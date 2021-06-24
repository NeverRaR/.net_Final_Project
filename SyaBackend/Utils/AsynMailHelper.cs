using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SyaBackend.Utils
{
    public class MailInfo
    {
        public String MailTo { get; set; }
        public String MailSubject { get; set; }
        public String MailContent { get; set; }
        public String SmtpServer { get; set; }
        public String MailFrom { get; set; }
        public String UserPassword { get; set; }
    }
    public class AsynMailHelper
    {
           public static void Execute(object obj)
          {
            MailInfo info = (MailInfo)obj;
            if (info != null)
            {
                // 设置发送方的邮件信息,例如使用腾讯的smtp
               

                // 邮件服务设置
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
                smtpClient.Host = info.SmtpServer; //指定SMTP服务器



                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(info.MailFrom, info.UserPassword);//用户名和密码

                // 发送邮件设置      
                MailMessage mailMessage = new MailMessage(info.MailFrom, info.MailTo); // 发送人和收件人
                mailMessage.Subject = info.MailSubject;//主题
                mailMessage.Body = info.MailContent;//内容
                mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
                mailMessage.IsBodyHtml = true;//设置为HTML格式
                mailMessage.Priority = MailPriority.Low;//优先级
                smtpClient.Send(mailMessage); // 发送邮件

            }
          }
        
    }
}
