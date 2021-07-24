using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _repository.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDTO>>(posts);
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _repository.GetById(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            await _repository.InsertPost(post);
            return Ok();
        }
    }
}
