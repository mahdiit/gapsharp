# GapSharp
Gap.im Bot Sdk and Samples

نمونه کد اتصال به پیام رسان گپ و ایجاد بات

پیاده سازی شده بر اساس اطلاعات موجود در بخش توسعه دهندگان سایت گپ
- https://developer.gap.im/doc/botplatform

بصورت رست پیاده سازی شده است
به همین دلیل نیاز به کتابخانه های زیر هست:

- https://www.nuget.org/packages/Newtonsoft.Json
- https://www.nuget.org/packages/RestSharp/

کدها بصورت متد پیاده سازی شده اند

توضیح:
> پیام رسان های داخل ایران دارای مشکلات زیر ساختی فراوانی هستن
> گرچه هر کدام محیط های توسعه دارن ولی چندان انتظار ساختارهایی شبیه تلگرام را نداشته باشین
> در زمان نگارش این متن
> بسیاری از عملکرد آنها به درستی کار نمیکنند

روش استفاده از کدها:
1- Base class is __GapClinet__, you need to live this client in your app so please consider it as single
you can init this class in Global.asax and make it static

```csharp
Cm.Client = new GapClient(Properties.Settings.Default.Token)
            {
                //set text logger path to app_data folder in app settings
                Logger = new SimpleTextLogger(Properties.Settings.Default.LogDir
                    , (LogErrorLevel) Enum.Parse(typeof(LogErrorLevel), Properties.Settings.Default.LogLevel))
            };
```

you need a logger class, if you do not need log set __Logger__ to __DisabledLogger__
__SimpleTextLogger__ will log on text file, you can also write you own logger or use __Log4Net__ or __NLog__ in your project
see sample implemented logger in project directory 


![Preview Class Code](https://mahdiit.github.io/gapsharp/preview.jpg)

محیط توسعه
- VS2017
- .Net 4.6.2
- Asp.net
