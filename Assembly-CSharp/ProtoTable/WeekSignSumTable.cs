using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000623 RID: 1571
	public class WeekSignSumTable : IFlatbufferObject
	{
		// Token: 0x170017F9 RID: 6137
		// (get) Token: 0x06005531 RID: 21809 RVA: 0x001049CC File Offset: 0x00102DCC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005532 RID: 21810 RVA: 0x001049D9 File Offset: 0x00102DD9
		public static WeekSignSumTable GetRootAsWeekSignSumTable(ByteBuffer _bb)
		{
			return WeekSignSumTable.GetRootAsWeekSignSumTable(_bb, new WeekSignSumTable());
		}

		// Token: 0x06005533 RID: 21811 RVA: 0x001049E6 File Offset: 0x00102DE6
		public static WeekSignSumTable GetRootAsWeekSignSumTable(ByteBuffer _bb, WeekSignSumTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005534 RID: 21812 RVA: 0x00104A02 File Offset: 0x00102E02
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005535 RID: 21813 RVA: 0x00104A1C File Offset: 0x00102E1C
		public WeekSignSumTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170017FA RID: 6138
		// (get) Token: 0x06005536 RID: 21814 RVA: 0x00104A28 File Offset: 0x00102E28
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (264522694 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017FB RID: 6139
		// (get) Token: 0x06005537 RID: 21815 RVA: 0x00104A74 File Offset: 0x00102E74
		public int opActType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (264522694 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017FC RID: 6140
		// (get) Token: 0x06005538 RID: 21816 RVA: 0x00104AC0 File Offset: 0x00102EC0
		public int weekSum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (264522694 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017FD RID: 6141
		// (get) Token: 0x06005539 RID: 21817 RVA: 0x00104B0C File Offset: 0x00102F0C
		public int rewardId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (264522694 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017FE RID: 6142
		// (get) Token: 0x0600553A RID: 21818 RVA: 0x00104B58 File Offset: 0x00102F58
		public int rewardNum
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (264522694 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600553B RID: 21819 RVA: 0x00104BA2 File Offset: 0x00102FA2
		public static Offset<WeekSignSumTable> CreateWeekSignSumTable(FlatBufferBuilder builder, int ID = 0, int opActType = 0, int weekSum = 0, int rewardId = 0, int rewardNum = 0)
		{
			builder.StartObject(5);
			WeekSignSumTable.AddRewardNum(builder, rewardNum);
			WeekSignSumTable.AddRewardId(builder, rewardId);
			WeekSignSumTable.AddWeekSum(builder, weekSum);
			WeekSignSumTable.AddOpActType(builder, opActType);
			WeekSignSumTable.AddID(builder, ID);
			return WeekSignSumTable.EndWeekSignSumTable(builder);
		}

		// Token: 0x0600553C RID: 21820 RVA: 0x00104BD6 File Offset: 0x00102FD6
		public static void StartWeekSignSumTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0600553D RID: 21821 RVA: 0x00104BDF File Offset: 0x00102FDF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600553E RID: 21822 RVA: 0x00104BEA File Offset: 0x00102FEA
		public static void AddOpActType(FlatBufferBuilder builder, int opActType)
		{
			builder.AddInt(1, opActType, 0);
		}

		// Token: 0x0600553F RID: 21823 RVA: 0x00104BF5 File Offset: 0x00102FF5
		public static void AddWeekSum(FlatBufferBuilder builder, int weekSum)
		{
			builder.AddInt(2, weekSum, 0);
		}

		// Token: 0x06005540 RID: 21824 RVA: 0x00104C00 File Offset: 0x00103000
		public static void AddRewardId(FlatBufferBuilder builder, int rewardId)
		{
			builder.AddInt(3, rewardId, 0);
		}

		// Token: 0x06005541 RID: 21825 RVA: 0x00104C0B File Offset: 0x0010300B
		public static void AddRewardNum(FlatBufferBuilder builder, int rewardNum)
		{
			builder.AddInt(4, rewardNum, 0);
		}

		// Token: 0x06005542 RID: 21826 RVA: 0x00104C18 File Offset: 0x00103018
		public static Offset<WeekSignSumTable> EndWeekSignSumTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<WeekSignSumTable>(value);
		}

		// Token: 0x06005543 RID: 21827 RVA: 0x00104C32 File Offset: 0x00103032
		public static void FinishWeekSignSumTableBuffer(FlatBufferBuilder builder, Offset<WeekSignSumTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001EB4 RID: 7860
		private Table __p = new Table();

		// Token: 0x02000624 RID: 1572
		public enum eCrypt
		{
			// Token: 0x04001EB6 RID: 7862
			code = 264522694
		}
	}
}
