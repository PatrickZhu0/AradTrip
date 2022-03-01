using System;

namespace FlatBuffers
{
	// Token: 0x02004AFA RID: 19194
	public class ByteBuffer
	{
		// Token: 0x0601BEB8 RID: 114360 RVA: 0x0088C4C7 File Offset: 0x0088A8C7
		public ByteBuffer(byte[] buffer) : this(buffer, 0)
		{
		}

		// Token: 0x0601BEB9 RID: 114361 RVA: 0x0088C4D4 File Offset: 0x0088A8D4
		public ByteBuffer(byte[] buffer, int pos)
		{
			this._buffer = buffer;
			this._pos = pos;
		}

		// Token: 0x170025F0 RID: 9712
		// (get) Token: 0x0601BEBA RID: 114362 RVA: 0x0088C525 File Offset: 0x0088A925
		public int Length
		{
			get
			{
				return this._buffer.Length;
			}
		}

		// Token: 0x170025F1 RID: 9713
		// (get) Token: 0x0601BEBB RID: 114363 RVA: 0x0088C52F File Offset: 0x0088A92F
		public byte[] Data
		{
			get
			{
				return this._buffer;
			}
		}

		// Token: 0x170025F2 RID: 9714
		// (get) Token: 0x0601BEBC RID: 114364 RVA: 0x0088C537 File Offset: 0x0088A937
		// (set) Token: 0x0601BEBD RID: 114365 RVA: 0x0088C53F File Offset: 0x0088A93F
		public int Position
		{
			get
			{
				return this._pos;
			}
			set
			{
				this._pos = value;
			}
		}

		// Token: 0x0601BEBE RID: 114366 RVA: 0x0088C548 File Offset: 0x0088A948
		public void Reset()
		{
			this._pos = 0;
		}

		// Token: 0x0601BEBF RID: 114367 RVA: 0x0088C551 File Offset: 0x0088A951
		public static ushort ReverseBytes(ushort input)
		{
			return (ushort)((int)(input & 255) << 8 | (int)((uint)(input & 65280) >> 8));
		}

		// Token: 0x0601BEC0 RID: 114368 RVA: 0x0088C567 File Offset: 0x0088A967
		public static uint ReverseBytes(uint input)
		{
			return (input & 255U) << 24 | (input & 65280U) << 8 | (input & 16711680U) >> 8 | (input & 4278190080U) >> 24;
		}

		// Token: 0x0601BEC1 RID: 114369 RVA: 0x0088C594 File Offset: 0x0088A994
		public static ulong ReverseBytes(ulong input)
		{
			return (input & 255UL) << 56 | (input & 65280UL) << 40 | (input & 16711680UL) << 24 | (input & (ulong)-16777216) << 8 | (input & 1095216660480UL) >> 8 | (input & 280375465082880UL) >> 24 | (input & 71776119061217280UL) >> 40 | (input & 18374686479671623680UL) >> 56;
		}

		// Token: 0x0601BEC2 RID: 114370 RVA: 0x0088C60C File Offset: 0x0088AA0C
		protected void WriteLittleEndian(int offset, int count, ulong data)
		{
			if (BitConverter.IsLittleEndian)
			{
				for (int i = 0; i < count; i++)
				{
					this._buffer[offset + i] = (byte)(data >> i * 8);
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					this._buffer[offset + count - 1 - j] = (byte)(data >> j * 8);
				}
			}
		}

		// Token: 0x0601BEC3 RID: 114371 RVA: 0x0088C678 File Offset: 0x0088AA78
		protected ulong ReadLittleEndian(int offset, int count)
		{
			this.AssertOffsetAndLength(offset, count);
			ulong num = 0UL;
			if (BitConverter.IsLittleEndian)
			{
				for (int i = 0; i < count; i++)
				{
					num |= (ulong)this._buffer[offset + i] << i * 8;
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					num |= (ulong)this._buffer[offset + count - 1 - j] << j * 8;
				}
			}
			return num;
		}

		// Token: 0x0601BEC4 RID: 114372 RVA: 0x0088C6F2 File Offset: 0x0088AAF2
		private void AssertOffsetAndLength(int offset, int length)
		{
			if (offset < 0 || offset > this._buffer.Length - length)
			{
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x0601BEC5 RID: 114373 RVA: 0x0088C711 File Offset: 0x0088AB11
		public void PutSbyte(int offset, sbyte value)
		{
			this.AssertOffsetAndLength(offset, 1);
			this._buffer[offset] = (byte)value;
		}

		// Token: 0x0601BEC6 RID: 114374 RVA: 0x0088C725 File Offset: 0x0088AB25
		public void PutByte(int offset, byte value)
		{
			this.AssertOffsetAndLength(offset, 1);
			this._buffer[offset] = value;
		}

		// Token: 0x0601BEC7 RID: 114375 RVA: 0x0088C738 File Offset: 0x0088AB38
		public void PutByte(int offset, byte value, int count)
		{
			this.AssertOffsetAndLength(offset, count);
			for (int i = 0; i < count; i++)
			{
				this._buffer[offset + i] = value;
			}
		}

		// Token: 0x0601BEC8 RID: 114376 RVA: 0x0088C76A File Offset: 0x0088AB6A
		public void Put(int offset, byte value)
		{
			this.PutByte(offset, value);
		}

		// Token: 0x0601BEC9 RID: 114377 RVA: 0x0088C774 File Offset: 0x0088AB74
		public void PutShort(int offset, short value)
		{
			this.AssertOffsetAndLength(offset, 2);
			this.WriteLittleEndian(offset, 2, (ulong)((long)value));
		}

		// Token: 0x0601BECA RID: 114378 RVA: 0x0088C788 File Offset: 0x0088AB88
		public void PutUshort(int offset, ushort value)
		{
			this.AssertOffsetAndLength(offset, 2);
			this.WriteLittleEndian(offset, 2, (ulong)value);
		}

		// Token: 0x0601BECB RID: 114379 RVA: 0x0088C79C File Offset: 0x0088AB9C
		public void PutInt(int offset, int value)
		{
			this.AssertOffsetAndLength(offset, 4);
			this.WriteLittleEndian(offset, 4, (ulong)((long)value));
		}

		// Token: 0x0601BECC RID: 114380 RVA: 0x0088C7B0 File Offset: 0x0088ABB0
		public void PutUint(int offset, uint value)
		{
			this.AssertOffsetAndLength(offset, 4);
			this.WriteLittleEndian(offset, 4, (ulong)value);
		}

		// Token: 0x0601BECD RID: 114381 RVA: 0x0088C7C4 File Offset: 0x0088ABC4
		public void PutLong(int offset, long value)
		{
			this.AssertOffsetAndLength(offset, 8);
			this.WriteLittleEndian(offset, 8, (ulong)value);
		}

		// Token: 0x0601BECE RID: 114382 RVA: 0x0088C7D7 File Offset: 0x0088ABD7
		public void PutUlong(int offset, ulong value)
		{
			this.AssertOffsetAndLength(offset, 8);
			this.WriteLittleEndian(offset, 8, value);
		}

		// Token: 0x0601BECF RID: 114383 RVA: 0x0088C7EA File Offset: 0x0088ABEA
		public void PutFloat(int offset, float value)
		{
			this.AssertOffsetAndLength(offset, 4);
			this.floathelper[0] = value;
			Buffer.BlockCopy(this.floathelper, 0, this.inthelper, 0, 4);
			this.WriteLittleEndian(offset, 4, (ulong)((long)this.inthelper[0]));
		}

		// Token: 0x0601BED0 RID: 114384 RVA: 0x0088C822 File Offset: 0x0088AC22
		public void PutDouble(int offset, double value)
		{
			this.AssertOffsetAndLength(offset, 8);
			this.doublehelper[0] = value;
			Buffer.BlockCopy(this.doublehelper, 0, this.ulonghelper, 0, 8);
			this.WriteLittleEndian(offset, 8, this.ulonghelper[0]);
		}

		// Token: 0x0601BED1 RID: 114385 RVA: 0x0088C859 File Offset: 0x0088AC59
		public sbyte GetSbyte(int index)
		{
			this.AssertOffsetAndLength(index, 1);
			return (sbyte)this._buffer[index];
		}

		// Token: 0x0601BED2 RID: 114386 RVA: 0x0088C86C File Offset: 0x0088AC6C
		public byte Get(int index)
		{
			this.AssertOffsetAndLength(index, 1);
			return this._buffer[index];
		}

		// Token: 0x0601BED3 RID: 114387 RVA: 0x0088C87E File Offset: 0x0088AC7E
		public short GetShort(int index)
		{
			return (short)this.ReadLittleEndian(index, 2);
		}

		// Token: 0x0601BED4 RID: 114388 RVA: 0x0088C889 File Offset: 0x0088AC89
		public ushort GetUshort(int index)
		{
			return (ushort)this.ReadLittleEndian(index, 2);
		}

		// Token: 0x0601BED5 RID: 114389 RVA: 0x0088C894 File Offset: 0x0088AC94
		public int GetInt(int index)
		{
			return (int)this.ReadLittleEndian(index, 4);
		}

		// Token: 0x0601BED6 RID: 114390 RVA: 0x0088C89F File Offset: 0x0088AC9F
		public uint GetUint(int index)
		{
			return (uint)this.ReadLittleEndian(index, 4);
		}

		// Token: 0x0601BED7 RID: 114391 RVA: 0x0088C8AA File Offset: 0x0088ACAA
		public long GetLong(int index)
		{
			return (long)this.ReadLittleEndian(index, 8);
		}

		// Token: 0x0601BED8 RID: 114392 RVA: 0x0088C8B4 File Offset: 0x0088ACB4
		public ulong GetUlong(int index)
		{
			return this.ReadLittleEndian(index, 8);
		}

		// Token: 0x0601BED9 RID: 114393 RVA: 0x0088C8C0 File Offset: 0x0088ACC0
		public float GetFloat(int index)
		{
			int num = (int)this.ReadLittleEndian(index, 4);
			this.inthelper[0] = num;
			Buffer.BlockCopy(this.inthelper, 0, this.floathelper, 0, 4);
			return this.floathelper[0];
		}

		// Token: 0x0601BEDA RID: 114394 RVA: 0x0088C8FC File Offset: 0x0088ACFC
		public double GetDouble(int index)
		{
			ulong num = this.ReadLittleEndian(index, 8);
			this.ulonghelper[0] = num;
			Buffer.BlockCopy(this.ulonghelper, 0, this.doublehelper, 0, 8);
			return this.doublehelper[0];
		}

		// Token: 0x04013790 RID: 79760
		private readonly byte[] _buffer;

		// Token: 0x04013791 RID: 79761
		private int _pos;

		// Token: 0x04013792 RID: 79762
		private float[] floathelper = new float[1];

		// Token: 0x04013793 RID: 79763
		private int[] inthelper = new int[1];

		// Token: 0x04013794 RID: 79764
		private double[] doublehelper = new double[1];

		// Token: 0x04013795 RID: 79765
		private ulong[] ulonghelper = new ulong[1];
	}
}
