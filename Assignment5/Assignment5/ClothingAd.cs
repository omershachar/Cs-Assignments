using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class ClothingAd
    {
        static int count;
        int adId;
        string userId, recipientID;
        string pickupAddress;
        bool adStatus; //true - to give clothingItem, false - to not give clothingItem
        DateTime creationDate, donationDate;
        uint itemId;
        public int AdID { get { return adId; } set { adId = value; } }
        public string UserId { get { return userId; } set { userId = value; } }
        public uint ItemID { get { return itemId; } set { itemId = value; } }
        public string PickupAddress
        {
            get { return pickupAddress; }
            set { pickupAddress = value; }
        }
        public bool AdStatus { get { return adStatus; } set { adStatus = value; } }
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        public DateTime DonationDate
        {
            get { return donationDate; }
            set { donationDate = value; }
        }
        public string RecipientID
        {
            get { return recipientID; }
            set { recipientID = value; }
        }
        public ClothingAd(uint itemId, string userId, string pickupAddress)
        {
            AdID = count++;
            CreationDate = DateTime.Now;
            PickupAddress = pickupAddress;
            AdStatus = false;
            ItemID = itemId;
            UserId = userId; //You forgot to write this line...
        }
        public void PrintAdDetails()
        {
            Console.WriteLine($"Ad ID: {adId}");
            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"Pickup Address: {PickupAddress}");
            Console.WriteLine($"Creation Date: {CreationDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Item ID: {itemId}");
        }
    }

}
