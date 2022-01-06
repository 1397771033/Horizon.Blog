using Horizon.Blog.Domain.Common;
using Horizon.Blog.Domain.Core;
using Horizon.Blog.Domain.Events.Articles;
using Horizon.Blog.Service.Enums;
using System;

namespace Horizon.Blog.Domain.Aggregates.ArticleAggreate
{
    public class Article : Entity, IAggregateRoot
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; private set; }
        /// <summary>
        /// 创建人信息
        /// </summary>
        public AdminCreationInfo CreationInfo { get; private set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int SortNum { get; private set; }
        /// <summary>
        /// 置顶状态 true置顶 false未置顶
        /// </summary>
        public bool Toped { get; private set; }
        /// <summary>
        /// 文章状态
        /// </summary>
        public ArticleStatusEnum Status { get; private set; }
        /// <summary>
        /// 修改人信息
        /// </summary>
        public AdminModificationInfo ModificationInfo { get; private set; }
        private Article()
        {

        }
        public Article(string title, string content, string creatorIp, int sortNum = 1) : this()
        {
            GenerateId();
            SetTitle(title);
            SetContent(content);
            SetCreationInfo(creatorIp);
            SetSortNum(sortNum);
            SetToped(false);
            SetStatus(ArticleStatusEnum.Unpublished);
            SetModificationInfo(creatorIp);
            AddDomainEvent(new ArticleCreatedDomainEvent(Id));
        }
        public void ModifyArticle(string title, string content, string modifierId)
        {
            SetTitle(title);
            SetContent(content);
            SetModificationInfo(modifierId);
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
        private void SetCreationInfo(string creatorIp)
        {
            if (string.IsNullOrWhiteSpace(creatorIp))
                throw new ArgumentNullException(nameof(creatorIp));
            CreationInfo = new AdminCreationInfo(creatorIp, DateTime.Now);
        }
        private void SetSortNum(int sortNum)
        {
            SortNum = sortNum <= 0 ? 1 : sortNum;
        }
        private void SetModificationInfo(string modifierId)
        {
            if (string.IsNullOrWhiteSpace(modifierId))
                throw new ArgumentNullException(nameof(modifierId));
            ModificationInfo = new AdminModificationInfo(modifierId, DateTime.Now);
        }
        #endregion
        public void ModifySortNum(int sortNum, string modifierId)
        {
            this.SetSortNum(sortNum);
            this.SetModificationInfo(modifierId);
        }
        public void ModifyContent(string content, string modifierId)
        {
            this.SetContent(content);
            this.SetModificationInfo(modifierId);
        }
        public void ModifyTitle(string title, string modifierId)
        {
            this.SetTitle(title);
            this.SetModificationInfo(modifierId);
        }
        private void SetStatus(ArticleStatusEnum status)
        {
            Status = status;
        }
        /// <summary>
        /// 文章取消发布
        /// </summary>
        public void Unpublished()
        {
            SetStatus(ArticleStatusEnum.Unpublished);
        }
        /// <summary>
        /// 文章发布
        /// </summary>
        public void Published()
        {
            SetStatus(ArticleStatusEnum.Published);
        }
        private void SetToped(bool toped)
        {
            Toped = toped;
        }
        /// <summary>
        /// 文章置顶
        /// </summary>
        public void PutOnTop()
        {
            SetToped(true);
        }
        /// <summary>
        /// 取消置顶
        /// </summary>
        public void CancelTheTop()
        {
            SetToped(false);
        }
    }
}
