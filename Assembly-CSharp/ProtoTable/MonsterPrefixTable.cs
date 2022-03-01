using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200051A RID: 1306
	public class MonsterPrefixTable : IFlatbufferObject
	{
		// Token: 0x170011E3 RID: 4579
		// (get) Token: 0x0600432C RID: 17196 RVA: 0x000DA10C File Offset: 0x000D850C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600432D RID: 17197 RVA: 0x000DA119 File Offset: 0x000D8519
		public static MonsterPrefixTable GetRootAsMonsterPrefixTable(ByteBuffer _bb)
		{
			return MonsterPrefixTable.GetRootAsMonsterPrefixTable(_bb, new MonsterPrefixTable());
		}

		// Token: 0x0600432E RID: 17198 RVA: 0x000DA126 File Offset: 0x000D8526
		public static MonsterPrefixTable GetRootAsMonsterPrefixTable(ByteBuffer _bb, MonsterPrefixTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600432F RID: 17199 RVA: 0x000DA142 File Offset: 0x000D8542
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004330 RID: 17200 RVA: 0x000DA15C File Offset: 0x000D855C
		public MonsterPrefixTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011E4 RID: 4580
		// (get) Token: 0x06004331 RID: 17201 RVA: 0x000DA168 File Offset: 0x000D8568
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1718048358 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011E5 RID: 4581
		// (get) Token: 0x06004332 RID: 17202 RVA: 0x000DA1B4 File Offset: 0x000D85B4
		public int type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1718048358 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011E6 RID: 4582
		// (get) Token: 0x06004333 RID: 17203 RVA: 0x000DA200 File Offset: 0x000D8600
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004334 RID: 17204 RVA: 0x000DA242 File Offset: 0x000D8642
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06004335 RID: 17205 RVA: 0x000DA250 File Offset: 0x000D8650
		public int BufferInfoIDArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1718048358 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170011E7 RID: 4583
		// (get) Token: 0x06004336 RID: 17206 RVA: 0x000DA2A0 File Offset: 0x000D86A0
		public int BufferInfoIDLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004337 RID: 17207 RVA: 0x000DA2D3 File Offset: 0x000D86D3
		public ArraySegment<byte>? GetBufferInfoIDBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170011E8 RID: 4584
		// (get) Token: 0x06004338 RID: 17208 RVA: 0x000DA2E2 File Offset: 0x000D86E2
		public FlatBufferArray<int> BufferInfoID
		{
			get
			{
				if (this.BufferInfoIDValue == null)
				{
					this.BufferInfoIDValue = new FlatBufferArray<int>(new Func<int, int>(this.BufferInfoIDArray), this.BufferInfoIDLength);
				}
				return this.BufferInfoIDValue;
			}
		}

		// Token: 0x06004339 RID: 17209 RVA: 0x000DA312 File Offset: 0x000D8712
		public static Offset<MonsterPrefixTable> CreateMonsterPrefixTable(FlatBufferBuilder builder, int ID = 0, int type = 0, StringOffset NameOffset = default(StringOffset), VectorOffset BufferInfoIDOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			MonsterPrefixTable.AddBufferInfoID(builder, BufferInfoIDOffset);
			MonsterPrefixTable.AddName(builder, NameOffset);
			MonsterPrefixTable.AddType(builder, type);
			MonsterPrefixTable.AddID(builder, ID);
			return MonsterPrefixTable.EndMonsterPrefixTable(builder);
		}

		// Token: 0x0600433A RID: 17210 RVA: 0x000DA33E File Offset: 0x000D873E
		public static void StartMonsterPrefixTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0600433B RID: 17211 RVA: 0x000DA347 File Offset: 0x000D8747
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600433C RID: 17212 RVA: 0x000DA352 File Offset: 0x000D8752
		public static void AddType(FlatBufferBuilder builder, int type)
		{
			builder.AddInt(1, type, 0);
		}

		// Token: 0x0600433D RID: 17213 RVA: 0x000DA35D File Offset: 0x000D875D
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x0600433E RID: 17214 RVA: 0x000DA36E File Offset: 0x000D876E
		public static void AddBufferInfoID(FlatBufferBuilder builder, VectorOffset BufferInfoIDOffset)
		{
			builder.AddOffset(3, BufferInfoIDOffset.Value, 0);
		}

		// Token: 0x0600433F RID: 17215 RVA: 0x000DA380 File Offset: 0x000D8780
		public static VectorOffset CreateBufferInfoIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004340 RID: 17216 RVA: 0x000DA3BD File Offset: 0x000D87BD
		public static void StartBufferInfoIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004341 RID: 17217 RVA: 0x000DA3C8 File Offset: 0x000D87C8
		public static Offset<MonsterPrefixTable> EndMonsterPrefixTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonsterPrefixTable>(value);
		}

		// Token: 0x06004342 RID: 17218 RVA: 0x000DA3E2 File Offset: 0x000D87E2
		public static void FinishMonsterPrefixTableBuffer(FlatBufferBuilder builder, Offset<MonsterPrefixTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018E3 RID: 6371
		private Table __p = new Table();

		// Token: 0x040018E4 RID: 6372
		private FlatBufferArray<int> BufferInfoIDValue;

		// Token: 0x0200051B RID: 1307
		public enum eCrypt
		{
			// Token: 0x040018E6 RID: 6374
			code = -1718048358
		}
	}
}
