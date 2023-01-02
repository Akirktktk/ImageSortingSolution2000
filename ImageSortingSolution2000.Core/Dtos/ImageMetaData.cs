namespace ImageSortingSolution2000.Core.Dtos
{
    public class ImageMetaData
    {
        public string FileType { get; set; }
        public string Path { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public TimeSpan ExposureTime { get; set; }
        public DateTime TakenAt { get; set; }
    }
}