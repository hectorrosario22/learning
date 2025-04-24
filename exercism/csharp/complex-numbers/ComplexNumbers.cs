#pragma warning disable CA1050 // Declare types in namespaces
public struct ComplexNumber(double real, double imaginary)
#pragma warning restore CA1050 // Declare types in namespaces
{
    public readonly double Real() => real;

    public readonly double Imaginary() => imaginary;

    public readonly ComplexNumber Mul(ComplexNumber other)
    {
        double newReal = real * other.Real() - imaginary * other.Imaginary();
        double newImaginary = real * other.Imaginary() + imaginary * other.Real();
        return new(newReal, newImaginary);
    }

    public readonly ComplexNumber Add(ComplexNumber other)
        => new(real + other.Real(), imaginary + other.Imaginary());

    public readonly ComplexNumber Sub(ComplexNumber other)
        => new(real - other.Real(), imaginary - other.Imaginary());

    public readonly ComplexNumber Div(ComplexNumber other)
    {
        double divisor = other.Real() * other.Real() + other.Imaginary() * other.Imaginary();
        if (divisor == 0) throw new DivideByZeroException();

        double newReal = (real * other.Real() + imaginary * other.Imaginary()) / divisor;
        double newImaginary = (imaginary * other.Real() - real * other.Imaginary()) / divisor;
        return new(newReal, newImaginary);
    }

    public readonly double Abs() => Math.Sqrt(real * real + imaginary * imaginary);

    public readonly ComplexNumber Conjugate() => new(real, -imaginary);

    public readonly ComplexNumber Exp()
    {
        double expReal = Math.Exp(real);
        return new(expReal * Math.Cos(imaginary), expReal * Math.Sin(imaginary));
    }

    public static implicit operator ComplexNumber(double number) => new(number, 0);
}