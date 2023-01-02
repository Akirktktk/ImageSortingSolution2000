using ImageSortingSolution2000.Core.Dtos;
using ImageSortingSolution2000.Core.Implementations;

namespace ImageSortingSolution2000.Core.Test.Unit
{
    public class ClusterTests
    {
        private IImageClusterer Instance => new ImageClusterer();

        [Fact]
        public void Cluster_TwoTimelapsesSameDate_ShouldGroupByDate_Groups()
        {
            var now = new DateTime().Date.AddHours(1);
            var nowButLater = now.AddHours(6);

            var testData = new List<ImageMetaData>
            {
                new ImageMetaData { TakenAt = now },
                new ImageMetaData { TakenAt = now.AddSeconds(15) },
                new ImageMetaData { TakenAt = now.AddSeconds(30) },
                new ImageMetaData { TakenAt = nowButLater },
                new ImageMetaData { TakenAt = nowButLater.AddSeconds(15) },
                new ImageMetaData { TakenAt = nowButLater.AddSeconds(30) },
            };

            var result = Instance.Cluster(testData);

            Assert.Equal(2, result.Count);
            Assert.True(result.All(x => 3 == x.Data.Count));
        }


        [Fact]
        public void Cluster_TwoTimelapsesSeparateDates_ShouldGroupByDate_Groups()
        {
            var now = new DateTime();
            var tomorrow = now.AddDays(1);

            var testData = new List<ImageMetaData>
            {
                new ImageMetaData { TakenAt = now },
                new ImageMetaData { TakenAt = now.AddSeconds(15) },
                new ImageMetaData { TakenAt = now.AddSeconds(30) },
                new ImageMetaData { TakenAt = tomorrow },
                new ImageMetaData { TakenAt = tomorrow.AddSeconds(15) },
                new ImageMetaData { TakenAt = tomorrow.AddSeconds(30) },
            };

            var result = Instance.Cluster(testData);

            Assert.Equal(2, result.Count);
            Assert.True(result.All(x => 3 == x.Data.Count));
        }

        [Fact]
        public void Cluster_OneTimelapse_ShouldGroupByDate_Groups()
        {
            var now = new DateTime();

            var testData = new List<ImageMetaData>
            {
                new ImageMetaData { TakenAt = now },
                new ImageMetaData { TakenAt = now.AddSeconds(15) },
                new ImageMetaData { TakenAt = now.AddSeconds(30) },
            };

            var result = Instance.Cluster(testData);

            Assert.Single(result);
            Assert.Equal(3, result.Single().Data.Count);
        }
    }
}