using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLLLibrarySystem.Domain.Abstract;
using OLLLibrarySystem.Domain.Entities;

namespace OLLLibrarySystem.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "greg.wilson5@outlook.com";//TODO Send to location owners
        public string MailFromAddress = "noreply@LourdesAcademyLibrary.net";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;//Set to false if e-mail is to be sent - else will save to file.
        public string FileLocation = @"C:\Users\gregw\source\repos\OLLLibrarySystem\Orders";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {

            using (var smtpClient = new SmtpClient())
            {

                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                          emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendFormat("{0} has requested to check out the following items:\n", shippingInfo.Name)
                    .AppendLine("-----------------------")
                    .AppendLine("Items:");

                var i = 1;
                decimal value = 0;
                foreach (var line in cart.Lines)
                {
                    
                    var subtotal = line.Book.ReplacementCost * line.Quantity;
                    body.AppendLine($"{i}.  {line.Quantity} x {line.Book.BookTitle} (subtotal: {subtotal:c})");
                    body.AppendLine("");
                    i++;
                    value += subtotal;
                }

                body.AppendLine("-----------------------");
                body.AppendFormat("Total order value: {0:c}\n", value)
                    .AppendLine("-----------------------")
                    .AppendLine("Deliver items to:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine($"Grade: {shippingInfo.Grade}")
                    .AppendLine($"Teacher: {shippingInfo.HomeroomTeacher}")

                    //.AppendLine(shippingInfo.Line1)
                    //.AppendLine(shippingInfo.Line2 ?? "")
                    //.AppendLine(shippingInfo.Line3 ?? "")
                    //.AppendLine(shippingInfo.City)
                    //.AppendLine(shippingInfo.State ?? "")
                    //.AppendLine(shippingInfo.Zip)
                    .AppendLine("-----------------------");

                MailMessage mailMessage = new MailMessage(
                                       emailSettings.MailFromAddress,   // From
                                       emailSettings.MailToAddress,     // To
                                       "New Book Request!",             // Subject
                                       body.ToString());                // Body

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
