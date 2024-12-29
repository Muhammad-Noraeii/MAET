using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================="
                + "\n          Mojo Advanced Encryption Tool       "
                + "\n=======================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. File Operations (Encrypt/Decrypt)");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2. Message Operations (Encrypt/Decrypt)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("3. Help");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("4. About Us");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5. Exit");
            Console.ResetColor();
            Console.Write("Select a category: ");

            if (!int.TryParse(Console.ReadLine(), out int categoryChoice) || categoryChoice < 1 || categoryChoice > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ResetColor();
                Console.ReadLine();
                continue;
            }

            switch (categoryChoice)
            {
                case 1:
                    FileOperationsMenu();
                    break;
                case 2:
                    MessageOperationsMenu();
                    break;
                case 3:
                    ShowHelp();
                    break;
                case 4:
                    ShowAboutUs();
                    break;
                case 5:
                    return;
            }
        }
    }

    static void FileOperationsMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== File Operations ===");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Encrypt File");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("2. Decrypt File");
        Console.ResetColor();
        Console.Write("Select an option: ");

        if (!int.TryParse(Console.ReadLine(), out int fileChoice) || fileChoice < 1 || fileChoice > 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Press Enter to return to main menu.");
            Console.ResetColor();
            Console.ReadLine();
            return;
        }

        switch (fileChoice)
        {
            case 1:
                EncryptMenu();
                break;
            case 2:
                DecryptMenu();
                break;
        }
    }

    static void MessageOperationsMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== Message Operations ===");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Encrypt Message");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("2. Decrypt Message");
        Console.ResetColor();
        Console.Write("Select an option: ");

        if (!int.TryParse(Console.ReadLine(), out int messageChoice) || messageChoice < 1 || messageChoice > 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Press Enter to return to main menu.");
            Console.ResetColor();
            Console.ReadLine();
            return;
        }

        switch (messageChoice)
        {
            case 1:
                EncryptMessageMenu();
                break;
            case 2:
                DecryptMessageMenu();
                break;
        }
    }

    static void EncryptMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== Encrypt File ===");
        Console.ResetColor();
        Console.Write("Enter file path: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string filePath = Console.ReadLine();
        Console.ResetColor();

        Console.Write("Enter password: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string password = Console.ReadLine();
        Console.ResetColor();

        Console.WriteLine("Choose encryption level:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Basic Encryption");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("2. Advanced Encryption");
        Console.ResetColor();
        Console.Write("Select level: ");

        if (!int.TryParse(Console.ReadLine(), out int level) || level < 1 || level > 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid encryption level. Press Enter to return to main menu.");
            Console.ResetColor();
            Console.ReadLine();
            return;
        }

        try
        {
            EncryptFile(filePath, password, level);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File encrypted successfully!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("Press Enter to return to main menu.");
        Console.ReadLine();
    }

    static void DecryptMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== Decrypt File ===");
        Console.ResetColor();
        Console.Write("Enter file path: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string filePath = Console.ReadLine();
        Console.ResetColor();

        Console.Write("Enter password: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string password = Console.ReadLine();
        Console.ResetColor();

        try
        {
            DecryptFile(filePath, password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File decrypted successfully!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("Press Enter to return to main menu.");
        Console.ReadLine();
    }

    static void EncryptMessageMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== Encrypt Message ===");
        Console.ResetColor();
        Console.Write("Enter your message: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string message = Console.ReadLine();
        Console.ResetColor();

        Console.Write("Enter password: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string password = Console.ReadLine();
        Console.ResetColor();

        try
        {
            string encryptedMessage = EncryptMessage(message, password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Encrypted Message: " + encryptedMessage);
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("Press Enter to return to main menu.");
        Console.ReadLine();
    }

    static void DecryptMessageMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== Decrypt Message ===");
        Console.ResetColor();
        Console.Write("Enter the encrypted message: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string encryptedMessage = Console.ReadLine();
        Console.ResetColor();

        Console.Write("Enter password: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string password = Console.ReadLine();
        Console.ResetColor();

        try
        {
            string decryptedMessage = DecryptMessage(encryptedMessage, password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Decrypted Message: " + decryptedMessage);
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("Press Enter to return to main menu.");
        Console.ReadLine();
    }

    static void ShowHelp()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=== Help ===");
        Console.ResetColor();
        Console.WriteLine("This program allows you to securely encrypt and decrypt files and messages.");
        Console.WriteLine("Features:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. File Operations: Encrypt or decrypt files.");
        Console.WriteLine("2. Message Operations: Encrypt or decrypt text messages.");
        Console.ResetColor();
        Console.WriteLine("Make sure to remember your password as it is required for decryption.");
        Console.WriteLine("Press Enter to return to main menu.");
        Console.ReadLine();
    }

    static void ShowAboutUs()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== About Us ===");
        Console.ResetColor();
        Console.WriteLine("This program is developed by Mojo Corp.");
        Console.WriteLine("Key Features:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("- File encryption and decryption with multiple security levels.");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("- Secure message encryption and decryption.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("- Easy-to-use console interface.");
        Console.ResetColor();
        Console.WriteLine("Mojo Corp. ensures that your data is protected with advanced AES encryption.");
        Console.WriteLine("About Mojo Corp.");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Since : 2021");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Web Site : Mojo-Corp.blog.ir");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("CEO Mail : Muhammad.Noraeii@gmail.com");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Support Mail : support@Mojo-Corp.com");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Copy Right 2024 Mojo Corp");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Press Enter to return to main menu.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.ReadLine();
    }

    static (byte[] Key, byte[] IV) DeriveKeyAndIV(string password, byte[] salt)
    {
        using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 100_000))
        {
            byte[] key = rfc2898.GetBytes(32); // 256-bit key
            byte[] iv = rfc2898.GetBytes(16); // 128-bit IV
            return (key, iv);
        }
    }

    static void EncryptFile(string filePath, string password, int level)
    {
        byte[] salt = GenerateRandomSalt();
        var (key, iv) = DeriveKeyAndIV(password, salt);
        string outputFilePath = filePath + ".MAEF";

        using (var aes = Aes.Create())
        {
            aes.KeySize = level == 1 ? 128 : 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CFB;

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                outputFileStream.Write(salt, 0, salt.Length); // Save salt at the beginning of the file
                using (var cryptoStream = new CryptoStream(outputFileStream, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    fileStream.CopyTo(cryptoStream);
                }
            }
        }
        ClearSensitiveData(key, iv);
    }

    static void DecryptFile(string filePath, string password)
    {
        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] salt = new byte[16]; // Assuming 128-bit salt
            fileStream.Read(salt, 0, salt.Length);

            var (key, iv) = DeriveKeyAndIV(password, salt);

            using (var aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CFB;

                string outputFilePath = Path.ChangeExtension(filePath, null);
                using (var outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                using (var cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    cryptoStream.CopyTo(outputFileStream);
                }
            }
            ClearSensitiveData(key, iv);
        }
    }

    static string EncryptMessage(string message, string password)
    {
        byte[] salt = GenerateRandomSalt();
        var (key, iv) = DeriveKeyAndIV(password, salt);

        using (var aes = Aes.Create())
        using (var memoryStream = new MemoryStream())
        {
            memoryStream.Write(salt, 0, salt.Length); // Save salt at the beginning of the message
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                cryptoStream.Write(messageBytes, 0, messageBytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }

    static string DecryptMessage(string encryptedMessage, string password)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedMessage);

        using (var memoryStream = new MemoryStream(encryptedBytes))
        {
            byte[] salt = new byte[16];
            memoryStream.Read(salt, 0, salt.Length);

            var (key, iv) = DeriveKeyAndIV(password, salt);

            using (var aes = Aes.Create())
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
            using (var reader = new StreamReader(cryptoStream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    static byte[] GenerateRandomSalt()
    {
        byte[] salt = new byte[16]; // 128-bit salt
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    static void ClearSensitiveData(byte[] key, byte[] iv)
    {
        Array.Clear(key, 0, key.Length);
        Array.Clear(iv, 0, iv.Length);
    }
}
