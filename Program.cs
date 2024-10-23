// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

List<Plant> plants = new List<Plant>()
{
    new Plant()
            {
                Species = "Aloe Vera",
                LightNeeds = 4,
                AskingPrice = 15.99m,
                City = "Phoenix",
                ZIP = 85001,
                Sold = false
            },
            new Plant()
            {
                Species = "Snake Plant",
                LightNeeds = 2,
                AskingPrice = 25.50m,
                City = "Los Angeles",
                ZIP = 90001,
                Sold = true
            },
            new Plant()
            {
                Species = "Spider Plant",
                LightNeeds = 3,
                AskingPrice = 12.00m,
                City = "Austin",
                ZIP = 73301,
                Sold = false
            },
            new Plant()
            {
                Species = "Peace Lily",
                LightNeeds = 1,
                AskingPrice = 18.75m,
                City = "Chicago",
                ZIP = 60007,
                Sold = true
            },
            new Plant()
            {
                Species = "Fiddle Leaf Fig",
                LightNeeds = 5,
                AskingPrice = 45.00m,
                City = "New York",
                ZIP = 10001,
                Sold = false
            },
            new Plant()
            {
                Species = "Monstera",
                LightNeeds = 3,
                AskingPrice = 30.00m,
                City = "San Francisco",
                ZIP = 94101,
                Sold = true
            },
            new Plant()
            {
                Species = "Cactus",
                LightNeeds = 5,
                AskingPrice = 10.99m,
                City = "Tucson",
                ZIP = 85701,
                Sold = false
            },
            new Plant()
            {
                Species = "Bamboo",
                LightNeeds = 2,
                AskingPrice = 22.50m,
                City = "Miami",
                ZIP = 33101,
                Sold = false
            },
            new Plant()
            {
                Species = "Orchid",
                LightNeeds = 4,
                AskingPrice = 35.25m,
                City = "Houston",
                ZIP = 77001,
                Sold = true
            },
            new Plant()
            {
                Species = "ZZ Plant",
                LightNeeds = 1,
                AskingPrice = 28.99m,
                City = "Denver",
                ZIP = 80201,
                Sold = false
            }
};

Console.WriteLine("Hi! Welcome to ExtraVert. Check out all of our Plants!");

string choice = null;
while (choice != "z")
{
    Console.Clear();
    Console.WriteLine(@"Choose an option:
    a. Display all plants
    b. Post a plant to be adopted
    c. Adopt a plant
    d. Delist a plant
    z. Exit");

    choice = Console.ReadLine();
    if (choice == "a")
    {
        Console.Clear();
        ListProducts();
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    else if (choice == "b")
    {
        Console.Clear();
        AddPlant();
    }
    else if (choice == "c")
    {
        Console.Clear();
        AdoptAPlant();
    }
    else if (choice == "d")
    {
        Console.Clear();
        throw new NotImplementedException("Delist a plant");
    }
    else if (choice == "z")
    {
        Console.Clear();
        Console.WriteLine("Sorry to see you go :( Goodbye!");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Oops this is not an option. Try again.");
    }
}

void ListProducts()
{
    foreach (Plant plant in plants)
    {
        Console.WriteLine($"{plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for {plant.AskingPrice}");
    }
};

void AddPlant()
{
    bool Sold = false;

    Console.WriteLine("What species is the plant?");
    string Species = Console.ReadLine();

    Console.WriteLine(Species);

    Console.WriteLine("On a scale of 1-5 how much light does this plant need?");
    int LightNeeds = int.Parse(Console.ReadLine());

    Console.WriteLine(LightNeeds);

    Console.WriteLine("How much do you want to sell it for?");
    decimal AskingPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine(AskingPrice);

    Console.WriteLine("What city do you live in?");
    string City = Console.ReadLine();

    Console.WriteLine(City);

    Console.WriteLine("Enter ZipCode?");
    int ZIP = int.Parse(Console.ReadLine());

    Console.WriteLine(ZIP);

    Plant newPlant = new Plant()
    {
        Species = Species,
        LightNeeds = LightNeeds,
        AskingPrice = AskingPrice,
        City = City,
        ZIP = ZIP,
        Sold = Sold
    };

    plants.Add(newPlant);

    Console.WriteLine($"Added: {newPlant.Species} in {newPlant.City}.");
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

void AdoptAPlant()
{
    Plant chosenPlant = null;

    while (chosenPlant == null)

    {
        Console.WriteLine("Choose a plant to Adopt:");
        for (int i = 0; i < plants.Count; i++)
        {
            if (!plants[i].Sold)
            {
                Console.WriteLine($"{i + 1}. {plants[i].Species}");
            }
        }

        Console.WriteLine("Select the number of the plant you would like to adopt.");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = plants[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }

        Console.WriteLine($"You chose: {chosenPlant.Species}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

}

