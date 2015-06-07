/*
    Copyright(c) 2015 Neodymium

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using RageLib.Resources.Common;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Particles
{
    public class Unknown_P_009 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 64; }
        }

        // structure data
        public ulong p1;
        public ushort c1a;
        public ushort c1b;
        public uint Unknown_Ch; // 0x00000000
        public ulong p2;
        public ushort c2a;
        public ushort c2b;
        public uint Unknown_1Ch; // 0x00000000
        public uint Unknown_20h; // 0x00000001
        public uint Unknown_24h; // 0x00000000
        public ulong p3;
        public ushort c3a;
        public ushort c3b;
        public uint Unknown_34h; // 0x00000000
        public uint Unknown_38h; // 0x00000000
        public uint Unknown_3Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<Unknown_P_012> p1data;
        public ResourceSimpleArray<Unknown_P_013> p2data;
        public ResourceSimpleArray<Unknown_P_017> p3data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.p1 = reader.ReadUInt64();
            this.c1a = reader.ReadUInt16();
            this.c1b = reader.ReadUInt16();
            this.Unknown_Ch = reader.ReadUInt32();
            this.p2 = reader.ReadUInt64();
            this.c2a = reader.ReadUInt16();
            this.c2b = reader.ReadUInt16();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.p3 = reader.ReadUInt64();
            this.c3a = reader.ReadUInt16();
            this.c3b = reader.ReadUInt16();
            this.Unknown_34h = reader.ReadUInt32();
            this.Unknown_38h = reader.ReadUInt32();
            this.Unknown_3Ch = reader.ReadUInt32();

            // read reference data
            this.p1data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_P_012>>(
                this.p1, // offset
                this.c1a
            );
            this.p2data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_P_013>>(
                this.p2, // offset
                this.c2a
            );
            this.p3data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_P_017>>(
                this.p3, // offset
                this.c3a
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.p1 = (ulong)(this.p1data != null ? this.p1data.Position : 0);
            //this.c1a = (ushort)(this.p1data != null ? this.p1data.Count : 0);
            this.p2 = (ulong)(this.p2data != null ? this.p2data.Position : 0);
            //this.c2a = (ushort)(this.p2data != null ? this.p2data.Count : 0);
            this.p3 = (ulong)(this.p3data != null ? this.p3data.Position : 0);
            //this.c3a = (ushort)(this.p3data != null ? this.p3data.Count : 0);

            // write structure data
            writer.Write(this.p1);
            writer.Write(this.c1a);
            writer.Write(this.c1b);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.p2);
            writer.Write(this.c2a);
            writer.Write(this.c2b);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.p3);
            writer.Write(this.c3a);
            writer.Write(this.c3b);
            writer.Write(this.Unknown_34h);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (p1data != null) list.Add(p1data);
            if (p2data != null) list.Add(p2data);
            if (p3data != null) list.Add(p3data);
            return list.ToArray();
        }

    }
}