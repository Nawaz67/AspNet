using ProductData.Repository;
using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBusiness.Services
{
    public class ArticleService
    {
        IArticle _article;
        public ArticleService(IArticle article)
        {
            _article = article;
        }

        public void AddArticle(Article article)
        {
            _article.AddArticle(article);
        }
        public void UpdateArticle(Article article)
        {
            _article.UpdateArticle(article);
        }
        public void DeleteArticle(Guid articleId)
        {
            _article.DeleteArticle(articleId);
        }
        public Article GetArticleById(Guid articleId)
        {
            return _article.GetArticleById(articleId);
        }
        public IEnumerable<Article> GetArticles()
        {
            return _article.GetArticles();  
        }
    }
}
