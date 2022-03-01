using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002D8 RID: 728
	public class BetHorseOccuSuppress : IFlatbufferObject
	{
		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06001A84 RID: 6788 RVA: 0x00078238 File Offset: 0x00076638
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001A85 RID: 6789 RVA: 0x00078245 File Offset: 0x00076645
		public static BetHorseOccuSuppress GetRootAsBetHorseOccuSuppress(ByteBuffer _bb)
		{
			return BetHorseOccuSuppress.GetRootAsBetHorseOccuSuppress(_bb, new BetHorseOccuSuppress());
		}

		// Token: 0x06001A86 RID: 6790 RVA: 0x00078252 File Offset: 0x00076652
		public static BetHorseOccuSuppress GetRootAsBetHorseOccuSuppress(ByteBuffer _bb, BetHorseOccuSuppress obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001A87 RID: 6791 RVA: 0x0007826E File Offset: 0x0007666E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001A88 RID: 6792 RVA: 0x00078288 File Offset: 0x00076688
		public BetHorseOccuSuppress __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06001A89 RID: 6793 RVA: 0x00078294 File Offset: 0x00076694
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1614518943 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06001A8A RID: 6794 RVA: 0x000782E0 File Offset: 0x000766E0
		public int OccupationType1
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1614518943 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06001A8B RID: 6795 RVA: 0x0007832C File Offset: 0x0007672C
		public int OccupationType2
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1614518943 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06001A8C RID: 6796 RVA: 0x00078378 File Offset: 0x00076778
		public int WinRate
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1614518943 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001A8D RID: 6797 RVA: 0x000783C2 File Offset: 0x000767C2
		public static Offset<BetHorseOccuSuppress> CreateBetHorseOccuSuppress(FlatBufferBuilder builder, int ID = 0, int OccupationType1 = 0, int OccupationType2 = 0, int WinRate = 0)
		{
			builder.StartObject(4);
			BetHorseOccuSuppress.AddWinRate(builder, WinRate);
			BetHorseOccuSuppress.AddOccupationType2(builder, OccupationType2);
			BetHorseOccuSuppress.AddOccupationType1(builder, OccupationType1);
			BetHorseOccuSuppress.AddID(builder, ID);
			return BetHorseOccuSuppress.EndBetHorseOccuSuppress(builder);
		}

		// Token: 0x06001A8E RID: 6798 RVA: 0x000783EE File Offset: 0x000767EE
		public static void StartBetHorseOccuSuppress(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001A8F RID: 6799 RVA: 0x000783F7 File Offset: 0x000767F7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001A90 RID: 6800 RVA: 0x00078402 File Offset: 0x00076802
		public static void AddOccupationType1(FlatBufferBuilder builder, int OccupationType1)
		{
			builder.AddInt(1, OccupationType1, 0);
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x0007840D File Offset: 0x0007680D
		public static void AddOccupationType2(FlatBufferBuilder builder, int OccupationType2)
		{
			builder.AddInt(2, OccupationType2, 0);
		}

		// Token: 0x06001A92 RID: 6802 RVA: 0x00078418 File Offset: 0x00076818
		public static void AddWinRate(FlatBufferBuilder builder, int WinRate)
		{
			builder.AddInt(3, WinRate, 0);
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x00078424 File Offset: 0x00076824
		public static Offset<BetHorseOccuSuppress> EndBetHorseOccuSuppress(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BetHorseOccuSuppress>(value);
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x0007843E File Offset: 0x0007683E
		public static void FinishBetHorseOccuSuppressBuffer(FlatBufferBuilder builder, Offset<BetHorseOccuSuppress> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EAB RID: 3755
		private Table __p = new Table();

		// Token: 0x020002D9 RID: 729
		public enum eCrypt
		{
			// Token: 0x04000EAD RID: 3757
			code = 1614518943
		}
	}
}
