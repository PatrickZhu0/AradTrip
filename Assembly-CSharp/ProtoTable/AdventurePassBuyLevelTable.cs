using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200028D RID: 653
	public class AdventurePassBuyLevelTable : IFlatbufferObject
	{
		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06001713 RID: 5907 RVA: 0x00070C18 File Offset: 0x0006F018
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001714 RID: 5908 RVA: 0x00070C25 File Offset: 0x0006F025
		public static AdventurePassBuyLevelTable GetRootAsAdventurePassBuyLevelTable(ByteBuffer _bb)
		{
			return AdventurePassBuyLevelTable.GetRootAsAdventurePassBuyLevelTable(_bb, new AdventurePassBuyLevelTable());
		}

		// Token: 0x06001715 RID: 5909 RVA: 0x00070C32 File Offset: 0x0006F032
		public static AdventurePassBuyLevelTable GetRootAsAdventurePassBuyLevelTable(ByteBuffer _bb, AdventurePassBuyLevelTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001716 RID: 5910 RVA: 0x00070C4E File Offset: 0x0006F04E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001717 RID: 5911 RVA: 0x00070C68 File Offset: 0x0006F068
		public AdventurePassBuyLevelTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x00070C74 File Offset: 0x0006F074
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-51098687 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06001719 RID: 5913 RVA: 0x00070CC0 File Offset: 0x0006F0C0
		public int PointCost
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-51098687 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600171A RID: 5914 RVA: 0x00070D09 File Offset: 0x0006F109
		public static Offset<AdventurePassBuyLevelTable> CreateAdventurePassBuyLevelTable(FlatBufferBuilder builder, int ID = 0, int PointCost = 0)
		{
			builder.StartObject(2);
			AdventurePassBuyLevelTable.AddPointCost(builder, PointCost);
			AdventurePassBuyLevelTable.AddID(builder, ID);
			return AdventurePassBuyLevelTable.EndAdventurePassBuyLevelTable(builder);
		}

		// Token: 0x0600171B RID: 5915 RVA: 0x00070D26 File Offset: 0x0006F126
		public static void StartAdventurePassBuyLevelTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x0600171C RID: 5916 RVA: 0x00070D2F File Offset: 0x0006F12F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600171D RID: 5917 RVA: 0x00070D3A File Offset: 0x0006F13A
		public static void AddPointCost(FlatBufferBuilder builder, int PointCost)
		{
			builder.AddInt(1, PointCost, 0);
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x00070D48 File Offset: 0x0006F148
		public static Offset<AdventurePassBuyLevelTable> EndAdventurePassBuyLevelTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AdventurePassBuyLevelTable>(value);
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x00070D62 File Offset: 0x0006F162
		public static void FinishAdventurePassBuyLevelTableBuffer(FlatBufferBuilder builder, Offset<AdventurePassBuyLevelTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DC5 RID: 3525
		private Table __p = new Table();

		// Token: 0x0200028E RID: 654
		public enum eCrypt
		{
			// Token: 0x04000DC7 RID: 3527
			code = -51098687
		}
	}
}
