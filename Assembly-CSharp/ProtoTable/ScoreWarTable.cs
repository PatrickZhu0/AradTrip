using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200059C RID: 1436
	public class ScoreWarTable : IFlatbufferObject
	{
		// Token: 0x1700142C RID: 5164
		// (get) Token: 0x06004A53 RID: 19027 RVA: 0x000EA150 File Offset: 0x000E8550
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004A54 RID: 19028 RVA: 0x000EA15D File Offset: 0x000E855D
		public static ScoreWarTable GetRootAsScoreWarTable(ByteBuffer _bb)
		{
			return ScoreWarTable.GetRootAsScoreWarTable(_bb, new ScoreWarTable());
		}

		// Token: 0x06004A55 RID: 19029 RVA: 0x000EA16A File Offset: 0x000E856A
		public static ScoreWarTable GetRootAsScoreWarTable(ByteBuffer _bb, ScoreWarTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004A56 RID: 19030 RVA: 0x000EA186 File Offset: 0x000E8586
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004A57 RID: 19031 RVA: 0x000EA1A0 File Offset: 0x000E85A0
		public ScoreWarTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700142D RID: 5165
		// (get) Token: 0x06004A58 RID: 19032 RVA: 0x000EA1AC File Offset: 0x000E85AC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (294447050 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700142E RID: 5166
		// (get) Token: 0x06004A59 RID: 19033 RVA: 0x000EA1F8 File Offset: 0x000E85F8
		public int Group
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (294447050 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700142F RID: 5167
		// (get) Token: 0x06004A5A RID: 19034 RVA: 0x000EA244 File Offset: 0x000E8644
		public ScoreWarTable.eStatus Status
		{
			get
			{
				int num = this.__p.__offset(8);
				return (ScoreWarTable.eStatus)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001430 RID: 5168
		// (get) Token: 0x06004A5B RID: 19035 RVA: 0x000EA288 File Offset: 0x000E8688
		public int Week
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (294447050 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001431 RID: 5169
		// (get) Token: 0x06004A5C RID: 19036 RVA: 0x000EA2D4 File Offset: 0x000E86D4
		public string Time
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004A5D RID: 19037 RVA: 0x000EA317 File Offset: 0x000E8717
		public ArraySegment<byte>? GetTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001432 RID: 5170
		// (get) Token: 0x06004A5E RID: 19038 RVA: 0x000EA328 File Offset: 0x000E8728
		public int IsOpen
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (294447050 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004A5F RID: 19039 RVA: 0x000EA372 File Offset: 0x000E8772
		public static Offset<ScoreWarTable> CreateScoreWarTable(FlatBufferBuilder builder, int ID = 0, int Group = 0, ScoreWarTable.eStatus Status = ScoreWarTable.eStatus.SWS_INVALID, int Week = 0, StringOffset TimeOffset = default(StringOffset), int IsOpen = 0)
		{
			builder.StartObject(6);
			ScoreWarTable.AddIsOpen(builder, IsOpen);
			ScoreWarTable.AddTime(builder, TimeOffset);
			ScoreWarTable.AddWeek(builder, Week);
			ScoreWarTable.AddStatus(builder, Status);
			ScoreWarTable.AddGroup(builder, Group);
			ScoreWarTable.AddID(builder, ID);
			return ScoreWarTable.EndScoreWarTable(builder);
		}

		// Token: 0x06004A60 RID: 19040 RVA: 0x000EA3AE File Offset: 0x000E87AE
		public static void StartScoreWarTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06004A61 RID: 19041 RVA: 0x000EA3B7 File Offset: 0x000E87B7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004A62 RID: 19042 RVA: 0x000EA3C2 File Offset: 0x000E87C2
		public static void AddGroup(FlatBufferBuilder builder, int Group)
		{
			builder.AddInt(1, Group, 0);
		}

		// Token: 0x06004A63 RID: 19043 RVA: 0x000EA3CD File Offset: 0x000E87CD
		public static void AddStatus(FlatBufferBuilder builder, ScoreWarTable.eStatus Status)
		{
			builder.AddInt(2, (int)Status, 0);
		}

		// Token: 0x06004A64 RID: 19044 RVA: 0x000EA3D8 File Offset: 0x000E87D8
		public static void AddWeek(FlatBufferBuilder builder, int Week)
		{
			builder.AddInt(3, Week, 0);
		}

		// Token: 0x06004A65 RID: 19045 RVA: 0x000EA3E3 File Offset: 0x000E87E3
		public static void AddTime(FlatBufferBuilder builder, StringOffset TimeOffset)
		{
			builder.AddOffset(4, TimeOffset.Value, 0);
		}

		// Token: 0x06004A66 RID: 19046 RVA: 0x000EA3F4 File Offset: 0x000E87F4
		public static void AddIsOpen(FlatBufferBuilder builder, int IsOpen)
		{
			builder.AddInt(5, IsOpen, 0);
		}

		// Token: 0x06004A67 RID: 19047 RVA: 0x000EA400 File Offset: 0x000E8800
		public static Offset<ScoreWarTable> EndScoreWarTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ScoreWarTable>(value);
		}

		// Token: 0x06004A68 RID: 19048 RVA: 0x000EA41A File Offset: 0x000E881A
		public static void FinishScoreWarTableBuffer(FlatBufferBuilder builder, Offset<ScoreWarTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AEA RID: 6890
		private Table __p = new Table();

		// Token: 0x0200059D RID: 1437
		public enum eStatus
		{
			// Token: 0x04001AEC RID: 6892
			SWS_INVALID,
			// Token: 0x04001AED RID: 6893
			SWS_PREPARE,
			// Token: 0x04001AEE RID: 6894
			SWS_BATTLE,
			// Token: 0x04001AEF RID: 6895
			SWS_WAIT_END
		}

		// Token: 0x0200059E RID: 1438
		public enum eCrypt
		{
			// Token: 0x04001AF1 RID: 6897
			code = 294447050
		}
	}
}
