using BusinessLayer.Interfaces;
using CommonLayer.Model;
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
        /// <summary>
        /// Adds the lables.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Removes the lable.
        /// </summary>
        /// <param name="lableId">The lable identifier.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Retrieves the lables.
        /// </summary>
        /// <returns></returns>
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

        public bool UpdateLabel(LabelModel1 model, long labelId)
        {
            try
            {
                return this.labelsRL.UpdateLabel(model, labelId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
