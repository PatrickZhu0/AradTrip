using System;
using System.Net;
using System.Net.Mail;
using System.Text;

// Token: 0x020001B1 RID: 433
public class MailSender
{
	// Token: 0x06000DF9 RID: 3577 RVA: 0x000482F0 File Offset: 0x000466F0
	private static bool _SendMail(string smtp, string affix, string from, string pwd, string to, string title, string body)
	{
		MailSender.smtpClient = new SmtpClient();
		MailSender.smtpClient.Host = smtp;
		MailSender.smtpClient.UseDefaultCredentials = false;
		NetworkCredential networkCredential = new NetworkCredential(from, pwd);
		NetworkCredential credentials = new NetworkCredential(from, pwd);
		MailSender.smtpClient.Credentials = credentials;
		MailSender.smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
		MailSender.mailMessage_mai = new MailMessage(from, to);
		MailSender.mailMessage_mai.Subject = title;
		MailSender.mailMessage_mai.Body = body;
		MailSender.mailMessage_mai.IsBodyHtml = true;
		MailSender.mailMessage_mai.BodyEncoding = Encoding.UTF8;
		MailSender.mailMessage_mai.IsBodyHtml = false;
		if (!string.IsNullOrEmpty(affix))
		{
			Attachment item = new Attachment(affix, "application/octet-stream");
			MailSender.mailMessage_mai.Attachments.Add(item);
		}
		bool result;
		try
		{
			MailSender.smtpClient.SendAsync(MailSender.mailMessage_mai, "000000000");
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000DFA RID: 3578 RVA: 0x000483E8 File Offset: 0x000467E8
	public static bool SetEmail(string title, string content)
	{
		string str = "Android";
		content = "平台：" + str + "，" + content;
		return MailSender._SendMail("smtp.exmail.qq.com", null, "jinxingmeng@herogo.net", "Q123wer", "simonking200@vip.qq.com", title, content);
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x00048430 File Offset: 0x00046830
	public static bool SetEmail(string toUser, string title, string content)
	{
		string str = "Android";
		content = "平台：" + str + "，" + content;
		return MailSender._SendMail("smtp.exmail.qq.com", null, "jinxingmeng@herogo.net", "Q123wer", toUser, title, content);
	}

	// Token: 0x040009BD RID: 2493
	private static SmtpClient smtpClient;

	// Token: 0x040009BE RID: 2494
	private static MailMessage mailMessage_mai;
}
