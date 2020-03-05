using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Snet.Framework.Utilities
{
    public class SNetWriter : IDisposable
    {
        public MemoryStream Stream = null;
        public BinaryWriter Writer = null;
        public BinaryReader Reader = null;

        public SNetWriter(byte[] DataBytes = null)
        {
            if (DataBytes != null)
            {
                Stream = new MemoryStream(DataBytes);
                Reader = new BinaryReader(Stream);
            }
            else
            {
                Stream = new MemoryStream();
                Writer = new BinaryWriter(Stream);
            }
        }

        public byte[] SaveWriter()
        {
            try
            {
                if (Reader == null && Stream != null)
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
}