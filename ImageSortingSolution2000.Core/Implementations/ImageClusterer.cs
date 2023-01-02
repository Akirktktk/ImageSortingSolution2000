using ImageSortingSolution2000.Core.Dtos;
using System.Linq;

namespace ImageSortingSolution2000.Core.Implementations
{
    public class ImageClusterer : IImageClusterer
    {
        public List<ImageGroup> Cluster(List<ImageMetaData> data)
        {
            var groups = new List<ImageGroup>();
            var groupedData = data.ToList().GroupBy(x => DateOnly.FromDateTime(x.TakenAt));
            foreach (var grouping in groupedData)
            {
                var nextGroup = new ImageGroup
                {
                    Data = grouping.ToList()
                };

                groups.Add(nextGroup);
            }

            return groups;
        }
    }
}