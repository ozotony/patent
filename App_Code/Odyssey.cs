using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;


public class Odyssey
{
    public string DecryptString(string inputString, int dwKeySize, string xmlString)
    {
        CspParameters parameters = new CspParameters
        {
            Flags = CspProviderFlags.UseMachineKeyStore
        };
        RSACryptoServiceProvider provider = new RSACryptoServiceProvider(dwKeySize, parameters);
        provider.FromXmlString(xmlString);
        int length = (((dwKeySize / 8) % 3) != 0) ? ((((dwKeySize / 8) / 3) * 4) + 4) : (((dwKeySize / 8) / 3) * 4);
        int num2 = inputString.Length / length;
        ArrayList list = new ArrayList();
        for (int i = 0; i < num2; i++)
        {
            byte[] array = Convert.FromBase64String(inputString.Substring(length * i, length));
            Array.Reverse(array);
            list.AddRange(provider.Decrypt(array, true));
        }
        return Encoding.UTF32.GetString(list.ToArray(Type.GetType("System.Byte")) as byte[]);
    }

    public string EncryptString(string inputString, int dwKeySize, string xmlString)
    {
        CspParameters parameters = new CspParameters
        {
            Flags = CspProviderFlags.UseMachineKeyStore
        };
        RSACryptoServiceProvider provider = new RSACryptoServiceProvider(dwKeySize, parameters);
        provider.FromXmlString(xmlString);
        int num = dwKeySize / 8;
        byte[] bytes = Encoding.UTF32.GetBytes(inputString);
        int num2 = num - 0x2a;
        int length = bytes.Length;
        int num4 = length / num2;
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i <= num4; i++)
        {
            byte[] dst = new byte[((length - (num2 * i)) > num2) ? num2 : (length - (num2 * i))];
            Buffer.BlockCopy(bytes, num2 * i, dst, 0, dst.Length);
            byte[] array = provider.Encrypt(dst, true);
            Array.Reverse(array);
            builder.Append(Convert.ToBase64String(array));
        }
        return builder.ToString();
    }
}
