using System.Text.Json;
using System.Text.Json.Serialization;

public class GoalConverter : JsonConverter<Goal>
{
    public override Goal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        string type = root.GetProperty("GoalType").GetString();
        var goalData = root.GetProperty("GoalData").GetRawText();

        return type switch
        {
            "SimpleGoal" => JsonSerializer.Deserialize<SimpleGoal>(goalData, options),
            "EternalGoal" => JsonSerializer.Deserialize<EternalGoal>(goalData, options),
            "ChecklistGoal" => JsonSerializer.Deserialize<ChecklistGoal>(goalData, options),
            _ => throw new NotSupportedException($"Unknown goal type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
    {
        var type = value.GetType().Name;
        writer.WriteStartObject();
        writer.WriteString("GoalType", type);
        writer.WritePropertyName("GoalData");
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
        writer.WriteEndObject();
    }
}
