namespace GOAML.Repository.Helper
{
    public class Enum
    {
        public enum ResponseCode
        {
            Success=1,
            Error,
            Warning,
            Exist,
            NotExist,
            Failed
        }

        public enum Month
        {
            January=1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public enum SearchCriteria
        {
            ByEntity=1,
            ByPersonMyClient,
        }
    }
}
