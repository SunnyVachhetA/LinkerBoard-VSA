using Microsoft.AspNetCore.Mvc;

namespace LinkerBoard.API.Features.LinkBoards;

[Route("api/[controller]")]
[ApiController]
public sealed class LinkBoardsController(ILinkBoardService linkBoardService)
    : ControllerBase
{
    private readonly ILinkBoardService _linkBoardService = linkBoardService;
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] UpsertLinkBoardRequestDto linkBoardDto,
        CancellationToken cancellationToken)
    {
        UpsertLinkBoardResponseDto dto = await _linkBoardService.CreateAsync(linkBoardDto, cancellationToken);
        
        return Ok(dto);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpsertLinkBoardRequestDto linkBoardDto,
        CancellationToken cancellationToken)
    {
        UpsertLinkBoardResponseDto dto = await _linkBoardService.UpdateAsync(linkBoardDto, cancellationToken);
        
        return Ok(dto);
    }
}