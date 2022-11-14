using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Controls;

namespace Web_App.Models.Controls
{
    public class CtrlModalMessageModel : CtrlBaseModel
    {

        public string Title { get; set; }
        public string ModalFormId { get; set; }
        public string Text { get; set; }
        public string SpanId { get; set; }
        public string SpanClasses { get; set; }
        public string SpanColumnDataName { get; set; }

        public string BtnActionId { get; set; }
        public string BtnActionType { get; set; }
        public string BtnActionText { get; set; }
        public string BtnActionFunction { get; set; }

        public string BtnCancelId { get; set; }
        public string BtnCancelType { get; set; }
        public string BtnCancelText { get; set; }
        public string BtnCancelFunction { get; set; }
    }
}