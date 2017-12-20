using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualEvent.BusinessLayer.Notification
{
    public class PushNotificationRequest : NotificationDefaultKeys
    {

        public string EventTitle { get; set; }
        public DateTime DateOfEvent { get; set; }
        public long EventId { get; set; }
        public string Question { get; set; }
        public long UserId { get; set; }
    }



    public class NotificationDefaultKeys
    {

        public NotificationDefaultKeys()
        {
            this.alert = string.Empty;
            this.sound = "default";
            this.badge = this.pushType = 0;
        }

        public string alert { get; set; }
        public int badge { get; set; }
        public int pushType { get; set; }
        public string sound { get; set; }

    }
    public class NotificationMatrix
    {
        public int PushTypeValue { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
        public string UseCase { get; set; }
    }

}
