using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002E0 RID: 736
	public class BetHorseShooterStatus : IFlatbufferObject
	{
		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06001AF1 RID: 6897 RVA: 0x000790FC File Offset: 0x000774FC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x00079109 File Offset: 0x00077509
		public static BetHorseShooterStatus GetRootAsBetHorseShooterStatus(ByteBuffer _bb)
		{
			return BetHorseShooterStatus.GetRootAsBetHorseShooterStatus(_bb, new BetHorseShooterStatus());
		}

		// Token: 0x06001AF3 RID: 6899 RVA: 0x00079116 File Offset: 0x00077516
		public static BetHorseShooterStatus GetRootAsBetHorseShooterStatus(ByteBuffer _bb, BetHorseShooterStatus obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x00079132 File Offset: 0x00077532
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x0007914C File Offset: 0x0007754C
		public BetHorseShooterStatus __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06001AF6 RID: 6902 RVA: 0x00079158 File Offset: 0x00077558
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-745360500 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06001AF7 RID: 6903 RVA: 0x000791A4 File Offset: 0x000775A4
		public int StatusType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-745360500 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06001AF8 RID: 6904 RVA: 0x000791F0 File Offset: 0x000775F0
		public int statusType2
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-745360500 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06001AF9 RID: 6905 RVA: 0x0007923C File Offset: 0x0007763C
		public int WinRate
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-745360500 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001AFA RID: 6906 RVA: 0x00079286 File Offset: 0x00077686
		public static Offset<BetHorseShooterStatus> CreateBetHorseShooterStatus(FlatBufferBuilder builder, int ID = 0, int StatusType = 0, int statusType2 = 0, int WinRate = 0)
		{
			builder.StartObject(4);
			BetHorseShooterStatus.AddWinRate(builder, WinRate);
			BetHorseShooterStatus.AddStatusType2(builder, statusType2);
			BetHorseShooterStatus.AddStatusType(builder, StatusType);
			BetHorseShooterStatus.AddID(builder, ID);
			return BetHorseShooterStatus.EndBetHorseShooterStatus(builder);
		}

		// Token: 0x06001AFB RID: 6907 RVA: 0x000792B2 File Offset: 0x000776B2
		public static void StartBetHorseShooterStatus(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x000792BB File Offset: 0x000776BB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001AFD RID: 6909 RVA: 0x000792C6 File Offset: 0x000776C6
		public static void AddStatusType(FlatBufferBuilder builder, int StatusType)
		{
			builder.AddInt(1, StatusType, 0);
		}

		// Token: 0x06001AFE RID: 6910 RVA: 0x000792D1 File Offset: 0x000776D1
		public static void AddStatusType2(FlatBufferBuilder builder, int statusType2)
		{
			builder.AddInt(2, statusType2, 0);
		}

		// Token: 0x06001AFF RID: 6911 RVA: 0x000792DC File Offset: 0x000776DC
		public static void AddWinRate(FlatBufferBuilder builder, int WinRate)
		{
			builder.AddInt(3, WinRate, 0);
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x000792E8 File Offset: 0x000776E8
		public static Offset<BetHorseShooterStatus> EndBetHorseShooterStatus(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BetHorseShooterStatus>(value);
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x00079302 File Offset: 0x00077702
		public static void FinishBetHorseShooterStatusBuffer(FlatBufferBuilder builder, Offset<BetHorseShooterStatus> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EB7 RID: 3767
		private Table __p = new Table();

		// Token: 0x020002E1 RID: 737
		public enum eCrypt
		{
			// Token: 0x04000EB9 RID: 3769
			code = -745360500
		}
	}
}
