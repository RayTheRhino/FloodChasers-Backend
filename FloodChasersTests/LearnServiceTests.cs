using MongoDB.Driver;
using NUnit.Framework;
using Unity;

using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FloodChasersLogic.Learn.Service;
using FloodChasersModel.Boundaries.Learn;
using NUnit.Framework.Legacy;
using Amazon.Runtime.Internal.Util;

namespace FloodChasersTests
{
    [TestFixture]
    public class LearnServiceTests
    {
        [Test]
        public async Task GetAllArticles_ReturnsArticles()
        {
            var articleApiMock = new Mock<FloodChasersModel.APIs.IArticleApi>();
            articleApiMock.Setup(api => api.GetArticlesBySubject("sustainability")).ReturnsAsync(new List<LearnBoundary> {
                new LearnBoundary {
                    UrlToImage = "no image",
                    Content = "Example",
                    Title = "Sample Article",
                    Author = "Dvir",
                    Url = "no url",
                }});

            var learnService = new LearnService(articleApiMock.Object);
            var result = await learnService.GetAllArticles();

            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(1, result.Count);
            ClassicAssert.AreEqual("Sample Article", result[0].Title);
            ClassicAssert.IsInstanceOf<List<LearnBoundary>>(result);

        }
    }
}
