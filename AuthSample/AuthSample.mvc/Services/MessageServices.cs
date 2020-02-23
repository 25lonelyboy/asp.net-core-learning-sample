using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuthSample.mvc.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        private readonly SenderOptions senderOptions;
        //注入配置模型，通过配置模型读取配置信息
        public AuthMessageSender(IOptions<SenderOptions> optionsAccessor)
        {
            senderOptions = optionsAccessor.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            SmtpClient client = new SmtpClient(senderOptions.Host);
            client.UseDefaultCredentials = false;
            client.EnableSsl = senderOptions.UseSsl;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(senderOptions.UserName, senderOptions.Password);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderOptions.UserName);
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            await client.SendMailAsync(mailMessage);
        }

        public Task SendSmsAsync(string number, string message)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", senderOptions.AliAccessKey, senderOptions.AliAccessSecret);
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", number);
            request.AddQueryParameters("SignName", senderOptions.AliSignName);
            request.AddQueryParameters("TemplateCode", senderOptions.AliTemplateCode);
            request.AddQueryParameters("TemplateParam", "{\"code\":\"" + message + "\"}");
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
            return Task.FromResult(0);
        }
    }
}
