using MediatR;

namespace Horzion.Blog.Api.Application.CommandHandlers.ArticleHandlers
{
    public class AddArticleCommand: IRequest<bool>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatorId { get; set; }
        public AddArticleCommand(string title, string content,string creatorId)
        {
            Title = title;
            Content = content;
            CreatorId = creatorId;
        }
    }
}
