namespace LinkerBoard.API.Features.Common;

internal static class DateHelper
{
    internal static DateOnly TodayDate => DateOnly.FromDateTime(DateTime.Now);    
}