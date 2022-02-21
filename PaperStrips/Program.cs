using System;
using System.Collections.Generic;
using System.Linq;

namespace PaperStrips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] original = new int[] { 1, 4, 3, 2, };
            int[] desired = new int[] { 1, 2, 4, 3, };
            Console.WriteLine(MinPieces(original, desired));
        }
        
        public static int MinPieces(int[] original, int[] desired)
        {
            var originalVariations = GetVariations(original);
            var desiredVariations = GetVariations(desired);
            var pieces = new List<List<int>>();
            foreach (var item in originalVariations)
            {

                var piece = desiredVariations.Where(x => x.SequenceEqual(item));
                var pieceSelection = piece.SelectMany(x => x);
                var piecesSelection = pieces.SelectMany(x => x);
                var intersect = pieceSelection.Intersect(piecesSelection);
                if (!intersect.Any()) pieces.AddRange(piece);
            }

            return pieces.Count();
        }
        static List<List<int>> GetVariations(int[] numbers)
        {
            var all = new List<List<int>>();
            for (int i = 1; i < numbers.Length + 1; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {

                    var taked = numbers.Skip(j).Take(i).ToList();
                    if (taked.Count() != i) continue;
                    all.Add(taked);
                }
            }
            return all.OrderByDescending(x => x.Count()).ToList();
        }
        public static bool IsMaybeStrip(int number, int anotherNumber)
        {
            return number == anotherNumber;
        }
    }
    
}
