namespace VetClinic.Domain.Repositories
{
    public interface IVeterinarianRepository
    {
        Task<bool> ExistsAsync(string firstName, string lastName);
    }
}
