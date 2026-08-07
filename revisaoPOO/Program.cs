namespace revisaoPOO {
    /// <summary>
    /// Escreva um programa que receba três valores inteiros, A, B e C. Este programa deve:
    /// - calcular o produto dos números ímpares entre o menor e o maior número dos três lidos, incluindo ambos;
    /// - responder quais são os números divisíveis pelo menor número na faixa entre os dois maiores, incluindo ambos.
    /// </summary>
    
    internal class Program
    {
        const int QuantValores = 3;

        static int[] LerValores() {
            int[] valores = new int[QuantValores];
            Console.Clear();
            Console.WriteLine($"Você precisará digitar {QuantValores} para a realização dos cálculos:");
            for (int i = 0; i < QuantValores; i++) {
                Console.Write($"Digite o {i+1}º valor: ");
                valores[i] = int.Parse(Console.ReadLine());
            }
            return valores;
        }

        static void Main(string[] args)
        {
            int[] valores = LerValores();
            int produto;
            int[] divisiveis;
            Array.Sort(valores);
            produto = CalcularProdutoDosImpares(valores);
            divisiveis = EncontrarDivisiveisPeloMenor(valores);
            ImprimirResposta(valores, produto, divisiveis);
        }

        static int CalcularProdutoDosImpares(int[] array) {
            int produto = 1;
            for(int i = array[0]; i <= array[QuantValores - 1]; i++) {
                produto *= i % 2 != 0 ? i : 1;
            }
            return produto;
        }

        static int[] EncontrarDivisiveisPeloMenor(int[] array) {
            if (array[0] == 0)
                return new int[0];

            int[] arr = new int[array[2] - array[1] + 1];
            int count = 0;
            for(int i = array[1]; i <= array[QuantValores - 1]; i++) {
                if (i % array[0] == 0) {
                    arr[count] = i;
                    count++;
                }
            }
            
            int[] divisiveis = new int[count];

            for(int i = 0; i < count; i++) 
                divisiveis[i] = arr[i];
                
            return divisiveis;
        }

        static void ImprimirResposta(int[] array, int produto, int[] divisiveis) {
            Console.WriteLine($"Produto dos numeros entre {array[0]} e {array[2]}: {produto}");
            Console.WriteLine($"Numeros divisiveis por {array[0]}, entre {array[1]} e {array[2]}");
            for(int i = 0; i < divisiveis.Length; i++) {
                Console.Write($"{divisiveis[i]}, ");
            }
        }
    }
}
