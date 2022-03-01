using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005A8 RID: 1448
	public class SeasonRewardTable : IFlatbufferObject
	{
		// Token: 0x17001463 RID: 5219
		// (get) Token: 0x06004AFD RID: 19197 RVA: 0x000EB9D8 File Offset: 0x000E9DD8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004AFE RID: 19198 RVA: 0x000EB9E5 File Offset: 0x000E9DE5
		public static SeasonRewardTable GetRootAsSeasonRewardTable(ByteBuffer _bb)
		{
			return SeasonRewardTable.GetRootAsSeasonRewardTable(_bb, new SeasonRewardTable());
		}

		// Token: 0x06004AFF RID: 19199 RVA: 0x000EB9F2 File Offset: 0x000E9DF2
		public static SeasonRewardTable GetRootAsSeasonRewardTable(ByteBuffer _bb, SeasonRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004B00 RID: 19200 RVA: 0x000EBA0E File Offset: 0x000E9E0E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004B01 RID: 19201 RVA: 0x000EBA28 File Offset: 0x000E9E28
		public SeasonRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001464 RID: 5220
		// (get) Token: 0x06004B02 RID: 19202 RVA: 0x000EBA34 File Offset: 0x000E9E34
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1237728204 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004B03 RID: 19203 RVA: 0x000EBA80 File Offset: 0x000E9E80
		public int RankRangeArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (-1237728204 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001465 RID: 5221
		// (get) Token: 0x06004B04 RID: 19204 RVA: 0x000EBACC File Offset: 0x000E9ECC
		public int RankRangeLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004B05 RID: 19205 RVA: 0x000EBAFE File Offset: 0x000E9EFE
		public ArraySegment<byte>? GetRankRangeBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001466 RID: 5222
		// (get) Token: 0x06004B06 RID: 19206 RVA: 0x000EBB0C File Offset: 0x000E9F0C
		public FlatBufferArray<int> RankRange
		{
			get
			{
				if (this.RankRangeValue == null)
				{
					this.RankRangeValue = new FlatBufferArray<int>(new Func<int, int>(this.RankRangeArray), this.RankRangeLength);
				}
				return this.RankRangeValue;
			}
		}

		// Token: 0x06004B07 RID: 19207 RVA: 0x000EBB3C File Offset: 0x000E9F3C
		public string RewardsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001467 RID: 5223
		// (get) Token: 0x06004B08 RID: 19208 RVA: 0x000EBB84 File Offset: 0x000E9F84
		public int RewardsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001468 RID: 5224
		// (get) Token: 0x06004B09 RID: 19209 RVA: 0x000EBBB6 File Offset: 0x000E9FB6
		public FlatBufferArray<string> Rewards
		{
			get
			{
				if (this.RewardsValue == null)
				{
					this.RewardsValue = new FlatBufferArray<string>(new Func<int, string>(this.RewardsArray), this.RewardsLength);
				}
				return this.RewardsValue;
			}
		}

		// Token: 0x06004B0A RID: 19210 RVA: 0x000EBBE6 File Offset: 0x000E9FE6
		public static Offset<SeasonRewardTable> CreateSeasonRewardTable(FlatBufferBuilder builder, int ID = 0, VectorOffset RankRangeOffset = default(VectorOffset), VectorOffset RewardsOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			SeasonRewardTable.AddRewards(builder, RewardsOffset);
			SeasonRewardTable.AddRankRange(builder, RankRangeOffset);
			SeasonRewardTable.AddID(builder, ID);
			return SeasonRewardTable.EndSeasonRewardTable(builder);
		}

		// Token: 0x06004B0B RID: 19211 RVA: 0x000EBC0A File Offset: 0x000EA00A
		public static void StartSeasonRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004B0C RID: 19212 RVA: 0x000EBC13 File Offset: 0x000EA013
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004B0D RID: 19213 RVA: 0x000EBC1E File Offset: 0x000EA01E
		public static void AddRankRange(FlatBufferBuilder builder, VectorOffset RankRangeOffset)
		{
			builder.AddOffset(1, RankRangeOffset.Value, 0);
		}

		// Token: 0x06004B0E RID: 19214 RVA: 0x000EBC30 File Offset: 0x000EA030
		public static VectorOffset CreateRankRangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004B0F RID: 19215 RVA: 0x000EBC6D File Offset: 0x000EA06D
		public static void StartRankRangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004B10 RID: 19216 RVA: 0x000EBC78 File Offset: 0x000EA078
		public static void AddRewards(FlatBufferBuilder builder, VectorOffset RewardsOffset)
		{
			builder.AddOffset(2, RewardsOffset.Value, 0);
		}

		// Token: 0x06004B11 RID: 19217 RVA: 0x000EBC8C File Offset: 0x000EA08C
		public static VectorOffset CreateRewardsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004B12 RID: 19218 RVA: 0x000EBCD2 File Offset: 0x000EA0D2
		public static void StartRewardsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004B13 RID: 19219 RVA: 0x000EBCE0 File Offset: 0x000EA0E0
		public static Offset<SeasonRewardTable> EndSeasonRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SeasonRewardTable>(value);
		}

		// Token: 0x06004B14 RID: 19220 RVA: 0x000EBCFA File Offset: 0x000EA0FA
		public static void FinishSeasonRewardTableBuffer(FlatBufferBuilder builder, Offset<SeasonRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B0C RID: 6924
		private Table __p = new Table();

		// Token: 0x04001B0D RID: 6925
		private FlatBufferArray<int> RankRangeValue;

		// Token: 0x04001B0E RID: 6926
		private FlatBufferArray<string> RewardsValue;

		// Token: 0x020005A9 RID: 1449
		public enum eCrypt
		{
			// Token: 0x04001B10 RID: 6928
			code = -1237728204
		}
	}
}
