using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public interface IDropDownItemData
    {
        string Text { get; }
        string Value { get; }
        string Icon { get; }
        bool Selected { get; set; }
    }
}
