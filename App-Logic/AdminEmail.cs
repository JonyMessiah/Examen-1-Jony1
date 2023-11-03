using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Communication.Email;

namespace AppLogic
{
    public class AdminEmail
    {
        public async Task<string> SendEmail(string emailAddress)
        {
            string connectionString = "endpoint=https://isa-ieee-communicationservice.unitedstates.communication.azure.com/;accesskey=p/eEvRFgsQVGdGdACB1wInqOKaxSdGOfpoO0g5ybFqp7kKWquqTF4SPsTyfm7EX8nTgfGlGnX7mF3q/SYxrmsQ==";
            
            EmailClient emailClient = new EmailClient(connectionString);

            EmailContent emailContent = new EmailContent("Queremos agradecerle por su compra"); //Subject
            emailContent.PlainText = "Hemos recibido su Pedido, y queremos informarle que nos pondremos en contacto con usted a la brevedad, para coordinar la entrega"; //Contenido del correo


            List<EmailAddress> emailAddresses = new List<EmailAddress> { new EmailAddress(emailAddress, "Suscriptor de ISA-IEEE") };
            EmailRecipients emailRecipients = new EmailRecipients(emailAddresses);


            EmailMessage emailMessage = new EmailMessage("DoNotReply@fc248c30-351e-4e54-a77b-1859390c2d5b.azurecomm.net", emailRecipients, emailContent);

            EmailSendOperation emailSendOperation = await emailClient.SendAsync(
                                                    WaitUntil.Completed,
                                                                emailMessage, CancellationToken.None);
            EmailSendResult statusMonitor = emailSendOperation.Value;

            Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

            return emailSendOperation.Value.Status.ToString();
        }
    }
}


