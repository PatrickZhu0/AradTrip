using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000323 RID: 803
	public class ChiJiRegionTable : IFlatbufferObject
	{
		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06001FE0 RID: 8160 RVA: 0x00085088 File Offset: 0x00083488
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001FE1 RID: 8161 RVA: 0x00085095 File Offset: 0x00083495
		public static ChiJiRegionTable GetRootAsChiJiRegionTable(ByteBuffer _bb)
		{
			return ChiJiRegionTable.GetRootAsChiJiRegionTable(_bb, new ChiJiRegionTable());
		}

		// Token: 0x06001FE2 RID: 8162 RVA: 0x000850A2 File Offset: 0x000834A2
		public static ChiJiRegionTable GetRootAsChiJiRegionTable(ByteBuffer _bb, ChiJiRegionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001FE3 RID: 8163 RVA: 0x000850BE File Offset: 0x000834BE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001FE4 RID: 8164 RVA: 0x000850D8 File Offset: 0x000834D8
		public ChiJiRegionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x06001FE5 RID: 8165 RVA: 0x000850E4 File Offset: 0x000834E4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2099043363 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06001FE6 RID: 8166 RVA: 0x00085130 File Offset: 0x00083530
		public string regionName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001FE7 RID: 8167 RVA: 0x00085172 File Offset: 0x00083572
		public ArraySegment<byte>? GetRegionNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x06001FE8 RID: 8168 RVA: 0x00085180 File Offset: 0x00083580
		public string regionDescribe
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001FE9 RID: 8169 RVA: 0x000851C2 File Offset: 0x000835C2
		public ArraySegment<byte>? GetRegionDescribeBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06001FEA RID: 8170 RVA: 0x000851D0 File Offset: 0x000835D0
		public static Offset<ChiJiRegionTable> CreateChiJiRegionTable(FlatBufferBuilder builder, int ID = 0, StringOffset regionNameOffset = default(StringOffset), StringOffset regionDescribeOffset = default(StringOffset))
		{
			builder.StartObject(3);
			ChiJiRegionTable.AddRegionDescribe(builder, regionDescribeOffset);
			ChiJiRegionTable.AddRegionName(builder, regionNameOffset);
			ChiJiRegionTable.AddID(builder, ID);
			return ChiJiRegionTable.EndChiJiRegionTable(builder);
		}

		// Token: 0x06001FEB RID: 8171 RVA: 0x000851F4 File Offset: 0x000835F4
		public static void StartChiJiRegionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001FEC RID: 8172 RVA: 0x000851FD File Offset: 0x000835FD
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001FED RID: 8173 RVA: 0x00085208 File Offset: 0x00083608
		public static void AddRegionName(FlatBufferBuilder builder, StringOffset regionNameOffset)
		{
			builder.AddOffset(1, regionNameOffset.Value, 0);
		}

		// Token: 0x06001FEE RID: 8174 RVA: 0x00085219 File Offset: 0x00083619
		public static void AddRegionDescribe(FlatBufferBuilder builder, StringOffset regionDescribeOffset)
		{
			builder.AddOffset(2, regionDescribeOffset.Value, 0);
		}

		// Token: 0x06001FEF RID: 8175 RVA: 0x0008522C File Offset: 0x0008362C
		public static Offset<ChiJiRegionTable> EndChiJiRegionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiRegionTable>(value);
		}

		// Token: 0x06001FF0 RID: 8176 RVA: 0x00085246 File Offset: 0x00083646
		public static void FinishChiJiRegionTableBuffer(FlatBufferBuilder builder, Offset<ChiJiRegionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F78 RID: 3960
		private Table __p = new Table();

		// Token: 0x02000324 RID: 804
		public enum eCrypt
		{
			// Token: 0x04000F7A RID: 3962
			code = 2099043363
		}
	}
}
