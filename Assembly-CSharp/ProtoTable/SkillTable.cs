using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005C5 RID: 1477
	public class SkillTable : IFlatbufferObject
	{
		// Token: 0x17001528 RID: 5416
		// (get) Token: 0x06004D63 RID: 19811 RVA: 0x000F1360 File Offset: 0x000EF760
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004D64 RID: 19812 RVA: 0x000F136D File Offset: 0x000EF76D
		public static SkillTable GetRootAsSkillTable(ByteBuffer _bb)
		{
			return SkillTable.GetRootAsSkillTable(_bb, new SkillTable());
		}

		// Token: 0x06004D65 RID: 19813 RVA: 0x000F137A File Offset: 0x000EF77A
		public static SkillTable GetRootAsSkillTable(ByteBuffer _bb, SkillTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004D66 RID: 19814 RVA: 0x000F1396 File Offset: 0x000EF796
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004D67 RID: 19815 RVA: 0x000F13B0 File Offset: 0x000EF7B0
		public SkillTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001529 RID: 5417
		// (get) Token: 0x06004D68 RID: 19816 RVA: 0x000F13BC File Offset: 0x000EF7BC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700152A RID: 5418
		// (get) Token: 0x06004D69 RID: 19817 RVA: 0x000F1408 File Offset: 0x000EF808
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004D6A RID: 19818 RVA: 0x000F144A File Offset: 0x000EF84A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700152B RID: 5419
		// (get) Token: 0x06004D6B RID: 19819 RVA: 0x000F1458 File Offset: 0x000EF858
		public string EnglishName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004D6C RID: 19820 RVA: 0x000F149A File Offset: 0x000EF89A
		public ArraySegment<byte>? GetEnglishNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700152C RID: 5420
		// (get) Token: 0x06004D6D RID: 19821 RVA: 0x000F14A8 File Offset: 0x000EF8A8
		public string SmallIcon
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004D6E RID: 19822 RVA: 0x000F14EB File Offset: 0x000EF8EB
		public ArraySegment<byte>? GetSmallIconBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700152D RID: 5421
		// (get) Token: 0x06004D6F RID: 19823 RVA: 0x000F14FC File Offset: 0x000EF8FC
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004D70 RID: 19824 RVA: 0x000F153F File Offset: 0x000EF93F
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06004D71 RID: 19825 RVA: 0x000F1550 File Offset: 0x000EF950
		public int JobIDArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700152E RID: 5422
		// (get) Token: 0x06004D72 RID: 19826 RVA: 0x000F15A0 File Offset: 0x000EF9A0
		public int JobIDLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D73 RID: 19827 RVA: 0x000F15D3 File Offset: 0x000EF9D3
		public ArraySegment<byte>? GetJobIDBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x1700152F RID: 5423
		// (get) Token: 0x06004D74 RID: 19828 RVA: 0x000F15E2 File Offset: 0x000EF9E2
		public FlatBufferArray<int> JobID
		{
			get
			{
				if (this.JobIDValue == null)
				{
					this.JobIDValue = new FlatBufferArray<int>(new Func<int, int>(this.JobIDArray), this.JobIDLength);
				}
				return this.JobIDValue;
			}
		}

		// Token: 0x17001530 RID: 5424
		// (get) Token: 0x06004D75 RID: 19829 RVA: 0x000F1614 File Offset: 0x000EFA14
		public int Speed
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001531 RID: 5425
		// (get) Token: 0x06004D76 RID: 19830 RVA: 0x000F1660 File Offset: 0x000EFA60
		public int SpeedEffectType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001532 RID: 5426
		// (get) Token: 0x06004D77 RID: 19831 RVA: 0x000F16AC File Offset: 0x000EFAAC
		public int PhaseRelatedSpeed
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001533 RID: 5427
		// (get) Token: 0x06004D78 RID: 19832 RVA: 0x000F16F8 File Offset: 0x000EFAF8
		public SkillTable.eSkillType SkillType
		{
			get
			{
				int num = this.__p.__offset(22);
				return (SkillTable.eSkillType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001534 RID: 5428
		// (get) Token: 0x06004D79 RID: 19833 RVA: 0x000F173C File Offset: 0x000EFB3C
		public int SkillCategory
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001535 RID: 5429
		// (get) Token: 0x06004D7A RID: 19834 RVA: 0x000F1788 File Offset: 0x000EFB88
		public int MasterSkillID
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004D7B RID: 19835 RVA: 0x000F17D4 File Offset: 0x000EFBD4
		public SkillTable.eSkillEffect SkillEffectArray(int j)
		{
			int num = this.__p.__offset(28);
			return (SkillTable.eSkillEffect)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001536 RID: 5430
		// (get) Token: 0x06004D7C RID: 19836 RVA: 0x000F181C File Offset: 0x000EFC1C
		public int SkillEffectLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D7D RID: 19837 RVA: 0x000F184F File Offset: 0x000EFC4F
		public ArraySegment<byte>? GetSkillEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17001537 RID: 5431
		// (get) Token: 0x06004D7E RID: 19838 RVA: 0x000F185E File Offset: 0x000EFC5E
		public FlatBufferArray<SkillTable.eSkillEffect> SkillEffect
		{
			get
			{
				if (this.SkillEffectValue == null)
				{
					this.SkillEffectValue = new FlatBufferArray<SkillTable.eSkillEffect>(new Func<int, SkillTable.eSkillEffect>(this.SkillEffectArray), this.SkillEffectLength);
				}
				return this.SkillEffectValue;
			}
		}

		// Token: 0x17001538 RID: 5432
		// (get) Token: 0x06004D7F RID: 19839 RVA: 0x000F1890 File Offset: 0x000EFC90
		public int IsBuff
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001539 RID: 5433
		// (get) Token: 0x06004D80 RID: 19840 RVA: 0x000F18DC File Offset: 0x000EFCDC
		public int IsQTE
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700153A RID: 5434
		// (get) Token: 0x06004D81 RID: 19841 RVA: 0x000F1928 File Offset: 0x000EFD28
		public int IsRunAttack
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700153B RID: 5435
		// (get) Token: 0x06004D82 RID: 19842 RVA: 0x000F1974 File Offset: 0x000EFD74
		public int SkillPressType
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700153C RID: 5436
		// (get) Token: 0x06004D83 RID: 19843 RVA: 0x000F19C0 File Offset: 0x000EFDC0
		public int PressBackJumpCancel
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700153D RID: 5437
		// (get) Token: 0x06004D84 RID: 19844 RVA: 0x000F1A0C File Offset: 0x000EFE0C
		public int WatchBuffID
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700153E RID: 5438
		// (get) Token: 0x06004D85 RID: 19845 RVA: 0x000F1A58 File Offset: 0x000EFE58
		public int CanSwithWeapon
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700153F RID: 5439
		// (get) Token: 0x06004D86 RID: 19846 RVA: 0x000F1AA4 File Offset: 0x000EFEA4
		public int CDPhase
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001540 RID: 5440
		// (get) Token: 0x06004D87 RID: 19847 RVA: 0x000F1AF0 File Offset: 0x000EFEF0
		public int IsAttackCombo
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001541 RID: 5441
		// (get) Token: 0x06004D88 RID: 19848 RVA: 0x000F1B3C File Offset: 0x000EFF3C
		public int CanUseInPVP
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001542 RID: 5442
		// (get) Token: 0x06004D89 RID: 19849 RVA: 0x000F1B88 File Offset: 0x000EFF88
		public int AttackScalePVP
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004D8A RID: 19850 RVA: 0x000F1BD4 File Offset: 0x000EFFD4
		public SkillTable.ePreCondition PreConditionArray(int j)
		{
			int num = this.__p.__offset(52);
			return (SkillTable.ePreCondition)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001543 RID: 5443
		// (get) Token: 0x06004D8B RID: 19851 RVA: 0x000F1C1C File Offset: 0x000F001C
		public int PreConditionLength
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D8C RID: 19852 RVA: 0x000F1C4F File Offset: 0x000F004F
		public ArraySegment<byte>? GetPreConditionBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x17001544 RID: 5444
		// (get) Token: 0x06004D8D RID: 19853 RVA: 0x000F1C5E File Offset: 0x000F005E
		public FlatBufferArray<SkillTable.ePreCondition> PreCondition
		{
			get
			{
				if (this.PreConditionValue == null)
				{
					this.PreConditionValue = new FlatBufferArray<SkillTable.ePreCondition>(new Func<int, SkillTable.ePreCondition>(this.PreConditionArray), this.PreConditionLength);
				}
				return this.PreConditionValue;
			}
		}

		// Token: 0x06004D8E RID: 19854 RVA: 0x000F1C90 File Offset: 0x000F0090
		public int LowHpPercentArray(int j)
		{
			int num = this.__p.__offset(54);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001545 RID: 5445
		// (get) Token: 0x06004D8F RID: 19855 RVA: 0x000F1CE0 File Offset: 0x000F00E0
		public int LowHpPercentLength
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D90 RID: 19856 RVA: 0x000F1D13 File Offset: 0x000F0113
		public ArraySegment<byte>? GetLowHpPercentBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x17001546 RID: 5446
		// (get) Token: 0x06004D91 RID: 19857 RVA: 0x000F1D22 File Offset: 0x000F0122
		public FlatBufferArray<int> LowHpPercent
		{
			get
			{
				if (this.LowHpPercentValue == null)
				{
					this.LowHpPercentValue = new FlatBufferArray<int>(new Func<int, int>(this.LowHpPercentArray), this.LowHpPercentLength);
				}
				return this.LowHpPercentValue;
			}
		}

		// Token: 0x17001547 RID: 5447
		// (get) Token: 0x06004D92 RID: 19858 RVA: 0x000F1D54 File Offset: 0x000F0154
		public UnionCell Probability
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x06004D93 RID: 19859 RVA: 0x000F1DAC File Offset: 0x000F01AC
		public int HitEffectIDsArray(int j)
		{
			int num = this.__p.__offset(58);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001548 RID: 5448
		// (get) Token: 0x06004D94 RID: 19860 RVA: 0x000F1DFC File Offset: 0x000F01FC
		public int HitEffectIDsLength
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D95 RID: 19861 RVA: 0x000F1E2F File Offset: 0x000F022F
		public ArraySegment<byte>? GetHitEffectIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x17001549 RID: 5449
		// (get) Token: 0x06004D96 RID: 19862 RVA: 0x000F1E3E File Offset: 0x000F023E
		public FlatBufferArray<int> HitEffectIDs
		{
			get
			{
				if (this.HitEffectIDsValue == null)
				{
					this.HitEffectIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.HitEffectIDsArray), this.HitEffectIDsLength);
				}
				return this.HitEffectIDsValue;
			}
		}

		// Token: 0x06004D97 RID: 19863 RVA: 0x000F1E70 File Offset: 0x000F0270
		public int HitEffectIDsPVPArray(int j)
		{
			int num = this.__p.__offset(60);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700154A RID: 5450
		// (get) Token: 0x06004D98 RID: 19864 RVA: 0x000F1EC0 File Offset: 0x000F02C0
		public int HitEffectIDsPVPLength
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D99 RID: 19865 RVA: 0x000F1EF3 File Offset: 0x000F02F3
		public ArraySegment<byte>? GetHitEffectIDsPVPBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x1700154B RID: 5451
		// (get) Token: 0x06004D9A RID: 19866 RVA: 0x000F1F02 File Offset: 0x000F0302
		public FlatBufferArray<int> HitEffectIDsPVP
		{
			get
			{
				if (this.HitEffectIDsPVPValue == null)
				{
					this.HitEffectIDsPVPValue = new FlatBufferArray<int>(new Func<int, int>(this.HitEffectIDsPVPArray), this.HitEffectIDsPVPLength);
				}
				return this.HitEffectIDsPVPValue;
			}
		}

		// Token: 0x06004D9B RID: 19867 RVA: 0x000F1F34 File Offset: 0x000F0334
		public int BuffInfoIDsArray(int j)
		{
			int num = this.__p.__offset(62);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700154C RID: 5452
		// (get) Token: 0x06004D9C RID: 19868 RVA: 0x000F1F84 File Offset: 0x000F0384
		public int BuffInfoIDsLength
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D9D RID: 19869 RVA: 0x000F1FB7 File Offset: 0x000F03B7
		public ArraySegment<byte>? GetBuffInfoIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x1700154D RID: 5453
		// (get) Token: 0x06004D9E RID: 19870 RVA: 0x000F1FC6 File Offset: 0x000F03C6
		public FlatBufferArray<int> BuffInfoIDs
		{
			get
			{
				if (this.BuffInfoIDsValue == null)
				{
					this.BuffInfoIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffInfoIDsArray), this.BuffInfoIDsLength);
				}
				return this.BuffInfoIDsValue;
			}
		}

		// Token: 0x06004D9F RID: 19871 RVA: 0x000F1FF8 File Offset: 0x000F03F8
		public int BuffInfoIDsPVPArray(int j)
		{
			int num = this.__p.__offset(64);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700154E RID: 5454
		// (get) Token: 0x06004DA0 RID: 19872 RVA: 0x000F2048 File Offset: 0x000F0448
		public int BuffInfoIDsPVPLength
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DA1 RID: 19873 RVA: 0x000F207B File Offset: 0x000F047B
		public ArraySegment<byte>? GetBuffInfoIDsPVPBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x1700154F RID: 5455
		// (get) Token: 0x06004DA2 RID: 19874 RVA: 0x000F208A File Offset: 0x000F048A
		public FlatBufferArray<int> BuffInfoIDsPVP
		{
			get
			{
				if (this.BuffInfoIDsPVPValue == null)
				{
					this.BuffInfoIDsPVPValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffInfoIDsPVPArray), this.BuffInfoIDsPVPLength);
				}
				return this.BuffInfoIDsPVPValue;
			}
		}

		// Token: 0x06004DA3 RID: 19875 RVA: 0x000F20BC File Offset: 0x000F04BC
		public int MechismIDsArray(int j)
		{
			int num = this.__p.__offset(66);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001550 RID: 5456
		// (get) Token: 0x06004DA4 RID: 19876 RVA: 0x000F210C File Offset: 0x000F050C
		public int MechismIDsLength
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DA5 RID: 19877 RVA: 0x000F213F File Offset: 0x000F053F
		public ArraySegment<byte>? GetMechismIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x17001551 RID: 5457
		// (get) Token: 0x06004DA6 RID: 19878 RVA: 0x000F214E File Offset: 0x000F054E
		public FlatBufferArray<int> MechismIDs
		{
			get
			{
				if (this.MechismIDsValue == null)
				{
					this.MechismIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.MechismIDsArray), this.MechismIDsLength);
				}
				return this.MechismIDsValue;
			}
		}

		// Token: 0x06004DA7 RID: 19879 RVA: 0x000F2180 File Offset: 0x000F0580
		public int MechismIDsPVPArray(int j)
		{
			int num = this.__p.__offset(68);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001552 RID: 5458
		// (get) Token: 0x06004DA8 RID: 19880 RVA: 0x000F21D0 File Offset: 0x000F05D0
		public int MechismIDsPVPLength
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DA9 RID: 19881 RVA: 0x000F2203 File Offset: 0x000F0603
		public ArraySegment<byte>? GetMechismIDsPVPBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x17001553 RID: 5459
		// (get) Token: 0x06004DAA RID: 19882 RVA: 0x000F2212 File Offset: 0x000F0612
		public FlatBufferArray<int> MechismIDsPVP
		{
			get
			{
				if (this.MechismIDsPVPValue == null)
				{
					this.MechismIDsPVPValue = new FlatBufferArray<int>(new Func<int, int>(this.MechismIDsPVPArray), this.MechismIDsPVPLength);
				}
				return this.MechismIDsPVPValue;
			}
		}

		// Token: 0x17001554 RID: 5460
		// (get) Token: 0x06004DAB RID: 19883 RVA: 0x000F2244 File Offset: 0x000F0644
		public string InterruptSkills
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004DAC RID: 19884 RVA: 0x000F2287 File Offset: 0x000F0687
		public ArraySegment<byte>? GetInterruptSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x17001555 RID: 5461
		// (get) Token: 0x06004DAD RID: 19885 RVA: 0x000F2298 File Offset: 0x000F0698
		public string InterruptSkillsPVP
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004DAE RID: 19886 RVA: 0x000F22DB File Offset: 0x000F06DB
		public ArraySegment<byte>? GetInterruptSkillsPVPBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x06004DAF RID: 19887 RVA: 0x000F22EC File Offset: 0x000F06EC
		public int HitInterruptSkillsArray(int j)
		{
			int num = this.__p.__offset(74);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001556 RID: 5462
		// (get) Token: 0x06004DB0 RID: 19888 RVA: 0x000F233C File Offset: 0x000F073C
		public int HitInterruptSkillsLength
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DB1 RID: 19889 RVA: 0x000F236F File Offset: 0x000F076F
		public ArraySegment<byte>? GetHitInterruptSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(74);
		}

		// Token: 0x17001557 RID: 5463
		// (get) Token: 0x06004DB2 RID: 19890 RVA: 0x000F237E File Offset: 0x000F077E
		public FlatBufferArray<int> HitInterruptSkills
		{
			get
			{
				if (this.HitInterruptSkillsValue == null)
				{
					this.HitInterruptSkillsValue = new FlatBufferArray<int>(new Func<int, int>(this.HitInterruptSkillsArray), this.HitInterruptSkillsLength);
				}
				return this.HitInterruptSkillsValue;
			}
		}

		// Token: 0x17001558 RID: 5464
		// (get) Token: 0x06004DB3 RID: 19891 RVA: 0x000F23B0 File Offset: 0x000F07B0
		public bool IsResetCamera
		{
			get
			{
				int num = this.__p.__offset(76);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17001559 RID: 5465
		// (get) Token: 0x06004DB4 RID: 19892 RVA: 0x000F23FC File Offset: 0x000F07FC
		public bool IsForce
		{
			get
			{
				int num = this.__p.__offset(78);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700155A RID: 5466
		// (get) Token: 0x06004DB5 RID: 19893 RVA: 0x000F2448 File Offset: 0x000F0848
		public bool IsCanCancel
		{
			get
			{
				int num = this.__p.__offset(80);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700155B RID: 5467
		// (get) Token: 0x06004DB6 RID: 19894 RVA: 0x000F2494 File Offset: 0x000F0894
		public bool IsCanDispose
		{
			get
			{
				int num = this.__p.__offset(82);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700155C RID: 5468
		// (get) Token: 0x06004DB7 RID: 19895 RVA: 0x000F24E0 File Offset: 0x000F08E0
		public bool IsChargeEnable
		{
			get
			{
				int num = this.__p.__offset(84);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700155D RID: 5469
		// (get) Token: 0x06004DB8 RID: 19896 RVA: 0x000F252C File Offset: 0x000F092C
		public int HideSpellBar
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700155E RID: 5470
		// (get) Token: 0x06004DB9 RID: 19897 RVA: 0x000F2578 File Offset: 0x000F0978
		public bool IsWalkEnable
		{
			get
			{
				int num = this.__p.__offset(88);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700155F RID: 5471
		// (get) Token: 0x06004DBA RID: 19898 RVA: 0x000F25C4 File Offset: 0x000F09C4
		public int WalkMode
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001560 RID: 5472
		// (get) Token: 0x06004DBB RID: 19899 RVA: 0x000F2610 File Offset: 0x000F0A10
		public UnionCell WalkSpeed
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001561 RID: 5473
		// (get) Token: 0x06004DBC RID: 19900 RVA: 0x000F2668 File Offset: 0x000F0A68
		public UnionCell WalkSpeedPVP
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001562 RID: 5474
		// (get) Token: 0x06004DBD RID: 19901 RVA: 0x000F26C0 File Offset: 0x000F0AC0
		public int SummonRestrainEffectID
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001563 RID: 5475
		// (get) Token: 0x06004DBE RID: 19902 RVA: 0x000F270C File Offset: 0x000F0B0C
		public int CostMode
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001564 RID: 5476
		// (get) Token: 0x06004DBF RID: 19903 RVA: 0x000F2758 File Offset: 0x000F0B58
		public UnionCell HPCostPercent
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001565 RID: 5477
		// (get) Token: 0x06004DC0 RID: 19904 RVA: 0x000F27B0 File Offset: 0x000F0BB0
		public UnionCell HPCost
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001566 RID: 5478
		// (get) Token: 0x06004DC1 RID: 19905 RVA: 0x000F2808 File Offset: 0x000F0C08
		public UnionCell MPCost
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001567 RID: 5479
		// (get) Token: 0x06004DC2 RID: 19906 RVA: 0x000F2860 File Offset: 0x000F0C60
		public UnionCell CrystalCost
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001568 RID: 5480
		// (get) Token: 0x06004DC3 RID: 19907 RVA: 0x000F28B8 File Offset: 0x000F0CB8
		public int SpellTime
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001569 RID: 5481
		// (get) Token: 0x06004DC4 RID: 19908 RVA: 0x000F2904 File Offset: 0x000F0D04
		public int SpellTimePVP
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700156A RID: 5482
		// (get) Token: 0x06004DC5 RID: 19909 RVA: 0x000F2950 File Offset: 0x000F0D50
		public UnionCell RefreshTime
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700156B RID: 5483
		// (get) Token: 0x06004DC6 RID: 19910 RVA: 0x000F29A8 File Offset: 0x000F0DA8
		public UnionCell InitCD
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700156C RID: 5484
		// (get) Token: 0x06004DC7 RID: 19911 RVA: 0x000F2A00 File Offset: 0x000F0E00
		public UnionCell MinCD
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700156D RID: 5485
		// (get) Token: 0x06004DC8 RID: 19912 RVA: 0x000F2A58 File Offset: 0x000F0E58
		public UnionCell RefreshTimePVP
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700156E RID: 5486
		// (get) Token: 0x06004DC9 RID: 19913 RVA: 0x000F2AB0 File Offset: 0x000F0EB0
		public UnionCell InitCDPVP
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700156F RID: 5487
		// (get) Token: 0x06004DCA RID: 19914 RVA: 0x000F2B08 File Offset: 0x000F0F08
		public UnionCell MinCDPVP
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001570 RID: 5488
		// (get) Token: 0x06004DCB RID: 19915 RVA: 0x000F2B60 File Offset: 0x000F0F60
		public SkillTable.eSkillTarget SkillTarget
		{
			get
			{
				int num = this.__p.__offset(124);
				return (SkillTable.eSkillTarget)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001571 RID: 5489
		// (get) Token: 0x06004DCC RID: 19916 RVA: 0x000F2BA4 File Offset: 0x000F0FA4
		public int SkillAttri
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001572 RID: 5490
		// (get) Token: 0x06004DCD RID: 19917 RVA: 0x000F2BF0 File Offset: 0x000F0FF0
		public int IsPreJob
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001573 RID: 5491
		// (get) Token: 0x06004DCE RID: 19918 RVA: 0x000F2C40 File Offset: 0x000F1040
		public int IsStudy
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001574 RID: 5492
		// (get) Token: 0x06004DCF RID: 19919 RVA: 0x000F2C90 File Offset: 0x000F1090
		public int LevelLimit
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001575 RID: 5493
		// (get) Token: 0x06004DD0 RID: 19920 RVA: 0x000F2CE0 File Offset: 0x000F10E0
		public int LevelLimitAmend
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001576 RID: 5494
		// (get) Token: 0x06004DD1 RID: 19921 RVA: 0x000F2D30 File Offset: 0x000F1130
		public int TopLevelLimit
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001577 RID: 5495
		// (get) Token: 0x06004DD2 RID: 19922 RVA: 0x000F2D80 File Offset: 0x000F1180
		public int TopLevel
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004DD3 RID: 19923 RVA: 0x000F2DD0 File Offset: 0x000F11D0
		public int PreSkillsArray(int j)
		{
			int num = this.__p.__offset(140);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001578 RID: 5496
		// (get) Token: 0x06004DD4 RID: 19924 RVA: 0x000F2E20 File Offset: 0x000F1220
		public int PreSkillsLength
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DD5 RID: 19925 RVA: 0x000F2E56 File Offset: 0x000F1256
		public ArraySegment<byte>? GetPreSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(140);
		}

		// Token: 0x17001579 RID: 5497
		// (get) Token: 0x06004DD6 RID: 19926 RVA: 0x000F2E68 File Offset: 0x000F1268
		public FlatBufferArray<int> PreSkills
		{
			get
			{
				if (this.PreSkillsValue == null)
				{
					this.PreSkillsValue = new FlatBufferArray<int>(new Func<int, int>(this.PreSkillsArray), this.PreSkillsLength);
				}
				return this.PreSkillsValue;
			}
		}

		// Token: 0x06004DD7 RID: 19927 RVA: 0x000F2E98 File Offset: 0x000F1298
		public int PreSkillsLevelArray(int j)
		{
			int num = this.__p.__offset(142);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700157A RID: 5498
		// (get) Token: 0x06004DD8 RID: 19928 RVA: 0x000F2EE8 File Offset: 0x000F12E8
		public int PreSkillsLevelLength
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DD9 RID: 19929 RVA: 0x000F2F1E File Offset: 0x000F131E
		public ArraySegment<byte>? GetPreSkillsLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(142);
		}

		// Token: 0x1700157B RID: 5499
		// (get) Token: 0x06004DDA RID: 19930 RVA: 0x000F2F30 File Offset: 0x000F1330
		public FlatBufferArray<int> PreSkillsLevel
		{
			get
			{
				if (this.PreSkillsLevelValue == null)
				{
					this.PreSkillsLevelValue = new FlatBufferArray<int>(new Func<int, int>(this.PreSkillsLevelArray), this.PreSkillsLevelLength);
				}
				return this.PreSkillsLevelValue;
			}
		}

		// Token: 0x06004DDB RID: 19931 RVA: 0x000F2F60 File Offset: 0x000F1360
		public int PostSkillsArray(int j)
		{
			int num = this.__p.__offset(144);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700157C RID: 5500
		// (get) Token: 0x06004DDC RID: 19932 RVA: 0x000F2FB0 File Offset: 0x000F13B0
		public int PostSkillsLength
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DDD RID: 19933 RVA: 0x000F2FE6 File Offset: 0x000F13E6
		public ArraySegment<byte>? GetPostSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(144);
		}

		// Token: 0x1700157D RID: 5501
		// (get) Token: 0x06004DDE RID: 19934 RVA: 0x000F2FF8 File Offset: 0x000F13F8
		public FlatBufferArray<int> PostSkills
		{
			get
			{
				if (this.PostSkillsValue == null)
				{
					this.PostSkillsValue = new FlatBufferArray<int>(new Func<int, int>(this.PostSkillsArray), this.PostSkillsLength);
				}
				return this.PostSkillsValue;
			}
		}

		// Token: 0x06004DDF RID: 19935 RVA: 0x000F3028 File Offset: 0x000F1428
		public int NeedLevelArray(int j)
		{
			int num = this.__p.__offset(146);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700157E RID: 5502
		// (get) Token: 0x06004DE0 RID: 19936 RVA: 0x000F3078 File Offset: 0x000F1478
		public int NeedLevelLength
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DE1 RID: 19937 RVA: 0x000F30AE File Offset: 0x000F14AE
		public ArraySegment<byte>? GetNeedLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(146);
		}

		// Token: 0x1700157F RID: 5503
		// (get) Token: 0x06004DE2 RID: 19938 RVA: 0x000F30C0 File Offset: 0x000F14C0
		public FlatBufferArray<int> NeedLevel
		{
			get
			{
				if (this.NeedLevelValue == null)
				{
					this.NeedLevelValue = new FlatBufferArray<int>(new Func<int, int>(this.NeedLevelArray), this.NeedLevelLength);
				}
				return this.NeedLevelValue;
			}
		}

		// Token: 0x17001580 RID: 5504
		// (get) Token: 0x06004DE3 RID: 19939 RVA: 0x000F30F0 File Offset: 0x000F14F0
		public int LearnSPCost
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001581 RID: 5505
		// (get) Token: 0x06004DE4 RID: 19940 RVA: 0x000F3140 File Offset: 0x000F1540
		public int LearnGoodCost
		{
			get
			{
				int num = this.__p.__offset(150);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001582 RID: 5506
		// (get) Token: 0x06004DE5 RID: 19941 RVA: 0x000F3190 File Offset: 0x000F1590
		public int IsForceSync
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001583 RID: 5507
		// (get) Token: 0x06004DE6 RID: 19942 RVA: 0x000F31E0 File Offset: 0x000F15E0
		public int BindButtonIndex
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001584 RID: 5508
		// (get) Token: 0x06004DE7 RID: 19943 RVA: 0x000F3230 File Offset: 0x000F1630
		public int PassiveSkillBtnIndex
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001585 RID: 5509
		// (get) Token: 0x06004DE8 RID: 19944 RVA: 0x000F3280 File Offset: 0x000F1680
		public string SkillSpeech
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004DE9 RID: 19945 RVA: 0x000F32C6 File Offset: 0x000F16C6
		public ArraySegment<byte>? GetSkillSpeechBytes()
		{
			return this.__p.__vector_as_arraysegment(158);
		}

		// Token: 0x17001586 RID: 5510
		// (get) Token: 0x06004DEA RID: 19946 RVA: 0x000F32D8 File Offset: 0x000F16D8
		public int SkillSpeechRand
		{
			get
			{
				int num = this.__p.__offset(160);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001587 RID: 5511
		// (get) Token: 0x06004DEB RID: 19947 RVA: 0x000F3328 File Offset: 0x000F1728
		public string SkillDealText
		{
			get
			{
				int num = this.__p.__offset(162);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004DEC RID: 19948 RVA: 0x000F336E File Offset: 0x000F176E
		public ArraySegment<byte>? GetSkillDealTextBytes()
		{
			return this.__p.__vector_as_arraysegment(162);
		}

		// Token: 0x17001588 RID: 5512
		// (get) Token: 0x06004DED RID: 19949 RVA: 0x000F3380 File Offset: 0x000F1780
		public int SkillDealTextDuration
		{
			get
			{
				int num = this.__p.__offset(164);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001589 RID: 5513
		// (get) Token: 0x06004DEE RID: 19950 RVA: 0x000F33D0 File Offset: 0x000F17D0
		public int SwitchSkillID
		{
			get
			{
				int num = this.__p.__offset(166);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700158A RID: 5514
		// (get) Token: 0x06004DEF RID: 19951 RVA: 0x000F3420 File Offset: 0x000F1820
		public int RangeX
		{
			get
			{
				int num = this.__p.__offset(168);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700158B RID: 5515
		// (get) Token: 0x06004DF0 RID: 19952 RVA: 0x000F3470 File Offset: 0x000F1870
		public int RangeY
		{
			get
			{
				int num = this.__p.__offset(170);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700158C RID: 5516
		// (get) Token: 0x06004DF1 RID: 19953 RVA: 0x000F34C0 File Offset: 0x000F18C0
		public int BackRangeX
		{
			get
			{
				int num = this.__p.__offset(172);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700158D RID: 5517
		// (get) Token: 0x06004DF2 RID: 19954 RVA: 0x000F3510 File Offset: 0x000F1910
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(174);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700158E RID: 5518
		// (get) Token: 0x06004DF3 RID: 19955 RVA: 0x000F3560 File Offset: 0x000F1960
		public string AttackInfo
		{
			get
			{
				int num = this.__p.__offset(176);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004DF4 RID: 19956 RVA: 0x000F35A6 File Offset: 0x000F19A6
		public ArraySegment<byte>? GetAttackInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(176);
		}

		// Token: 0x1700158F RID: 5519
		// (get) Token: 0x06004DF5 RID: 19957 RVA: 0x000F35B8 File Offset: 0x000F19B8
		public UnionCell Zscale
		{
			get
			{
				int num = this.__p.__offset(178);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001590 RID: 5520
		// (get) Token: 0x06004DF6 RID: 19958 RVA: 0x000F3614 File Offset: 0x000F1A14
		public UnionCell PVPZscale
		{
			get
			{
				int num = this.__p.__offset(180);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001591 RID: 5521
		// (get) Token: 0x06004DF7 RID: 19959 RVA: 0x000F3670 File Offset: 0x000F1A70
		public int SkillOperation
		{
			get
			{
				int num = this.__p.__offset(182);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001592 RID: 5522
		// (get) Token: 0x06004DF8 RID: 19960 RVA: 0x000F36C0 File Offset: 0x000F1AC0
		public int SkillOpTarget
		{
			get
			{
				int num = this.__p.__offset(184);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001593 RID: 5523
		// (get) Token: 0x06004DF9 RID: 19961 RVA: 0x000F3710 File Offset: 0x000F1B10
		public string SkillOpVar
		{
			get
			{
				int num = this.__p.__offset(186);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004DFA RID: 19962 RVA: 0x000F3756 File Offset: 0x000F1B56
		public ArraySegment<byte>? GetSkillOpVarBytes()
		{
			return this.__p.__vector_as_arraysegment(186);
		}

		// Token: 0x17001594 RID: 5524
		// (get) Token: 0x06004DFB RID: 19963 RVA: 0x000F3768 File Offset: 0x000F1B68
		public UnionCell SkillOpValue
		{
			get
			{
				int num = this.__p.__offset(188);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x06004DFC RID: 19964 RVA: 0x000F37C4 File Offset: 0x000F1BC4
		public int SkillOpSkillIDsArray(int j)
		{
			int num = this.__p.__offset(190);
			return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001595 RID: 5525
		// (get) Token: 0x06004DFD RID: 19965 RVA: 0x000F3814 File Offset: 0x000F1C14
		public int SkillOpSkillIDsLength
		{
			get
			{
				int num = this.__p.__offset(190);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004DFE RID: 19966 RVA: 0x000F384A File Offset: 0x000F1C4A
		public ArraySegment<byte>? GetSkillOpSkillIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(190);
		}

		// Token: 0x17001596 RID: 5526
		// (get) Token: 0x06004DFF RID: 19967 RVA: 0x000F385C File Offset: 0x000F1C5C
		public FlatBufferArray<int> SkillOpSkillIDs
		{
			get
			{
				if (this.SkillOpSkillIDsValue == null)
				{
					this.SkillOpSkillIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.SkillOpSkillIDsArray), this.SkillOpSkillIDsLength);
				}
				return this.SkillOpSkillIDsValue;
			}
		}

		// Token: 0x17001597 RID: 5527
		// (get) Token: 0x06004E00 RID: 19968 RVA: 0x000F388C File Offset: 0x000F1C8C
		public int NeedWeaponType
		{
			get
			{
				int num = this.__p.__offset(192);
				return (num == 0) ? 0 : (-1406489137 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001598 RID: 5528
		// (get) Token: 0x06004E01 RID: 19969 RVA: 0x000F38DC File Offset: 0x000F1CDC
		public string DescriptionA
		{
			get
			{
				int num = this.__p.__offset(194);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004E02 RID: 19970 RVA: 0x000F3922 File Offset: 0x000F1D22
		public ArraySegment<byte>? GetDescriptionABytes()
		{
			return this.__p.__vector_as_arraysegment(194);
		}

		// Token: 0x06004E03 RID: 19971 RVA: 0x000F3934 File Offset: 0x000F1D34
		public UnionCell ValueAArray(int j)
		{
			int num = this.__p.__offset(196);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17001599 RID: 5529
		// (get) Token: 0x06004E04 RID: 19972 RVA: 0x000F3994 File Offset: 0x000F1D94
		public int ValueALength
		{
			get
			{
				int num = this.__p.__offset(196);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700159A RID: 5530
		// (get) Token: 0x06004E05 RID: 19973 RVA: 0x000F39CA File Offset: 0x000F1DCA
		public FlatBufferArray<UnionCell> ValueA
		{
			get
			{
				if (this.ValueAValue == null)
				{
					this.ValueAValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueAArray), this.ValueALength);
				}
				return this.ValueAValue;
			}
		}

		// Token: 0x1700159B RID: 5531
		// (get) Token: 0x06004E06 RID: 19974 RVA: 0x000F39FC File Offset: 0x000F1DFC
		public string DescriptionB
		{
			get
			{
				int num = this.__p.__offset(198);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004E07 RID: 19975 RVA: 0x000F3A42 File Offset: 0x000F1E42
		public ArraySegment<byte>? GetDescriptionBBytes()
		{
			return this.__p.__vector_as_arraysegment(198);
		}

		// Token: 0x06004E08 RID: 19976 RVA: 0x000F3A54 File Offset: 0x000F1E54
		public UnionCell ValueBArray(int j)
		{
			int num = this.__p.__offset(200);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700159C RID: 5532
		// (get) Token: 0x06004E09 RID: 19977 RVA: 0x000F3AB4 File Offset: 0x000F1EB4
		public int ValueBLength
		{
			get
			{
				int num = this.__p.__offset(200);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700159D RID: 5533
		// (get) Token: 0x06004E0A RID: 19978 RVA: 0x000F3AEA File Offset: 0x000F1EEA
		public FlatBufferArray<UnionCell> ValueB
		{
			get
			{
				if (this.ValueBValue == null)
				{
					this.ValueBValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueBArray), this.ValueBLength);
				}
				return this.ValueBValue;
			}
		}

		// Token: 0x1700159E RID: 5534
		// (get) Token: 0x06004E0B RID: 19979 RVA: 0x000F3B1C File Offset: 0x000F1F1C
		public string DescriptionC
		{
			get
			{
				int num = this.__p.__offset(202);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004E0C RID: 19980 RVA: 0x000F3B62 File Offset: 0x000F1F62
		public ArraySegment<byte>? GetDescriptionCBytes()
		{
			return this.__p.__vector_as_arraysegment(202);
		}

		// Token: 0x06004E0D RID: 19981 RVA: 0x000F3B74 File Offset: 0x000F1F74
		public UnionCell ValueCArray(int j)
		{
			int num = this.__p.__offset(204);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700159F RID: 5535
		// (get) Token: 0x06004E0E RID: 19982 RVA: 0x000F3BD4 File Offset: 0x000F1FD4
		public int ValueCLength
		{
			get
			{
				int num = this.__p.__offset(204);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015A0 RID: 5536
		// (get) Token: 0x06004E0F RID: 19983 RVA: 0x000F3C0A File Offset: 0x000F200A
		public FlatBufferArray<UnionCell> ValueC
		{
			get
			{
				if (this.ValueCValue == null)
				{
					this.ValueCValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueCArray), this.ValueCLength);
				}
				return this.ValueCValue;
			}
		}

		// Token: 0x170015A1 RID: 5537
		// (get) Token: 0x06004E10 RID: 19984 RVA: 0x000F3C3C File Offset: 0x000F203C
		public string DescriptionD
		{
			get
			{
				int num = this.__p.__offset(206);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004E11 RID: 19985 RVA: 0x000F3C82 File Offset: 0x000F2082
		public ArraySegment<byte>? GetDescriptionDBytes()
		{
			return this.__p.__vector_as_arraysegment(206);
		}

		// Token: 0x06004E12 RID: 19986 RVA: 0x000F3C94 File Offset: 0x000F2094
		public UnionCell ValueDArray(int j)
		{
			int num = this.__p.__offset(208);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x170015A2 RID: 5538
		// (get) Token: 0x06004E13 RID: 19987 RVA: 0x000F3CF4 File Offset: 0x000F20F4
		public int ValueDLength
		{
			get
			{
				int num = this.__p.__offset(208);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015A3 RID: 5539
		// (get) Token: 0x06004E14 RID: 19988 RVA: 0x000F3D2A File Offset: 0x000F212A
		public FlatBufferArray<UnionCell> ValueD
		{
			get
			{
				if (this.ValueDValue == null)
				{
					this.ValueDValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueDArray), this.ValueDLength);
				}
				return this.ValueDValue;
			}
		}

		// Token: 0x170015A4 RID: 5540
		// (get) Token: 0x06004E15 RID: 19989 RVA: 0x000F3D5C File Offset: 0x000F215C
		public string DescriptionE
		{
			get
			{
				int num = this.__p.__offset(210);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004E16 RID: 19990 RVA: 0x000F3DA2 File Offset: 0x000F21A2
		public ArraySegment<byte>? GetDescriptionEBytes()
		{
			return this.__p.__vector_as_arraysegment(210);
		}

		// Token: 0x06004E17 RID: 19991 RVA: 0x000F3DB4 File Offset: 0x000F21B4
		public UnionCell ValueEArray(int j)
		{
			int num = this.__p.__offset(212);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x170015A5 RID: 5541
		// (get) Token: 0x06004E18 RID: 19992 RVA: 0x000F3E14 File Offset: 0x000F2214
		public int ValueELength
		{
			get
			{
				int num = this.__p.__offset(212);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015A6 RID: 5542
		// (get) Token: 0x06004E19 RID: 19993 RVA: 0x000F3E4A File Offset: 0x000F224A
		public FlatBufferArray<UnionCell> ValueE
		{
			get
			{
				if (this.ValueEValue == null)
				{
					this.ValueEValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueEArray), this.ValueELength);
				}
				return this.ValueEValue;
			}
		}

		// Token: 0x170015A7 RID: 5543
		// (get) Token: 0x06004E1A RID: 19994 RVA: 0x000F3E7C File Offset: 0x000F227C
		public string DescriptionF
		{
			get
			{
				int num = this.__p.__offset(214);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004E1B RID: 19995 RVA: 0x000F3EC2 File Offset: 0x000F22C2
		public ArraySegment<byte>? GetDescriptionFBytes()
		{
			return this.__p.__vector_as_arraysegment(214);
		}

		// Token: 0x06004E1C RID: 19996 RVA: 0x000F3ED4 File Offset: 0x000F22D4
		public UnionCell ValueFArray(int j)
		{
			int num = this.__p.__offset(216);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x170015A8 RID: 5544
		// (get) Token: 0x06004E1D RID: 19997 RVA: 0x000F3F34 File Offset: 0x000F2334
		public int ValueFLength
		{
			get
			{
				int num = this.__p.__offset(216);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015A9 RID: 5545
		// (get) Token: 0x06004E1E RID: 19998 RVA: 0x000F3F6A File Offset: 0x000F236A
		public FlatBufferArray<UnionCell> ValueF
		{
			get
			{
				if (this.ValueFValue == null)
				{
					this.ValueFValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueFArray), this.ValueFLength);
				}
				return this.ValueFValue;
			}
		}

		// Token: 0x170015AA RID: 5546
		// (get) Token: 0x06004E1F RID: 19999 RVA: 0x000F3F9C File Offset: 0x000F239C
		public string DescriptionG
		{
			get
			{
				int num = this.__p.__offset(218);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004E20 RID: 20000 RVA: 0x000F3FE2 File Offset: 0x000F23E2
		public ArraySegment<byte>? GetDescriptionGBytes()
		{
			return this.__p.__vector_as_arraysegment(218);
		}

		// Token: 0x06004E21 RID: 20001 RVA: 0x000F3FF4 File Offset: 0x000F23F4
		public UnionCell ValueGArray(int j)
		{
			int num = this.__p.__offset(220);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x170015AB RID: 5547
		// (get) Token: 0x06004E22 RID: 20002 RVA: 0x000F4054 File Offset: 0x000F2454
		public int ValueGLength
		{
			get
			{
				int num = this.__p.__offset(220);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015AC RID: 5548
		// (get) Token: 0x06004E23 RID: 20003 RVA: 0x000F408A File Offset: 0x000F248A
		public FlatBufferArray<UnionCell> ValueG
		{
			get
			{
				if (this.ValueGValue == null)
				{
					this.ValueGValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueGArray), this.ValueGLength);
				}
				return this.ValueGValue;
			}
		}

		// Token: 0x06004E24 RID: 20004 RVA: 0x000F40BC File Offset: 0x000F24BC
		public static Offset<SkillTable> CreateSkillTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset EnglishNameOffset = default(StringOffset), StringOffset SmallIconOffset = default(StringOffset), StringOffset IconOffset = default(StringOffset), VectorOffset JobIDOffset = default(VectorOffset), int Speed = 0, int SpeedEffectType = 0, int PhaseRelatedSpeed = 0, SkillTable.eSkillType SkillType = SkillTable.eSkillType.SkillType_None, int SkillCategory = 0, int MasterSkillID = 0, VectorOffset SkillEffectOffset = default(VectorOffset), int IsBuff = 0, int IsQTE = 0, int IsRunAttack = 0, int SkillPressType = 0, int PressBackJumpCancel = 0, int WatchBuffID = 0, int CanSwithWeapon = 0, int CDPhase = 0, int IsAttackCombo = 0, int CanUseInPVP = 0, int AttackScalePVP = 0, VectorOffset PreConditionOffset = default(VectorOffset), VectorOffset LowHpPercentOffset = default(VectorOffset), Offset<UnionCell> ProbabilityOffset = default(Offset<UnionCell>), VectorOffset HitEffectIDsOffset = default(VectorOffset), VectorOffset HitEffectIDsPVPOffset = default(VectorOffset), VectorOffset BuffInfoIDsOffset = default(VectorOffset), VectorOffset BuffInfoIDsPVPOffset = default(VectorOffset), VectorOffset MechismIDsOffset = default(VectorOffset), VectorOffset MechismIDsPVPOffset = default(VectorOffset), StringOffset InterruptSkillsOffset = default(StringOffset), StringOffset InterruptSkillsPVPOffset = default(StringOffset), VectorOffset HitInterruptSkillsOffset = default(VectorOffset), bool IsResetCamera = false, bool IsForce = false, bool IsCanCancel = false, bool IsCanDispose = false, bool IsChargeEnable = false, int HideSpellBar = 0, bool IsWalkEnable = false, int WalkMode = 0, Offset<UnionCell> WalkSpeedOffset = default(Offset<UnionCell>), Offset<UnionCell> WalkSpeedPVPOffset = default(Offset<UnionCell>), int SummonRestrainEffectID = 0, int CostMode = 0, Offset<UnionCell> HPCostPercentOffset = default(Offset<UnionCell>), Offset<UnionCell> HPCostOffset = default(Offset<UnionCell>), Offset<UnionCell> MPCostOffset = default(Offset<UnionCell>), Offset<UnionCell> CrystalCostOffset = default(Offset<UnionCell>), int SpellTime = 0, int SpellTimePVP = 0, Offset<UnionCell> RefreshTimeOffset = default(Offset<UnionCell>), Offset<UnionCell> InitCDOffset = default(Offset<UnionCell>), Offset<UnionCell> MinCDOffset = default(Offset<UnionCell>), Offset<UnionCell> RefreshTimePVPOffset = default(Offset<UnionCell>), Offset<UnionCell> InitCDPVPOffset = default(Offset<UnionCell>), Offset<UnionCell> MinCDPVPOffset = default(Offset<UnionCell>), SkillTable.eSkillTarget SkillTarget = SkillTable.eSkillTarget.SkillTarget_None, int SkillAttri = 0, int IsPreJob = 0, int IsStudy = 0, int LevelLimit = 0, int LevelLimitAmend = 0, int TopLevelLimit = 0, int TopLevel = 0, VectorOffset PreSkillsOffset = default(VectorOffset), VectorOffset PreSkillsLevelOffset = default(VectorOffset), VectorOffset PostSkillsOffset = default(VectorOffset), VectorOffset NeedLevelOffset = default(VectorOffset), int LearnSPCost = 0, int LearnGoodCost = 0, int IsForceSync = 0, int BindButtonIndex = 0, int PassiveSkillBtnIndex = 0, StringOffset SkillSpeechOffset = default(StringOffset), int SkillSpeechRand = 0, StringOffset SkillDealTextOffset = default(StringOffset), int SkillDealTextDuration = 0, int SwitchSkillID = 0, int RangeX = 0, int RangeY = 0, int BackRangeX = 0, int Weight = 0, StringOffset AttackInfoOffset = default(StringOffset), Offset<UnionCell> ZscaleOffset = default(Offset<UnionCell>), Offset<UnionCell> PVPZscaleOffset = default(Offset<UnionCell>), int SkillOperation = 0, int SkillOpTarget = 0, StringOffset SkillOpVarOffset = default(StringOffset), Offset<UnionCell> SkillOpValueOffset = default(Offset<UnionCell>), VectorOffset SkillOpSkillIDsOffset = default(VectorOffset), int NeedWeaponType = 0, StringOffset DescriptionAOffset = default(StringOffset), VectorOffset ValueAOffset = default(VectorOffset), StringOffset DescriptionBOffset = default(StringOffset), VectorOffset ValueBOffset = default(VectorOffset), StringOffset DescriptionCOffset = default(StringOffset), VectorOffset ValueCOffset = default(VectorOffset), StringOffset DescriptionDOffset = default(StringOffset), VectorOffset ValueDOffset = default(VectorOffset), StringOffset DescriptionEOffset = default(StringOffset), VectorOffset ValueEOffset = default(VectorOffset), StringOffset DescriptionFOffset = default(StringOffset), VectorOffset ValueFOffset = default(VectorOffset), StringOffset DescriptionGOffset = default(StringOffset), VectorOffset ValueGOffset = default(VectorOffset))
		{
			builder.StartObject(109);
			SkillTable.AddValueG(builder, ValueGOffset);
			SkillTable.AddDescriptionG(builder, DescriptionGOffset);
			SkillTable.AddValueF(builder, ValueFOffset);
			SkillTable.AddDescriptionF(builder, DescriptionFOffset);
			SkillTable.AddValueE(builder, ValueEOffset);
			SkillTable.AddDescriptionE(builder, DescriptionEOffset);
			SkillTable.AddValueD(builder, ValueDOffset);
			SkillTable.AddDescriptionD(builder, DescriptionDOffset);
			SkillTable.AddValueC(builder, ValueCOffset);
			SkillTable.AddDescriptionC(builder, DescriptionCOffset);
			SkillTable.AddValueB(builder, ValueBOffset);
			SkillTable.AddDescriptionB(builder, DescriptionBOffset);
			SkillTable.AddValueA(builder, ValueAOffset);
			SkillTable.AddDescriptionA(builder, DescriptionAOffset);
			SkillTable.AddNeedWeaponType(builder, NeedWeaponType);
			SkillTable.AddSkillOpSkillIDs(builder, SkillOpSkillIDsOffset);
			SkillTable.AddSkillOpValue(builder, SkillOpValueOffset);
			SkillTable.AddSkillOpVar(builder, SkillOpVarOffset);
			SkillTable.AddSkillOpTarget(builder, SkillOpTarget);
			SkillTable.AddSkillOperation(builder, SkillOperation);
			SkillTable.AddPVPZscale(builder, PVPZscaleOffset);
			SkillTable.AddZscale(builder, ZscaleOffset);
			SkillTable.AddAttackInfo(builder, AttackInfoOffset);
			SkillTable.AddWeight(builder, Weight);
			SkillTable.AddBackRangeX(builder, BackRangeX);
			SkillTable.AddRangeY(builder, RangeY);
			SkillTable.AddRangeX(builder, RangeX);
			SkillTable.AddSwitchSkillID(builder, SwitchSkillID);
			SkillTable.AddSkillDealTextDuration(builder, SkillDealTextDuration);
			SkillTable.AddSkillDealText(builder, SkillDealTextOffset);
			SkillTable.AddSkillSpeechRand(builder, SkillSpeechRand);
			SkillTable.AddSkillSpeech(builder, SkillSpeechOffset);
			SkillTable.AddPassiveSkillBtnIndex(builder, PassiveSkillBtnIndex);
			SkillTable.AddBindButtonIndex(builder, BindButtonIndex);
			SkillTable.AddIsForceSync(builder, IsForceSync);
			SkillTable.AddLearnGoodCost(builder, LearnGoodCost);
			SkillTable.AddLearnSPCost(builder, LearnSPCost);
			SkillTable.AddNeedLevel(builder, NeedLevelOffset);
			SkillTable.AddPostSkills(builder, PostSkillsOffset);
			SkillTable.AddPreSkillsLevel(builder, PreSkillsLevelOffset);
			SkillTable.AddPreSkills(builder, PreSkillsOffset);
			SkillTable.AddTopLevel(builder, TopLevel);
			SkillTable.AddTopLevelLimit(builder, TopLevelLimit);
			SkillTable.AddLevelLimitAmend(builder, LevelLimitAmend);
			SkillTable.AddLevelLimit(builder, LevelLimit);
			SkillTable.AddIsStudy(builder, IsStudy);
			SkillTable.AddIsPreJob(builder, IsPreJob);
			SkillTable.AddSkillAttri(builder, SkillAttri);
			SkillTable.AddSkillTarget(builder, SkillTarget);
			SkillTable.AddMinCDPVP(builder, MinCDPVPOffset);
			SkillTable.AddInitCDPVP(builder, InitCDPVPOffset);
			SkillTable.AddRefreshTimePVP(builder, RefreshTimePVPOffset);
			SkillTable.AddMinCD(builder, MinCDOffset);
			SkillTable.AddInitCD(builder, InitCDOffset);
			SkillTable.AddRefreshTime(builder, RefreshTimeOffset);
			SkillTable.AddSpellTimePVP(builder, SpellTimePVP);
			SkillTable.AddSpellTime(builder, SpellTime);
			SkillTable.AddCrystalCost(builder, CrystalCostOffset);
			SkillTable.AddMPCost(builder, MPCostOffset);
			SkillTable.AddHPCost(builder, HPCostOffset);
			SkillTable.AddHPCostPercent(builder, HPCostPercentOffset);
			SkillTable.AddCostMode(builder, CostMode);
			SkillTable.AddSummonRestrainEffectID(builder, SummonRestrainEffectID);
			SkillTable.AddWalkSpeedPVP(builder, WalkSpeedPVPOffset);
			SkillTable.AddWalkSpeed(builder, WalkSpeedOffset);
			SkillTable.AddWalkMode(builder, WalkMode);
			SkillTable.AddHideSpellBar(builder, HideSpellBar);
			SkillTable.AddHitInterruptSkills(builder, HitInterruptSkillsOffset);
			SkillTable.AddInterruptSkillsPVP(builder, InterruptSkillsPVPOffset);
			SkillTable.AddInterruptSkills(builder, InterruptSkillsOffset);
			SkillTable.AddMechismIDsPVP(builder, MechismIDsPVPOffset);
			SkillTable.AddMechismIDs(builder, MechismIDsOffset);
			SkillTable.AddBuffInfoIDsPVP(builder, BuffInfoIDsPVPOffset);
			SkillTable.AddBuffInfoIDs(builder, BuffInfoIDsOffset);
			SkillTable.AddHitEffectIDsPVP(builder, HitEffectIDsPVPOffset);
			SkillTable.AddHitEffectIDs(builder, HitEffectIDsOffset);
			SkillTable.AddProbability(builder, ProbabilityOffset);
			SkillTable.AddLowHpPercent(builder, LowHpPercentOffset);
			SkillTable.AddPreCondition(builder, PreConditionOffset);
			SkillTable.AddAttackScalePVP(builder, AttackScalePVP);
			SkillTable.AddCanUseInPVP(builder, CanUseInPVP);
			SkillTable.AddIsAttackCombo(builder, IsAttackCombo);
			SkillTable.AddCDPhase(builder, CDPhase);
			SkillTable.AddCanSwithWeapon(builder, CanSwithWeapon);
			SkillTable.AddWatchBuffID(builder, WatchBuffID);
			SkillTable.AddPressBackJumpCancel(builder, PressBackJumpCancel);
			SkillTable.AddSkillPressType(builder, SkillPressType);
			SkillTable.AddIsRunAttack(builder, IsRunAttack);
			SkillTable.AddIsQTE(builder, IsQTE);
			SkillTable.AddIsBuff(builder, IsBuff);
			SkillTable.AddSkillEffect(builder, SkillEffectOffset);
			SkillTable.AddMasterSkillID(builder, MasterSkillID);
			SkillTable.AddSkillCategory(builder, SkillCategory);
			SkillTable.AddSkillType(builder, SkillType);
			SkillTable.AddPhaseRelatedSpeed(builder, PhaseRelatedSpeed);
			SkillTable.AddSpeedEffectType(builder, SpeedEffectType);
			SkillTable.AddSpeed(builder, Speed);
			SkillTable.AddJobID(builder, JobIDOffset);
			SkillTable.AddIcon(builder, IconOffset);
			SkillTable.AddSmallIcon(builder, SmallIconOffset);
			SkillTable.AddEnglishName(builder, EnglishNameOffset);
			SkillTable.AddName(builder, NameOffset);
			SkillTable.AddID(builder, ID);
			SkillTable.AddIsWalkEnable(builder, IsWalkEnable);
			SkillTable.AddIsChargeEnable(builder, IsChargeEnable);
			SkillTable.AddIsCanDispose(builder, IsCanDispose);
			SkillTable.AddIsCanCancel(builder, IsCanCancel);
			SkillTable.AddIsForce(builder, IsForce);
			SkillTable.AddIsResetCamera(builder, IsResetCamera);
			return SkillTable.EndSkillTable(builder);
		}

		// Token: 0x06004E25 RID: 20005 RVA: 0x000F443C File Offset: 0x000F283C
		public static void StartSkillTable(FlatBufferBuilder builder)
		{
			builder.StartObject(109);
		}

		// Token: 0x06004E26 RID: 20006 RVA: 0x000F4446 File Offset: 0x000F2846
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004E27 RID: 20007 RVA: 0x000F4451 File Offset: 0x000F2851
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004E28 RID: 20008 RVA: 0x000F4462 File Offset: 0x000F2862
		public static void AddEnglishName(FlatBufferBuilder builder, StringOffset EnglishNameOffset)
		{
			builder.AddOffset(2, EnglishNameOffset.Value, 0);
		}

		// Token: 0x06004E29 RID: 20009 RVA: 0x000F4473 File Offset: 0x000F2873
		public static void AddSmallIcon(FlatBufferBuilder builder, StringOffset SmallIconOffset)
		{
			builder.AddOffset(3, SmallIconOffset.Value, 0);
		}

		// Token: 0x06004E2A RID: 20010 RVA: 0x000F4484 File Offset: 0x000F2884
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(4, IconOffset.Value, 0);
		}

		// Token: 0x06004E2B RID: 20011 RVA: 0x000F4495 File Offset: 0x000F2895
		public static void AddJobID(FlatBufferBuilder builder, VectorOffset JobIDOffset)
		{
			builder.AddOffset(5, JobIDOffset.Value, 0);
		}

		// Token: 0x06004E2C RID: 20012 RVA: 0x000F44A8 File Offset: 0x000F28A8
		public static VectorOffset CreateJobIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E2D RID: 20013 RVA: 0x000F44E5 File Offset: 0x000F28E5
		public static void StartJobIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E2E RID: 20014 RVA: 0x000F44F0 File Offset: 0x000F28F0
		public static void AddSpeed(FlatBufferBuilder builder, int Speed)
		{
			builder.AddInt(6, Speed, 0);
		}

		// Token: 0x06004E2F RID: 20015 RVA: 0x000F44FB File Offset: 0x000F28FB
		public static void AddSpeedEffectType(FlatBufferBuilder builder, int SpeedEffectType)
		{
			builder.AddInt(7, SpeedEffectType, 0);
		}

		// Token: 0x06004E30 RID: 20016 RVA: 0x000F4506 File Offset: 0x000F2906
		public static void AddPhaseRelatedSpeed(FlatBufferBuilder builder, int PhaseRelatedSpeed)
		{
			builder.AddInt(8, PhaseRelatedSpeed, 0);
		}

		// Token: 0x06004E31 RID: 20017 RVA: 0x000F4511 File Offset: 0x000F2911
		public static void AddSkillType(FlatBufferBuilder builder, SkillTable.eSkillType SkillType)
		{
			builder.AddInt(9, (int)SkillType, 0);
		}

		// Token: 0x06004E32 RID: 20018 RVA: 0x000F451D File Offset: 0x000F291D
		public static void AddSkillCategory(FlatBufferBuilder builder, int SkillCategory)
		{
			builder.AddInt(10, SkillCategory, 0);
		}

		// Token: 0x06004E33 RID: 20019 RVA: 0x000F4529 File Offset: 0x000F2929
		public static void AddMasterSkillID(FlatBufferBuilder builder, int MasterSkillID)
		{
			builder.AddInt(11, MasterSkillID, 0);
		}

		// Token: 0x06004E34 RID: 20020 RVA: 0x000F4535 File Offset: 0x000F2935
		public static void AddSkillEffect(FlatBufferBuilder builder, VectorOffset SkillEffectOffset)
		{
			builder.AddOffset(12, SkillEffectOffset.Value, 0);
		}

		// Token: 0x06004E35 RID: 20021 RVA: 0x000F4548 File Offset: 0x000F2948
		public static VectorOffset CreateSkillEffectVector(FlatBufferBuilder builder, SkillTable.eSkillEffect[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E36 RID: 20022 RVA: 0x000F4585 File Offset: 0x000F2985
		public static void StartSkillEffectVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E37 RID: 20023 RVA: 0x000F4590 File Offset: 0x000F2990
		public static void AddIsBuff(FlatBufferBuilder builder, int IsBuff)
		{
			builder.AddInt(13, IsBuff, 0);
		}

		// Token: 0x06004E38 RID: 20024 RVA: 0x000F459C File Offset: 0x000F299C
		public static void AddIsQTE(FlatBufferBuilder builder, int IsQTE)
		{
			builder.AddInt(14, IsQTE, 0);
		}

		// Token: 0x06004E39 RID: 20025 RVA: 0x000F45A8 File Offset: 0x000F29A8
		public static void AddIsRunAttack(FlatBufferBuilder builder, int IsRunAttack)
		{
			builder.AddInt(15, IsRunAttack, 0);
		}

		// Token: 0x06004E3A RID: 20026 RVA: 0x000F45B4 File Offset: 0x000F29B4
		public static void AddSkillPressType(FlatBufferBuilder builder, int SkillPressType)
		{
			builder.AddInt(16, SkillPressType, 0);
		}

		// Token: 0x06004E3B RID: 20027 RVA: 0x000F45C0 File Offset: 0x000F29C0
		public static void AddPressBackJumpCancel(FlatBufferBuilder builder, int PressBackJumpCancel)
		{
			builder.AddInt(17, PressBackJumpCancel, 0);
		}

		// Token: 0x06004E3C RID: 20028 RVA: 0x000F45CC File Offset: 0x000F29CC
		public static void AddWatchBuffID(FlatBufferBuilder builder, int WatchBuffID)
		{
			builder.AddInt(18, WatchBuffID, 0);
		}

		// Token: 0x06004E3D RID: 20029 RVA: 0x000F45D8 File Offset: 0x000F29D8
		public static void AddCanSwithWeapon(FlatBufferBuilder builder, int CanSwithWeapon)
		{
			builder.AddInt(19, CanSwithWeapon, 0);
		}

		// Token: 0x06004E3E RID: 20030 RVA: 0x000F45E4 File Offset: 0x000F29E4
		public static void AddCDPhase(FlatBufferBuilder builder, int CDPhase)
		{
			builder.AddInt(20, CDPhase, 0);
		}

		// Token: 0x06004E3F RID: 20031 RVA: 0x000F45F0 File Offset: 0x000F29F0
		public static void AddIsAttackCombo(FlatBufferBuilder builder, int IsAttackCombo)
		{
			builder.AddInt(21, IsAttackCombo, 0);
		}

		// Token: 0x06004E40 RID: 20032 RVA: 0x000F45FC File Offset: 0x000F29FC
		public static void AddCanUseInPVP(FlatBufferBuilder builder, int CanUseInPVP)
		{
			builder.AddInt(22, CanUseInPVP, 0);
		}

		// Token: 0x06004E41 RID: 20033 RVA: 0x000F4608 File Offset: 0x000F2A08
		public static void AddAttackScalePVP(FlatBufferBuilder builder, int AttackScalePVP)
		{
			builder.AddInt(23, AttackScalePVP, 0);
		}

		// Token: 0x06004E42 RID: 20034 RVA: 0x000F4614 File Offset: 0x000F2A14
		public static void AddPreCondition(FlatBufferBuilder builder, VectorOffset PreConditionOffset)
		{
			builder.AddOffset(24, PreConditionOffset.Value, 0);
		}

		// Token: 0x06004E43 RID: 20035 RVA: 0x000F4628 File Offset: 0x000F2A28
		public static VectorOffset CreatePreConditionVector(FlatBufferBuilder builder, SkillTable.ePreCondition[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E44 RID: 20036 RVA: 0x000F4665 File Offset: 0x000F2A65
		public static void StartPreConditionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E45 RID: 20037 RVA: 0x000F4670 File Offset: 0x000F2A70
		public static void AddLowHpPercent(FlatBufferBuilder builder, VectorOffset LowHpPercentOffset)
		{
			builder.AddOffset(25, LowHpPercentOffset.Value, 0);
		}

		// Token: 0x06004E46 RID: 20038 RVA: 0x000F4684 File Offset: 0x000F2A84
		public static VectorOffset CreateLowHpPercentVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E47 RID: 20039 RVA: 0x000F46C1 File Offset: 0x000F2AC1
		public static void StartLowHpPercentVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E48 RID: 20040 RVA: 0x000F46CC File Offset: 0x000F2ACC
		public static void AddProbability(FlatBufferBuilder builder, Offset<UnionCell> ProbabilityOffset)
		{
			builder.AddOffset(26, ProbabilityOffset.Value, 0);
		}

		// Token: 0x06004E49 RID: 20041 RVA: 0x000F46DE File Offset: 0x000F2ADE
		public static void AddHitEffectIDs(FlatBufferBuilder builder, VectorOffset HitEffectIDsOffset)
		{
			builder.AddOffset(27, HitEffectIDsOffset.Value, 0);
		}

		// Token: 0x06004E4A RID: 20042 RVA: 0x000F46F0 File Offset: 0x000F2AF0
		public static VectorOffset CreateHitEffectIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E4B RID: 20043 RVA: 0x000F472D File Offset: 0x000F2B2D
		public static void StartHitEffectIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E4C RID: 20044 RVA: 0x000F4738 File Offset: 0x000F2B38
		public static void AddHitEffectIDsPVP(FlatBufferBuilder builder, VectorOffset HitEffectIDsPVPOffset)
		{
			builder.AddOffset(28, HitEffectIDsPVPOffset.Value, 0);
		}

		// Token: 0x06004E4D RID: 20045 RVA: 0x000F474C File Offset: 0x000F2B4C
		public static VectorOffset CreateHitEffectIDsPVPVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E4E RID: 20046 RVA: 0x000F4789 File Offset: 0x000F2B89
		public static void StartHitEffectIDsPVPVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E4F RID: 20047 RVA: 0x000F4794 File Offset: 0x000F2B94
		public static void AddBuffInfoIDs(FlatBufferBuilder builder, VectorOffset BuffInfoIDsOffset)
		{
			builder.AddOffset(29, BuffInfoIDsOffset.Value, 0);
		}

		// Token: 0x06004E50 RID: 20048 RVA: 0x000F47A8 File Offset: 0x000F2BA8
		public static VectorOffset CreateBuffInfoIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E51 RID: 20049 RVA: 0x000F47E5 File Offset: 0x000F2BE5
		public static void StartBuffInfoIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E52 RID: 20050 RVA: 0x000F47F0 File Offset: 0x000F2BF0
		public static void AddBuffInfoIDsPVP(FlatBufferBuilder builder, VectorOffset BuffInfoIDsPVPOffset)
		{
			builder.AddOffset(30, BuffInfoIDsPVPOffset.Value, 0);
		}

		// Token: 0x06004E53 RID: 20051 RVA: 0x000F4804 File Offset: 0x000F2C04
		public static VectorOffset CreateBuffInfoIDsPVPVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E54 RID: 20052 RVA: 0x000F4841 File Offset: 0x000F2C41
		public static void StartBuffInfoIDsPVPVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E55 RID: 20053 RVA: 0x000F484C File Offset: 0x000F2C4C
		public static void AddMechismIDs(FlatBufferBuilder builder, VectorOffset MechismIDsOffset)
		{
			builder.AddOffset(31, MechismIDsOffset.Value, 0);
		}

		// Token: 0x06004E56 RID: 20054 RVA: 0x000F4860 File Offset: 0x000F2C60
		public static VectorOffset CreateMechismIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E57 RID: 20055 RVA: 0x000F489D File Offset: 0x000F2C9D
		public static void StartMechismIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E58 RID: 20056 RVA: 0x000F48A8 File Offset: 0x000F2CA8
		public static void AddMechismIDsPVP(FlatBufferBuilder builder, VectorOffset MechismIDsPVPOffset)
		{
			builder.AddOffset(32, MechismIDsPVPOffset.Value, 0);
		}

		// Token: 0x06004E59 RID: 20057 RVA: 0x000F48BC File Offset: 0x000F2CBC
		public static VectorOffset CreateMechismIDsPVPVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E5A RID: 20058 RVA: 0x000F48F9 File Offset: 0x000F2CF9
		public static void StartMechismIDsPVPVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E5B RID: 20059 RVA: 0x000F4904 File Offset: 0x000F2D04
		public static void AddInterruptSkills(FlatBufferBuilder builder, StringOffset InterruptSkillsOffset)
		{
			builder.AddOffset(33, InterruptSkillsOffset.Value, 0);
		}

		// Token: 0x06004E5C RID: 20060 RVA: 0x000F4916 File Offset: 0x000F2D16
		public static void AddInterruptSkillsPVP(FlatBufferBuilder builder, StringOffset InterruptSkillsPVPOffset)
		{
			builder.AddOffset(34, InterruptSkillsPVPOffset.Value, 0);
		}

		// Token: 0x06004E5D RID: 20061 RVA: 0x000F4928 File Offset: 0x000F2D28
		public static void AddHitInterruptSkills(FlatBufferBuilder builder, VectorOffset HitInterruptSkillsOffset)
		{
			builder.AddOffset(35, HitInterruptSkillsOffset.Value, 0);
		}

		// Token: 0x06004E5E RID: 20062 RVA: 0x000F493C File Offset: 0x000F2D3C
		public static VectorOffset CreateHitInterruptSkillsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E5F RID: 20063 RVA: 0x000F4979 File Offset: 0x000F2D79
		public static void StartHitInterruptSkillsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E60 RID: 20064 RVA: 0x000F4984 File Offset: 0x000F2D84
		public static void AddIsResetCamera(FlatBufferBuilder builder, bool IsResetCamera)
		{
			builder.AddBool(36, IsResetCamera, false);
		}

		// Token: 0x06004E61 RID: 20065 RVA: 0x000F4990 File Offset: 0x000F2D90
		public static void AddIsForce(FlatBufferBuilder builder, bool IsForce)
		{
			builder.AddBool(37, IsForce, false);
		}

		// Token: 0x06004E62 RID: 20066 RVA: 0x000F499C File Offset: 0x000F2D9C
		public static void AddIsCanCancel(FlatBufferBuilder builder, bool IsCanCancel)
		{
			builder.AddBool(38, IsCanCancel, false);
		}

		// Token: 0x06004E63 RID: 20067 RVA: 0x000F49A8 File Offset: 0x000F2DA8
		public static void AddIsCanDispose(FlatBufferBuilder builder, bool IsCanDispose)
		{
			builder.AddBool(39, IsCanDispose, false);
		}

		// Token: 0x06004E64 RID: 20068 RVA: 0x000F49B4 File Offset: 0x000F2DB4
		public static void AddIsChargeEnable(FlatBufferBuilder builder, bool IsChargeEnable)
		{
			builder.AddBool(40, IsChargeEnable, false);
		}

		// Token: 0x06004E65 RID: 20069 RVA: 0x000F49C0 File Offset: 0x000F2DC0
		public static void AddHideSpellBar(FlatBufferBuilder builder, int HideSpellBar)
		{
			builder.AddInt(41, HideSpellBar, 0);
		}

		// Token: 0x06004E66 RID: 20070 RVA: 0x000F49CC File Offset: 0x000F2DCC
		public static void AddIsWalkEnable(FlatBufferBuilder builder, bool IsWalkEnable)
		{
			builder.AddBool(42, IsWalkEnable, false);
		}

		// Token: 0x06004E67 RID: 20071 RVA: 0x000F49D8 File Offset: 0x000F2DD8
		public static void AddWalkMode(FlatBufferBuilder builder, int WalkMode)
		{
			builder.AddInt(43, WalkMode, 0);
		}

		// Token: 0x06004E68 RID: 20072 RVA: 0x000F49E4 File Offset: 0x000F2DE4
		public static void AddWalkSpeed(FlatBufferBuilder builder, Offset<UnionCell> WalkSpeedOffset)
		{
			builder.AddOffset(44, WalkSpeedOffset.Value, 0);
		}

		// Token: 0x06004E69 RID: 20073 RVA: 0x000F49F6 File Offset: 0x000F2DF6
		public static void AddWalkSpeedPVP(FlatBufferBuilder builder, Offset<UnionCell> WalkSpeedPVPOffset)
		{
			builder.AddOffset(45, WalkSpeedPVPOffset.Value, 0);
		}

		// Token: 0x06004E6A RID: 20074 RVA: 0x000F4A08 File Offset: 0x000F2E08
		public static void AddSummonRestrainEffectID(FlatBufferBuilder builder, int SummonRestrainEffectID)
		{
			builder.AddInt(46, SummonRestrainEffectID, 0);
		}

		// Token: 0x06004E6B RID: 20075 RVA: 0x000F4A14 File Offset: 0x000F2E14
		public static void AddCostMode(FlatBufferBuilder builder, int CostMode)
		{
			builder.AddInt(47, CostMode, 0);
		}

		// Token: 0x06004E6C RID: 20076 RVA: 0x000F4A20 File Offset: 0x000F2E20
		public static void AddHPCostPercent(FlatBufferBuilder builder, Offset<UnionCell> HPCostPercentOffset)
		{
			builder.AddOffset(48, HPCostPercentOffset.Value, 0);
		}

		// Token: 0x06004E6D RID: 20077 RVA: 0x000F4A32 File Offset: 0x000F2E32
		public static void AddHPCost(FlatBufferBuilder builder, Offset<UnionCell> HPCostOffset)
		{
			builder.AddOffset(49, HPCostOffset.Value, 0);
		}

		// Token: 0x06004E6E RID: 20078 RVA: 0x000F4A44 File Offset: 0x000F2E44
		public static void AddMPCost(FlatBufferBuilder builder, Offset<UnionCell> MPCostOffset)
		{
			builder.AddOffset(50, MPCostOffset.Value, 0);
		}

		// Token: 0x06004E6F RID: 20079 RVA: 0x000F4A56 File Offset: 0x000F2E56
		public static void AddCrystalCost(FlatBufferBuilder builder, Offset<UnionCell> CrystalCostOffset)
		{
			builder.AddOffset(51, CrystalCostOffset.Value, 0);
		}

		// Token: 0x06004E70 RID: 20080 RVA: 0x000F4A68 File Offset: 0x000F2E68
		public static void AddSpellTime(FlatBufferBuilder builder, int SpellTime)
		{
			builder.AddInt(52, SpellTime, 0);
		}

		// Token: 0x06004E71 RID: 20081 RVA: 0x000F4A74 File Offset: 0x000F2E74
		public static void AddSpellTimePVP(FlatBufferBuilder builder, int SpellTimePVP)
		{
			builder.AddInt(53, SpellTimePVP, 0);
		}

		// Token: 0x06004E72 RID: 20082 RVA: 0x000F4A80 File Offset: 0x000F2E80
		public static void AddRefreshTime(FlatBufferBuilder builder, Offset<UnionCell> RefreshTimeOffset)
		{
			builder.AddOffset(54, RefreshTimeOffset.Value, 0);
		}

		// Token: 0x06004E73 RID: 20083 RVA: 0x000F4A92 File Offset: 0x000F2E92
		public static void AddInitCD(FlatBufferBuilder builder, Offset<UnionCell> InitCDOffset)
		{
			builder.AddOffset(55, InitCDOffset.Value, 0);
		}

		// Token: 0x06004E74 RID: 20084 RVA: 0x000F4AA4 File Offset: 0x000F2EA4
		public static void AddMinCD(FlatBufferBuilder builder, Offset<UnionCell> MinCDOffset)
		{
			builder.AddOffset(56, MinCDOffset.Value, 0);
		}

		// Token: 0x06004E75 RID: 20085 RVA: 0x000F4AB6 File Offset: 0x000F2EB6
		public static void AddRefreshTimePVP(FlatBufferBuilder builder, Offset<UnionCell> RefreshTimePVPOffset)
		{
			builder.AddOffset(57, RefreshTimePVPOffset.Value, 0);
		}

		// Token: 0x06004E76 RID: 20086 RVA: 0x000F4AC8 File Offset: 0x000F2EC8
		public static void AddInitCDPVP(FlatBufferBuilder builder, Offset<UnionCell> InitCDPVPOffset)
		{
			builder.AddOffset(58, InitCDPVPOffset.Value, 0);
		}

		// Token: 0x06004E77 RID: 20087 RVA: 0x000F4ADA File Offset: 0x000F2EDA
		public static void AddMinCDPVP(FlatBufferBuilder builder, Offset<UnionCell> MinCDPVPOffset)
		{
			builder.AddOffset(59, MinCDPVPOffset.Value, 0);
		}

		// Token: 0x06004E78 RID: 20088 RVA: 0x000F4AEC File Offset: 0x000F2EEC
		public static void AddSkillTarget(FlatBufferBuilder builder, SkillTable.eSkillTarget SkillTarget)
		{
			builder.AddInt(60, (int)SkillTarget, 0);
		}

		// Token: 0x06004E79 RID: 20089 RVA: 0x000F4AF8 File Offset: 0x000F2EF8
		public static void AddSkillAttri(FlatBufferBuilder builder, int SkillAttri)
		{
			builder.AddInt(61, SkillAttri, 0);
		}

		// Token: 0x06004E7A RID: 20090 RVA: 0x000F4B04 File Offset: 0x000F2F04
		public static void AddIsPreJob(FlatBufferBuilder builder, int IsPreJob)
		{
			builder.AddInt(62, IsPreJob, 0);
		}

		// Token: 0x06004E7B RID: 20091 RVA: 0x000F4B10 File Offset: 0x000F2F10
		public static void AddIsStudy(FlatBufferBuilder builder, int IsStudy)
		{
			builder.AddInt(63, IsStudy, 0);
		}

		// Token: 0x06004E7C RID: 20092 RVA: 0x000F4B1C File Offset: 0x000F2F1C
		public static void AddLevelLimit(FlatBufferBuilder builder, int LevelLimit)
		{
			builder.AddInt(64, LevelLimit, 0);
		}

		// Token: 0x06004E7D RID: 20093 RVA: 0x000F4B28 File Offset: 0x000F2F28
		public static void AddLevelLimitAmend(FlatBufferBuilder builder, int LevelLimitAmend)
		{
			builder.AddInt(65, LevelLimitAmend, 0);
		}

		// Token: 0x06004E7E RID: 20094 RVA: 0x000F4B34 File Offset: 0x000F2F34
		public static void AddTopLevelLimit(FlatBufferBuilder builder, int TopLevelLimit)
		{
			builder.AddInt(66, TopLevelLimit, 0);
		}

		// Token: 0x06004E7F RID: 20095 RVA: 0x000F4B40 File Offset: 0x000F2F40
		public static void AddTopLevel(FlatBufferBuilder builder, int TopLevel)
		{
			builder.AddInt(67, TopLevel, 0);
		}

		// Token: 0x06004E80 RID: 20096 RVA: 0x000F4B4C File Offset: 0x000F2F4C
		public static void AddPreSkills(FlatBufferBuilder builder, VectorOffset PreSkillsOffset)
		{
			builder.AddOffset(68, PreSkillsOffset.Value, 0);
		}

		// Token: 0x06004E81 RID: 20097 RVA: 0x000F4B60 File Offset: 0x000F2F60
		public static VectorOffset CreatePreSkillsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E82 RID: 20098 RVA: 0x000F4B9D File Offset: 0x000F2F9D
		public static void StartPreSkillsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E83 RID: 20099 RVA: 0x000F4BA8 File Offset: 0x000F2FA8
		public static void AddPreSkillsLevel(FlatBufferBuilder builder, VectorOffset PreSkillsLevelOffset)
		{
			builder.AddOffset(69, PreSkillsLevelOffset.Value, 0);
		}

		// Token: 0x06004E84 RID: 20100 RVA: 0x000F4BBC File Offset: 0x000F2FBC
		public static VectorOffset CreatePreSkillsLevelVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E85 RID: 20101 RVA: 0x000F4BF9 File Offset: 0x000F2FF9
		public static void StartPreSkillsLevelVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E86 RID: 20102 RVA: 0x000F4C04 File Offset: 0x000F3004
		public static void AddPostSkills(FlatBufferBuilder builder, VectorOffset PostSkillsOffset)
		{
			builder.AddOffset(70, PostSkillsOffset.Value, 0);
		}

		// Token: 0x06004E87 RID: 20103 RVA: 0x000F4C18 File Offset: 0x000F3018
		public static VectorOffset CreatePostSkillsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E88 RID: 20104 RVA: 0x000F4C55 File Offset: 0x000F3055
		public static void StartPostSkillsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E89 RID: 20105 RVA: 0x000F4C60 File Offset: 0x000F3060
		public static void AddNeedLevel(FlatBufferBuilder builder, VectorOffset NeedLevelOffset)
		{
			builder.AddOffset(71, NeedLevelOffset.Value, 0);
		}

		// Token: 0x06004E8A RID: 20106 RVA: 0x000F4C74 File Offset: 0x000F3074
		public static VectorOffset CreateNeedLevelVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004E8B RID: 20107 RVA: 0x000F4CB1 File Offset: 0x000F30B1
		public static void StartNeedLevelVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004E8C RID: 20108 RVA: 0x000F4CBC File Offset: 0x000F30BC
		public static void AddLearnSPCost(FlatBufferBuilder builder, int LearnSPCost)
		{
			builder.AddInt(72, LearnSPCost, 0);
		}

		// Token: 0x06004E8D RID: 20109 RVA: 0x000F4CC8 File Offset: 0x000F30C8
		public static void AddLearnGoodCost(FlatBufferBuilder builder, int LearnGoodCost)
		{
			builder.AddInt(73, LearnGoodCost, 0);
		}

		// Token: 0x06004E8E RID: 20110 RVA: 0x000F4CD4 File Offset: 0x000F30D4
		public static void AddIsForceSync(FlatBufferBuilder builder, int IsForceSync)
		{
			builder.AddInt(74, IsForceSync, 0);
		}

		// Token: 0x06004E8F RID: 20111 RVA: 0x000F4CE0 File Offset: 0x000F30E0
		public static void AddBindButtonIndex(FlatBufferBuilder builder, int BindButtonIndex)
		{
			builder.AddInt(75, BindButtonIndex, 0);
		}

		// Token: 0x06004E90 RID: 20112 RVA: 0x000F4CEC File Offset: 0x000F30EC
		public static void AddPassiveSkillBtnIndex(FlatBufferBuilder builder, int PassiveSkillBtnIndex)
		{
			builder.AddInt(76, PassiveSkillBtnIndex, 0);
		}

		// Token: 0x06004E91 RID: 20113 RVA: 0x000F4CF8 File Offset: 0x000F30F8
		public static void AddSkillSpeech(FlatBufferBuilder builder, StringOffset SkillSpeechOffset)
		{
			builder.AddOffset(77, SkillSpeechOffset.Value, 0);
		}

		// Token: 0x06004E92 RID: 20114 RVA: 0x000F4D0A File Offset: 0x000F310A
		public static void AddSkillSpeechRand(FlatBufferBuilder builder, int SkillSpeechRand)
		{
			builder.AddInt(78, SkillSpeechRand, 0);
		}

		// Token: 0x06004E93 RID: 20115 RVA: 0x000F4D16 File Offset: 0x000F3116
		public static void AddSkillDealText(FlatBufferBuilder builder, StringOffset SkillDealTextOffset)
		{
			builder.AddOffset(79, SkillDealTextOffset.Value, 0);
		}

		// Token: 0x06004E94 RID: 20116 RVA: 0x000F4D28 File Offset: 0x000F3128
		public static void AddSkillDealTextDuration(FlatBufferBuilder builder, int SkillDealTextDuration)
		{
			builder.AddInt(80, SkillDealTextDuration, 0);
		}

		// Token: 0x06004E95 RID: 20117 RVA: 0x000F4D34 File Offset: 0x000F3134
		public static void AddSwitchSkillID(FlatBufferBuilder builder, int SwitchSkillID)
		{
			builder.AddInt(81, SwitchSkillID, 0);
		}

		// Token: 0x06004E96 RID: 20118 RVA: 0x000F4D40 File Offset: 0x000F3140
		public static void AddRangeX(FlatBufferBuilder builder, int RangeX)
		{
			builder.AddInt(82, RangeX, 0);
		}

		// Token: 0x06004E97 RID: 20119 RVA: 0x000F4D4C File Offset: 0x000F314C
		public static void AddRangeY(FlatBufferBuilder builder, int RangeY)
		{
			builder.AddInt(83, RangeY, 0);
		}

		// Token: 0x06004E98 RID: 20120 RVA: 0x000F4D58 File Offset: 0x000F3158
		public static void AddBackRangeX(FlatBufferBuilder builder, int BackRangeX)
		{
			builder.AddInt(84, BackRangeX, 0);
		}

		// Token: 0x06004E99 RID: 20121 RVA: 0x000F4D64 File Offset: 0x000F3164
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(85, Weight, 0);
		}

		// Token: 0x06004E9A RID: 20122 RVA: 0x000F4D70 File Offset: 0x000F3170
		public static void AddAttackInfo(FlatBufferBuilder builder, StringOffset AttackInfoOffset)
		{
			builder.AddOffset(86, AttackInfoOffset.Value, 0);
		}

		// Token: 0x06004E9B RID: 20123 RVA: 0x000F4D82 File Offset: 0x000F3182
		public static void AddZscale(FlatBufferBuilder builder, Offset<UnionCell> ZscaleOffset)
		{
			builder.AddOffset(87, ZscaleOffset.Value, 0);
		}

		// Token: 0x06004E9C RID: 20124 RVA: 0x000F4D94 File Offset: 0x000F3194
		public static void AddPVPZscale(FlatBufferBuilder builder, Offset<UnionCell> PVPZscaleOffset)
		{
			builder.AddOffset(88, PVPZscaleOffset.Value, 0);
		}

		// Token: 0x06004E9D RID: 20125 RVA: 0x000F4DA6 File Offset: 0x000F31A6
		public static void AddSkillOperation(FlatBufferBuilder builder, int SkillOperation)
		{
			builder.AddInt(89, SkillOperation, 0);
		}

		// Token: 0x06004E9E RID: 20126 RVA: 0x000F4DB2 File Offset: 0x000F31B2
		public static void AddSkillOpTarget(FlatBufferBuilder builder, int SkillOpTarget)
		{
			builder.AddInt(90, SkillOpTarget, 0);
		}

		// Token: 0x06004E9F RID: 20127 RVA: 0x000F4DBE File Offset: 0x000F31BE
		public static void AddSkillOpVar(FlatBufferBuilder builder, StringOffset SkillOpVarOffset)
		{
			builder.AddOffset(91, SkillOpVarOffset.Value, 0);
		}

		// Token: 0x06004EA0 RID: 20128 RVA: 0x000F4DD0 File Offset: 0x000F31D0
		public static void AddSkillOpValue(FlatBufferBuilder builder, Offset<UnionCell> SkillOpValueOffset)
		{
			builder.AddOffset(92, SkillOpValueOffset.Value, 0);
		}

		// Token: 0x06004EA1 RID: 20129 RVA: 0x000F4DE2 File Offset: 0x000F31E2
		public static void AddSkillOpSkillIDs(FlatBufferBuilder builder, VectorOffset SkillOpSkillIDsOffset)
		{
			builder.AddOffset(93, SkillOpSkillIDsOffset.Value, 0);
		}

		// Token: 0x06004EA2 RID: 20130 RVA: 0x000F4DF4 File Offset: 0x000F31F4
		public static VectorOffset CreateSkillOpSkillIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004EA3 RID: 20131 RVA: 0x000F4E31 File Offset: 0x000F3231
		public static void StartSkillOpSkillIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004EA4 RID: 20132 RVA: 0x000F4E3C File Offset: 0x000F323C
		public static void AddNeedWeaponType(FlatBufferBuilder builder, int NeedWeaponType)
		{
			builder.AddInt(94, NeedWeaponType, 0);
		}

		// Token: 0x06004EA5 RID: 20133 RVA: 0x000F4E48 File Offset: 0x000F3248
		public static void AddDescriptionA(FlatBufferBuilder builder, StringOffset DescriptionAOffset)
		{
			builder.AddOffset(95, DescriptionAOffset.Value, 0);
		}

		// Token: 0x06004EA6 RID: 20134 RVA: 0x000F4E5A File Offset: 0x000F325A
		public static void AddValueA(FlatBufferBuilder builder, VectorOffset ValueAOffset)
		{
			builder.AddOffset(96, ValueAOffset.Value, 0);
		}

		// Token: 0x06004EA7 RID: 20135 RVA: 0x000F4E6C File Offset: 0x000F326C
		public static VectorOffset CreateValueAVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004EA8 RID: 20136 RVA: 0x000F4EB2 File Offset: 0x000F32B2
		public static void StartValueAVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004EA9 RID: 20137 RVA: 0x000F4EBD File Offset: 0x000F32BD
		public static void AddDescriptionB(FlatBufferBuilder builder, StringOffset DescriptionBOffset)
		{
			builder.AddOffset(97, DescriptionBOffset.Value, 0);
		}

		// Token: 0x06004EAA RID: 20138 RVA: 0x000F4ECF File Offset: 0x000F32CF
		public static void AddValueB(FlatBufferBuilder builder, VectorOffset ValueBOffset)
		{
			builder.AddOffset(98, ValueBOffset.Value, 0);
		}

		// Token: 0x06004EAB RID: 20139 RVA: 0x000F4EE4 File Offset: 0x000F32E4
		public static VectorOffset CreateValueBVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004EAC RID: 20140 RVA: 0x000F4F2A File Offset: 0x000F332A
		public static void StartValueBVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004EAD RID: 20141 RVA: 0x000F4F35 File Offset: 0x000F3335
		public static void AddDescriptionC(FlatBufferBuilder builder, StringOffset DescriptionCOffset)
		{
			builder.AddOffset(99, DescriptionCOffset.Value, 0);
		}

		// Token: 0x06004EAE RID: 20142 RVA: 0x000F4F47 File Offset: 0x000F3347
		public static void AddValueC(FlatBufferBuilder builder, VectorOffset ValueCOffset)
		{
			builder.AddOffset(100, ValueCOffset.Value, 0);
		}

		// Token: 0x06004EAF RID: 20143 RVA: 0x000F4F5C File Offset: 0x000F335C
		public static VectorOffset CreateValueCVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004EB0 RID: 20144 RVA: 0x000F4FA2 File Offset: 0x000F33A2
		public static void StartValueCVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004EB1 RID: 20145 RVA: 0x000F4FAD File Offset: 0x000F33AD
		public static void AddDescriptionD(FlatBufferBuilder builder, StringOffset DescriptionDOffset)
		{
			builder.AddOffset(101, DescriptionDOffset.Value, 0);
		}

		// Token: 0x06004EB2 RID: 20146 RVA: 0x000F4FBF File Offset: 0x000F33BF
		public static void AddValueD(FlatBufferBuilder builder, VectorOffset ValueDOffset)
		{
			builder.AddOffset(102, ValueDOffset.Value, 0);
		}

		// Token: 0x06004EB3 RID: 20147 RVA: 0x000F4FD4 File Offset: 0x000F33D4
		public static VectorOffset CreateValueDVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004EB4 RID: 20148 RVA: 0x000F501A File Offset: 0x000F341A
		public static void StartValueDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004EB5 RID: 20149 RVA: 0x000F5025 File Offset: 0x000F3425
		public static void AddDescriptionE(FlatBufferBuilder builder, StringOffset DescriptionEOffset)
		{
			builder.AddOffset(103, DescriptionEOffset.Value, 0);
		}

		// Token: 0x06004EB6 RID: 20150 RVA: 0x000F5037 File Offset: 0x000F3437
		public static void AddValueE(FlatBufferBuilder builder, VectorOffset ValueEOffset)
		{
			builder.AddOffset(104, ValueEOffset.Value, 0);
		}

		// Token: 0x06004EB7 RID: 20151 RVA: 0x000F504C File Offset: 0x000F344C
		public static VectorOffset CreateValueEVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004EB8 RID: 20152 RVA: 0x000F5092 File Offset: 0x000F3492
		public static void StartValueEVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004EB9 RID: 20153 RVA: 0x000F509D File Offset: 0x000F349D
		public static void AddDescriptionF(FlatBufferBuilder builder, StringOffset DescriptionFOffset)
		{
			builder.AddOffset(105, DescriptionFOffset.Value, 0);
		}

		// Token: 0x06004EBA RID: 20154 RVA: 0x000F50AF File Offset: 0x000F34AF
		public static void AddValueF(FlatBufferBuilder builder, VectorOffset ValueFOffset)
		{
			builder.AddOffset(106, ValueFOffset.Value, 0);
		}

		// Token: 0x06004EBB RID: 20155 RVA: 0x000F50C4 File Offset: 0x000F34C4
		public static VectorOffset CreateValueFVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004EBC RID: 20156 RVA: 0x000F510A File Offset: 0x000F350A
		public static void StartValueFVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004EBD RID: 20157 RVA: 0x000F5115 File Offset: 0x000F3515
		public static void AddDescriptionG(FlatBufferBuilder builder, StringOffset DescriptionGOffset)
		{
			builder.AddOffset(107, DescriptionGOffset.Value, 0);
		}

		// Token: 0x06004EBE RID: 20158 RVA: 0x000F5127 File Offset: 0x000F3527
		public static void AddValueG(FlatBufferBuilder builder, VectorOffset ValueGOffset)
		{
			builder.AddOffset(108, ValueGOffset.Value, 0);
		}

		// Token: 0x06004EBF RID: 20159 RVA: 0x000F513C File Offset: 0x000F353C
		public static VectorOffset CreateValueGVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004EC0 RID: 20160 RVA: 0x000F5182 File Offset: 0x000F3582
		public static void StartValueGVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004EC1 RID: 20161 RVA: 0x000F5190 File Offset: 0x000F3590
		public static Offset<SkillTable> EndSkillTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SkillTable>(value);
		}

		// Token: 0x06004EC2 RID: 20162 RVA: 0x000F51AA File Offset: 0x000F35AA
		public static void FinishSkillTableBuffer(FlatBufferBuilder builder, Offset<SkillTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B94 RID: 7060
		private Table __p = new Table();

		// Token: 0x04001B95 RID: 7061
		private FlatBufferArray<int> JobIDValue;

		// Token: 0x04001B96 RID: 7062
		private FlatBufferArray<SkillTable.eSkillEffect> SkillEffectValue;

		// Token: 0x04001B97 RID: 7063
		private FlatBufferArray<SkillTable.ePreCondition> PreConditionValue;

		// Token: 0x04001B98 RID: 7064
		private FlatBufferArray<int> LowHpPercentValue;

		// Token: 0x04001B99 RID: 7065
		private FlatBufferArray<int> HitEffectIDsValue;

		// Token: 0x04001B9A RID: 7066
		private FlatBufferArray<int> HitEffectIDsPVPValue;

		// Token: 0x04001B9B RID: 7067
		private FlatBufferArray<int> BuffInfoIDsValue;

		// Token: 0x04001B9C RID: 7068
		private FlatBufferArray<int> BuffInfoIDsPVPValue;

		// Token: 0x04001B9D RID: 7069
		private FlatBufferArray<int> MechismIDsValue;

		// Token: 0x04001B9E RID: 7070
		private FlatBufferArray<int> MechismIDsPVPValue;

		// Token: 0x04001B9F RID: 7071
		private FlatBufferArray<int> HitInterruptSkillsValue;

		// Token: 0x04001BA0 RID: 7072
		private FlatBufferArray<int> PreSkillsValue;

		// Token: 0x04001BA1 RID: 7073
		private FlatBufferArray<int> PreSkillsLevelValue;

		// Token: 0x04001BA2 RID: 7074
		private FlatBufferArray<int> PostSkillsValue;

		// Token: 0x04001BA3 RID: 7075
		private FlatBufferArray<int> NeedLevelValue;

		// Token: 0x04001BA4 RID: 7076
		private FlatBufferArray<int> SkillOpSkillIDsValue;

		// Token: 0x04001BA5 RID: 7077
		private FlatBufferArray<UnionCell> ValueAValue;

		// Token: 0x04001BA6 RID: 7078
		private FlatBufferArray<UnionCell> ValueBValue;

		// Token: 0x04001BA7 RID: 7079
		private FlatBufferArray<UnionCell> ValueCValue;

		// Token: 0x04001BA8 RID: 7080
		private FlatBufferArray<UnionCell> ValueDValue;

		// Token: 0x04001BA9 RID: 7081
		private FlatBufferArray<UnionCell> ValueEValue;

		// Token: 0x04001BAA RID: 7082
		private FlatBufferArray<UnionCell> ValueFValue;

		// Token: 0x04001BAB RID: 7083
		private FlatBufferArray<UnionCell> ValueGValue;

		// Token: 0x020005C6 RID: 1478
		public enum eSkillType
		{
			// Token: 0x04001BAD RID: 7085
			SkillType_None,
			// Token: 0x04001BAE RID: 7086
			ACTIVE,
			// Token: 0x04001BAF RID: 7087
			PASSIVE
		}

		// Token: 0x020005C7 RID: 1479
		public enum eSkillEffect
		{
			// Token: 0x04001BB1 RID: 7089
			NONE,
			// Token: 0x04001BB2 RID: 7090
			START_SKILL,
			// Token: 0x04001BB3 RID: 7091
			CONTINUOUS_SKILL,
			// Token: 0x04001BB4 RID: 7092
			HURT_SKILL,
			// Token: 0x04001BB5 RID: 7093
			DISPLACEMENT_SKILL,
			// Token: 0x04001BB6 RID: 7094
			CONTROL_SKILL,
			// Token: 0x04001BB7 RID: 7095
			GRAB_SKILL,
			// Token: 0x04001BB8 RID: 7096
			DEFENSE_SKILL,
			// Token: 0x04001BB9 RID: 7097
			ASSISTANT_SKILL,
			// Token: 0x04001BBA RID: 7098
			PHYSICAL_SKILL,
			// Token: 0x04001BBB RID: 7099
			MAGIC_SKILL,
			// Token: 0x04001BBC RID: 7100
			NEAR_SKILL,
			// Token: 0x04001BBD RID: 7101
			FAR_SKILL
		}

		// Token: 0x020005C8 RID: 1480
		public enum ePreCondition
		{
			// Token: 0x04001BBF RID: 7103
			PreCondition_None,
			// Token: 0x04001BC0 RID: 7104
			STAND,
			// Token: 0x04001BC1 RID: 7105
			WALK,
			// Token: 0x04001BC2 RID: 7106
			RUN,
			// Token: 0x04001BC3 RID: 7107
			JUMP,
			// Token: 0x04001BC4 RID: 7108
			BEHIT,
			// Token: 0x04001BC5 RID: 7109
			ENTERSCENE,
			// Token: 0x04001BC6 RID: 7110
			INIT,
			// Token: 0x04001BC7 RID: 7111
			LOWHP,
			// Token: 0x04001BC8 RID: 7112
			DAODI,
			// Token: 0x04001BC9 RID: 7113
			MASTER_ATTACK,
			// Token: 0x04001BCA RID: 7114
			JUMP_BACK
		}

		// Token: 0x020005C9 RID: 1481
		public enum eSkillTarget
		{
			// Token: 0x04001BCC RID: 7116
			SkillTarget_None,
			// Token: 0x04001BCD RID: 7117
			FRIENDLY,
			// Token: 0x04001BCE RID: 7118
			ENEMY
		}

		// Token: 0x020005CA RID: 1482
		public enum eCrypt
		{
			// Token: 0x04001BD0 RID: 7120
			code = -1406489137
		}
	}
}
