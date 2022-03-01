using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005A5 RID: 1445
	public class SeasonLevelTable : IFlatbufferObject
	{
		// Token: 0x1700144B RID: 5195
		// (get) Token: 0x06004ABC RID: 19132 RVA: 0x000EAF98 File Offset: 0x000E9398
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004ABD RID: 19133 RVA: 0x000EAFA5 File Offset: 0x000E93A5
		public static SeasonLevelTable GetRootAsSeasonLevelTable(ByteBuffer _bb)
		{
			return SeasonLevelTable.GetRootAsSeasonLevelTable(_bb, new SeasonLevelTable());
		}

		// Token: 0x06004ABE RID: 19134 RVA: 0x000EAFB2 File Offset: 0x000E93B2
		public static SeasonLevelTable GetRootAsSeasonLevelTable(ByteBuffer _bb, SeasonLevelTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004ABF RID: 19135 RVA: 0x000EAFCE File Offset: 0x000E93CE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004AC0 RID: 19136 RVA: 0x000EAFE8 File Offset: 0x000E93E8
		public SeasonLevelTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700144C RID: 5196
		// (get) Token: 0x06004AC1 RID: 19137 RVA: 0x000EAFF4 File Offset: 0x000E93F4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700144D RID: 5197
		// (get) Token: 0x06004AC2 RID: 19138 RVA: 0x000EB040 File Offset: 0x000E9440
		public int PreId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700144E RID: 5198
		// (get) Token: 0x06004AC3 RID: 19139 RVA: 0x000EB08C File Offset: 0x000E948C
		public int AfterId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700144F RID: 5199
		// (get) Token: 0x06004AC4 RID: 19140 RVA: 0x000EB0D8 File Offset: 0x000E94D8
		public SeasonLevelTable.eMainLevel MainLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (SeasonLevelTable.eMainLevel)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001450 RID: 5200
		// (get) Token: 0x06004AC5 RID: 19141 RVA: 0x000EB11C File Offset: 0x000E951C
		public int SmallLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001451 RID: 5201
		// (get) Token: 0x06004AC6 RID: 19142 RVA: 0x000EB168 File Offset: 0x000E9568
		public int Star
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001452 RID: 5202
		// (get) Token: 0x06004AC7 RID: 19143 RVA: 0x000EB1B4 File Offset: 0x000E95B4
		public int MaxExp
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001453 RID: 5203
		// (get) Token: 0x06004AC8 RID: 19144 RVA: 0x000EB200 File Offset: 0x000E9600
		public int MaxStar
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001454 RID: 5204
		// (get) Token: 0x06004AC9 RID: 19145 RVA: 0x000EB24C File Offset: 0x000E964C
		public int HideScore
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001455 RID: 5205
		// (get) Token: 0x06004ACA RID: 19146 RVA: 0x000EB298 File Offset: 0x000E9698
		public int CanMatchRobot
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001456 RID: 5206
		// (get) Token: 0x06004ACB RID: 19147 RVA: 0x000EB2E4 File Offset: 0x000E96E4
		public int IsFailLevelReduce
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001457 RID: 5207
		// (get) Token: 0x06004ACC RID: 19148 RVA: 0x000EB330 File Offset: 0x000E9730
		public int IsPromotion
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001458 RID: 5208
		// (get) Token: 0x06004ACD RID: 19149 RVA: 0x000EB37C File Offset: 0x000E977C
		public string PromotionRule
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004ACE RID: 19150 RVA: 0x000EB3BF File Offset: 0x000E97BF
		public ArraySegment<byte>? GetPromotionRuleBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17001459 RID: 5209
		// (get) Token: 0x06004ACF RID: 19151 RVA: 0x000EB3D0 File Offset: 0x000E97D0
		public string CommonLevelReduce
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004AD0 RID: 19152 RVA: 0x000EB413 File Offset: 0x000E9813
		public ArraySegment<byte>? GetCommonLevelReduceBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x1700145A RID: 5210
		// (get) Token: 0x06004AD1 RID: 19153 RVA: 0x000EB424 File Offset: 0x000E9824
		public int SeasonStartLevelReduce
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004AD2 RID: 19154 RVA: 0x000EB470 File Offset: 0x000E9870
		public string DailyRewardsArray(int j)
		{
			int num = this.__p.__offset(34);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700145B RID: 5211
		// (get) Token: 0x06004AD3 RID: 19155 RVA: 0x000EB4B8 File Offset: 0x000E98B8
		public int DailyRewardsLength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700145C RID: 5212
		// (get) Token: 0x06004AD4 RID: 19156 RVA: 0x000EB4EB File Offset: 0x000E98EB
		public FlatBufferArray<string> DailyRewards
		{
			get
			{
				if (this.DailyRewardsValue == null)
				{
					this.DailyRewardsValue = new FlatBufferArray<string>(new Func<int, string>(this.DailyRewardsArray), this.DailyRewardsLength);
				}
				return this.DailyRewardsValue;
			}
		}

		// Token: 0x06004AD5 RID: 19157 RVA: 0x000EB51C File Offset: 0x000E991C
		public string SeasonRewardsArray(int j)
		{
			int num = this.__p.__offset(36);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700145D RID: 5213
		// (get) Token: 0x06004AD6 RID: 19158 RVA: 0x000EB564 File Offset: 0x000E9964
		public int SeasonRewardsLength
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700145E RID: 5214
		// (get) Token: 0x06004AD7 RID: 19159 RVA: 0x000EB597 File Offset: 0x000E9997
		public FlatBufferArray<string> SeasonRewards
		{
			get
			{
				if (this.SeasonRewardsValue == null)
				{
					this.SeasonRewardsValue = new FlatBufferArray<string>(new Func<int, string>(this.SeasonRewardsArray), this.SeasonRewardsLength);
				}
				return this.SeasonRewardsValue;
			}
		}

		// Token: 0x1700145F RID: 5215
		// (get) Token: 0x06004AD8 RID: 19160 RVA: 0x000EB5C8 File Offset: 0x000E99C8
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004AD9 RID: 19161 RVA: 0x000EB60B File Offset: 0x000E9A0B
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17001460 RID: 5216
		// (get) Token: 0x06004ADA RID: 19162 RVA: 0x000EB61C File Offset: 0x000E9A1C
		public string SmallIcon
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004ADB RID: 19163 RVA: 0x000EB65F File Offset: 0x000E9A5F
		public ArraySegment<byte>? GetSmallIconBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x17001461 RID: 5217
		// (get) Token: 0x06004ADC RID: 19164 RVA: 0x000EB670 File Offset: 0x000E9A70
		public string SubLevelIcon
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004ADD RID: 19165 RVA: 0x000EB6B3 File Offset: 0x000E9AB3
		public ArraySegment<byte>? GetSubLevelIconBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17001462 RID: 5218
		// (get) Token: 0x06004ADE RID: 19166 RVA: 0x000EB6C4 File Offset: 0x000E9AC4
		public int AttrID
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (1594614297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004ADF RID: 19167 RVA: 0x000EB710 File Offset: 0x000E9B10
		public static Offset<SeasonLevelTable> CreateSeasonLevelTable(FlatBufferBuilder builder, int ID = 0, int PreId = 0, int AfterId = 0, SeasonLevelTable.eMainLevel MainLevel = SeasonLevelTable.eMainLevel.MainLevel_None, int SmallLevel = 0, int Star = 0, int MaxExp = 0, int MaxStar = 0, int HideScore = 0, int CanMatchRobot = 0, int IsFailLevelReduce = 0, int IsPromotion = 0, StringOffset PromotionRuleOffset = default(StringOffset), StringOffset CommonLevelReduceOffset = default(StringOffset), int SeasonStartLevelReduce = 0, VectorOffset DailyRewardsOffset = default(VectorOffset), VectorOffset SeasonRewardsOffset = default(VectorOffset), StringOffset IconOffset = default(StringOffset), StringOffset SmallIconOffset = default(StringOffset), StringOffset SubLevelIconOffset = default(StringOffset), int AttrID = 0)
		{
			builder.StartObject(21);
			SeasonLevelTable.AddAttrID(builder, AttrID);
			SeasonLevelTable.AddSubLevelIcon(builder, SubLevelIconOffset);
			SeasonLevelTable.AddSmallIcon(builder, SmallIconOffset);
			SeasonLevelTable.AddIcon(builder, IconOffset);
			SeasonLevelTable.AddSeasonRewards(builder, SeasonRewardsOffset);
			SeasonLevelTable.AddDailyRewards(builder, DailyRewardsOffset);
			SeasonLevelTable.AddSeasonStartLevelReduce(builder, SeasonStartLevelReduce);
			SeasonLevelTable.AddCommonLevelReduce(builder, CommonLevelReduceOffset);
			SeasonLevelTable.AddPromotionRule(builder, PromotionRuleOffset);
			SeasonLevelTable.AddIsPromotion(builder, IsPromotion);
			SeasonLevelTable.AddIsFailLevelReduce(builder, IsFailLevelReduce);
			SeasonLevelTable.AddCanMatchRobot(builder, CanMatchRobot);
			SeasonLevelTable.AddHideScore(builder, HideScore);
			SeasonLevelTable.AddMaxStar(builder, MaxStar);
			SeasonLevelTable.AddMaxExp(builder, MaxExp);
			SeasonLevelTable.AddStar(builder, Star);
			SeasonLevelTable.AddSmallLevel(builder, SmallLevel);
			SeasonLevelTable.AddMainLevel(builder, MainLevel);
			SeasonLevelTable.AddAfterId(builder, AfterId);
			SeasonLevelTable.AddPreId(builder, PreId);
			SeasonLevelTable.AddID(builder, ID);
			return SeasonLevelTable.EndSeasonLevelTable(builder);
		}

		// Token: 0x06004AE0 RID: 19168 RVA: 0x000EB7D0 File Offset: 0x000E9BD0
		public static void StartSeasonLevelTable(FlatBufferBuilder builder)
		{
			builder.StartObject(21);
		}

		// Token: 0x06004AE1 RID: 19169 RVA: 0x000EB7DA File Offset: 0x000E9BDA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004AE2 RID: 19170 RVA: 0x000EB7E5 File Offset: 0x000E9BE5
		public static void AddPreId(FlatBufferBuilder builder, int PreId)
		{
			builder.AddInt(1, PreId, 0);
		}

		// Token: 0x06004AE3 RID: 19171 RVA: 0x000EB7F0 File Offset: 0x000E9BF0
		public static void AddAfterId(FlatBufferBuilder builder, int AfterId)
		{
			builder.AddInt(2, AfterId, 0);
		}

		// Token: 0x06004AE4 RID: 19172 RVA: 0x000EB7FB File Offset: 0x000E9BFB
		public static void AddMainLevel(FlatBufferBuilder builder, SeasonLevelTable.eMainLevel MainLevel)
		{
			builder.AddInt(3, (int)MainLevel, 0);
		}

		// Token: 0x06004AE5 RID: 19173 RVA: 0x000EB806 File Offset: 0x000E9C06
		public static void AddSmallLevel(FlatBufferBuilder builder, int SmallLevel)
		{
			builder.AddInt(4, SmallLevel, 0);
		}

		// Token: 0x06004AE6 RID: 19174 RVA: 0x000EB811 File Offset: 0x000E9C11
		public static void AddStar(FlatBufferBuilder builder, int Star)
		{
			builder.AddInt(5, Star, 0);
		}

		// Token: 0x06004AE7 RID: 19175 RVA: 0x000EB81C File Offset: 0x000E9C1C
		public static void AddMaxExp(FlatBufferBuilder builder, int MaxExp)
		{
			builder.AddInt(6, MaxExp, 0);
		}

		// Token: 0x06004AE8 RID: 19176 RVA: 0x000EB827 File Offset: 0x000E9C27
		public static void AddMaxStar(FlatBufferBuilder builder, int MaxStar)
		{
			builder.AddInt(7, MaxStar, 0);
		}

		// Token: 0x06004AE9 RID: 19177 RVA: 0x000EB832 File Offset: 0x000E9C32
		public static void AddHideScore(FlatBufferBuilder builder, int HideScore)
		{
			builder.AddInt(8, HideScore, 0);
		}

		// Token: 0x06004AEA RID: 19178 RVA: 0x000EB83D File Offset: 0x000E9C3D
		public static void AddCanMatchRobot(FlatBufferBuilder builder, int CanMatchRobot)
		{
			builder.AddInt(9, CanMatchRobot, 0);
		}

		// Token: 0x06004AEB RID: 19179 RVA: 0x000EB849 File Offset: 0x000E9C49
		public static void AddIsFailLevelReduce(FlatBufferBuilder builder, int IsFailLevelReduce)
		{
			builder.AddInt(10, IsFailLevelReduce, 0);
		}

		// Token: 0x06004AEC RID: 19180 RVA: 0x000EB855 File Offset: 0x000E9C55
		public static void AddIsPromotion(FlatBufferBuilder builder, int IsPromotion)
		{
			builder.AddInt(11, IsPromotion, 0);
		}

		// Token: 0x06004AED RID: 19181 RVA: 0x000EB861 File Offset: 0x000E9C61
		public static void AddPromotionRule(FlatBufferBuilder builder, StringOffset PromotionRuleOffset)
		{
			builder.AddOffset(12, PromotionRuleOffset.Value, 0);
		}

		// Token: 0x06004AEE RID: 19182 RVA: 0x000EB873 File Offset: 0x000E9C73
		public static void AddCommonLevelReduce(FlatBufferBuilder builder, StringOffset CommonLevelReduceOffset)
		{
			builder.AddOffset(13, CommonLevelReduceOffset.Value, 0);
		}

		// Token: 0x06004AEF RID: 19183 RVA: 0x000EB885 File Offset: 0x000E9C85
		public static void AddSeasonStartLevelReduce(FlatBufferBuilder builder, int SeasonStartLevelReduce)
		{
			builder.AddInt(14, SeasonStartLevelReduce, 0);
		}

		// Token: 0x06004AF0 RID: 19184 RVA: 0x000EB891 File Offset: 0x000E9C91
		public static void AddDailyRewards(FlatBufferBuilder builder, VectorOffset DailyRewardsOffset)
		{
			builder.AddOffset(15, DailyRewardsOffset.Value, 0);
		}

		// Token: 0x06004AF1 RID: 19185 RVA: 0x000EB8A4 File Offset: 0x000E9CA4
		public static VectorOffset CreateDailyRewardsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004AF2 RID: 19186 RVA: 0x000EB8EA File Offset: 0x000E9CEA
		public static void StartDailyRewardsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004AF3 RID: 19187 RVA: 0x000EB8F5 File Offset: 0x000E9CF5
		public static void AddSeasonRewards(FlatBufferBuilder builder, VectorOffset SeasonRewardsOffset)
		{
			builder.AddOffset(16, SeasonRewardsOffset.Value, 0);
		}

		// Token: 0x06004AF4 RID: 19188 RVA: 0x000EB908 File Offset: 0x000E9D08
		public static VectorOffset CreateSeasonRewardsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004AF5 RID: 19189 RVA: 0x000EB94E File Offset: 0x000E9D4E
		public static void StartSeasonRewardsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004AF6 RID: 19190 RVA: 0x000EB959 File Offset: 0x000E9D59
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(17, IconOffset.Value, 0);
		}

		// Token: 0x06004AF7 RID: 19191 RVA: 0x000EB96B File Offset: 0x000E9D6B
		public static void AddSmallIcon(FlatBufferBuilder builder, StringOffset SmallIconOffset)
		{
			builder.AddOffset(18, SmallIconOffset.Value, 0);
		}

		// Token: 0x06004AF8 RID: 19192 RVA: 0x000EB97D File Offset: 0x000E9D7D
		public static void AddSubLevelIcon(FlatBufferBuilder builder, StringOffset SubLevelIconOffset)
		{
			builder.AddOffset(19, SubLevelIconOffset.Value, 0);
		}

		// Token: 0x06004AF9 RID: 19193 RVA: 0x000EB98F File Offset: 0x000E9D8F
		public static void AddAttrID(FlatBufferBuilder builder, int AttrID)
		{
			builder.AddInt(20, AttrID, 0);
		}

		// Token: 0x06004AFA RID: 19194 RVA: 0x000EB99C File Offset: 0x000E9D9C
		public static Offset<SeasonLevelTable> EndSeasonLevelTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SeasonLevelTable>(value);
		}

		// Token: 0x06004AFB RID: 19195 RVA: 0x000EB9B6 File Offset: 0x000E9DB6
		public static void FinishSeasonLevelTableBuffer(FlatBufferBuilder builder, Offset<SeasonLevelTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AFF RID: 6911
		private Table __p = new Table();

		// Token: 0x04001B00 RID: 6912
		private FlatBufferArray<string> DailyRewardsValue;

		// Token: 0x04001B01 RID: 6913
		private FlatBufferArray<string> SeasonRewardsValue;

		// Token: 0x020005A6 RID: 1446
		public enum eMainLevel
		{
			// Token: 0x04001B03 RID: 6915
			MainLevel_None,
			// Token: 0x04001B04 RID: 6916
			Bronze,
			// Token: 0x04001B05 RID: 6917
			Silver,
			// Token: 0x04001B06 RID: 6918
			Gold,
			// Token: 0x04001B07 RID: 6919
			Platinum,
			// Token: 0x04001B08 RID: 6920
			Diamond,
			// Token: 0x04001B09 RID: 6921
			King
		}

		// Token: 0x020005A7 RID: 1447
		public enum eCrypt
		{
			// Token: 0x04001B0B RID: 6923
			code = 1594614297
		}
	}
}
