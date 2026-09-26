using System.Globalization;
using System.Text;
using BenchmarkDotNet.Running;
using AcademyScheduleAnalyzer.Benchmarks;
namespace AcademyScheduleAnalyzer;

internal class Program
{
    public static void NewLine()
    {
        Console.WriteLine();
    }
    public static void DisplaySessionDetials(int indx, string[] sessionNames, DateTime[] sessionDates, int[] sessionDuration)
    {
        Console.WriteLine($"{indx + 1}. {sessionNames[indx]}");
        Console.WriteLine($"Date: {sessionDates[indx].Day} {sessionDates[indx].Month} {sessionDates[indx].Year}");
        Console.WriteLine($"Start Time: {sessionDates[indx].ToString("hh:mm tt")}");
        Console.WriteLine($"Duration: {sessionDuration[indx]}");
        NewLine();
    }
    public static void DisplaySessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDuration)
    {
        for (int i = 0; i < sessionNames.Length; i++)
        {
            DisplaySessionDetials(i, sessionNames, sessionDates, sessionDuration);
        }
    }
    public static void SearchBySession(string sessionName, string[] sessionNames, DateTime[] sessionDates, int[] sessionDuration)
    {
        int sessionIndex = Array.IndexOf(sessionNames, sessionName);
        if (sessionIndex == -1)
        {
            Console.WriteLine("Session not found");
        }
        else
        {
            DisplaySessionDetials(sessionIndex, sessionNames, sessionDates, sessionDuration);
        }

    }

    public static DateTime GetSessionEndTime(DateTime startTime, int duration)
    {
        return startTime.AddMinutes(duration);
    }


    public static DateTime ReadSessionDate(string? input, out bool check)
    {
        DateTime convertDate;
        check = DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out convertDate);
        return convertDate;
    }

    public static double TotalDuration(int[] sessionDuration)
    {
        double total = 0.0;
        foreach (int time in sessionDuration)
        {
            total += time;
        }
        return total;
    }

    public static string BuildReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        string report = "";

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report += $"Session {i + 1}: {sessionNames[i]}\n";
            report += $"Date: {sessionDates[i]:yyyy-MM-dd HH:mm}\n";
            report += $"Duration: {sessionDurations[i]} mins\n";
            report += "-----------------------------------\n";
        }

        return report;
    }

    public static string BuildReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < sessionNames.Length; i++)
        {
            sb.AppendLine($"Session {i + 1}: {sessionNames[i]}");
            sb.AppendLine($"Date: {sessionDates[i]:yyyy-MM-dd HH:mm}");
            sb.AppendLine($"Duration: {sessionDurations[i]} mins");
            sb.AppendLine("-----------------------------------");
        }

        return sb.ToString();
    }

    public static double AverageDuration(int[] sessionDuration)
    {
        double totDuration = TotalDuration(sessionDuration);
        int numberOfSessions = sessionDuration.Length;
        return (totDuration / numberOfSessions);
    }
    public static int LongestDuration(int[] sessionDuration)
    {
        int longest = 0;
        foreach (int time in sessionDuration)
        {
            if (longest < time)
            {
                longest = time;
            }
        }
        return longest;
    }

    public static int ShortestDuration(int[] sessionDuration)
    {
        int shortest = 10000000;
        foreach (int time in sessionDuration)
        {
            if (shortest > time)
            {
                shortest = time;
            }
        }
        return shortest;
    }

    public static void TestRef(ref int num)
    {
        num += 5;
    }


    public static void TestOut(string[] sessionNames, int[] sessionDurations, string? sessionName, out int sessionIndex, out int sessionDuration)
    {
        sessionIndex = Array.IndexOf(sessionNames, sessionName);
        sessionDuration = sessionDurations[sessionIndex];
    }

    public static void ChangesOnArray(int[] array)
    {
        array[0] = -1;
    }

    public static int CalculateDurationByParams(params int[] durations)
    {
        int total = 0;
        foreach (int dur in durations)
        {
            total += dur;
        }
        return total;
    }
    public static void GetSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDuration, string? name)
    {
        int indexx = Array.IndexOf(sessionNames, name);
        if (indexx != -1)
        {
            Console.WriteLine($"Date :{sessionDates[indexx].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)} ");
            Console.WriteLine($"Day : {sessionDates[indexx].DayOfWeek}");
            Console.WriteLine($"Year : {sessionDates[indexx].Year}");
            Console.WriteLine($"Month : {sessionDates[indexx].Month}");
            Console.WriteLine($"Start Time : {sessionDates[indexx].ToString("hh:mm tt")}");
            Console.WriteLine($"");
            Console.WriteLine($"Duration : {sessionDuration[indexx]}");
            Console.WriteLine($"End Time : {GetSessionEndTime(sessionDates[indexx], sessionDuration[indexx]).ToString("hh MM tt")}");

        }
    }

    public static DateTime CheckValidationDate(string? date, out bool check)
    {
        DateTime checkDate;
        check = DateTime.TryParseExact(date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out checkDate);

        return checkDate;
    }
    public static void ValidateDuration(int duration)
    {
        if (duration < 0)
            throw new ArgumentException("Duration must be greater than zero.");

        Console.WriteLine("Duration Accepted");
    }


    public static string GenerateScheduleReport(string[] sessionNames, DateTime[] sessionDates, int[] sessionDuration)
    {
        string report = "";

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report += $"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDuration[i]} minutes\n";
        }

        return report;
    }


    public static StringBuilder GenerateScheduleReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDuration)
    {
        StringBuilder report = new StringBuilder();

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report.AppendLine($"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDuration[i]} minutes");
        }

        return report;
    }
    public static void Main(string[] args)
    {
        // part-1
        string[] sessionNames =
        {
            "C# Basics",
            "Arrays",
            "Functions",
            "Date and Time",
            "Exception Handling"
        };
        DateTime[] sessionDates =
        {
            new DateTime(2026, 9, 10, 18, 0, 0),
            new DateTime(2026, 9, 13, 18, 0, 0),
            new DateTime(2026, 9, 17, 18, 0, 0),
            new DateTime(2026, 9, 20, 18, 0, 0),
            new DateTime(2026, 9, 24, 18, 0, 0)
        };
        int[] sessionDuration = {
              180,
              240,
              180,
              240,
              180
        };


        //part-2
        //DisplaySessions(sessionNames, sessionDates, sessionDuration);


        //part-3
        SearchBySession("Arrays", sessionNames, sessionDates, sessionDuration);


        //part-4.1
        string[] sessionNamesSorted = new string[sessionNames.Length];
        Array.Copy(sessionNames, sessionNamesSorted, sessionNames.Length);
        Array.Sort(sessionNamesSorted);
        foreach (string session in sessionNamesSorted)
        {
            Console.WriteLine(session);
        }

        //part-4.2
        NewLine();
        string[] sessionNamesReversed = new string[sessionNames.Length];
        Array.Copy(sessionNames, sessionNamesReversed, sessionNames.Length);
        Array.Reverse(sessionNamesReversed);
        foreach (string session in sessionNamesReversed)
        {
            Console.WriteLine(session);
        }

        //part-4.3
        NewLine();
        Console.WriteLine(" Enter session name : ");
        string? sessionName = Console.ReadLine();
        int indx = Array.IndexOf(sessionNames, sessionName);
        if (string.IsNullOrEmpty(sessionName) || string.IsNullOrWhiteSpace(sessionName) || indx == -1)
        {
            Console.WriteLine("Session not found");
        }
        else
        {
            Console.WriteLine($"session Index : {indx}");
        }


        //part-4.4
        NewLine();
        string sessionExist = "Arrayss";
        bool ok = Array.Exists(sessionNames, session => session == sessionExist);
        Console.WriteLine(ok ? "Session exists" : "Session does not exist");


        //part-4.5
        NewLine();
        string Name1 = "Functions";
        string Name2 = "Functionsss";
        string? retValue = Array.Find(sessionNames, session => session == Name1); // Correct value
        Console.WriteLine($"returned value : {retValue}");
        retValue = Array.Find(sessionNames, session => session == Name2); // Incorrect value
        Console.WriteLine($"returned value : {retValue}");


        //part-4.6
        NewLine();
        // reuse Name1 & Name2 in previvous part-->(4.5)
        int index = Array.FindIndex(sessionNames, session => session == Name1);// Correct value
        Console.WriteLine($"return value : {index}");
        index = Array.FindIndex(sessionNames, session => session == Name2);// Incorrect value
        Console.WriteLine($"return value : {index}");





        //part-4.7
        NewLine();

        string[] copiedArray = new string[sessionNames.Length];
        Array.Copy(sessionNames, copiedArray, sessionNames.Length);

        foreach (string? session in sessionNames) // original array 
        {
            Console.WriteLine(session);
        }
        NewLine();

        foreach (string? session in copiedArray) // copied array 
        {
            Console.WriteLine(session);
        }





        // Part-5
        NewLine();
        Console.WriteLine(TotalDuration(sessionDuration));
        Console.WriteLine(AverageDuration(sessionDuration));
        Console.WriteLine(LongestDuration(sessionDuration));
        Console.WriteLine(ShortestDuration(sessionDuration));

        NewLine();
        int[] sessionDurationCopied = new int[sessionDuration.Length];
        Array.Copy(sessionDuration, sessionDurationCopied, sessionDuration.Length);
        Array.Sort(sessionDurationCopied);

        foreach (int duration in sessionDurationCopied)
        {
            Console.WriteLine(duration);
        }




        // part-6 
        NewLine();
        Console.WriteLine(GetSessionEndTime(sessionDates[0], sessionDuration[0]).ToString("hh mm tt"));

        string? date = Console.ReadLine();

        bool checkDate;

        DateTime result = ReadSessionDate(date, out checkDate);
        if (checkDate is false)
        {
            Console.WriteLine("Invalid Date ");
        }
        else
        {
            Console.WriteLine($"Date : {result}");
        }

        string report1 = BuildReportUsingString(sessionNames, sessionDates, sessionDuration);
        Console.WriteLine(report1);

        string report2 = BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDuration);
        Console.WriteLine(report2);

        //part-7.1
        NewLine();
        int num = 10;
        Console.WriteLine($"Value before calling :  {num}");  // after call function 
        TestRef(ref num);
        Console.WriteLine($"Value after calling :  {num}");

        //part-7.2
        NewLine();
        int sessionDur, sessionIndx;
        Console.WriteLine("Enter  session name : ");
        string? session1 = Console.ReadLine();
        TestOut(sessionNames, sessionDuration, session1, out sessionIndx, out sessionDur);


        // part-7.3
        NewLine();
        int[] values = [150, 5689, 111, 222, 3];
        // we apply changes on index (0) so we print index zero only 
        Console.WriteLine(values[0]); // Before call function
        ChangesOnArray(values);
        Console.WriteLine(values[0]);


        //part-8
        NewLine();

        int totalDuration = CalculateDurationByParams(1, 2, 55, 30);
        Console.WriteLine($"Total duration : {totalDuration}");
        totalDuration = CalculateDurationByParams(200, 250, 180);
        Console.WriteLine($"Total duration : {totalDuration}");
        totalDuration = CalculateDurationByParams(120, 180);
        Console.WriteLine($"Total duration : {totalDuration}");



        //part-9 
        Console.WriteLine("Choose \n 1 - Search session by name \n 2 - Select session from list");
        int.TryParse(Console.ReadLine(), out int choose);
        if (choose is 1)
        {
            string? name = Console.ReadLine();
            GetSession(sessionNames, sessionDates, sessionDuration, name);
        }
        else
        {
            int idx = 1;
            foreach (string session in sessionNames)
            {
                Console.WriteLine($"{idx} - {session}");
            }
            string? name = Console.ReadLine();
            GetSession(sessionNames, sessionDates, sessionDuration, name);
        }


        //part-10
        NewLine();
        string? firstSession = "Arrays", secondSession = "Functions";
        int first = 1, second = 2; // position in array 

        TimeSpan diff = sessionDates[first] - sessionDates[second];
        Console.WriteLine($"Difference : \n{diff.TotalDays} days \n{diff.Hours} hours");



        //part-11 
        NewLine();
        int pos = 0;
        foreach (DateTime datee in sessionDates)
        {
            if (sessionDates[pos] < DateTime.Now)
            {
                Console.WriteLine($"{sessionNames[pos]} Past");
            }
            else
            {
                Console.WriteLine($"{sessionNames[pos]} Upcoming");
            }
        }


        //part-12
        DateTime nearestUpcoming = DateTime.Now;
        bool done = false;
        int nearestIdx = 0;
        for (int i = 0; i < sessionDates.Length; i++)
        {
            if (sessionDates[i] > DateTime.Now)
            {
                if (done is false || sessionDates[i] < nearestUpcoming)
                {
                    nearestUpcoming = sessionDates[i];
                    nearestIdx = i;
                    done = true;
                }

            }
        }

        if (done is true)
        {
            TimeSpan timeRemaining = nearestUpcoming - DateTime.Now;

            Console.WriteLine("Next Session : \n");
            Console.WriteLine(sessionNames[nearestIdx]);
            Console.WriteLine(nearestUpcoming.ToString("dd MMMM yyyy"));
            Console.WriteLine(nearestUpcoming.ToString("hh:mm tt"));

            Console.WriteLine("Time Remaining:");
            Console.WriteLine($"{timeRemaining.Days} days \n {timeRemaining.Hours} hours");
        }
        else
        {
            Console.WriteLine("No upcoming sessions found.");
        }



        //part-13 
        NewLine();
        Console.WriteLine($"{sessionDates[0].ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"{sessionDates[0].ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"{sessionDates[0].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"{sessionDates[0].ToString("dddd, dd MMMM yyyy", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"{sessionDates[0].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");


        //part-14 
        NewLine();
        Console.WriteLine("Enter your date");
        Console.WriteLine($"Date Format : (yyyy-MM-dd HH:mm) .. required");
        string? dates;// = "2026-10-15 18:30";
        while (true)
        {
            dates = Console.ReadLine();
            bool checkDates = false;
            DateTime ret = CheckValidationDate(dates, out checkDates);
            if (checkDates is true) //we can use this also to validate date ret != DateTime.MinValue
            {
                Console.WriteLine(ret.ToString("yyyy-MM-dd HH:mm"));
                break;
            }
            else
            {
                Console.WriteLine("Rejected..invalid date");
            }
        }




        //part-15
        NewLine();

        int option;
        while (true)
        {
            Console.WriteLine("Choose an option !");
            try
            {
                option = int.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid menu option. Enter a number.");
            }
        }



        //part-16
        NewLine();
        int indexSession = 50;
        Random random = new Random(); // insteaad of take an input to test exceptions
        while (true)
        {
            try
            {
                indexSession = random.Next(0, 60);
                string? name = sessionNames[indexSession];
                Console.WriteLine($"session : {name}");
                break;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
            finally // Part-18 <-------------------------------------------------------------look here part-18
            {
                Console.WriteLine("Input operation finished");
            }
        }

        // part-18
        // - (look above)



        //part-19
        NewLine();
        string? report = GenerateScheduleReport(sessionNames, sessionDates, sessionDuration);
        Console.WriteLine(report);


        //part-20
        NewLine();

        StringBuilder reports = GenerateScheduleReportUsingStringBuilder(sessionNames, sessionDates, sessionDuration);
        Console.WriteLine(reports.ToString());

        //part-25
        BenchmarkRunner.Run<StringBenchmark>();

    }
}