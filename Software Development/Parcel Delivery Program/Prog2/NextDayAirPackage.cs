// Program 1A
// CIS 200-01
// Fall 2020
// Due: 9/21/2020
// By: Andrew L. Wright (students use Grading ID)

// File: NextDayAirPackage.cs
// The NextDayAirPackage class is a concrete derived class from AirPackage. It adds
// an express fee.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NextDayAirPackage : AirPackage
{
    private decimal _expressFee; // Next day air package's express fee

    // Precondition:  pLength > 0, pWidth > 0, pHeight > 0,
    //                pWeight > 0, expFee >= 0
    // Postcondition: The next day air package is created with the specified values for
    //                origin address, destination address, length, width,
    //                height, weight, and express fee
    public NextDayAirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight, decimal expFee)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
    {
        ExpressFee = expFee;
    }

    public decimal ExpressFee
    {
        // Precondition:  None
        // Postcondition: The next day air package's express fee has been returned
        get
        {
            return _expressFee;
        }

        // Precondition:  value >= 0
        // Postcondition: The next day air package's express fee has been set to the
        //                specified value
        private set // Helper set property
        {
            if (value >= 0)
                _expressFee = value;
            else
                throw new ArgumentOutOfRangeException(nameof(ExpressFee), value,
                    $"{nameof(ExpressFee)} must be >= 0");
        }
    }

    // Precondition:  None
    // Postcondition: The next day air package's cost has been returned
    public override decimal CalcCost()
    {
        const double DIM_FACTOR = .35;    // Dimension coefficient in cost equation
        const double WEIGHT_FACTOR = .25; // Weight coefficient in cost equation
        const double HEAVY_FACTOR = .2;   // Heavy coefficient in cost equation
        const double LARGE_FACTOR = .22;  // Large coefficient in cost equation

        decimal cost; // Running total of cost of package

        cost = (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * Weight) + ExpressFee;

        if (IsHeavy())
            cost += (decimal)(HEAVY_FACTOR * Weight);
        if (IsLarge())
            cost += (decimal)(LARGE_FACTOR * TotalDimension);

        return cost;
    }

    // Precondition:  None
    // Postcondition: A String with the next day air package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; // Newline shorthand

        return $"NextDay{base.ToString()}{NL}Express Fee: {ExpressFee:C}";
    }
}
