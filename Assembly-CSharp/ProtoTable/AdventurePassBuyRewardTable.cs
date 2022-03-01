using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200028F RID: 655
	public class AdventurePassBuyRewardTable : IFlatbufferObject
	{
		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06001721 RID: 5921 RVA: 0x00070D84 File Offset: 0x0006F184
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001722 RID: 5922 RVA: 0x00070D91 File Offset: 0x0006F191
		public static AdventurePassBuyRewardTable GetRootAsAdventurePassBuyRewardTable(ByteBuffer _bb)
		{
			return AdventurePassBuyRewardTable.GetRootAsAdventurePassBuyRewardTable(_bb, new AdventurePassBuyRewardTable());
		}

		// Token: 0x06001723 RID: 5923 RVA: 0x00070D9E File Offset: 0x0006F19E
		public static AdventurePassBuyRewardTable GetRootAsAdventurePassBuyRewardTable(ByteBuffer _bb, AdventurePassBuyRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001724 RID: 5924 RVA: 0x00070DBA File Offset: 0x0006F1BA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001725 RID: 5925 RVA: 0x00070DD4 File Offset: 0x0006F1D4
		public AdventurePassBuyRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06001726 RID: 5926 RVA: 0x00070DE0 File Offset: 0x0006F1E0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-410530372 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06001727 RID: 5927 RVA: 0x00070E2C File Offset: 0x0006F22C
		public int Season
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-410530372 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06001728 RID: 5928 RVA: 0x00070E78 File Offset: 0x0006F278
		public int KingLevel
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-410530372 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06001729 RID: 5929 RVA: 0x00070EC4 File Offset: 0x0006F2C4
		public string KingReward
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600172A RID: 5930 RVA: 0x00070F07 File Offset: 0x0006F307
		public ArraySegment<byte>? GetKingRewardBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x0600172B RID: 5931 RVA: 0x00070F18 File Offset: 0x0006F318
		public int TopKingLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-410530372 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x0600172C RID: 5932 RVA: 0x00070F64 File Offset: 0x0006F364
		public string TopKingReward
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600172D RID: 5933 RVA: 0x00070FA7 File Offset: 0x0006F3A7
		public ArraySegment<byte>? GetTopKingRewardBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x0600172E RID: 5934 RVA: 0x00070FB8 File Offset: 0x0006F3B8
		public int KingPrice
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-410530372 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x0600172F RID: 5935 RVA: 0x00071004 File Offset: 0x0006F404
		public int TopKingPrice
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-410530372 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06001730 RID: 5936 RVA: 0x00071050 File Offset: 0x0006F450
		public int buyType
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-410530372 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06001731 RID: 5937 RVA: 0x0007109C File Offset: 0x0006F49C
		public string KingRewardBanner1
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x000710DF File Offset: 0x0006F4DF
		public ArraySegment<byte>? GetKingRewardBanner1Bytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06001733 RID: 5939 RVA: 0x000710F0 File Offset: 0x0006F4F0
		public string KingRewardBanner1Text
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001734 RID: 5940 RVA: 0x00071133 File Offset: 0x0006F533
		public ArraySegment<byte>? GetKingRewardBanner1TextBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06001735 RID: 5941 RVA: 0x00071144 File Offset: 0x0006F544
		public string KingRewardBanner2
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x00071187 File Offset: 0x0006F587
		public ArraySegment<byte>? GetKingRewardBanner2Bytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06001737 RID: 5943 RVA: 0x00071198 File Offset: 0x0006F598
		public string KingRewardBanner2Text
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001738 RID: 5944 RVA: 0x000711DB File Offset: 0x0006F5DB
		public ArraySegment<byte>? GetKingRewardBanner2TextBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06001739 RID: 5945 RVA: 0x000711EC File Offset: 0x0006F5EC
		public string KingRewardBanner3
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x0007122F File Offset: 0x0006F62F
		public ArraySegment<byte>? GetKingRewardBanner3Bytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x0600173B RID: 5947 RVA: 0x00071240 File Offset: 0x0006F640
		public string KingRewardBanner3Text
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600173C RID: 5948 RVA: 0x00071283 File Offset: 0x0006F683
		public ArraySegment<byte>? GetKingRewardBanner3TextBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x0600173D RID: 5949 RVA: 0x00071294 File Offset: 0x0006F694
		public string GiftBagID
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600173E RID: 5950 RVA: 0x000712D7 File Offset: 0x0006F6D7
		public ArraySegment<byte>? GetGiftBagIDBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x0600173F RID: 5951 RVA: 0x000712E8 File Offset: 0x0006F6E8
		public string Normal
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001740 RID: 5952 RVA: 0x0007132B File Offset: 0x0006F72B
		public ArraySegment<byte>? GetNormalBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06001741 RID: 5953 RVA: 0x0007133C File Offset: 0x0006F73C
		public string High
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001742 RID: 5954 RVA: 0x0007137F File Offset: 0x0006F77F
		public ArraySegment<byte>? GetHighBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x06001743 RID: 5955 RVA: 0x00071390 File Offset: 0x0006F790
		public static Offset<AdventurePassBuyRewardTable> CreateAdventurePassBuyRewardTable(FlatBufferBuilder builder, int ID = 0, int Season = 0, int KingLevel = 0, StringOffset KingRewardOffset = default(StringOffset), int TopKingLevel = 0, StringOffset TopKingRewardOffset = default(StringOffset), int KingPrice = 0, int TopKingPrice = 0, int buyType = 0, StringOffset KingRewardBanner1Offset = default(StringOffset), StringOffset KingRewardBanner1TextOffset = default(StringOffset), StringOffset KingRewardBanner2Offset = default(StringOffset), StringOffset KingRewardBanner2TextOffset = default(StringOffset), StringOffset KingRewardBanner3Offset = default(StringOffset), StringOffset KingRewardBanner3TextOffset = default(StringOffset), StringOffset GiftBagIDOffset = default(StringOffset), StringOffset NormalOffset = default(StringOffset), StringOffset HighOffset = default(StringOffset))
		{
			builder.StartObject(18);
			AdventurePassBuyRewardTable.AddHigh(builder, HighOffset);
			AdventurePassBuyRewardTable.AddNormal(builder, NormalOffset);
			AdventurePassBuyRewardTable.AddGiftBagID(builder, GiftBagIDOffset);
			AdventurePassBuyRewardTable.AddKingRewardBanner3Text(builder, KingRewardBanner3TextOffset);
			AdventurePassBuyRewardTable.AddKingRewardBanner3(builder, KingRewardBanner3Offset);
			AdventurePassBuyRewardTable.AddKingRewardBanner2Text(builder, KingRewardBanner2TextOffset);
			AdventurePassBuyRewardTable.AddKingRewardBanner2(builder, KingRewardBanner2Offset);
			AdventurePassBuyRewardTable.AddKingRewardBanner1Text(builder, KingRewardBanner1TextOffset);
			AdventurePassBuyRewardTable.AddKingRewardBanner1(builder, KingRewardBanner1Offset);
			AdventurePassBuyRewardTable.AddBuyType(builder, buyType);
			AdventurePassBuyRewardTable.AddTopKingPrice(builder, TopKingPrice);
			AdventurePassBuyRewardTable.AddKingPrice(builder, KingPrice);
			AdventurePassBuyRewardTable.AddTopKingReward(builder, TopKingRewardOffset);
			AdventurePassBuyRewardTable.AddTopKingLevel(builder, TopKingLevel);
			AdventurePassBuyRewardTable.AddKingReward(builder, KingRewardOffset);
			AdventurePassBuyRewardTable.AddKingLevel(builder, KingLevel);
			AdventurePassBuyRewardTable.AddSeason(builder, Season);
			AdventurePassBuyRewardTable.AddID(builder, ID);
			return AdventurePassBuyRewardTable.EndAdventurePassBuyRewardTable(builder);
		}

		// Token: 0x06001744 RID: 5956 RVA: 0x00071438 File Offset: 0x0006F838
		public static void StartAdventurePassBuyRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(18);
		}

		// Token: 0x06001745 RID: 5957 RVA: 0x00071442 File Offset: 0x0006F842
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001746 RID: 5958 RVA: 0x0007144D File Offset: 0x0006F84D
		public static void AddSeason(FlatBufferBuilder builder, int Season)
		{
			builder.AddInt(1, Season, 0);
		}

		// Token: 0x06001747 RID: 5959 RVA: 0x00071458 File Offset: 0x0006F858
		public static void AddKingLevel(FlatBufferBuilder builder, int KingLevel)
		{
			builder.AddInt(2, KingLevel, 0);
		}

		// Token: 0x06001748 RID: 5960 RVA: 0x00071463 File Offset: 0x0006F863
		public static void AddKingReward(FlatBufferBuilder builder, StringOffset KingRewardOffset)
		{
			builder.AddOffset(3, KingRewardOffset.Value, 0);
		}

		// Token: 0x06001749 RID: 5961 RVA: 0x00071474 File Offset: 0x0006F874
		public static void AddTopKingLevel(FlatBufferBuilder builder, int TopKingLevel)
		{
			builder.AddInt(4, TopKingLevel, 0);
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0007147F File Offset: 0x0006F87F
		public static void AddTopKingReward(FlatBufferBuilder builder, StringOffset TopKingRewardOffset)
		{
			builder.AddOffset(5, TopKingRewardOffset.Value, 0);
		}

		// Token: 0x0600174B RID: 5963 RVA: 0x00071490 File Offset: 0x0006F890
		public static void AddKingPrice(FlatBufferBuilder builder, int KingPrice)
		{
			builder.AddInt(6, KingPrice, 0);
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x0007149B File Offset: 0x0006F89B
		public static void AddTopKingPrice(FlatBufferBuilder builder, int TopKingPrice)
		{
			builder.AddInt(7, TopKingPrice, 0);
		}

		// Token: 0x0600174D RID: 5965 RVA: 0x000714A6 File Offset: 0x0006F8A6
		public static void AddBuyType(FlatBufferBuilder builder, int buyType)
		{
			builder.AddInt(8, buyType, 0);
		}

		// Token: 0x0600174E RID: 5966 RVA: 0x000714B1 File Offset: 0x0006F8B1
		public static void AddKingRewardBanner1(FlatBufferBuilder builder, StringOffset KingRewardBanner1Offset)
		{
			builder.AddOffset(9, KingRewardBanner1Offset.Value, 0);
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x000714C3 File Offset: 0x0006F8C3
		public static void AddKingRewardBanner1Text(FlatBufferBuilder builder, StringOffset KingRewardBanner1TextOffset)
		{
			builder.AddOffset(10, KingRewardBanner1TextOffset.Value, 0);
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x000714D5 File Offset: 0x0006F8D5
		public static void AddKingRewardBanner2(FlatBufferBuilder builder, StringOffset KingRewardBanner2Offset)
		{
			builder.AddOffset(11, KingRewardBanner2Offset.Value, 0);
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x000714E7 File Offset: 0x0006F8E7
		public static void AddKingRewardBanner2Text(FlatBufferBuilder builder, StringOffset KingRewardBanner2TextOffset)
		{
			builder.AddOffset(12, KingRewardBanner2TextOffset.Value, 0);
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x000714F9 File Offset: 0x0006F8F9
		public static void AddKingRewardBanner3(FlatBufferBuilder builder, StringOffset KingRewardBanner3Offset)
		{
			builder.AddOffset(13, KingRewardBanner3Offset.Value, 0);
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x0007150B File Offset: 0x0006F90B
		public static void AddKingRewardBanner3Text(FlatBufferBuilder builder, StringOffset KingRewardBanner3TextOffset)
		{
			builder.AddOffset(14, KingRewardBanner3TextOffset.Value, 0);
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x0007151D File Offset: 0x0006F91D
		public static void AddGiftBagID(FlatBufferBuilder builder, StringOffset GiftBagIDOffset)
		{
			builder.AddOffset(15, GiftBagIDOffset.Value, 0);
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x0007152F File Offset: 0x0006F92F
		public static void AddNormal(FlatBufferBuilder builder, StringOffset NormalOffset)
		{
			builder.AddOffset(16, NormalOffset.Value, 0);
		}

		// Token: 0x06001756 RID: 5974 RVA: 0x00071541 File Offset: 0x0006F941
		public static void AddHigh(FlatBufferBuilder builder, StringOffset HighOffset)
		{
			builder.AddOffset(17, HighOffset.Value, 0);
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x00071554 File Offset: 0x0006F954
		public static Offset<AdventurePassBuyRewardTable> EndAdventurePassBuyRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AdventurePassBuyRewardTable>(value);
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x0007156E File Offset: 0x0006F96E
		public static void FinishAdventurePassBuyRewardTableBuffer(FlatBufferBuilder builder, Offset<AdventurePassBuyRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DC8 RID: 3528
		private Table __p = new Table();

		// Token: 0x02000290 RID: 656
		public enum eCrypt
		{
			// Token: 0x04000DCA RID: 3530
			code = -410530372
		}
	}
}
