using Assessment.Services;

namespace Assessment;

public class Program
{
   public static void Main(string[] args)
   {
       Console.WriteLine("Please provide input:");
       Console.WriteLine("ex. (id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)");
       var input = Console.ReadLine();

       if (string.IsNullOrEmpty(input))
       {
           Console.WriteLine("Using example input");
           input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
       }

       Console.WriteLine("Input: " + input);

       var parseDataService = new ParseDataService();
       var data = parseDataService.ExtractData(input);

       Console.WriteLine();
       Console.WriteLine("Output 1:");
       Console.WriteLine("=================");
       PrintData(data, 0);

       data = data.OrderBy(d => d.Name).ToList();
       foreach (var d in data)
       {
           d.Sort();
       }

       Console.WriteLine();
       Console.WriteLine("Output 2:");
       Console.WriteLine("=================");
       PrintData(data, 0);

       Console.WriteLine();
       Console.WriteLine("Press any key to exit.");
       Console.ReadLine();
   }

   public static void PrintData(List<InputData> data, int spaceIndentation)
   {
       var indentation = new string(' ', spaceIndentation);
       foreach (var d in data)
       {
           Console.WriteLine($"{indentation}{d}");
           PrintData(d.Data, spaceIndentation+2);
       }
   }
}
