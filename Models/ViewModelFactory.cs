using System.Collections.Generic;
using System.Linq;

namespace Upletter.Models
{
    public class ViewModelFactory
    {
        public static WordViewModel Details(Word w)
        {
            return new WordViewModel
            {
                Word = w,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false
            };
        }

        public static WordViewModel Create(Word w)
        {
            return new WordViewModel
            {
                Word = w,
                Action = "Create"
            };
        }

        public static WordViewModel Edit(Word w)
        {
            return new WordViewModel
            {
                Word = w,
                Theme = "warning",
                Action = "Edit"
            };
        }

        public static WordViewModel Delete(Word w)
        {
            return new WordViewModel
            {
                Word = w,
                Action = "Delete",
                ReadOnly = true,
                Theme = "danger"
            };
        }
    }
}
