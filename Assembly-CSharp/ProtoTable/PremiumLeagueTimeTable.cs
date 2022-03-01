using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200055C RID: 1372
	public class PremiumLeagueTimeTable : IFlatbufferObject
	{
		// Token: 0x1700130E RID: 4878
		// (get) Token: 0x060046C7 RID: 18119 RVA: 0x000E23C0 File Offset: 0x000E07C0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060046C8 RID: 18120 RVA: 0x000E23CD File Offset: 0x000E07CD
		public static PremiumLeagueTimeTable GetRootAsPremiumLeagueTimeTable(ByteBuffer _bb)
		{
			return PremiumLeagueTimeTable.GetRootAsPremiumLeagueTimeTable(_bb, new PremiumLeagueTimeTable());
		}

		// Token: 0x060046C9 RID: 18121 RVA: 0x000E23DA File Offset: 0x000E07DA
		public static PremiumLeagueTimeTable GetRootAsPremiumLeagueTimeTable(ByteBuffer _bb, PremiumLeagueTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060046CA RID: 18122 RVA: 0x000E23F6 File Offset: 0x000E07F6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060046CB RID: 18123 RVA: 0x000E2410 File Offset: 0x000E0810
		public PremiumLeagueTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700130F RID: 4879
		// (get) Token: 0x060046CC RID: 18124 RVA: 0x000E241C File Offset: 0x000E081C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1851077999 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001310 RID: 4880
		// (get) Token: 0x060046CD RID: 18125 RVA: 0x000E2468 File Offset: 0x000E0868
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046CE RID: 18126 RVA: 0x000E24AA File Offset: 0x000E08AA
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001311 RID: 4881
		// (get) Token: 0x060046CF RID: 18127 RVA: 0x000E24B8 File Offset: 0x000E08B8
		public PremiumLeagueTimeTable.eStatus Status
		{
			get
			{
				int num = this.__p.__offset(8);
				return (PremiumLeagueTimeTable.eStatus)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001312 RID: 4882
		// (get) Token: 0x060046D0 RID: 18128 RVA: 0x000E24FC File Offset: 0x000E08FC
		public int Week
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1851077999 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001313 RID: 4883
		// (get) Token: 0x060046D1 RID: 18129 RVA: 0x000E2548 File Offset: 0x000E0948
		public string Time
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046D2 RID: 18130 RVA: 0x000E258B File Offset: 0x000E098B
		public ArraySegment<byte>? GetTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001314 RID: 4884
		// (get) Token: 0x060046D3 RID: 18131 RVA: 0x000E259C File Offset: 0x000E099C
		public int DurningTime
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1851077999 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060046D4 RID: 18132 RVA: 0x000E25E6 File Offset: 0x000E09E6
		public static Offset<PremiumLeagueTimeTable> CreatePremiumLeagueTimeTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescOffset = default(StringOffset), PremiumLeagueTimeTable.eStatus Status = PremiumLeagueTimeTable.eStatus.PLS_INIT, int Week = 0, StringOffset TimeOffset = default(StringOffset), int DurningTime = 0)
		{
			builder.StartObject(6);
			PremiumLeagueTimeTable.AddDurningTime(builder, DurningTime);
			PremiumLeagueTimeTable.AddTime(builder, TimeOffset);
			PremiumLeagueTimeTable.AddWeek(builder, Week);
			PremiumLeagueTimeTable.AddStatus(builder, Status);
			PremiumLeagueTimeTable.AddDesc(builder, DescOffset);
			PremiumLeagueTimeTable.AddID(builder, ID);
			return PremiumLeagueTimeTable.EndPremiumLeagueTimeTable(builder);
		}

		// Token: 0x060046D5 RID: 18133 RVA: 0x000E2622 File Offset: 0x000E0A22
		public static void StartPremiumLeagueTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x060046D6 RID: 18134 RVA: 0x000E262B File Offset: 0x000E0A2B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060046D7 RID: 18135 RVA: 0x000E2636 File Offset: 0x000E0A36
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(1, DescOffset.Value, 0);
		}

		// Token: 0x060046D8 RID: 18136 RVA: 0x000E2647 File Offset: 0x000E0A47
		public static void AddStatus(FlatBufferBuilder builder, PremiumLeagueTimeTable.eStatus Status)
		{
			builder.AddInt(2, (int)Status, 0);
		}

		// Token: 0x060046D9 RID: 18137 RVA: 0x000E2652 File Offset: 0x000E0A52
		public static void AddWeek(FlatBufferBuilder builder, int Week)
		{
			builder.AddInt(3, Week, 0);
		}

		// Token: 0x060046DA RID: 18138 RVA: 0x000E265D File Offset: 0x000E0A5D
		public static void AddTime(FlatBufferBuilder builder, StringOffset TimeOffset)
		{
			builder.AddOffset(4, TimeOffset.Value, 0);
		}

		// Token: 0x060046DB RID: 18139 RVA: 0x000E266E File Offset: 0x000E0A6E
		public static void AddDurningTime(FlatBufferBuilder builder, int DurningTime)
		{
			builder.AddInt(5, DurningTime, 0);
		}

		// Token: 0x060046DC RID: 18140 RVA: 0x000E267C File Offset: 0x000E0A7C
		public static Offset<PremiumLeagueTimeTable> EndPremiumLeagueTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PremiumLeagueTimeTable>(value);
		}

		// Token: 0x060046DD RID: 18141 RVA: 0x000E2696 File Offset: 0x000E0A96
		public static void FinishPremiumLeagueTimeTableBuffer(FlatBufferBuilder builder, Offset<PremiumLeagueTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A24 RID: 6692
		private Table __p = new Table();

		// Token: 0x0200055D RID: 1373
		public enum eStatus
		{
			// Token: 0x04001A26 RID: 6694
			PLS_INIT,
			// Token: 0x04001A27 RID: 6695
			PLS_ENROLL,
			// Token: 0x04001A28 RID: 6696
			PLS_PRELIMINAY,
			// Token: 0x04001A29 RID: 6697
			PLS_FINAL_EIGHT_PREPARE,
			// Token: 0x04001A2A RID: 6698
			PLS_FINAL_EIGHT,
			// Token: 0x04001A2B RID: 6699
			PLS_FINAL_FOUR,
			// Token: 0x04001A2C RID: 6700
			PLS_FINAL,
			// Token: 0x04001A2D RID: 6701
			PLS_FINAL_END
		}

		// Token: 0x0200055E RID: 1374
		public enum eCrypt
		{
			// Token: 0x04001A2F RID: 6703
			code = 1851077999
		}
	}
}
