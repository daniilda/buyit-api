namespace BuyIt.Api.TelegramLayer.TelegramCommands.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute : Attribute
{
    public CommandType Type { get; set; }

    public CommandAttribute()
    {
    }

    public CommandAttribute(CommandType type)
    {
        Type = type;
    }
}