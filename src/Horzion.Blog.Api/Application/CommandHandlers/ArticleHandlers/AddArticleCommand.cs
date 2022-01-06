using MediatR;

namespace Horzion.Blog.Api.Application.CommandHandlers.ArticleHandlers
{
    public class AddArticleCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatorIp { get; set; }
        public AddArticleCommand(string title, string content, string creatorIp)
        {
            Title = title;
            Content = content;
            CreatorIp = creatorIp;
        }
    }
}
