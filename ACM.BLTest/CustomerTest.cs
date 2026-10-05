using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.BusinessLayer;

namespace CMS.BusinessLayerTest
{
    [TestClass]
    public class CustomerTest
    {
      
        [TestMethod]
        public void FullNameTestValid()
        {
            //-- Arrange
            Customer customer = new Customer();
            customer.FirstName = "Bilbo";
            customer.LastName = "Baggins";

            string expected = "Baggins, Bilbo";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer();
            customer.LastName = "Baggins";
            string expected = "Baggins";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer();
            customer.FirstName = "Bilbo";
            string expected = "Bilbo";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void ValidateValid()
        {
            //-- Arrange
            var customer = new Customer();
            customer.LastName = "Baggins";
            customer.EmailAddress = "fbaggins@hobbiton.me";

            var expected = true;

            //-- Act
            var actual = customer.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            //-- Arrange
            var customer = new Customer();
            customer.EmailAddress = "fbaggins@hobbiton.me";

            var expected = false;

            //-- Act
            var actual = customer.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

    }

}
