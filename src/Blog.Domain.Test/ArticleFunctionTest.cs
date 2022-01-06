using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Blog.Domain.Test
{
    [TestClass]
    public class ArticleFunctionTest
    {
        private ArticleFunction ArticleFunctionInstance { get => new ArticleFunction(_articleId); }

        private readonly string _articleId = "1283947583491";

        private readonly string _userIp_1 = "userid";
        private readonly string _content_1 = "WTNB";

        private readonly string _userIp_2 = "userid2";
        private readonly string _content_2 = "WTNB2";
        [TestMethod]
        public void Ctor_Success()
        {
            var articleFunction = ArticleFunctionInstance;

            Assert.IsNotNull(articleFunction);

            Assert.IsNotNull(articleFunction.Id);
            Assert.AreEqual(articleFunction.ArticleId, _articleId);

            Assert.IsNotNull(articleFunction.Reviews);
            Assert.IsNotNull(articleFunction.Stars);

            Assert.AreEqual(0, articleFunction.Stars.Count);
            Assert.AreEqual(0, articleFunction.Reviews.Count);
        }
        [TestMethod]
        public void Review_Success()
        {
            var articleFunction = ArticleFunctionInstance;

            articleFunction.Review(_content_1, _userIp_1);
            Assert.AreEqual(1, articleFunction.Reviews.Count);
            Assert.AreEqual(_userIp_1, articleFunction.Reviews.FirstOrDefault().CreationInfo.CreatorIp);
            Assert.AreEqual(_content_1, articleFunction.Reviews.FirstOrDefault().Content);


            articleFunction.Review(_content_2, _userIp_2);
            Assert.AreEqual(2, articleFunction.Reviews.Count);
            Assert.AreEqual(_userIp_2, articleFunction.Reviews.LastOrDefault().CreationInfo.CreatorIp);
            Assert.AreEqual(_content_2, articleFunction.Reviews.LastOrDefault().Content);
        }
        [TestMethod]
        public void DeleteReview_Success()
        {
            var articleFunction = ArticleFunctionInstance;

            articleFunction.Review(_content_1, _userIp_1);
            articleFunction.Review(_content_2, _userIp_2);



            articleFunction.DeleteReview(articleFunction.Reviews.FirstOrDefault().Id);
            Assert.AreEqual(1, articleFunction.Reviews.Count);

            Assert.AreEqual(_userIp_2, articleFunction.Reviews.FirstOrDefault().CreationInfo.CreatorIp);
            Assert.AreEqual(_content_2, articleFunction.Reviews.FirstOrDefault().Content);


            articleFunction.DeleteReview(articleFunction.Reviews.FirstOrDefault().Id);
            Assert.AreEqual(0, articleFunction.Reviews.Count);
        }

        [TestMethod]
        public void Star_Success()
        {
            var articleFunction = ArticleFunctionInstance;

            articleFunction.Star(_userIp_1);
            Assert.AreEqual(1, articleFunction.Stars.Count);
            articleFunction.Star(_userIp_1);
            Assert.AreEqual(1, articleFunction.Stars.Count);

            articleFunction.Star(_userIp_2);
            Assert.AreEqual(2, articleFunction.Stars.Count);

            Assert.AreEqual(_userIp_1, articleFunction.Stars.FirstOrDefault().CreationInfo.CreatorIp);
            Assert.AreEqual(_userIp_2, articleFunction.Stars.LastOrDefault().CreationInfo.CreatorIp);
        }
        [TestMethod]
        public void CancelStar_Success()
        {
            var articleFunction = ArticleFunctionInstance;

            articleFunction.Star(_userIp_1);
            articleFunction.Star(_userIp_2);

            articleFunction.CancelStar("undefind");
            Assert.AreEqual(2, articleFunction.Stars.Count);

            articleFunction.CancelStar(_userIp_1);
            Assert.AreEqual(1, articleFunction.Stars.Count);
            Assert.AreEqual(_userIp_2, articleFunction.Stars.FirstOrDefault().CreationInfo.CreatorIp);

            articleFunction.CancelStar(_userIp_2);
            Assert.AreEqual(0, articleFunction.Stars.Count);
        }
    }
}
