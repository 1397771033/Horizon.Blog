using Horizon.Blog.Domain.Aggregates.ArticleAggreate;
using Horizon.Blog.Service.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Blog.Domain.Test
{
    [TestClass]
    public class ArticleTest
    {
        private Article ArticleInstance { get => new Article(_articleTitle, _articleContent, _creatorId); }

        private readonly string _articleTitle = "文章标题";
        private readonly string _articleContent = "文章内容";
        private readonly string _creatorId = "admin";


        [TestMethod("正常参数的构造函数")]
        public void Ctor_Success()
        {
            var article = ArticleInstance;

            Assert.IsNotNull(article.Id);
            Assert.IsNotNull(article.CreationInfo);
            Assert.IsNotNull(article.ModificationInfo);
            Assert.IsNotNull(article.ModificationInfo);

            Assert.AreEqual(_articleTitle, article.Title);
            Assert.AreEqual(_articleContent, article.Content);
            Assert.AreEqual(1, article.SortNum);
            Assert.AreEqual(false, article.Toped);
            Assert.AreEqual(ArticleStatusEnum.Unpublished, article.Status);


            Assert.AreEqual(_creatorId, article.CreationInfo.CreatorId);
            Assert.AreEqual(_creatorId, article.ModificationInfo.ModifierId);
            Assert.AreNotEqual(default, article.CreationInfo.CreationTime);
            Assert.AreNotEqual(default, article.ModificationInfo.ModificationTime);
        }
        [TestMethod("正常参数的修改文章")]
        public void Modify_Success()
        {
            var article = ArticleInstance;

            string articleTitle = "新文章标题";
            string articleContent = "新文章标题";
            string modifierId = "zhangsan";
            Thread.Sleep(100);
            article.ModifyArticle(articleTitle, articleContent, modifierId);

            Assert.AreEqual(articleTitle, article.Title);
            Assert.AreEqual(articleContent, article.Content);
            Assert.AreEqual(modifierId, article.ModificationInfo.ModifierId);
            Assert.AreEqual(_creatorId, article.CreationInfo.CreatorId);
            if (article.ModificationInfo.ModificationTime <= article.CreationInfo.CreationTime)
                throw new System.Exception("修改时间数据好像未修改~");
        }
    }
}
