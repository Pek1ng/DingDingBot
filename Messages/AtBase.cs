using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DingTalkClient.Messages;

public abstract class AtBase<T> where T : AtBase<T>
{
    [JsonInclude]
    private AtContent? At { get; set; }

    public T AtWithMobile(string mobile)
    {
        if (At is null)
        {
            At = new();
        }

        if (At.AtMobiles is null)
        {
            At.AtMobiles = new();
        }

        At.AtMobiles.Add(mobile);
        return (T)this;
    }

    public T AtWithId(string userId)
    {
        if (At is null)
        {
            At = new();
        }

        if (At.AtUserIds is null)
        {
            At.AtUserIds = new();
        }

        At.AtUserIds.Add(userId);
        return (T)this;
    }

    public T AtAll()
    {
        if (At is null)
        {
            At = new();
        }

        At.IsAtAll = true;
        return (T)this;
    }
}

public class AtContent
{
    /// <summary>
    /// 被@人的手机号
    /// </summary>
    public List<string>? AtMobiles { get; set; }

    /// <summary>
    /// 被@人的用户userId
    /// </summary>
    public List<string>? AtUserIds { get; set; }

    /// <summary>
    /// 是否@所有人
    /// </summary>
    public bool? IsAtAll { get; set; }
}
