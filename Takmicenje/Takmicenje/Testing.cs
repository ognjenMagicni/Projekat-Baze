using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Testing
    {
        static void main(string[] args)
        {
            string inputString = "Hello, world!"; // Your input string

            // Compute the SHA256 hash
            string hashedString = ComputeSHA256Hash(inputString);

            Console.WriteLine("Input String: " + inputString);
            Console.WriteLine("SHA256 Hash: " + hashedString);
        }

    static string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // ComputeHash - returns byte array
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2")); // Convert each byte to a hexadecimal string
            }
            return builder.ToString();
        }
    }
}
    

