using Microsoft.AspNetCore.Mvc;

namespace LinkerBoard.API.Features.Links;

[ApiController]
[Route("api/[controller]")]
public sealed class LinksController(ILinkService linkService)
    : ControllerBase
{
    private readonly ILinkService _linkService = linkService;
    
    [HttpPost("upsert")]
    public async Task<IActionResult> Upsert([FromBody] UpsertLinkRequestDto linkRequestDto,
        CancellationToken cancellationToken)
    {
        LinkResponseDto response = await _linkService.UpsertAsync(linkRequestDto, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPatch("move-link-board/{linkId:long}/{boardId:int}")]
    public async Task<IActionResult> MoveLinkBoard([FromRoute] long linkId,
        [FromRoute] int boardId,
        CancellationToken cancellationToken)
    {
        await _linkService.MoveLinkBoardAsync(linkId, boardId, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("{linkId:long}")]
    public async Task<IActionResult> Delete([FromRoute] long linkId,
        CancellationToken cancellationToken)
    {
        await _linkService.DeleteAsync(linkId, cancellationToken);
        return Ok();
    }
}