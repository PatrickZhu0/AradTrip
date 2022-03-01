using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000625 RID: 1573
	public class WeekSignTable : IFlatbufferObject
	{
		// Token: 0x170017FF RID: 6143
		// (get) Token: 0x06005545 RID: 21829 RVA: 0x00104C54 File Offset: 0x00103054
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005546 RID: 21830 RVA: 0x00104C61 File Offset: 0x00103061
		public static WeekSignTable GetRootAsWeekSignTable(ByteBuffer _bb)
		{
			return WeekSignTable.GetRootAsWeekSignTable(_bb, new WeekSignTable());
		}

		// Token: 0x06005547 RID: 21831 RVA: 0x00104C6E File Offset: 0x0010306E
		public static WeekSignTable GetRootAsWeekSignTable(ByteBuffer _bb, WeekSignTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005548 RID: 21832 RVA: 0x00104C8A File Offset: 0x0010308A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005549 RID: 21833 RVA: 0x00104CA4 File Offset: 0x001030A4
		public WeekSignTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001800 RID: 6144
		// (get) Token: 0x0600554A RID: 21834 RVA: 0x00104CB0 File Offset: 0x001030B0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001801 RID: 6145
		// (get) Token: 0x0600554B RID: 21835 RVA: 0x00104CFC File Offset: 0x001030FC
		public int opActType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001802 RID: 6146
		// (get) Token: 0x0600554C RID: 21836 RVA: 0x00104D48 File Offset: 0x00103148
		public int rewardId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001803 RID: 6147
		// (get) Token: 0x0600554D RID: 21837 RVA: 0x00104D94 File Offset: 0x00103194
		public int rewardNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001804 RID: 6148
		// (get) Token: 0x0600554E RID: 21838 RVA: 0x00104DE0 File Offset: 0x001031E0
		public int sortId
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001805 RID: 6149
		// (get) Token: 0x0600554F RID: 21839 RVA: 0x00104E2C File Offset: 0x0010322C
		public int rewardWeight
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001806 RID: 6150
		// (get) Token: 0x06005550 RID: 21840 RVA: 0x00104E78 File Offset: 0x00103278
		public int serverLimit
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001807 RID: 6151
		// (get) Token: 0x06005551 RID: 21841 RVA: 0x00104EC4 File Offset: 0x001032C4
		public int roleLimit
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005552 RID: 21842 RVA: 0x00104F10 File Offset: 0x00103310
		public string vipRateArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001808 RID: 6152
		// (get) Token: 0x06005553 RID: 21843 RVA: 0x00104F58 File Offset: 0x00103358
		public int vipRateLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001809 RID: 6153
		// (get) Token: 0x06005554 RID: 21844 RVA: 0x00104F8B File Offset: 0x0010338B
		public FlatBufferArray<string> vipRate
		{
			get
			{
				if (this.vipRateValue == null)
				{
					this.vipRateValue = new FlatBufferArray<string>(new Func<int, string>(this.vipRateArray), this.vipRateLength);
				}
				return this.vipRateValue;
			}
		}

		// Token: 0x1700180A RID: 6154
		// (get) Token: 0x06005555 RID: 21845 RVA: 0x00104FBC File Offset: 0x001033BC
		public int isBigReward
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700180B RID: 6155
		// (get) Token: 0x06005556 RID: 21846 RVA: 0x00105008 File Offset: 0x00103408
		public int notifyId
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700180C RID: 6156
		// (get) Token: 0x06005557 RID: 21847 RVA: 0x00105054 File Offset: 0x00103454
		public int SuperLink
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700180D RID: 6157
		// (get) Token: 0x06005558 RID: 21848 RVA: 0x001050A0 File Offset: 0x001034A0
		public int refreshType
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700180E RID: 6158
		// (get) Token: 0x06005559 RID: 21849 RVA: 0x001050EC File Offset: 0x001034EC
		public int rewardUid
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700180F RID: 6159
		// (get) Token: 0x0600555A RID: 21850 RVA: 0x00105138 File Offset: 0x00103538
		public int Preview
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (1571332953 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600555B RID: 21851 RVA: 0x00105184 File Offset: 0x00103584
		public static Offset<WeekSignTable> CreateWeekSignTable(FlatBufferBuilder builder, int ID = 0, int opActType = 0, int rewardId = 0, int rewardNum = 0, int sortId = 0, int rewardWeight = 0, int serverLimit = 0, int roleLimit = 0, VectorOffset vipRateOffset = default(VectorOffset), int isBigReward = 0, int notifyId = 0, int SuperLink = 0, int refreshType = 0, int rewardUid = 0, int Preview = 0)
		{
			builder.StartObject(15);
			WeekSignTable.AddPreview(builder, Preview);
			WeekSignTable.AddRewardUid(builder, rewardUid);
			WeekSignTable.AddRefreshType(builder, refreshType);
			WeekSignTable.AddSuperLink(builder, SuperLink);
			WeekSignTable.AddNotifyId(builder, notifyId);
			WeekSignTable.AddIsBigReward(builder, isBigReward);
			WeekSignTable.AddVipRate(builder, vipRateOffset);
			WeekSignTable.AddRoleLimit(builder, roleLimit);
			WeekSignTable.AddServerLimit(builder, serverLimit);
			WeekSignTable.AddRewardWeight(builder, rewardWeight);
			WeekSignTable.AddSortId(builder, sortId);
			WeekSignTable.AddRewardNum(builder, rewardNum);
			WeekSignTable.AddRewardId(builder, rewardId);
			WeekSignTable.AddOpActType(builder, opActType);
			WeekSignTable.AddID(builder, ID);
			return WeekSignTable.EndWeekSignTable(builder);
		}

		// Token: 0x0600555C RID: 21852 RVA: 0x00105214 File Offset: 0x00103614
		public static void StartWeekSignTable(FlatBufferBuilder builder)
		{
			builder.StartObject(15);
		}

		// Token: 0x0600555D RID: 21853 RVA: 0x0010521E File Offset: 0x0010361E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600555E RID: 21854 RVA: 0x00105229 File Offset: 0x00103629
		public static void AddOpActType(FlatBufferBuilder builder, int opActType)
		{
			builder.AddInt(1, opActType, 0);
		}

		// Token: 0x0600555F RID: 21855 RVA: 0x00105234 File Offset: 0x00103634
		public static void AddRewardId(FlatBufferBuilder builder, int rewardId)
		{
			builder.AddInt(2, rewardId, 0);
		}

		// Token: 0x06005560 RID: 21856 RVA: 0x0010523F File Offset: 0x0010363F
		public static void AddRewardNum(FlatBufferBuilder builder, int rewardNum)
		{
			builder.AddInt(3, rewardNum, 0);
		}

		// Token: 0x06005561 RID: 21857 RVA: 0x0010524A File Offset: 0x0010364A
		public static void AddSortId(FlatBufferBuilder builder, int sortId)
		{
			builder.AddInt(4, sortId, 0);
		}

		// Token: 0x06005562 RID: 21858 RVA: 0x00105255 File Offset: 0x00103655
		public static void AddRewardWeight(FlatBufferBuilder builder, int rewardWeight)
		{
			builder.AddInt(5, rewardWeight, 0);
		}

		// Token: 0x06005563 RID: 21859 RVA: 0x00105260 File Offset: 0x00103660
		public static void AddServerLimit(FlatBufferBuilder builder, int serverLimit)
		{
			builder.AddInt(6, serverLimit, 0);
		}

		// Token: 0x06005564 RID: 21860 RVA: 0x0010526B File Offset: 0x0010366B
		public static void AddRoleLimit(FlatBufferBuilder builder, int roleLimit)
		{
			builder.AddInt(7, roleLimit, 0);
		}

		// Token: 0x06005565 RID: 21861 RVA: 0x00105276 File Offset: 0x00103676
		public static void AddVipRate(FlatBufferBuilder builder, VectorOffset vipRateOffset)
		{
			builder.AddOffset(8, vipRateOffset.Value, 0);
		}

		// Token: 0x06005566 RID: 21862 RVA: 0x00105288 File Offset: 0x00103688
		public static VectorOffset CreateVipRateVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06005567 RID: 21863 RVA: 0x001052CE File Offset: 0x001036CE
		public static void StartVipRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005568 RID: 21864 RVA: 0x001052D9 File Offset: 0x001036D9
		public static void AddIsBigReward(FlatBufferBuilder builder, int isBigReward)
		{
			builder.AddInt(9, isBigReward, 0);
		}

		// Token: 0x06005569 RID: 21865 RVA: 0x001052E5 File Offset: 0x001036E5
		public static void AddNotifyId(FlatBufferBuilder builder, int notifyId)
		{
			builder.AddInt(10, notifyId, 0);
		}

		// Token: 0x0600556A RID: 21866 RVA: 0x001052F1 File Offset: 0x001036F1
		public static void AddSuperLink(FlatBufferBuilder builder, int SuperLink)
		{
			builder.AddInt(11, SuperLink, 0);
		}

		// Token: 0x0600556B RID: 21867 RVA: 0x001052FD File Offset: 0x001036FD
		public static void AddRefreshType(FlatBufferBuilder builder, int refreshType)
		{
			builder.AddInt(12, refreshType, 0);
		}

		// Token: 0x0600556C RID: 21868 RVA: 0x00105309 File Offset: 0x00103709
		public static void AddRewardUid(FlatBufferBuilder builder, int rewardUid)
		{
			builder.AddInt(13, rewardUid, 0);
		}

		// Token: 0x0600556D RID: 21869 RVA: 0x00105315 File Offset: 0x00103715
		public static void AddPreview(FlatBufferBuilder builder, int Preview)
		{
			builder.AddInt(14, Preview, 0);
		}

		// Token: 0x0600556E RID: 21870 RVA: 0x00105324 File Offset: 0x00103724
		public static Offset<WeekSignTable> EndWeekSignTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<WeekSignTable>(value);
		}

		// Token: 0x0600556F RID: 21871 RVA: 0x0010533E File Offset: 0x0010373E
		public static void FinishWeekSignTableBuffer(FlatBufferBuilder builder, Offset<WeekSignTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001EB7 RID: 7863
		private Table __p = new Table();

		// Token: 0x04001EB8 RID: 7864
		private FlatBufferArray<string> vipRateValue;

		// Token: 0x02000626 RID: 1574
		public enum eCrypt
		{
			// Token: 0x04001EBA RID: 7866
			code = 1571332953
		}
	}
}
