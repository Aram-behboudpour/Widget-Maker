using Infrastructure;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;

namespace Server.Pages;

public class TestXmlModel : BasePageModel
{
    public TestXmlModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        JsonOutput = string.Empty;
    }
    public string JsonOutput { get; set; }
    public void OnGet()
    {
        string xmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "xml", "sampleXmlFile.xml");

        try
        {
            if (!System.IO.File.Exists(xmlFilePath))
            {
               // Message = "❌ فایل XML یافت نشد.";
                return;
            }

            var xmlContent = System.IO.File.ReadAllText(xmlFilePath);

            
            XmlHelper.GetComponentsForUserTask(xmlContent, "Activity_03ffu17");

            string successMessage= "✅ فایل XML با موفقیت پردازش شد.";

            AddToastSuccess(message: successMessage);

        }
        catch (Exception ex)
        {
            AddToastError(message: ex.Message);
        }
    }
}
