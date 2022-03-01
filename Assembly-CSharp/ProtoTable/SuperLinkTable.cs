using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005D9 RID: 1497
	public class SuperLinkTable : IFlatbufferObject
	{
		// Token: 0x170015DB RID: 5595
		// (get) Token: 0x06004F61 RID: 20321 RVA: 0x000F65F4 File Offset: 0x000F49F4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004F62 RID: 20322 RVA: 0x000F6601 File Offset: 0x000F4A01
		public static SuperLinkTable GetRootAsSuperLinkTable(ByteBuffer _bb)
		{
			return SuperLinkTable.GetRootAsSuperLinkTable(_bb, new SuperLinkTable());
		}

		// Token: 0x06004F63 RID: 20323 RVA: 0x000F660E File Offset: 0x000F4A0E
		public static SuperLinkTable GetRootAsSuperLinkTable(ByteBuffer _bb, SuperLinkTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004F64 RID: 20324 RVA: 0x000F662A File Offset: 0x000F4A2A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004F65 RID: 20325 RVA: 0x000F6644 File Offset: 0x000F4A44
		public SuperLinkTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015DC RID: 5596
		// (get) Token: 0x06004F66 RID: 20326 RVA: 0x000F6650 File Offset: 0x000F4A50
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1907652381 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015DD RID: 5597
		// (get) Token: 0x06004F67 RID: 20327 RVA: 0x000F669C File Offset: 0x000F4A9C
		public SuperLinkTable.eLinkType LinkType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (SuperLinkTable.eLinkType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015DE RID: 5598
		// (get) Token: 0x06004F68 RID: 20328 RVA: 0x000F66E0 File Offset: 0x000F4AE0
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F69 RID: 20329 RVA: 0x000F6722 File Offset: 0x000F4B22
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170015DF RID: 5599
		// (get) Token: 0x06004F6A RID: 20330 RVA: 0x000F6730 File Offset: 0x000F4B30
		public string Param
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F6B RID: 20331 RVA: 0x000F6773 File Offset: 0x000F4B73
		public ArraySegment<byte>? GetParamBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170015E0 RID: 5600
		// (get) Token: 0x06004F6C RID: 20332 RVA: 0x000F6784 File Offset: 0x000F4B84
		public int FunctionType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1907652381 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004F6D RID: 20333 RVA: 0x000F67D0 File Offset: 0x000F4BD0
		public string LocalParamArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170015E1 RID: 5601
		// (get) Token: 0x06004F6E RID: 20334 RVA: 0x000F6818 File Offset: 0x000F4C18
		public int LocalParamLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015E2 RID: 5602
		// (get) Token: 0x06004F6F RID: 20335 RVA: 0x000F684B File Offset: 0x000F4C4B
		public FlatBufferArray<string> LocalParam
		{
			get
			{
				if (this.LocalParamValue == null)
				{
					this.LocalParamValue = new FlatBufferArray<string>(new Func<int, string>(this.LocalParamArray), this.LocalParamLength);
				}
				return this.LocalParamValue;
			}
		}

		// Token: 0x170015E3 RID: 5603
		// (get) Token: 0x06004F70 RID: 20336 RVA: 0x000F687C File Offset: 0x000F4C7C
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F71 RID: 20337 RVA: 0x000F68BF File Offset: 0x000F4CBF
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x06004F72 RID: 20338 RVA: 0x000F68D0 File Offset: 0x000F4CD0
		public string OpenLevelArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170015E4 RID: 5604
		// (get) Token: 0x06004F73 RID: 20339 RVA: 0x000F6918 File Offset: 0x000F4D18
		public int OpenLevelLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015E5 RID: 5605
		// (get) Token: 0x06004F74 RID: 20340 RVA: 0x000F694B File Offset: 0x000F4D4B
		public FlatBufferArray<string> OpenLevel
		{
			get
			{
				if (this.OpenLevelValue == null)
				{
					this.OpenLevelValue = new FlatBufferArray<string>(new Func<int, string>(this.OpenLevelArray), this.OpenLevelLength);
				}
				return this.OpenLevelValue;
			}
		}

		// Token: 0x06004F75 RID: 20341 RVA: 0x000F697C File Offset: 0x000F4D7C
		public static Offset<SuperLinkTable> CreateSuperLinkTable(FlatBufferBuilder builder, int ID = 0, SuperLinkTable.eLinkType LinkType = SuperLinkTable.eLinkType.LT_DESC, StringOffset LinkInfoOffset = default(StringOffset), StringOffset ParamOffset = default(StringOffset), int FunctionType = 0, VectorOffset LocalParamOffset = default(VectorOffset), StringOffset DescOffset = default(StringOffset), VectorOffset OpenLevelOffset = default(VectorOffset))
		{
			builder.StartObject(8);
			SuperLinkTable.AddOpenLevel(builder, OpenLevelOffset);
			SuperLinkTable.AddDesc(builder, DescOffset);
			SuperLinkTable.AddLocalParam(builder, LocalParamOffset);
			SuperLinkTable.AddFunctionType(builder, FunctionType);
			SuperLinkTable.AddParam(builder, ParamOffset);
			SuperLinkTable.AddLinkInfo(builder, LinkInfoOffset);
			SuperLinkTable.AddLinkType(builder, LinkType);
			SuperLinkTable.AddID(builder, ID);
			return SuperLinkTable.EndSuperLinkTable(builder);
		}

		// Token: 0x06004F76 RID: 20342 RVA: 0x000F69D3 File Offset: 0x000F4DD3
		public static void StartSuperLinkTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06004F77 RID: 20343 RVA: 0x000F69DC File Offset: 0x000F4DDC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004F78 RID: 20344 RVA: 0x000F69E7 File Offset: 0x000F4DE7
		public static void AddLinkType(FlatBufferBuilder builder, SuperLinkTable.eLinkType LinkType)
		{
			builder.AddInt(1, (int)LinkType, 0);
		}

		// Token: 0x06004F79 RID: 20345 RVA: 0x000F69F2 File Offset: 0x000F4DF2
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(2, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06004F7A RID: 20346 RVA: 0x000F6A03 File Offset: 0x000F4E03
		public static void AddParam(FlatBufferBuilder builder, StringOffset ParamOffset)
		{
			builder.AddOffset(3, ParamOffset.Value, 0);
		}

		// Token: 0x06004F7B RID: 20347 RVA: 0x000F6A14 File Offset: 0x000F4E14
		public static void AddFunctionType(FlatBufferBuilder builder, int FunctionType)
		{
			builder.AddInt(4, FunctionType, 0);
		}

		// Token: 0x06004F7C RID: 20348 RVA: 0x000F6A1F File Offset: 0x000F4E1F
		public static void AddLocalParam(FlatBufferBuilder builder, VectorOffset LocalParamOffset)
		{
			builder.AddOffset(5, LocalParamOffset.Value, 0);
		}

		// Token: 0x06004F7D RID: 20349 RVA: 0x000F6A30 File Offset: 0x000F4E30
		public static VectorOffset CreateLocalParamVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004F7E RID: 20350 RVA: 0x000F6A76 File Offset: 0x000F4E76
		public static void StartLocalParamVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004F7F RID: 20351 RVA: 0x000F6A81 File Offset: 0x000F4E81
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(6, DescOffset.Value, 0);
		}

		// Token: 0x06004F80 RID: 20352 RVA: 0x000F6A92 File Offset: 0x000F4E92
		public static void AddOpenLevel(FlatBufferBuilder builder, VectorOffset OpenLevelOffset)
		{
			builder.AddOffset(7, OpenLevelOffset.Value, 0);
		}

		// Token: 0x06004F81 RID: 20353 RVA: 0x000F6AA4 File Offset: 0x000F4EA4
		public static VectorOffset CreateOpenLevelVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004F82 RID: 20354 RVA: 0x000F6AEA File Offset: 0x000F4EEA
		public static void StartOpenLevelVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004F83 RID: 20355 RVA: 0x000F6AF8 File Offset: 0x000F4EF8
		public static Offset<SuperLinkTable> EndSuperLinkTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SuperLinkTable>(value);
		}

		// Token: 0x06004F84 RID: 20356 RVA: 0x000F6B12 File Offset: 0x000F4F12
		public static void FinishSuperLinkTableBuffer(FlatBufferBuilder builder, Offset<SuperLinkTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BE8 RID: 7144
		private Table __p = new Table();

		// Token: 0x04001BE9 RID: 7145
		private FlatBufferArray<string> LocalParamValue;

		// Token: 0x04001BEA RID: 7146
		private FlatBufferArray<string> OpenLevelValue;

		// Token: 0x020005DA RID: 1498
		public enum eLinkType
		{
			// Token: 0x04001BEC RID: 7148
			LT_DESC,
			// Token: 0x04001BED RID: 7149
			LT_TABLE_NAME
		}

		// Token: 0x020005DB RID: 1499
		public enum eCrypt
		{
			// Token: 0x04001BEF RID: 7151
			code = -1907652381
		}
	}
}
