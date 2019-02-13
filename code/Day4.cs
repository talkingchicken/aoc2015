using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode
{
	class DayFour
	{
		public static void PartOne()
		{
			string input = "bgvyzdsv";

			int number = 0;
			string output;
			do
			{
				number++;

				string realInput = input + number;
				MD5 md5Hash = MD5.Create();
				output = GetMd5Hash(md5Hash, realInput);

			} while (!output.StartsWith("00000"));

			Console.WriteLine(number);
		}

		public static void PartTwo()
		{
			string input = "bgvyzdsv";

			int number = 0;
			string output;
			do
			{
				number++;

				string realInput = input + number;
				MD5 md5Hash = MD5.Create();
				output = GetMd5Hash(md5Hash, realInput);

			} while (!output.StartsWith("000000"));

			Console.WriteLine(number);
		}

		public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
	}
}