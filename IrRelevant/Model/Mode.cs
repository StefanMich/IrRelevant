using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrRelevant.Model
{
    public class Mode
    {
        public Mode(string title)
        {
            Title = title;
            subCategories = new List<SubCategory>();
            items = new List<Item>();
        }

        public string Title { get; set; }

        private List<SubCategory> subCategories;

        public List<SubCategory> SubCategories
        {
            get { return subCategories; }
        }

        public List<Item> items;

        public List<Item> Items { get { return items; } }
        
    }
}
