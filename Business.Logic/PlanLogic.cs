using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PlanLogic:BusinessLogic
    {
        public Data.Database.PlanAdapter PlanData { get; set; }

        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }

        public void Save(Business.Entities.Plan plan)
        {
            PlanData.Save(plan);
        }

        public void Update(Business.Entities.Plan plan)
        {
            PlanData.Update(plan);
        }
    }
}
