using FundooApp.Controllers;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ILabelsBL
    {
       public bool AddLables(LabelModel model);
        IEnumerable<Labels> RetrieveLables();
        bool RemoveLable(long lableId);
        bool UpdateLabels(LabelModel model);
    }
}
