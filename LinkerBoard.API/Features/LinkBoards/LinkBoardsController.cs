using LinkerBoard.API.Features.Common.Dto;
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
    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpsertLinkBoardRequestDto linkBoardDto,
        CancellationToken cancellationToken)
    {
        UpsertLinkBoardResponseDto dto = await _linkBoardService.UpdateAsync(linkBoardDto, cancellationToken);
        
        return Ok(dto);
    }

    [HttpPost("filter")]
    public async Task<IActionResult> Filter([FromBody] FilterLinkBoardRequestDto? filterDto,
        CancellationToken cancellationToken)
    {
        PageResponseDto<LinkBoardResponseDto> linkBoardResponse = await _linkBoardService.FilterAsync(filterDto ?? new(), cancellationToken);

        return Ok(linkBoardResponse);
    }

    [HttpDelete("{boardId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int boardId,
        CancellationToken cancellationToken)
    {
        await _linkBoardService.DeleteAsync(boardId, cancellationToken);
        return Ok();
    }


}