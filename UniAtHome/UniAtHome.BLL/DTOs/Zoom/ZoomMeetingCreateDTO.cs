using System;

namespace UniAtHome.BLL.DTOs.Zoom
{

    public class ZoomMeetingCreateDTO
    {
        public string Topic { get; set; }

        public ZoomMeetingType Type { get; set; }

        public DateTime? StartTime { get; set; }

        public int Duration { get; set; }

        public string Password { get; set; }

        public string Agenda { get; set; }

        public ZoomMeetingSettingsDTO Settings { get; set; } = new ZoomMeetingSettingsDTO();
    }
}
