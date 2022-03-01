using System;
using System.Text;

namespace FlatBuffers
{
	// Token: 0x02004B46 RID: 19270
	public class FlatBufferBuilder
	{
		// Token: 0x0601C4E4 RID: 115940 RVA: 0x0089B0F4 File Offset: 0x008994F4
		public FlatBufferBuilder(int initialSize)
		{
			if (initialSize <= 0)
			{
				throw new ArgumentOutOfRangeException("initialSize", initialSize, "Must be greater than zero");
			}
			this._space = initialSize;
			this._bb = new ByteBuffer(new byte[initialSize]);
		}

		// Token: 0x0601C4E5 RID: 115941 RVA: 0x0089B164 File Offset: 0x00899564
		public void Clear()
		{
			this._space = this._bb.Length;
			this._bb.Reset();
			this._minAlign = 1;
			while (this._vtableSize > 0)
			{
				this._vtable[--this._vtableSize] = 0;
			}
			this._vtableSize = -1;
			this._objectStart = 0;
			this._numVtables = 0;
			this._vectorNumElems = 0;
		}

		// Token: 0x170027D4 RID: 10196
		// (get) Token: 0x0601C4E6 RID: 115942 RVA: 0x0089B1DA File Offset: 0x008995DA
		// (set) Token: 0x0601C4E7 RID: 115943 RVA: 0x0089B1E2 File Offset: 0x008995E2
		public bool ForceDefaults { get; set; }

		// Token: 0x170027D5 RID: 10197
		// (get) Token: 0x0601C4E8 RID: 115944 RVA: 0x0089B1EB File Offset: 0x008995EB
		public int Offset
		{
			get
			{
				return this._bb.Length - this._space;
			}
		}

		// Token: 0x0601C4E9 RID: 115945 RVA: 0x0089B200 File Offset: 0x00899600
		public void Pad(int size)
		{
			this._bb.PutByte(this._space -= size, 0, size);
		}

		// Token: 0x0601C4EA RID: 115946 RVA: 0x0089B22C File Offset: 0x0089962C
		private void GrowBuffer()
		{
			byte[] data = this._bb.Data;
			int num = data.Length;
			if (((long)num & (long)((ulong)-1073741824)) != 0L)
			{
				throw new Exception("FlatBuffers: cannot grow buffer beyond 2 gigabytes.");
			}
			int num2 = num << 1;
			byte[] array = new byte[num2];
			Buffer.BlockCopy(data, 0, array, num2 - num, num);
			this._bb = new ByteBuffer(array, num2);
		}

		// Token: 0x0601C4EB RID: 115947 RVA: 0x0089B288 File Offset: 0x00899688
		public void Prep(int size, int additionalBytes)
		{
			if (size > this._minAlign)
			{
				this._minAlign = size;
			}
			int num = ~(this._bb.Length - this._space + additionalBytes) + 1 & size - 1;
			while (this._space < num + size + additionalBytes)
			{
				int length = this._bb.Length;
				this.GrowBuffer();
				this._space += this._bb.Length - length;
			}
			if (num > 0)
			{
				this.Pad(num);
			}
		}

		// Token: 0x0601C4EC RID: 115948 RVA: 0x0089B314 File Offset: 0x00899714
		public void PutBool(bool x)
		{
			this._bb.PutByte(--this._space, (!x) ? 0 : 1);
		}

		// Token: 0x0601C4ED RID: 115949 RVA: 0x0089B34C File Offset: 0x0089974C
		public void PutSbyte(sbyte x)
		{
			this._bb.PutSbyte(--this._space, x);
		}

		// Token: 0x0601C4EE RID: 115950 RVA: 0x0089B378 File Offset: 0x00899778
		public void PutByte(byte x)
		{
			this._bb.PutByte(--this._space, x);
		}

		// Token: 0x0601C4EF RID: 115951 RVA: 0x0089B3A4 File Offset: 0x008997A4
		public void PutShort(short x)
		{
			this._bb.PutShort(this._space -= 2, x);
		}

		// Token: 0x0601C4F0 RID: 115952 RVA: 0x0089B3D0 File Offset: 0x008997D0
		public void PutUshort(ushort x)
		{
			this._bb.PutUshort(this._space -= 2, x);
		}

		// Token: 0x0601C4F1 RID: 115953 RVA: 0x0089B3FC File Offset: 0x008997FC
		public void PutInt(int x)
		{
			this._bb.PutInt(this._space -= 4, x);
		}

		// Token: 0x0601C4F2 RID: 115954 RVA: 0x0089B428 File Offset: 0x00899828
		public void PutUint(uint x)
		{
			this._bb.PutUint(this._space -= 4, x);
		}

		// Token: 0x0601C4F3 RID: 115955 RVA: 0x0089B454 File Offset: 0x00899854
		public void PutLong(long x)
		{
			this._bb.PutLong(this._space -= 8, x);
		}

		// Token: 0x0601C4F4 RID: 115956 RVA: 0x0089B480 File Offset: 0x00899880
		public void PutUlong(ulong x)
		{
			this._bb.PutUlong(this._space -= 8, x);
		}

		// Token: 0x0601C4F5 RID: 115957 RVA: 0x0089B4AC File Offset: 0x008998AC
		public void PutFloat(float x)
		{
			this._bb.PutFloat(this._space -= 4, x);
		}

		// Token: 0x0601C4F6 RID: 115958 RVA: 0x0089B4D8 File Offset: 0x008998D8
		public void PutDouble(double x)
		{
			this._bb.PutDouble(this._space -= 8, x);
		}

		// Token: 0x0601C4F7 RID: 115959 RVA: 0x0089B502 File Offset: 0x00899902
		public void AddBool(bool x)
		{
			this.Prep(1, 0);
			this.PutBool(x);
		}

		// Token: 0x0601C4F8 RID: 115960 RVA: 0x0089B513 File Offset: 0x00899913
		public void AddSbyte(sbyte x)
		{
			this.Prep(1, 0);
			this.PutSbyte(x);
		}

		// Token: 0x0601C4F9 RID: 115961 RVA: 0x0089B524 File Offset: 0x00899924
		public void AddByte(byte x)
		{
			this.Prep(1, 0);
			this.PutByte(x);
		}

		// Token: 0x0601C4FA RID: 115962 RVA: 0x0089B535 File Offset: 0x00899935
		public void AddShort(short x)
		{
			this.Prep(2, 0);
			this.PutShort(x);
		}

		// Token: 0x0601C4FB RID: 115963 RVA: 0x0089B546 File Offset: 0x00899946
		public void AddUshort(ushort x)
		{
			this.Prep(2, 0);
			this.PutUshort(x);
		}

		// Token: 0x0601C4FC RID: 115964 RVA: 0x0089B557 File Offset: 0x00899957
		public void AddInt(int x)
		{
			this.Prep(4, 0);
			this.PutInt(x);
		}

		// Token: 0x0601C4FD RID: 115965 RVA: 0x0089B568 File Offset: 0x00899968
		public void AddUint(uint x)
		{
			this.Prep(4, 0);
			this.PutUint(x);
		}

		// Token: 0x0601C4FE RID: 115966 RVA: 0x0089B579 File Offset: 0x00899979
		public void AddLong(long x)
		{
			this.Prep(8, 0);
			this.PutLong(x);
		}

		// Token: 0x0601C4FF RID: 115967 RVA: 0x0089B58A File Offset: 0x0089998A
		public void AddUlong(ulong x)
		{
			this.Prep(8, 0);
			this.PutUlong(x);
		}

		// Token: 0x0601C500 RID: 115968 RVA: 0x0089B59B File Offset: 0x0089999B
		public void AddFloat(float x)
		{
			this.Prep(4, 0);
			this.PutFloat(x);
		}

		// Token: 0x0601C501 RID: 115969 RVA: 0x0089B5AC File Offset: 0x008999AC
		public void AddDouble(double x)
		{
			this.Prep(8, 0);
			this.PutDouble(x);
		}

		// Token: 0x0601C502 RID: 115970 RVA: 0x0089B5BD File Offset: 0x008999BD
		public void AddOffset(int off)
		{
			this.Prep(4, 0);
			if (off > this.Offset)
			{
				throw new ArgumentException();
			}
			off = this.Offset - off + 4;
			this.PutInt(off);
		}

		// Token: 0x0601C503 RID: 115971 RVA: 0x0089B5EC File Offset: 0x008999EC
		public void StartVector(int elemSize, int count, int alignment)
		{
			this.NotNested();
			this._vectorNumElems = count;
			this.Prep(4, elemSize * count);
			this.Prep(alignment, elemSize * count);
		}

		// Token: 0x0601C504 RID: 115972 RVA: 0x0089B60F File Offset: 0x00899A0F
		public VectorOffset EndVector()
		{
			this.PutInt(this._vectorNumElems);
			return new VectorOffset(this.Offset);
		}

		// Token: 0x0601C505 RID: 115973 RVA: 0x0089B628 File Offset: 0x00899A28
		public void Nested(int obj)
		{
			if (obj != this.Offset)
			{
				throw new Exception("FlatBuffers: struct must be serialized inline.");
			}
		}

		// Token: 0x0601C506 RID: 115974 RVA: 0x0089B641 File Offset: 0x00899A41
		public void NotNested()
		{
			if (this._vtableSize >= 0)
			{
				throw new Exception("FlatBuffers: object serialization must not be nested.");
			}
		}

		// Token: 0x0601C507 RID: 115975 RVA: 0x0089B65C File Offset: 0x00899A5C
		public void StartObject(int numfields)
		{
			if (numfields < 0)
			{
				throw new ArgumentOutOfRangeException("Flatbuffers: invalid numfields");
			}
			this.NotNested();
			if (this._vtable.Length < numfields)
			{
				this._vtable = new int[numfields];
			}
			this._vtableSize = numfields;
			this._objectStart = this.Offset;
		}

		// Token: 0x0601C508 RID: 115976 RVA: 0x0089B6AE File Offset: 0x00899AAE
		public void Slot(int voffset)
		{
			if (voffset >= this._vtableSize)
			{
				throw new IndexOutOfRangeException("Flatbuffers: invalid voffset");
			}
			this._vtable[voffset] = this.Offset;
		}

		// Token: 0x0601C509 RID: 115977 RVA: 0x0089B6D5 File Offset: 0x00899AD5
		public void AddBool(int o, bool x, bool d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddBool(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C50A RID: 115978 RVA: 0x0089B6F7 File Offset: 0x00899AF7
		public void AddSbyte(int o, sbyte x, sbyte d)
		{
			if (this.ForceDefaults || (int)x != (int)d)
			{
				this.AddSbyte(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C50B RID: 115979 RVA: 0x0089B71B File Offset: 0x00899B1B
		public void AddByte(int o, byte x, byte d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddByte(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C50C RID: 115980 RVA: 0x0089B73D File Offset: 0x00899B3D
		public void AddShort(int o, short x, int d)
		{
			if (this.ForceDefaults || (int)x != d)
			{
				this.AddShort(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C50D RID: 115981 RVA: 0x0089B75F File Offset: 0x00899B5F
		public void AddUshort(int o, ushort x, ushort d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddUshort(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C50E RID: 115982 RVA: 0x0089B781 File Offset: 0x00899B81
		public void AddInt(int o, int x, int d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddInt(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C50F RID: 115983 RVA: 0x0089B7A3 File Offset: 0x00899BA3
		public void AddUint(int o, uint x, uint d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddUint(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C510 RID: 115984 RVA: 0x0089B7C5 File Offset: 0x00899BC5
		public void AddLong(int o, long x, long d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddLong(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C511 RID: 115985 RVA: 0x0089B7E7 File Offset: 0x00899BE7
		public void AddUlong(int o, ulong x, ulong d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddUlong(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C512 RID: 115986 RVA: 0x0089B809 File Offset: 0x00899C09
		public void AddFloat(int o, float x, double d)
		{
			if (this.ForceDefaults || (double)x != d)
			{
				this.AddFloat(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C513 RID: 115987 RVA: 0x0089B82C File Offset: 0x00899C2C
		public void AddDouble(int o, double x, double d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddDouble(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C514 RID: 115988 RVA: 0x0089B84E File Offset: 0x00899C4E
		public void AddOffset(int o, int x, int d)
		{
			if (this.ForceDefaults || x != d)
			{
				this.AddOffset(x);
				this.Slot(o);
			}
		}

		// Token: 0x0601C515 RID: 115989 RVA: 0x0089B870 File Offset: 0x00899C70
		public StringOffset CreateString(string s)
		{
			this.NotNested();
			this.AddByte(0);
			int byteCount = Encoding.UTF8.GetByteCount(s);
			this.StartVector(1, byteCount, 1);
			Encoding.UTF8.GetBytes(s, 0, s.Length, this._bb.Data, this._space -= byteCount);
			return new StringOffset(this.EndVector().Value);
		}

		// Token: 0x0601C516 RID: 115990 RVA: 0x0089B8E1 File Offset: 0x00899CE1
		public void AddStruct(int voffset, int x, int d)
		{
			if (x != d)
			{
				this.Nested(x);
				this.Slot(voffset);
			}
		}

		// Token: 0x0601C517 RID: 115991 RVA: 0x0089B8F8 File Offset: 0x00899CF8
		public int EndObject()
		{
			if (this._vtableSize < 0)
			{
				throw new InvalidOperationException("Flatbuffers: calling endObject without a startObject");
			}
			this.AddInt(0);
			int offset = this.Offset;
			int i = this._vtableSize - 1;
			while (i >= 0 && this._vtable[i] == 0)
			{
				i--;
			}
			int num = i + 1;
			while (i >= 0)
			{
				short x = (short)((this._vtable[i] == 0) ? 0 : (offset - this._vtable[i]));
				this.AddShort(x);
				this._vtable[i] = 0;
				i--;
			}
			this.AddShort((short)(offset - this._objectStart));
			this.AddShort((short)((num + 2) * 2));
			int num2 = 0;
			for (i = 0; i < this._numVtables; i++)
			{
				int num3 = this._bb.Length - this._vtables[i];
				int space = this._space;
				short @short = this._bb.GetShort(num3);
				if (@short == this._bb.GetShort(space))
				{
					for (int j = 2; j < (int)@short; j += 2)
					{
						if (this._bb.GetShort(num3 + j) != this._bb.GetShort(space + j))
						{
							goto IL_144;
						}
					}
					num2 = this._vtables[i];
					break;
				}
				IL_144:;
			}
			if (num2 != 0)
			{
				this._space = this._bb.Length - offset;
				this._bb.PutInt(this._space, num2 - offset);
			}
			else
			{
				if (this._numVtables == this._vtables.Length)
				{
					int[] array = new int[this._numVtables * 2];
					Array.Copy(this._vtables, array, this._vtables.Length);
					this._vtables = array;
				}
				this._vtables[this._numVtables++] = this.Offset;
				this._bb.PutInt(this._bb.Length - offset, this.Offset - offset);
			}
			this._vtableSize = -1;
			return offset;
		}

		// Token: 0x0601C518 RID: 115992 RVA: 0x0089BB14 File Offset: 0x00899F14
		public void Required(int table, int field)
		{
			int num = this._bb.Length - table;
			int num2 = num - this._bb.GetInt(num);
			if (this._bb.GetShort(num2 + field) == 0)
			{
				throw new InvalidOperationException("FlatBuffers: field " + field + " must be set");
			}
		}

		// Token: 0x0601C519 RID: 115993 RVA: 0x0089BB74 File Offset: 0x00899F74
		public void Finish(int rootTable)
		{
			this.Prep(this._minAlign, 4);
			this.AddOffset(rootTable);
			this._bb.Position = this._space;
		}

		// Token: 0x170027D6 RID: 10198
		// (get) Token: 0x0601C51A RID: 115994 RVA: 0x0089BB9B File Offset: 0x00899F9B
		public ByteBuffer DataBuffer
		{
			get
			{
				return this._bb;
			}
		}

		// Token: 0x0601C51B RID: 115995 RVA: 0x0089BBA4 File Offset: 0x00899FA4
		public byte[] SizedByteArray()
		{
			byte[] array = new byte[this._bb.Data.Length - this._bb.Position];
			Buffer.BlockCopy(this._bb.Data, this._bb.Position, array, 0, this._bb.Data.Length - this._bb.Position);
			return array;
		}

		// Token: 0x0601C51C RID: 115996 RVA: 0x0089BC08 File Offset: 0x0089A008
		public void Finish(int rootTable, string fileIdentifier)
		{
			this.Prep(this._minAlign, 8);
			if (fileIdentifier.Length != 4)
			{
				throw new ArgumentException("FlatBuffers: file identifier must be length " + 4, "fileIdentifier");
			}
			for (int i = 3; i >= 0; i--)
			{
				this.AddByte((byte)fileIdentifier[i]);
			}
			this.Finish(rootTable);
		}

		// Token: 0x040137D2 RID: 79826
		private int _space;

		// Token: 0x040137D3 RID: 79827
		private ByteBuffer _bb;

		// Token: 0x040137D4 RID: 79828
		private int _minAlign = 1;

		// Token: 0x040137D5 RID: 79829
		private int[] _vtable = new int[16];

		// Token: 0x040137D6 RID: 79830
		private int _vtableSize = -1;

		// Token: 0x040137D7 RID: 79831
		private int _objectStart;

		// Token: 0x040137D8 RID: 79832
		private int[] _vtables = new int[16];

		// Token: 0x040137D9 RID: 79833
		private int _numVtables;

		// Token: 0x040137DA RID: 79834
		private int _vectorNumElems;
	}
}
