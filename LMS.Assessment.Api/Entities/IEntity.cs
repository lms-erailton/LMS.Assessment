namespace LMS.Assessment.Api.Abstractions;

public class IEntity
{
    int Id { get; }
    int CreatedBy { get; }
    DateTime CreatedAt { get; }
}