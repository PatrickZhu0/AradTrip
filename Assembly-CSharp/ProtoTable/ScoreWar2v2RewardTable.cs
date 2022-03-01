using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000595 RID: 1429
	public class ScoreWar2v2RewardTable : IFlatbufferObject
	{
		// Token: 0x1700140F RID: 5135
		// (get) Token: 0x060049F8 RID: 18936 RVA: 0x000E941C File Offset: 0x000E781C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060049F9 RID: 18937 RVA: 0x000E9429 File Offset: 0x000E7829
		public static ScoreWar2v2RewardTable GetRootAsScoreWar2v2RewardTable(ByteBuffer _bb)
		{
			return ScoreWar2v2RewardTable.GetRootAsScoreWar2v2RewardTable(_bb, new ScoreWar2v2RewardTable());
		}

		// Token: 0x060049FA RID: 18938 RVA: 0x000E9436 File Offset: 0x000E7836
		public static ScoreWar2v2RewardTable GetRootAsScoreWar2v2RewardTable(ByteBuffer _bb, ScoreWar2v2RewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060049FB RID: 18939 RVA: 0x000E9452 File Offset: 0x000E7852
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060049FC RID: 18940 RVA: 0x000E946C File Offset: 0x000E786C
		public ScoreWar2v2RewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001410 RID: 5136
		// (get) Token: 0x060049FD RID: 18941 RVA: 0x000E9478 File Offset: 0x000E7878
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1747873531 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001411 RID: 5137
		// (get) Token: 0x060049FE RID: 18942 RVA: 0x000E94C4 File Offset: 0x000E78C4
		public int RewardId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1747873531 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001412 RID: 5138
		// (get) Token: 0x060049FF RID: 18943 RVA: 0x000E9510 File Offset: 0x000E7910
		public int BattleCount
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1747873531 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001413 RID: 5139
		// (get) Token: 0x06004A00 RID: 18944 RVA: 0x000E955C File Offset: 0x000E795C
		public int WinCount
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1747873531 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001414 RID: 5140
		// (get) Token: 0x06004A01 RID: 18945 RVA: 0x000E95A8 File Offset: 0x000E79A8
		public int RankingBegin
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1747873531 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001415 RID: 5141
		// (get) Token: 0x06004A02 RID: 18946 RVA: 0x000E95F4 File Offset: 0x000E79F4
		public int RankingEnd
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1747873531 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004A03 RID: 18947 RVA: 0x000E9640 File Offset: 0x000E7A40
		public string ItemRewardArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001416 RID: 5142
		// (get) Token: 0x06004A04 RID: 18948 RVA: 0x000E9688 File Offset: 0x000E7A88
		public int ItemRewardLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001417 RID: 5143
		// (get) Token: 0x06004A05 RID: 18949 RVA: 0x000E96BB File Offset: 0x000E7ABB
		public FlatBufferArray<string> ItemReward
		{
			get
			{
				if (this.ItemRewardValue == null)
				{
					this.ItemRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.ItemRewardArray), this.ItemRewardLength);
				}
				return this.ItemRewardValue;
			}
		}

		// Token: 0x06004A06 RID: 18950 RVA: 0x000E96EC File Offset: 0x000E7AEC
		public string RewardPreviewArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001418 RID: 5144
		// (get) Token: 0x06004A07 RID: 18951 RVA: 0x000E9734 File Offset: 0x000E7B34
		public int RewardPreviewLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001419 RID: 5145
		// (get) Token: 0x06004A08 RID: 18952 RVA: 0x000E9767 File Offset: 0x000E7B67
		public FlatBufferArray<string> RewardPreview
		{
			get
			{
				if (this.RewardPreviewValue == null)
				{
					this.RewardPreviewValue = new FlatBufferArray<string>(new Func<int, string>(this.RewardPreviewArray), this.RewardPreviewLength);
				}
				return this.RewardPreviewValue;
			}
		}

		// Token: 0x06004A09 RID: 18953 RVA: 0x000E9798 File Offset: 0x000E7B98
		public static Offset<ScoreWar2v2RewardTable> CreateScoreWar2v2RewardTable(FlatBufferBuilder builder, int ID = 0, int RewardId = 0, int BattleCount = 0, int WinCount = 0, int RankingBegin = 0, int RankingEnd = 0, VectorOffset ItemRewardOffset = default(VectorOffset), VectorOffset RewardPreviewOffset = default(VectorOffset))
		{
			builder.StartObject(8);
			ScoreWar2v2RewardTable.AddRewardPreview(builder, RewardPreviewOffset);
			ScoreWar2v2RewardTable.AddItemReward(builder, ItemRewardOffset);
			ScoreWar2v2RewardTable.AddRankingEnd(builder, RankingEnd);
			ScoreWar2v2RewardTable.AddRankingBegin(builder, RankingBegin);
			ScoreWar2v2RewardTable.AddWinCount(builder, WinCount);
			ScoreWar2v2RewardTable.AddBattleCount(builder, BattleCount);
			ScoreWar2v2RewardTable.AddRewardId(builder, RewardId);
			ScoreWar2v2RewardTable.AddID(builder, ID);
			return ScoreWar2v2RewardTable.EndScoreWar2v2RewardTable(builder);
		}

		// Token: 0x06004A0A RID: 18954 RVA: 0x000E97EF File Offset: 0x000E7BEF
		public static void StartScoreWar2v2RewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06004A0B RID: 18955 RVA: 0x000E97F8 File Offset: 0x000E7BF8
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004A0C RID: 18956 RVA: 0x000E9803 File Offset: 0x000E7C03
		public static void AddRewardId(FlatBufferBuilder builder, int RewardId)
		{
			builder.AddInt(1, RewardId, 0);
		}

		// Token: 0x06004A0D RID: 18957 RVA: 0x000E980E File Offset: 0x000E7C0E
		public static void AddBattleCount(FlatBufferBuilder builder, int BattleCount)
		{
			builder.AddInt(2, BattleCount, 0);
		}

		// Token: 0x06004A0E RID: 18958 RVA: 0x000E9819 File Offset: 0x000E7C19
		public static void AddWinCount(FlatBufferBuilder builder, int WinCount)
		{
			builder.AddInt(3, WinCount, 0);
		}

		// Token: 0x06004A0F RID: 18959 RVA: 0x000E9824 File Offset: 0x000E7C24
		public static void AddRankingBegin(FlatBufferBuilder builder, int RankingBegin)
		{
			builder.AddInt(4, RankingBegin, 0);
		}

		// Token: 0x06004A10 RID: 18960 RVA: 0x000E982F File Offset: 0x000E7C2F
		public static void AddRankingEnd(FlatBufferBuilder builder, int RankingEnd)
		{
			builder.AddInt(5, RankingEnd, 0);
		}

		// Token: 0x06004A11 RID: 18961 RVA: 0x000E983A File Offset: 0x000E7C3A
		public static void AddItemReward(FlatBufferBuilder builder, VectorOffset ItemRewardOffset)
		{
			builder.AddOffset(6, ItemRewardOffset.Value, 0);
		}

		// Token: 0x06004A12 RID: 18962 RVA: 0x000E984C File Offset: 0x000E7C4C
		public static VectorOffset CreateItemRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004A13 RID: 18963 RVA: 0x000E9892 File Offset: 0x000E7C92
		public static void StartItemRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004A14 RID: 18964 RVA: 0x000E989D File Offset: 0x000E7C9D
		public static void AddRewardPreview(FlatBufferBuilder builder, VectorOffset RewardPreviewOffset)
		{
			builder.AddOffset(7, RewardPreviewOffset.Value, 0);
		}

		// Token: 0x06004A15 RID: 18965 RVA: 0x000E98B0 File Offset: 0x000E7CB0
		public static VectorOffset CreateRewardPreviewVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004A16 RID: 18966 RVA: 0x000E98F6 File Offset: 0x000E7CF6
		public static void StartRewardPreviewVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004A17 RID: 18967 RVA: 0x000E9904 File Offset: 0x000E7D04
		public static Offset<ScoreWar2v2RewardTable> EndScoreWar2v2RewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ScoreWar2v2RewardTable>(value);
		}

		// Token: 0x06004A18 RID: 18968 RVA: 0x000E991E File Offset: 0x000E7D1E
		public static void FinishScoreWar2v2RewardTableBuffer(FlatBufferBuilder builder, Offset<ScoreWar2v2RewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AD8 RID: 6872
		private Table __p = new Table();

		// Token: 0x04001AD9 RID: 6873
		private FlatBufferArray<string> ItemRewardValue;

		// Token: 0x04001ADA RID: 6874
		private FlatBufferArray<string> RewardPreviewValue;

		// Token: 0x02000596 RID: 1430
		public enum eCrypt
		{
			// Token: 0x04001ADC RID: 6876
			code = 1747873531
		}
	}
}
