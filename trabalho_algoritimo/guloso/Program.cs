using System;
using System.IO;
using System.Collections;

namespace guloso {
	class Program {
		static void Main(string[] args) {
      String inputFileName = args[0];
      String outputFileName = args[1];

      string[] lines = File.ReadAllLines(inputFileName);

      ArrayList caminho = new ArrayList();
      caminho.Add(1);

      int total = guloso(caminho, lines, 0, 0);

      using(StreamWriter sw = new StreamWriter(outputFileName)) {
        foreach (int item in caminho) {
          sw.WriteLine(item);
        }

        sw.WriteLine(total);
      }
		}

    public static int guloso(ArrayList caminho, string[] lines, int vCurrent, int total) {
      if (caminho.Count == lines.Length) {
        caminho.Add(1);
        return total + (int)Char.GetNumericValue(lines[vCurrent][0]);
      }

      string[] nums = lines[vCurrent].Split(" ");

      int menor = 99;
      int idx = 0;

      for (int i=0; i<nums.Length; i++) {
        int convert = Convert.ToInt32(nums[i]);

        if (convert < menor && !caminho.Contains(i+1)) {
            menor = convert;
            idx = i + 1;
        }
      }

      caminho.Add(idx);
      return guloso(caminho, lines, idx-1, menor + total);
    }
	}
}