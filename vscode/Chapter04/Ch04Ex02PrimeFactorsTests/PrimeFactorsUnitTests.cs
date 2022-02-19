using Ch04Ex02PrimeFactorsLib;

namespace Ch04Ex02PrimeFactorsTests
{
  public class PrimeFactorsUnitTests
  {
    [Fact]
    public void PrimeFactorsOf40()
    {
      // arrange
      int number = 40;
      string expected = "5 x 2 x 2 x 2";

      // act
      string actual = Primes.PrimeFactors(number);

      // assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PrimeFactorsOf99()
    {
      // arrange
      int number = 99;
      string expected = "11 x 3 x 3";

      // act
      string actual = Primes.PrimeFactors(number);

      // assert
      Assert.Equal(expected, actual);
    }
  }
}
