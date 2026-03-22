namespace JwtTechTask;

public static class Program
{
    static void Main(string[] args)
    {
        string jwt = "eyJhbGciOiJub25lIn0.eyJkYXRhIjpbeyJ1c2VySWQiOiIxMjM0NSIsInRyYW5zYWN0aW9ucyI6W3siaWQiOiIxIiwiYW1vdW50Ijo1MCwiY3VycmVuY3kiOiJVQUgiLCJtZXRhIjp7InNvdXJjZSI6IkNBQiIsImNvbmZpcm1lZCI6dHJ1ZX0sInN0YXR1cyI6IkNvbXBsZXRlZCJ9LHsiaWQiOiIyIiwiYW1vdW50IjozMC41LCJjdXJyZW5jeSI6IlVBSCIsIm1ldGEiOnsic291cmNlIjoiQUNCIiwiY29uZmlybWVkIjpmYWxzZX0sInN0YXR1cyI6IkluUHJvZ3Jlc3MifSx7ImlkIjoiMyIsImFtb3VudCI6ODkuOTksImN1cnJlbmN5IjoiVUFIIiwibWV0YSI6eyJzb3VyY2UiOiJDQUIiLCJjb25maXJtZWQiOnRydWV9LCJzdGF0dXMiOiJDb21wbGV0ZWQifV19LHsidXNlcklkIjoidTEyMyIsInRyYW5zYWN0aW9ucyI6W3siaWQiOiIxIiwiYW1vdW50Ijo0NDM0LCJjdXJyZW5jeSI6IkVVUiIsIm1ldGEiOnsic291cmNlIjoiQ0FCIiwiY29uZmlybWVkIjp0cnVlfSwic3RhdHVzIjoiQ29tcGxldGVkIn0seyJpZCI6IjIiLCJhbW91bnQiOjU2LjUzLCJjdXJyZW5jeSI6IlVBSCIsIm1ldGEiOnsic291cmNlIjoiQUNCIiwiY29uZmlybWVkIjpmYWxzZX0sInN0YXR1cyI6Mn1dfV19.";

        var users = JwtDeserializer.Deserialize(jwt);

        foreach (var user in users)
        {
            Console.WriteLine($"UserId: {user.UserId}," +
                $" transactions count: {user.Transactions?.Count ?? 0}," +
                $" confirmed: {user.Transactions?.Count(x => x.Meta.Confirmed == true) ?? 0}");
        }
    }
}
