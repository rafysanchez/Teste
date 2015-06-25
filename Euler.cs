using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SolvEuler
{
    public class Euler
    {
        public decimal Solve()
        {

           // string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\input.txt";
            string filename = @"C:\Users\rafael\Documents\Visual Studio 2012\Projects\Exercicios\SolvEuler\File\input.txt";
            //string filename = @"~/File/input.txt";
            const int numbersInProduct = 4;

            DateTime startTime = DateTime.Now;
            decimal product = 0;

            int[,] inputSquare = readInput(filename);
            for (int col = 0; col < inputSquare.GetLength(0); col++)
            {
                for (int row = 0; row < inputSquare.GetLength(1); row++)
                {
                    decimal tempProd;

                    // Check Vertically
                    if (row < inputSquare.GetLength(0) - numbersInProduct)
                    {
                        tempProd = inputSquare[col, row];
                        for (int i = 1; i < numbersInProduct; i++)
                        {
                            tempProd *= inputSquare[col, row + i];
                        }
                        product = Math.Max(product, tempProd);
                    }

                    // Check Horisontally
                    if (col < inputSquare.GetLength(1) - numbersInProduct)
                    {
                        tempProd = inputSquare[col, row];
                        for (int i = 1; i < numbersInProduct; i++)
                        {
                            tempProd *= inputSquare[col + i, row];
                        }
                        product = Math.Max(product, tempProd);
                    }

                    // Check diagonally upwards / forwards           
                    if ((col < inputSquare.GetLength(0) - numbersInProduct) && (row >= numbersInProduct))
                    {
                        tempProd = inputSquare[col, row];
                        for (int i = 1; i < numbersInProduct; i++)
                        {
                            tempProd *= inputSquare[col + i, row - i];
                        }
                        product = Math.Max(product, tempProd);
                    }

                    // Check diagonally Downwards / forwards      
                    if ((row < inputSquare.GetLength(0) - numbersInProduct) && (col < inputSquare.GetLength(1) - numbersInProduct))
                    {
                        tempProd = inputSquare[col, row];
                        for (int i = 1; i < numbersInProduct; i++)
                        {
                            tempProd *= inputSquare[col + i, row + i];
                        }
                        product = Math.Max(product, tempProd);
                    }
                }
            }

            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            Console.WriteLine("The greatest product of {0} entries, is {1}", numbersInProduct, product);
            Console.WriteLine("Solution took {0} ms", duration.TotalMilliseconds);
            return product;

        }


        private int[,] readInput(string filename)
        {
            int lines = 0;
            string line;
            string[] linePieces;

            StreamReader r = new StreamReader(filename);
            while (r.ReadLine() != null)
            {
                lines++;
            }

            int[,] inputSquare = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    inputSquare[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }

            r.Close();

            return inputSquare;
        }


    }
}