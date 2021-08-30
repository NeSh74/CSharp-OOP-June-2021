using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void Constructor_Should_SetCapacityCorrectly()
        {
            var robotManager = new RobotManager(6);

            Assert.That(robotManager.Capacity, Is.EqualTo(6));
        }

        [Test]
        public void Negative_CapacityShould_ThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => new RobotManager(-6),
                "Capacity is not negative.");
        }

        [Test]
        public void Constructor_ShouldSetCount_Correctly()
        {
            var robotManager = new RobotManager(6);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);

            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Method_ShouldAddRobot_Correctly()
        {
            var robotManager = new RobotManager(6);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);

            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Method_Should_ThrowExceptionIfRobotExisting()
        {
            var robotManager = new RobotManager(6);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(robot),
                "No robot duplicates.");
        }

        [Test]
        public void Add_Method_ShouldThrowExceptio_IfNoCapacityLeft()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(new Robot("Gogi", 1000)),
                "There is more capacity");
        }

        [Test]
        public void RemoveMethod_ShouldRemoveRobotCorrectly()
        {
            var robotManager = new RobotManager(5);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);
            robotManager.Remove("Sofia");

            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveMethod_ShouldThrowExceptionIfTheRobotIs_Null()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Remove(null),
                "Robot is not null.");
        }

        [Test]
        public void WorkMethod_ShouldThrowExceptionIfRobotIsNull()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work(null, "Manager", 100),
                "Robot is not null.");
        }

        [Test]
        public void WorkMethod_ShouldThrowException0IfRobotBatteryIsBellowThe_Battery_Usage()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("Sofia", "Manager", 1000),
                "Robot battery not bellow than the usage.");
        }

        [Test]
        public void WorkMethod_Should_DecreaseBatteryCorrectly()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);
            robotManager.Work("Sofia", "Manager", 50);

            Assert.That(robot.Battery, Is.EqualTo(50));
        }

        [Test]
        public void ChargeMethod_ShouldThrowExceptionIfRobotIsNull()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Charge(null),
                "Robot is not null.");
        }

        [Test]
        public void ChargeMethod_ShouldChargeRobotCorrectly()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);
            robotManager.Work("Sofia", "Manager", 80);
            robotManager.Charge("Sofia");

            Assert.That(robot.Battery, Is.EqualTo(100));
        }
    }
}
