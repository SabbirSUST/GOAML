using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GOAML.Repository.Helper
{
    /// <summary>
    ///T is the input
    /// and E is Output
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    public class ConvertTypeInto<T,TE>
    {
        public TE ConvertInto(T convertable, TE convertedInto)
        {
            try
            {
                var myType = convertable.GetType();
                var props = new List<PropertyInfo>(myType.GetProperties());

                foreach (var prop in props)
                {
                    var propValue = prop.GetValue(convertable, null);
                    var prInfo = convertedInto.GetType().GetProperty(prop.Name);
                    if (prInfo!=null)
                        prInfo.SetValue(convertedInto, propValue);
                    // Do something with propValue
                }
                return convertedInto;
            }
            catch (Exception)
            {
                throw new Exception("Some Problem Happened Converting Entity Framework.");
            }
        }

        public List<TE> ConvertInto(List<T> convertable)
        {
            try
            {
                var myType = convertable.First().GetType();
                var props = new List<PropertyInfo>(myType.GetProperties());

                var convertedList = new List<TE>();
                foreach (var convert in convertable)
                {
                    foreach (var prop in props)
                    {
                        var propValue = prop.GetValue(convert, null);
                        var prInfo = convert.GetType().GetProperty(prop.Name);
                        if (prInfo != null)
                            prInfo.SetValue(convert, propValue);
                    }
                }
                return convertedList;
            }
            catch (Exception)
            {
                throw new Exception("Some Problem Happened Converting Entity Framework.");
            }
        }
    }

    //public static class CastList<FromType, ToType> : IList<ToType>
    //{
    //    public CastList(IList<FromType> source, Func<FromType, ToType> converter)
    //    {
        
    //    }
    //}
}
