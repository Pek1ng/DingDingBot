namespace DingTalkClient.Messages;

/// <summary>
/// 钉钉机器人消息类型接口
/// </summary>
public interface IDingDingMessage
{
    /// <summary>
    /// 消息类型
    /// </summary>
    string Msgtype { get; }
}