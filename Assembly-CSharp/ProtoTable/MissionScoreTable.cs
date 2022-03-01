using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000500 RID: 1280
	public class MissionScoreTable : IFlatbufferObject
	{
		// Token: 0x17001156 RID: 4438
		// (get) Token: 0x0600419F RID: 16799 RVA: 0x000D6584 File Offset: 0x000D4984
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060041A0 RID: 16800 RVA: 0x000D6591 File Offset: 0x000D4991
		public static MissionScoreTable GetRootAsMissionScoreTable(ByteBuffer _bb)
		{
			return MissionScoreTable.GetRootAsMissionScoreTable(_bb, new MissionScoreTable());
		}

		// Token: 0x060041A1 RID: 16801 RVA: 0x000D659E File Offset: 0x000D499E
		public static MissionScoreTable GetRootAsMissionScoreTable(ByteBuffer _bb, MissionScoreTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060041A2 RID: 16802 RVA: 0x000D65BA File Offset: 0x000D49BA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060041A3 RID: 16803 RVA: 0x000D65D4 File Offset: 0x000D49D4
		public MissionScoreTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001157 RID: 4439
		// (get) Token: 0x060041A4 RID: 16804 RVA: 0x000D65E0 File Offset: 0x000D49E0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (634797042 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001158 RID: 4440
		// (get) Token: 0x060041A5 RID: 16805 RVA: 0x000D662C File Offset: 0x000D4A2C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041A6 RID: 16806 RVA: 0x000D666E File Offset: 0x000D4A6E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001159 RID: 4441
		// (get) Token: 0x060041A7 RID: 16807 RVA: 0x000D667C File Offset: 0x000D4A7C
		public string UnOpenedChestBoxIcon
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041A8 RID: 16808 RVA: 0x000D66BE File Offset: 0x000D4ABE
		public ArraySegment<byte>? GetUnOpenedChestBoxIconBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700115A RID: 4442
		// (get) Token: 0x060041A9 RID: 16809 RVA: 0x000D66CC File Offset: 0x000D4ACC
		public string OpenedChestBoxIcon
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041AA RID: 16810 RVA: 0x000D670F File Offset: 0x000D4B0F
		public ArraySegment<byte>? GetOpenedChestBoxIconBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700115B RID: 4443
		// (get) Token: 0x060041AB RID: 16811 RVA: 0x000D6720 File Offset: 0x000D4B20
		public int Score
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (634797042 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700115C RID: 4444
		// (get) Token: 0x060041AC RID: 16812 RVA: 0x000D676C File Offset: 0x000D4B6C
		public int TotalScore
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (634797042 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060041AD RID: 16813 RVA: 0x000D67B8 File Offset: 0x000D4BB8
		public string AwardsArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700115D RID: 4445
		// (get) Token: 0x060041AE RID: 16814 RVA: 0x000D6800 File Offset: 0x000D4C00
		public int AwardsLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700115E RID: 4446
		// (get) Token: 0x060041AF RID: 16815 RVA: 0x000D6833 File Offset: 0x000D4C33
		public FlatBufferArray<string> Awards
		{
			get
			{
				if (this.AwardsValue == null)
				{
					this.AwardsValue = new FlatBufferArray<string>(new Func<int, string>(this.AwardsArray), this.AwardsLength);
				}
				return this.AwardsValue;
			}
		}

		// Token: 0x060041B0 RID: 16816 RVA: 0x000D6864 File Offset: 0x000D4C64
		public static Offset<MissionScoreTable> CreateMissionScoreTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset UnOpenedChestBoxIconOffset = default(StringOffset), StringOffset OpenedChestBoxIconOffset = default(StringOffset), int Score = 0, int TotalScore = 0, VectorOffset AwardsOffset = default(VectorOffset))
		{
			builder.StartObject(7);
			MissionScoreTable.AddAwards(builder, AwardsOffset);
			MissionScoreTable.AddTotalScore(builder, TotalScore);
			MissionScoreTable.AddScore(builder, Score);
			MissionScoreTable.AddOpenedChestBoxIcon(builder, OpenedChestBoxIconOffset);
			MissionScoreTable.AddUnOpenedChestBoxIcon(builder, UnOpenedChestBoxIconOffset);
			MissionScoreTable.AddName(builder, NameOffset);
			MissionScoreTable.AddID(builder, ID);
			return MissionScoreTable.EndMissionScoreTable(builder);
		}

		// Token: 0x060041B1 RID: 16817 RVA: 0x000D68B3 File Offset: 0x000D4CB3
		public static void StartMissionScoreTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x060041B2 RID: 16818 RVA: 0x000D68BC File Offset: 0x000D4CBC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060041B3 RID: 16819 RVA: 0x000D68C7 File Offset: 0x000D4CC7
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060041B4 RID: 16820 RVA: 0x000D68D8 File Offset: 0x000D4CD8
		public static void AddUnOpenedChestBoxIcon(FlatBufferBuilder builder, StringOffset UnOpenedChestBoxIconOffset)
		{
			builder.AddOffset(2, UnOpenedChestBoxIconOffset.Value, 0);
		}

		// Token: 0x060041B5 RID: 16821 RVA: 0x000D68E9 File Offset: 0x000D4CE9
		public static void AddOpenedChestBoxIcon(FlatBufferBuilder builder, StringOffset OpenedChestBoxIconOffset)
		{
			builder.AddOffset(3, OpenedChestBoxIconOffset.Value, 0);
		}

		// Token: 0x060041B6 RID: 16822 RVA: 0x000D68FA File Offset: 0x000D4CFA
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(4, Score, 0);
		}

		// Token: 0x060041B7 RID: 16823 RVA: 0x000D6905 File Offset: 0x000D4D05
		public static void AddTotalScore(FlatBufferBuilder builder, int TotalScore)
		{
			builder.AddInt(5, TotalScore, 0);
		}

		// Token: 0x060041B8 RID: 16824 RVA: 0x000D6910 File Offset: 0x000D4D10
		public static void AddAwards(FlatBufferBuilder builder, VectorOffset AwardsOffset)
		{
			builder.AddOffset(6, AwardsOffset.Value, 0);
		}

		// Token: 0x060041B9 RID: 16825 RVA: 0x000D6924 File Offset: 0x000D4D24
		public static VectorOffset CreateAwardsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060041BA RID: 16826 RVA: 0x000D696A File Offset: 0x000D4D6A
		public static void StartAwardsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060041BB RID: 16827 RVA: 0x000D6978 File Offset: 0x000D4D78
		public static Offset<MissionScoreTable> EndMissionScoreTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MissionScoreTable>(value);
		}

		// Token: 0x060041BC RID: 16828 RVA: 0x000D6992 File Offset: 0x000D4D92
		public static void FinishMissionScoreTableBuffer(FlatBufferBuilder builder, Offset<MissionScoreTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400187C RID: 6268
		private Table __p = new Table();

		// Token: 0x0400187D RID: 6269
		private FlatBufferArray<string> AwardsValue;

		// Token: 0x02000501 RID: 1281
		public enum eCrypt
		{
			// Token: 0x0400187F RID: 6271
			code = 634797042
		}
	}
}
