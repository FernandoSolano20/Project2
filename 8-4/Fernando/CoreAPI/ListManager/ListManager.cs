using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.ListOption;
using Excepciones;
using POJO_Entities.Entities;

namespace CoreAPI.ListManager
{
    public class ListManager : BaseManager
    {
        private static Dictionary<string, List<OptionList>> dicListOptions;
        //private ListCrudFactory crudCustomer;

        public ListManager(string id)
        {
            LoadDictionary(id);
            //crudCustomer = new ListCrudFactory();
        }

        private void LoadDictionary(string id)
        {
            if(dicListOptions != null && dicListOptions.ContainsKey(id)) return;
            dicListOptions = new Dictionary<string, List<OptionList>>();
            //TODO: ESTO DEBE VENIR DE ELA BASE DE DATOS
            var crudList = new ListOptionCrudFactory();

            var lists = crudList.RetrieveAll<OptionList>();

            var lstId = "";
            var lstOptions = new List<OptionList>();

            foreach (var l in lists)
            {
                if (!lstId.Equals(l.ListId))
                {
                    lstOptions = new List<OptionList>();
                    lstOptions.Add(new OptionList { ListId = l.ListId, Value = l.Value.Trim(), Description = l.Description });
                    dicListOptions[l.ListId] = lstOptions;
                    lstId = l.ListId;
                }
                else
                {
                    lstOptions.Add(new OptionList { ListId = l.ListId, Value = l.Value.Trim(), Description = l.Description });
                    dicListOptions[l.ListId] = lstOptions;
                }

            }
        }

        public List<OptionList> RetrieveById(OptionList option)
        {

            try
            {
                if (dicListOptions.ContainsKey(option.ListId))
                {
                    return dicListOptions[option.ListId];
                }
                else if (option.ListId.Equals("LST_PROVINCIA"))
                {
                    var manager = new LocalizacionManager.LocalizacionManager();
                    var lst = manager.ObtenerProvincias();

                    var lstResult = new List<OptionList>();

                    foreach (var c in lst)
                    {
                        var newOption = new OptionList { ListId = option.ListId, Value = c, Description = c };
                        lstResult.Add(newOption);
                    }
                    return lstResult;
                }
                else if (option.ListId.Equals("LST_PAISES"))
                {
                    var manager = new LocalizacionManager.LocalizacionManager();
                    var lst = manager.ObtenerPaises();

                    var lstResult = new List<OptionList>();

                    foreach (var c in lst)
                    {
                        var newOption = new OptionList { ListId = option.ListId, Value = c, Description = c };
                        lstResult.Add(newOption);
                    }
                    return lstResult;
                }
                else if (option.ListId.Equals("LST_MONEDA"))
                {
                    var manager = new MonedaManager.MonedaManager();
                    var lst = manager.ObtenerMonedaPaises();

                    var lstResult = new List<OptionList>();

                    foreach (var c in lst)
                    {
                        var newOption = new OptionList { ListId = option.ListId, Value = c, Description = c };
                        lstResult.Add(newOption);
                    }
                    return lstResult;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return new List<OptionList>(); ;
        }
    }
}
