using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class PopupEvent
    {
        static int count;
        int eventId;
        string userId, eventName, pickAddress;
        DateTime startEvent, endEvent;
        ClothingItem[] listClothingItems;
        public int EventID { get { return eventId; } set { eventId = value; } }
        public string EventName { get { return eventName; } set { eventName = value; } }
        public DateTime StartEvent { get { return startEvent; } set { startEvent = value; } }
        public DateTime EndEvent { get { return endEvent; } set { endEvent = value; } }
        public string PickupAddress
        {
            get { return pickAddress; }
            set { pickAddress = value; }
        }
        public string UserID { get { return userId; } set { userId = value; } }
        public PopupEvent(string userId, string eventName, string pickAddress, DateTime
        startEvent, DateTime endEvent)
        {
            EventID = count++;
            UserID = userId;
            EventName = eventName;
            PickupAddress = pickAddress;
            while ((endEvent - startEvent).TotalDays < 1)
            {
                Console.WriteLine("A pop-up event must be as least one day long. enter again start date and end date");
                startEvent = DateTime.Parse(Console.ReadLine());
            }
            StartEvent = startEvent;
            EndEvent = endEvent;
        }
        public void AddClothingItem(ClothingItem item)
        {
            if (listClothingItems == null)
                listClothingItems = new ClothingItem[1];
            else Array.Resize(ref listClothingItems, listClothingItems.Length + 1);
            listClothingItems[listClothingItems.Length - 1] = item;
        }
        public void PrintEventDetails()
        {
            Console.WriteLine($"Event ID: {eventId}");
            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"Event Name: {eventName}");
            Console.WriteLine($"Pick Address: {pickAddress}");
            Console.WriteLine($"Start Time: {startEvent:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"End Time: {endEvent:yyyy-MM-dd HH:mm}");
            Console.WriteLine("Clothing Items:");
            if (listClothingItems != null && listClothingItems.Length > 0)
            {
                foreach (ClothingItem item in listClothingItems)
                {
                    item.Print();
                    Console.WriteLine("-----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(" No clothing items available.");
            }
        }
    }
}
