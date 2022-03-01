using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005A3 RID: 1443
	public class SeasonDailyTable : IFlatbufferObject
	{
		// Token: 0x17001445 RID: 5189
		// (get) Token: 0x06004AA3 RID: 19107 RVA: 0x000EAC54 File Offset: 0x000E9054
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004AA4 RID: 19108 RVA: 0x000EAC61 File Offset: 0x000E9061
		public static SeasonDailyTable GetRootAsSeasonDailyTable(ByteBuffer _bb)
		{
			return SeasonDailyTable.GetRootAsSeasonDailyTable(_bb, new SeasonDailyTable());
		}

		// Token: 0x06004AA5 RID: 19109 RVA: 0x000EAC6E File Offset: 0x000E906E
		public static SeasonDailyTable GetRootAsSeasonDailyTable(ByteBuffer _bb, SeasonDailyTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004AA6 RID: 19110 RVA: 0x000EAC8A File Offset: 0x000E908A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004AA7 RID: 19111 RVA: 0x000EACA4 File Offset: 0x000E90A4
		public SeasonDailyTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001446 RID: 5190
		// (get) Token: 0x06004AA8 RID: 19112 RVA: 0x000EACB0 File Offset: 0x000E90B0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1570894362 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004AA9 RID: 19113 RVA: 0x000EACFC File Offset: 0x000E90FC
		public int MatchScoreArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (1570894362 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001447 RID: 5191
		// (get) Token: 0x06004AAA RID: 19114 RVA: 0x000EAD48 File Offset: 0x000E9148
		public int MatchScoreLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004AAB RID: 19115 RVA: 0x000EAD7A File Offset: 0x000E917A
		public ArraySegment<byte>? GetMatchScoreBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001448 RID: 5192
		// (get) Token: 0x06004AAC RID: 19116 RVA: 0x000EAD88 File Offset: 0x000E9188
		public FlatBufferArray<int> MatchScore
		{
			get
			{
				if (this.MatchScoreValue == null)
				{
					this.MatchScoreValue = new FlatBufferArray<int>(new Func<int, int>(this.MatchScoreArray), this.MatchScoreLength);
				}
				return this.MatchScoreValue;
			}
		}

		// Token: 0x06004AAD RID: 19117 RVA: 0x000EADB8 File Offset: 0x000E91B8
		public string RewardsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001449 RID: 5193
		// (get) Token: 0x06004AAE RID: 19118 RVA: 0x000EAE00 File Offset: 0x000E9200
		public int RewardsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700144A RID: 5194
		// (get) Token: 0x06004AAF RID: 19119 RVA: 0x000EAE32 File Offset: 0x000E9232
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

		// Token: 0x06004AB0 RID: 19120 RVA: 0x000EAE62 File Offset: 0x000E9262
		public static Offset<SeasonDailyTable> CreateSeasonDailyTable(FlatBufferBuilder builder, int ID = 0, VectorOffset MatchScoreOffset = default(VectorOffset), VectorOffset RewardsOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			SeasonDailyTable.AddRewards(builder, RewardsOffset);
			SeasonDailyTable.AddMatchScore(builder, MatchScoreOffset);
			SeasonDailyTable.AddID(builder, ID);
			return SeasonDailyTable.EndSeasonDailyTable(builder);
		}

		// Token: 0x06004AB1 RID: 19121 RVA: 0x000EAE86 File Offset: 0x000E9286
		public static void StartSeasonDailyTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004AB2 RID: 19122 RVA: 0x000EAE8F File Offset: 0x000E928F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004AB3 RID: 19123 RVA: 0x000EAE9A File Offset: 0x000E929A
		public static void AddMatchScore(FlatBufferBuilder builder, VectorOffset MatchScoreOffset)
		{
			builder.AddOffset(1, MatchScoreOffset.Value, 0);
		}

		// Token: 0x06004AB4 RID: 19124 RVA: 0x000EAEAC File Offset: 0x000E92AC
		public static VectorOffset CreateMatchScoreVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004AB5 RID: 19125 RVA: 0x000EAEE9 File Offset: 0x000E92E9
		public static void StartMatchScoreVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004AB6 RID: 19126 RVA: 0x000EAEF4 File Offset: 0x000E92F4
		public static void AddRewards(FlatBufferBuilder builder, VectorOffset RewardsOffset)
		{
			builder.AddOffset(2, RewardsOffset.Value, 0);
		}

		// Token: 0x06004AB7 RID: 19127 RVA: 0x000EAF08 File Offset: 0x000E9308
		public static VectorOffset CreateRewardsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004AB8 RID: 19128 RVA: 0x000EAF4E File Offset: 0x000E934E
		public static void StartRewardsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004AB9 RID: 19129 RVA: 0x000EAF5C File Offset: 0x000E935C
		public static Offset<SeasonDailyTable> EndSeasonDailyTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SeasonDailyTable>(value);
		}

		// Token: 0x06004ABA RID: 19130 RVA: 0x000EAF76 File Offset: 0x000E9376
		public static void FinishSeasonDailyTableBuffer(FlatBufferBuilder builder, Offset<SeasonDailyTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AFA RID: 6906
		private Table __p = new Table();

		// Token: 0x04001AFB RID: 6907
		private FlatBufferArray<int> MatchScoreValue;

		// Token: 0x04001AFC RID: 6908
		private FlatBufferArray<string> RewardsValue;

		// Token: 0x020005A4 RID: 1444
		public enum eCrypt
		{
			// Token: 0x04001AFE RID: 6910
			code = 1570894362
		}
	}
}
