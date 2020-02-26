namespace GOAML.DomainModels.LocalObjects
{
    public class SignatoryInfo
    {
        public int sign_Id { get; set; }
        public string accountNumber { get; set; }
        public int? signatorId { get; set; }
        public string isprimary { get; set; }
        public int? director_id { get; set; }
    }
}
