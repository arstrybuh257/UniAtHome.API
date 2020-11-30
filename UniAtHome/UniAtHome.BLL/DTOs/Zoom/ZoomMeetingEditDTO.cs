using System;

namespace UniAtHome.BLL.DTOs.Zoom
{
    public class ZoomMeetingEditDTO
    {
        public string Topic { get; set; }

        public string Agenda { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public ZoomMeetingSettingsDTO Settings { get; set; } = new ZoomMeetingSettingsDTO();
    }
}
