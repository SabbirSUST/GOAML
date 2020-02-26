using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GOAML.Repository.Helper
{
    public class ServiceToSelectItem<T>
    {
        public List<ListItem> GetSelectListItems(List<T> serviceList,string optGroup)
        {
            var listItems = new List<ListItem>();
            foreach (T service in serviceList)
            {
                var selectList = new ListItem
                {
                    Value = (service.GetType().GetProperty("Id")).GetValue(service).ToString(),
                    Text = (service.GetType().GetProperty("showtext")).GetValue(service).ToString()
                };
                selectList.Attributes["OptionGroup"] = optGroup;
                listItems.Add(selectList);
            }
            return listItems;
        }

        public List<ListItem> GetSelectListItems(List<T> serviceList)
        {
            var listItems = new List<ListItem>();
            foreach (T service in serviceList)
            {
                var selectList = new ListItem
                {
                    Value = (service.GetType().GetProperty("Id")).GetValue(service).ToString(),
                    Text = (service.GetType().GetProperty("showtext")).GetValue(service).ToString()
                };
                listItems.Add(selectList);
            }
            return listItems;
        }
    }
}
