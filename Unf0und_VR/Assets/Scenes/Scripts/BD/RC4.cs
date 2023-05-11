using System;

public class RC4
{
    private readonly byte[] s = new byte[256];
    private int i, j;

    public RC4(byte[] key)
    {
        for (i = 0; i < 256; i++)
        {
            s[i] = (byte)i;
        }

        for (i = 0, j = 0; i < 256; i++)
        {
            j = (j + key[i % key.Length] + s[i]) & 0xff;
            Swap(i, j);
        }

        i = j = 0;
    }

    private void Swap(int i, int j)
    {
        byte temp = s[i];
        s[i] = s[j];
        s[j] = temp;
    }

    public byte[] Encrypt(byte[] input)
    {
        byte[] output = new byte[input.Length];
        for (int k = 0; k < input.Length; k++)
        {
            i = (i + 1) & 0xff;
            j = (j + s[i]) & 0xff;
            Swap(i, j);
            output[k] = (byte)(input[k] ^ s[(s[i] + s[j]) & 0xff]);
        }

        return output;
    }
}