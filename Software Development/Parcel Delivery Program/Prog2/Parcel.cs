// Program 0
// CIS 200-76
// Fall 2020
// Due: 9/7/2020
// By: Andrew L. Wright (students use Grading ID)

// File: Parcel.cs
// Parcel serves as the abstract base class of the Parcel hierachy.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]

public abstract class Parcel
{
    private Address _originAddress; // The origin address for the parcel
    private Address _destAddress;   // The destination address for the parcel

    // Precondition:  None
    // Postcondition: The parcel is created with the specified values for
    //                origin address and destination address
    public Parcel(Address originAddress, Address destAddress)
    {
        OriginAddress = originAddress;
        DestinationAddress = destAddress;
    }

    public Address OriginAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's origin address has been returned
        get
        {
            return _originAddress;
        }

        // Precondition:  value must not be null
        // Postcondition: The parcel's origin address has been set to the
        //                specified value
        set
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException($"{nameof(OriginAddress)}",
                    value, $"{nameof(OriginAddress)} must not be null");
            }
            else
                _originAddress = value;
        }
    }

    public Address DestinationAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's destination address has been returned
        get
        {
            return _destAddress;
        }

        // Precondition:  value must not be null
        // Postcondition: The parcel's destination address has been set to the
        //                specified value
        set
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException($"{nameof(DestinationAddress)}",
                    value, $"{nameof(DestinationAddress)} must not be null");
            }
            else
                _destAddress = value;
        }
    }

    // Precondition:  None
    // Postcondition: The parcel's cost has been returned
    public abstract decimal CalcCost();

    // Precondition:  None
    // Postcondition: A String with the parcel's data has been returned
    public override String ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut

        return $"Origin Address:{NL}{OriginAddress}{NL}{NL}Destination Address:{NL}" +
            $"{DestinationAddress}{NL}Cost: {CalcCost():C}";
    }
}
