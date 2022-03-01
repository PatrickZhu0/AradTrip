using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200029D RID: 669
	public class AnnounceTable : IFlatbufferObject
	{
		// Token: 0x17000370 RID: 880
		// (get) Token: 0x060017CF RID: 6095 RVA: 0x000723D4 File Offset: 0x000707D4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060017D0 RID: 6096 RVA: 0x000723E1 File Offset: 0x000707E1
		public static AnnounceTable GetRootAsAnnounceTable(ByteBuffer _bb)
		{
			return AnnounceTable.GetRootAsAnnounceTable(_bb, new AnnounceTable());
		}

		// Token: 0x060017D1 RID: 6097 RVA: 0x000723EE File Offset: 0x000707EE
		public static AnnounceTable GetRootAsAnnounceTable(ByteBuffer _bb, AnnounceTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060017D2 RID: 6098 RVA: 0x0007240A File Offset: 0x0007080A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060017D3 RID: 6099 RVA: 0x00072424 File Offset: 0x00070824
		public AnnounceTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x060017D4 RID: 6100 RVA: 0x00072430 File Offset: 0x00070830
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1712356129 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x060017D5 RID: 6101 RVA: 0x0007247C File Offset: 0x0007087C
		public string NoticeText
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060017D6 RID: 6102 RVA: 0x000724BE File Offset: 0x000708BE
		public ArraySegment<byte>? GetNoticeTextBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x060017D7 RID: 6103 RVA: 0x000724CC File Offset: 0x000708CC
		public int Interval
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1712356129 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x060017D8 RID: 6104 RVA: 0x00072518 File Offset: 0x00070918
		public int Times
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1712356129 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x060017D9 RID: 6105 RVA: 0x00072564 File Offset: 0x00070964
		public int Priority
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1712356129 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x060017DA RID: 6106 RVA: 0x000725B0 File Offset: 0x000709B0
		public int Parameter
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1712356129 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x060017DB RID: 6107 RVA: 0x000725FC File Offset: 0x000709FC
		public string Effect
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060017DC RID: 6108 RVA: 0x0007263F File Offset: 0x00070A3F
		public ArraySegment<byte>? GetEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x060017DD RID: 6109 RVA: 0x00072650 File Offset: 0x00070A50
		public int Channel
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1712356129 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060017DE RID: 6110 RVA: 0x0007269C File Offset: 0x00070A9C
		public static Offset<AnnounceTable> CreateAnnounceTable(FlatBufferBuilder builder, int ID = 0, StringOffset NoticeTextOffset = default(StringOffset), int Interval = 0, int Times = 0, int Priority = 0, int Parameter = 0, StringOffset EffectOffset = default(StringOffset), int Channel = 0)
		{
			builder.StartObject(8);
			AnnounceTable.AddChannel(builder, Channel);
			AnnounceTable.AddEffect(builder, EffectOffset);
			AnnounceTable.AddParameter(builder, Parameter);
			AnnounceTable.AddPriority(builder, Priority);
			AnnounceTable.AddTimes(builder, Times);
			AnnounceTable.AddInterval(builder, Interval);
			AnnounceTable.AddNoticeText(builder, NoticeTextOffset);
			AnnounceTable.AddID(builder, ID);
			return AnnounceTable.EndAnnounceTable(builder);
		}

		// Token: 0x060017DF RID: 6111 RVA: 0x000726F3 File Offset: 0x00070AF3
		public static void StartAnnounceTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x060017E0 RID: 6112 RVA: 0x000726FC File Offset: 0x00070AFC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060017E1 RID: 6113 RVA: 0x00072707 File Offset: 0x00070B07
		public static void AddNoticeText(FlatBufferBuilder builder, StringOffset NoticeTextOffset)
		{
			builder.AddOffset(1, NoticeTextOffset.Value, 0);
		}

		// Token: 0x060017E2 RID: 6114 RVA: 0x00072718 File Offset: 0x00070B18
		public static void AddInterval(FlatBufferBuilder builder, int Interval)
		{
			builder.AddInt(2, Interval, 0);
		}

		// Token: 0x060017E3 RID: 6115 RVA: 0x00072723 File Offset: 0x00070B23
		public static void AddTimes(FlatBufferBuilder builder, int Times)
		{
			builder.AddInt(3, Times, 0);
		}

		// Token: 0x060017E4 RID: 6116 RVA: 0x0007272E File Offset: 0x00070B2E
		public static void AddPriority(FlatBufferBuilder builder, int Priority)
		{
			builder.AddInt(4, Priority, 0);
		}

		// Token: 0x060017E5 RID: 6117 RVA: 0x00072739 File Offset: 0x00070B39
		public static void AddParameter(FlatBufferBuilder builder, int Parameter)
		{
			builder.AddInt(5, Parameter, 0);
		}

		// Token: 0x060017E6 RID: 6118 RVA: 0x00072744 File Offset: 0x00070B44
		public static void AddEffect(FlatBufferBuilder builder, StringOffset EffectOffset)
		{
			builder.AddOffset(6, EffectOffset.Value, 0);
		}

		// Token: 0x060017E7 RID: 6119 RVA: 0x00072755 File Offset: 0x00070B55
		public static void AddChannel(FlatBufferBuilder builder, int Channel)
		{
			builder.AddInt(7, Channel, 0);
		}

		// Token: 0x060017E8 RID: 6120 RVA: 0x00072760 File Offset: 0x00070B60
		public static Offset<AnnounceTable> EndAnnounceTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AnnounceTable>(value);
		}

		// Token: 0x060017E9 RID: 6121 RVA: 0x0007277A File Offset: 0x00070B7A
		public static void FinishAnnounceTableBuffer(FlatBufferBuilder builder, Offset<AnnounceTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DE5 RID: 3557
		private Table __p = new Table();

		// Token: 0x0200029E RID: 670
		public enum eCrypt
		{
			// Token: 0x04000DE7 RID: 3559
			code = 1712356129
		}
	}
}
