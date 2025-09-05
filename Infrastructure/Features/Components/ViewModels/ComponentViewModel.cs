using oc.TSB.Core.Features.CamundaProcesses.Enums;
using System;
using System.Collections.Generic;

namespace oc.TSB.Infrastructure.Features.Components.ViewModels;

public class ComponentViewModel : object
{
    public ComponentViewModel() : base()
    {
        Type =
            string.Empty;

        TextInputProperties =
            new TextInputProps();

        CheckBoxProperties =
            new CheckBoxProps();

        ButtonProperties=
            new ButtonProps();
    }
    public ComponentType ComponentType { get; set; }
    public Guid ComponentId { get; set; }
    public string Type { get; set; }
    public int Order { get; set; }
    public Guid? ParentComponentId { get; set; }
    public TextInputProps TextInputProperties { get; set; }
    public CheckBoxProps CheckBoxProperties { get; set; }
    public ButtonProps ButtonProperties { get; set; }

    public class TextInputProps
    {
        public TextInputProps()
        {
            Label =
                string.Empty;

            Type =
                string.Empty;

            SubmitRequiredFields =
                new Dictionary<string, object>();
        }
        public Dictionary<string, object> SubmitRequiredFields { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
    }

    public class CheckBoxProps
    {
        public CheckBoxProps()
        {
            Label =
             string.Empty;

            Type =
                string.Empty;

            SubmitRequiredFields =
                new Dictionary<string, object>();
        }
        public Dictionary<string, object> SubmitRequiredFields { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public bool Value { get; set; }
    }

    public class SubmitField
    {
        public SubmitField()
        {
            Value =
            string.Empty;
        }
        public string Value { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsRequired { get; set; }
    }

    public class ButtonProps
    {
        public ButtonProps()
        {
            Type =
            string.Empty;
        }
        public string Type { get; set; }
    }
}
