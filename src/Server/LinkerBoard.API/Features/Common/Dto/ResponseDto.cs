namespace LinkerBoard.API.Features.Common.Dto;

public record PageResponseDto<T>(int PageNumber,
    int PageSize,
    IEnumerable<T> Records,
    long TotalCount)
    where T : class;