using System;
using System.Data;
using GOAML.DomainModels.Models;
using GOAML.Repository.CustomStatic;

namespace GOAML.Repository.Helper
{
    class GenericClass
    {
        public static GOAMLEntities RecreateContext(GOAMLEntities context, int count, int commitCount, bool recreateContext)
        {
            try
            {
                if (count % commitCount == 0)
                {
                    context.SaveChanges();
                    if (recreateContext)
                    {
                        context.Dispose();
                        context = new GOAMLEntities();
                        context.Configuration.AutoDetectChangesEnabled = false;
                    }
                }
                return context;
            }
            catch (EntityException entityException)
            {
                System128.ExceptionMessage(entityException);
                return null;
            }
            catch (Exception exception)
            {
                System128.ExceptionMessage(exception);
                return null;
            }
        }
    }
}
