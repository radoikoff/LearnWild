namespace LearnWild.Web.ViewModels.Resource
{
    public class ResourceFileInfoModel
    {
        public Stream ReadStream { get; set; } = null!;

        public string FileName { get; set; } = null!;

        public string MimeType { get; set; } = null!;
    }
}
