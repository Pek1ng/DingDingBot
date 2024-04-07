using System.Text.Json.Serialization;

namespace DingTalkClient.Messages;

public class ActionCardMessage : IDingDingMessage
{
    public string Msgtype => "actionCard";

    public required ActionCardContentBase ActionCard { get; set; }
}

[JsonDerivedType(typeof(SingleButtonActionCardContent))]
[JsonDerivedType(typeof(MultiButtonActionCardContent))]
public abstract class ActionCardContentBase
{
    /// <summary>
    /// 首屏会话透出的展示内容。
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// markdown格式的消息。
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    /// 按钮排列方式：0：按钮竖直排列 1：按钮横向排列。
    /// </summary>
    public int? BtnOrientation { get; set; }
}

public class SingleButtonActionCardContent : ActionCardContentBase
{
    /// <summary>
    /// 单个按钮的标题。
    /// </summary>
    public required string SingleTitle { get; set; }

    /// <summary>
    /// 点击消息跳转的URL。
    /// </summary>
    public required string SingleURL { get; set; }
}

public class MultiButtonActionCardContent : ActionCardContentBase
{
    /// <summary>
    /// 按钮。
    /// </summary>
    public required BtnContent[] Btns { get; set; }
}

public class BtnContent
{
    /// <summary>
    /// 按钮标题。
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// 点击按钮触发的URL。
    /// </summary>
    public required string ActionURL { get; set; }
}
