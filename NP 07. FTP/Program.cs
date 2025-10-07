
using System.Net;

// Использовали https://sftpcloud.io/tools/free-ftp-server
// бесплатный demo FTP сервер на час 

//UploadFTP();
//GetFTP();
//DownloadFTP();
void GetFTP() {
    var request = WebRequest.Create("ftp://eu-central-1.sftpcloud.io:21") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    request.Credentials = new NetworkCredential("abbcf2d7d12f4024ac49f022e776f08f", "QdLz4sqmg17KUxUEtij1Xn4p0QINxK1P");
    var response = request.GetResponse() as FtpWebResponse;
    var stream = response.GetResponseStream();
    var reader = new StreamReader(stream);
    var data = reader.ReadToEnd();
    Console.WriteLine(data);

}
void UploadFTP() {
    var request = WebRequest.Create("ftp://eu-central-1.sftpcloud.io:21/google.zip") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.UploadFile;
    request.Credentials = new NetworkCredential("abbcf2d7d12f4024ac49f022e776f08f", "QdLz4sqmg17KUxUEtij1Xn4p0QINxK1P");
    var fileStream = new FileStream(@"C:\Users\zamanov\Desktop\GoogleChromeEnterpriseBundle64.zip", FileMode.Open);
    var stream = request.GetRequestStream();
    fileStream.CopyTo(stream);
    stream.Close();
    fileStream.Close();
}
void DownloadFTP() {
    var request = WebRequest.Create("ftp://eu-central-1.sftpcloud.io:21/Salam.txt") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.DownloadFile;
    request.Credentials = new NetworkCredential("abbcf2d7d12f4024ac49f022e776f08f", "QdLz4sqmg17KUxUEtij1Xn4p0QINxK1P");
    var response = request.GetResponse() as FtpWebResponse;
    var stream = response.GetResponseStream();

    var fileStream = new FileStream(@"..\..\Salat.txt", FileMode.Create);

    stream.CopyTo(fileStream);
    fileStream.Close();

}
