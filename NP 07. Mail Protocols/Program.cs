using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;

//using System.Net;
//using System.Net.Mail;



//SMTP();
//SMTPMailKit();
IMAP();

//void SMTP()
//{
//    var client = new SmtpClient("smtp.gmail.com", 587);
//    client.EnableSsl = true;

//    client.Credentials = new NetworkCredential("fbms.1223@gmail.com", "opulnrgguvhhebvt");

//    var message = new MailMessage
//    {
//        Subject = "Test Mail Protocols",
//        Body = "WINTER IS COMING!!! (WINTER=EXAM)"
//    };

//    message.From = new MailAddress("fbms.1223@gmail.com", "Donald Trump");

//    //message.To.Add(new MailAddress("nailhere849@gmail.com"));
//    //message.To.Add(new MailAddress("vagif.aliev.17.04@gmail.com"));
//    //message.To.Add(new MailAddress("ravansafarovelitar@gmail.com"));
//    //message.To.Add(new MailAddress("alibeylitural212@gmail.com"));
//    message.To.Add(new MailAddress("zamanov@itstep.org"));

//    client.Send(message);
//}


void SMTPMailKit()
{
    var client = new SmtpClient();
    client.Connect("smtp.gmail.com", 587);
    client.Authenticate("fbms.1223@gmail.com", "opulnrgguvhhebvt");

    var message = new MimeKit.MimeMessage();

    message.From.Add(new MailboxAddress("Barak Obama", "fbms.1223@gmail.com"));

    message.To.AddRange(new[]
    {
        MailboxAddress.Parse("nailhere849@gmail.com"),
        MailboxAddress.Parse("vagif.aliev.17.04@gmail.com"),
        MailboxAddress.Parse("ravansafarovelitar@gmail.com"),
        MailboxAddress.Parse("alibeylitural212@gmail.com"),
        MailboxAddress.Parse("zamanov@itstep.org")
    });

    message.Subject = "Exam";
    //message.Body = new TextPart("plain")
    //{
    //    Text = "WINTER IS COMING!!! (WINTER=EXAM)"
    //};

    message.Body = new TextPart("html")
    {
        Text = """
            <h1>WINTER IS COMING!!! (WINTER=EXAM)</h1>
            <img src='https://images2.minutemediacdn.com/image/upload/c_fill,w_1440,ar_16:9,f_auto,q_auto,g_auto/shape/cover/sport/WinterIsComing_social-share-7076d8e90f656c73183ce00052be52a4.jpg'/>
        """
    };

    client.Send(message);
    client.Disconnect(true);
}

void IMAP()
{
    var imapClient = new ImapClient();
    imapClient.Connect("imap.gmail.com", 993, true);
    imapClient.Authenticate("fbms.1223@gmail.com", "opulnrgguvhhebvt");

    var inbox = imapClient.Inbox;
    inbox.Open(FolderAccess.ReadWrite);

    var ids = inbox.Search(SearchQuery.All);

    //foreach(var id in ids)
    //{
    //    Console.WriteLine($"{id}. {inbox.GetMessage(id).TextBody}");
    //}

    //inbox.SetFlags(new UniqueId(55), MessageFlags.Deleted, true);
    //inbox.AddFlags(ids, MessageFlags.Seen, true);
    inbox.AddFlags(ids, MessageFlags.Deleted, true);

    inbox.Expunge();
    inbox.Close();


}