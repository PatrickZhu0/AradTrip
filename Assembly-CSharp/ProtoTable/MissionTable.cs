using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000502 RID: 1282
	public class MissionTable : IFlatbufferObject
	{
		// Token: 0x1700115F RID: 4447
		// (get) Token: 0x060041BE RID: 16830 RVA: 0x000D69B4 File Offset: 0x000D4DB4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060041BF RID: 16831 RVA: 0x000D69C1 File Offset: 0x000D4DC1
		public static MissionTable GetRootAsMissionTable(ByteBuffer _bb)
		{
			return MissionTable.GetRootAsMissionTable(_bb, new MissionTable());
		}

		// Token: 0x060041C0 RID: 16832 RVA: 0x000D69CE File Offset: 0x000D4DCE
		public static MissionTable GetRootAsMissionTable(ByteBuffer _bb, MissionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060041C1 RID: 16833 RVA: 0x000D69EA File Offset: 0x000D4DEA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060041C2 RID: 16834 RVA: 0x000D6A04 File Offset: 0x000D4E04
		public MissionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001160 RID: 4448
		// (get) Token: 0x060041C3 RID: 16835 RVA: 0x000D6A10 File Offset: 0x000D4E10
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001161 RID: 4449
		// (get) Token: 0x060041C4 RID: 16836 RVA: 0x000D6A5C File Offset: 0x000D4E5C
		public string TaskName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041C5 RID: 16837 RVA: 0x000D6A9E File Offset: 0x000D4E9E
		public ArraySegment<byte>? GetTaskNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001162 RID: 4450
		// (get) Token: 0x060041C6 RID: 16838 RVA: 0x000D6AAC File Offset: 0x000D4EAC
		public int IntParam0
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001163 RID: 4451
		// (get) Token: 0x060041C7 RID: 16839 RVA: 0x000D6AF8 File Offset: 0x000D4EF8
		public int SortID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001164 RID: 4452
		// (get) Token: 0x060041C8 RID: 16840 RVA: 0x000D6B44 File Offset: 0x000D4F44
		public MissionTable.eTaskType TaskType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (MissionTable.eTaskType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001165 RID: 4453
		// (get) Token: 0x060041C9 RID: 16841 RVA: 0x000D6B88 File Offset: 0x000D4F88
		public MissionTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (MissionTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001166 RID: 4454
		// (get) Token: 0x060041CA RID: 16842 RVA: 0x000D6BCC File Offset: 0x000D4FCC
		public MissionTable.eCycleType CycleType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (MissionTable.eCycleType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001167 RID: 4455
		// (get) Token: 0x060041CB RID: 16843 RVA: 0x000D6C10 File Offset: 0x000D5010
		public int CycleWeight
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001168 RID: 4456
		// (get) Token: 0x060041CC RID: 16844 RVA: 0x000D6C5C File Offset: 0x000D505C
		public MissionTable.eDailyPoolType DailyPoolType
		{
			get
			{
				int num = this.__p.__offset(20);
				return (MissionTable.eDailyPoolType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001169 RID: 4457
		// (get) Token: 0x060041CD RID: 16845 RVA: 0x000D6CA0 File Offset: 0x000D50A0
		public int PoolID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700116A RID: 4458
		// (get) Token: 0x060041CE RID: 16846 RVA: 0x000D6CEC File Offset: 0x000D50EC
		public MissionTable.eTaskLevelType TaskLevelType
		{
			get
			{
				int num = this.__p.__offset(24);
				return (MissionTable.eTaskLevelType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700116B RID: 4459
		// (get) Token: 0x060041CF RID: 16847 RVA: 0x000D6D30 File Offset: 0x000D5130
		public string TaskInformationText
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041D0 RID: 16848 RVA: 0x000D6D73 File Offset: 0x000D5173
		public ArraySegment<byte>? GetTaskInformationTextBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x1700116C RID: 4460
		// (get) Token: 0x060041D1 RID: 16849 RVA: 0x000D6D84 File Offset: 0x000D5184
		public string TaskInitText
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041D2 RID: 16850 RVA: 0x000D6DC7 File Offset: 0x000D51C7
		public ArraySegment<byte>? GetTaskInitTextBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x1700116D RID: 4461
		// (get) Token: 0x060041D3 RID: 16851 RVA: 0x000D6DD8 File Offset: 0x000D51D8
		public string TaskAcceptedText
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041D4 RID: 16852 RVA: 0x000D6E1B File Offset: 0x000D521B
		public ArraySegment<byte>? GetTaskAcceptedTextBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x1700116E RID: 4462
		// (get) Token: 0x060041D5 RID: 16853 RVA: 0x000D6E2C File Offset: 0x000D522C
		public string TaskFinishText
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041D6 RID: 16854 RVA: 0x000D6E6F File Offset: 0x000D526F
		public ArraySegment<byte>? GetTaskFinishTextBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x1700116F RID: 4463
		// (get) Token: 0x060041D7 RID: 16855 RVA: 0x000D6E80 File Offset: 0x000D5280
		public int MapID
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001170 RID: 4464
		// (get) Token: 0x060041D8 RID: 16856 RVA: 0x000D6ECC File Offset: 0x000D52CC
		public int SeekingTarget
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001171 RID: 4465
		// (get) Token: 0x060041D9 RID: 16857 RVA: 0x000D6F18 File Offset: 0x000D5318
		public int BefTaskDlgID
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001172 RID: 4466
		// (get) Token: 0x060041DA RID: 16858 RVA: 0x000D6F64 File Offset: 0x000D5364
		public int InTaskDlgID
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001173 RID: 4467
		// (get) Token: 0x060041DB RID: 16859 RVA: 0x000D6FB0 File Offset: 0x000D53B0
		public int AftTaskDlgID
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001174 RID: 4468
		// (get) Token: 0x060041DC RID: 16860 RVA: 0x000D6FFC File Offset: 0x000D53FC
		public int PreTaskID
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001175 RID: 4469
		// (get) Token: 0x060041DD RID: 16861 RVA: 0x000D7048 File Offset: 0x000D5448
		public int SeverTake
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001176 RID: 4470
		// (get) Token: 0x060041DE RID: 16862 RVA: 0x000D7094 File Offset: 0x000D5494
		public int MaxPlayerLv
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001177 RID: 4471
		// (get) Token: 0x060041DF RID: 16863 RVA: 0x000D70E0 File Offset: 0x000D54E0
		public int MinPlayerLv
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001178 RID: 4472
		// (get) Token: 0x060041E0 RID: 16864 RVA: 0x000D712C File Offset: 0x000D552C
		public int JobID
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001179 RID: 4473
		// (get) Token: 0x060041E1 RID: 16865 RVA: 0x000D7178 File Offset: 0x000D5578
		public MissionTable.eTaskFinishType TaskFinishType
		{
			get
			{
				int num = this.__p.__offset(54);
				return (MissionTable.eTaskFinishType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700117A RID: 4474
		// (get) Token: 0x060041E2 RID: 16866 RVA: 0x000D71BC File Offset: 0x000D55BC
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041E3 RID: 16867 RVA: 0x000D71FF File Offset: 0x000D55FF
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x1700117B RID: 4475
		// (get) Token: 0x060041E4 RID: 16868 RVA: 0x000D7210 File Offset: 0x000D5610
		public int LinkParam
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700117C RID: 4476
		// (get) Token: 0x060041E5 RID: 16869 RVA: 0x000D725C File Offset: 0x000D565C
		public string OccuAward
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041E6 RID: 16870 RVA: 0x000D729F File Offset: 0x000D569F
		public ArraySegment<byte>? GetOccuAwardBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x1700117D RID: 4477
		// (get) Token: 0x060041E7 RID: 16871 RVA: 0x000D72B0 File Offset: 0x000D56B0
		public string Award
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041E8 RID: 16872 RVA: 0x000D72F3 File Offset: 0x000D56F3
		public ArraySegment<byte>? GetAwardBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x1700117E RID: 4478
		// (get) Token: 0x060041E9 RID: 16873 RVA: 0x000D7304 File Offset: 0x000D5704
		public int RewardAdapter
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700117F RID: 4479
		// (get) Token: 0x060041EA RID: 16874 RVA: 0x000D7350 File Offset: 0x000D5750
		public int AfterID
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001180 RID: 4480
		// (get) Token: 0x060041EB RID: 16875 RVA: 0x000D739C File Offset: 0x000D579C
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041EC RID: 16876 RVA: 0x000D73DF File Offset: 0x000D57DF
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x17001181 RID: 4481
		// (get) Token: 0x060041ED RID: 16877 RVA: 0x000D73F0 File Offset: 0x000D57F0
		public MissionTable.eAcceptType AcceptType
		{
			get
			{
				int num = this.__p.__offset(70);
				return (MissionTable.eAcceptType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001182 RID: 4482
		// (get) Token: 0x060041EE RID: 16878 RVA: 0x000D7434 File Offset: 0x000D5834
		public MissionTable.eFinishType FinishType
		{
			get
			{
				int num = this.__p.__offset(72);
				return (MissionTable.eFinishType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001183 RID: 4483
		// (get) Token: 0x060041EF RID: 16879 RVA: 0x000D7478 File Offset: 0x000D5878
		public int MissionTakeNpc
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001184 RID: 4484
		// (get) Token: 0x060041F0 RID: 16880 RVA: 0x000D74C4 File Offset: 0x000D58C4
		public int MissionFinishNpc
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001185 RID: 4485
		// (get) Token: 0x060041F1 RID: 16881 RVA: 0x000D7510 File Offset: 0x000D5910
		public string MissionNpcIcon
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041F2 RID: 16882 RVA: 0x000D7553 File Offset: 0x000D5953
		public ArraySegment<byte>? GetMissionNpcIconBytes()
		{
			return this.__p.__vector_as_arraysegment(78);
		}

		// Token: 0x17001186 RID: 4486
		// (get) Token: 0x060041F3 RID: 16883 RVA: 0x000D7564 File Offset: 0x000D5964
		public int IsAnnouncement
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001187 RID: 4487
		// (get) Token: 0x060041F4 RID: 16884 RVA: 0x000D75B0 File Offset: 0x000D59B0
		public int MaxSubmitCount
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001188 RID: 4488
		// (get) Token: 0x060041F5 RID: 16885 RVA: 0x000D75FC File Offset: 0x000D59FC
		public int VitalityValue
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001189 RID: 4489
		// (get) Token: 0x060041F6 RID: 16886 RVA: 0x000D7648 File Offset: 0x000D5A48
		public string MissionParam
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041F7 RID: 16887 RVA: 0x000D768B File Offset: 0x000D5A8B
		public ArraySegment<byte>? GetMissionParamBytes()
		{
			return this.__p.__vector_as_arraysegment(86);
		}

		// Token: 0x1700118A RID: 4490
		// (get) Token: 0x060041F8 RID: 16888 RVA: 0x000D769C File Offset: 0x000D5A9C
		public int TemplateId
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700118B RID: 4491
		// (get) Token: 0x060041F9 RID: 16889 RVA: 0x000D76E8 File Offset: 0x000D5AE8
		public string ScriptParam
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060041FA RID: 16890 RVA: 0x000D772B File Offset: 0x000D5B2B
		public ArraySegment<byte>? GetScriptParamBytes()
		{
			return this.__p.__vector_as_arraysegment(90);
		}

		// Token: 0x1700118C RID: 4492
		// (get) Token: 0x060041FB RID: 16891 RVA: 0x000D773C File Offset: 0x000D5B3C
		public int MissionOnOff
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060041FC RID: 16892 RVA: 0x000D7788 File Offset: 0x000D5B88
		public int MonsterIDsArray(int j)
		{
			int num = this.__p.__offset(94);
			return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700118D RID: 4493
		// (get) Token: 0x060041FD RID: 16893 RVA: 0x000D77D8 File Offset: 0x000D5BD8
		public int MonsterIDsLength
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060041FE RID: 16894 RVA: 0x000D780B File Offset: 0x000D5C0B
		public ArraySegment<byte>? GetMonsterIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(94);
		}

		// Token: 0x1700118E RID: 4494
		// (get) Token: 0x060041FF RID: 16895 RVA: 0x000D781A File Offset: 0x000D5C1A
		public FlatBufferArray<int> MonsterIDs
		{
			get
			{
				if (this.MonsterIDsValue == null)
				{
					this.MonsterIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.MonsterIDsArray), this.MonsterIDsLength);
				}
				return this.MonsterIDsValue;
			}
		}

		// Token: 0x06004200 RID: 16896 RVA: 0x000D784C File Offset: 0x000D5C4C
		public string MissionMaterialsArray(int j)
		{
			int num = this.__p.__offset(96);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700118F RID: 4495
		// (get) Token: 0x06004201 RID: 16897 RVA: 0x000D7894 File Offset: 0x000D5C94
		public int MissionMaterialsLength
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001190 RID: 4496
		// (get) Token: 0x06004202 RID: 16898 RVA: 0x000D78C7 File Offset: 0x000D5CC7
		public FlatBufferArray<string> MissionMaterials
		{
			get
			{
				if (this.MissionMaterialsValue == null)
				{
					this.MissionMaterialsValue = new FlatBufferArray<string>(new Func<int, string>(this.MissionMaterialsArray), this.MissionMaterialsLength);
				}
				return this.MissionMaterialsValue;
			}
		}

		// Token: 0x06004203 RID: 16899 RVA: 0x000D78F8 File Offset: 0x000D5CF8
		public string MissionMaterialsKeyValueArray(int j)
		{
			int num = this.__p.__offset(98);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001191 RID: 4497
		// (get) Token: 0x06004204 RID: 16900 RVA: 0x000D7940 File Offset: 0x000D5D40
		public int MissionMaterialsKeyValueLength
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001192 RID: 4498
		// (get) Token: 0x06004205 RID: 16901 RVA: 0x000D7973 File Offset: 0x000D5D73
		public FlatBufferArray<string> MissionMaterialsKeyValue
		{
			get
			{
				if (this.MissionMaterialsKeyValueValue == null)
				{
					this.MissionMaterialsKeyValueValue = new FlatBufferArray<string>(new Func<int, string>(this.MissionMaterialsKeyValueArray), this.MissionMaterialsKeyValueLength);
				}
				return this.MissionMaterialsKeyValueValue;
			}
		}

		// Token: 0x06004206 RID: 16902 RVA: 0x000D79A4 File Offset: 0x000D5DA4
		public int PreIDsArray(int j)
		{
			int num = this.__p.__offset(100);
			return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001193 RID: 4499
		// (get) Token: 0x06004207 RID: 16903 RVA: 0x000D79F4 File Offset: 0x000D5DF4
		public int PreIDsLength
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004208 RID: 16904 RVA: 0x000D7A27 File Offset: 0x000D5E27
		public ArraySegment<byte>? GetPreIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(100);
		}

		// Token: 0x17001194 RID: 4500
		// (get) Token: 0x06004209 RID: 16905 RVA: 0x000D7A36 File Offset: 0x000D5E36
		public FlatBufferArray<int> PreIDs
		{
			get
			{
				if (this.PreIDsValue == null)
				{
					this.PreIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.PreIDsArray), this.PreIDsLength);
				}
				return this.PreIDsValue;
			}
		}

		// Token: 0x17001195 RID: 4501
		// (get) Token: 0x0600420A RID: 16906 RVA: 0x000D7A68 File Offset: 0x000D5E68
		public string PreIDsConditionDesc
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600420B RID: 16907 RVA: 0x000D7AAB File Offset: 0x000D5EAB
		public ArraySegment<byte>? GetPreIDsConditionDescBytes()
		{
			return this.__p.__vector_as_arraysegment(102);
		}

		// Token: 0x17001196 RID: 4502
		// (get) Token: 0x0600420C RID: 16908 RVA: 0x000D7ABC File Offset: 0x000D5EBC
		public bool IsNeedBuriedPoint
		{
			get
			{
				int num = this.__p.__offset(104);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17001197 RID: 4503
		// (get) Token: 0x0600420D RID: 16909 RVA: 0x000D7B08 File Offset: 0x000D5F08
		public int DungeonTableID
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001198 RID: 4504
		// (get) Token: 0x0600420E RID: 16910 RVA: 0x000D7B54 File Offset: 0x000D5F54
		public int FinishRightNowLevel
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001199 RID: 4505
		// (get) Token: 0x0600420F RID: 16911 RVA: 0x000D7BA0 File Offset: 0x000D5FA0
		public int FinishRightNowItemType
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700119A RID: 4506
		// (get) Token: 0x06004210 RID: 16912 RVA: 0x000D7BEC File Offset: 0x000D5FEC
		public int FinishRightNowItemNum
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : (-1977692534 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004211 RID: 16913 RVA: 0x000D7C38 File Offset: 0x000D6038
		public static Offset<MissionTable> CreateMissionTable(FlatBufferBuilder builder, int ID = 0, StringOffset TaskNameOffset = default(StringOffset), int IntParam0 = 0, int SortID = 0, MissionTable.eTaskType TaskType = MissionTable.eTaskType.TT_DIALY, MissionTable.eSubType SubType = MissionTable.eSubType.Daily_Null, MissionTable.eCycleType CycleType = MissionTable.eCycleType.CYCLE_INVALID, int CycleWeight = 0, MissionTable.eDailyPoolType DailyPoolType = MissionTable.eDailyPoolType.DAILY_INVALID, int PoolID = 0, MissionTable.eTaskLevelType TaskLevelType = MissionTable.eTaskLevelType.NPC_NONE, StringOffset TaskInformationTextOffset = default(StringOffset), StringOffset TaskInitTextOffset = default(StringOffset), StringOffset TaskAcceptedTextOffset = default(StringOffset), StringOffset TaskFinishTextOffset = default(StringOffset), int MapID = 0, int SeekingTarget = 0, int BefTaskDlgID = 0, int InTaskDlgID = 0, int AftTaskDlgID = 0, int PreTaskID = 0, int SeverTake = 0, int MaxPlayerLv = 0, int MinPlayerLv = 0, int JobID = 0, MissionTable.eTaskFinishType TaskFinishType = MissionTable.eTaskFinishType.TFT_KILL, StringOffset LinkInfoOffset = default(StringOffset), int LinkParam = 0, StringOffset OccuAwardOffset = default(StringOffset), StringOffset AwardOffset = default(StringOffset), int RewardAdapter = 0, int AfterID = 0, StringOffset IconOffset = default(StringOffset), MissionTable.eAcceptType AcceptType = MissionTable.eAcceptType.ACT_AUTO, MissionTable.eFinishType FinishType = MissionTable.eFinishType.FINISH_TYPE_AUTO, int MissionTakeNpc = 0, int MissionFinishNpc = 0, StringOffset MissionNpcIconOffset = default(StringOffset), int IsAnnouncement = 0, int MaxSubmitCount = 0, int VitalityValue = 0, StringOffset MissionParamOffset = default(StringOffset), int TemplateId = 0, StringOffset ScriptParamOffset = default(StringOffset), int MissionOnOff = 0, VectorOffset MonsterIDsOffset = default(VectorOffset), VectorOffset MissionMaterialsOffset = default(VectorOffset), VectorOffset MissionMaterialsKeyValueOffset = default(VectorOffset), VectorOffset PreIDsOffset = default(VectorOffset), StringOffset PreIDsConditionDescOffset = default(StringOffset), bool IsNeedBuriedPoint = false, int DungeonTableID = 0, int FinishRightNowLevel = 0, int FinishRightNowItemType = 0, int FinishRightNowItemNum = 0)
		{
			builder.StartObject(55);
			MissionTable.AddFinishRightNowItemNum(builder, FinishRightNowItemNum);
			MissionTable.AddFinishRightNowItemType(builder, FinishRightNowItemType);
			MissionTable.AddFinishRightNowLevel(builder, FinishRightNowLevel);
			MissionTable.AddDungeonTableID(builder, DungeonTableID);
			MissionTable.AddPreIDsConditionDesc(builder, PreIDsConditionDescOffset);
			MissionTable.AddPreIDs(builder, PreIDsOffset);
			MissionTable.AddMissionMaterialsKeyValue(builder, MissionMaterialsKeyValueOffset);
			MissionTable.AddMissionMaterials(builder, MissionMaterialsOffset);
			MissionTable.AddMonsterIDs(builder, MonsterIDsOffset);
			MissionTable.AddMissionOnOff(builder, MissionOnOff);
			MissionTable.AddScriptParam(builder, ScriptParamOffset);
			MissionTable.AddTemplateId(builder, TemplateId);
			MissionTable.AddMissionParam(builder, MissionParamOffset);
			MissionTable.AddVitalityValue(builder, VitalityValue);
			MissionTable.AddMaxSubmitCount(builder, MaxSubmitCount);
			MissionTable.AddIsAnnouncement(builder, IsAnnouncement);
			MissionTable.AddMissionNpcIcon(builder, MissionNpcIconOffset);
			MissionTable.AddMissionFinishNpc(builder, MissionFinishNpc);
			MissionTable.AddMissionTakeNpc(builder, MissionTakeNpc);
			MissionTable.AddFinishType(builder, FinishType);
			MissionTable.AddAcceptType(builder, AcceptType);
			MissionTable.AddIcon(builder, IconOffset);
			MissionTable.AddAfterID(builder, AfterID);
			MissionTable.AddRewardAdapter(builder, RewardAdapter);
			MissionTable.AddAward(builder, AwardOffset);
			MissionTable.AddOccuAward(builder, OccuAwardOffset);
			MissionTable.AddLinkParam(builder, LinkParam);
			MissionTable.AddLinkInfo(builder, LinkInfoOffset);
			MissionTable.AddTaskFinishType(builder, TaskFinishType);
			MissionTable.AddJobID(builder, JobID);
			MissionTable.AddMinPlayerLv(builder, MinPlayerLv);
			MissionTable.AddMaxPlayerLv(builder, MaxPlayerLv);
			MissionTable.AddSeverTake(builder, SeverTake);
			MissionTable.AddPreTaskID(builder, PreTaskID);
			MissionTable.AddAftTaskDlgID(builder, AftTaskDlgID);
			MissionTable.AddInTaskDlgID(builder, InTaskDlgID);
			MissionTable.AddBefTaskDlgID(builder, BefTaskDlgID);
			MissionTable.AddSeekingTarget(builder, SeekingTarget);
			MissionTable.AddMapID(builder, MapID);
			MissionTable.AddTaskFinishText(builder, TaskFinishTextOffset);
			MissionTable.AddTaskAcceptedText(builder, TaskAcceptedTextOffset);
			MissionTable.AddTaskInitText(builder, TaskInitTextOffset);
			MissionTable.AddTaskInformationText(builder, TaskInformationTextOffset);
			MissionTable.AddTaskLevelType(builder, TaskLevelType);
			MissionTable.AddPoolID(builder, PoolID);
			MissionTable.AddDailyPoolType(builder, DailyPoolType);
			MissionTable.AddCycleWeight(builder, CycleWeight);
			MissionTable.AddCycleType(builder, CycleType);
			MissionTable.AddSubType(builder, SubType);
			MissionTable.AddTaskType(builder, TaskType);
			MissionTable.AddSortID(builder, SortID);
			MissionTable.AddIntParam0(builder, IntParam0);
			MissionTable.AddTaskName(builder, TaskNameOffset);
			MissionTable.AddID(builder, ID);
			MissionTable.AddIsNeedBuriedPoint(builder, IsNeedBuriedPoint);
			return MissionTable.EndMissionTable(builder);
		}

		// Token: 0x06004212 RID: 16914 RVA: 0x000D7E08 File Offset: 0x000D6208
		public static void StartMissionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(55);
		}

		// Token: 0x06004213 RID: 16915 RVA: 0x000D7E12 File Offset: 0x000D6212
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004214 RID: 16916 RVA: 0x000D7E1D File Offset: 0x000D621D
		public static void AddTaskName(FlatBufferBuilder builder, StringOffset TaskNameOffset)
		{
			builder.AddOffset(1, TaskNameOffset.Value, 0);
		}

		// Token: 0x06004215 RID: 16917 RVA: 0x000D7E2E File Offset: 0x000D622E
		public static void AddIntParam0(FlatBufferBuilder builder, int IntParam0)
		{
			builder.AddInt(2, IntParam0, 0);
		}

		// Token: 0x06004216 RID: 16918 RVA: 0x000D7E39 File Offset: 0x000D6239
		public static void AddSortID(FlatBufferBuilder builder, int SortID)
		{
			builder.AddInt(3, SortID, 0);
		}

		// Token: 0x06004217 RID: 16919 RVA: 0x000D7E44 File Offset: 0x000D6244
		public static void AddTaskType(FlatBufferBuilder builder, MissionTable.eTaskType TaskType)
		{
			builder.AddInt(4, (int)TaskType, 0);
		}

		// Token: 0x06004218 RID: 16920 RVA: 0x000D7E4F File Offset: 0x000D624F
		public static void AddSubType(FlatBufferBuilder builder, MissionTable.eSubType SubType)
		{
			builder.AddInt(5, (int)SubType, 0);
		}

		// Token: 0x06004219 RID: 16921 RVA: 0x000D7E5A File Offset: 0x000D625A
		public static void AddCycleType(FlatBufferBuilder builder, MissionTable.eCycleType CycleType)
		{
			builder.AddInt(6, (int)CycleType, 0);
		}

		// Token: 0x0600421A RID: 16922 RVA: 0x000D7E65 File Offset: 0x000D6265
		public static void AddCycleWeight(FlatBufferBuilder builder, int CycleWeight)
		{
			builder.AddInt(7, CycleWeight, 0);
		}

		// Token: 0x0600421B RID: 16923 RVA: 0x000D7E70 File Offset: 0x000D6270
		public static void AddDailyPoolType(FlatBufferBuilder builder, MissionTable.eDailyPoolType DailyPoolType)
		{
			builder.AddInt(8, (int)DailyPoolType, 0);
		}

		// Token: 0x0600421C RID: 16924 RVA: 0x000D7E7B File Offset: 0x000D627B
		public static void AddPoolID(FlatBufferBuilder builder, int PoolID)
		{
			builder.AddInt(9, PoolID, 0);
		}

		// Token: 0x0600421D RID: 16925 RVA: 0x000D7E87 File Offset: 0x000D6287
		public static void AddTaskLevelType(FlatBufferBuilder builder, MissionTable.eTaskLevelType TaskLevelType)
		{
			builder.AddInt(10, (int)TaskLevelType, 0);
		}

		// Token: 0x0600421E RID: 16926 RVA: 0x000D7E93 File Offset: 0x000D6293
		public static void AddTaskInformationText(FlatBufferBuilder builder, StringOffset TaskInformationTextOffset)
		{
			builder.AddOffset(11, TaskInformationTextOffset.Value, 0);
		}

		// Token: 0x0600421F RID: 16927 RVA: 0x000D7EA5 File Offset: 0x000D62A5
		public static void AddTaskInitText(FlatBufferBuilder builder, StringOffset TaskInitTextOffset)
		{
			builder.AddOffset(12, TaskInitTextOffset.Value, 0);
		}

		// Token: 0x06004220 RID: 16928 RVA: 0x000D7EB7 File Offset: 0x000D62B7
		public static void AddTaskAcceptedText(FlatBufferBuilder builder, StringOffset TaskAcceptedTextOffset)
		{
			builder.AddOffset(13, TaskAcceptedTextOffset.Value, 0);
		}

		// Token: 0x06004221 RID: 16929 RVA: 0x000D7EC9 File Offset: 0x000D62C9
		public static void AddTaskFinishText(FlatBufferBuilder builder, StringOffset TaskFinishTextOffset)
		{
			builder.AddOffset(14, TaskFinishTextOffset.Value, 0);
		}

		// Token: 0x06004222 RID: 16930 RVA: 0x000D7EDB File Offset: 0x000D62DB
		public static void AddMapID(FlatBufferBuilder builder, int MapID)
		{
			builder.AddInt(15, MapID, 0);
		}

		// Token: 0x06004223 RID: 16931 RVA: 0x000D7EE7 File Offset: 0x000D62E7
		public static void AddSeekingTarget(FlatBufferBuilder builder, int SeekingTarget)
		{
			builder.AddInt(16, SeekingTarget, 0);
		}

		// Token: 0x06004224 RID: 16932 RVA: 0x000D7EF3 File Offset: 0x000D62F3
		public static void AddBefTaskDlgID(FlatBufferBuilder builder, int BefTaskDlgID)
		{
			builder.AddInt(17, BefTaskDlgID, 0);
		}

		// Token: 0x06004225 RID: 16933 RVA: 0x000D7EFF File Offset: 0x000D62FF
		public static void AddInTaskDlgID(FlatBufferBuilder builder, int InTaskDlgID)
		{
			builder.AddInt(18, InTaskDlgID, 0);
		}

		// Token: 0x06004226 RID: 16934 RVA: 0x000D7F0B File Offset: 0x000D630B
		public static void AddAftTaskDlgID(FlatBufferBuilder builder, int AftTaskDlgID)
		{
			builder.AddInt(19, AftTaskDlgID, 0);
		}

		// Token: 0x06004227 RID: 16935 RVA: 0x000D7F17 File Offset: 0x000D6317
		public static void AddPreTaskID(FlatBufferBuilder builder, int PreTaskID)
		{
			builder.AddInt(20, PreTaskID, 0);
		}

		// Token: 0x06004228 RID: 16936 RVA: 0x000D7F23 File Offset: 0x000D6323
		public static void AddSeverTake(FlatBufferBuilder builder, int SeverTake)
		{
			builder.AddInt(21, SeverTake, 0);
		}

		// Token: 0x06004229 RID: 16937 RVA: 0x000D7F2F File Offset: 0x000D632F
		public static void AddMaxPlayerLv(FlatBufferBuilder builder, int MaxPlayerLv)
		{
			builder.AddInt(22, MaxPlayerLv, 0);
		}

		// Token: 0x0600422A RID: 16938 RVA: 0x000D7F3B File Offset: 0x000D633B
		public static void AddMinPlayerLv(FlatBufferBuilder builder, int MinPlayerLv)
		{
			builder.AddInt(23, MinPlayerLv, 0);
		}

		// Token: 0x0600422B RID: 16939 RVA: 0x000D7F47 File Offset: 0x000D6347
		public static void AddJobID(FlatBufferBuilder builder, int JobID)
		{
			builder.AddInt(24, JobID, 0);
		}

		// Token: 0x0600422C RID: 16940 RVA: 0x000D7F53 File Offset: 0x000D6353
		public static void AddTaskFinishType(FlatBufferBuilder builder, MissionTable.eTaskFinishType TaskFinishType)
		{
			builder.AddInt(25, (int)TaskFinishType, 0);
		}

		// Token: 0x0600422D RID: 16941 RVA: 0x000D7F5F File Offset: 0x000D635F
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(26, LinkInfoOffset.Value, 0);
		}

		// Token: 0x0600422E RID: 16942 RVA: 0x000D7F71 File Offset: 0x000D6371
		public static void AddLinkParam(FlatBufferBuilder builder, int LinkParam)
		{
			builder.AddInt(27, LinkParam, 0);
		}

		// Token: 0x0600422F RID: 16943 RVA: 0x000D7F7D File Offset: 0x000D637D
		public static void AddOccuAward(FlatBufferBuilder builder, StringOffset OccuAwardOffset)
		{
			builder.AddOffset(28, OccuAwardOffset.Value, 0);
		}

		// Token: 0x06004230 RID: 16944 RVA: 0x000D7F8F File Offset: 0x000D638F
		public static void AddAward(FlatBufferBuilder builder, StringOffset AwardOffset)
		{
			builder.AddOffset(29, AwardOffset.Value, 0);
		}

		// Token: 0x06004231 RID: 16945 RVA: 0x000D7FA1 File Offset: 0x000D63A1
		public static void AddRewardAdapter(FlatBufferBuilder builder, int RewardAdapter)
		{
			builder.AddInt(30, RewardAdapter, 0);
		}

		// Token: 0x06004232 RID: 16946 RVA: 0x000D7FAD File Offset: 0x000D63AD
		public static void AddAfterID(FlatBufferBuilder builder, int AfterID)
		{
			builder.AddInt(31, AfterID, 0);
		}

		// Token: 0x06004233 RID: 16947 RVA: 0x000D7FB9 File Offset: 0x000D63B9
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(32, IconOffset.Value, 0);
		}

		// Token: 0x06004234 RID: 16948 RVA: 0x000D7FCB File Offset: 0x000D63CB
		public static void AddAcceptType(FlatBufferBuilder builder, MissionTable.eAcceptType AcceptType)
		{
			builder.AddInt(33, (int)AcceptType, 0);
		}

		// Token: 0x06004235 RID: 16949 RVA: 0x000D7FD7 File Offset: 0x000D63D7
		public static void AddFinishType(FlatBufferBuilder builder, MissionTable.eFinishType FinishType)
		{
			builder.AddInt(34, (int)FinishType, 0);
		}

		// Token: 0x06004236 RID: 16950 RVA: 0x000D7FE3 File Offset: 0x000D63E3
		public static void AddMissionTakeNpc(FlatBufferBuilder builder, int MissionTakeNpc)
		{
			builder.AddInt(35, MissionTakeNpc, 0);
		}

		// Token: 0x06004237 RID: 16951 RVA: 0x000D7FEF File Offset: 0x000D63EF
		public static void AddMissionFinishNpc(FlatBufferBuilder builder, int MissionFinishNpc)
		{
			builder.AddInt(36, MissionFinishNpc, 0);
		}

		// Token: 0x06004238 RID: 16952 RVA: 0x000D7FFB File Offset: 0x000D63FB
		public static void AddMissionNpcIcon(FlatBufferBuilder builder, StringOffset MissionNpcIconOffset)
		{
			builder.AddOffset(37, MissionNpcIconOffset.Value, 0);
		}

		// Token: 0x06004239 RID: 16953 RVA: 0x000D800D File Offset: 0x000D640D
		public static void AddIsAnnouncement(FlatBufferBuilder builder, int IsAnnouncement)
		{
			builder.AddInt(38, IsAnnouncement, 0);
		}

		// Token: 0x0600423A RID: 16954 RVA: 0x000D8019 File Offset: 0x000D6419
		public static void AddMaxSubmitCount(FlatBufferBuilder builder, int MaxSubmitCount)
		{
			builder.AddInt(39, MaxSubmitCount, 0);
		}

		// Token: 0x0600423B RID: 16955 RVA: 0x000D8025 File Offset: 0x000D6425
		public static void AddVitalityValue(FlatBufferBuilder builder, int VitalityValue)
		{
			builder.AddInt(40, VitalityValue, 0);
		}

		// Token: 0x0600423C RID: 16956 RVA: 0x000D8031 File Offset: 0x000D6431
		public static void AddMissionParam(FlatBufferBuilder builder, StringOffset MissionParamOffset)
		{
			builder.AddOffset(41, MissionParamOffset.Value, 0);
		}

		// Token: 0x0600423D RID: 16957 RVA: 0x000D8043 File Offset: 0x000D6443
		public static void AddTemplateId(FlatBufferBuilder builder, int TemplateId)
		{
			builder.AddInt(42, TemplateId, 0);
		}

		// Token: 0x0600423E RID: 16958 RVA: 0x000D804F File Offset: 0x000D644F
		public static void AddScriptParam(FlatBufferBuilder builder, StringOffset ScriptParamOffset)
		{
			builder.AddOffset(43, ScriptParamOffset.Value, 0);
		}

		// Token: 0x0600423F RID: 16959 RVA: 0x000D8061 File Offset: 0x000D6461
		public static void AddMissionOnOff(FlatBufferBuilder builder, int MissionOnOff)
		{
			builder.AddInt(44, MissionOnOff, 0);
		}

		// Token: 0x06004240 RID: 16960 RVA: 0x000D806D File Offset: 0x000D646D
		public static void AddMonsterIDs(FlatBufferBuilder builder, VectorOffset MonsterIDsOffset)
		{
			builder.AddOffset(45, MonsterIDsOffset.Value, 0);
		}

		// Token: 0x06004241 RID: 16961 RVA: 0x000D8080 File Offset: 0x000D6480
		public static VectorOffset CreateMonsterIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004242 RID: 16962 RVA: 0x000D80BD File Offset: 0x000D64BD
		public static void StartMonsterIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004243 RID: 16963 RVA: 0x000D80C8 File Offset: 0x000D64C8
		public static void AddMissionMaterials(FlatBufferBuilder builder, VectorOffset MissionMaterialsOffset)
		{
			builder.AddOffset(46, MissionMaterialsOffset.Value, 0);
		}

		// Token: 0x06004244 RID: 16964 RVA: 0x000D80DC File Offset: 0x000D64DC
		public static VectorOffset CreateMissionMaterialsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004245 RID: 16965 RVA: 0x000D8122 File Offset: 0x000D6522
		public static void StartMissionMaterialsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004246 RID: 16966 RVA: 0x000D812D File Offset: 0x000D652D
		public static void AddMissionMaterialsKeyValue(FlatBufferBuilder builder, VectorOffset MissionMaterialsKeyValueOffset)
		{
			builder.AddOffset(47, MissionMaterialsKeyValueOffset.Value, 0);
		}

		// Token: 0x06004247 RID: 16967 RVA: 0x000D8140 File Offset: 0x000D6540
		public static VectorOffset CreateMissionMaterialsKeyValueVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004248 RID: 16968 RVA: 0x000D8186 File Offset: 0x000D6586
		public static void StartMissionMaterialsKeyValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004249 RID: 16969 RVA: 0x000D8191 File Offset: 0x000D6591
		public static void AddPreIDs(FlatBufferBuilder builder, VectorOffset PreIDsOffset)
		{
			builder.AddOffset(48, PreIDsOffset.Value, 0);
		}

		// Token: 0x0600424A RID: 16970 RVA: 0x000D81A4 File Offset: 0x000D65A4
		public static VectorOffset CreatePreIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600424B RID: 16971 RVA: 0x000D81E1 File Offset: 0x000D65E1
		public static void StartPreIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600424C RID: 16972 RVA: 0x000D81EC File Offset: 0x000D65EC
		public static void AddPreIDsConditionDesc(FlatBufferBuilder builder, StringOffset PreIDsConditionDescOffset)
		{
			builder.AddOffset(49, PreIDsConditionDescOffset.Value, 0);
		}

		// Token: 0x0600424D RID: 16973 RVA: 0x000D81FE File Offset: 0x000D65FE
		public static void AddIsNeedBuriedPoint(FlatBufferBuilder builder, bool IsNeedBuriedPoint)
		{
			builder.AddBool(50, IsNeedBuriedPoint, false);
		}

		// Token: 0x0600424E RID: 16974 RVA: 0x000D820A File Offset: 0x000D660A
		public static void AddDungeonTableID(FlatBufferBuilder builder, int DungeonTableID)
		{
			builder.AddInt(51, DungeonTableID, 0);
		}

		// Token: 0x0600424F RID: 16975 RVA: 0x000D8216 File Offset: 0x000D6616
		public static void AddFinishRightNowLevel(FlatBufferBuilder builder, int FinishRightNowLevel)
		{
			builder.AddInt(52, FinishRightNowLevel, 0);
		}

		// Token: 0x06004250 RID: 16976 RVA: 0x000D8222 File Offset: 0x000D6622
		public static void AddFinishRightNowItemType(FlatBufferBuilder builder, int FinishRightNowItemType)
		{
			builder.AddInt(53, FinishRightNowItemType, 0);
		}

		// Token: 0x06004251 RID: 16977 RVA: 0x000D822E File Offset: 0x000D662E
		public static void AddFinishRightNowItemNum(FlatBufferBuilder builder, int FinishRightNowItemNum)
		{
			builder.AddInt(54, FinishRightNowItemNum, 0);
		}

		// Token: 0x06004252 RID: 16978 RVA: 0x000D823C File Offset: 0x000D663C
		public static Offset<MissionTable> EndMissionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MissionTable>(value);
		}

		// Token: 0x06004253 RID: 16979 RVA: 0x000D8256 File Offset: 0x000D6656
		public static void FinishMissionTableBuffer(FlatBufferBuilder builder, Offset<MissionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001880 RID: 6272
		private Table __p = new Table();

		// Token: 0x04001881 RID: 6273
		private FlatBufferArray<int> MonsterIDsValue;

		// Token: 0x04001882 RID: 6274
		private FlatBufferArray<string> MissionMaterialsValue;

		// Token: 0x04001883 RID: 6275
		private FlatBufferArray<string> MissionMaterialsKeyValueValue;

		// Token: 0x04001884 RID: 6276
		private FlatBufferArray<int> PreIDsValue;

		// Token: 0x02000503 RID: 1283
		public enum eTaskType
		{
			// Token: 0x04001886 RID: 6278
			TT_DIALY,
			// Token: 0x04001887 RID: 6279
			TT_MAIN,
			// Token: 0x04001888 RID: 6280
			TT_BRANCH,
			// Token: 0x04001889 RID: 6281
			TT_ACHIEVEMENT,
			// Token: 0x0400188A RID: 6282
			TT_SYSTEM,
			// Token: 0x0400188B RID: 6283
			TT_ACTIVITY,
			// Token: 0x0400188C RID: 6284
			TT_EXTENTION,
			// Token: 0x0400188D RID: 6285
			TT_CHANGEJOB,
			// Token: 0x0400188E RID: 6286
			TT_AWAKEN,
			// Token: 0x0400188F RID: 6287
			TT_CYCLE,
			// Token: 0x04001890 RID: 6288
			TT_RED_PACKET,
			// Token: 0x04001891 RID: 6289
			TT_TITLE,
			// Token: 0x04001892 RID: 6290
			TT_LEGEND,
			// Token: 0x04001893 RID: 6291
			TASK_MASTER_DAILY,
			// Token: 0x04001894 RID: 6292
			TASK_MASTER_ACADEMIC,
			// Token: 0x04001895 RID: 6293
			TASK_ACCOUNT_ACHIEVEMENT,
			// Token: 0x04001896 RID: 6294
			TASK_ADVENTURE_TEAM_ACCOUNT_WEEKLY
		}

		// Token: 0x02000504 RID: 1284
		public enum eSubType
		{
			// Token: 0x04001898 RID: 6296
			Daily_Null,
			// Token: 0x04001899 RID: 6297
			Daily_Task,
			// Token: 0x0400189A RID: 6298
			Daily_Prove,
			// Token: 0x0400189B RID: 6299
			Dungeon_Mission,
			// Token: 0x0400189C RID: 6300
			Dungeon_Chest,
			// Token: 0x0400189D RID: 6301
			Chapter_Change,
			// Token: 0x0400189E RID: 6302
			SummerNpc = 7,
			// Token: 0x0400189F RID: 6303
			TST_COND_ROLE_NUM_CHANGE = 10,
			// Token: 0x040018A0 RID: 6304
			NewbieGuide_Mission = 100,
			// Token: 0x040018A1 RID: 6305
			Legend_PoKongShi = 1200,
			// Token: 0x040018A2 RID: 6306
			Legend_BuMieZhiWang,
			// Token: 0x040018A3 RID: 6307
			Legend_HeiAnZhiAiShang,
			// Token: 0x040018A4 RID: 6308
			Legend_RongYaoShiShi,
			// Token: 0x040018A5 RID: 6309
			Legend_ZhanGuoFengYun,
			// Token: 0x040018A6 RID: 6310
			Legend_MoHunZhiYun,
			// Token: 0x040018A7 RID: 6311
			Legend_QunFengDaoFenZheng
		}

		// Token: 0x02000505 RID: 1285
		public enum eCycleType
		{
			// Token: 0x040018A9 RID: 6313
			CYCLE_INVALID,
			// Token: 0x040018AA RID: 6314
			CYCLE_DUNGEON,
			// Token: 0x040018AB RID: 6315
			CYCLE_SET_ITEM,
			// Token: 0x040018AC RID: 6316
			CYCLE_STORY
		}

		// Token: 0x02000506 RID: 1286
		public enum eDailyPoolType
		{
			// Token: 0x040018AE RID: 6318
			DAILY_INVALID,
			// Token: 0x040018AF RID: 6319
			DAILY_SURE,
			// Token: 0x040018B0 RID: 6320
			DAILY_DUNGEON,
			// Token: 0x040018B1 RID: 6321
			DAILY_FUNCTION,
			// Token: 0x040018B2 RID: 6322
			DAILY_ACTIVITY
		}

		// Token: 0x02000507 RID: 1287
		public enum eTaskLevelType
		{
			// Token: 0x040018B4 RID: 6324
			NPC_NONE,
			// Token: 0x040018B5 RID: 6325
			NPC_PROTECT,
			// Token: 0x040018B6 RID: 6326
			NPC_FIND
		}

		// Token: 0x02000508 RID: 1288
		public enum eTaskFinishType
		{
			// Token: 0x040018B8 RID: 6328
			TFT_KILL,
			// Token: 0x040018B9 RID: 6329
			TFT_PASS,
			// Token: 0x040018BA RID: 6330
			TFT_COLLECT,
			// Token: 0x040018BB RID: 6331
			TFT_TALK,
			// Token: 0x040018BC RID: 6332
			TFT_KILL_BY_TYPE,
			// Token: 0x040018BD RID: 6333
			TFT_FINISHMISSION_TYPE,
			// Token: 0x040018BE RID: 6334
			TFT_ACCESS_SHOP,
			// Token: 0x040018BF RID: 6335
			TFT_SUBMIT_ITEM,
			// Token: 0x040018C0 RID: 6336
			TFT_LINKS
		}

		// Token: 0x02000509 RID: 1289
		public enum eAcceptType
		{
			// Token: 0x040018C2 RID: 6338
			ACT_AUTO,
			// Token: 0x040018C3 RID: 6339
			ACT_NPC,
			// Token: 0x040018C4 RID: 6340
			ACT_UI
		}

		// Token: 0x0200050A RID: 1290
		public enum eFinishType
		{
			// Token: 0x040018C6 RID: 6342
			FINISH_TYPE_AUTO,
			// Token: 0x040018C7 RID: 6343
			FINISH_TYPE_NPC,
			// Token: 0x040018C8 RID: 6344
			FINISH_TYPE_UI
		}

		// Token: 0x0200050B RID: 1291
		public enum eCrypt
		{
			// Token: 0x040018CA RID: 6346
			code = -1977692534
		}
	}
}
