namespace Assessment.Services;

public class ParseDataService
{
    public List<InputData> ExtractData(string input)
    {
        var list = new List<InputData>();
        var current = "";
        
        input = input.GetStringBetweenIndexes(input.IndexOf('(')+1, input.LastIndexOf(')')).Trim();
        
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == ',')
            {
                if(string.IsNullOrEmpty(current)) continue;

                list.Add(new InputData { Name = current.Trim() });
                current = "";
            }
            else if(input[i] == '(')
            {
                list.Add(new InputData { Name = current.Trim() });
                list.Last().Data = ExtractData(input.Substring(i));
                i = input.LastIndexOf(')');
                current = "";
            }
            else
            {
                current += input[i];
            }
        }

        if(!string.IsNullOrEmpty(current))
        {
            list.Add(new InputData { Name = current.Trim() });
        }
        return list;
    }
}
