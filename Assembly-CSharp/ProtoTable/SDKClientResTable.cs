using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200058D RID: 1421
	public class SDKClientResTable : IFlatbufferObject
	{
		// Token: 0x170013FA RID: 5114
		// (get) Token: 0x060049B6 RID: 18870 RVA: 0x000E8B18 File Offset: 0x000E6F18
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060049B7 RID: 18871 RVA: 0x000E8B25 File Offset: 0x000E6F25
		public static SDKClientResTable GetRootAsSDKClientResTable(ByteBuffer _bb)
		{
			return SDKClientResTable.GetRootAsSDKClientResTable(_bb, new SDKClientResTable());
		}

		// Token: 0x060049B8 RID: 18872 RVA: 0x000E8B32 File Offset: 0x000E6F32
		public static SDKClientResTable GetRootAsSDKClientResTable(ByteBuffer _bb, SDKClientResTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060049B9 RID: 18873 RVA: 0x000E8B4E File Offset: 0x000E6F4E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060049BA RID: 18874 RVA: 0x000E8B68 File Offset: 0x000E6F68
		public SDKClientResTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170013FB RID: 5115
		// (get) Token: 0x060049BB RID: 18875 RVA: 0x000E8B74 File Offset: 0x000E6F74
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-112053201 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013FC RID: 5116
		// (get) Token: 0x060049BC RID: 18876 RVA: 0x000E8BC0 File Offset: 0x000E6FC0
		public SDKClientResTable.eSDK SDK
		{
			get
			{
				int num = this.__p.__offset(6);
				return (SDKClientResTable.eSDK)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013FD RID: 5117
		// (get) Token: 0x060049BD RID: 18877 RVA: 0x000E8C04 File Offset: 0x000E7004
		public SDKClientResTable.eFuncType FuncType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (SDKClientResTable.eFuncType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013FE RID: 5118
		// (get) Token: 0x060049BE RID: 18878 RVA: 0x000E8C48 File Offset: 0x000E7048
		public bool Open
		{
			get
			{
				int num = this.__p.__offset(10);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170013FF RID: 5119
		// (get) Token: 0x060049BF RID: 18879 RVA: 0x000E8C94 File Offset: 0x000E7094
		public string IconDesc
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060049C0 RID: 18880 RVA: 0x000E8CD7 File Offset: 0x000E70D7
		public ArraySegment<byte>? GetIconDescBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001400 RID: 5120
		// (get) Token: 0x060049C1 RID: 18881 RVA: 0x000E8CE8 File Offset: 0x000E70E8
		public string IconImgPath
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060049C2 RID: 18882 RVA: 0x000E8D2B File Offset: 0x000E712B
		public ArraySegment<byte>? GetIconImgPathBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x060049C3 RID: 18883 RVA: 0x000E8D3A File Offset: 0x000E713A
		public static Offset<SDKClientResTable> CreateSDKClientResTable(FlatBufferBuilder builder, int ID = 0, SDKClientResTable.eSDK SDK = SDKClientResTable.eSDK.OPPO, SDKClientResTable.eFuncType FuncType = SDKClientResTable.eFuncType.GotoCommunity, bool Open = false, StringOffset IconDescOffset = default(StringOffset), StringOffset IconImgPathOffset = default(StringOffset))
		{
			builder.StartObject(6);
			SDKClientResTable.AddIconImgPath(builder, IconImgPathOffset);
			SDKClientResTable.AddIconDesc(builder, IconDescOffset);
			SDKClientResTable.AddFuncType(builder, FuncType);
			SDKClientResTable.AddSDK(builder, SDK);
			SDKClientResTable.AddID(builder, ID);
			SDKClientResTable.AddOpen(builder, Open);
			return SDKClientResTable.EndSDKClientResTable(builder);
		}

		// Token: 0x060049C4 RID: 18884 RVA: 0x000E8D76 File Offset: 0x000E7176
		public static void StartSDKClientResTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x060049C5 RID: 18885 RVA: 0x000E8D7F File Offset: 0x000E717F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060049C6 RID: 18886 RVA: 0x000E8D8A File Offset: 0x000E718A
		public static void AddSDK(FlatBufferBuilder builder, SDKClientResTable.eSDK SDK)
		{
			builder.AddInt(1, (int)SDK, 0);
		}

		// Token: 0x060049C7 RID: 18887 RVA: 0x000E8D95 File Offset: 0x000E7195
		public static void AddFuncType(FlatBufferBuilder builder, SDKClientResTable.eFuncType FuncType)
		{
			builder.AddInt(2, (int)FuncType, 0);
		}

		// Token: 0x060049C8 RID: 18888 RVA: 0x000E8DA0 File Offset: 0x000E71A0
		public static void AddOpen(FlatBufferBuilder builder, bool Open)
		{
			builder.AddBool(3, Open, false);
		}

		// Token: 0x060049C9 RID: 18889 RVA: 0x000E8DAB File Offset: 0x000E71AB
		public static void AddIconDesc(FlatBufferBuilder builder, StringOffset IconDescOffset)
		{
			builder.AddOffset(4, IconDescOffset.Value, 0);
		}

		// Token: 0x060049CA RID: 18890 RVA: 0x000E8DBC File Offset: 0x000E71BC
		public static void AddIconImgPath(FlatBufferBuilder builder, StringOffset IconImgPathOffset)
		{
			builder.AddOffset(5, IconImgPathOffset.Value, 0);
		}

		// Token: 0x060049CB RID: 18891 RVA: 0x000E8DD0 File Offset: 0x000E71D0
		public static Offset<SDKClientResTable> EndSDKClientResTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SDKClientResTable>(value);
		}

		// Token: 0x060049CC RID: 18892 RVA: 0x000E8DEA File Offset: 0x000E71EA
		public static void FinishSDKClientResTableBuffer(FlatBufferBuilder builder, Offset<SDKClientResTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001ABF RID: 6847
		private Table __p = new Table();

		// Token: 0x0200058E RID: 1422
		public enum eSDK
		{
			// Token: 0x04001AC1 RID: 6849
			OPPO,
			// Token: 0x04001AC2 RID: 6850
			VIVO
		}

		// Token: 0x0200058F RID: 1423
		public enum eFuncType
		{
			// Token: 0x04001AC4 RID: 6852
			GotoCommunity
		}

		// Token: 0x02000590 RID: 1424
		public enum eCrypt
		{
			// Token: 0x04001AC6 RID: 6854
			code = -112053201
		}
	}
}
