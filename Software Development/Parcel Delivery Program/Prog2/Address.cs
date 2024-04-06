// Program 0
// CIS 200-76
// Fall 2020
// Due: 9/7/2020
// By: Andrew L. Wright (students use Grading ID)

// File: Address.cs
// This classes stores a typical US address consisting of name,
// two address lines, city, state, and 5 digit zip code.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]

public class Address
{


    public const int MIN_ZIP = 0;     // Minimum ZipCode value
    public const int MAX_ZIP = 99999; // Maximum ZipCode value

    private string _name;     // Address' name
    private string _address1; // First address line
    private string _address2; // Second address line, optional
    private string _city;     // Address' city
    private string _state;    // Address' state
    private int _zip;         // Address' zip code

    // Precondition:  name, address1, city, state may not be null, empty nor all whitespace
    //                MIN_ZIP <= zipcode <= MAX_ZIP
    // Postcondition: The address is created with the specified values for
    //                name, address1, address2, city, state, and zipcode
    public Address(string name, string address1, string address2,
        string city, string state, int zipcode)
    {
        Name = name;
        Address1 = address1;
        Address2 = address2;
        City = city;
        State = state;
        Zip = zipcode;
    }

    // Precondition:  name, address1, city, state may not be null, empty nor all whitespace
    //                MIN_ZIP <= zipcode <= MAX_ZIP
    // Postcondition: The address is created with the specified values for
    //                name, address1, city, state, and zipcode
    public Address(string name, string address1, string city,
        string state, int zipcode) :
        this(name, address1, string.Empty, city, state, zipcode)
    {
        // No body needed
        // Calls previous constructor sending empty string for Address2
    }

    public string Name
    {
        // Precondition:  None
        // Postcondition: The address' name has been returned
        get
        {
            return _name;
        }

        // Precondition:  value must not be null, empty nor all whitespace
        // Postcondition: The address' name has been set to the
        //                specified value
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException($"{nameof(Name)}",
                    value, $"{nameof(Name)} must not be empty");
            else
                _name = value.Trim();
        }
    }

    public string Address1
    {
        // Precondition:  None
        // Postcondition: The address' first address line has been returned
        get
        {
            return _address1;
        }

        // Precondition:  value must not be null, empty nor all whitespace
        // Postcondition: The address' first address line has been set to
        //                the specified value
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException($"{nameof(Address1)}",
                    value, $"{nameof(Address1)} must not be empty");
            else
                _address1 = value.Trim();
        }
    }

    public string Address2
    {
        // Precondition:  None
        // Postcondition: The address' second address line has been returned
        get
        {
            return _address2;
        }

        // Precondition:  None
        // Postcondition: The address' second address line has been set to
        //                the specified value
        set
        {
            if (value == null) // Just in case
                value = string.Empty;

            _address2 = value.Trim();
        }
    }

    public string City
    {
        // Precondition:  None
        // Postcondition: The address' city has been returned
        get
        {
            return _city;
        }

        // Precondition:  value must not be null, empty nor all whitespace
        // Postcondition: The address' city has been set to the
        //                specified value
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException($"{nameof(City)}",
                    value, $"{nameof(City)} must not be empty");
            else
                _city = value.Trim();
        }
    }

    public string State
    {
        // Precondition:  None
        // Postcondition: The address' state has been returned
        get
        {
            return _state;
        }

        // Precondition:  value must not be null, empty nor all whitespace
        // Postcondition: The address' state has been set to the
        //                specified value
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException($"{nameof(State)}",
                    value, $"{nameof(State)} must not be empty");
            else
                _state = value.Trim();
        }
    }

    public int Zip
    {
        // Precondition:  None
        // Postcondition: The address' zip code has been returned
        get
        {
            return _zip;
        }

        // Precondition:  MIN_ZIP <= value <= MAX_ZIP
        // Postcondition: The address' zip code has been set to the
        //                specified value
        set
        {
            if ((value >= MIN_ZIP) && (value <= MAX_ZIP))
                _zip = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(Zip)}", value,
                    $"{nameof(Zip)} must be U.S. 5 digit zip code");
        }
    }

    // Precondition:  None
    // Postcondition: A String with the address' data has been returned
    public override string ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut
        string result;                   // Builds formatted string

        result = $"{Name}{NL}{Address1}{NL}";

        if (!string.IsNullOrWhiteSpace(Address2)) // Is Address2 not empty?
            result += $"{Address2}{NL}";

        result += $"{City}, {State} {Zip:D5}";

        // -- OR --
        // Compact Way
        //result = $"{Name}{NL}{Address1}{NL}{Address2}" +
        //    $"{(String.IsNullOrWhiteSpace(Address2) ? string.Empty : NL)}" +
        //    $"{City}, {State} {Zip:D5}";

        return result;
    }
}