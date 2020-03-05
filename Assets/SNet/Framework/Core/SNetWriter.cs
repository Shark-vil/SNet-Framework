using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SNetWriter : MonoBehaviour, IDisposable
{
    public MemoryStream Stream = null;
    public BinaryWriter Writer = null;

    public SNetWriter()
    {
        Stream = new MemoryStream();
        Writer = new BinaryWriter(Stream);
    }

    public byte[] SaveWriter()
    {
        try
        {
            if (Stream != null)
                return Stream.ToArray();
        }
        catch (Exception ex)
        {
            // Error
        }

        return null;
    }

    public void Dispose()
    {
        if (Writer != null)
            Writer.Close();

        if (Stream != null)
            Stream.Close();
    }
}
