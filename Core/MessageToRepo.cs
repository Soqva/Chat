using System;

namespace Core
{
    public class MessageToRepo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime SendTime { get; set; }
    }
}
