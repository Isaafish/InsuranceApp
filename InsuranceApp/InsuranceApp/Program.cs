//imports

using System.Text.RegularExpressions;

namespace InsuranceApp;
class Program
{
    //globel veriables


    //methods and functions

    static float CheckFloat(string question, float min, float max)
    {

        while (true)
        {
            try
            {
                Console.WriteLine(question);

                float userfloat = (float)Convert.ToDecimal(Console.ReadLine());

                if (userfloat >= min && userfloat <= max)
                {
                    return userfloat;

                }

                DisplayErrorMessage($"ERROR: You must enter an number between {min} and {max}");
            }
            catch
            {
                DisplayErrorMessage($"ERROR: You must enter an number between {min} and {max}");
            }
        }
    }

    static int Checkint(string question, int min, int max)
    {

        while (true)
        {
            try
            {
                Console.WriteLine(question);

                int userint = (int)Convert.ToDecimal(Console.ReadLine());

                if (userint >= min && userint <= max)
                {
                    return userint;

                }

                DisplayErrorMessage($"ERROR: You must enter an number between {min} and {max}");
            }
            catch
            {
                DisplayErrorMessage($"ERROR: You must enter an number between {min} and {max}");

            }

        }


    }

    static string CalculateDepreciation(float cost)
    {
        string depreciation = "month\tvalue lost\n";

        for (int month = 1; month < 7; month++)
        {
            cost = cost * 0.95f;
            cost = (float)Math.Round(cost, 2);

            depreciation += $"{month}\t{cost}\n";
        }

        return depreciation;

    }

    static string CheckProcced()
    {
        while (true)
        {
            Console.WriteLine("Press <ENTER> to add another device or press 'x' to exit");

            string checkProceed = Console.ReadLine();
            checkProceed = checkProceed.ToUpper();

            if (checkProceed.Equals("") || checkProceed.Equals("X"))
            {


                return checkProceed;
            }
            DisplayErrorMessage("ERROR Invalid choice,Press <ENTER> to add another device or press 'x' to exit ");


        }
    }


    static void DisplayErrorMessage(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
        Console.ForegroundColor = ConsoleColor.Black;
    }


 static string CheckName()
{
    while (true)
    {
        Console.WriteLine("Enter the device brand name");

        string name = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z0-100]+$"))
        {
            name = name.ToUpper();

            return name;
        }
        DisplayErrorMessage("ERROR: You must enter a name");


    }
}


//the ID

static string GenerateID(string deviceName, string category, int deviceCounter)
    {
        int charCountDeviceName = 3;
        int charCountCatorgory = 1;

        if (deviceName.Length < 3)
        {
            charCountDeviceName = deviceName.Length;
        }

        if (category.Length < 1)
        {
            charCountCatorgory = category.Length;
        }


        string id = (deviceName.Substring(0, charCountDeviceName) + category.Substring(0, charCountCatorgory)).ToUpper() + deviceCounter;

        return id;
    }
    static void oneDevice()
    {

        //Enter category
        List<string> math = new List<string>() { "Laptop", "Phone", "Desktop", "Other" };
        String menu = "Choose a category:\n";

        for (int index = 0; index < math.Count; index++)
        {
            menu += $"{index + 1}. {math[index]}\n";
        }

        int category = Checkint(menu, 1, 4);

        //Enter device name
        string deviceName = CheckName();


        //Enter amount of devices
        int deviceQuantity = Checkint("Enter the number of device(s)", 1, 1000);


        //Enter cost of device
        float deviceCost = CheckFloat("Enter the individual device cost", 1, 10000);


        float insuranceCost = 0;
        //Calculate Insurance
        if (deviceQuantity>5)
        {
            insuranceCost += 5 * deviceCost;
            insuranceCost += (deviceQuantity - 5) * deviceCost * 0.9f;
        }
        else
        {
            insuranceCost += deviceQuantity * deviceCost;
        }

        Console.WriteLine($"Total cost of device {insuranceCost}");

        Console.WriteLine(CalculateDepreciation(deviceCost));
    }

    //main precess or when run...



    static void Main(string[] args)
    {
        //Display app title
        Console.WriteLine("---Welcome To The Insurance App---\n");

        //call oneDevice()
        string proceed = "";
        while (proceed.Equals(""))
        {
            oneDevice();
            Console.WriteLine();
            proceed = CheckProcced();
        }



        //check if a person needs to calculate another Device
        
        //if true repeat step two

        //if false show results

    }
}