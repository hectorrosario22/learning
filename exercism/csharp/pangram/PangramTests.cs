#pragma warning disable CA1050 // Declare types in namespaces
public class PangramTests
#pragma warning restore CA1050 // Declare types in namespaces
{
    [Fact]
    public void Empty_sentence()
    {
        Assert.False(Pangram.IsPangram(""));
    }

    [Fact]
    public void Perfect_lower_case()
    {
        Assert.True(Pangram.IsPangram("abcdefghijklmnopqrstuvwxyz"));
    }

    [Fact]
    public void Only_lower_case()
    {
        Assert.True(Pangram.IsPangram("the quick brown fox jumps over the lazy dog"));
    }

    [Fact]
    public void Missing_the_letter_x()
    {
        Assert.False(Pangram.IsPangram("a quick movement of the enemy will jeopardize five gunboats"));
    }

    [Fact]
    public void Missing_the_letter_h()
    {
        Assert.False(Pangram.IsPangram("five boxing wizards jump quickly at it"));
    }

    [Fact]
    public void With_underscores()
    {
        Assert.True(Pangram.IsPangram("the_quick_brown_fox_jumps_over_the_lazy_dog"));
    }

    [Fact]
    public void With_numbers()
    {
        Assert.True(Pangram.IsPangram("the 1 quick brown fox jumps over the 2 lazy dogs"));
    }

    [Fact]
    public void Missing_letters_replaced_by_numbers()
    {
        Assert.False(Pangram.IsPangram("7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog"));
    }

    [Fact]
    public void Mixed_case_and_punctuation()
    {
        Assert.True(Pangram.IsPangram("\"Five quacking Zephyrs jolt my wax bed.\""));
    }

    [Fact]
    public void A_m_and_a_m_are_26_different_characters_but_not_a_pangram()
    {
        Assert.False(Pangram.IsPangram("abcdefghijklm ABCDEFGHIJKLM"));
    }
}
