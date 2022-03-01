using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200060A RID: 1546
	public class UltimateChallengeRewardTable : IFlatbufferObject
	{
		// Token: 0x1700168D RID: 5773
		// (get) Token: 0x060051A7 RID: 20903 RVA: 0x000FB330 File Offset: 0x000F9730
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060051A8 RID: 20904 RVA: 0x000FB33D File Offset: 0x000F973D
		public static UltimateChallengeRewardTable GetRootAsUltimateChallengeRewardTable(ByteBuffer _bb)
		{
			return UltimateChallengeRewardTable.GetRootAsUltimateChallengeRewardTable(_bb, new UltimateChallengeRewardTable());
		}

		// Token: 0x060051A9 RID: 20905 RVA: 0x000FB34A File Offset: 0x000F974A
		public static UltimateChallengeRewardTable GetRootAsUltimateChallengeRewardTable(ByteBuffer _bb, UltimateChallengeRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060051AA RID: 20906 RVA: 0x000FB366 File Offset: 0x000F9766
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060051AB RID: 20907 RVA: 0x000FB380 File Offset: 0x000F9780
		public UltimateChallengeRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700168E RID: 5774
		// (get) Token: 0x060051AC RID: 20908 RVA: 0x000FB38C File Offset: 0x000F978C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-605253449 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700168F RID: 5775
		// (get) Token: 0x060051AD RID: 20909 RVA: 0x000FB3D8 File Offset: 0x000F97D8
		public int MinClearDays
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-605253449 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001690 RID: 5776
		// (get) Token: 0x060051AE RID: 20910 RVA: 0x000FB424 File Offset: 0x000F9824
		public int MaxClearDays
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-605253449 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001691 RID: 5777
		// (get) Token: 0x060051AF RID: 20911 RVA: 0x000FB470 File Offset: 0x000F9870
		public string RewardItem
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051B0 RID: 20912 RVA: 0x000FB4B3 File Offset: 0x000F98B3
		public ArraySegment<byte>? GetRewardItemBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001692 RID: 5778
		// (get) Token: 0x060051B1 RID: 20913 RVA: 0x000FB4C4 File Offset: 0x000F98C4
		public string Rreview
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051B2 RID: 20914 RVA: 0x000FB507 File Offset: 0x000F9907
		public ArraySegment<byte>? GetRreviewBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x060051B3 RID: 20915 RVA: 0x000FB516 File Offset: 0x000F9916
		public static Offset<UltimateChallengeRewardTable> CreateUltimateChallengeRewardTable(FlatBufferBuilder builder, int ID = 0, int MinClearDays = 0, int MaxClearDays = 0, StringOffset RewardItemOffset = default(StringOffset), StringOffset RreviewOffset = default(StringOffset))
		{
			builder.StartObject(5);
			UltimateChallengeRewardTable.AddRreview(builder, RreviewOffset);
			UltimateChallengeRewardTable.AddRewardItem(builder, RewardItemOffset);
			UltimateChallengeRewardTable.AddMaxClearDays(builder, MaxClearDays);
			UltimateChallengeRewardTable.AddMinClearDays(builder, MinClearDays);
			UltimateChallengeRewardTable.AddID(builder, ID);
			return UltimateChallengeRewardTable.EndUltimateChallengeRewardTable(builder);
		}

		// Token: 0x060051B4 RID: 20916 RVA: 0x000FB54A File Offset: 0x000F994A
		public static void StartUltimateChallengeRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060051B5 RID: 20917 RVA: 0x000FB553 File Offset: 0x000F9953
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060051B6 RID: 20918 RVA: 0x000FB55E File Offset: 0x000F995E
		public static void AddMinClearDays(FlatBufferBuilder builder, int MinClearDays)
		{
			builder.AddInt(1, MinClearDays, 0);
		}

		// Token: 0x060051B7 RID: 20919 RVA: 0x000FB569 File Offset: 0x000F9969
		public static void AddMaxClearDays(FlatBufferBuilder builder, int MaxClearDays)
		{
			builder.AddInt(2, MaxClearDays, 0);
		}

		// Token: 0x060051B8 RID: 20920 RVA: 0x000FB574 File Offset: 0x000F9974
		public static void AddRewardItem(FlatBufferBuilder builder, StringOffset RewardItemOffset)
		{
			builder.AddOffset(3, RewardItemOffset.Value, 0);
		}

		// Token: 0x060051B9 RID: 20921 RVA: 0x000FB585 File Offset: 0x000F9985
		public static void AddRreview(FlatBufferBuilder builder, StringOffset RreviewOffset)
		{
			builder.AddOffset(4, RreviewOffset.Value, 0);
		}

		// Token: 0x060051BA RID: 20922 RVA: 0x000FB598 File Offset: 0x000F9998
		public static Offset<UltimateChallengeRewardTable> EndUltimateChallengeRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<UltimateChallengeRewardTable>(value);
		}

		// Token: 0x060051BB RID: 20923 RVA: 0x000FB5B2 File Offset: 0x000F99B2
		public static void FinishUltimateChallengeRewardTableBuffer(FlatBufferBuilder builder, Offset<UltimateChallengeRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E18 RID: 7704
		private Table __p = new Table();

		// Token: 0x0200060B RID: 1547
		public enum eCrypt
		{
			// Token: 0x04001E1A RID: 7706
			code = -605253449
		}
	}
}
