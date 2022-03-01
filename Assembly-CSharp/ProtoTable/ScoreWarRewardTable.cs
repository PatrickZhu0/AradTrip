using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200059A RID: 1434
	public class ScoreWarRewardTable : IFlatbufferObject
	{
		// Token: 0x17001421 RID: 5153
		// (get) Token: 0x06004A31 RID: 18993 RVA: 0x000E9C2C File Offset: 0x000E802C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004A32 RID: 18994 RVA: 0x000E9C39 File Offset: 0x000E8039
		public static ScoreWarRewardTable GetRootAsScoreWarRewardTable(ByteBuffer _bb)
		{
			return ScoreWarRewardTable.GetRootAsScoreWarRewardTable(_bb, new ScoreWarRewardTable());
		}

		// Token: 0x06004A33 RID: 18995 RVA: 0x000E9C46 File Offset: 0x000E8046
		public static ScoreWarRewardTable GetRootAsScoreWarRewardTable(ByteBuffer _bb, ScoreWarRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004A34 RID: 18996 RVA: 0x000E9C62 File Offset: 0x000E8062
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004A35 RID: 18997 RVA: 0x000E9C7C File Offset: 0x000E807C
		public ScoreWarRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001422 RID: 5154
		// (get) Token: 0x06004A36 RID: 18998 RVA: 0x000E9C88 File Offset: 0x000E8088
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1807737823 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001423 RID: 5155
		// (get) Token: 0x06004A37 RID: 18999 RVA: 0x000E9CD4 File Offset: 0x000E80D4
		public int RewardId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1807737823 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001424 RID: 5156
		// (get) Token: 0x06004A38 RID: 19000 RVA: 0x000E9D20 File Offset: 0x000E8120
		public int BattleCount
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1807737823 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001425 RID: 5157
		// (get) Token: 0x06004A39 RID: 19001 RVA: 0x000E9D6C File Offset: 0x000E816C
		public int WinCount
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1807737823 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001426 RID: 5158
		// (get) Token: 0x06004A3A RID: 19002 RVA: 0x000E9DB8 File Offset: 0x000E81B8
		public int RankingBegin
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1807737823 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001427 RID: 5159
		// (get) Token: 0x06004A3B RID: 19003 RVA: 0x000E9E04 File Offset: 0x000E8204
		public int RankingEnd
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1807737823 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004A3C RID: 19004 RVA: 0x000E9E50 File Offset: 0x000E8250
		public string ItemRewardArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001428 RID: 5160
		// (get) Token: 0x06004A3D RID: 19005 RVA: 0x000E9E98 File Offset: 0x000E8298
		public int ItemRewardLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001429 RID: 5161
		// (get) Token: 0x06004A3E RID: 19006 RVA: 0x000E9ECB File Offset: 0x000E82CB
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

		// Token: 0x06004A3F RID: 19007 RVA: 0x000E9EFC File Offset: 0x000E82FC
		public string RewardPreviewArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700142A RID: 5162
		// (get) Token: 0x06004A40 RID: 19008 RVA: 0x000E9F44 File Offset: 0x000E8344
		public int RewardPreviewLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700142B RID: 5163
		// (get) Token: 0x06004A41 RID: 19009 RVA: 0x000E9F77 File Offset: 0x000E8377
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

		// Token: 0x06004A42 RID: 19010 RVA: 0x000E9FA8 File Offset: 0x000E83A8
		public static Offset<ScoreWarRewardTable> CreateScoreWarRewardTable(FlatBufferBuilder builder, int ID = 0, int RewardId = 0, int BattleCount = 0, int WinCount = 0, int RankingBegin = 0, int RankingEnd = 0, VectorOffset ItemRewardOffset = default(VectorOffset), VectorOffset RewardPreviewOffset = default(VectorOffset))
		{
			builder.StartObject(8);
			ScoreWarRewardTable.AddRewardPreview(builder, RewardPreviewOffset);
			ScoreWarRewardTable.AddItemReward(builder, ItemRewardOffset);
			ScoreWarRewardTable.AddRankingEnd(builder, RankingEnd);
			ScoreWarRewardTable.AddRankingBegin(builder, RankingBegin);
			ScoreWarRewardTable.AddWinCount(builder, WinCount);
			ScoreWarRewardTable.AddBattleCount(builder, BattleCount);
			ScoreWarRewardTable.AddRewardId(builder, RewardId);
			ScoreWarRewardTable.AddID(builder, ID);
			return ScoreWarRewardTable.EndScoreWarRewardTable(builder);
		}

		// Token: 0x06004A43 RID: 19011 RVA: 0x000E9FFF File Offset: 0x000E83FF
		public static void StartScoreWarRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06004A44 RID: 19012 RVA: 0x000EA008 File Offset: 0x000E8408
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004A45 RID: 19013 RVA: 0x000EA013 File Offset: 0x000E8413
		public static void AddRewardId(FlatBufferBuilder builder, int RewardId)
		{
			builder.AddInt(1, RewardId, 0);
		}

		// Token: 0x06004A46 RID: 19014 RVA: 0x000EA01E File Offset: 0x000E841E
		public static void AddBattleCount(FlatBufferBuilder builder, int BattleCount)
		{
			builder.AddInt(2, BattleCount, 0);
		}

		// Token: 0x06004A47 RID: 19015 RVA: 0x000EA029 File Offset: 0x000E8429
		public static void AddWinCount(FlatBufferBuilder builder, int WinCount)
		{
			builder.AddInt(3, WinCount, 0);
		}

		// Token: 0x06004A48 RID: 19016 RVA: 0x000EA034 File Offset: 0x000E8434
		public static void AddRankingBegin(FlatBufferBuilder builder, int RankingBegin)
		{
			builder.AddInt(4, RankingBegin, 0);
		}

		// Token: 0x06004A49 RID: 19017 RVA: 0x000EA03F File Offset: 0x000E843F
		public static void AddRankingEnd(FlatBufferBuilder builder, int RankingEnd)
		{
			builder.AddInt(5, RankingEnd, 0);
		}

		// Token: 0x06004A4A RID: 19018 RVA: 0x000EA04A File Offset: 0x000E844A
		public static void AddItemReward(FlatBufferBuilder builder, VectorOffset ItemRewardOffset)
		{
			builder.AddOffset(6, ItemRewardOffset.Value, 0);
		}

		// Token: 0x06004A4B RID: 19019 RVA: 0x000EA05C File Offset: 0x000E845C
		public static VectorOffset CreateItemRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004A4C RID: 19020 RVA: 0x000EA0A2 File Offset: 0x000E84A2
		public static void StartItemRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004A4D RID: 19021 RVA: 0x000EA0AD File Offset: 0x000E84AD
		public static void AddRewardPreview(FlatBufferBuilder builder, VectorOffset RewardPreviewOffset)
		{
			builder.AddOffset(7, RewardPreviewOffset.Value, 0);
		}

		// Token: 0x06004A4E RID: 19022 RVA: 0x000EA0C0 File Offset: 0x000E84C0
		public static VectorOffset CreateRewardPreviewVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004A4F RID: 19023 RVA: 0x000EA106 File Offset: 0x000E8506
		public static void StartRewardPreviewVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004A50 RID: 19024 RVA: 0x000EA114 File Offset: 0x000E8514
		public static Offset<ScoreWarRewardTable> EndScoreWarRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ScoreWarRewardTable>(value);
		}

		// Token: 0x06004A51 RID: 19025 RVA: 0x000EA12E File Offset: 0x000E852E
		public static void FinishScoreWarRewardTableBuffer(FlatBufferBuilder builder, Offset<ScoreWarRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AE5 RID: 6885
		private Table __p = new Table();

		// Token: 0x04001AE6 RID: 6886
		private FlatBufferArray<string> ItemRewardValue;

		// Token: 0x04001AE7 RID: 6887
		private FlatBufferArray<string> RewardPreviewValue;

		// Token: 0x0200059B RID: 1435
		public enum eCrypt
		{
			// Token: 0x04001AE9 RID: 6889
			code = -1807737823
		}
	}
}
