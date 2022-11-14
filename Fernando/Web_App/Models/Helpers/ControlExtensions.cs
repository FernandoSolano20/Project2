using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_App.Models.Controls;
using WebApp.Models.Controls;

namespace WebApp.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
            string columnsTitle, string ColumnsDataName, string onSelectFunction, string colorHeader, bool hasButton = false, string buttonId = "", string buttonType ="", string buttonLabel ="", string buttonFunction ="", string buttonToggle = "", string buttonTarget = "")
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction,
                hasButton = hasButton,
                ButtonId = buttonId,
                ButtonType = buttonType,
                ButtonLabel = buttonLabel,
                ButtonFunction = buttonFunction,
                ButtonToggle = buttonToggle,
                ButtonTarget = buttonTarget
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlChart(this HtmlHelper html, string viewName, string id, string title,
            string labels, string chartType, string onLoadFunction)
        {
            var ctrl = new CtrlChartModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Labels = labels,
                ChartType = chartType,
                OnLoadFunction = onLoadFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInput(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName="")
        {
            var ctrl = new CtrlInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder=placeHolder,
                ColumnDataName=columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string label, string onClickFunction="", string buttonType="primary")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDown(this HtmlHelper html, string name, string columnDataName, string id, string label, bool isAjax, string length, string searchText, string disabled = "", string labelOptionDisable = "", string listId = "")
        {
            var ctrl = new CtrlDropDownModel
            {
                Id = id,
                ColumnDataName = columnDataName,
                Name = name,
                Label = label,
                ListId = listId,
                Length = length,
                Search = searchText,
                OptionsAjax = isAjax,
                LabelOption = labelOptionDisable,
                Disabled = disabled
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlModalForm(this HtmlHelper html, string viewName, string id, string modalFormId, string title, string text, string inputColumnDataNames, string inputIds, string inputTypes, string inputPlaceholders, string inputLabels, string btnActionId, string btnActionType, string btnActionText, string btnActionFunction, string btnCancelId, string btnCancelType, string btnCancelText, string btnCancelFunction, string inputClasses = ",")
        {

            var ctrl = new CtrlModalFormModel
            {
                ViewName = viewName,
                Id = id,
                ModalFormId = modalFormId,
                Title = title,
                Text = text,
                InputColumnDataNames = inputColumnDataNames,
                InputIds = inputIds,
                InputTypes = inputTypes,
                InputClasses = inputClasses,
                InputPlaceholders = inputPlaceholders,
                InputLabels = inputLabels,
                BtnActionId = btnActionId,
                BtnActionType = btnActionType,
                BtnActionText = btnActionText,
                BtnActionFunction = btnActionFunction,
                BtnCancelId = btnCancelId,
                BtnCancelType = btnCancelType,
                BtnCancelText = btnCancelText,
                BtnCancelFunction = btnCancelFunction,
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlModalMessage(this HtmlHelper html, string viewName, string id, string modalFormId, string title, string text, string btnActionId, string btnActionType, string btnActionText, string btnActionFunction, string btnCancelId, string btnCancelType, string btnCancelText, string btnCancelFunction, string spanId = "", string spanClasses = "", string spanColumnDataName = "")
        {
            var ctrl = new CtrlModalMessageModel
            {
                ViewName = viewName,
                Id = id,
                ModalFormId = modalFormId,
                Title = title,
                Text = text,
                SpanId = spanId,
                SpanClasses = spanClasses, 
                SpanColumnDataName = spanColumnDataName,
                BtnActionId = btnActionId,
                BtnActionType = btnActionType,
                BtnActionText = btnActionText,
                BtnActionFunction = btnActionFunction,
                BtnCancelId = btnCancelId,
                BtnCancelType = btnCancelType,
                BtnCancelText = btnCancelText,
                BtnCancelFunction = btnCancelFunction,
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputFormModel(this HtmlHelper html, string viewName, string columnDataName, string name, string lengthColumn, string anchor, string id, string label, string cssClass, string type, bool isRequired, string validMessage = "", string invalidMessage = "", string value = "", bool disabled = false, string labelClass = "", string dataFormat = "", string dataMask = "")
        {
            var ctrl = new CtrlInputFormModel
            {
                ViewName = viewName,
                ColumnDataName = columnDataName,
                Name = name,
                LengthColumn = lengthColumn,
                Anchor = anchor,
                Id = id,
                Label = label,
                Type = type,
                IsRequired = isRequired,
                ValidFeedback = validMessage,
                InvalidFeedback = invalidMessage,
                Value = value,
                CssClass = cssClass,
                LabelClass = labelClass,
                Disabled = disabled ? "disabled" : "",
                DataFormat = dataFormat,
                DataMask = dataMask
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputLabelModel(this HtmlHelper html, string viewName, string columnDataName, string id, string name, string type, string label, bool isRequired, bool mostrarMensaje, string validMessage = "", string invalidMessage = "", string cssContainer = "", string classInput = "", string  placeholder = "", string valor = "", string labelClass = "")
        {
            var ctrl = new CtrlInputLabelModel
            {
                ViewName = viewName,
                ColumnDataName = columnDataName,
                Id = id,
                Name = name,
                Label = label,
                IsRequired = isRequired,
                ValidFeedback = validMessage,
                InvalidFeedback = invalidMessage,
                MostarMensajes = mostrarMensaje,
                ContainerCss = cssContainer,
                Placeholder = placeholder,
                Type = type,
                ClassInput = classInput,
                LengthColumn = "",
                Anchor = "",
                Value = valor,
                CssClass = "",
                LabelClass = labelClass,
                Disabled = ""
            };

            return new HtmlString(ctrl.GetHtml());
        }
    }
}