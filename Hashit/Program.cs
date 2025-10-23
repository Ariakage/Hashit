using System.Text.Json;

namespace Hashit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hashit - V1.0");

            if (args.Length == 0)
            {
                showHelp();
                return;
            }

            //flags
            bool g = false, v = false;
            string ifp = null, cfp = null;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-h":
                    case "-help":
                    case "--help":
                        showHelp();
                        return;
                    case "-g":
                        g = true;
                        if (i + 1 < args.Length)
                        {
                            ifp = args[++i];
                        }
                        else
                        {
                            Console.WriteLine("Error: Missing file for -g option.");
                            return;
                        }
                        break;
                    case "-v":
                        v = true;
                        if (i + 1 < args.Length)
                        {
                            ifp = args[++i];
                        }
                        else
                        {
                            Console.WriteLine("Error: Missing file for -v option.");
                            return;
                        }
                        break;
                    case "-i":
                        if (i + 1 < args.Length)
                        {
                            cfp = args[++i];
                        }
                        else
                        {
                            Console.WriteLine("Error: Missing checksum file for -i option.");
                            return;
                        }
                        break;
                    default:
                        if (ifp == null && !args[i].StartsWith("-"))
                        {
                            g = true;
                            ifp = args[i];
                        }
                        else
                        {
                            Console.WriteLine($"Unknown argument: {args[i]}");
                            return;
                        }
                        break;


                }
            }

            if (g)
            {
                using (FileStream fileStream = File.OpenRead(ifp))
                {
                    //byte[] MD5bytes = HashCalculator.ComputeMD5(fileStream);
                    //string MD5String = HashCalculator.ToString(MD5bytes);
                    fileStream.Position = 0;
                    string MD5String = HashCalculator.ToString(HashCalculator.ComputeMD5(fileStream));
                    fileStream.Position = 0;
                    string SHA1String = HashCalculator.ToString(HashCalculator.ComputeSHA1(fileStream));
                    fileStream.Position = 0;
                    string SHA256String = HashCalculator.ToString(HashCalculator.ComputeSHA256(fileStream));
                    fileStream.Position = 0;
                    string SHA512String = HashCalculator.ToString(HashCalculator.ComputeSHA512(fileStream));
                    fileStream.Position = 0;
                    string CRC32String = HashCalculator.ToString(HashCalculator.ComputeCRC32(fileStream));
                    Console.WriteLine($"File: {ifp}\n" +
                                      $"MD5:    {MD5String}\n" +
                                      $"SHA-1:  {SHA1String}\n" +
                                      $"SHA-256:{SHA256String}\n" +
                                      $"SHA-512:{SHA512String}\n" +
                                      $"CRC-32: {CRC32String}");
                    Dictionary<string, string> dict = new Dictionary<string, string>
                    {
                        { "MD5", MD5String },
                        { "SHA1", SHA1String },
                        { "SHA256", SHA256String },
                        { "SHA512", SHA512String },
                        { "CRC32", CRC32String }
                    };
                    string json = JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true });
                    string ocfp = ifp + ".checksum";
                    Console.WriteLine($"Convert into json:\n{json}\nOutput checksum path: {ocfp}");
                    using (FileStream outFileStream = File.Create(ocfp))
                    {
                        outFileStream.Position = 0;
                        outFileStream.Write(System.Text.Encoding.UTF8.GetBytes(json));
                    }
                }
                return;
            }
            else if (v)
            {
                if (cfp == null)
                {
                    cfp = ifp + ".checksum";
                }
                if (!File.Exists(cfp))
                {
                    Console.WriteLine($"Error: Checksum file '{cfp}' does not exist.");
                    return;
                }
                string jsonContent = File.ReadAllText(cfp);
                Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
                using (FileStream fileStream = File.OpenRead(ifp))
                {
                    bool allMatch = true;
                    foreach (var kvp in dict)
                    {
                        string algo = kvp.Key;
                        string expectedHash = kvp.Value;
                        string computedHash = algo switch
                        {
                            "MD5" => HashCalculator.ToString(HashCalculator.ComputeMD5(fileStream)),
                            "SHA1" => HashCalculator.ToString(HashCalculator.ComputeSHA1(fileStream)),
                            "SHA256" => HashCalculator.ToString(HashCalculator.ComputeSHA256(fileStream)),
                            "SHA512" => HashCalculator.ToString(HashCalculator.ComputeSHA512(fileStream)),
                            "CRC32" => HashCalculator.ToString(HashCalculator.ComputeCRC32(fileStream)),
                            _ => null
                        };
                        fileStream.Position = 0;
                        if (computedHash == expectedHash)
                        {
                            Console.WriteLine($"{algo} match: {computedHash}");
                        }
                        else
                        {
                            Console.WriteLine($"{algo} mismatch! Expected: {expectedHash}, Computed: {computedHash}");
                            allMatch = false;
                        }
                    }
                    if (allMatch)
                    {
                        Console.WriteLine("All hashes match.");
                    }
                    else
                    {
                        Console.WriteLine("Some hashes did not match.");
                    }
                }

            }
        }
        static void showHelp()
        {
            Console.WriteLine("Usage: Hashit [options] <file>\n" +
                            "e.g. (Calc file hash) Hashit <file> | Hashit -g <file>\n" +
                            "(Verify file hash) Hashit -v <file> (default read <filename>.checksum) | Hashit -v <file> -i <checksum-file>\n");
        }
    }
}
