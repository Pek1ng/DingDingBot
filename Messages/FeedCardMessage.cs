namespace DingTalkClient.Messages;

public class FeedCardMessage : IDingDingMessage
{
    public string Msgtype => "feedCard";

    public required FeedCardContent FeedCard {  get; set; }
}

public class FeedCardContent
{
    public required FeedCardItem[] Links { get; set; }
}

public class FeedCardItem
{
    /// <summary>
    /// 单条信息文本。
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// 点击单条信息到跳转链接。
    /// </summary>
    public required string MessageURL { get; set; }

    /// <summary>
    /// 单条信息后面图片的URL。
    /// </summary>
    public required string PicURL { get; set; }
}