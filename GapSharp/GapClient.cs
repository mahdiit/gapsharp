using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GapSharp.DtoModel;
using GapSharp.DtoModel.InputTypes;
using GapSharp.DtoModel.ResponseTypes;
using GapSharp.Infrastructure;
using GapSharp.Infrastructure.Logger;
using Newtonsoft.Json;
using RestSharp;

namespace GapSharp
{
    public class GapClient
    {
        public GapPostedMessage ExtractPostedMessage(HttpRequestBase request)
        {
            var form = request.Form;

            if (!form.AllKeys.Contains("chat_id"))
                throw new ArgumentException("Not found", "chat_id");

            if (!form.AllKeys.Contains("type"))
                throw new ArgumentException("Not found", "type");

            Logger.Log(JsonConvert.SerializeObject(new
            {
                ip = request.UserHostAddress,
                method = request.HttpMethod,
                chat_id = form["chat_id"],
                type = form["type"],
                data = form["data"]
            }),
                LogErrorLevel.Debug);

            var result = new GapPostedMessage()
            {
                ChatId = form["chat_id"],
                Data = form["data"],
                MessageType = (RecivedMessageType)Enum.Parse(typeof(RecivedMessageType), form["type"])
            };

            return result;
        }

        private LogWriter _logger;

        public LogWriter Logger
        {
            get { return _logger ?? (_logger = new ConsoleLogger()); }
            set { _logger = value; }
        }

        public GapClient(string token, string gapApiUrl = "https://api.gap.im/")
        {
            RestApi = new RestClient(gapApiUrl);
            RestApi.AddDefaultHeader("token", token);
        }
        public RestClient RestApi { get; }

        private void LogInput(object input)
        {
            Logger.Log(JsonConvert.SerializeObject(input), LogErrorLevel.Debug);
        }
        private void LogOutput(IRestResponse response, object payload)
        {
            Logger.Log(JsonConvert.SerializeObject(new
            {
                payload,
                response.ErrorMessage,
                response.IsSuccessful,
                response.StatusCode,
                response.Content,
                response.ContentLength,
                response.ContentEncoding
            }), LogErrorLevel.Debug);
        }

        public IRestResponse<SendMessageResponse> SendMessage(SendMessageInput input)
        {
            try
            {
                LogInput(input);

                var req = new RestRequest("sendMessage", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("type", input.MessageType);
                req.AddParameter("data", input.Data);
                req.AddParameter("reply_keyboard", input.ReplyKeyboard);
                req.AddParameter("inline_keyboard", input.InlineKeyboard);
                req.AddParameter("form", input.Form);

                var response = RestApi.Execute<SendMessageResponse>(req);

                LogOutput(response, new
                {
                    hasData = response.Data != null,
                    method = "SendMessage",
                    input.ChatId
                });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("SendMessage", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse<FileMessage> Upload(UploadInput input)
        {
            try
            {
                //LogInput(input);

                var req = new RestRequest("upload", Method.POST);
                req.AddFile(input.FileType, input.Data, input.FileName, input.MimeType);
                req.AlwaysMultipartFormData = true;

                req.AddParameter("reply_keyboard", input.ReplyKeyboard);
                req.AddParameter("inline_keyboard", input.InlineKeyboard);

                var response = RestApi.Execute<FileMessage>(req);

                LogOutput(response, new
                {
                    hasData = response.Data != null,
                    method = "Upload",
                    input.FileName
                });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("Upload", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse SendAction(SendActionInput input)
        {
            try
            {
                LogInput(input);

                var req = new RestRequest("sendAction", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("type", input.ActionType);

                var response = RestApi.Execute(req);

                LogOutput(response, new
                {
                    method = "SendAction",
                    input.ChatId
                });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("SendAction", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse EditMessage(EditMessageInput input)
        {
            try
            {
                LogInput(input);

                var req = new RestRequest("editMessage", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("message_id", input.MessageId);
                req.AddParameter("data", input.Data);
                req.AddParameter("inline_keyboard", input.InlineKeyboard);

                var response = RestApi.Execute(req);

                LogOutput(response, new { method = "EditMessage", input.MessageId });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("EditMessage", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse DeleteMessage(DeleteMessageInput input)
        {
            try
            {
                LogInput(input);

                var req = new RestRequest("deleteMessage", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("message_id", input.MessageId);

                var response = RestApi.Execute(req);

                LogOutput(response, new { method = "DeleteMessage", input.MessageId });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("DeleteMessage", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse AnswerCallback(AnswerCallbackInput input)
        {
            try
            {
                LogInput(input);

                var req = new RestRequest("answerCallback", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("callback_id", input.CallbackId);
                req.AddParameter("text", input.Text);
                req.AddParameter("show_alert", input.ShowAlert);

                var response = RestApi.Execute(req);

                LogOutput(response, new { method = "AnswerCallback", input.CallbackId });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("AnswerCallback", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse<SendInvoiceResponse> SendInvoice(SendInvoiceInput input)
        {
            try
            {
                LogInput(input);

                var req = new RestRequest("invoice", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("amount", input.Amount);
                req.AddParameter("description", input.Description);

                var response = RestApi.Execute<SendInvoiceResponse>(req);

                LogOutput(response, new { hasData = response.Data != null, method = "SendInvoice", input.Amount });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("SendInvoice", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse<PaymentResponse> InvoiceVerify(PaymentInput input)
        {
            try
            {
                LogInput(input);

                var req = new RestRequest("invoice/verify", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("ref_id", input.RefId);

                var response = RestApi.Execute<PaymentResponse>(req);

                LogOutput(response, new { hasData = response.Data != null, method = "InvoiceVerify", input.RefId });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("InvoiceVerify", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse<PaymentResponse> InvoiceInquery(PaymentInput input)
        {
            try
            {
                LogInput(input);

                var req = new RestRequest("invoice/inquery", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("ref_id", input.RefId);

                var response = RestApi.Execute<PaymentResponse>(req);

                LogOutput(response, new { hasData = response.Data != null, method = "InvoiceInquery", input.RefId });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("InvoiceInquery", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse<PaymentResponse> PaymentVerify(PaymentInput input)
        {
            try
            {
                var req = new RestRequest("payment/verify", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("ref_id", input.RefId);

                var response = RestApi.Execute<PaymentResponse>(req);

                LogOutput(response, new { hasData = response.Data != null, method = "PaymentVerify", input.RefId });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("PaymentVerify", LogErrorLevel.Error, ex);
                return null;
            }
        }
        public IRestResponse<PaymentResponse> PaymentInquery(PaymentInput input)
        {
            try
            {
                var req = new RestRequest("payment/inquery", Method.POST);
                req.AddParameter("chat_id", input.ChatId);
                req.AddParameter("ref_id", input.RefId);

                var response = RestApi.Execute<PaymentResponse>(req);

                LogOutput(response, new { hasData = response.Data != null, method = "PaymentInquery", input.RefId });

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log("PaymentInquery", LogErrorLevel.Error, ex);
                return null;
            }
        }
    }
}
