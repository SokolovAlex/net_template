namespace App.DTO.Models.Base
{
    public class ReferenceModel : BaseModel
    {
        public int CategoryId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int? ValueInt { get; set; }
    }
}
