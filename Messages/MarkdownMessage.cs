namespace DingTalkClient.Messages;

/// <summary>
/// markdown类型
/// </summary>
public class MarkdownMessage : AtBase<MarkdownMessage>,IDingDingMessage
{
    public string Msgtype => "markdown";

    public required MarkdownContent Markdown { get; set; }
}

public class MarkdownContent
{
    /// <summary>
    /// 消息标题。
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// 消息内容。如果太长只会部分展示。
    /// </summary>
    public required string Text { get; set; }
}
