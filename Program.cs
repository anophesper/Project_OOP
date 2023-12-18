using Project.EnumType;
using Project.Object;
using Project.Organization;

namespace Project
{
    public class Program
    {
        public static List<ArtObject> artObjects = new List<ArtObject>();
        public static List<Artist> artists = new List<Artist>();
        public static List <IPresentable> venues = new List<IPresentable>();
        public static List<Owner> owners = new List<Owner>();
        public static List<Curator> curators = new List<Curator>();
        public static List<Exhibition> exhibitions = new List<Exhibition>();

        public static void Main(string[] args)
        {
            while (true)
            {
                int choice = PrintMainMenu();
                switch (choice) {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("How do you want to create art objects? Enter 1 for manual creation, 2 for random creation:");
                        while (true) {
                            string creationMethod = Console.ReadLine();
                            if (creationMethod == "1") {
                                CreateArtObject();
                                break;
                            }
                            else if (creationMethod == "2") {
                                Console.WriteLine("Enter the number of art objects to create:");
                                int numberOfArtObjects = Convert.ToInt32(Console.ReadLine());
                                GenerateArtObjectsAndArtists(numberOfArtObjects, numberOfArtObjects);
                                break;
                            }
                            else
                                Console.WriteLine("Invalid input. Please enter 1 for manual creation or 2 for random creation.");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        if (artObjects.Count == 0)
                            Console.WriteLine("No art objects found.");
                        foreach (var artObject in artObjects) {
                            artObject.infoArtObject();
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (artists.Count == 0)
                            Console.WriteLine("No artists found.");
                        foreach (var artist in artists) {
                            artist.infoArtist();
                            Console.WriteLine("");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("How do you want to create places? Enter 1 for manual creation, 2 for random creation:");
                        while (true)
                        {
                            string creationMethod = Console.ReadLine();
                            if (creationMethod == "1")
                            {
                                AddPlace();
                                break;
                            }
                            else if (creationMethod == "2")
                            {
                                Console.WriteLine("Enter the number of places to create:");
                                int numberOfPlaces = Convert.ToInt32(Console.ReadLine());
                                AddRandomPlaces(numberOfPlaces);
                                break;
                            }
                            else
                                Console.WriteLine("Invalid input. Please enter 1 for manual creation or 2 for random creation.");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        if (venues.Count == 0)
                            Console.WriteLine("No venues found.");
                        foreach (var venue in venues){
                            venue.info();
                            Console.WriteLine("");
                        }
                        break;
                    case 6:
                        Console.Clear();
                        if (owners.Count == 0)
                            Console.WriteLine("No owners found.");
                        foreach (var owner in owners)
                        {
                            owner.infoOwner();
                            Console.WriteLine("");
                        }
                        break;
                    case 7:
                        Console.Clear();
                        AddMoreArtObject();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("How do you want to create exhibition? Enter 1 for manual creation, 2 for random creation:");
                        while (true)
                        {
                            string creationMethod = Console.ReadLine();
                            if (creationMethod == "1")
                            {
                                AddExhibition();
                                break;
                            }
                            else if (creationMethod == "2")
                            {
                                Console.WriteLine("Enter the number of exibitions to create:");
                                int numberOfArtObjects = Convert.ToInt32(Console.ReadLine());
                                GenerateExhibitions(numberOfArtObjects);
                                break;
                            }
                            else
                                Console.WriteLine("Invalid input. Please enter 1 for manual creation or 2 for random creation.");
                        }
                        break;
                    case 9:
                        Console.Clear();
                        if (exhibitions.Count == 0)
                            Console.WriteLine("No exibitions found.");
                        foreach (var exibition in exhibitions)
                        {
                            exibition.infoExhibition();
                            Console.WriteLine();
                        }
                        break;
                    case 10:
                        Console.Clear();
                        if (curators.Count == 0)
                            Console.WriteLine("No curators found.");
                        foreach (var curator in curators)
                        {
                            curator.infoCurator();
                            Console.WriteLine();
                        }
                        break;
                    case 11:
                        Console.Clear();
                        ModifyExhibition();
                        break;
                    case 0:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("You entered an incorrect value."); break;
                }
            }
        }

        // Вивід головного меню програми
        public static int PrintMainMenu()
        {
            Console.WriteLine("\n1. Add art object.\n2. View all art objects in list. \n3. View all artists in list.\n4. Add venue" +
                "\n5. View venues\n6. View owners of venues\n7. Add to venue new artobject\n8. Add new Exhibition\n9. View all exhibitions" +
                "\n10. View all curators\n11.Edit Exhibition\n0. End work.\n");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Sorry, it's not a number.");

            return choice;
        }

        //метод для створення нового витвору мистецтва
        public static void CreateArtObject()
        {
            try
            {
                //обираємо який арт об'єкт створювати
                string choose = "";
                while (choose != "1" && choose != "2")
                {
                    Console.WriteLine("Choose the type of the art object (1 for Painting or 2 for Sculpture): ");
                    choose = Console.ReadLine();
                    if (choose == "1" || choose == "2") 
                        break;
                    else
                        Console.WriteLine("Incorrect number, choose 1 or 2");
                }
                
                int lastId = artObjects.Count > 0 ? artObjects.Max(artObject => artObject.Id) : -1; //генеруємо унікальне id
                int id = lastId + 1;

                //запрашуємо дані для об'єкта та перевіряємо їх на валідність
                string name;
                while (true)
                {
                    Console.WriteLine("Enter the name of the art object: ");
                    name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name))
                        break;
                    else
                        Console.WriteLine("Name can't be null");
                }

                int? yearOfCreation = null;
                while (true)
                {
                    Console.WriteLine("Enter the year of creation of the art object (or leave it blank if unknown): ");
                    string? yearOfCreationInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(yearOfCreationInput))
                        break;
                    else
                    {
                        try
                        {
                            if (!int.TryParse(yearOfCreationInput, out int parsedYear))
                                throw new Exception("Year must be a number");
                            yearOfCreation = parsedYear;
                            int currentYear = DateTime.Now.Year;
                            if (yearOfCreation < 0 || yearOfCreation > currentYear)
                                throw new Exception("Year can't be < 0 or > current year");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                //обираємо митця зі списку або додаємо нового
                Artist artist;
                while (true)
                {
                    Console.WriteLine("Please select the number of the artist or enter 0 to add a new one:");
                    for (int i = 0; i < artists.Count; i++)
                        Console.WriteLine($"{i + 1}. {artists[i].Name} {artists[i].Surname}");

                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input == 0)
                    {
                        string nameArt;
                        while (true)
                        {
                            Console.Write("Enter the name: ");
                            nameArt = Console.ReadLine();
                            if (!nameArt.Any(char.IsDigit) && nameArt.Length >= 2)
                                break;
                            Console.WriteLine("Name cannot contain digits and must be at least two characters long");
                        }

                        string surname;
                        while (true)
                        {
                            Console.Write("Enter the surname: ");
                            surname = Console.ReadLine();
                            if (!surname.Any(char.IsDigit) && surname.Length >= 2)
                                break;
                            Console.WriteLine("Surname cannot contain digits and must be at least two characters long");
                        }

                        int birthYear;
                        while (true)
                        {
                            Console.Write("Enter the birth year: ");
                            string birthYearInput = Console.ReadLine();
                            if (Int32.TryParse(birthYearInput, out birthYear) && birthYear >= 0)
                                break;
                            Console.WriteLine("Birth year must be a non-negative integer");
                        }

                        int? deathYear = null;
                        while (true)
                        {
                            Console.Write("Enter the death year (or leave it blank if the artist is still alive): ");
                            string deathYearInput = Console.ReadLine();
                            if (string.IsNullOrEmpty(deathYearInput))
                                break;
                            else
                            {
                                if (Int32.TryParse(deathYearInput, out int tempDeathYear) && tempDeathYear >= birthYear)
                                {
                                    deathYear = tempDeathYear;
                                    break;
                                }
                                Console.WriteLine("Death year must be a non-negative integer and not less than the birth year");
                            }
                        }

                        Artist newArtist = new Artist(nameArt, surname, birthYear, deathYear);
                        artists.Add(newArtist);
                        Console.WriteLine("Artist was added");
                        artist = newArtist;
                        break;
                    }
                    else if (input > 0 && input <= artists.Count)
                    {
                        artist = artists[input - 1];
                        break;
                    }
                    else
                        Console.WriteLine("Invalid input. Please try again.");
                }

                //характеристики для картини
                if (choose == "1")
                {
                    Console.WriteLine("Enter the canvas size of the painting: ");
                    string canvasSize = Console.ReadLine();

                    //вивід можливих варіантів для обрання стилю
                    Console.WriteLine("\nStyle:");
                    foreach (Style style in Enum.GetValues(typeof(Style)))
                        Console.WriteLine(style);

                    Console.WriteLine("\nEnter the style of the painting:");
                    Style stylePic = Style.None;
                    string userStyle;

                    while (true)
                    {
                        userStyle = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(userStyle) || (Enum.TryParse(userStyle, out stylePic)))
                            break;
                        Console.WriteLine("Invalid style. Please enter a valid style from the list.");
                    }

                    //вивід можливих варіантів для обрання матеріалів
                    Console.WriteLine("\nMaterial:");
                    foreach (Paint paint in Enum.GetValues(typeof(Paint)))
                        Console.WriteLine(paint);

                    Console.WriteLine("\nEnter the material of the painting:");
                    Paint material = Paint.None;
                    string userMaterial;

                    while (true)
                    {
                        userMaterial = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(userMaterial) || (Enum.TryParse(userMaterial, out material)))
                            break;
                        Console.WriteLine("Invalid material. Please enter a valid material from the list.");
                    }

                    artObjects.Add(artist.CreateArtObject(id, name, yearOfCreation, artist, canvasSize, stylePic, material));
                    Console.WriteLine("Paintin was added");
                }
                //характеристики для скульптури
                else if (choose == "2")
                {
                    float height;
                    while (true)
                    {
                        Console.WriteLine("Enter the height of the sculpture: ");
                        string heightInput = Console.ReadLine();
                        if (float.TryParse(heightInput, out height) && !heightInput.Any(char.IsLetter))
                        {
                            if (height < 0)
                                Console.WriteLine("Height can't be < 0");
                            else
                                break;
                        }
                        else
                            Console.WriteLine("Height must be a number and should not contain letters");
                    }

                    float weight;
                    while (true)
                    {
                        Console.WriteLine("Enter the weight of the sculpture: ");
                        string weightInput = Console.ReadLine();
                        if (float.TryParse(weightInput, out weight) && !weightInput.Any(char.IsLetter))
                        {
                            if (weight < 0)
                                Console.WriteLine("Weight can't be < 0");
                            else
                                break;
                        }
                        else
                            Console.WriteLine("Weight must be a number and should not contain letters");
                    }

                    //вивід можливих варіантів для обрання матеріалу
                    Console.WriteLine("\nMaterial:");
                    foreach (Materials material in Enum.GetValues(typeof(Materials)))
                        Console.WriteLine(material);

                    Console.WriteLine("\nEnter the material of the sculpture:");
                    Materials sculptureMaterial = Materials.None;
                    string userMaterial;

                    while (true)
                    {
                        userMaterial = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(userMaterial) || (Enum.TryParse(userMaterial, out sculptureMaterial)))
                            break;
                        Console.WriteLine("Invalid material. Please enter a valid material from the list.");
                    }

                    //вивід можливих варіантів для обрання методу створення
                    Console.WriteLine("\nMethod of Creation:");
                    foreach (MethodOfCreation creation in Enum.GetValues(typeof(MethodOfCreation)))
                        Console.WriteLine(creation);

                    Console.WriteLine("\nEnter the method of creation of the sculpture:");
                    MethodOfCreation methodOfCreation = MethodOfCreation.None;
                    string userMethod;

                    while (true)
                    {
                        userMethod = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(userMethod) || (Enum.TryParse(userMethod, out methodOfCreation)))
                            break;
                        Console.WriteLine("Invalid method. Please enter a valid method from the list.");
                    }

                    artObjects.Add(artist.CreateArtObject(id, name, yearOfCreation, artist, height, weight, sculptureMaterial, methodOfCreation));
                    Console.WriteLine("Sculpture was added");
                }
            }
            catch (Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //метод для генерації нового витвору мистецтва
        public static void GenerateArtObjectsAndArtists(int numberOfArtists, int numberOfArtObjectsPerArtist)
        {
            Random random = new Random();
            string[] names = { "Vincent", "Pablo", "Leonardo", "Michelangelo", "Raphael" };
            string[] surnames = { "Van Gogh", "Picasso", "da Vinci", "Buonarroti", "Sanzio" };

            for (int i = 0; i < numberOfArtists; i++)
            {
                string name = names[random.Next(names.Length)];
                string surname = surnames[random.Next(surnames.Length)];
                int birthYear = random.Next(1850, 1950);
                int deathYear = random.Next(1950, 2020);

                Artist artist = new Artist(name, surname, birthYear, deathYear);
                artists.Add(artist);

                for (int j = 0; j < numberOfArtObjectsPerArtist; j++)
                {
                    int id = j;
                    string artObjectName = $"Art Object {j}";
                    int? yearOfCreation = random.Next(1900, 2020);

                    //Випадково обирає для створення скульптуру чи картину
                    if (random.Next(2) == 0)
                    {
                        //Створює скульптуру
                        float height = (float)random.NextDouble() * 100;
                        float weight = (float)random.NextDouble() * 100;
                        Materials material = (Materials)random.Next(Enum.GetNames(typeof(Materials)).Length);
                        MethodOfCreation creation = (MethodOfCreation)random.Next(Enum.GetNames(typeof(MethodOfCreation)).Length);

                        artObjects.Add(artist.CreateArtObject(id, artObjectName, yearOfCreation, artist, height, weight, material, creation));
                    }
                    else
                    {
                        //Створює картину
                        string canvasSize = $"{random.Next(1, 100)}x{random.Next(1, 100)}";
                        Style stylePic = (Style)random.Next(Enum.GetNames(typeof(Style)).Length);
                        Paint material = (Paint)random.Next(Enum.GetNames(typeof(Paint)).Length);

                        artObjects.Add(artist.CreateArtObject(id, artObjectName, yearOfCreation, artist, canvasSize, stylePic, material));
                    }
                }
            }
            Console.WriteLine("Objects were generated");
        }

        //метод для додавання нового місця проведення
        public static void AddPlace()
        {
            List<ArtObject> artworks = new List<ArtObject>();
            string name;
            while (true)
            {
                Console.Write("Enter the name: ");
                name = Console.ReadLine();
                if (!name.Any(char.IsDigit) && name.Length >= 2)
                    break;
                Console.WriteLine("Name cannot contain digits and must be at least two characters long");
            }

            string address;
            while (true)
            {
                Console.Write("Enter the address: ");
                address = Console.ReadLine();
                if (address.Length >= 5)
                    break;
                Console.WriteLine("Address must be at least five characters long");
            }

            //обираємо власника зі списку або додаємо нового
            Owner ownerObj;
            while (true)
            {
                Console.WriteLine("Please select the number of the owner or enter 0 to add a new one:");
                for (int i = 0; i < owners.Count; i++)
                    Console.WriteLine($"{i + 1}. {owners[i].Name} {owners[i].Surname}");

                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                {
                    string nameOwn;
                    while (true)
                    {
                        Console.Write("Enter the name: ");
                        nameOwn = Console.ReadLine();
                        if (!nameOwn.Any(char.IsDigit) && nameOwn.Length >= 2)
                            break;
                        Console.WriteLine("Name cannot contain digits and must be at least two characters long");
                    }

                    string surname;
                    while (true)
                    {
                        Console.Write("Enter the surname: ");
                        surname = Console.ReadLine();
                        if (!surname.Any(char.IsDigit) && surname.Length >= 2)
                            break;
                        Console.WriteLine("Surname cannot contain digits and must be at least two characters long");
                    }

                    int age;
                    while (true)
                    {
                        Console.Write("Enter the age: ");
                        string ageInput = Console.ReadLine();
                        if (Int32.TryParse(ageInput, out age) && age >= 0)
                            break;
                        Console.WriteLine("Age must be a non-negative integer");
                    }

                    Owner newOwner = new Owner(nameOwn, surname, age);
                    owners.Add(newOwner);
                    Console.WriteLine("Owner was added");
                    ownerObj = newOwner;
                    break;
                }
                else if (input > 0 && input <= owners.Count)
                {
                    ownerObj = owners[input - 1];
                    break;
                }
                else
                    Console.WriteLine("Invalid input. Please try again.");
            }

            //вивід доступних арт об'єктів які можна додати до галереї/музею
            Console.WriteLine("Select art objects:");
            for (int i = 0; i < artObjects.Count; i++)
            {
                if (!artObjects[i].IsInVenue)
                    Console.WriteLine($"{i + 1}. {artObjects[i].Name}");
            }
            
            //вибір та додання робіт до нового об'єкту
            while (true)
            {
                Console.Write("Enter the number of the art object or 'q' to finish: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                    break;

                int index;
                if (int.TryParse(input, out index) && index > 0 && index <= artObjects.Count && !artObjects[index - 1].IsInVenue)
                {
                    artworks.Add(artObjects[index - 1]);
                    artObjects[index - 1].IsInVenue = true;
                }
                else
                    Console.WriteLine("Invalid choice, please try again");
            }

            bool isMuseum;
            while (true)
            {
                Console.Write("Is it a museum? (y/n): ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    isMuseum = true;
                    break;
                }
                else if (input == "n")
                {
                    isMuseum = false;
                    break;
                }
                else
                    Console.WriteLine("Invalid choice, please try again");
            }

            venues.Add(ownerObj.AddPlace(name, address, ownerObj, artworks, isMuseum));
            Console.WriteLine("Place was added");
        }

        //метод для генерації нового місця проведення
        public static void AddRandomPlaces(int numberOfPlaces)
        {
            Random random = new Random();
            string[] names = { "NameOne", "NameTwo", "NameThree", "NameFour", "NameFive" };
            string[] addresses = { "StreetOne No.12", "AvenueTwo No.34", "RoadThree No.56", "LaneFour No.78", "WayFive No.90" };
            string[] ownerNames = { "OwnerNameOne", "OwnerNameTwo", "OwnerNameThree", "OwnerNameFour", "OwnerNameFive" };
            string[] ownerSurnames = { "OwnerSurnameOne", "OwnerSurnameTwo", "OwnerSurnameThree", "OwnerSurnameFour", "OwnerSurnameFive" };

            for (int i = 0; i < numberOfPlaces; i++)
            {
                List<ArtObject> artworks = new List<ArtObject>();
                string name = names[random.Next(names.Length)];
                string address = addresses[random.Next(addresses.Length)];
                string ownerName = ownerNames[random.Next(ownerNames.Length)];
                string ownerSurname = ownerSurnames[random.Next(ownerSurnames.Length)];

                Owner ownerObj = owners.FirstOrDefault(o => o.Name == ownerName && o.Surname == ownerSurname);

                if (ownerObj == null)
                {
                    int ownerAge = random.Next(20, 60);
                    ownerObj = new Owner(ownerName, ownerSurname, ownerAge);
                    owners.Add(ownerObj);
                }

                for (int j = 0; j < artObjects.Count; j++)
                {
                    if (!artObjects[j].IsInVenue && random.NextDouble() < 0.5) //50% шанс додати кожен об'єкт
                    {
                        artworks.Add(artObjects[j]);
                        artObjects[j].IsInVenue = true;
                    }
                }

                bool isMuseum = random.NextDouble() < 0.5; // 50% шанс бути музеєм

                venues.Add(ownerObj.AddPlace(name, address, ownerObj, artworks, isMuseum));
            }
            Console.WriteLine("Places was added");
        }

        //метод для додавання арт об'єктів до вже існуючого місця проведення
        public static void AddMoreArtObject()
        {
            // Виведення списку місць проведення
            Console.WriteLine("Select a venue:");
            for (int i = 0; i < venues.Count; i++)
                Console.WriteLine($"{i + 1}. {venues[i].Name}");

            IPresentable selectedVenue = null;
            //обрання музею/галереї
            while (selectedVenue == null)
            {
                int venueIndex;
                if (int.TryParse(Console.ReadLine(), out venueIndex) && venueIndex > 0 && venueIndex <= venues.Count)
                    selectedVenue = venues[venueIndex - 1];
                else
                    Console.WriteLine("Invalid choice, please try again");
            }

            //вивід доступних арт об'єктів які можна додати до галереї/музею
            Console.WriteLine("Select an art object:");
            for (int i = 0; i < artObjects.Count; i++)
            {
                if (!artObjects[i].IsInVenue)
                    Console.WriteLine($"{i + 1}. {artObjects[i].Name}");
            }

            //вибір та додання робіт
            while (true)
            {
                Console.Write("Enter the number of the art object or 'q' to finish: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                    break;

                int index;
                if (int.TryParse(input, out index) && index > 0 && index <= artObjects.Count && !artObjects[index - 1].IsInVenue)
                {
                    selectedVenue.AddArtwork(artObjects[index - 1]);
                    Console.WriteLine("Artwork was added");
                }
                else
                    Console.WriteLine("Invalid choice, please try again");
            }
        }

        ////метод для додавання виставки
        public static void AddExhibition()
        {
            //обрання куратора або додання нового
            Curator selectedCurator;
            while (true)
            {
                Console.WriteLine("Please select the number of the curator or enter 0 to add a new one:");
                for (int i = 0; i < curators.Count; i++)
                    Console.WriteLine($"{i + 1}. {curators[i].Name}");

                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                {
                    string name;
                    while (true)
                    {
                        Console.Write("Enter the name: ");
                        name = Console.ReadLine();
                        if (!name.Any(char.IsDigit) && name.Length >= 2)
                            break;
                        Console.WriteLine("Name cannot contain digits and must be at least two characters long");
                    }

                    string surname;
                    while (true)
                    {
                        Console.Write("Enter the surname: ");
                        surname = Console.ReadLine();
                        if (!surname.Any(char.IsDigit) && surname.Length >= 2)
                            break;
                        Console.WriteLine("Surname cannot contain digits and must be at least two characters long");
                    }

                    int age;
                    while (true)
                    {
                        Console.Write("Enter the age: ");
                        string ageInput = Console.ReadLine();
                        if (Int32.TryParse(ageInput, out age) && age >= 0)
                            break;
                        Console.WriteLine("Age must be a non-negative integer");
                    }

                    Curator newCurator = new Curator(name, surname, age);
                    curators.Add(newCurator);
                    selectedCurator = newCurator;
                    break;
                }
                else if (input > 0 && input <= curators.Count)
                {
                    selectedCurator = curators[input - 1];
                    break;
                }
                else
                    Console.WriteLine("Invalid input. Please try again.");
            }

            //обрання місця проведення
            IPresentable selectedPlace;
            while (true)
            {
                Console.WriteLine("Please select the number of the place:");
                for (int i = 0; i < venues.Count; i++)
                    Console.WriteLine($"{i + 1}. {venues[i].Name}");

                int input = Convert.ToInt32(Console.ReadLine());
                if (input > 0 && input <= venues.Count)
                {
                    selectedPlace = venues[input - 1];
                    break;
                }
                else
                    Console.WriteLine("Invalid input. Please try again.");
            }

            Console.WriteLine("Please enter the name of the exhibition:");
            string nameEx = Console.ReadLine();

            DateTime startDate, endDate;
            while (true)
            {
                Console.WriteLine("Please enter the start date of the exhibition (yyyy-mm-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out startDate))
                {
                    Console.WriteLine("Please enter the end date of the exhibition (yyyy-mm-dd):");
                    if (DateTime.TryParse(Console.ReadLine(), out endDate) && endDate >= startDate)
                        break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }

            exhibitions.Add(selectedCurator.AddExhibition(nameEx, startDate, endDate, selectedPlace, null));
            Console.WriteLine("Exhibition was added");
        }

        //метод для генерації виставки
        public static void GenerateExhibitions(int numberOfExhibitions)
        {
            Random random = new Random();
            string[] names = { "John", "Jane", "Bob", "Alice", "Tom", "Emma" };
            string[] surnames = { "Smith", "Johnson", "Brown", "Taylor", "Anderson", "Thomas" };
            string[] exhibitionNames = { "Art of the Ages", "Modern Masterpieces", "Cultural Heritage", "Historical Artifacts", "Contemporary Creations", "Timeless Treasures" };

            for (int i = 0; i < numberOfExhibitions; i++)
            {
                //генерує куратора
                string name = names[random.Next(names.Length)];
                string surname = surnames[random.Next(surnames.Length)];
                int age = random.Next(25, 50);
                Curator curator = new Curator(name, surname, age);
                curators.Add(curator);

                //генерує місце
                IPresentable place = venues[random.Next(venues.Count)];

                //генерує виставку
                string exhibitionName = exhibitionNames[random.Next(exhibitionNames.Length)];
                DateTime startDate = DateTime.Today.AddDays(random.Next(-365, 365));
                DateTime endDate = startDate.AddDays(random.Next(1, 30));

                Exhibition exhibition = curator.AddExhibition(exhibitionName, startDate, endDate, place, null);
                exhibitions.Add(exhibition);
            }

            Console.WriteLine("Exhibitions was added");
        }

        //метод для зручного обрання модифікації виставки
        public static void ModifyExhibition()
        {
            while (true)
            {
                // Виведення списку виставок
                Console.WriteLine("Select exhibition:");
                for (int i = 0; i < exhibitions.Count; i++)
                    Console.WriteLine($"{i + 1}. {exhibitions[i].Name}");

                // Вибір виставки
                Exhibition selectedExhibition = null;
                while (selectedExhibition == null)
                {
                    int exhibitionIndex;
                    if (int.TryParse(Console.ReadLine(), out exhibitionIndex) && exhibitionIndex > 0 && exhibitionIndex <= exhibitions.Count)
                        selectedExhibition = exhibitions[exhibitionIndex - 1];
                    else
                        Console.WriteLine("Invalid choice, please try again");
                }

                // Запит, що змінити
                Console.WriteLine("Select an option:\n1. Add artwork to the exhibition\n2. Change exhibition date");

                // Вибір опції
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddArtworkToExhibition(selectedExhibition);
                        return;
                    case "2":
                        ChangeDataExhebition(selectedExhibition);
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        break;
                }
            }
        }

        //метод для додавання арт об'єктів до вже існуючої виставки
        public static void AddArtworkToExhibition(Exhibition selectedExhibition)
        {
            // Виведення списку доступних арт-об'єктів, які можна додати до виставки
            Console.WriteLine("Select an art object:");
            List<ArtObject> availableArtObjects = artObjects.Where(a => !a.IsInVenue).ToList();
            for (int i = 0; i < availableArtObjects.Count; i++)
                Console.WriteLine($"{i + 1}. {availableArtObjects[i].Name}");

            // Вибір та додавання арт-об'єктів
            while (true)
            {
                Console.Write("Enter the number of the art object or 'q' to finish: ");
                string input = Console.ReadLine();
                while (true)
                {
                    if (input.ToLower() == "q")
                        return;

                    int index;
                    if (int.TryParse(input, out index) && index > 0 && index <= availableArtObjects.Count)
                    {
                        selectedExhibition.AddArtObject(availableArtObjects[index - 1]);
                        Console.WriteLine("Artwork was added");
                        break;
                    }
                    else
                        Console.WriteLine("Invalid choice, please try again");
                }
            }
        }

        //метод для зміни дати проведення виставки
        public static void ChangeDataExhebition(Exhibition selectedExhibition)
        {
            // Запит нової дати
            DateTime newStartDate, newEndDate;
            while (true)
            {
                Console.Write("Enter the new start date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out newStartDate))
                    break;
                Console.WriteLine("Invalid date, please try again");
            }
            while (true)
            {
                Console.Write("Enter the new end date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out newEndDate) && newEndDate >= newStartDate)
                    break;
                Console.WriteLine("Invalid date or end date is earlier than start date, please try again");
            }

            // Зміна дати
            if (selectedExhibition.ChangeDate(newStartDate, newEndDate))
                Console.WriteLine("Exhibition date successfully changed");
            else
                Console.WriteLine("An error occurred while changing the date");
        }
    }
}