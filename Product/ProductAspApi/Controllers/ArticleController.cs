using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductBusiness.Services;
using ProductEntity.Models;
using System;
using System.Collections.Generic;

namespace ProductAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        ArticleService _articleService;
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("GetArticles")]
        public IEnumerable<Article> GetArticles()
        {
            return _articleService.GetArticles();   
        }

        [HttpGet("GetArticleById")]
        public Article GetArticleById(Guid articleId)
        {
            return _articleService.GetArticleById(articleId);
        }

        [HttpPost("AddArticle")]
        public IActionResult AddArticle([FromBody]Article article)
        {
            _articleService.AddArticle(article);
            return Ok("Article Added Successfully");
        }

        [HttpPut("UpdateArticle")]
        public IActionResult UpdateArticle([FromBody] Article article)
        {
            _articleService.UpdateArticle(article);
            return Ok("Article Updated Successfully");
        }

        [HttpDelete("DeleteArticle")]
        public IActionResult DeleteArticle(Guid colourId)
        {
            _articleService.DeleteArticle(colourId);
            return Ok("Artile Deledted Successfully");
        }
    }
}
