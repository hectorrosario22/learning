#pragma warning disable CA1050 // Declare types in namespaces
public class SpaceAge(int seconds)
#pragma warning restore CA1050 // Declare types in namespaces
{
    private const int EARTH_YEAR_SECONDS = 31_557_600;

    public double OnEarth() => seconds / (double)EARTH_YEAR_SECONDS;

    public double OnMercury() => seconds / (EARTH_YEAR_SECONDS * 0.2408467);

    public double OnVenus() => seconds / (EARTH_YEAR_SECONDS * 0.61519726);

    public double OnMars() => seconds / (EARTH_YEAR_SECONDS * 1.8808158);

    public double OnJupiter() => seconds / (EARTH_YEAR_SECONDS * 11.862615);

    public double OnSaturn() => seconds / (EARTH_YEAR_SECONDS * 29.447498);

    public double OnUranus() => seconds / (EARTH_YEAR_SECONDS * 84.016846);

    public double OnNeptune() => seconds / (EARTH_YEAR_SECONDS * 164.79132);
}