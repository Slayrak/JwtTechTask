namespace JwtTechTask.Entities;
public sealed record Transaction(string Id, double Amount, string Currency, Meta Meta, object Status);
