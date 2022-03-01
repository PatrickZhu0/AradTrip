using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005CF RID: 1487
	public class StrenTicketFuseMaterialTable : IFlatbufferObject
	{
		// Token: 0x170015B9 RID: 5561
		// (get) Token: 0x06004EEF RID: 20207 RVA: 0x000F573C File Offset: 0x000F3B3C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004EF0 RID: 20208 RVA: 0x000F5749 File Offset: 0x000F3B49
		public static StrenTicketFuseMaterialTable GetRootAsStrenTicketFuseMaterialTable(ByteBuffer _bb)
		{
			return StrenTicketFuseMaterialTable.GetRootAsStrenTicketFuseMaterialTable(_bb, new StrenTicketFuseMaterialTable());
		}

		// Token: 0x06004EF1 RID: 20209 RVA: 0x000F5756 File Offset: 0x000F3B56
		public static StrenTicketFuseMaterialTable GetRootAsStrenTicketFuseMaterialTable(ByteBuffer _bb, StrenTicketFuseMaterialTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004EF2 RID: 20210 RVA: 0x000F5772 File Offset: 0x000F3B72
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004EF3 RID: 20211 RVA: 0x000F578C File Offset: 0x000F3B8C
		public StrenTicketFuseMaterialTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015BA RID: 5562
		// (get) Token: 0x06004EF4 RID: 20212 RVA: 0x000F5798 File Offset: 0x000F3B98
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (522136054 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015BB RID: 5563
		// (get) Token: 0x06004EF5 RID: 20213 RVA: 0x000F57E4 File Offset: 0x000F3BE4
		public string Material
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004EF6 RID: 20214 RVA: 0x000F5826 File Offset: 0x000F3C26
		public ArraySegment<byte>? GetMaterialBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170015BC RID: 5564
		// (get) Token: 0x06004EF7 RID: 20215 RVA: 0x000F5834 File Offset: 0x000F3C34
		public string PickCondOfStrenLv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004EF8 RID: 20216 RVA: 0x000F5876 File Offset: 0x000F3C76
		public ArraySegment<byte>? GetPickCondOfStrenLvBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06004EF9 RID: 20217 RVA: 0x000F5884 File Offset: 0x000F3C84
		public static Offset<StrenTicketFuseMaterialTable> CreateStrenTicketFuseMaterialTable(FlatBufferBuilder builder, int ID = 0, StringOffset MaterialOffset = default(StringOffset), StringOffset PickCondOfStrenLvOffset = default(StringOffset))
		{
			builder.StartObject(3);
			StrenTicketFuseMaterialTable.AddPickCondOfStrenLv(builder, PickCondOfStrenLvOffset);
			StrenTicketFuseMaterialTable.AddMaterial(builder, MaterialOffset);
			StrenTicketFuseMaterialTable.AddID(builder, ID);
			return StrenTicketFuseMaterialTable.EndStrenTicketFuseMaterialTable(builder);
		}

		// Token: 0x06004EFA RID: 20218 RVA: 0x000F58A8 File Offset: 0x000F3CA8
		public static void StartStrenTicketFuseMaterialTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004EFB RID: 20219 RVA: 0x000F58B1 File Offset: 0x000F3CB1
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004EFC RID: 20220 RVA: 0x000F58BC File Offset: 0x000F3CBC
		public static void AddMaterial(FlatBufferBuilder builder, StringOffset MaterialOffset)
		{
			builder.AddOffset(1, MaterialOffset.Value, 0);
		}

		// Token: 0x06004EFD RID: 20221 RVA: 0x000F58CD File Offset: 0x000F3CCD
		public static void AddPickCondOfStrenLv(FlatBufferBuilder builder, StringOffset PickCondOfStrenLvOffset)
		{
			builder.AddOffset(2, PickCondOfStrenLvOffset.Value, 0);
		}

		// Token: 0x06004EFE RID: 20222 RVA: 0x000F58E0 File Offset: 0x000F3CE0
		public static Offset<StrenTicketFuseMaterialTable> EndStrenTicketFuseMaterialTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<StrenTicketFuseMaterialTable>(value);
		}

		// Token: 0x06004EFF RID: 20223 RVA: 0x000F58FA File Offset: 0x000F3CFA
		public static void FinishStrenTicketFuseMaterialTableBuffer(FlatBufferBuilder builder, Offset<StrenTicketFuseMaterialTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BD8 RID: 7128
		private Table __p = new Table();

		// Token: 0x020005D0 RID: 1488
		public enum eCrypt
		{
			// Token: 0x04001BDA RID: 7130
			code = 522136054
		}
	}
}
