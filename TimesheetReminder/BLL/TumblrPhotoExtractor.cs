using System.Net;

namespace TimesheetReminder.BLL
{
    /// <summary>
    /// Concrete strategy for extracting photos from given tumblr page (with gallery mode on, for example http://hotgirls07.tumblr.com)
    /// </summary>
    public class TumblrPhotoExtractor : IPhotoExtractor
    {
        public string ExtractPhoto(string webAddress)
        {
            //Downloading page
            WebClient client = new WebClient();
            string gallery = client.DownloadString(webAddress);

            //Taking first image from gallery
            int firstPhotoboxPosition = gallery.IndexOf("<div class=\"photobox\">");
            int firstATagOpeningAfterFirstPhotobox = gallery.IndexOf("<a href", firstPhotoboxPosition);
            int firstATagClosingAfterFirstPhotobox = gallery.IndexOf(">", firstATagOpeningAfterFirstPhotobox + 1);
            string href = gallery.Substring(firstATagOpeningAfterFirstPhotobox, firstATagClosingAfterFirstPhotobox - firstATagOpeningAfterFirstPhotobox + 1);
            int bigImageAddressBegin = href.IndexOf("\"");
            int bigImageAddressEnd = href.IndexOf("\"", bigImageAddressBegin + 1);
            string bigImageAddress = href.Substring(bigImageAddressBegin + 1, bigImageAddressEnd - bigImageAddressBegin - 1);

            //Extracting address from particular image
            string particularImage = client.DownloadString(bigImageAddress);
            int photoboxPosition = particularImage.IndexOf("<div class=\"photobox\">");
            int firstImgTagOpeningAfterPhotobox = particularImage.IndexOf("<img src", photoboxPosition);
            int firstImgTagClosingAfterPhotobox = particularImage.IndexOf(">", firstImgTagOpeningAfterPhotobox + 1);
            string imageTag = particularImage.Substring(firstImgTagOpeningAfterPhotobox, firstImgTagClosingAfterPhotobox - firstImgTagOpeningAfterPhotobox + 1);
            int imageAddressBegin = imageTag.IndexOf("\"");
            int imageAddressEnd = imageTag.IndexOf("\"", imageAddressBegin + 1);
            string imageAddress = imageTag.Substring(imageAddressBegin + 1, imageAddressEnd - imageAddressBegin - 1);

            return imageAddress;
        }
    }
}
