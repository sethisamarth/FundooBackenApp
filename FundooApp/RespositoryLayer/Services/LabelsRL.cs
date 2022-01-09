using FundooApp.Controllers;
using RespositoryLayer.Context;
using RespositoryLayer.Entity;
using RespositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RespositoryLayer.Services
{
    public class LabelsRL:ILabelsRL
    {
        FundooContext context;
        public LabelsRL(FundooContext context)
        {
            this.context = context;
        }
        public bool AddLables(LabelModel model)
        {
            try
            {
                Labels newLabel = new Labels();
                newLabel.Label = model.Label;
                newLabel.NotesId = model.NotesId;
                //Adding the data to database
                this.context.LabelsTable.Add(newLabel);
                //Save the changes in database
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Labels> RetrieveLables()
        {
            try
            {
                return context.LabelsTable.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveLable(long lableId)
        {
            try
            {
                if (lableId > 0)
                {
                    var lables = this.context.LabelsTable.Where(x => x.LableId == lableId).SingleOrDefault();
                    this.context.LabelsTable.Remove(lables);
                    this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateLabels(LabelModel model)
        {
            if (model != null)
            {
                Labels labels = new Labels();
                labels.NotesId = model.NotesId;
                labels.Label = model.Label;
                this.context.LabelsTable.Update(labels);
            }
            //Save the changes in database
            int result = this.context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}