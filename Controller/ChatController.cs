using AutomatedResponseSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedResponseSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatGPTService _chatGPTService;

        public ChatController(ChatGPTService chatGPTService)
        {
            _chatGPTService = chatGPTService;
        }

        [HttpPost("GetResponse")]
        public async Task<IActionResult> GetResponse([FromBody] string userMessage)
        {
            var response = await _chatGPTService.GetResponseAsync(userMessage);
            return Ok(response);
        }
    }
}
