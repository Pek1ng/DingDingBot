namespace DingTalkClient.Messages;

/// <summary>
/// link类型
/// </summary>
public class LinkMessage : IDingDingMessage
{
    public string Msgtype => "link";

    public required LinkContent Link { get; set; }
}

public class LinkContent
{
    /// <summary>
    /// 消息标题。
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// 消息内容。如果太长只会部分展示。
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    /// 点击消息跳转的URL。
    /// </summary>
    public required string MessageUrl { get; set; }

    /// <summary>
    /// 图片URL。
    /// </summary>
    public string? PicUrl { get; set; }
}