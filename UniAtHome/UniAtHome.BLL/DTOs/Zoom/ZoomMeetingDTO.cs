using System;

namespace UniAtHome.BLL.DTOs.Zoom
{
    public class ZoomMeetingDTO
    {
        public long Id { get; set; }

        public string HostEmail { get; set; }

        public string Topic { get; set; }

        public ZoomMeetingType Type { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Agenda { get; set; }

        public string StartUrl { get; set; }

        public string JoinUrl { get; set; }

        public ZoomMeetingSettingsDTO Settings { get; set; } = new ZoomMeetingSettingsDTO();
    }
}
