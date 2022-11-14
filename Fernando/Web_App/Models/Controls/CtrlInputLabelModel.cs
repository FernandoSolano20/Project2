using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_App.Models.Controls
{
    public class CtrlInputLabelModel:CtrlInputFormModel
    {
        public string ColumnDataName { get; set; }
        private string _cssClassContainer;
        private string _placeholder;
        public bool MostarMensajes { get; set; }
        public string Placeholder {
            get => !string.IsNullOrEmpty(_placeholder)? "placeholder = \"" +_placeholder + "\"":"";
            set => _placeholder = value;
        }
        public string ClassInput { get; set; }
        public string HtmlValidMessage => MostarMensajes ? "<div class=\"valid-feedback\"> " + ValidFeedback + " </div>" : string.Empty;
        public string HtmlInvalidMessage => MostarMensajes ? "<div class=\"invalid-feedback\"> " + InvalidFeedback + " </div>" : string.Empty;
        public string ContainerCss
        {
            get => _cssClassContainer;
            set => _cssClassContainer = value;
        }
    }
}