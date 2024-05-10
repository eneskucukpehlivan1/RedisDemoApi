using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisDemoApi.Interfaces;
using RedisDemoApi.Models;

namespace RedisDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CacheController : ControllerBase
    {
        private readonly IRedisCacheService _redisCacheService;

        public CacheController(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }
        [HttpPost("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await _redisCacheService.GetValueAsync(key));
        }

        [HttpPost("set")]
        public async Task<IActionResult> Set([FromBody] RedisCacheRequestModel redisCacheRequestModel)
        {
            await _redisCacheService.SetValueAsync(redisCacheRequestModel.Key, redisCacheRequestModel.Value);
            return Ok();
        }

        [HttpPost("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _redisCacheService.Clear(key);
            return Ok();
        }
        [HttpPost]
        public IActionResult DeleteAll()
        {
            _redisCacheService.ClearAll();
            return Ok();
        }
    }
}
