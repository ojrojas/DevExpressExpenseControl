namespace DevExpressExpenseControl.BuildingBlocks.CQRS;

public record BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlation) : base()
    {
        _correlation = correlation;
    }
}