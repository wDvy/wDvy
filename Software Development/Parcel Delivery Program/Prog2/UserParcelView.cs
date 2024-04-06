// CIS 200
// UserParcelView (UPV) serves as a pure business logic class.
// An instance of the UPV class will be used by the desktop app
// to keep track of the user's address book and parcels that
// have been created using the stored addresses. The desktop
// app will use the methods of the UPV to manage addresses and
// parcels. Though internal access is given, thus exposing the
// internal structure of the class to the desktop app (since it
// is in the same namespace), it is best to call the existing
// methods of the UPV to complete the tasks. No changes should
// be made to the UPV class without permission from your
// instructor.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace UPVApp
{
    [Serializable]

    public class UserParcelView
    {

        

        // Namespace Accessible Data - Use with care
        internal List<Address> addresses; // List of addresses stored for this user
        internal List<Parcel> parcels;    // List of parcels for this user

        // Precondition:  None
        // Postcondition: The view has been created and is empty (no addresses, no parcels)

        public UserParcelView()
        {
            addresses = new List<Address>();
            parcels = new List<Parcel>();
        }

        // Precondition:  Address.MIN_ZIP <= zipcode <= Address.MAX_ZIP
        // Postcondition: An Address with the specified values has been created
        //                and added to the UserParcelView.
        public void AddAddress(String name, String address1, String address2,
        String city, String state, int zipcode)
        {
            Address a; // The address being added

            a = new Address(name, address1, address2, city, state, zipcode);
            addresses.Add(a);
        }

        // Precondition:  Address.MIN_ZIP <= zipcode <= Address.MAX_ZIP
        // Postcondition: An Address with the specified values has been created
        //                and added to the UserParcelView.
        public void AddAddress(String name, String address1, String city,
        String state, int zipcode)
        {
            AddAddress(name, address1, string.Empty, city, state, zipcode);
        }

        // Precondition:  cost >= 0
        // Postcondition: A Letter with the specified values has been created
        //                and added to the UserParcelView.
        public void AddLetter(Address originAddress, Address destAddress, decimal cost)
        {
            Letter l; // The letter being added

            l = new Letter(originAddress, destAddress, cost);
            parcels.Add(l);
        }

        // Precondition:  pLength > 0, pWidth > 0, pHeight > 0,
        //                pWeight > 0
        // Postcondition: A GroundPackage with the specified values has been created
        //                and added to the UserParcelView.
        public void AddGroundPackage(Address originAddress, Address destAddress,
            double pLength, double pWidth, double pHeight, double pWeight)
        {
            GroundPackage p; // The ground package being added

            p = new GroundPackage(originAddress, destAddress, pLength, pWidth,
                pHeight, pWeight);
            parcels.Add(p);
        }

        // Precondition:  pLength > 0, pWidth > 0, pHeight > 0,
        //                pWeight > 0, expFee >= 0
        // Postcondition: A NextDayAirPackage with the specified values has been created
        //                and added to the UserParcelView.
        public void AddNextDayAirPackage(Address originAddress, Address destAddress,
            double pLength, double pWidth, double pHeight, double pWeight, decimal expFee)
        {
            NextDayAirPackage p; // The next day air package being added

            p = new NextDayAirPackage(originAddress, destAddress, pLength, pWidth,
                pHeight, pWeight, expFee);
            parcels.Add(p);
        }

        // Precondition:  pLength > 0, pWidth > 0, pHeight > 0,
        //                pWeight > 0
        // Postcondition: A TwoDayAirPackage with the specified values has been created
        //                and added to the UserParcelView.
        public void AddTwoDayAirPackage(Address originAddress, Address destAddress,
            double pLength, double pWidth, double pHeight, double pWeight,
            TwoDayAirPackage.Delivery delType)
        {
            TwoDayAirPackage p; // The two day air package being added

            p = new TwoDayAirPackage(originAddress, destAddress, pLength, pWidth,
                pHeight, pWeight, delType);
            parcels.Add(p);
        }

        public int AddressCount
        {
            // Precondition:  None
            // Postcondition: The number of addresses in the UserParcelView
            //                is returned.
            get
            {
                return addresses.Count;
            }
        }

        public int ParcelCount
        {
            // Precondition:  None
            // Postcondition: The number of parcels in the UserParcelView
            //                is returned.
            get
            {
                return parcels.Count;
            }
        }

        // Precondition:  0 <= index < AddressCount
        // Postcondition: The specified address is returned
        public Address AddressAt(int index)
        {
            if ((index < 0) || (index >= AddressCount))
                throw new ArgumentOutOfRangeException("index", index, "Invalid index!");

            return AddressList[index];
        }

        // Precondition:  0 <= index < ParcelCount
        // Postcondition: The specified address is returned
        public Parcel ParcelAt(int index)
        {
            if ((index < 0) || (index >= ParcelCount))
                throw new ArgumentOutOfRangeException("index", index, "Invalid index!");

            return ParcelList[index];
        }

        internal List<Address> AddressList
        {
            // Namespace Helper property - Use with care
            // Precondition:  None
            // Postcondition: The list of addresses stored in the UserParcelView
            //                is returned.
            get
            {
                return addresses;
            }
        }

        internal List<Parcel> ParcelList
        {
            // Namespace Helper property - Use with care
            // Precondition:  None
            // Postcondition: The list of parcels stored in the UserParcelView
            //                is returned.
            get
            {
                return parcels;
            }
        }

        // Precondition:  None
        // Postcondition: A string summary of the UserParcel View is returned.
        public override string ToString()
        {
            // Using StringBuilder to show use of a more efficient way than String concatenation
            StringBuilder result = new StringBuilder(); // Will hold result as being built
            string NL = Environment.NewLine;            // Newline shorthand
            decimal totalCost = 0;                      // Running total of parcel costs

            foreach (Parcel p in ParcelList)
                totalCost += p.CalcCost();

            result.Append($"UserParcelView Info:{NL}");
            result.Append($"Number of Addresses stored: {AddressCount}{NL}");
            result.Append($"Number of Parcels stored:   {ParcelCount}{NL}");
            result.Append($"Total cost of Parcels:      {totalCost:C}{NL}");

            return result.ToString();
        }
    }
}
