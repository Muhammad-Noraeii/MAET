Here are detailed descriptions for both versions in English to include in your GitHub repository:

---

### Version 1: **Mojo Advanced Encryption Tool - Initial Release**
**Description:**
- This is the initial version of the Mojo Advanced Encryption Tool, designed for secure encryption and decryption of files and messages.
- The primary focus is on providing robust security using AES encryption with a simple console-based interface.

**Features:**
1. **File Operations**:
   - Encrypt files with a password.
   - Decrypt files using the same password.
2. **Message Operations**:
   - Encrypt messages with a password.
   - Decrypt messages using the same password.
3. **Improved Interface**:
   - Color-coded menu options for better readability.
   - Simple and intuitive navigation.

**Algorithms Used:**
- File and message encryption/decryption with AES.
- Key generation using SHA-256 and IV generation using MD5.

---

### Version 2: **Mojo Advanced Encryption Tool - Password Recovery Update**
**Description:**
- This update introduces a new feature for password recovery. Users can now recover their password by answering a security question set during encryption.
- Enhancements to the interface for a better user experience are also included.

**New Features:**
1. **Password Recovery**:
   - Users can set a security question and answer during file encryption.
   - Forgotten passwords can be recovered by correctly answering the security question.
2. **Enhanced User Interface**:
   - Visual improvements with separators for better menu organization.
   - Color-coding for success, error, and warning messages for clarity.

**Technical Changes:**
- **New Methods**:
  - `RecoverPasswordMenu`: Handles password recovery functionality.
  - `EncryptFile` and `RecoverPassword`: Store and retrieve security question and answer.
- **Improved Methods**:
  - Enhanced integration of encryption, decryption, and recovery for streamlined functionality.

---

**How to Use:**
- During file encryption, set a security question and answer.
- To recover a forgotten password, select the password recovery option and correctly answer the security question.

