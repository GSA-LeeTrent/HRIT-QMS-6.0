namespace Qms_Web.Models
{
    public class TelerikChartModel
    {
    }
}
public class TelerikChartModel
{
    public TelerikChartModel(int id, string key, int value)
    {
        Id = id;
        Key = key;
        Value = value;
    }

    public TelerikChartModel(int id, string key, int val1, int val2, int val3)
    {
        Id = id;
        Key = key;
        Value = val1;
        ValueTwo = val2;
        ValueThree = val3;
    }

    public int Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public int Value { get; set; }
    public int ValueTwo { get; set; }
    public int ValueThree { get; set; }
}