using Entities_POJO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using POJO_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDropDownModel : CtrlBaseModel
    {
        public string ColumnDataName { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Label { get; set; }
        public string ListId { get; set; }
        public string Length { get; set; }
        public string Search { get; set; }
        public bool OptionsAjax { get; set; }
        public string LabelOption { get; set; }
        public string Disabled { get; set; }

        private string URL_API_LISTs = "https://localhost:44347/api/List/";

        public string ListOptions
        {
            get
            {
                var htmlOptions = "";
                if (OptionsAjax) return htmlOptions;
                
                var lst = GetOptionsFromAPI();

                foreach(var option in lst)
                {
                    htmlOptions += "<option value='" + option.Value + "'>" + option.Description + "</option>";
                }
                return htmlOptions;
            }
        }


        private List<OptionList> GetOptionsFromAPI()
        {
            var client = new HttpClient { BaseAddress = new Uri(URL_API_LISTs + ListId) };
            var responseMessage = client.GetAsync(URL_API_LISTs + ListId, HttpCompletionOption.ResponseContentRead);
            var resultAsync = responseMessage.GetAwaiter().GetResult().Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(resultAsync.GetAwaiter().GetResult());
            var options = JsonConvert.DeserializeObject<List<OptionList>>(apiResponse.Data.ToString());

            return options;
        }


    
        public CtrlDropDownModel()
        {
            ViewName = "";
        }
    }
}