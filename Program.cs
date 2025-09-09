// ask for input
﻿using NLog;
string path = Directory.GetCurrentDirectory() + "//nlog.config";
// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();

// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    if (int.TryParse(Console.ReadLine(), out int weeks)){
        // determine start and end date
        DateTime today = DateTime.Now;
        // we want full weeks sunday - saturday
        DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
        // subtract # of weeks from endDate to get startDate
        DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
        // random number generator
        Random rnd = new();
        // create file
        StreamWriter sw = new("data.txt");

        // loop for the desired # of weeks
        while (dataDate < dataEndDate)
        {
            // 7 days in a week
            int[] hours = new int[7];
            for (int i = 0; i < hours.Length; i++)
            {
                // generate random number of hours slept between 4-12 (inclusive)
                hours[i] = rnd.Next(4, 13);
            }
            // M/d/yyyy,#|#|#|#|#|#|#
            // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
            sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
            // add 1 week to date
            dataDate = dataDate.AddDays(7);
        }
        sw.Close();
    } else {
        // log error
        logger.Error("You must enter a valid number");
    }
}
else if (resp == "2")
{
    if (File.Exists("data.txt"))
    {
        string[] lines = File.ReadAllLines("data.txt");
        
        foreach (string line in lines)
        {
            if (line != null && line.Length > 0)
            {
                string[] parts = line.Split(',');
                string dateStr = parts[0];
                string hoursStr = parts[1];

                //Reads all lines from the file
                //For each line, split it at the comma to separate date from sleep hours

                DateTime weekDate = DateTime.Parse(dateStr);

                string[] hourStrings = hoursStr.Split('|');
                int[] hours = new int[7];

                for (int i = 0; i < hourStrings.Length && i < 7; i++)
                {
                    hours[i] = int.Parse(hourStrings[i]);
                }

                //Splits the hours string at the pipe character '|'.
                //Converts each hour string to an integer
                //Stores in an array (one element per day).

                int total = hours.Sum();
                double average = total / 7.0;

                //Calculates total sleep hours for the week
                //Calculates average sleep hours per night

                Console.WriteLine($"Week of {weekDate:MMM, dd, yyyy}");
                Console.WriteLine(" Su Mo Tu We Th Fr Sa Tot Avg");
                Console.WriteLine(" -- -- -- -- -- -- -- --- ---");
                Console.WriteLine($"{hours[0],3}{hours[1],3}{hours[2],3}{hours[3],3}{hours[4],3}{hours[5],3}{hours[6],3}{total,4} {average:F1}");
                Console.WriteLine();
                
            }
        }
    }
    else
    {
        Console.WriteLine("File not found.");
    }
}
