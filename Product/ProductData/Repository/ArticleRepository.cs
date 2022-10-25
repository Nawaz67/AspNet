using ProductData.Data;
using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductData.Repository
{
    public class ArticleRepository:IArticle
    {
        ProductDbContext _productDbContext;
        public ArticleRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void AddArticle(Article article)
        {
            Guid id = Guid.NewGuid();
            article.articleId = id;
            _productDbContext.articles.Add(article);
            _productDbContext.SaveChanges();
        }

        public void DeleteArticle(Guid articleId)
        {
            throw new NotImplementedException();
        }

        public Article GetArticleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetArticles()
        {
            return _productDbContext.articles.ToList();  
        }

        public void UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
