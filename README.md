

This program is a console-based encryption tool designed to securely encrypt and decrypt files and messages. It uses the AES encryption algorithm and incorporates modern cryptographic practices to ensure data security. Here's a breakdown of how the program functions:

---

#### 1. **Main Menu**
   - The program starts with a menu offering several options:
     - **File Operations:** Encrypt or decrypt files.
     - **Message Operations:** Encrypt or decrypt plain text messages.
     - **Help:** Displays instructions on how to use the program.
     - **About Us:** Provides information about the program and its developers.
     - **Exit:** Exits the program.

---

#### 2. **File Operations**
   - **Encrypt File:**
     - Prompts the user for the file path, a password, and the encryption level (Basic or Advanced).
     - Generates a unique salt for each encryption to ensure security.
     - Derives a cryptographic key and IV (Initialization Vector) using the password and salt via PBKDF2.
     - Encrypts the file using AES encryption in **CFB (Cipher Feedback)** mode.
     - Saves the encrypted file with the `.MAEF` extension.

   - **Decrypt File:**
     - Prompts the user for the file path and password.
     - Reads the salt from the encrypted file.
     - Derives the key and IV using the same password and salt.
     - Decrypts the file and restores the original content.

---

#### 3. **Message Operations**
   - **Encrypt Message:**
     - Asks the user for a plain text message and a password.
     - Generates a unique salt and derives a key and IV.
     - Encrypts the message using AES in CFB mode.
     - Displays the encrypted message in Base64 format.

   - **Decrypt Message:**
     - Takes an encrypted Base64-encoded message and a password as input.
     - Reads the salt and derives the key and IV.
     - Decrypts the message and displays the original plain text.

---

#### 4. **Security Features**
   - **Key and IV Derivation:** 
     - Uses PBKDF2 (Password-Based Key Derivation Function 2) with 100,000 iterations for secure key generation.
   - **Salt:** 
     - Adds a unique salt to each encryption operation to ensure uniqueness and prevent attacks like rainbow tables.
   - **Memory Clearing:** 
     - Clears sensitive key and IV data from memory after use.
   - **Encryption Levels:**
     - Basic: Uses a 128-bit key.
     - Advanced: Uses a 256-bit key for stronger security.

---

#### 5. **File Format**
   - The program saves encrypted files with the `.MAEF` extension.
   - The encrypted file includes the salt at the beginning, making decryption possible without external dependencies.

---

This tool is ideal for securely managing sensitive data like files and messages. Its user-friendly design ensures even non-technical users can protect their data effectively.

# How it works?
### How the Program Works Internally:

This program employs a step-by-step process for encrypting and decrypting files and messages, leveraging modern cryptographic practices. Here's a detailed explanation of its internal workings:

---

#### **Encryption Process**

1. **User Input:**
   - The user provides:
     - The file path or message.
     - A password for encryption.
     - The encryption level (Basic or Advanced).

2. **Salt Generation:**
   - A random 16-byte salt is generated using a cryptographically secure random number generator.
   - The salt ensures that even if the same password is reused, the encryption result is unique.

3. **Key and IV Derivation:**
   - The password and salt are passed through PBKDF2 (Password-Based Key Derivation Function 2) with 100,000 iterations.
   - PBKDF2 outputs:
     - A cryptographic key (32 bytes for Advanced, 16 bytes for Basic).
     - An Initialization Vector (IV) of 16 bytes.

4. **AES Encryption:**
   - AES is initialized with the derived key and IV.
   - The program uses **CFB (Cipher Feedback)** mode for encryption, which ensures data confidentiality without padding issues.
   - The original data (file or message) is encrypted and written to the output file or returned as an encrypted string.

5. **File Format:**
   - Encrypted files are saved with the `.MAEF` extension.
   - The salt is stored at the beginning of the encrypted file, ensuring it is available for decryption.

---

#### **Decryption Process**

1. **User Input:**
   - The user provides:
     - The encrypted file path or Base64-encoded encrypted message.
     - The password used during encryption.

2. **Reading the Salt:**
   - The salt is extracted from the encrypted file or message.

3. **Key and IV Derivation:**
   - Using the same password and extracted salt, PBKDF2 is used to derive the cryptographic key and IV.

4. **AES Decryption:**
   - AES is initialized with the derived key and IV.
   - The encrypted data is decrypted using the same CFB mode used during encryption.

5. **Restoring the Original Data:**
   - The decrypted data is written back to the file (for files) or displayed as plain text (for messages).

---

#### **Security Considerations**

1. **Salt Storage:**
   - Storing the salt with the encrypted data ensures it is always available for decryption without external dependencies.

2. **Password-Based Security:**
   - The program relies on a user-provided password for encryption and decryption.
   - A strong, unique password enhances the overall security.

3. **Clearing Sensitive Data:**
   - Key and IV data are cleared from memory immediately after use to prevent leaks.

4. **Encryption Levels:**
   - Basic Encryption uses a 128-bit key for faster operations.
   - Advanced Encryption uses a 256-bit key for stronger security.

---

This approach ensures that the program is secure, reliable, and user-friendly, making it suitable for protecting sensitive files and messages.
