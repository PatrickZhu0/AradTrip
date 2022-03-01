using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200029A RID: 666
	public class AdventureTeamTitleTypeTable : IFlatbufferObject
	{
		// Token: 0x1700036A RID: 874
		// (get) Token: 0x060017BB RID: 6075 RVA: 0x00072154 File Offset: 0x00070554
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060017BC RID: 6076 RVA: 0x00072161 File Offset: 0x00070561
		public static AdventureTeamTitleTypeTable GetRootAsAdventureTeamTitleTypeTable(ByteBuffer _bb)
		{
			return AdventureTeamTitleTypeTable.GetRootAsAdventureTeamTitleTypeTable(_bb, new AdventureTeamTitleTypeTable());
		}

		// Token: 0x060017BD RID: 6077 RVA: 0x0007216E File Offset: 0x0007056E
		public static AdventureTeamTitleTypeTable GetRootAsAdventureTeamTitleTypeTable(ByteBuffer _bb, AdventureTeamTitleTypeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060017BE RID: 6078 RVA: 0x0007218A File Offset: 0x0007058A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060017BF RID: 6079 RVA: 0x000721A4 File Offset: 0x000705A4
		public AdventureTeamTitleTypeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x060017C0 RID: 6080 RVA: 0x000721B0 File Offset: 0x000705B0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-774939027 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x060017C1 RID: 6081 RVA: 0x000721FC File Offset: 0x000705FC
		public int TitleTableID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-774939027 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x060017C2 RID: 6082 RVA: 0x00072248 File Offset: 0x00070648
		public AdventureTeamTitleTypeTable.eLimitType LimitType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (AdventureTeamTitleTypeTable.eLimitType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x060017C3 RID: 6083 RVA: 0x0007228C File Offset: 0x0007068C
		public int RankingRangeMin
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-774939027 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x060017C4 RID: 6084 RVA: 0x000722D8 File Offset: 0x000706D8
		public int RankingRangeMax
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-774939027 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060017C5 RID: 6085 RVA: 0x00072322 File Offset: 0x00070722
		public static Offset<AdventureTeamTitleTypeTable> CreateAdventureTeamTitleTypeTable(FlatBufferBuilder builder, int ID = 0, int TitleTableID = 0, AdventureTeamTitleTypeTable.eLimitType LimitType = AdventureTeamTitleTypeTable.eLimitType.None, int RankingRangeMin = 0, int RankingRangeMax = 0)
		{
			builder.StartObject(5);
			AdventureTeamTitleTypeTable.AddRankingRangeMax(builder, RankingRangeMax);
			AdventureTeamTitleTypeTable.AddRankingRangeMin(builder, RankingRangeMin);
			AdventureTeamTitleTypeTable.AddLimitType(builder, LimitType);
			AdventureTeamTitleTypeTable.AddTitleTableID(builder, TitleTableID);
			AdventureTeamTitleTypeTable.AddID(builder, ID);
			return AdventureTeamTitleTypeTable.EndAdventureTeamTitleTypeTable(builder);
		}

		// Token: 0x060017C6 RID: 6086 RVA: 0x00072356 File Offset: 0x00070756
		public static void StartAdventureTeamTitleTypeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060017C7 RID: 6087 RVA: 0x0007235F File Offset: 0x0007075F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060017C8 RID: 6088 RVA: 0x0007236A File Offset: 0x0007076A
		public static void AddTitleTableID(FlatBufferBuilder builder, int TitleTableID)
		{
			builder.AddInt(1, TitleTableID, 0);
		}

		// Token: 0x060017C9 RID: 6089 RVA: 0x00072375 File Offset: 0x00070775
		public static void AddLimitType(FlatBufferBuilder builder, AdventureTeamTitleTypeTable.eLimitType LimitType)
		{
			builder.AddInt(2, (int)LimitType, 0);
		}

		// Token: 0x060017CA RID: 6090 RVA: 0x00072380 File Offset: 0x00070780
		public static void AddRankingRangeMin(FlatBufferBuilder builder, int RankingRangeMin)
		{
			builder.AddInt(3, RankingRangeMin, 0);
		}

		// Token: 0x060017CB RID: 6091 RVA: 0x0007238B File Offset: 0x0007078B
		public static void AddRankingRangeMax(FlatBufferBuilder builder, int RankingRangeMax)
		{
			builder.AddInt(4, RankingRangeMax, 0);
		}

		// Token: 0x060017CC RID: 6092 RVA: 0x00072398 File Offset: 0x00070798
		public static Offset<AdventureTeamTitleTypeTable> EndAdventureTeamTitleTypeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AdventureTeamTitleTypeTable>(value);
		}

		// Token: 0x060017CD RID: 6093 RVA: 0x000723B2 File Offset: 0x000707B2
		public static void FinishAdventureTeamTitleTypeTableBuffer(FlatBufferBuilder builder, Offset<AdventureTeamTitleTypeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DDF RID: 3551
		private Table __p = new Table();

		// Token: 0x0200029B RID: 667
		public enum eLimitType
		{
			// Token: 0x04000DE1 RID: 3553
			None,
			// Token: 0x04000DE2 RID: 3554
			Ranking
		}

		// Token: 0x0200029C RID: 668
		public enum eCrypt
		{
			// Token: 0x04000DE4 RID: 3556
			code = -774939027
		}
	}
}
