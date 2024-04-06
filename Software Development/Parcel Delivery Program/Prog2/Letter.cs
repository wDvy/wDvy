

// File: Letter.cs
// The Letter class is a concrete derived class of Parcel. Letters
// have a fixed cost.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]

public class Letter : Parcel
{
    private decimal _fixedCost; // Cost to send letter

    // Precondition:  cost >= 0
    // Postcondition: The letter is created with the specified values for
    //                origin address, destination address, and cost
    public Letter(Address originAddress, Address destAddress, decimal cost)
        : base(originAddress, destAddress)
    {
        FixedCost = cost;
    }

    private decimal FixedCost // Helper property
    {
        // Precondition:  None
        // Postcondition: The letter's fixed cost has been returned
        get
        {
            return _fixedCost;
        }

        // Precondition:  value >= 0
        // Postcondition: The letter's fixed cost has been set to the
        //                specified value
        set
        {
            if (value >= 0)
                _fixedCost = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(FixedCost)}", value,
                    $"{nameof(FixedCost)} must be >= 0");
        }
    }

    // Precondition:  None
    // Postcondition: The letter's cost has been returned
    public override decimal CalcCost()
    {
        return FixedCost;
    }

    // Precondition:  None
    // Postcondition: A String with the letter's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut

        return $"Letter{NL}{base.ToString()}"; // Let base class help
    }
}
