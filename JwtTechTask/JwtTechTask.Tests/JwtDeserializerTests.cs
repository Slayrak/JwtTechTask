namespace JwtTechTask.Tests;

public sealed class JwtDeserializerTests
{
    [Fact]
    public void Deserialize_UsersWithTransactions_ReturnsUsers()
    {
        // Arrange
        var token = "eyJhbGciOiJub25lIn0.eyJkYXRhIjpbeyJ1c2VySWQiOiIxMjM0NSIsInRyYW5zYWN0aW9ucyI6W3siaWQiOiIxIiwiYW1vdW50Ijo1MCwiY3VycmVuY3kiOiJVQUgiLCJtZXRhIjp7InNvdXJjZSI6IkNBQiIsImNvbmZpcm1lZCI6dHJ1ZX0sInN0YXR1cyI6IkNvbXBsZXRlZCJ9LHsiaWQiOiIyIiwiYW1vdW50IjozMC41LCJjdXJyZW5jeSI6IlVBSCIsIm1ldGEiOnsic291cmNlIjoiQUNCIiwiY29uZmlybWVkIjpmYWxzZX0sInN0YXR1cyI6IkluUHJvZ3Jlc3MifSx7ImlkIjoiMyIsImFtb3VudCI6ODkuOTksImN1cnJlbmN5IjoiVUFIIiwibWV0YSI6eyJzb3VyY2UiOiJDQUIiLCJjb25maXJtZWQiOnRydWV9LCJzdGF0dXMiOiJDb21wbGV0ZWQifV19LHsidXNlcklkIjoidTEyMyIsInRyYW5zYWN0aW9ucyI6W3siaWQiOiIxIiwiYW1vdW50Ijo0NDM0LCJjdXJyZW5jeSI6IkVVUiIsIm1ldGEiOnsic291cmNlIjoiQ0FCIiwiY29uZmlybWVkIjp0cnVlfSwic3RhdHVzIjoiQ29tcGxldGVkIn0seyJpZCI6IjIiLCJhbW91bnQiOjU2LjUzLCJjdXJyZW5jeSI6IlVBSCIsIm1ldGEiOnsic291cmNlIjoiQUNCIiwiY29uZmlybWVkIjpmYWxzZX0sInN0YXR1cyI6Mn1dfV19.";

        // Act
        var users = JwtDeserializer.Deserialize(token);
        
        // Assert
        Assert.NotNull(users);
        Assert.Equal(2, users.Count);
        Assert.True(users.TrueForAll(x => x.Transactions?.Count != 0));
    }

    [Fact]
    public void Deserialize_UsersWithoutTransactions_ReturnsUsers()
    {
        // Arrange
        var token = "eyJhbGciOiJub25lIn0.eyJkYXRhIjpbeyJ1c2VySWQiOiIxMjM0NSJ9LHsidXNlcklkIjoidTEyMyJ9XX0.";

        // Act
        var users = JwtDeserializer.Deserialize(token);

        // Assert
        Assert.NotNull(users);
        Assert.Equal(2, users.Count);
        Assert.True(users.TrueForAll(x => x.Transactions == null));
    }

    [Fact]
    public void Deserialize_NoUsers_ReturnsNull()
    {
        // Arrange
        var token = "eyJhbGciOiJub25lIn0.eyJkYXRhMSI6W119.";

        // Act
        var users = JwtDeserializer.Deserialize(token);

        // Assert
        Assert.Empty(users);
    }

    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(null)]
    public void Deserialize_EmptyToken_ReturnsNull(string? token)
    {
        // Act
        var users = JwtDeserializer.Deserialize(token);

        // Assert
        Assert.Empty(users);
    }
}
