using DingTalkClient;
using DingTalkClient.Messages;
using System;

//这里的换成你自己的
string webHookURL = "https://oapi.dingtalk.com/robot/send?access_token=token";
string secret = "SEC";

var msg = new TextMessage
{
    Text = new() { Content = "我就是我,是不一样的烟火" }
}.AtAll();

//var msg = new LinkMessage
//{
//    Link = new()
//    {
//        Text = "这个即将发布的新版本",
//        Title = "1",
//        MessageUrl = "https://www.dingtalk.com/s?__biz=MzA4NjMwMTA2Ng==&mid=2650316842&idx=1&sn=60da3ea2b29f1dcc43a7c8e4a7c97a16&scene=2&srcid=09189AnRJEdIiWVaKltFzNTw&from=timeline&isappinstalled=0&key=&ascene=2&uin=&devicetype=android-23&version=26031933&nettype=WIFI",
//        PicUrl = "https://th.bing.com/th?id=OIP.OhUOhPbzdELTIt6QY9fV0AHaEo&w=316&h=197&c=8&rs=1&qlt=90&o=6&pid=3.1&rm=2"
//    }
//};

//var msg = new MarkdownMessage
//{
//    Markdown = new()
//    {
//        Title = "杭州天气",
//        Text = "#### 杭州天气 @014728255240768602 \n > 9度，西北风1级，空气良89，相对温度73%\n > ![screenshot](https://img.alicdn.com/tfs/TB1NwmBEL9TBuNjy1zbXXXpepXa-2400-1218.png)\n > ###### 10点20分发布 [天气](https://www.dingtalk.com) \n"
//    }
//}.AtWithMobile("014728255240768602");

//var msg = new ActionCardMessage
//{
//    ActionCard = new SingleButtonActionCardContent
//    {
//        Title = "乔布斯 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
//        Text = "![screenshot](https://gw.alicdn.com/tfs/TB1ut3xxbsrBKNjSZFpXXcXhFXa-846-786.png) \r\n ### 乔布斯 20 年前想打造的苹果咖啡厅 \r\n Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
//        SingleTitle = "阅读全文",
//        SingleURL = "https://www.dingtalk.com/"
//    }
//};

//var msg = new ActionCardMessage
//{
//    ActionCard = new MultiButtonActionCardContent
//    {
//        Title = "我 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
//        Text = "![screenshot](https://img.alicdn.com/tfs/TB1NwmBEL9TBuNjy1zbXXXpepXa-2400-1218.png) \n\n #### 乔布斯 20 年前想打造的苹果咖啡厅 \n\n Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
//        Btns =
//        [
//            new BtnContent
//            {
//                Title = "内容不错",
//                ActionURL = "https://www.dingtalk.com/"
//            },
//             new BtnContent
//            {
//                 Title = "不感兴趣",
//                 ActionURL = "https://www.dingtalk.com/"
//            },
//        ],
//        BtnOrientation = 1
//    }
//};

//var msg = new ActionCardMessage
//{
//    ActionCard = new SingleButtonActionCardContent
//    {
//        Title = "乔布斯 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
//        Text = "![screenshot](https://gw.alicdn.com/tfs/TB1ut3xxbsrBKNjSZFpXXcXhFXa-846-786.png) \r\n ### 乔布斯 20 年前想打造的苹果咖啡厅 \r\n Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
//        SingleTitle = "阅读全文",
//        SingleURL = "https://www.dingtalk.com/"
//    }
//};

//var msg = new FeedCardMessage
//{
//    FeedCard = new FeedCardContent
//    {
//        Links = 
//        [
//           new FeedCardItem 
//           {
//               Title = "时代的火车向前开1",
//               MessageURL = "https://www.dingtalk.com/",
//               PicURL = "https://img.alicdn.com/tfs/TB1NwmBEL9TBuNjy1zbXXXpepXa-2400-1218.png"
//           },
//           new FeedCardItem
//           {
//               Title = "时代的火车向前开2",
//               MessageURL = "https://www.dingtalk.com/",
//               PicURL = "https://img.alicdn.com/tfs/TB1NwmBEL9TBuNjy1zbXXXpepXa-2400-1218.png"
//           }
//        ]
//    }
//};

DingDingClient client = new DingDingClient(webHookURL, secret);
var result = await client.SendAsync(msg);
Console.WriteLine(result);

Console.ReadLine();