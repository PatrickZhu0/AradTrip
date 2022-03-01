using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200038D RID: 909
	public class DropSmellControlTable : IFlatbufferObject
	{
		// Token: 0x170008BE RID: 2238
		// (get) Token: 0x06002765 RID: 10085 RVA: 0x00097B50 File Offset: 0x00095F50
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002766 RID: 10086 RVA: 0x00097B5D File Offset: 0x00095F5D
		public static DropSmellControlTable GetRootAsDropSmellControlTable(ByteBuffer _bb)
		{
			return DropSmellControlTable.GetRootAsDropSmellControlTable(_bb, new DropSmellControlTable());
		}

		// Token: 0x06002767 RID: 10087 RVA: 0x00097B6A File Offset: 0x00095F6A
		public static DropSmellControlTable GetRootAsDropSmellControlTable(ByteBuffer _bb, DropSmellControlTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002768 RID: 10088 RVA: 0x00097B86 File Offset: 0x00095F86
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002769 RID: 10089 RVA: 0x00097BA0 File Offset: 0x00095FA0
		public DropSmellControlTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008BF RID: 2239
		// (get) Token: 0x0600276A RID: 10090 RVA: 0x00097BAC File Offset: 0x00095FAC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x0600276B RID: 10091 RVA: 0x00097BF8 File Offset: 0x00095FF8
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008C1 RID: 2241
		// (get) Token: 0x0600276C RID: 10092 RVA: 0x00097C44 File Offset: 0x00096044
		public int Lv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008C2 RID: 2242
		// (get) Token: 0x0600276D RID: 10093 RVA: 0x00097C90 File Offset: 0x00096090
		public int Color
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x0600276E RID: 10094 RVA: 0x00097CDC File Offset: 0x000960DC
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600276F RID: 10095 RVA: 0x00097D28 File Offset: 0x00096128
		public int DungeonSubTypeArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170008C4 RID: 2244
		// (get) Token: 0x06002770 RID: 10096 RVA: 0x00097D78 File Offset: 0x00096178
		public int DungeonSubTypeLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002771 RID: 10097 RVA: 0x00097DAB File Offset: 0x000961AB
		public ArraySegment<byte>? GetDungeonSubTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x06002772 RID: 10098 RVA: 0x00097DBA File Offset: 0x000961BA
		public FlatBufferArray<int> DungeonSubType
		{
			get
			{
				if (this.DungeonSubTypeValue == null)
				{
					this.DungeonSubTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.DungeonSubTypeArray), this.DungeonSubTypeLength);
				}
				return this.DungeonSubTypeValue;
			}
		}

		// Token: 0x06002773 RID: 10099 RVA: 0x00097DEC File Offset: 0x000961EC
		public int DungeonHardArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170008C6 RID: 2246
		// (get) Token: 0x06002774 RID: 10100 RVA: 0x00097E3C File Offset: 0x0009623C
		public int DungeonHardLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002775 RID: 10101 RVA: 0x00097E6F File Offset: 0x0009626F
		public ArraySegment<byte>? GetDungeonHardBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x06002776 RID: 10102 RVA: 0x00097E7E File Offset: 0x0009627E
		public FlatBufferArray<int> DungeonHard
		{
			get
			{
				if (this.DungeonHardValue == null)
				{
					this.DungeonHardValue = new FlatBufferArray<int>(new Func<int, int>(this.DungeonHardArray), this.DungeonHardLength);
				}
				return this.DungeonHardValue;
			}
		}

		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x06002777 RID: 10103 RVA: 0x00097EB0 File Offset: 0x000962B0
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x06002778 RID: 10104 RVA: 0x00097EFC File Offset: 0x000962FC
		public int Probability
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1666393919 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002779 RID: 10105 RVA: 0x00097F48 File Offset: 0x00096348
		public static Offset<DropSmellControlTable> CreateDropSmellControlTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int Lv = 0, int Color = 0, int Color2 = 0, VectorOffset DungeonSubTypeOffset = default(VectorOffset), VectorOffset DungeonHardOffset = default(VectorOffset), int DungeonID = 0, int Probability = 0)
		{
			builder.StartObject(9);
			DropSmellControlTable.AddProbability(builder, Probability);
			DropSmellControlTable.AddDungeonID(builder, DungeonID);
			DropSmellControlTable.AddDungeonHard(builder, DungeonHardOffset);
			DropSmellControlTable.AddDungeonSubType(builder, DungeonSubTypeOffset);
			DropSmellControlTable.AddColor2(builder, Color2);
			DropSmellControlTable.AddColor(builder, Color);
			DropSmellControlTable.AddLv(builder, Lv);
			DropSmellControlTable.AddType(builder, Type);
			DropSmellControlTable.AddID(builder, ID);
			return DropSmellControlTable.EndDropSmellControlTable(builder);
		}

		// Token: 0x0600277A RID: 10106 RVA: 0x00097FA8 File Offset: 0x000963A8
		public static void StartDropSmellControlTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x0600277B RID: 10107 RVA: 0x00097FB2 File Offset: 0x000963B2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600277C RID: 10108 RVA: 0x00097FBD File Offset: 0x000963BD
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x0600277D RID: 10109 RVA: 0x00097FC8 File Offset: 0x000963C8
		public static void AddLv(FlatBufferBuilder builder, int Lv)
		{
			builder.AddInt(2, Lv, 0);
		}

		// Token: 0x0600277E RID: 10110 RVA: 0x00097FD3 File Offset: 0x000963D3
		public static void AddColor(FlatBufferBuilder builder, int Color)
		{
			builder.AddInt(3, Color, 0);
		}

		// Token: 0x0600277F RID: 10111 RVA: 0x00097FDE File Offset: 0x000963DE
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(4, Color2, 0);
		}

		// Token: 0x06002780 RID: 10112 RVA: 0x00097FE9 File Offset: 0x000963E9
		public static void AddDungeonSubType(FlatBufferBuilder builder, VectorOffset DungeonSubTypeOffset)
		{
			builder.AddOffset(5, DungeonSubTypeOffset.Value, 0);
		}

		// Token: 0x06002781 RID: 10113 RVA: 0x00097FFC File Offset: 0x000963FC
		public static VectorOffset CreateDungeonSubTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002782 RID: 10114 RVA: 0x00098039 File Offset: 0x00096439
		public static void StartDungeonSubTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002783 RID: 10115 RVA: 0x00098044 File Offset: 0x00096444
		public static void AddDungeonHard(FlatBufferBuilder builder, VectorOffset DungeonHardOffset)
		{
			builder.AddOffset(6, DungeonHardOffset.Value, 0);
		}

		// Token: 0x06002784 RID: 10116 RVA: 0x00098058 File Offset: 0x00096458
		public static VectorOffset CreateDungeonHardVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002785 RID: 10117 RVA: 0x00098095 File Offset: 0x00096495
		public static void StartDungeonHardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002786 RID: 10118 RVA: 0x000980A0 File Offset: 0x000964A0
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(7, DungeonID, 0);
		}

		// Token: 0x06002787 RID: 10119 RVA: 0x000980AB File Offset: 0x000964AB
		public static void AddProbability(FlatBufferBuilder builder, int Probability)
		{
			builder.AddInt(8, Probability, 0);
		}

		// Token: 0x06002788 RID: 10120 RVA: 0x000980B8 File Offset: 0x000964B8
		public static Offset<DropSmellControlTable> EndDropSmellControlTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DropSmellControlTable>(value);
		}

		// Token: 0x06002789 RID: 10121 RVA: 0x000980D2 File Offset: 0x000964D2
		public static void FinishDropSmellControlTableBuffer(FlatBufferBuilder builder, Offset<DropSmellControlTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011C1 RID: 4545
		private Table __p = new Table();

		// Token: 0x040011C2 RID: 4546
		private FlatBufferArray<int> DungeonSubTypeValue;

		// Token: 0x040011C3 RID: 4547
		private FlatBufferArray<int> DungeonHardValue;

		// Token: 0x0200038E RID: 910
		public enum eCrypt
		{
			// Token: 0x040011C5 RID: 4549
			code = 1666393919
		}
	}
}
