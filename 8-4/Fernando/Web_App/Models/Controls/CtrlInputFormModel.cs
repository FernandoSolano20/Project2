using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Controls;

namespace Web_App.Models.Controls
{
    public class CtrlInputFormModel : CtrlBaseModel
    {
        private string _dataFormat;
        private string _mask;
        public string ColumnDataName { get; set; }
        public string Name { get; set; }
        public string LengthColumn { get; set; }
        public string Anchor { get; set; }
        public string Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public string Required => IsRequired ? "required" : string.Empty;
        public string ValidFeedback { get; set; }
        public string InvalidFeedback { get; set; }
        public string CssClass { get; set; }
        public string LabelClass { get; set; }
        public string Disabled { get; set; }

        public string DataFormat
        {
            get => !string.IsNullOrEmpty(_dataFormat) ? "data-format=\"" +_dataFormat  + "\"" : "";
            set => _dataFormat = value;
        }

        public string DataMask {
            get => !string.IsNullOrEmpty(_mask) ? "data-mask=\"" + _mask + "\"" : "";
            set => _mask = value;
        }
        public CtrlInputFormModel()
        {
            ViewName = "";
        }
    }
}