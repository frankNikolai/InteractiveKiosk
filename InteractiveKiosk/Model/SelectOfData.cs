using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveKiosk.Model
{
    class SelectOfData
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        public string SelectName(int idAtt)
        {
            return  (from i in entities.Attraction
                    where i.ID == idAtt
                     select i.Name).FirstOrDefault();
        }
        public string SelectHoldingCapacity(int idAtt)
        {
            return (from i in entities.Descriptions
                               where i.ID == (from j in entities.Attraction
                                              where j.ID == idAtt
                                              select j.Description_ID).FirstOrDefault()
                               select i.HoldingCapacity).FirstOrDefault().ToString() + " человек";
        }
        public string SelectPermissibleLoad(int idAtt)
        {
            return (from i in entities.Descriptions
                    where i.ID == (from j in entities.Attraction
                                   where j.ID == idAtt
                                   select j.Description_ID).FirstOrDefault()
                    select i.PermissibleLoad).FirstOrDefault().ToString() + " кг.";
        }
        public string SelectAgeGroup(int idAtt)
        {
            return (from i in entities.AgeGroup
                    where i.ID == (from j in entities.Descriptions
                                   where j.ID == (from k in entities.Attraction
                                                  where k.ID == idAtt
                                                  select k.Description_ID).FirstOrDefault()
                                   select j.ID).FirstOrDefault()
                    select i.Name).FirstOrDefault().ToString();
        }
        public string SelectWorkOfTime(int idAtt)
        {
            string timeWork_1 = (from i in entities.Descriptions
                                 where i.ID == (from j in entities.Attraction
                                                where j.ID == idAtt
                                                select j.Description_ID).FirstOrDefault()
                                 select i.WorkingHours_1).FirstOrDefault().ToString();
            string timeWork_2 = (from i in entities.Descriptions
                                 where i.ID == (from j in entities.Attraction
                                                where j.ID == idAtt
                                                select j.Description_ID).FirstOrDefault()
                                 select i.WorkingHours_2).FirstOrDefault().ToString();
            return timeWork_1 + " - " + timeWork_2;
        }
        public string SelectLocation(int idAtt)
        {
            return (from i in entities.Location
                    where i.ID == (from j in entities.Descriptions
                                   where j.ID == (from k in entities.Attraction
                                                  where k.ID == idAtt
                                                  select k.Description_ID).FirstOrDefault()
                                   select j.Location_ID).FirstOrDefault()
                    select i.Name).FirstOrDefault();
        }
        public string SelectDeveloper(int idAtt)
        {
            string mName = (from i in entities.Developer
                            where i.ID == (from j in entities.Descriptions
                                           where j.ID == (from k in entities.Attraction
                                                          where k.ID == idAtt
                                                          select k.Description_ID).FirstOrDefault()
                                           select j.Developer_ID).FirstOrDefault()
                            select i.MiddleName).FirstOrDefault();
            if (mName == "" || mName == null)
            {
                return (from i in entities.Developer
                        where i.ID == (from j in entities.Descriptions
                                       where j.ID == (from k in entities.Attraction
                                                      where k.ID == idAtt
                                                      select k.Description_ID).FirstOrDefault()
                                       select j.Developer_ID).FirstOrDefault()
                        select i.FirstName + " " + i.LastName).FirstOrDefault();
            }
            else
            {
                return (from i in entities.Developer
                        where i.ID == (from j in entities.Descriptions
                                       where j.ID == (from k in entities.Attraction
                                                      where k.ID == idAtt
                                                      select k.Description_ID).FirstOrDefault()
                                       select j.Developer_ID).FirstOrDefault()
                        select i.FirstName.Substring(0, 1) + "." +
                        i.MiddleName.Substring(0, 1) + ". " + i.LastName).FirstOrDefault();
            }
        }
        public string SelectDateOfCreate(int idAtt)
        {
            return (from i in entities.Descriptions
                    where i.ID == (from j in entities.Attraction
                                   where j.ID == idAtt
                                   select j.Description_ID).FirstOrDefault()
                    select i.DateOfCreation.ToString().Substring(0, 13)).FirstOrDefault();
        }
        public string SelectNumbersupport(int idAtt)
        {
            return (from i in entities.Descriptions
                    where i.ID == (from j in entities.Attraction
                                   where j.ID == idAtt
                                   select j.Description_ID).FirstOrDefault()
                    select i.Support).FirstOrDefault().ToString();
        }
        public string SelectCost(int idAtt)
        {
            return (from i in entities.Attraction
                    where i.ID == idAtt
                    select i.Cost).FirstOrDefault().ToString();
        }
    }
}
