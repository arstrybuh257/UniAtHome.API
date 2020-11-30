namespace UniAtHome.BLL.DTOs.Zoom
{
    public enum ZoomMeetingType
    {
        Instant = 1,
        Scheduled = 2,
        Webinar = 5,
        // TODO: the API doesn't have support for the following params
        // but if one day you'd like to implement it, add "recurrence"
        // property to ZoomMeetingCreateDTO
        //RecurringWithNoFixedTime = 3,
        //RecurringWithFixedTime = 8
    }
}
