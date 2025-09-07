using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Faraz.Security;

public class Hashing : object
{
    public Hashing() : base()
    {
    }

    public static string GetSha256(string value)
    {
        var inputBytes = System.Text
            .Encoding.UTF8.GetBytes(s: value);

        //using var sha = System.Security
        //	.Cryptography.SHA256.Create();

        //var outputBytes =
        //	sha.ComputeHash(buffer: inputBytes);

        var outputBytes =
            System.Security.Cryptography
            .SHA256.HashData(source: inputBytes);

        var result =
            System.Convert
            .ToBase64String(inArray: outputBytes);

        return result;
    }
    // Function to hash a password using Argon2
    public static string HashPassword(string password)
    {
        // Generate a random salt (16 bytes)
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        // Create a new Argon2i hash object
        using (var argon2 = new Argon2i(Encoding.UTF8.GetBytes(password)))
        {
            // Set Argon2 parameters
            argon2.DegreeOfParallelism = 8; // Number of parallel threads (can adjust based on the system)
            argon2.MemorySize = 1024 * 1024; // Memory cost (1MB)
            argon2.Iterations = 4; // Number of iterations (higher values = more secure)

            // Hash the password with the salt
            argon2.Salt = salt;

            byte[] hash = argon2.GetBytes(32); // Generate the 32-byte hash
            string base64Hash = Convert.ToBase64String(hash); // Convert hash to Base64 string for storage

            // Include the salt in the stored data (to be used during comparison)
            string saltBase64 = Convert.ToBase64String(salt);
            return $"{saltBase64}${base64Hash}";
        }
    }

    // Function to verify the entered password against the stored hash
    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        // Split the stored hash into the salt and hash
        var parts = storedHash.Split('$');
        if (parts.Length != 2)
        {
            throw new ArgumentException("Stored hash format is invalid.");
        }

        string saltBase64 = parts[0];
        string hashBase64 = parts[1];

        byte[] salt = Convert.FromBase64String(saltBase64);
        byte[] storedHashBytes = Convert.FromBase64String(hashBase64);

        // Create a new Argon2i instance with the entered password
        using (var argon2 = new Argon2i(Encoding.UTF8.GetBytes(enteredPassword)))
        {
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8;
            argon2.MemorySize = 1024 * 1024;
            argon2.Iterations = 4;

            // Generate the hash for the entered password
            byte[] hashToCompare = argon2.GetBytes(32);

            // Use constant-time comparison to avoid timing attacks
            return AreHashesEqual(storedHashBytes, hashToCompare);
        }
    }

    // Function to compare two hashes in constant time
    public static bool AreHashesEqual(byte[] storedHash, byte[] hashToCompare)
    {
        if (storedHash.Length != hashToCompare.Length)
        {
            return false;
        }

        int result = 0;

        for (int i = 0; i < storedHash.Length; i++)
        {
            result |= storedHash[i] ^ hashToCompare[i];
        }

        return result == 0;
    }
}
