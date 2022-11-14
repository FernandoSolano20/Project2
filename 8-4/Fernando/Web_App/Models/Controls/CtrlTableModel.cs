using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlTableModel : CtrlBaseModel
    {
        public CtrlTableModel()
        {
            Columns = "";
        }

        
        public string Title { get; set; }
        public string Columns { get; set; }
        public string ColumnsDataName { get; set; }
        public string FunctionName { get; set; }

        public int ColumnsCount => Columns.Split(',').Length;

        public string ColumnHeaders
        {
            get
            {
                var headers = "";
                foreach(var text in Columns.Split(','))
                {
                    headers += "<th class=\"th-sm\">" + text + "</th>";
                }

                return headers;
            }
        }

        public bool hasButton { get; set; }

        public string ButtonId { get; set; }

        public string ButtonType { get; set; }

        public string ButtonLabel { get; set; }

        public string ButtonFunction { get; set; }

        public string ButtonToggle { get; set; }

        public string ButtonTarget { get; set; }

        public string Button
        {
            get
            {
                string button = "";
                if (this.hasButton)
                {
                    button = $"<button type =\"button\" id=\"{this.ButtonId}\" class=\"btn btn-{this.ButtonType} btn-sm\" style=\"margin-left: 5px; margin-right: 25px; float: right\" data-toggle=\"{this.ButtonToggle}\" data-target=\"#{this.ButtonTarget}\">{this.ButtonLabel}</button>";
                }
                return button;
            }
        }

        


    }
}