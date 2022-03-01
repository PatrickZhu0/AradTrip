using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000471 RID: 1137
	public class GuildDungeonRewardTable : IFlatbufferObject
	{
		// Token: 0x17000DB3 RID: 3507
		// (get) Token: 0x060036BB RID: 14011 RVA: 0x000BC19C File Offset: 0x000BA59C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060036BC RID: 14012 RVA: 0x000BC1A9 File Offset: 0x000BA5A9
		public static GuildDungeonRewardTable GetRootAsGuildDungeonRewardTable(ByteBuffer _bb)
		{
			return GuildDungeonRewardTable.GetRootAsGuildDungeonRewardTable(_bb, new GuildDungeonRewardTable());
		}

		// Token: 0x060036BD RID: 14013 RVA: 0x000BC1B6 File Offset: 0x000BA5B6
		public static GuildDungeonRewardTable GetRootAsGuildDungeonRewardTable(ByteBuffer _bb, GuildDungeonRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060036BE RID: 14014 RVA: 0x000BC1D2 File Offset: 0x000BA5D2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060036BF RID: 14015 RVA: 0x000BC1EC File Offset: 0x000BA5EC
		public GuildDungeonRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DB4 RID: 3508
		// (get) Token: 0x060036C0 RID: 14016 RVA: 0x000BC1F8 File Offset: 0x000BA5F8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DB5 RID: 3509
		// (get) Token: 0x060036C1 RID: 14017 RVA: 0x000BC244 File Offset: 0x000BA644
		public int rewardType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DB6 RID: 3510
		// (get) Token: 0x060036C2 RID: 14018 RVA: 0x000BC290 File Offset: 0x000BA690
		public int dungeonType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DB7 RID: 3511
		// (get) Token: 0x060036C3 RID: 14019 RVA: 0x000BC2DC File Offset: 0x000BA6DC
		public int damageWeight
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DB8 RID: 3512
		// (get) Token: 0x060036C4 RID: 14020 RVA: 0x000BC328 File Offset: 0x000BA728
		public int ownerBonusLimit
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060036C5 RID: 14021 RVA: 0x000BC374 File Offset: 0x000BA774
		public int rewardGroupArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DB9 RID: 3513
		// (get) Token: 0x060036C6 RID: 14022 RVA: 0x000BC3C4 File Offset: 0x000BA7C4
		public int rewardGroupLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060036C7 RID: 14023 RVA: 0x000BC3F7 File Offset: 0x000BA7F7
		public ArraySegment<byte>? GetRewardGroupBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000DBA RID: 3514
		// (get) Token: 0x060036C8 RID: 14024 RVA: 0x000BC406 File Offset: 0x000BA806
		public FlatBufferArray<int> rewardGroup
		{
			get
			{
				if (this.rewardGroupValue == null)
				{
					this.rewardGroupValue = new FlatBufferArray<int>(new Func<int, int>(this.rewardGroupArray), this.rewardGroupLength);
				}
				return this.rewardGroupValue;
			}
		}

		// Token: 0x060036C9 RID: 14025 RVA: 0x000BC438 File Offset: 0x000BA838
		public int rewardCountArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DBB RID: 3515
		// (get) Token: 0x060036CA RID: 14026 RVA: 0x000BC488 File Offset: 0x000BA888
		public int rewardCountLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060036CB RID: 14027 RVA: 0x000BC4BB File Offset: 0x000BA8BB
		public ArraySegment<byte>? GetRewardCountBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000DBC RID: 3516
		// (get) Token: 0x060036CC RID: 14028 RVA: 0x000BC4CA File Offset: 0x000BA8CA
		public FlatBufferArray<int> rewardCount
		{
			get
			{
				if (this.rewardCountValue == null)
				{
					this.rewardCountValue = new FlatBufferArray<int>(new Func<int, int>(this.rewardCountArray), this.rewardCountLength);
				}
				return this.rewardCountValue;
			}
		}

		// Token: 0x060036CD RID: 14029 RVA: 0x000BC4FC File Offset: 0x000BA8FC
		public int rewardWeightArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DBD RID: 3517
		// (get) Token: 0x060036CE RID: 14030 RVA: 0x000BC54C File Offset: 0x000BA94C
		public int rewardWeightLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060036CF RID: 14031 RVA: 0x000BC57F File Offset: 0x000BA97F
		public ArraySegment<byte>? GetRewardWeightBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000DBE RID: 3518
		// (get) Token: 0x060036D0 RID: 14032 RVA: 0x000BC58E File Offset: 0x000BA98E
		public FlatBufferArray<int> rewardWeight
		{
			get
			{
				if (this.rewardWeightValue == null)
				{
					this.rewardWeightValue = new FlatBufferArray<int>(new Func<int, int>(this.rewardWeightArray), this.rewardWeightLength);
				}
				return this.rewardWeightValue;
			}
		}

		// Token: 0x060036D1 RID: 14033 RVA: 0x000BC5C0 File Offset: 0x000BA9C0
		public int rewardSchemeCntArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DBF RID: 3519
		// (get) Token: 0x060036D2 RID: 14034 RVA: 0x000BC610 File Offset: 0x000BAA10
		public int rewardSchemeCntLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060036D3 RID: 14035 RVA: 0x000BC643 File Offset: 0x000BAA43
		public ArraySegment<byte>? GetRewardSchemeCntBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000DC0 RID: 3520
		// (get) Token: 0x060036D4 RID: 14036 RVA: 0x000BC652 File Offset: 0x000BAA52
		public FlatBufferArray<int> rewardSchemeCnt
		{
			get
			{
				if (this.rewardSchemeCntValue == null)
				{
					this.rewardSchemeCntValue = new FlatBufferArray<int>(new Func<int, int>(this.rewardSchemeCntArray), this.rewardSchemeCntLength);
				}
				return this.rewardSchemeCntValue;
			}
		}

		// Token: 0x060036D5 RID: 14037 RVA: 0x000BC684 File Offset: 0x000BAA84
		public int schemeWeightArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DC1 RID: 3521
		// (get) Token: 0x060036D6 RID: 14038 RVA: 0x000BC6D4 File Offset: 0x000BAAD4
		public int schemeWeightLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060036D7 RID: 14039 RVA: 0x000BC707 File Offset: 0x000BAB07
		public ArraySegment<byte>? GetSchemeWeightBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000DC2 RID: 3522
		// (get) Token: 0x060036D8 RID: 14040 RVA: 0x000BC716 File Offset: 0x000BAB16
		public FlatBufferArray<int> schemeWeight
		{
			get
			{
				if (this.schemeWeightValue == null)
				{
					this.schemeWeightValue = new FlatBufferArray<int>(new Func<int, int>(this.schemeWeightArray), this.schemeWeightLength);
				}
				return this.schemeWeightValue;
			}
		}

		// Token: 0x060036D9 RID: 14041 RVA: 0x000BC748 File Offset: 0x000BAB48
		public int fixPriceArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DC3 RID: 3523
		// (get) Token: 0x060036DA RID: 14042 RVA: 0x000BC798 File Offset: 0x000BAB98
		public int fixPriceLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060036DB RID: 14043 RVA: 0x000BC7CB File Offset: 0x000BABCB
		public ArraySegment<byte>? GetFixPriceBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000DC4 RID: 3524
		// (get) Token: 0x060036DC RID: 14044 RVA: 0x000BC7DA File Offset: 0x000BABDA
		public FlatBufferArray<int> fixPrice
		{
			get
			{
				if (this.fixPriceValue == null)
				{
					this.fixPriceValue = new FlatBufferArray<int>(new Func<int, int>(this.fixPriceArray), this.fixPriceLength);
				}
				return this.fixPriceValue;
			}
		}

		// Token: 0x060036DD RID: 14045 RVA: 0x000BC80C File Offset: 0x000BAC0C
		public int auctionPriceArray(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DC5 RID: 3525
		// (get) Token: 0x060036DE RID: 14046 RVA: 0x000BC85C File Offset: 0x000BAC5C
		public int auctionPriceLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060036DF RID: 14047 RVA: 0x000BC88F File Offset: 0x000BAC8F
		public ArraySegment<byte>? GetAuctionPriceBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000DC6 RID: 3526
		// (get) Token: 0x060036E0 RID: 14048 RVA: 0x000BC89E File Offset: 0x000BAC9E
		public FlatBufferArray<int> auctionPrice
		{
			get
			{
				if (this.auctionPriceValue == null)
				{
					this.auctionPriceValue = new FlatBufferArray<int>(new Func<int, int>(this.auctionPriceArray), this.auctionPriceLength);
				}
				return this.auctionPriceValue;
			}
		}

		// Token: 0x060036E1 RID: 14049 RVA: 0x000BC8D0 File Offset: 0x000BACD0
		public int addPirceArray(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (1182288942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DC7 RID: 3527
		// (get) Token: 0x060036E2 RID: 14050 RVA: 0x000BC920 File Offset: 0x000BAD20
		public int addPirceLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060036E3 RID: 14051 RVA: 0x000BC953 File Offset: 0x000BAD53
		public ArraySegment<byte>? GetAddPirceBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000DC8 RID: 3528
		// (get) Token: 0x060036E4 RID: 14052 RVA: 0x000BC962 File Offset: 0x000BAD62
		public FlatBufferArray<int> addPirce
		{
			get
			{
				if (this.addPirceValue == null)
				{
					this.addPirceValue = new FlatBufferArray<int>(new Func<int, int>(this.addPirceArray), this.addPirceLength);
				}
				return this.addPirceValue;
			}
		}

		// Token: 0x060036E5 RID: 14053 RVA: 0x000BC994 File Offset: 0x000BAD94
		public string rewardShowArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000DC9 RID: 3529
		// (get) Token: 0x060036E6 RID: 14054 RVA: 0x000BC9DC File Offset: 0x000BADDC
		public int rewardShowLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000DCA RID: 3530
		// (get) Token: 0x060036E7 RID: 14055 RVA: 0x000BCA0F File Offset: 0x000BAE0F
		public FlatBufferArray<string> rewardShow
		{
			get
			{
				if (this.rewardShowValue == null)
				{
					this.rewardShowValue = new FlatBufferArray<string>(new Func<int, string>(this.rewardShowArray), this.rewardShowLength);
				}
				return this.rewardShowValue;
			}
		}

		// Token: 0x060036E8 RID: 14056 RVA: 0x000BCA40 File Offset: 0x000BAE40
		public static Offset<GuildDungeonRewardTable> CreateGuildDungeonRewardTable(FlatBufferBuilder builder, int ID = 0, int rewardType = 0, int dungeonType = 0, int damageWeight = 0, int ownerBonusLimit = 0, VectorOffset rewardGroupOffset = default(VectorOffset), VectorOffset rewardCountOffset = default(VectorOffset), VectorOffset rewardWeightOffset = default(VectorOffset), VectorOffset rewardSchemeCntOffset = default(VectorOffset), VectorOffset schemeWeightOffset = default(VectorOffset), VectorOffset fixPriceOffset = default(VectorOffset), VectorOffset auctionPriceOffset = default(VectorOffset), VectorOffset addPirceOffset = default(VectorOffset), VectorOffset rewardShowOffset = default(VectorOffset))
		{
			builder.StartObject(14);
			GuildDungeonRewardTable.AddRewardShow(builder, rewardShowOffset);
			GuildDungeonRewardTable.AddAddPirce(builder, addPirceOffset);
			GuildDungeonRewardTable.AddAuctionPrice(builder, auctionPriceOffset);
			GuildDungeonRewardTable.AddFixPrice(builder, fixPriceOffset);
			GuildDungeonRewardTable.AddSchemeWeight(builder, schemeWeightOffset);
			GuildDungeonRewardTable.AddRewardSchemeCnt(builder, rewardSchemeCntOffset);
			GuildDungeonRewardTable.AddRewardWeight(builder, rewardWeightOffset);
			GuildDungeonRewardTable.AddRewardCount(builder, rewardCountOffset);
			GuildDungeonRewardTable.AddRewardGroup(builder, rewardGroupOffset);
			GuildDungeonRewardTable.AddOwnerBonusLimit(builder, ownerBonusLimit);
			GuildDungeonRewardTable.AddDamageWeight(builder, damageWeight);
			GuildDungeonRewardTable.AddDungeonType(builder, dungeonType);
			GuildDungeonRewardTable.AddRewardType(builder, rewardType);
			GuildDungeonRewardTable.AddID(builder, ID);
			return GuildDungeonRewardTable.EndGuildDungeonRewardTable(builder);
		}

		// Token: 0x060036E9 RID: 14057 RVA: 0x000BCAC8 File Offset: 0x000BAEC8
		public static void StartGuildDungeonRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(14);
		}

		// Token: 0x060036EA RID: 14058 RVA: 0x000BCAD2 File Offset: 0x000BAED2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060036EB RID: 14059 RVA: 0x000BCADD File Offset: 0x000BAEDD
		public static void AddRewardType(FlatBufferBuilder builder, int rewardType)
		{
			builder.AddInt(1, rewardType, 0);
		}

		// Token: 0x060036EC RID: 14060 RVA: 0x000BCAE8 File Offset: 0x000BAEE8
		public static void AddDungeonType(FlatBufferBuilder builder, int dungeonType)
		{
			builder.AddInt(2, dungeonType, 0);
		}

		// Token: 0x060036ED RID: 14061 RVA: 0x000BCAF3 File Offset: 0x000BAEF3
		public static void AddDamageWeight(FlatBufferBuilder builder, int damageWeight)
		{
			builder.AddInt(3, damageWeight, 0);
		}

		// Token: 0x060036EE RID: 14062 RVA: 0x000BCAFE File Offset: 0x000BAEFE
		public static void AddOwnerBonusLimit(FlatBufferBuilder builder, int ownerBonusLimit)
		{
			builder.AddInt(4, ownerBonusLimit, 0);
		}

		// Token: 0x060036EF RID: 14063 RVA: 0x000BCB09 File Offset: 0x000BAF09
		public static void AddRewardGroup(FlatBufferBuilder builder, VectorOffset rewardGroupOffset)
		{
			builder.AddOffset(5, rewardGroupOffset.Value, 0);
		}

		// Token: 0x060036F0 RID: 14064 RVA: 0x000BCB1C File Offset: 0x000BAF1C
		public static VectorOffset CreateRewardGroupVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060036F1 RID: 14065 RVA: 0x000BCB59 File Offset: 0x000BAF59
		public static void StartRewardGroupVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060036F2 RID: 14066 RVA: 0x000BCB64 File Offset: 0x000BAF64
		public static void AddRewardCount(FlatBufferBuilder builder, VectorOffset rewardCountOffset)
		{
			builder.AddOffset(6, rewardCountOffset.Value, 0);
		}

		// Token: 0x060036F3 RID: 14067 RVA: 0x000BCB78 File Offset: 0x000BAF78
		public static VectorOffset CreateRewardCountVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060036F4 RID: 14068 RVA: 0x000BCBB5 File Offset: 0x000BAFB5
		public static void StartRewardCountVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060036F5 RID: 14069 RVA: 0x000BCBC0 File Offset: 0x000BAFC0
		public static void AddRewardWeight(FlatBufferBuilder builder, VectorOffset rewardWeightOffset)
		{
			builder.AddOffset(7, rewardWeightOffset.Value, 0);
		}

		// Token: 0x060036F6 RID: 14070 RVA: 0x000BCBD4 File Offset: 0x000BAFD4
		public static VectorOffset CreateRewardWeightVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060036F7 RID: 14071 RVA: 0x000BCC11 File Offset: 0x000BB011
		public static void StartRewardWeightVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060036F8 RID: 14072 RVA: 0x000BCC1C File Offset: 0x000BB01C
		public static void AddRewardSchemeCnt(FlatBufferBuilder builder, VectorOffset rewardSchemeCntOffset)
		{
			builder.AddOffset(8, rewardSchemeCntOffset.Value, 0);
		}

		// Token: 0x060036F9 RID: 14073 RVA: 0x000BCC30 File Offset: 0x000BB030
		public static VectorOffset CreateRewardSchemeCntVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060036FA RID: 14074 RVA: 0x000BCC6D File Offset: 0x000BB06D
		public static void StartRewardSchemeCntVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060036FB RID: 14075 RVA: 0x000BCC78 File Offset: 0x000BB078
		public static void AddSchemeWeight(FlatBufferBuilder builder, VectorOffset schemeWeightOffset)
		{
			builder.AddOffset(9, schemeWeightOffset.Value, 0);
		}

		// Token: 0x060036FC RID: 14076 RVA: 0x000BCC8C File Offset: 0x000BB08C
		public static VectorOffset CreateSchemeWeightVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060036FD RID: 14077 RVA: 0x000BCCC9 File Offset: 0x000BB0C9
		public static void StartSchemeWeightVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060036FE RID: 14078 RVA: 0x000BCCD4 File Offset: 0x000BB0D4
		public static void AddFixPrice(FlatBufferBuilder builder, VectorOffset fixPriceOffset)
		{
			builder.AddOffset(10, fixPriceOffset.Value, 0);
		}

		// Token: 0x060036FF RID: 14079 RVA: 0x000BCCE8 File Offset: 0x000BB0E8
		public static VectorOffset CreateFixPriceVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003700 RID: 14080 RVA: 0x000BCD25 File Offset: 0x000BB125
		public static void StartFixPriceVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003701 RID: 14081 RVA: 0x000BCD30 File Offset: 0x000BB130
		public static void AddAuctionPrice(FlatBufferBuilder builder, VectorOffset auctionPriceOffset)
		{
			builder.AddOffset(11, auctionPriceOffset.Value, 0);
		}

		// Token: 0x06003702 RID: 14082 RVA: 0x000BCD44 File Offset: 0x000BB144
		public static VectorOffset CreateAuctionPriceVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003703 RID: 14083 RVA: 0x000BCD81 File Offset: 0x000BB181
		public static void StartAuctionPriceVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003704 RID: 14084 RVA: 0x000BCD8C File Offset: 0x000BB18C
		public static void AddAddPirce(FlatBufferBuilder builder, VectorOffset addPirceOffset)
		{
			builder.AddOffset(12, addPirceOffset.Value, 0);
		}

		// Token: 0x06003705 RID: 14085 RVA: 0x000BCDA0 File Offset: 0x000BB1A0
		public static VectorOffset CreateAddPirceVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003706 RID: 14086 RVA: 0x000BCDDD File Offset: 0x000BB1DD
		public static void StartAddPirceVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003707 RID: 14087 RVA: 0x000BCDE8 File Offset: 0x000BB1E8
		public static void AddRewardShow(FlatBufferBuilder builder, VectorOffset rewardShowOffset)
		{
			builder.AddOffset(13, rewardShowOffset.Value, 0);
		}

		// Token: 0x06003708 RID: 14088 RVA: 0x000BCDFC File Offset: 0x000BB1FC
		public static VectorOffset CreateRewardShowVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003709 RID: 14089 RVA: 0x000BCE42 File Offset: 0x000BB242
		public static void StartRewardShowVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600370A RID: 14090 RVA: 0x000BCE50 File Offset: 0x000BB250
		public static Offset<GuildDungeonRewardTable> EndGuildDungeonRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildDungeonRewardTable>(value);
		}

		// Token: 0x0600370B RID: 14091 RVA: 0x000BCE6A File Offset: 0x000BB26A
		public static void FinishGuildDungeonRewardTableBuffer(FlatBufferBuilder builder, Offset<GuildDungeonRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015BF RID: 5567
		private Table __p = new Table();

		// Token: 0x040015C0 RID: 5568
		private FlatBufferArray<int> rewardGroupValue;

		// Token: 0x040015C1 RID: 5569
		private FlatBufferArray<int> rewardCountValue;

		// Token: 0x040015C2 RID: 5570
		private FlatBufferArray<int> rewardWeightValue;

		// Token: 0x040015C3 RID: 5571
		private FlatBufferArray<int> rewardSchemeCntValue;

		// Token: 0x040015C4 RID: 5572
		private FlatBufferArray<int> schemeWeightValue;

		// Token: 0x040015C5 RID: 5573
		private FlatBufferArray<int> fixPriceValue;

		// Token: 0x040015C6 RID: 5574
		private FlatBufferArray<int> auctionPriceValue;

		// Token: 0x040015C7 RID: 5575
		private FlatBufferArray<int> addPirceValue;

		// Token: 0x040015C8 RID: 5576
		private FlatBufferArray<string> rewardShowValue;

		// Token: 0x02000472 RID: 1138
		public enum eCrypt
		{
			// Token: 0x040015CA RID: 5578
			code = 1182288942
		}
	}
}
