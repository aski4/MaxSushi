using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Enities;
using System.Net.Mail;
using System.Net;

namespace Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "";
        public string MailFromAddress = "MaxSushiVin@gmail.com";
        public bool UseSsl = true;
        public string UserName = "";
        public string Password = "";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587; //???
        public bool WriteAsFile = false;
        public string FileLocation = @"D:\EmailPapka";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials 
                    = new NetworkCredential(emailSettings.UserName, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ оформлен")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (сумма: {2:c}", line.Quantity, line.Product.Name, subtotal);
                }

                body.AppendFormat("Полная сумма заказа: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Доставка: ")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? "")
                    .AppendLine(shippingDetails.Line3 ?? "")
                    .AppendLine(shippingDetails.PhoneNumber)
                    .AppendLine(shippingDetails.CustomerEmail)
                    .AppendLine("---")
                    .AppendFormat("Учебные палочки: {0}", shippingDetails.GiftWrap ? "Да" : "Нет");

                MailMessage mailMessage = new MailMessage(emailSettings.MailFromAddress, emailSettings.MailToAddress, "Новый заказ!", body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }

        
    }
}
