

// File: GroundPackage.cs
// The Package class is a concrete derived class from Package. It adds
// a Zone Distance.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]

public class GroundPackage : Package
{
    // Precondition:  pLength > 0, pWidth > 0, pHeight > 0,
    //                pWeight > 0
    // Postcondition: The ground package is created with the specified values for
    //                origin address, destination address, length, width,
    //                height, and weight
    public GroundPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
    {
        // All work done in base class constructor
    }

    public int ZoneDistance
    {
        // Precondition:  None
        // Postcondition: The ground package's zone distance is returned.
        //                The zone distance is the positive difference between the
        //                first digit of the origin address' zip code and the first
        //                digit of the destination address' zip code.
        get
        {
            const int FIRST_DIGIT_FACTOR = 10000; // Denominator to extract 1st digit
            int dist;                             // Calculated zone distance

            dist = Math.Abs((OriginAddress.Zip / FIRST_DIGIT_FACTOR) - (DestinationAddress.Zip / FIRST_DIGIT_FACTOR));

            return dist;
        }
    }

    // Precondition:  None
    // Postcondition: The ground package's cost has been returned
    public override decimal CalcCost()
    {
        const double DIM_FACTOR = .15;    // Dimension coefficient in cost equation
        const double WEIGHT_FACTOR = .07; // Weight coefficient in cost equation

        return (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * (ZoneDistance + 1) * Weight);
    }

    // Precondition:  None
    // Postcondition: A String with the ground package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; // Newline shorthand

        return $"Ground{base.ToString()}{NL}Zone Distance: {ZoneDistance}";
    }
}

