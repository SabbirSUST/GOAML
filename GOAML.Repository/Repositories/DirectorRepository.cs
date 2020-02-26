using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.DomainModels.Models;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.Helper;
using GOAML.Repository.IRepositories;

namespace GOAML.Repository.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        public DirectorDetail GetDirector(long cifValue)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbDirector = dbEntities.director_detail.FirstOrDefault(i => i.entity_id == cifValue);
                    return ConvertToLocalObject(dbDirector, new DirectorDetail()) ?? new DirectorDetail();
                }
            }
            catch (Exception)
            {
                return new DirectorDetail();
            }
        }

        public List<DirectorDetail> GetDirectors(long cifValue)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbDirectorList = dbEntities.director_detail.Where(i => i.entity_id == cifValue).ToList();
                    var directorList = new List<DirectorDetail>();
                    foreach (var dbdirectorDetail in dbDirectorList)
                    {
                        directorList.Add(ConvertToLocalObject(dbdirectorDetail, new DirectorDetail()));
                    }
                    return directorList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DbResponse SaveDirectorDetails(DirectorDetail directorDetail)
        {
            using (var dbEntities = new GOAMLEntities())
            {
                try
                {
                    var dbDirectorDetails = ConvertToDbObject(directorDetail, new director_detail());
                    if (directorDetail.t_person_id > 0)
                    {
                        dbDirectorDetails.updateBy = "System";
                        dbDirectorDetails.updateDate = System128.GetToday;
                        dbEntities.Entry(dbDirectorDetails).State = EntityState.Modified;
                    }
                    else
                    {
                        dbEntities.director_detail.Add(dbDirectorDetails);
                    }
                    dbEntities.SaveChanges();
                    return System128.SuccessMessage("Job Complete.");
                }
                catch (Exception)
                {
                    return System128.FailureMessage("Job Failed.");
                }
            }
        }


        public DirectorDetail ConvertToLocalObject(director_detail convertedFrom, DirectorDetail convertedTo)
        {
            var converter = new ConvertTypeInto<director_detail, DirectorDetail>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }

        public director_detail ConvertToDbObject(DirectorDetail convertedFrom, director_detail convertedTo)
        {
            var converter = new ConvertTypeInto<DirectorDetail, director_detail>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }
    }
}
