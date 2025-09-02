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
    Console.WriteLine(dataDate);
}
else if (resp == "2")
{
    // TODO: parse data file.
}
