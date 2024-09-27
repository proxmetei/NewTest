using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewTest.Api.Contrellers.Models;
using NewTest.Services.Logger;
using NewTest.Services.Questions;

namespace NewTest.Api.Contrellers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IAppLogger logger;
        private readonly IQuestionService questionService;
        private readonly IMapper mapper;
        public QuestionsController(IQuestionService questionService, IMapper mapper, IAppLogger logger)
        {
            this.questionService = questionService;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetQuestionById([FromRoute] Guid id)
        {
            logger.Information("Attempt to get question", id);
            var result = await questionService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(mapper.Map<ResponseQuestionModel>(result));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(RequestCreateResultModel request)
        {
            logger.Information("Attempt to create result", request);
            var result = await questionService.CreateResult(mapper.Map<CreateResultModel>(request));

            return Ok(mapper.Map<ResponseCreateResultModel>(result));
        }
    }
}
