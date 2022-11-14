using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Controls;

namespace Web_App.Models.Controls
{
    public class CtrlModalFormModel : CtrlBaseModel
    {
        public CtrlModalFormModel()
        {
            InputColumnDataNames = "";
            InputIds = "";
            InputTypes = "";
            InputPlaceholders = "";
            InputLabels= "";
            InputClasses = "";
            InputValues = "";
        }

        
        public string Title { get; set; }

        public string ModalFormId { get; set; }

        public string Text { get; set; }

        public string Inputs
        {
            get
            {
                var inputs = "";
                var inputColumnDataNames = InputColumnDataNames.Split(',');
                var inputTypes = InputTypes.Split(',');
                var inputIds = InputIds.Split(',');
                var inputPlaceHolders = InputPlaceholders.Split(',');
                var inputLabels = InputLabels.Split(',');
                var inputClasses = InputClasses.Split(',');
                var inputValues = InputValues.Split(',');
                int position = 0;

                foreach (var text in inputColumnDataNames)
                {
                    inputs += $"<div class='md-form'>" +
                                 $"<input type = \"{inputTypes[position]}\" class=\"form-control {inputClasses[position]}\" id=\"{inputIds[position]}\" placeholder=\"{inputPlaceHolders[position]} \" ColumnDataName=\"{inputColumnDataNames[position]}\" value=\"{inputValues[position]}\">" +
                                 $"<label for=\"{inputIds[position]}\">{inputLabels[position]}</label>" +
                             "</div>";
                    position++;
                }
                return inputs;
            }
        }

        public string InputColumnDataNames { get; set; }

        public string InputIds { get; set; }

        public string InputTypes { get; set; }

        public string InputPlaceholders { get; set; }

        public string InputLabels { get; set; }

        public string InputClasses { get; set; }

        public string InputValues { get; set; }

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