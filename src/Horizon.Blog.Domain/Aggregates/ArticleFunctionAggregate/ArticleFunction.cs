using Horizon.Blog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate
{
    public class ArticleFunction : Entity, IAggregateRoot
    {
        public string ArticleId { get; set; }

        private readonly List<Review> _reviews;
        /// <summary>
        /// 评论
        /// </summary>
        public IReadOnlyCollection<Review> Reviews => _reviews;

        private readonly List<Star> _stars;
        /// <summary>
        /// 星
        /// </summary>
        public IReadOnlyCollection<Star> Stars => _stars;

        private ArticleFunction()
        {
            _reviews = new List<Review>();
            _stars = new List<Star>();
        }
        public ArticleFunction(string articleId)
            : this()
        {
            GenerateId();
            BindArticle(articleId);
        }
        private void BindArticle(string articleId)
        {
            if (string.IsNullOrWhiteSpace(articleId))
                throw new ArgumentNullException(nameof(articleId));
            ArticleId = articleId;
        }

        #region Review
        public void Review(string content, string creatorId)
        {
            Review review = new Review(content, creatorId);
            _reviews.Add(review);
        }
        public void DeleteReview(string reviewId)
        {
            Review review = _reviews.FirstOrDefault(_ => _.Id == reviewId);
            if (review == null) return;
            _reviews.Remove(review);
        }
        #endregion
        #region Star
        public void Star(string creatorId)
        {
            if (_stars.Any(_ => _.CreationInfo.CreatorId == creatorId)) return;
            Star star = new Star(creatorId);
            _stars.Add(star);
        }
        public void CancelStar(string creatorId)
        {
            Star star = _stars.FirstOrDefault(_ => _.CreationInfo.CreatorId == creatorId);
            if (star == null) return;
            _stars.Remove(star);
        }
        #endregion
    }
}
