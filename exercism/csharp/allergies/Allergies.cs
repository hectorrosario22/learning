#pragma warning disable CA1050 // Declare types in namespaces
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies(int mask)
{
    public bool IsAllergicTo(Allergen allergen) => (mask & (int)allergen) != 0;

    public Allergen[] List()
        => [.. Enum.GetValues<Allergen>().Where(IsAllergicTo)];
}
#pragma warning restore CA1050 // Declare types in namespaces