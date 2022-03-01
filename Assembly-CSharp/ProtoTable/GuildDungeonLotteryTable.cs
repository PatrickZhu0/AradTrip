using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200046D RID: 1133
	public class GuildDungeonLotteryTable : IFlatbufferObject
	{
		// Token: 0x17000D9A RID: 3482
		// (get) Token: 0x06003672 RID: 13938 RVA: 0x000BB740 File Offset: 0x000B9B40
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003673 RID: 13939 RVA: 0x000BB74D File Offset: 0x000B9B4D
		public static GuildDungeonLotteryTable GetRootAsGuildDungeonLotteryTable(ByteBuffer _bb)
		{
			return GuildDungeonLotteryTable.GetRootAsGuildDungeonLotteryTable(_bb, new GuildDungeonLotteryTable());
		}

		// Token: 0x06003674 RID: 13940 RVA: 0x000BB75A File Offset: 0x000B9B5A
		public static GuildDungeonLotteryTable GetRootAsGuildDungeonLotteryTable(ByteBuffer _bb, GuildDungeonLotteryTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003675 RID: 13941 RVA: 0x000BB776 File Offset: 0x000B9B76
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003676 RID: 13942 RVA: 0x000BB790 File Offset: 0x000B9B90
		public GuildDungeonLotteryTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D9B RID: 3483
		// (get) Token: 0x06003677 RID: 13943 RVA: 0x000BB79C File Offset: 0x000B9B9C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (17442364 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D9C RID: 3484
		// (get) Token: 0x06003678 RID: 13944 RVA: 0x000BB7E8 File Offset: 0x000B9BE8
		public int rewardGroup
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (17442364 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D9D RID: 3485
		// (get) Token: 0x06003679 RID: 13945 RVA: 0x000BB834 File Offset: 0x000B9C34
		public int itemID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (17442364 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D9E RID: 3486
		// (get) Token: 0x0600367A RID: 13946 RVA: 0x000BB880 File Offset: 0x000B9C80
		public int itemNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (17442364 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D9F RID: 3487
		// (get) Token: 0x0600367B RID: 13947 RVA: 0x000BB8CC File Offset: 0x000B9CCC
		public int weight
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (17442364 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DA0 RID: 3488
		// (get) Token: 0x0600367C RID: 13948 RVA: 0x000BB918 File Offset: 0x000B9D18
		public int isHighVal
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (17442364 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600367D RID: 13949 RVA: 0x000BB962 File Offset: 0x000B9D62
		public static Offset<GuildDungeonLotteryTable> CreateGuildDungeonLotteryTable(FlatBufferBuilder builder, int ID = 0, int rewardGroup = 0, int itemID = 0, int itemNum = 0, int weight = 0, int isHighVal = 0)
		{
			builder.StartObject(6);
			GuildDungeonLotteryTable.AddIsHighVal(builder, isHighVal);
			GuildDungeonLotteryTable.AddWeight(builder, weight);
			GuildDungeonLotteryTable.AddItemNum(builder, itemNum);
			GuildDungeonLotteryTable.AddItemID(builder, itemID);
			GuildDungeonLotteryTable.AddRewardGroup(builder, rewardGroup);
			GuildDungeonLotteryTable.AddID(builder, ID);
			return GuildDungeonLotteryTable.EndGuildDungeonLotteryTable(builder);
		}

		// Token: 0x0600367E RID: 13950 RVA: 0x000BB99E File Offset: 0x000B9D9E
		public static void StartGuildDungeonLotteryTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x0600367F RID: 13951 RVA: 0x000BB9A7 File Offset: 0x000B9DA7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003680 RID: 13952 RVA: 0x000BB9B2 File Offset: 0x000B9DB2
		public static void AddRewardGroup(FlatBufferBuilder builder, int rewardGroup)
		{
			builder.AddInt(1, rewardGroup, 0);
		}

		// Token: 0x06003681 RID: 13953 RVA: 0x000BB9BD File Offset: 0x000B9DBD
		public static void AddItemID(FlatBufferBuilder builder, int itemID)
		{
			builder.AddInt(2, itemID, 0);
		}

		// Token: 0x06003682 RID: 13954 RVA: 0x000BB9C8 File Offset: 0x000B9DC8
		public static void AddItemNum(FlatBufferBuilder builder, int itemNum)
		{
			builder.AddInt(3, itemNum, 0);
		}

		// Token: 0x06003683 RID: 13955 RVA: 0x000BB9D3 File Offset: 0x000B9DD3
		public static void AddWeight(FlatBufferBuilder builder, int weight)
		{
			builder.AddInt(4, weight, 0);
		}

		// Token: 0x06003684 RID: 13956 RVA: 0x000BB9DE File Offset: 0x000B9DDE
		public static void AddIsHighVal(FlatBufferBuilder builder, int isHighVal)
		{
			builder.AddInt(5, isHighVal, 0);
		}

		// Token: 0x06003685 RID: 13957 RVA: 0x000BB9EC File Offset: 0x000B9DEC
		public static Offset<GuildDungeonLotteryTable> EndGuildDungeonLotteryTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildDungeonLotteryTable>(value);
		}

		// Token: 0x06003686 RID: 13958 RVA: 0x000BBA06 File Offset: 0x000B9E06
		public static void FinishGuildDungeonLotteryTableBuffer(FlatBufferBuilder builder, Offset<GuildDungeonLotteryTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015B9 RID: 5561
		private Table __p = new Table();

		// Token: 0x0200046E RID: 1134
		public enum eCrypt
		{
			// Token: 0x040015BB RID: 5563
			code = 17442364
		}
	}
}
