using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductData.Repository
{
    public interface IArticle
    {
        void AddArticle(Article article);
        void DeleteArticle(Guid articleId);
        void UpdateArticle(Article article);    
        Article GetArticleById(Guid articleId);
        IEnumerable<Article> GetArticles();
    }
}
