using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000597 RID: 1431
	public class ScoreWar2v2Table : IFlatbufferObject
	{
		// Token: 0x1700141A RID: 5146
		// (get) Token: 0x06004A1A RID: 18970 RVA: 0x000E9940 File Offset: 0x000E7D40
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004A1B RID: 18971 RVA: 0x000E994D File Offset: 0x000E7D4D
		public static ScoreWar2v2Table GetRootAsScoreWar2v2Table(ByteBuffer _bb)
		{
			return ScoreWar2v2Table.GetRootAsScoreWar2v2Table(_bb, new ScoreWar2v2Table());
		}

		// Token: 0x06004A1C RID: 18972 RVA: 0x000E995A File Offset: 0x000E7D5A
		public static ScoreWar2v2Table GetRootAsScoreWar2v2Table(ByteBuffer _bb, ScoreWar2v2Table obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004A1D RID: 18973 RVA: 0x000E9976 File Offset: 0x000E7D76
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004A1E RID: 18974 RVA: 0x000E9990 File Offset: 0x000E7D90
		public ScoreWar2v2Table __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700141B RID: 5147
		// (get) Token: 0x06004A1F RID: 18975 RVA: 0x000E999C File Offset: 0x000E7D9C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-483104224 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700141C RID: 5148
		// (get) Token: 0x06004A20 RID: 18976 RVA: 0x000E99E8 File Offset: 0x000E7DE8
		public int Group
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-483104224 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700141D RID: 5149
		// (get) Token: 0x06004A21 RID: 18977 RVA: 0x000E9A34 File Offset: 0x000E7E34
		public ScoreWar2v2Table.eStatus Status
		{
			get
			{
				int num = this.__p.__offset(8);
				return (ScoreWar2v2Table.eStatus)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700141E RID: 5150
		// (get) Token: 0x06004A22 RID: 18978 RVA: 0x000E9A78 File Offset: 0x000E7E78
		public int Week
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-483104224 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700141F RID: 5151
		// (get) Token: 0x06004A23 RID: 18979 RVA: 0x000E9AC4 File Offset: 0x000E7EC4
		public string Time
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004A24 RID: 18980 RVA: 0x000E9B07 File Offset: 0x000E7F07
		public ArraySegment<byte>? GetTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001420 RID: 5152
		// (get) Token: 0x06004A25 RID: 18981 RVA: 0x000E9B18 File Offset: 0x000E7F18
		public int IsOpen
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-483104224 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004A26 RID: 18982 RVA: 0x000E9B62 File Offset: 0x000E7F62
		public static Offset<ScoreWar2v2Table> CreateScoreWar2v2Table(FlatBufferBuilder builder, int ID = 0, int Group = 0, ScoreWar2v2Table.eStatus Status = ScoreWar2v2Table.eStatus.SWS_INVALID, int Week = 0, StringOffset TimeOffset = default(StringOffset), int IsOpen = 0)
		{
			builder.StartObject(6);
			ScoreWar2v2Table.AddIsOpen(builder, IsOpen);
			ScoreWar2v2Table.AddTime(builder, TimeOffset);
			ScoreWar2v2Table.AddWeek(builder, Week);
			ScoreWar2v2Table.AddStatus(builder, Status);
			ScoreWar2v2Table.AddGroup(builder, Group);
			ScoreWar2v2Table.AddID(builder, ID);
			return ScoreWar2v2Table.EndScoreWar2v2Table(builder);
		}

		// Token: 0x06004A27 RID: 18983 RVA: 0x000E9B9E File Offset: 0x000E7F9E
		public static void StartScoreWar2v2Table(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06004A28 RID: 18984 RVA: 0x000E9BA7 File Offset: 0x000E7FA7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004A29 RID: 18985 RVA: 0x000E9BB2 File Offset: 0x000E7FB2
		public static void AddGroup(FlatBufferBuilder builder, int Group)
		{
			builder.AddInt(1, Group, 0);
		}

		// Token: 0x06004A2A RID: 18986 RVA: 0x000E9BBD File Offset: 0x000E7FBD
		public static void AddStatus(FlatBufferBuilder builder, ScoreWar2v2Table.eStatus Status)
		{
			builder.AddInt(2, (int)Status, 0);
		}

		// Token: 0x06004A2B RID: 18987 RVA: 0x000E9BC8 File Offset: 0x000E7FC8
		public static void AddWeek(FlatBufferBuilder builder, int Week)
		{
			builder.AddInt(3, Week, 0);
		}

		// Token: 0x06004A2C RID: 18988 RVA: 0x000E9BD3 File Offset: 0x000E7FD3
		public static void AddTime(FlatBufferBuilder builder, StringOffset TimeOffset)
		{
			builder.AddOffset(4, TimeOffset.Value, 0);
		}

		// Token: 0x06004A2D RID: 18989 RVA: 0x000E9BE4 File Offset: 0x000E7FE4
		public static void AddIsOpen(FlatBufferBuilder builder, int IsOpen)
		{
			builder.AddInt(5, IsOpen, 0);
		}

		// Token: 0x06004A2E RID: 18990 RVA: 0x000E9BF0 File Offset: 0x000E7FF0
		public static Offset<ScoreWar2v2Table> EndScoreWar2v2Table(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ScoreWar2v2Table>(value);
		}

		// Token: 0x06004A2F RID: 18991 RVA: 0x000E9C0A File Offset: 0x000E800A
		public static void FinishScoreWar2v2TableBuffer(FlatBufferBuilder builder, Offset<ScoreWar2v2Table> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001ADD RID: 6877
		private Table __p = new Table();

		// Token: 0x02000598 RID: 1432
		public enum eStatus
		{
			// Token: 0x04001ADF RID: 6879
			SWS_INVALID,
			// Token: 0x04001AE0 RID: 6880
			SWS_PREPARE,
			// Token: 0x04001AE1 RID: 6881
			SWS_BATTLE,
			// Token: 0x04001AE2 RID: 6882
			SWS_WAIT_END
		}

		// Token: 0x02000599 RID: 1433
		public enum eCrypt
		{
			// Token: 0x04001AE4 RID: 6884
			code = -483104224
		}
	}
}
