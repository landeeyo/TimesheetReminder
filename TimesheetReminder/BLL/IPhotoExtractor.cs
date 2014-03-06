
namespace TimesheetReminder.BLL
{
    /// <summary>
    /// Interface for photo extracting methods (strategy design pattern)
    /// </summary>
    interface IPhotoExtractor
    {
        /// <summary>
        /// Extracts link to photo from webpage of given address
        /// </summary>
        /// <param name="webAddress">Http address of website</param>
        /// <returns>Link to photo</returns>
        string ExtractPhoto(string webAddress);
    }
}
