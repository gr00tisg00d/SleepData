// ask for input
using System.Data;

Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data file.");
Console.WriteLine("Enter anything else to quit.");

// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file.
    // ask question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # weeks from endDate to get startDate
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
            // generate random number between 4 & 12 inclusive
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        sw.WriteLine($"{dataDate:M/d/yyyy}, {string.Join("|", hours)}"); // delimited data
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file.
}
