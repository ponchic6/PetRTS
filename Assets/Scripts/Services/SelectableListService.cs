using System.Collections.Generic;
using Logic.MonoBehaviors.View;

namespace Services
{
    public class SelectableListService
    {
        public List<SelectStatusChanger> AllSelectableObjects = new List<SelectStatusChanger>();
        public List<SelectStatusChanger> CurrentSelectObjects = new List<SelectStatusChanger>();
    }
}