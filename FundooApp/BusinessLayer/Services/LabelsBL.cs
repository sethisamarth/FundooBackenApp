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
        public bool AddLables(LabelModel model)
        {
            try
            {
                return this.labelsRL.AddLables(model);
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

        public bool UpdateLabels(LabelModel model)
        {
            try
            {
                return this.labelsRL.UpdateLabels( model);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
