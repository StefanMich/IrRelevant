using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrRelevant.Model
{
    public enum IconPlaceholder { Book, Video, List};
    public class Item
    {
        public string Title { get; set; }
        public IconPlaceholder Icon { get; set; }
        public string Content { get; set; }
    }
}
