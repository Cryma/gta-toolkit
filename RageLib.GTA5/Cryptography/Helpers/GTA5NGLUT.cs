namespace RageLib.GTA5.Cryptography.Helpers
{
    public class GTA5NGLUT
    {

        public byte[][] LUT0;
        public byte[][] LUT1;

        public byte[] Indices;

        public GTA5NGLUT()
        {
            LUT0 = new byte[256][];
            for (var i = 0; i < 256; i++)
            {
                LUT0[i] = new byte[256];
            }

            LUT1 = new byte[256][];
            for (var i = 0; i < 256; i++)
            {
                LUT1[i] = new byte[256];
            }

            Indices = new byte[65536];
        }

        public byte LookUp(uint value)
        {
            var num = (value & 4294901760u) >> 16;
            var num2 = (value & 65280u) >> 8;
            var num3 = value & 255u;
            return LUT0[LUT1[Indices[(int) num]][(int) num2]][(int) num3];
        }
    }
}
