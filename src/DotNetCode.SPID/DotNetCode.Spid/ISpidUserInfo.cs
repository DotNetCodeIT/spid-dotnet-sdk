using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid
{

   public interface ISpidUserInfo
    {
        /// <summary>
        /// Gets or sets the spid code.
        /// </summary>
        /// <value>
        /// The spid code.
        /// </value>
        string SpidCode { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the family.
        /// </summary>
        /// <value>
        /// The name of the family.
        /// </value>
        string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the place of birth.
        /// </summary>
        /// <value>
        /// The place of birth.
        /// </value>
        string PlaceOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the county of birth.
        /// </summary>
        /// <value>
        /// The county of birth.
        /// </value>
        string CountyOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        string DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        string Gender { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the registered office.
        /// </summary>
        /// <value>
        /// The registered office.
        /// </value>
        string RegisteredOffice { get; set; }

        /// <summary>
        /// Gets or sets the fiscal number.
        /// </summary>
        /// <value>
        /// The fiscal number.
        /// </value>
        string FiscalNumber { get; set; }

        /// <summary>
        /// Gets or sets the iva code.
        /// </summary>
        /// <value>
        /// The iva code.
        /// </value>
        string IvaCode { get; set; }

        /// <summary>
        /// Gets or sets the identifier card.
        /// </summary>
        /// <value>
        /// The identifier card.
        /// </value>
        string IdCard { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        /// <value>
        /// The mobile phone.
        /// </value>
        string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        string ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the digital address.
        /// </summary>
        /// <value>
        /// The digital address.
        /// </value>
        string DigitalAddress { get; set; }

    }

}
