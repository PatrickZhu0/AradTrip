using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005C1 RID: 1473
	public class SkillPreTable : IFlatbufferObject
	{
		// Token: 0x17001516 RID: 5398
		// (get) Token: 0x06004D1F RID: 19743 RVA: 0x000F09FC File Offset: 0x000EEDFC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004D20 RID: 19744 RVA: 0x000F0A09 File Offset: 0x000EEE09
		public static SkillPreTable GetRootAsSkillPreTable(ByteBuffer _bb)
		{
			return SkillPreTable.GetRootAsSkillPreTable(_bb, new SkillPreTable());
		}

		// Token: 0x06004D21 RID: 19745 RVA: 0x000F0A16 File Offset: 0x000EEE16
		public static SkillPreTable GetRootAsSkillPreTable(ByteBuffer _bb, SkillPreTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004D22 RID: 19746 RVA: 0x000F0A32 File Offset: 0x000EEE32
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004D23 RID: 19747 RVA: 0x000F0A4C File Offset: 0x000EEE4C
		public SkillPreTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001517 RID: 5399
		// (get) Token: 0x06004D24 RID: 19748 RVA: 0x000F0A58 File Offset: 0x000EEE58
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1695312336 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001518 RID: 5400
		// (get) Token: 0x06004D25 RID: 19749 RVA: 0x000F0AA4 File Offset: 0x000EEEA4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004D26 RID: 19750 RVA: 0x000F0AE6 File Offset: 0x000EEEE6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06004D27 RID: 19751 RVA: 0x000F0AF4 File Offset: 0x000EEEF4
		public int InfoIDArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (1695312336 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001519 RID: 5401
		// (get) Token: 0x06004D28 RID: 19752 RVA: 0x000F0B40 File Offset: 0x000EEF40
		public int InfoIDLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D29 RID: 19753 RVA: 0x000F0B72 File Offset: 0x000EEF72
		public ArraySegment<byte>? GetInfoIDBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700151A RID: 5402
		// (get) Token: 0x06004D2A RID: 19754 RVA: 0x000F0B80 File Offset: 0x000EEF80
		public FlatBufferArray<int> InfoID
		{
			get
			{
				if (this.InfoIDValue == null)
				{
					this.InfoIDValue = new FlatBufferArray<int>(new Func<int, int>(this.InfoIDArray), this.InfoIDLength);
				}
				return this.InfoIDValue;
			}
		}

		// Token: 0x06004D2B RID: 19755 RVA: 0x000F0BB0 File Offset: 0x000EEFB0
		public int LocalInfoIDArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (1695312336 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700151B RID: 5403
		// (get) Token: 0x06004D2C RID: 19756 RVA: 0x000F0C00 File Offset: 0x000EF000
		public int LocalInfoIDLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D2D RID: 19757 RVA: 0x000F0C33 File Offset: 0x000EF033
		public ArraySegment<byte>? GetLocalInfoIDBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700151C RID: 5404
		// (get) Token: 0x06004D2E RID: 19758 RVA: 0x000F0C42 File Offset: 0x000EF042
		public FlatBufferArray<int> LocalInfoID
		{
			get
			{
				if (this.LocalInfoIDValue == null)
				{
					this.LocalInfoIDValue = new FlatBufferArray<int>(new Func<int, int>(this.LocalInfoIDArray), this.LocalInfoIDLength);
				}
				return this.LocalInfoIDValue;
			}
		}

		// Token: 0x06004D2F RID: 19759 RVA: 0x000F0C72 File Offset: 0x000EF072
		public static Offset<SkillPreTable> CreateSkillPreTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), VectorOffset InfoIDOffset = default(VectorOffset), VectorOffset LocalInfoIDOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			SkillPreTable.AddLocalInfoID(builder, LocalInfoIDOffset);
			SkillPreTable.AddInfoID(builder, InfoIDOffset);
			SkillPreTable.AddName(builder, NameOffset);
			SkillPreTable.AddID(builder, ID);
			return SkillPreTable.EndSkillPreTable(builder);
		}

		// Token: 0x06004D30 RID: 19760 RVA: 0x000F0C9E File Offset: 0x000EF09E
		public static void StartSkillPreTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06004D31 RID: 19761 RVA: 0x000F0CA7 File Offset: 0x000EF0A7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004D32 RID: 19762 RVA: 0x000F0CB2 File Offset: 0x000EF0B2
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004D33 RID: 19763 RVA: 0x000F0CC3 File Offset: 0x000EF0C3
		public static void AddInfoID(FlatBufferBuilder builder, VectorOffset InfoIDOffset)
		{
			builder.AddOffset(2, InfoIDOffset.Value, 0);
		}

		// Token: 0x06004D34 RID: 19764 RVA: 0x000F0CD4 File Offset: 0x000EF0D4
		public static VectorOffset CreateInfoIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004D35 RID: 19765 RVA: 0x000F0D11 File Offset: 0x000EF111
		public static void StartInfoIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004D36 RID: 19766 RVA: 0x000F0D1C File Offset: 0x000EF11C
		public static void AddLocalInfoID(FlatBufferBuilder builder, VectorOffset LocalInfoIDOffset)
		{
			builder.AddOffset(3, LocalInfoIDOffset.Value, 0);
		}

		// Token: 0x06004D37 RID: 19767 RVA: 0x000F0D30 File Offset: 0x000EF130
		public static VectorOffset CreateLocalInfoIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004D38 RID: 19768 RVA: 0x000F0D6D File Offset: 0x000EF16D
		public static void StartLocalInfoIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004D39 RID: 19769 RVA: 0x000F0D78 File Offset: 0x000EF178
		public static Offset<SkillPreTable> EndSkillPreTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SkillPreTable>(value);
		}

		// Token: 0x06004D3A RID: 19770 RVA: 0x000F0D92 File Offset: 0x000EF192
		public static void FinishSkillPreTableBuffer(FlatBufferBuilder builder, Offset<SkillPreTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B89 RID: 7049
		private Table __p = new Table();

		// Token: 0x04001B8A RID: 7050
		private FlatBufferArray<int> InfoIDValue;

		// Token: 0x04001B8B RID: 7051
		private FlatBufferArray<int> LocalInfoIDValue;

		// Token: 0x020005C2 RID: 1474
		public enum eCrypt
		{
			// Token: 0x04001B8D RID: 7053
			code = 1695312336
		}
	}
}
