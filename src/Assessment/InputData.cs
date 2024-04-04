namespace Assessment;

public class InputData
{
    public InputData()
    {
        Data = new List<InputData>();
    }
  
    public string Name { get; set; }
    public List<InputData> Data { get; set; }

    public void Sort()
    {
        Data = Data.OrderBy(d => d.Name).ToList();
        foreach (var d in Data)
        {
            d.Sort();
        }
    }

    public override string ToString()
    {
        return $"- {Name}";
    }
}
