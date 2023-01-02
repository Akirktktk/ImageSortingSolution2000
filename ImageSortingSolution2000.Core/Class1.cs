using ImageSortingSolution2000.Core.Dtos;

namespace ImageSortingSolution2000.Core
{
    public interface IFolderAnalyzer
    {
        Task<List<ImageMetaData>> AnalyzeFolder(string path);
    }

    public interface IImageClusterer
    {
        List<ImageGroup> Cluster(List<ImageMetaData> data);
    }
}