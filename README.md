# GapSharp
Unofficial Gap.im Bot Sdk and Samples

[![Nuget](https://img.shields.io/nuget/v/GapSharp.svg)](https://www.nuget.org/packages/GapSharp/1.0.0)

<div dir="rtl">
نمونه کد اتصال به پیام رسان گپ و ایجاد بات

پیاده سازی شده بر اساس اطلاعات موجود در بخش توسعه دهندگان سایت گپ
<div dir="ltr">

- https://developer.gap.im/doc/botplatform
</div>


بصورت رست پیاده سازی شده است
به همین دلیل نیاز به کتابخانه های زیر هست:

<div dir="ltr">

- https://www.nuget.org/packages/Newtonsoft.Json
- https://www.nuget.org/packages/RestSharp/

</div>

کدها بصورت متد پیاده سازی شده اند

توضیح:
> پیام رسان های داخل ایران دارای مشکلات زیر ساختی فراوانی هستن
> گرچه هر کدام محیط های توسعه دارن ولی چندان انتظار ساختارهایی شبیه تلگرام را نداشته باشین
> در زمان نگارش این متن
> بسیاری از عملکرد آنها به درستی کار نمیکنند
</div>

## Using GapClient

1- Base class is __GapClinet__, you need to live this client in your app so please consider it as single
you can init this class in Global.asax and make it static

```csharp
Cm.Client = new GapClient("GapBotToken")
            {
                //set text logger path to app_data folder in app settings
                Logger = new SimpleTextLogger("Pointto\\Log\\Dir\\", "DefaultLogLevel")
            };
```

you need a logger class, if you do not need log set __Logger__ to __DisabledLogger__, 
__SimpleTextLogger__ will log on text file, you can also write you own logger or use __Log4Net__ or __NLog__ in your project
see sample implemented logger in project directory 

```csharp
protected void Application_Start()
        {
            Cm.Client = new GapClient("GapBotToken")
            {               
                //set text logger path to app_data folder in app settings
                Logger = new SimpleTextLogger("Pointto\\Log\\Dir\\", "DefaultLogLevel")
            };

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Cm.Client.Logger.Log("Application_Start");
        }
````

__Cm.Client__ is a static class, you can call __Client.Logger__ to log everythings
```csharp
public static class Cm
    {
        public static GapClient Client { get; set; }
	}
```

example of __Error__ log in application

```csharp
protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Exception ex = Server.GetLastError();
            Cm.Client.Logger.Log("Application_Error", LogErrorLevel.Error, ex);
        }
```

2- Using GapClient to send message in Asp.net MVC
create a controller Named Gap, created a method Named GetData

```csharp
namespace GapBotWeb.Controllers
{
    public class GapController : Controller
    {
        [HttpPost]
        public ActionResult GetData()
        {
            var posted = Cm.Client.ExtractPostedMessage(Request);

            //detect user
            var user = DbHelper.Get(posted.ChatId);

            //go to proccess command
            Task.Run(() =>
            {
                Cm.GetPrMsg(user.State).Proccess(posted);
            });

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
```

send a user text message:

```csharp
Cm.Client.SendMessage(new SendMessageInput()
            {
                Data = "سلام ",
                ChatId = message.ChatId,
                MessageType = SendMessageType.text
            });
```
## Using Builders
What is builders? you need builder to generate 
- Form
- Inline Keyboard
- Reply Keyboard

how? first for keyboards (inline or reply) you need to add a __Row__ then add keys to your keyboards

```csharp
var builder = new InlineButtonBuilder();
                builder.AddRow()
                    .AddCbData("کلید اول", "A1").AddCbData("کلید دوم در همان ردیف", "A2")
                    .AddRow()
                    .AddAmount("پرداخت", 2000, CurrencyType.Irr, "XXXXX", "پرداخت کنید"); //ردیف بعدی

                Cm.Client.SendMessage(new SendMessageInput()
                {
                    ChatId = message.ChatId,
                    Data = "لطفا کلید مناسب را انتخاب کنید",
                    InlineKeyboard = builder.ToString(),
                    MessageType = SendMessageType.text
                });
```

![Preview Class Code](https://mahdiit.github.io/gapsharp/preview.jpg)

محیط توسعه
- VS2017
- .Net 4.6.2
- Asp.net
