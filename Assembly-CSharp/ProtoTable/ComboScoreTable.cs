using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200035D RID: 861
	public class ComboScoreTable : IFlatbufferObject
	{
		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x060024E2 RID: 9442 RVA: 0x00092008 File Offset: 0x00090408
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x00092015 File Offset: 0x00090415
		public static ComboScoreTable GetRootAsComboScoreTable(ByteBuffer _bb)
		{
			return ComboScoreTable.GetRootAsComboScoreTable(_bb, new ComboScoreTable());
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x00092022 File Offset: 0x00090422
		public static ComboScoreTable GetRootAsComboScoreTable(ByteBuffer _bb, ComboScoreTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060024E5 RID: 9445 RVA: 0x0009203E File Offset: 0x0009043E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060024E6 RID: 9446 RVA: 0x00092058 File Offset: 0x00090458
		public ComboScoreTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x060024E7 RID: 9447 RVA: 0x00092064 File Offset: 0x00090464
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1753797086 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x060024E8 RID: 9448 RVA: 0x000920B0 File Offset: 0x000904B0
		public int JobID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1753797086 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x060024E9 RID: 9449 RVA: 0x000920FC File Offset: 0x000904FC
		public string JobDes
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x0009213E File Offset: 0x0009053E
		public ArraySegment<byte>? GetJobDesBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x060024EB RID: 9451 RVA: 0x0009214C File Offset: 0x0009054C
		public int Percent
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1753797086 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x060024EC RID: 9452 RVA: 0x00092198 File Offset: 0x00090598
		public int BaseScore
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1753797086 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x060024ED RID: 9453 RVA: 0x000921E4 File Offset: 0x000905E4
		public int MinCombo
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1753797086 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060024EE RID: 9454 RVA: 0x0009222E File Offset: 0x0009062E
		public static Offset<ComboScoreTable> CreateComboScoreTable(FlatBufferBuilder builder, int ID = 0, int JobID = 0, StringOffset JobDesOffset = default(StringOffset), int Percent = 0, int BaseScore = 0, int MinCombo = 0)
		{
			builder.StartObject(6);
			ComboScoreTable.AddMinCombo(builder, MinCombo);
			ComboScoreTable.AddBaseScore(builder, BaseScore);
			ComboScoreTable.AddPercent(builder, Percent);
			ComboScoreTable.AddJobDes(builder, JobDesOffset);
			ComboScoreTable.AddJobID(builder, JobID);
			ComboScoreTable.AddID(builder, ID);
			return ComboScoreTable.EndComboScoreTable(builder);
		}

		// Token: 0x060024EF RID: 9455 RVA: 0x0009226A File Offset: 0x0009066A
		public static void StartComboScoreTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x060024F0 RID: 9456 RVA: 0x00092273 File Offset: 0x00090673
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x0009227E File Offset: 0x0009067E
		public static void AddJobID(FlatBufferBuilder builder, int JobID)
		{
			builder.AddInt(1, JobID, 0);
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x00092289 File Offset: 0x00090689
		public static void AddJobDes(FlatBufferBuilder builder, StringOffset JobDesOffset)
		{
			builder.AddOffset(2, JobDesOffset.Value, 0);
		}

		// Token: 0x060024F3 RID: 9459 RVA: 0x0009229A File Offset: 0x0009069A
		public static void AddPercent(FlatBufferBuilder builder, int Percent)
		{
			builder.AddInt(3, Percent, 0);
		}

		// Token: 0x060024F4 RID: 9460 RVA: 0x000922A5 File Offset: 0x000906A5
		public static void AddBaseScore(FlatBufferBuilder builder, int BaseScore)
		{
			builder.AddInt(4, BaseScore, 0);
		}

		// Token: 0x060024F5 RID: 9461 RVA: 0x000922B0 File Offset: 0x000906B0
		public static void AddMinCombo(FlatBufferBuilder builder, int MinCombo)
		{
			builder.AddInt(5, MinCombo, 0);
		}

		// Token: 0x060024F6 RID: 9462 RVA: 0x000922BC File Offset: 0x000906BC
		public static Offset<ComboScoreTable> EndComboScoreTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ComboScoreTable>(value);
		}

		// Token: 0x060024F7 RID: 9463 RVA: 0x000922D6 File Offset: 0x000906D6
		public static void FinishComboScoreTableBuffer(FlatBufferBuilder builder, Offset<ComboScoreTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001126 RID: 4390
		private Table __p = new Table();

		// Token: 0x0200035E RID: 862
		public enum eCrypt
		{
			// Token: 0x04001128 RID: 4392
			code = -1753797086
		}
	}
}
