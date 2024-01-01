namespace FloodChasersAPI.Data.Common
{
    public class FileUploadModel
    {
        public string JsonData { get; set; }
        public IFormFile Image { get; set; }
    }
}
