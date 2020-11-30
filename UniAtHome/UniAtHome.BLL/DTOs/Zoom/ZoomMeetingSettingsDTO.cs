namespace UniAtHome.BLL.DTOs.Zoom
{
    public class ZoomMeetingSettingsDTO
    {
        public bool JoinBeforeHost { get; set; }

        public bool MuteUponEntry { get; set; }

        public string AlternativeHosts { get; set; }

        public bool MeetingAuthentication { get; set; }
    }
}
