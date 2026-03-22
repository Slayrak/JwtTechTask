using JwtTechTask.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace JwtTechTask;
public static class JwtDeserializer
{
    public static List<User> Deserialize(string? token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return [];
        }

        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);

        if (jsonToken.Payload.TryGetValue("data", out object? result) && !string.IsNullOrWhiteSpace(result.ToString()))
        {
            return JsonSerializer.Deserialize<List<User>>(result.ToString()!, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
        }

        return [];
    }
}
