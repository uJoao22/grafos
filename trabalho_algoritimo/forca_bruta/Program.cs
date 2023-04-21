using System;
using System.IO;
using System.Collections;

namespace forca_bruta {
	class Program {
		static void Main(string[] args) {
      String inputFileName = args[0];
      String outputFileName = args[1];

      string[] lines = File.ReadAllLines(inputFileName);

      for (int i = 0; i < lines.Length; i++) {
        string caminho = "1";

        for (int j=0; j<lines.Length; j++) {
          if (!contemVertice(caminho, j+1)) {
            caminho = $"{caminho}-{j+1}";
          }
        }

        caminho += "-1";

        Console.WriteLine(caminho);
      }
		}

    public static bool contemVertice(string caminho, int vet) {
      string[] vertices = caminho.Split("-");

      foreach (string vertice in vertices) {
        if (Convert.ToInt32(vertice) == vet)
          return true;
      }

      return false;
    }
	}
}