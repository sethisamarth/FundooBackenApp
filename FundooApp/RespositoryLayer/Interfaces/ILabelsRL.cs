using CommonLayer.Model;
using FundooApp.Controllers;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespositoryLayer.Interfaces
{
    public interface ILabelsRL
    {
       public bool AddLables(LabelModel model, long Id);
        IEnumerable<Labels> RetrieveLables();
       public bool RemoveLable(long lableId);
        bool UpdateLabel(LabelModel1 model, long labelId);
    }
}
