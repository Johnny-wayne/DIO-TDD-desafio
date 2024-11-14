using Xunit;
using NewTalents;

namespace TestNewTalent
{
    public class CalculadoraTest
    {
        public Calculadora ConstruirClasse()
        {
            string data = "02/02/2020";
            Calculadora calc = new Calculadora("02/02/2020");

            return calc;
        }
          

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calc = ConstruirClasse();

            int resultadoCalculadora = calc.Somar(val1, val2);

            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(5, 1, 4)]
        public void TesteSubtrair(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calc = ConstruirClasse();

            int resultadoCalculadora = calc.Subtrair(val1, val2);

            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calc = ConstruirClasse();

            int resultadoCalculadora = calc.Multiplicar(val1, val2);

            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(5, 5, 1)]
        [InlineData(25, 5, 5)]
        public void TesteDividir(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calc = ConstruirClasse();

            int resultadoCalculadora = calc.Dividir(val1, val2);

            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = ConstruirClasse();

            Assert.Throws<DivideByZeroException>(
                    () => calc.Dividir(3, 0)
                );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = ConstruirClasse();

            calc.Somar(1, 2);
            calc.Somar(3, 4);
            calc.Somar(5, 6);
            calc.Somar(2, 9);

            var lista = calc.Historico();

            Assert.NotEmpty(calc.Historico());
            Assert.Equal(3, lista.Count);
        }
    }

}