using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5.Utilities;

namespace Assignment5
{
    public class BusinessUser : RegisteredUser
    {
        //Attributes
        string instagram_link;
        List<PopupEvent> popupEvents = new List<PopupEvent>();

        //Properties
        public string Instagram_link
        {
            get => instagram_link;
            set => instagram_link = (!string.IsNullOrEmpty(value)) ? value : throw new ArgumentException("Invalid instagram link.");
        }

        //Constructors
        public BusinessUser() : base()
        {
            Instagram_link = "https://instagram.com/default";
        }

        public BusinessUser
            (string userId, string email, string password, string firstName, string lastName, string nickName, string phoneNumber, DateTime birthDate, string instagramLink)
            : base(userId, email, password, firstName, lastName, nickName, phoneNumber, birthDate)
        {
            Instagram_link = instagramLink;
        }

        //Methods
        public void AddPopupEvent(PopupEvent popupEvent)
        {
            if (popupEvent != null)
            {
                popupEvents.Add(popupEvent);
            }
            else
            {
                throw new ArgumentNullException("Popup event cannot be null.");
            }
        }

        public void RemovePopupEvent(PopupEvent popupEvent)
        {
            if (popupEvents.Contains(popupEvent))
            {
                popupEvents.Remove(popupEvent);
            }
            else
            {
                throw new ArgumentException("Popup event not found.");
            }
        }

        public void PrintPopupEvents()
        {
            if (popupEvents.Count > 0)
            {
                Console.WriteLine("Popup Events:");
                foreach (var popupEvent in popupEvents)
                {
                    popupEvent.PrintEventDetails();
                }
            }
            else
            {
                Console.WriteLine("No popup events found.\n");
            }
        }

        public override void Print()
        {
            Console.WriteLine($"Instagram Link: {Instagram_link}");
            base.Print();
            PrintPopupEvents();
        }
    }
}
