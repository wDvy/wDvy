// Program 1A
// CIS 200-01
// Fall 2020
// Due: 9/21/2020
// By: Andrew L. Wright (students use Grading ID)

// File: TwoDayAirPackage.cs
// The TwoDayAirPackage class is a concrete derived class from AirPackage. It adds
// a delivery type.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]

public class TwoDayAirPackage : AirPackage
{
    public enum Delivery { Early, Saver } // Delivery types

    private Delivery _deliveryType; // TDAP's delivery type (Early or Saver)

    // Precondition:  pLength > 0, pWidth > 0, pHeight > 0,
    //                pWeight > 0
    // Postcondition: The two day air package is created with the specified values for
    //                origin address, destination address, length, width,
    //                height, weight, and delivery type
    public TwoDayAirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight, Delivery delType)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
    {
        DeliveryType = delType;
    }

    public Delivery DeliveryType
    {
        // Precondition:  None
        // Postcondition: The two day air package's delivery type has been returned
        get
        {
            return _deliveryType;
        }

        // Precondition:  value must be Early or Saver
        // Postcondition: The two day air package's delivery type has been set to the
        //                specified value
        set
        {
            if (Enum.IsDefined(typeof(Delivery), value))
                _deliveryType = value;
            else
                throw new ArgumentOutOfRangeException(nameof(DeliveryType), value,
                    $"{nameof(DeliveryType)} must be {nameof(Delivery.Early)} " +
                    $"or {nameof(Delivery.Saver)}");
        }
    }

    // Precondition:  None
    // Postcondition: The two day air package's cost has been returned
    public override decimal CalcCost()
    {
        const double DIM_FACTOR = .18;        // Dimension coefficient in cost equation
        const double WEIGHT_FACTOR = .2;      // Weight coefficient in cost equation
        const decimal DISCOUNT_FACTOR = .15M; // Discount factor in cost equation

        decimal cost; // Running total of cost of package

        cost = (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * Weight);

        if (DeliveryType == Delivery.Saver)
            cost *= (1-DISCOUNT_FACTOR);

        return cost;
    }

    // Precondition:  None
    // Postcondition: A String with the two day air package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; // Newline shorthand

        return $"TwoDay{base.ToString()}{NL}Delivery Type: {DeliveryType}";
    }
}
