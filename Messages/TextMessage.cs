namespace DingTalkClient.Messages
{

    /// <summary>
    /// 文本类型
    /// </summary>
    public class TextMessage : AtBase<TextMessage>,IDingDingMessage
    {
        public string Msgtype => "text";

        public required TextContent Text { get; set; }
    }

    public class TextContent
    {
        /// <summary>
        /// 消息内容。
        /// </summary>
        public required string Content { get; set; }
    }
}
