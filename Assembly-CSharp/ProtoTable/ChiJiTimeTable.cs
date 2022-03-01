using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000338 RID: 824
	public class ChiJiTimeTable : IFlatbufferObject
	{
		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06002133 RID: 8499 RVA: 0x000881D4 File Offset: 0x000865D4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002134 RID: 8500 RVA: 0x000881E1 File Offset: 0x000865E1
		public static ChiJiTimeTable GetRootAsChiJiTimeTable(ByteBuffer _bb)
		{
			return ChiJiTimeTable.GetRootAsChiJiTimeTable(_bb, new ChiJiTimeTable());
		}

		// Token: 0x06002135 RID: 8501 RVA: 0x000881EE File Offset: 0x000865EE
		public static ChiJiTimeTable GetRootAsChiJiTimeTable(ByteBuffer _bb, ChiJiTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002136 RID: 8502 RVA: 0x0008820A File Offset: 0x0008660A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002137 RID: 8503 RVA: 0x00088224 File Offset: 0x00086624
		public ChiJiTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x06002138 RID: 8504 RVA: 0x00088230 File Offset: 0x00086630
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x06002139 RID: 8505 RVA: 0x0008827C File Offset: 0x0008667C
		public ChiJiTimeTable.eChickenType ChickenType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (ChiJiTimeTable.eChickenType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x0600213A RID: 8506 RVA: 0x000882C0 File Offset: 0x000866C0
		public string ChickenTypeName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600213B RID: 8507 RVA: 0x00088302 File Offset: 0x00086702
		public ArraySegment<byte>? GetChickenTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x0600213C RID: 8508 RVA: 0x00088310 File Offset: 0x00086710
		public ChiJiTimeTable.eBattleStage BattleStage
		{
			get
			{
				int num = this.__p.__offset(10);
				return (ChiJiTimeTable.eBattleStage)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x0600213D RID: 8509 RVA: 0x00088354 File Offset: 0x00086754
		public int ChickenParameter
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x0600213E RID: 8510 RVA: 0x000883A0 File Offset: 0x000867A0
		public int StartTime
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x0600213F RID: 8511 RVA: 0x000883EC File Offset: 0x000867EC
		public int ContinueTime
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x06002140 RID: 8512 RVA: 0x00088438 File Offset: 0x00086838
		public int NextStage
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x06002141 RID: 8513 RVA: 0x00088484 File Offset: 0x00086884
		public int ProgressTime
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x06002142 RID: 8514 RVA: 0x000884D0 File Offset: 0x000868D0
		public int ContinueInjury
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x06002143 RID: 8515 RVA: 0x0008851C File Offset: 0x0008691C
		public int NextDuquanID
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002144 RID: 8516 RVA: 0x00088568 File Offset: 0x00086968
		public int packIDsArray(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? 0 : (613655378 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06002145 RID: 8517 RVA: 0x000885B8 File Offset: 0x000869B8
		public int packIDsLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002146 RID: 8518 RVA: 0x000885EB File Offset: 0x000869EB
		public ArraySegment<byte>? GetPackIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06002147 RID: 8519 RVA: 0x000885FA File Offset: 0x000869FA
		public FlatBufferArray<int> packIDs
		{
			get
			{
				if (this.packIDsValue == null)
				{
					this.packIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.packIDsArray), this.packIDsLength);
				}
				return this.packIDsValue;
			}
		}

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x06002148 RID: 8520 RVA: 0x0008862C File Offset: 0x00086A2C
		public string StageTip
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002149 RID: 8521 RVA: 0x0008866F File Offset: 0x00086A6F
		public ArraySegment<byte>? GetStageTipBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x0600214A RID: 8522 RVA: 0x00088680 File Offset: 0x00086A80
		public static Offset<ChiJiTimeTable> CreateChiJiTimeTable(FlatBufferBuilder builder, int ID = 0, ChiJiTimeTable.eChickenType ChickenType = ChiJiTimeTable.eChickenType.ChickenType_None, StringOffset ChickenTypeNameOffset = default(StringOffset), ChiJiTimeTable.eBattleStage BattleStage = ChiJiTimeTable.eBattleStage.BS_NONE, int ChickenParameter = 0, int StartTime = 0, int ContinueTime = 0, int NextStage = 0, int ProgressTime = 0, int ContinueInjury = 0, int NextDuquanID = 0, VectorOffset packIDsOffset = default(VectorOffset), StringOffset StageTipOffset = default(StringOffset))
		{
			builder.StartObject(13);
			ChiJiTimeTable.AddStageTip(builder, StageTipOffset);
			ChiJiTimeTable.AddPackIDs(builder, packIDsOffset);
			ChiJiTimeTable.AddNextDuquanID(builder, NextDuquanID);
			ChiJiTimeTable.AddContinueInjury(builder, ContinueInjury);
			ChiJiTimeTable.AddProgressTime(builder, ProgressTime);
			ChiJiTimeTable.AddNextStage(builder, NextStage);
			ChiJiTimeTable.AddContinueTime(builder, ContinueTime);
			ChiJiTimeTable.AddStartTime(builder, StartTime);
			ChiJiTimeTable.AddChickenParameter(builder, ChickenParameter);
			ChiJiTimeTable.AddBattleStage(builder, BattleStage);
			ChiJiTimeTable.AddChickenTypeName(builder, ChickenTypeNameOffset);
			ChiJiTimeTable.AddChickenType(builder, ChickenType);
			ChiJiTimeTable.AddID(builder, ID);
			return ChiJiTimeTable.EndChiJiTimeTable(builder);
		}

		// Token: 0x0600214B RID: 8523 RVA: 0x00088700 File Offset: 0x00086B00
		public static void StartChiJiTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x0600214C RID: 8524 RVA: 0x0008870A File Offset: 0x00086B0A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600214D RID: 8525 RVA: 0x00088715 File Offset: 0x00086B15
		public static void AddChickenType(FlatBufferBuilder builder, ChiJiTimeTable.eChickenType ChickenType)
		{
			builder.AddInt(1, (int)ChickenType, 0);
		}

		// Token: 0x0600214E RID: 8526 RVA: 0x00088720 File Offset: 0x00086B20
		public static void AddChickenTypeName(FlatBufferBuilder builder, StringOffset ChickenTypeNameOffset)
		{
			builder.AddOffset(2, ChickenTypeNameOffset.Value, 0);
		}

		// Token: 0x0600214F RID: 8527 RVA: 0x00088731 File Offset: 0x00086B31
		public static void AddBattleStage(FlatBufferBuilder builder, ChiJiTimeTable.eBattleStage BattleStage)
		{
			builder.AddInt(3, (int)BattleStage, 0);
		}

		// Token: 0x06002150 RID: 8528 RVA: 0x0008873C File Offset: 0x00086B3C
		public static void AddChickenParameter(FlatBufferBuilder builder, int ChickenParameter)
		{
			builder.AddInt(4, ChickenParameter, 0);
		}

		// Token: 0x06002151 RID: 8529 RVA: 0x00088747 File Offset: 0x00086B47
		public static void AddStartTime(FlatBufferBuilder builder, int StartTime)
		{
			builder.AddInt(5, StartTime, 0);
		}

		// Token: 0x06002152 RID: 8530 RVA: 0x00088752 File Offset: 0x00086B52
		public static void AddContinueTime(FlatBufferBuilder builder, int ContinueTime)
		{
			builder.AddInt(6, ContinueTime, 0);
		}

		// Token: 0x06002153 RID: 8531 RVA: 0x0008875D File Offset: 0x00086B5D
		public static void AddNextStage(FlatBufferBuilder builder, int NextStage)
		{
			builder.AddInt(7, NextStage, 0);
		}

		// Token: 0x06002154 RID: 8532 RVA: 0x00088768 File Offset: 0x00086B68
		public static void AddProgressTime(FlatBufferBuilder builder, int ProgressTime)
		{
			builder.AddInt(8, ProgressTime, 0);
		}

		// Token: 0x06002155 RID: 8533 RVA: 0x00088773 File Offset: 0x00086B73
		public static void AddContinueInjury(FlatBufferBuilder builder, int ContinueInjury)
		{
			builder.AddInt(9, ContinueInjury, 0);
		}

		// Token: 0x06002156 RID: 8534 RVA: 0x0008877F File Offset: 0x00086B7F
		public static void AddNextDuquanID(FlatBufferBuilder builder, int NextDuquanID)
		{
			builder.AddInt(10, NextDuquanID, 0);
		}

		// Token: 0x06002157 RID: 8535 RVA: 0x0008878B File Offset: 0x00086B8B
		public static void AddPackIDs(FlatBufferBuilder builder, VectorOffset packIDsOffset)
		{
			builder.AddOffset(11, packIDsOffset.Value, 0);
		}

		// Token: 0x06002158 RID: 8536 RVA: 0x000887A0 File Offset: 0x00086BA0
		public static VectorOffset CreatePackIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002159 RID: 8537 RVA: 0x000887DD File Offset: 0x00086BDD
		public static void StartPackIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600215A RID: 8538 RVA: 0x000887E8 File Offset: 0x00086BE8
		public static void AddStageTip(FlatBufferBuilder builder, StringOffset StageTipOffset)
		{
			builder.AddOffset(12, StageTipOffset.Value, 0);
		}

		// Token: 0x0600215B RID: 8539 RVA: 0x000887FC File Offset: 0x00086BFC
		public static Offset<ChiJiTimeTable> EndChiJiTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiTimeTable>(value);
		}

		// Token: 0x0600215C RID: 8540 RVA: 0x00088816 File Offset: 0x00086C16
		public static void FinishChiJiTimeTableBuffer(FlatBufferBuilder builder, Offset<ChiJiTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000FE6 RID: 4070
		private Table __p = new Table();

		// Token: 0x04000FE7 RID: 4071
		private FlatBufferArray<int> packIDsValue;

		// Token: 0x02000339 RID: 825
		public enum eChickenType
		{
			// Token: 0x04000FE9 RID: 4073
			ChickenType_None,
			// Token: 0x04000FEA RID: 4074
			CHOOSE_ROLE,
			// Token: 0x04000FEB RID: 4075
			CHOOSE_JOB,
			// Token: 0x04000FEC RID: 4076
			PREPARE_TIME,
			// Token: 0x04000FED RID: 4077
			PUT_ITEM,
			// Token: 0x04000FEE RID: 4078
			START_PK,
			// Token: 0x04000FEF RID: 4079
			POSION_SCOPE
		}

		// Token: 0x0200033A RID: 826
		public enum eBattleStage
		{
			// Token: 0x04000FF1 RID: 4081
			BS_NONE,
			// Token: 0x04000FF2 RID: 4082
			BS_CHOOSE_ROLE,
			// Token: 0x04000FF3 RID: 4083
			BS_CHOOSE_JOB,
			// Token: 0x04000FF4 RID: 4084
			BS_PREPARE_TIME,
			// Token: 0x04000FF5 RID: 4085
			BS_SAFE_AREA_0,
			// Token: 0x04000FF6 RID: 4086
			BS_PUT_ITEM_1,
			// Token: 0x04000FF7 RID: 4087
			BS_START_PK,
			// Token: 0x04000FF8 RID: 4088
			BS_NPC_1,
			// Token: 0x04000FF9 RID: 4089
			BS_SAFE_AREA_1,
			// Token: 0x04000FFA RID: 4090
			BS_NPC_2,
			// Token: 0x04000FFB RID: 4091
			BS_PUT_ITEM_2,
			// Token: 0x04000FFC RID: 4092
			BS_SAFE_AREA_2,
			// Token: 0x04000FFD RID: 4093
			BS_NPC_3,
			// Token: 0x04000FFE RID: 4094
			BS_PUT_ITEM_3,
			// Token: 0x04000FFF RID: 4095
			BS_SAFE_AREA_3
		}

		// Token: 0x0200033B RID: 827
		public enum eCrypt
		{
			// Token: 0x04001001 RID: 4097
			code = 613655378
		}
	}
}
