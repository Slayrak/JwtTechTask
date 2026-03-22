namespace JwtTechTask.Entities;
public sealed record User(string UserId, List<Transaction>? Transactions);
