using System.Security.Cryptography;
using System.IO.Hashing;

namespace Hashit
{
    // CRC-32 SHA-1 SHA-256 SHA-512 MD5 Calulator Class
    public class HashCalculator
    {
        //public static byte[] ComputeMD5(byte[] bytes) => MD5.Create().ComputeHash(bytes);
        /// <summary>
        /// Compute MD5 hash from a byte array.
        /// </summary>
        /// <param name="bytes">Input bytes to calculate hash.</param>
        /// <returns>MD5 hash as a byte array.</returns>
        public static byte[] ComputeMD5(byte[] bytes) => MD5.HashData(bytes);
        /// <summary>
        /// Compute MD5 hash from a FileStream.
        /// </summary>
        /// <param name="stream">FileStream to calculate hash.</param>
        /// <returns>MD5 hash as a byte array.</returns>
        public static byte[] ComputeMD5(FileStream stream) => MD5.HashData(stream);

        /// <summary>
        /// Compute SHA-1 hash from a byte array.
        /// </summary>
        /// <param name="bytes">Input bytes to calculate hash.</param>
        /// <returns>SHA-1 hash as a byte array.</returns>
        public static byte[] ComputeSHA1(byte[] bytes) => SHA1.HashData(bytes);
        /// <summary>
        /// Compute SHA-1 hash from a FileStream.
        /// </summary>
        /// <param name="stream">FileStream to calculate hash.</param>
        /// <returns>SHA-1 hash as a byte array.</returns>
        public static byte[] ComputeSHA1(FileStream stream) => SHA1.HashData(stream);

        /// <summary>
        /// Compute SHA-256 hash from a byte array.
        /// </summary>
        /// <param name="bytes">Input bytes to calculate hash.</param>
        /// <returns>SHA-256 hash as a byte array.</returns>
        public static byte[] ComputeSHA256(byte[] bytes) => SHA256.HashData(bytes);
        /// <summary>
        /// Compute SHA-256 hash from a FileStream.
        /// </summary>
        /// <param name="stream">FileStream to calculate hash.</param>
        /// <returns>SHA-256 hash as a byte array.</returns>
        public static byte[] ComputeSHA256(FileStream stream) => SHA256.HashData(stream);

        /// <summary>
        /// Compute SHA-512 hash from a byte array.
        /// </summary>
        /// <param name="bytes">Input bytes to calculate hash.</param>
        /// <returns>SHA-512 hash as a byte array.</returns>
        public static byte[] ComputeSHA512(byte[] bytes) => SHA512.HashData(bytes);
        /// <summary>
        /// Compute SHA-512 hash from a FileStream.
        /// </summary>
        /// <param name="stream">FileStream to calculate hash.</param>
        /// <returns>SHA-512 hash as a byte array.</returns>
        public static byte[] ComputeSHA512(FileStream stream) => SHA512.HashData(stream);

        /*public static byte[] ComputeCRC32(byte[] bytes)
        {
            var crc32 = new Crc32();
            crc32.Append(bytes);
            return crc32.GetCurrentHash();
        }*/

        /// <summary>
        /// Compute CRC32 from bytes
        /// </summary>
        /// <param name="bytes">Bytes to be calculated</param>
        /// <returns>CRC32 (byte[])</returns>
        public static byte[] ComputeCRC32(byte[] bytes) => Crc32.Hash(bytes);
        /// <summary>
        /// Compute CRC32 from a FileStream
        /// </summary>
        /// <param name="stream">FileStream to be calculated</param>
        /// <returns>CRC32 (byte[])</returns>
        public static byte[] ComputeCRC32(FileStream stream)
        {
            Crc32 crc32 = new Crc32();
            crc32.Append(stream);
            return crc32.GetCurrentHash();
        }
        /// <summary>
        /// Convert a byte array hash into a lowercase hexadecimal string representation.
        /// </summary>
        /// <param name="hashBytes">The byte array containing the hash.</param>
        /// <returns>A lowercase hexadecimal string representing the hash.</returns>
        public static string ToString(byte[] hashBytes) => BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
    }
}
