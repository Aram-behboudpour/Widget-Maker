using oc.TSB.Core.Features.CamundaProcesses.Enums;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Infrastructure.Helper;

public static class XmlHelper : object
{
    static XmlHelper()
    {
    }
    public static void ParseXml(string xml)
    {
        // Escape invalid ampersands (& not part of a valid entity)
        string safeXml = EscapeXmlEntitiesSmart(xml);
        var xdoc = XDocument.Parse(safeXml);

        XNamespace bpmn = "http://www.omg.org/spec/BPMN/20100524/MODEL";
        XNamespace camunda = "http://camunda.org/schema/1.0/bpmn";

        var process = xdoc.Descendants(bpmn + "process").FirstOrDefault();
        string processName = process?.Attribute("name")?.Value ?? "UnknownProcess";

        foreach (var userTask in xdoc.Descendants(bpmn + "userTask"))
        {
            string taskName = userTask.Attribute("name")?.Value ?? "UnnamedTask";
            string taskId = userTask.Attribute("id")?.Value ?? Guid.NewGuid().ToString();

            var viewJson = new Dictionary<string, object>
            {
                ["processName"] = processName,
                ["processLabel"] = processName,
                ["formName"] = taskName,
                ["formLabel"] = taskName
            };

            var componentList = new List<object>();

            var extensionElements = userTask.Element(bpmn + "extensionElements") ?? userTask.Element("extensionElements");
            var formData = extensionElements?.Element(camunda + "formData");
            var formFields = formData?.Elements(camunda + "formField");

            if (formFields != null)
            {
                foreach (var formField in formFields)
                {
                    string propId = formField.Attribute("id")?.Value ?? "";
                    string propLabel = formField.Attribute("label")?.Value ?? "";
                    string defaultVal = formField.Attribute("defaultValue")?.Value ?? "";

                    // space before each field
                    componentList.Add(new
                    {
                        type = "space",
                        componentId = Guid.NewGuid(),
                        parentComponentId = (string)null
                    });

                    if (defaultVal == "textInput")
                    {
                        componentList.Add(new
                        {
                            type = "textInput",
                            componentId = Guid.NewGuid(),
                            parentComponentId = (string)null,
                            textInputProperties = new
                            {
                                submitRequiredFields = new Dictionary<string, object>
                                {
                                    [propId] = new
                                    {
                                        value = "",
                                        isReadonly = false,
                                        isRequired = true
                                    }
                                },
                                label = propLabel,
                                type = "text"
                            }
                        });
                    }
                    else if (defaultVal == "checkBox")
                    {
                        componentList.Add(new
                        {
                            type = "checkBox",
                            componentId = Guid.NewGuid(),
                            parentComponentId = (string)null,
                            checkBoxProperties = new
                            {
                                submitRequiredFields = new Dictionary<string, object>
                                {
                                    [propId] = new
                                    {
                                        value = "",
                                        isReadonly = false,
                                        isRequired = true
                                    }
                                },
                                label = propLabel,
                                type = "checkBox",
                                value = false
                            }
                        });
                    }
                }
            }

            // Submit button
            componentList.Add(new
            {
                type = "button",
                componentId = Guid.NewGuid(),
                parentComponentId = (string)null,
                buttonProperties = new
                {
                    type = "submit"
                }
            });

            viewJson["componentsList"] = componentList;

            string jsonOutput = JsonSerializer.Serialize(viewJson, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // preserves Persian
            });

            File.WriteAllText($"{taskId}.json", jsonOutput);
            Console.WriteLine($"✅ فایل '{taskId}.json' با موفقیت ساخته شد.");
        }
    }

    static string EscapeXmlEntitiesSmart(string input)
    {
        // Only escape unescaped ampersands (to avoid double escaping &amp;)
        return Regex.Replace(input, @"&(?!amp;|lt;|gt;|quot;|apos;|#[0-9]+;)", "&amp;");
    }

    public static Dictionary<string, List<ComponentViewModel>> GetuserTaskComponents(string xml)
    {
        string safeXml = EscapeXmlEntitiesSmart(xml);
        var xdoc = XDocument.Parse(safeXml);

        XNamespace bpmn = "http://www.omg.org/spec/BPMN/20100524/MODEL";
        XNamespace camunda = "http://camunda.org/schema/1.0/bpmn";

        var process = xdoc.Descendants(bpmn + "process").FirstOrDefault();
        string processName = process?.Attribute("name")?.Value ?? "UnknownProcess";

        // دیکشنری خروجی: key = userTaskId, value = لیست کامپوننت‌ها
        var userTaskComponents = new Dictionary<string, List<ComponentViewModel>>();

        foreach (var userTask in xdoc.Descendants(bpmn + "userTask"))
        {
            string taskName = userTask.Attribute("name")?.Value ?? "UnnamedTask";
            string taskId = userTask.Attribute("id")?.Value ?? Guid.NewGuid().ToString();

            var componentList = new List<ComponentViewModel>();

            var extensionElements = userTask.Element(bpmn + "extensionElements") ?? userTask.Element("extensionElements");
            var formData = extensionElements?.Element(camunda + "formData");
            var formFields = formData?.Elements(camunda + "formField");

            if (formFields != null)
            {
                foreach (var formField in formFields)
                {
                    string propId = formField.Attribute("id")?.Value ?? "";
                    string propLabel = formField.Attribute("label")?.Value ?? "";
                    string defaultVal = formField.Attribute("defaultValue")?.Value ?? "";

                    componentList.Add(new ComponentViewModel
                    {
                        Type = "Space",
                        ComponentType = ComponentType.Space,
                        ComponentId = Guid.NewGuid(),
                        ParentComponentId = null
                    });

                    if (defaultVal == "TextInput")
                    {
                        componentList.Add(new ComponentViewModel
                        {
                            Type = "TextInput",
                            ComponentType = ComponentType.TextInput,
                            ComponentId = Guid.NewGuid(),
                            ParentComponentId = null,
                            TextInputProperties = new ComponentViewModel.TextInputProps
                            {
                                SubmitRequiredFields = new Dictionary<string, object>
                                {
                                    [propId] = new
                                    {
                                        value = "",
                                        isReadonly = false,
                                        isRequired = true
                                    }
                                },
                                Label = propLabel,
                                Type = "text"
                            }
                        });
                    }
                    else if (defaultVal == "CheckBox")
                    {
                        componentList.Add(new ComponentViewModel
                        {
                            Type = "CheckBox",
                            ComponentType = ComponentType.CheckBox,
                            ComponentId = Guid.NewGuid(),
                            ParentComponentId = null,
                            CheckBoxProperties = new ComponentViewModel.CheckBoxProps
                            {
                                SubmitRequiredFields = new Dictionary<string, object>
                                {
                                    [propId] = new
                                    {
                                        value = "",
                                        isReadonly = false,
                                        isRequired = true
                                    }
                                },
                                Label = propLabel,
                                Type = "checkBox",
                                Value = false
                            }
                        });
                    }
                }
            }

            // دکمه ارسال
            componentList.Add(new ComponentViewModel
            {
                Type = "Button",
                ComponentType = ComponentType.Button,   
                ComponentId = Guid.NewGuid(),
                ParentComponentId = null,
                ButtonProperties = new  ComponentViewModel.ButtonProps
                {
                    Type = "submit"
                }
            });

            // ذخیره لیست کامپوننت‌ها برای این userTask
            userTaskComponents[taskId] = componentList;
        }

        return userTaskComponents;
    }

    public static List<ComponentViewModel> GetComponentsForUserTask(string xml, string userTaskId)
    {
        var allComponents = GetuserTaskComponents(xml);

        if (allComponents.TryGetValue(userTaskId, out var components))
        {
            return components;
        }

        // اگر userTaskId یافت نشد، یک لیست خالی برگردان
        return new List<ComponentViewModel>();
    }

}

