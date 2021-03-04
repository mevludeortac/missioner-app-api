using System;
namespace Missioner.Models
{
    public class Message
    {
        public Int64 message_id { get; set; }
        public string subject{ get; set; }
        public DateTime create_date { get; set; }
        public Int64 sender { get; set; }
        public Int64 message_task_id { get; set; }
    }
}
