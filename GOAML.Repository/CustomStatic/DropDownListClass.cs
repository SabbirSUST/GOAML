using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GOAML.DomainModels.Models;

namespace GOAML.Repository.CustomStatic
{
    public static class DropDownListClass
    {

        public static List<Branch_Info> GetBranches()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Branch_Info.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Branch_Info>();
            }
        }
        public static List<Country_Codes> GetCountryCodeses()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Country_Codes.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Country_Codes>();
            }
        }
        public static List<Legal_Form_Type> GetLegalFormType()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Legal_Form_Type.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Legal_Form_Type>();
            }
        }

        public static List<Identification_Type> GetIdentificationTypes()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Identification_Type.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Identification_Type>();
            }
        }
        public static List<Communication_Type> GetCommunicationTypes()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Communication_Type.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Communication_Type>();
            }
        }
        public static List<Contact_Type> GetContactTypes()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Contact_Type.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Contact_Type>();
            }
        }
        public static List<Division_Name> GetDivisionNames()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Division_Name.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Division_Name>();
            }
        }

        public static List<Currency> GetCurrencyList()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Currencies.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Currency>();
            }
        }
        public static List<District_Name> GetDistrictNames()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.District_Name.ToList();
                }
            }
            catch (Exception)
            {
                return new List<District_Name>();
            }
        }
        public static List<Thana_Name> GetThanaNames()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Thana_Name.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Thana_Name>();
            }
        }
        public static List<Account_Status_Type> GetAccStatusList()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Account_Status_Type.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Account_Status_Type>();
            }
        }
        public static List<Account_Person_Role> GetRoleList()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Account_Person_Role.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Account_Person_Role>();
            }
        }
        public static List<Account_Type> GetAccountTypeList()
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    return dbEntities.Account_Type.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Account_Type>();
            }
        }
        public static SelectList GetSignatoryStatusList()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem {Value = "Y", Text = "PRIMARY"},
                new SelectListItem {Value = "N", Text = "NOT PRIMARY"},};
            return new SelectList(list, "Value", "Text");
        }
        public static SelectList GetDistrictList()
        {
            var districtList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Bagerhat",Value = "Bagerhat"},
                new SelectListItem {Text = "Bandarban",Value = "Bandarban"},
                new SelectListItem {Text = "Barguna",Value = "Barguna"},
                new SelectListItem {Text = "Barisal",Value = "Barisal"},
                new SelectListItem {Text = "Bhola",Value = "Bhola"},
                new SelectListItem {Text = "Bogra",Value = "Bogra"},
                new SelectListItem {Text = "Brahmanbaria",Value = "Brahmanbaria"},
                new SelectListItem {Text = "Chandpur",Value = "Chandpur"},
                new SelectListItem {Text = "Chapainawabganj",Value = "Chapainawabganj"},
                new SelectListItem {Text = "Chittagong",Value = "Chittagong"},
                new SelectListItem {Text = "Chuadanga",Value = "Chuadanga"},
                new SelectListItem {Text = "Comilla",Value = "Comilla"},
                new SelectListItem {Text = "Cox's Bazar",Value = "Cox's Bazar"},
                new SelectListItem {Text = "Dhaka",Value = "Dhaka"},
                new SelectListItem {Text = "Dinajpur",Value = "Dinajpur"},
                new SelectListItem {Text = "Faridpur",Value = "Faridpur"},
                new SelectListItem {Text = "Feni",Value = "Feni"},
                new SelectListItem {Text = "Gaibandha",Value = "Gaibandha"},
                new SelectListItem {Text = "Gazipur",Value = "Gazipur"},
                new SelectListItem {Text = "Gopalganj",Value = "Gopalganj"},
                new SelectListItem {Text = "Habiganj",Value = "Habiganj"},
                new SelectListItem {Text = "Jamalpur",Value = "Jamalpur"},
                new SelectListItem {Text = "Jessore",Value = "Jessore"},
                new SelectListItem {Text = "Jhalokati",Value = "Jhalokati"},
                new SelectListItem {Text = "Jhenaidah",Value = "Jhenaidah"},
                new SelectListItem {Text = "Joypurhat",Value = "Joypurhat"},
                new SelectListItem {Text = "Khagrachhari",Value = "Khagrachhari"},
                new SelectListItem {Text = "Khulna",Value = "Khulna"},
                new SelectListItem {Text = "Kishoreganj",Value = "Kishoreganj"},
                new SelectListItem {Text = "Kurigram",Value = "Kurigram"},
                new SelectListItem {Text = "Kushtia",Value = "Kushtia"},
                new SelectListItem {Text = "Lakshmipur",Value = "Lakshmipur"},
                new SelectListItem {Text = "Lalmonirhat",Value = "Lalmonirhat"},
                new SelectListItem {Text = "Madaripur",Value = "Madaripur"},
                new SelectListItem {Text = "Magura",Value = "Magura"},
                new SelectListItem {Text = "Manikganj",Value = "Manikganj"},
                new SelectListItem {Text = "Meherpur",Value = "Meherpur"},
                new SelectListItem {Text = "Moulvibazar",Value = "Moulvibazar"},
                new SelectListItem {Text = "Munshiganj",Value = "Munshiganj"},
                new SelectListItem {Text = "Mymensingh",Value = "Mymensingh"},
                new SelectListItem {Text = "Naogaon",Value = "Naogaon"},
                new SelectListItem {Text = "Narail",Value = "Narail"},
                new SelectListItem {Text = "Narayanganj",Value = "Narayanganj"},
                new SelectListItem {Text = "Narsingdi",Value = "Narsingdi"},
                new SelectListItem {Text = "Natore",Value = "Natore"},
                new SelectListItem {Text = "Netrakona",Value = "Netrakona"},
                new SelectListItem {Text = "Nilphamari",Value = "Nilphamari"},
                new SelectListItem {Text = "Noakhali",Value = "Noakhali"},
                new SelectListItem {Text = "Pabna",Value = "Pabna"},
                new SelectListItem {Text = "Panchagarh",Value = "Panchagarh"},
                new SelectListItem {Text = "Patuakhali",Value = "Patuakhali"},
                new SelectListItem {Text = "Pirojpur",Value = "Pirojpur"},
                new SelectListItem {Text = "Rajbari",Value = "Rajbari"},
                new SelectListItem {Text = "Rajshahi",Value = "Rajshahi"},
                new SelectListItem {Text = "Rangamati",Value = "Rangamati"},
                new SelectListItem {Text = "Rangpur",Value = "Rangpur"},
                new SelectListItem {Text = "Satkhira",Value = "Satkhira"},
                new SelectListItem {Text = "Shariatpur",Value = "Shariatpur"},
                new SelectListItem {Text = "Sherpur",Value = "Sherpur"},
                new SelectListItem {Text = "Sirajganj",Value = "Sirajganj"},
                new SelectListItem {Text = "Sunamganj",Value = "Sunamganj"},
                new SelectListItem {Text = "Sylhet",Value = "Sylhet"},
                new SelectListItem {Text = "Tangail",Value = "Tangail"},
                new SelectListItem {Text = "Thakurgaon",Value = "Thakurgaon"}

            };
            //var sortedText = TextList.OrderBy(i => i.Text).ToList();
            return new SelectList(districtList, "Value", "Text");
        }
        public static SelectList GetBloodGroupList()
        {
            var getList = new List<SelectListItem>
            {
                new SelectListItem {Text = "A+", Value = "A+"},
                new SelectListItem {Text = "B+", Value = "B+"},
                new SelectListItem {Text = "A-", Value = "A-"},
                new SelectListItem {Text = "B-", Value = "B-"},
                new SelectListItem {Text = "AB+", Value = "AB+"},
                new SelectListItem {Text = "AB-", Value = "AB-"},
                new SelectListItem {Text = "o+", Value = "o+"},
                new SelectListItem {Text = "o-", Value = "o-"}
            };
            return new SelectList(getList, "Value", "Text");
        }
        public static SelectList GetMaritalStatusList()
        {
            var getList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Married", Value = "Married"},
                new SelectListItem {Text = "Single", Value = "Single"},
                new SelectListItem {Text = "Widow", Value = "Widow"},
                new SelectListItem {Text = "Divorcee", Value = "Divorcee"}
            };
            return new SelectList(getList, "Value", "Text");
        }
        public static SelectList GetGenderList()
        {
            var getList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Male", Value = "M"},
                new SelectListItem {Text = "Female", Value = "F"},
                //new SelectListItem {Text = "Transgender", Value = "Transgender"},
                //new SelectListItem {Text = "Others", Value = "Others"}
            };
            return new SelectList(getList, "Value", "Text");
        }
        public static SelectList GetTaskStatusList()
        {
            var getList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Complete", Value = "Complete"},
                new SelectListItem {Text = "Incomplete", Value = "Incomplete"}
            };
            return new SelectList(getList, "Value", "Text");
        }
        
        public static SelectList GetCountry()
        {
            var values = new List<SelectListItem>
            {
                new SelectListItem {Value = "Afghanistan", Text = "Afghanistan"},
                new SelectListItem {Value = "Albania", Text = "Albania"},
                new SelectListItem {Value = "Algeria", Text = "Algeria"},
                new SelectListItem {Value = "American Samoa", Text = "American Samoa"},
                new SelectListItem {Value = "Andorra", Text = "Andorra"},
                new SelectListItem {Value = "Angola", Text = "Angola"},
                new SelectListItem {Value = "Anguilla", Text = "Anguilla"},
                new SelectListItem {Value = "Antarctica", Text = "Antarctica"},
                new SelectListItem {Value = "Antigua and Barbuda", Text = "Antigua and Barbuda"},
                new SelectListItem {Value = "Argentina", Text = "Argentina"},
                new SelectListItem {Value = "Armenia", Text = "Armenia"},
                new SelectListItem {Value = "Aruba", Text = "Aruba"},
                new SelectListItem {Value = "Australia", Text = "Australia"},
                new SelectListItem {Value = "Austria", Text = "Austria"},
                new SelectListItem {Value = "Azerbaijan", Text = "Azerbaijan"},
                new SelectListItem {Value = "Bahamas", Text = "Bahamas"},
                new SelectListItem {Value = "Bahrain", Text = "Bahrain"},
                new SelectListItem {Value = "BD", Text = "BANGLADESH"},
                new SelectListItem {Value = "Barbados", Text = "Barbados"},
                new SelectListItem {Value = "Belarus", Text = "Belarus"},
                new SelectListItem {Value = "Belgium", Text = "Belgium"},
                new SelectListItem {Value = "Belize", Text = "Belize"},
                new SelectListItem {Value = "Benin", Text = "Benin"},
                new SelectListItem {Value = "Bermuda", Text = "Bermuda"},
                new SelectListItem {Value = "Bhutan", Text = "Bhutan"},
                new SelectListItem {Value = "Bolivia", Text = "Bolivia"},
                new SelectListItem {Value = "Bosnia and Herzegovina", Text = "Bosnia and Herzegovina"},
                new SelectListItem {Value = "Botswana", Text = "Botswana"},
                new SelectListItem {Value = "Bouvet Island", Text = "Bouvet Island"},
                new SelectListItem {Value = "Brazil", Text = "Brazil"},
                new SelectListItem {Value = "British Indian Ocean Territory", Text = "British Indian Ocean Territory"},
                new SelectListItem {Value = "Brunei Darussalam", Text = "Brunei Darussalam"},
                new SelectListItem {Value = "Bulgaria", Text = "Bulgaria"},
                new SelectListItem {Value = "Burkina Faso", Text = "Burkina Faso"},
                new SelectListItem {Value = "Burundi", Text = "Burundi"},
                new SelectListItem {Value = "Cambodia", Text = "Cambodia"},
                new SelectListItem {Value = "Cameroon", Text = "Cameroon"},
                new SelectListItem {Value = "Canada", Text = "Canada"},
                new SelectListItem {Value = "Cape Verde", Text = "Cape Verde"},
                new SelectListItem {Value = "Cayman Islands", Text = "Cayman Islands"},
                new SelectListItem {Value = "Chad", Text = "Chad"},
                new SelectListItem {Value = "Chile", Text = "Chile"},
                new SelectListItem {Value = "China", Text = "China"},
                new SelectListItem {Value = "Christmas Island", Text = "Christmas Island"},
                new SelectListItem {Value = "Cocos (Keeling) Islands", Text = "Cocos (Keeling) Islands"},
                new SelectListItem {Value = "Colombia", Text = "Colombia"},
                new SelectListItem {Value = "Comoros", Text = "Comoros"},
                new SelectListItem {Value = "Congo", Text = "Congo"},
                new SelectListItem {Value = "Costa Rica", Text = "Costa Rica"},
                new SelectListItem {Value = "Cote D'ivoire", Text = "Cote D'ivoire"},
                new SelectListItem {Value = "Croatia", Text = "Croatia"},
                new SelectListItem {Value = "Cuba", Text = "Cuba"},
                new SelectListItem {Value = "Cyprus", Text = "Cyprus"},
                new SelectListItem {Value = "Czech Republic", Text = "Czech Republic"},
                new SelectListItem {Value = "Denmark", Text = "Denmark"},
                new SelectListItem {Value = "Dominican Republic", Text = "Dominican Republic"},
                new SelectListItem {Value = "Ecuador", Text = "Ecuador"},
                new SelectListItem {Value = "Egypt", Text = "Egypt"},
                new SelectListItem {Value = "Ethiopia", Text = "Ethiopia"},
                new SelectListItem {Value = "Fiji", Text = "Fiji"},
                new SelectListItem {Value = "Finland", Text = "Finland"},
                new SelectListItem {Value = "France", Text = "France"},
                new SelectListItem {Value = "Georgia", Text = "Georgia"},
                new SelectListItem {Value = "Germany", Text = "Germany"},
                new SelectListItem {Value = "Ghana", Text = "Ghana"},
                new SelectListItem {Value = "Greece", Text = "Greece"},
                new SelectListItem {Value = "Greenland", Text = "Greenland"},
                new SelectListItem {Value = "Grenada", Text = "Grenada"},
                new SelectListItem {Value = "Guatemala", Text = "Guatemala"},
                new SelectListItem {Value = "Honduras", Text = "Honduras"},
                new SelectListItem {Value = "Hong Kong", Text = "Hong Kong"},
                new SelectListItem {Value = "Hungary", Text = "Hungary"},
                new SelectListItem {Value = "India", Text = "India"},
                new SelectListItem {Value = "Indonesia", Text = "Indonesia"},
                new SelectListItem {Value = "Iran", Text = "Iran"},
                new SelectListItem {Value = "Iraq", Text = "Iraq"},
                new SelectListItem {Value = "Ireland", Text = "Ireland"},
                new SelectListItem {Value = "Israel", Text = "Israel"},
                new SelectListItem {Value = "Italy", Text = "Italy"},
                new SelectListItem {Value = "Jamaica", Text = "Jamaica"},
                new SelectListItem {Value = "Japan", Text = "Japan"},
                new SelectListItem {Value = "Jordan", Text = "Jordan"},
                new SelectListItem {Value = "Kazakhstan", Text = "Kazakhstan"},
                new SelectListItem {Value = "Kenya", Text = "Kenya"},
                new SelectListItem {Value = "KR", Text = "KOREA"},
                new SelectListItem {Value = "Kuwait", Text = "Kuwait"},
                new SelectListItem {Value = "Kyrgyzstan", Text = "Kyrgyzstan"},
                new SelectListItem {Value = "Latvia", Text = "Latvia"},
                new SelectListItem {Value = "Lebanon", Text = "Lebanon"},
                new SelectListItem {Value = "Liberia", Text = "Liberia"},
                new SelectListItem {Value = "Lithuania", Text = "Lithuania"},
                new SelectListItem {Value = "Luxembourg", Text = "Luxembourg"},
                new SelectListItem {Value = "Madagascar", Text = "Madagascar"},
                new SelectListItem {Value = "Malaysia", Text = "Malaysia"},
                new SelectListItem {Value = "Malta", Text = "Malta"},
                new SelectListItem {Value = "Mexico", Text = "Mexico"},
                new SelectListItem {Value = "Mongolia", Text = "Mongolia"},
                new SelectListItem {Value = "Morocco", Text = "Morocco"},
                new SelectListItem {Value = "Myanmar", Text = "Myanmar"},
                new SelectListItem {Value = "Namibia", Text = "Namibia"},
                new SelectListItem {Value = "Nepal", Text = "Nepal"},
                new SelectListItem {Value = "Netherlands", Text = "Netherlands"},
                new SelectListItem {Value = "New Zealand", Text = "New Zealand"},
                new SelectListItem {Value = "Nigeria", Text = "Nigeria"},
                new SelectListItem {Value = "Norway", Text = "Norway"},
                new SelectListItem {Value = "Oman", Text = "Oman"},
                new SelectListItem {Value = "Pakistan", Text = "Pakistan"},
                new SelectListItem {Value = "Paraguay", Text = "Paraguay"},
                new SelectListItem {Value = "Philippines", Text = "Philippines"},
                new SelectListItem {Value = "Poland", Text = "Poland"},
                new SelectListItem {Value = "Portugal", Text = "Portugal"},
                new SelectListItem {Value = "Qatar", Text = "Qatar"},
                new SelectListItem {Value = "Romania", Text = "Romania"},
                new SelectListItem {Value = "Russia", Text = "Russia"},
                new SelectListItem {Value = "Singapore", Text = "Singapore"},
                new SelectListItem {Value = "Slovakia", Text = "Slovakia"},
                new SelectListItem {Value = "Somalia", Text = "Somalia"},
                new SelectListItem {Value = "South Africa", Text = "South Africa"},
                new SelectListItem {Value = "Spain", Text = "Spain"},
                new SelectListItem {Value = "Sri Lanka", Text = "Sri Lanka"},
                new SelectListItem {Value = "Sudan", Text = "Sudan"},
                new SelectListItem {Value = "Swaziland", Text = "Swaziland"},
                new SelectListItem {Value = "Taiwan", Text = "Taiwan"},
                new SelectListItem {Value = "Thailand", Text = "Thailand"},
                new SelectListItem {Value = "Turkey", Text = "Turkey"},
                new SelectListItem {Value = "Uganda", Text = "Uganda"},
                new SelectListItem {Value = "Ukraine", Text = "Ukraine"},
                new SelectListItem {Value = "United Arab Emirates", Text = "United Arab Emirates"},
                new SelectListItem {Value = "United Kingdom", Text = "United Kingdom"},
                new SelectListItem {Value = "United States", Text = "United States"},
                new SelectListItem {Value = "Uruguay", Text = "Uruguay"},
                new SelectListItem {Value = "Uzbekistan", Text = "Uzbekistan"},
                new SelectListItem {Value = "Venezuela", Text = "Venezuela"},
                new SelectListItem {Value = "Yemen", Text = "Yemen"},
                new SelectListItem {Value = "Zambia", Text = "Zambia"},
                new SelectListItem {Value = "Zimbabwe", Text = "Zimbabwe"}
            };
            return new SelectList(values, "Value", "Text");
        }
        public static List<BooleanDdl> BooleanDropDown()
        {
            return new List<BooleanDdl>
            {
                new BooleanDdl {Value = true, Text = "Yes"},
                new BooleanDdl {Value = false, Text = "No"}
            };
        }
        public static SelectList GetYesNoSelectList()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem {Value = "Y", Text = "Yes"},
                new SelectListItem {Value = "N", Text = "No"},};
            return new SelectList(list, "Value", "Text");
        }
        public static SelectList GetTimeList()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem {Value = "01:00 A.M", Text = "01:00 A.M"},
                new SelectListItem {Value = "02:00 A.M", Text = "02:00 A.M"},
                new SelectListItem {Value = "03:00 A.M", Text = "03:00 A.M"},
                new SelectListItem {Value = "04:00 A.M", Text = "04:00 A.M"},
                new SelectListItem {Value = "05:00 A.M", Text = "05:00 A.M"},
                new SelectListItem {Value = "06:00 A.M", Text = "06:00 A.M"},
                new SelectListItem {Value = "07:00 A.M", Text = "07:00 A.M"},
                new SelectListItem {Value = "08:00 A.M", Text = "08:00 A.M"},
                new SelectListItem {Value = "09:00 A.M", Text = "09:00 A.M"},
                new SelectListItem {Value = "10:00 A.M", Text = "10:00 A.M"},
                new SelectListItem {Value = "11:00 A.M", Text = "11:00 A.M"},
                new SelectListItem {Value = "12:00 A.M", Text = "12:00 A.M"},
                new SelectListItem {Value = "01:00 P.M", Text = "01:00 P.M"},
                new SelectListItem {Value = "02:00 P.M", Text = "02:00 P.M"},
                new SelectListItem {Value = "03:00 P.M", Text = "03:00 P.M"},
                new SelectListItem {Value = "04:00 P.M", Text = "04:00 P.M"},
                new SelectListItem {Value = "05:00 P.M", Text = "05:00 P.M"},
                new SelectListItem {Value = "06:00 P.M", Text = "06:00 P.M"},
                new SelectListItem {Value = "07:00 P.M", Text = "07:00 P.M"},
                new SelectListItem {Value = "08:00 P.M", Text = "08:00 P.M"},
                new SelectListItem {Value = "09:00 P.M", Text = "09:00 P.M"},
                new SelectListItem {Value = "10:00 P.M", Text = "10:00 P.M"},
                new SelectListItem {Value = "11:00 P.M", Text = "11:00 P.M"},
                new SelectListItem {Value = "12:00 P.M", Text = "12:00 P.M"}
            };
            return new SelectList(list, "Value", "Text");
        }
    }
    public class BooleanDdl
    {
        public bool Value { get; set; }
        public string Text { get; set; }
    }
}
