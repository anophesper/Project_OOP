using System;
using Project.Object;
using Project.Organization;

namespace TestProject
{
    //тестування методів з класів папки Object
    [TestClass]
    public class UnitTest1
    {
        //тестування методів класів папки Object
        [TestMethod]
        public void Artist_CreateArtObject()
        {
            /// Arrange
            var artist = new Artist();

            // Act
            bool result = artist.CreateArtObject();

            // Assert
            Assert.IsTrue(result);
        }

        //тестування методів класів папки Organization
        [TestMethod]
        public void Curator_AddExhibition()
        {
            // Arrange
            var curator = new Curator();

            // Act
            bool result = curator.AddExhibition();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Curator_RemoveExhibition()
        {
            // Arrange
            var curator = new Curator();

            // Act
            bool result = curator.RemoveExhibition();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Exhibition_AddArtObject()
        {
            // Arrange
            var exhibition = new Exhibition();
            var presentable = new Gallery();

            // Act
            bool result = exhibition.AddArtObject(presentable, "SomeName");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Exhibition_RemoveArtObject()
        {
            // Arrange
            var exhibition = new Exhibition();
            var presentable = new Gallery();

            // Act
            bool result = exhibition.RemoveArtObject(presentable, "SomeName");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Exhibition_ChangeDate()
        {
            // Arrange
            var exhibition = new Exhibition();

            // Act
            bool result = exhibition.ChangeDate();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Owner_AddPlace()
        {
            // Arrange
            var owner = new Owner();

            // Act
            bool result = owner.AddPlace();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Owner_DeletePlace()
        {
            // Arrange
            var owner = new Owner();

            // Act
            bool result = owner.DeletePlace();

            // Assert
            Assert.IsTrue(result);
        }
    }
}