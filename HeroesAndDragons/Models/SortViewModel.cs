using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState Current { get; private set; }
        //public SortViewModel(SortState sortState)
        //{
        //    NameSort = sortState == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
        //    Current = sortState;
        //}
    }
}
