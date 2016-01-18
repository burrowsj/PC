using GardenMower;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenTests
{
    [TestFixture]
    public class MowerTest
    {
        [Test]
        public void changeHeading()
        {
            //Arrange
            IGarden testGarden = new Garden();
            Mower testMower = new Mower(testGarden);

            //Act
            testMower.move('L');

            //Assert
            Assert.AreEqual('W', testMower.Heading);
        }

        [Test]
        public void changeHeadingMultiple()
        {
            //Arrange
            IGarden testGarden = new Garden();
            Mower testMower = new Mower(testGarden);

            //Act
            testMower.move("LLRRR");

            //Assert
            Assert.AreEqual('E', testMower.Heading);
        }

        [Test]
        public void moveSingle()
        {
            //Arrange
            IGarden testGarden = new Garden {Width=1, Length=1 };
            Mower testMower = new Mower(testGarden);

            //Act
            testMower.move('M');

            //Assert
            Assert.AreEqual(0, testMower.Position.X);
            Assert.AreEqual(1, testMower.Position.Y);
        }

        [Test]
        public void moveMultiple()
        {
            //Arrange
            IGarden testGarden = new Garden { Width = 5, Length = 5 };
            Mower testMower = new Mower(testGarden, new CoOrdinate {X=1, Y=2 }, 'N');

            //Act
            testMower.move("LMLMLMLMM");

            //Assert
            Assert.AreEqual('N', testMower.Heading);
            Assert.AreEqual(1, testMower.Position.X);
            Assert.AreEqual(3, testMower.Position.Y);
        }

        [Test]
        public void moveMultiple2()
        {
            //Arrange
            IGarden testGarden = new Garden { Width = 5, Length = 5 };
            Mower testMower = new Mower(testGarden, new CoOrdinate { X = 3, Y = 3 }, 'E');

            //Act
            testMower.move("MMRMMRMRRM");

            //Assert
            Assert.AreEqual('E', testMower.Heading);
            Assert.AreEqual(5, testMower.Position.X);
            Assert.AreEqual(1, testMower.Position.Y);
        }

        [Test]
        public void moveException()
        {
            //Arrange
            IGarden testGarden = new Garden { Width = 1, Length = 1 };
            Mower testMower = new Mower(testGarden, new CoOrdinate { X = 0, Y = 0 }, 'W');
            string message = string.Empty;
            //Act
            try {
                testMower.move('M');
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }

            //Assert
            Assert.AreEqual(0, testMower.Position.X);
            Assert.AreEqual(0, testMower.Position.Y);
            Assert.AreEqual("You have reached the edge of the garden", message);
        }
    }
}
