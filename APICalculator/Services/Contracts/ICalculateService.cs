
namespace APICalculator.Services.Contracts
{
    public interface ICalculateService
    {
        int Add(decimal x, decimal y);

        int Subtract(decimal x, decimal y);

        int Multiply(decimal x, decimal y);

        int Divide(decimal x, decimal y);

        int Exponente(decimal x, decimal y);

        decimal GetResult(int id);
    }
}
