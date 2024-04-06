// Program 2
// CIS 200-76
// Fall 2020
// Due: 10/20/2020
// By: Andrew L. Wright (students use Grading ID)

// File: AddressForm.cs
// This class creates the Address dialog box form GUI. It performs validation
// and provides String properties for each field. This solution uses one
// event handler for all required text textboxes Validating events and one
// event handler for all controls Validated events.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class AddressForm : Form
    {
        public const String DEFAULT_STATE = "KY"; // Default state for addresses

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.
        public AddressForm()
        {
            InitializeComponent();

            List<string> states = new List<string> {"CA", "IN", "KY", "MD", "ME",
                                   "NC", "OH", "SC", "TN", "TX"}; // Possible states

            // Add states to comboBox
            foreach (string state in states)
                stateCbo.Items.Add(state);
            
            // This is not required but nice
            // If use, must remain in constructor not Load event
            // so that when loading data in P3 for editing, can still
            // specify actual state after constructing form
            // Select a state by default
            State = DEFAULT_STATE;
        }

        internal string AddressName
        {
            // Precondition:  None
            // Postcondition: The text of form's name field is returned
            get
            {
                return nameTxt.Text;
            }
            // Precondition:  None
            // Postcondition: The text of form's name field is set to specified value
            set
            {
                nameTxt.Text = value;
            }
        }

        internal string Address1
        {
            // Precondition:  None
            // Postcondition: The text of form's Address1 field is returned
            get
            {
                return address1Txt.Text;
            }
            // Precondition:  None
            // Postcondition: The text of form's Address1 field is set to specified value
            set
            {
                address1Txt.Text = value;
            }
        }

        internal string Address2
        {
            // Precondition:  None
            // Postcondition: The text of form's Address2 field is returned
            get
            {
                return address2Txt.Text;
            }
            // Precondition:  None
            // Postcondition: The text of form's Address2 field is set to specified value
            set
            {
                address2Txt.Text = value;
            }
        }

        internal string City
        {
            // Precondition:  None
            // Postcondition: The text of form's City field is returned
            get
            {
                return cityTxt.Text;
            }
            // Precondition:  None
            // Postcondition: The text of form's City field is set to specified value
            set
            {
                cityTxt.Text = value;
            }
        }

        internal string ZipText
        {
            // Precondition:  None
            // Postcondition: The text of form's Zip field is returned
            get
            {
                return zipTxt.Text;
            }
            // Precondition:  None
            // Postcondition: The text of form's Zip field is set to specified value
            set
            {
                zipTxt.Text = value;
            }
        }

        internal string State
        {
            // Precondition:  None
            // Postcondition: The text of form's State field is returned
            get
            {
                if (stateCbo.SelectedIndex != -1) // -1 means no item selected
                    return stateCbo.SelectedItem.ToString();
                else
                    return "";

            }
            // Precondition:  value must be in stateCbo Items
            // Postcondition: The text of form's State field is set to specified value
            set
            {
                stateCbo.SelectedItem = value;
            }
        }

        // Precondition:  Focus is shifting from stateCbo
        // Postcondition: If no state selected, focus remains and error
        //                provider highlights the field
        private void stateCbo_Validating(object sender, CancelEventArgs e)
        {
            if (stateCbo.SelectedIndex == -1) // Didn't select anything from cbo
            {
                e.Cancel = true;
                errorProvider.SetError(stateCbo, "Must select a state!");
            }
        }

        // Precondition:  Focus is shifting from zipTxt
        // Postcondition: If text is invalid, focus remains and error provider
        //                highlights the field
        private void zipTxt_Validating(object sender, CancelEventArgs e)
        {
            int zip;           // Zip code of address

            if (!int.TryParse(zipTxt.Text, out zip)      // Parse failed?
                || (zip < Address.MIN_ZIP) || (zip > Address.MAX_ZIP)) // Invalid, so cancel and highlight field
            {
                e.Cancel = true;
                zipTxt.SelectAll();
                errorProvider.SetError(zipTxt, "Invalid zip code! Enter 5 digit zip code.");
            }
        }

        // Precondition:  Focus is shifting from sender
        //                sender is TextBox
        // Postcondition: If text is invalid, focus remains and error provider
        //                highlights the field
        private void RequiredTextFields_Validating(object sender, CancelEventArgs e)
        {
            // Downcast to sender as TextBox, so make sure you obey precondition!
            TextBox textbox = sender as TextBox; // Cast sender as TextBox
                                                 // Should always be a TextBox

            if (string.IsNullOrWhiteSpace(textbox.Text)) // Empty field
            {
                e.Cancel = true;

                // errorProvider.SetError(textbox, "Must enter a value!");

                // ---OR---

                // Alternate error message with specific field named
                const int SUFFIX = 3; // Chars in "txt" suffix in control names
                string name;          // Will hold field name based on control name
                name = textbox.Name.Substring(0, textbox.Name.Length - SUFFIX); // Remove suffix
                errorProvider.SetError(textbox, $"Must enter a value for {name}!");

            }
        }

        // Precondition:  Validating of sender not cancelled, so data OK
        //                sender is Control
        // Postcondition: Error provider cleared and focus allowed to change
        private void AllFields_Validated(object sender, EventArgs e)
        {
            // Downcast to sender as Control, so make sure you obey precondition!
            Control control = sender as Control; // Cast sender as Control
                                                 // Should always be a Control
            errorProvider.SetError(control, "");
        }

        // Precondition:  User pressed on cancelBtn
        // Postcondition: Form closes and sends Cancel result
        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            // This handler uses MouseDown instead of Click event because
            // Click won't be allowed if other field's validation fails

            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }

        // Precondition:  User clicked on okBtn
        // Postcondition: If invalid field on dialog, keep form open and give first invalid
        //                field the focus. Else return OK and close form.
        private void okBtn_Click(object sender, EventArgs e)
        {
            // Raise validating event for all enabled controls on form
            // If all pass, ValidateChildren() will be true
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }
    }
}
