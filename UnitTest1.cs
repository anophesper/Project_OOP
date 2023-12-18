using System;
using Project;
using Project.EnumType;
using Project.Object;
using Project.Organization;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Artist_CreateArtObject_Sculpture_Success()
        {
            // Arrange
            Artist artist = new Artist("Test Artist", "Test Surname", 1980);
            float height = 1.5f;
            float weight = 10.0f;
            Materials material = Materials.Stone;
            MethodOfCreation creation = MethodOfCreation.Cutting;

            // Act
            ArtObject result = artist.CreateArtObject(1, "Test Sculpture", 2000, artist, height, weight, material, creation);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Sculpture", result.Name);
        }

        [TestMethod]
        public void Artist_CreateArtObject_Sculpture_Failure()
        {
            // Arrange
            Artist artist = new Artist("Test Artist", "Test Surname", 1980);
            float height = -1.5f; // Invalid height
            float weight = 10.0f;
            Materials material = Materials.Stone;
            MethodOfCreation creation = MethodOfCreation.Cutting;

            // Act
            ArtObject result = artist.CreateArtObject(1, "Test Sculpture", 2000, artist, height, weight, material, creation);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Artist_CreateArtObject_Painting_Success()
        {
            // Arrange
            Artist artist = new Artist("Test Artist", "Test Surname", 1980);
            string canvaSize = "20x30";
            Style stylePic = Style.Modernism;
            Paint material = Paint.Oil;

            // Act
            ArtObject result = artist.CreateArtObject(1, "Test Painting", 2000, artist, canvaSize, stylePic, material);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Painting", result.Name);
        }

        [TestMethod]
        public void Artist_CreateArtObject_Painting_Failure()
        {
            // Arrange
            Artist artist = new Artist("Test Artist", "Test Surname", 1980);
            string canvaSize = "50x50";
            Style stylePic = Style.Modernism;
            Paint material = Paint.Oil;

            // Act
            ArtObject result = artist.CreateArtObject(1, "Test Painting", 2222, artist, canvaSize, stylePic, material);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Gallery_AddArtwork_Success()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Artist artist = new Artist("Test Artist", "Test Surname", 1980);
            Painting painting = new Painting(1, "Test Painting", 2000, artist, "20x30", Style.Romanticism, Paint.Oil);
            Gallery gallery = new Gallery("Test Gallery", "Test Address", owner, new List<ArtObject>());

            // Act
            bool result = gallery.AddArtwork(painting);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, gallery.ArtWorks.Count);
        }

        [TestMethod]
        public void Gallery_AddArtwork_Failure()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Artist artist = new Artist("Test Artist", "Test Surname", 1980);
            Painting painting = null; // Invalid ArtObject
            Gallery gallery = new Gallery("Test Gallery", "Test Address", owner, new List<ArtObject>());

            // Act
            bool result = gallery.AddArtwork(painting);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, gallery.ArtWorks.Count);
        }

        [TestMethod]
        public void Museum_AddArtwork_Success()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Artist artist = new Artist("Test Artist", "Test Surname", 1980, null);
            Painting painting = new Painting(1, "Test Painting", 2000, artist, "20x30", Style.Romanticism, Paint.Oil);
            Museum museum = new Museum("Test Museum", "Test Address", owner, new List<ArtObject>());

            // Act
            bool result = museum.AddArtwork(painting);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, museum.ArtWorks.Count);
        }

        [TestMethod]
        public void Museum_AddArtwork_Failure()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Artist artist = new Artist("Test Artist", "Test Surname", 1980, null);
            Painting painting = null; // Invalid ArtObject
            Museum museum = new Museum("Test Museum", "Test Address", owner, new List<ArtObject>());

            // Act
            bool result = museum.AddArtwork(painting);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, museum.ArtWorks.Count);
        }

        [TestMethod]
        public void Owner_AddPlace_Success()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Artist artist = new Artist("Test Artist", "Test Surname", 1980, null);
            Painting painting = new Painting(1, "Test Painting", 2000, artist, "20x30", Style.Romanticism, Paint.Oil);
            List<ArtObject> artworks = new List<ArtObject> { painting };

            // Act
            IPresentable result = owner.AddPlace("Test Gallery", "Test Address", owner, artworks, false);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Gallery", result.Name);
            Assert.AreEqual(1, owner.Places.Count);
        }

        [TestMethod]
        public void Curator_AddExhibition_Success()
        {
            // Arrange
            Curator curator = new Curator("Test Curator", "Test Surname", 30);
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Museum place = new Museum("Test Museum", "Test Address", owner, null);
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(7);

            // Act
            Exhibition result = curator.AddExhibition("Test Exhibition", start, end, place, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Exhibition", result.Name);
            Assert.AreEqual(1, curator.Exhibitions.Count);
        }

        [TestMethod]
        public void Curator_AddExhibition_Failure()
        {
            // Arrange
            Curator curator = new Curator("Test Curator", "Test Surname", 30);
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Museum place = new Museum("Test Museum", "Test Address", owner, null);
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(-7); // Invalid end date

            // Act
            Exhibition result = curator.AddExhibition("Test Exhibition", start, end, place, null);

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(0, curator.Exhibitions.Count);
        }

        [TestMethod]
        public void Exhibition_ChangeDate_Success()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Museum place = new Museum("Test Museum", "Test Address", owner, null);
            Exhibition exhibition = new Exhibition("Test Exhibition", DateTime.Today, DateTime.Today.AddDays(7), place, null);
            DateTime newStartDate = DateTime.Today.AddDays(1);
            DateTime newEndDate = DateTime.Today.AddDays(8);

            // Act
            bool result = exhibition.ChangeDate(newStartDate, newEndDate);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(newStartDate, exhibition.StartDate);
            Assert.AreEqual(newEndDate, exhibition.EndDate);
        }

        [TestMethod]
        public void Exhibition_ChangeDate_Failure()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Museum place = new Museum("Test Museum", "Test Address", owner, null);
            Exhibition exhibition = new Exhibition("Test Exhibition", DateTime.Today, DateTime.Today.AddDays(7), place, null);
            DateTime newStartDate = DateTime.Today.AddDays(1);
            DateTime newEndDate = DateTime.Today; // Invalid end date

            // Act
            bool result = exhibition.ChangeDate(newStartDate, newEndDate);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Exhibition_AddArtObject_Success()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Artist artist = new Artist("Test Artist", "Test Surname", 1980, null);
            Painting painting = new Painting(1, "Test Painting", 2000, artist, "20x30", Style.Romanticism, Paint.Oil);
            Museum place = new Museum("Test Museum", "Test Address", owner, null);
            Exhibition exhibition = new Exhibition("Test Exhibition", DateTime.Today, DateTime.Today.AddDays(7), place, null);

            // Act
            bool result = exhibition.AddArtObject(painting);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, exhibition.ExhibitionObjects.Count);
        }

        [TestMethod]
        public void Exhibition_AddArtObject_Failure()
        {
            // Arrange
            Owner owner = new Owner("Test Owner", "Owner Surname", 30);
            Artist artist = new Artist("Test Artist", "Test Surname", 1980, null);
            Painting painting = null; // Invalid ArtObject
            Museum place = new Museum("Test Museum", "Test Address", owner, null);
            Exhibition exhibition = new Exhibition("Test Exhibition", DateTime.Today, DateTime.Today.AddDays(7), place, null);

            // Act
            bool result = exhibition.AddArtObject(painting);

            // Assert
            Assert.IsFalse(result);
        }
    }
}