// Program 1A
// CIS 200-01
// Fall 2020
// Due: 9/21/2020
// By: Andrew L. Wright (students use Grading ID)

// File: Package.cs
// The Package class is an abstract derived class from Parcel. It adds
// dimensions and weight.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]

public abstract class Package : Parcel
{
    private double _length; // Length of package in inches
    private double _width;  // Width of package in inches
    private double _height; // Height of package in inches
    private double _weight; // Weight of package in pounds

    // Precondition:  pLength > 0, pWidth > 0, pHeight > 0,
    //                pWeight > 0
    // Postcondition: The package is created with the specified values for
    //                origin address, destination address, length, width,
    //                height, and weight
    public Package(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight)
        : base(originAddress, destAddress)
    {
        Length = pLength;
        Width = pWidth;
        Height = pHeight;
        Weight = pWeight;
    }

    public double Length
    {
        // Precondition:  None
        // Postcondition: The package's length has been returned
        get
        {
            return _length;
        }

        // Precondition:  value > 0
        // Postcondition: The package's length has been set to the
        //                specified value
        set
        {
            if (value > 0)
                _length = value;
            else
                throw new ArgumentOutOfRangeException(nameof(Length), value,
                    $"{nameof(Length)} must be > 0");
        }
    }

    public double Width
    {
        // Precondition:  None
        // Postcondition: The package's width has been returned
        get
        {
            return _width;
        }

        // Precondition:  value > 0
        // Postcondition: The package's width has been set to the
        //                specified value
        set
        {
            if (value > 0)
                _width = value;
            else
                throw new ArgumentOutOfRangeException(nameof(Width), value,
                    $"{nameof(Width)} must be > 0");
        }
    }

    public double Height
    {
        // Precondition:  None
        // Postcondition: The package's height has been returned
        get
        {
            return _height;
        }

        // Precondition:  value > 0
        // Postcondition: The package's height has been set to the
        //                specified value
        set
        {
            if (value > 0)
                _height = value;
            else
                throw new ArgumentOutOfRangeException(nameof(Height), value,
                    $"{nameof(Height)} must be > 0");
        }
    }

    public double Weight
    {
        // Precondition:  None
        // Postcondition: The package's weight has been returned
        get
        {
            return _weight;
        }

        // Precondition:  value > 0
        // Postcondition: The package's weight has been set to the
        //                specified value
        set
        {
            if (value > 0)
                _weight = value;
            else
                throw new ArgumentOutOfRangeException(nameof(Weight), value,
                    $"{nameof(Weight)} must be > 0");
        }
    }
    
    // Helper Property
    protected double TotalDimension
    {
        // Precondition:  None
        // Postcondition: The package's (Length + Width + Height) is returned
        get
        {
            return (Length + Width + Height);
        }
    }

    // Precondition:  None
    // Postcondition: A String with the package's data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; // Newline shorthand

        return $"Package{NL}{base.ToString()}{NL}Length: {Length:N1}{NL}Width: {Width:N1}{NL}" +
            $"Height: {Height:N1}{NL}Weight: {Weight:N1}";
    }
}
