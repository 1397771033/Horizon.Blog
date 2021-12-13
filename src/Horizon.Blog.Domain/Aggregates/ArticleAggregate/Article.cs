using Horizon.Blog.Domain.Common;
using Horizon.Blog.Domain.Core;
using System;

namespace Horizon.Blog.Domain.Aggregates.ArticleAggreate
{
    public class Article:Entity,IAggregateRoot
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get;private set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get;private set; }
        /// <summary>
        /// 创建人信息
        /// </summary>
        public AdminCreationInfo CreationInfo { get;private set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int SortNum { get;private set; }
        public Article(string title,string content,string creatorId,int sortNum=1)
        {
            SetTitle(title);
            SetContent(content);
            SetCreationInfo(creatorId);
            SetSortNum(sortNum);
        }
        #region Basic
        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
            Title = title;
        }
        private void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));
            Content = content;
        }
        private void SetCreationInfo(string creatorId)
        {
            if(string.IsNullOrWhiteSpace(creatorId))
                throw new ArgumentNullException(nameof(creatorId));
            CreationInfo = new AdminCreationInfo(creatorId, DateTime.Now);
        }
        private void SetSortNum(int sortNum)
        {
            SortNum = sortNum <= 0 ? 1 : sortNum;
        }
        #endregion
    }
}
