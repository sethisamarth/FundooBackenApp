using BusinessLayer.Interfaces;
using FundooApp.Controllers;
using RespositoryLayer.Entity;
using RespositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LabelsBL : ILabelsBL
    {
        ILabelsRL labelsRL;
        public LabelsBL(ILabelsRL labelsRL)
        {
            this.labelsRL = labelsRL;

        }
        public bool AddLables(LabelModel model, long Id)
        {
            try
            {
                return this.labelsRL.AddLables(model, Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool EditLabel(long labelId, LabelModel model)
        {
            try
            {
                return this.labelsRL.EditLabel(labelId,model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool RemoveLable(long lableId)
        {
            try
            {
                return this.labelsRL.RemoveLable(lableId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<Labels> RetrieveLables()
        {
            try
            {
                return this.labelsRL.RetrieveLables();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
