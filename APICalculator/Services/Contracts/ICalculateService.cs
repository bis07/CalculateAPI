
namespace APICalculator.Services.Contracts
{
    public interface ICalculateService
    {
        int Add(double x, double y);

        int Subtract(double x, double y);

        int Multiply(double x, double y);

        int Divide(double x, double y);

        int Exponente(double x, double y);

        double GetResult(int id);
    }
}
