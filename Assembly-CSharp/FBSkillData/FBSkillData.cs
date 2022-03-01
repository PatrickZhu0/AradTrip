using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B3D RID: 19261
	public sealed class FBSkillData : Table
	{
		// Token: 0x0601C396 RID: 115606 RVA: 0x008960DA File Offset: 0x008944DA
		public static FBSkillData GetRootAsFBSkillData(ByteBuffer _bb)
		{
			return FBSkillData.GetRootAsFBSkillData(_bb, new FBSkillData());
		}

		// Token: 0x0601C397 RID: 115607 RVA: 0x008960E7 File Offset: 0x008944E7
		public static FBSkillData GetRootAsFBSkillData(ByteBuffer _bb, FBSkillData obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C398 RID: 115608 RVA: 0x00896103 File Offset: 0x00894503
		public FBSkillData __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002773 RID: 10099
		// (get) Token: 0x0601C399 RID: 115609 RVA: 0x00896114 File Offset: 0x00894514
		public string _name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002774 RID: 10100
		// (get) Token: 0x0601C39A RID: 115610 RVA: 0x00896144 File Offset: 0x00894544
		public int SkillID
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002775 RID: 10101
		// (get) Token: 0x0601C39B RID: 115611 RVA: 0x00896178 File Offset: 0x00894578
		public int SkillPriority
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C39C RID: 115612 RVA: 0x008961AC File Offset: 0x008945AC
		public int GetSkillPhases(int j)
		{
			int num = base.__offset(10);
			return (num == 0) ? 0 : this.bb.GetInt(base.__vector(num) + j * 4);
		}

		// Token: 0x17002776 RID: 10102
		// (get) Token: 0x0601C39D RID: 115613 RVA: 0x008961E4 File Offset: 0x008945E4
		public int SkillPhasesLength
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x17002777 RID: 10103
		// (get) Token: 0x0601C39E RID: 115614 RVA: 0x00896210 File Offset: 0x00894610
		public bool RelatedAttackSpeed
		{
			get
			{
				int num = base.__offset(12);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002778 RID: 10104
		// (get) Token: 0x0601C39F RID: 115615 RVA: 0x0089624C File Offset: 0x0089464C
		public int AttackSpeed
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002779 RID: 10105
		// (get) Token: 0x0601C3A0 RID: 115616 RVA: 0x00896284 File Offset: 0x00894684
		public int IsLoop
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700277A RID: 10106
		// (get) Token: 0x0601C3A1 RID: 115617 RVA: 0x008962BC File Offset: 0x008946BC
		public bool NotLoopLastFrame
		{
			get
			{
				int num = base.__offset(18);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700277B RID: 10107
		// (get) Token: 0x0601C3A2 RID: 115618 RVA: 0x008962F8 File Offset: 0x008946F8
		public bool LoopAnimation
		{
			get
			{
				int num = base.__offset(20);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700277C RID: 10108
		// (get) Token: 0x0601C3A3 RID: 115619 RVA: 0x00896334 File Offset: 0x00894734
		public bool LoopAnimation1
		{
			get
			{
				int num = base.__offset(22);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700277D RID: 10109
		// (get) Token: 0x0601C3A4 RID: 115620 RVA: 0x00896370 File Offset: 0x00894770
		public string HitEffect
		{
			get
			{
				int num = base.__offset(24);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700277E RID: 10110
		// (get) Token: 0x0601C3A5 RID: 115621 RVA: 0x008963A0 File Offset: 0x008947A0
		public string GoHitEffectAsset
		{
			get
			{
				int num = base.__offset(26);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700277F RID: 10111
		// (get) Token: 0x0601C3A6 RID: 115622 RVA: 0x008963D0 File Offset: 0x008947D0
		public string GoSFXAsset
		{
			get
			{
				int num = base.__offset(28);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002780 RID: 10112
		// (get) Token: 0x0601C3A7 RID: 115623 RVA: 0x00896400 File Offset: 0x00894800
		public int HitSFXID
		{
			get
			{
				int num = base.__offset(30);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002781 RID: 10113
		// (get) Token: 0x0601C3A8 RID: 115624 RVA: 0x00896438 File Offset: 0x00894838
		public int HurtType
		{
			get
			{
				int num = base.__offset(32);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002782 RID: 10114
		// (get) Token: 0x0601C3A9 RID: 115625 RVA: 0x00896470 File Offset: 0x00894870
		public float HurtTime
		{
			get
			{
				int num = base.__offset(34);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002783 RID: 10115
		// (get) Token: 0x0601C3AA RID: 115626 RVA: 0x008964AC File Offset: 0x008948AC
		public int HurtPause
		{
			get
			{
				int num = base.__offset(36);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002784 RID: 10116
		// (get) Token: 0x0601C3AB RID: 115627 RVA: 0x008964E4 File Offset: 0x008948E4
		public float HurtPauseTime
		{
			get
			{
				int num = base.__offset(38);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002785 RID: 10117
		// (get) Token: 0x0601C3AC RID: 115628 RVA: 0x00896520 File Offset: 0x00894920
		public float Forcex
		{
			get
			{
				int num = base.__offset(40);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002786 RID: 10118
		// (get) Token: 0x0601C3AD RID: 115629 RVA: 0x0089655C File Offset: 0x0089495C
		public float Forcey
		{
			get
			{
				int num = base.__offset(42);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002787 RID: 10119
		// (get) Token: 0x0601C3AE RID: 115630 RVA: 0x00896598 File Offset: 0x00894998
		public string Dscription
		{
			get
			{
				int num = base.__offset(44);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002788 RID: 10120
		// (get) Token: 0x0601C3AF RID: 115631 RVA: 0x008965C8 File Offset: 0x008949C8
		public string CaracterAsset
		{
			get
			{
				int num = base.__offset(46);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002789 RID: 10121
		// (get) Token: 0x0601C3B0 RID: 115632 RVA: 0x008965F8 File Offset: 0x008949F8
		public int Fps
		{
			get
			{
				int num = base.__offset(48);
				return (num == 0) ? 60 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700278A RID: 10122
		// (get) Token: 0x0601C3B1 RID: 115633 RVA: 0x00896630 File Offset: 0x00894A30
		public string AnimationName
		{
			get
			{
				int num = base.__offset(50);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700278B RID: 10123
		// (get) Token: 0x0601C3B2 RID: 115634 RVA: 0x00896660 File Offset: 0x00894A60
		public string MoveName
		{
			get
			{
				int num = base.__offset(52);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700278C RID: 10124
		// (get) Token: 0x0601C3B3 RID: 115635 RVA: 0x00896690 File Offset: 0x00894A90
		public int WapMode
		{
			get
			{
				int num = base.__offset(54);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700278D RID: 10125
		// (get) Token: 0x0601C3B4 RID: 115636 RVA: 0x008966C8 File Offset: 0x00894AC8
		public float IterpolationSpeed
		{
			get
			{
				int num = base.__offset(56);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700278E RID: 10126
		// (get) Token: 0x0601C3B5 RID: 115637 RVA: 0x00896704 File Offset: 0x00894B04
		public float AnimationSpeed
		{
			get
			{
				int num = base.__offset(58);
				return (num == 0) ? 1f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700278F RID: 10127
		// (get) Token: 0x0601C3B6 RID: 115638 RVA: 0x00896740 File Offset: 0x00894B40
		public int TotalFrames
		{
			get
			{
				int num = base.__offset(60);
				return (num == 0) ? 15 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002790 RID: 10128
		// (get) Token: 0x0601C3B7 RID: 115639 RVA: 0x00896778 File Offset: 0x00894B78
		public int StartUpFrames
		{
			get
			{
				int num = base.__offset(62);
				return (num == 0) ? 5 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002791 RID: 10129
		// (get) Token: 0x0601C3B8 RID: 115640 RVA: 0x008967B0 File Offset: 0x00894BB0
		public int ActiveFrames
		{
			get
			{
				int num = base.__offset(64);
				return (num == 0) ? 5 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002792 RID: 10130
		// (get) Token: 0x0601C3B9 RID: 115641 RVA: 0x008967E8 File Offset: 0x00894BE8
		public int RcoveryFrames
		{
			get
			{
				int num = base.__offset(66);
				return (num == 0) ? 5 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002793 RID: 10131
		// (get) Token: 0x0601C3BA RID: 115642 RVA: 0x00896820 File Offset: 0x00894C20
		public bool UeSpellBar
		{
			get
			{
				int num = base.__offset(68);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002794 RID: 10132
		// (get) Token: 0x0601C3BB RID: 115643 RVA: 0x0089685C File Offset: 0x00894C5C
		public float SellBarTime
		{
			get
			{
				int num = base.__offset(70);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002795 RID: 10133
		// (get) Token: 0x0601C3BC RID: 115644 RVA: 0x00896898 File Offset: 0x00894C98
		public int CmboStartFrame
		{
			get
			{
				int num = base.__offset(72);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002796 RID: 10134
		// (get) Token: 0x0601C3BD RID: 115645 RVA: 0x008968D0 File Offset: 0x00894CD0
		public int CmboSkillID
		{
			get
			{
				int num = base.__offset(74);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002797 RID: 10135
		// (get) Token: 0x0601C3BE RID: 115646 RVA: 0x00896908 File Offset: 0x00894D08
		public float Skilltime
		{
			get
			{
				int num = base.__offset(76);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002798 RID: 10136
		// (get) Token: 0x0601C3BF RID: 115647 RVA: 0x00896944 File Offset: 0x00894D44
		public bool CameraRestore
		{
			get
			{
				int num = base.__offset(78);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002799 RID: 10137
		// (get) Token: 0x0601C3C0 RID: 115648 RVA: 0x00896980 File Offset: 0x00894D80
		public float CameraRestoreTime
		{
			get
			{
				int num = base.__offset(80);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700279A RID: 10138
		// (get) Token: 0x0601C3C1 RID: 115649 RVA: 0x008969BC File Offset: 0x00894DBC
		public float GrabPosx
		{
			get
			{
				int num = base.__offset(82);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700279B RID: 10139
		// (get) Token: 0x0601C3C2 RID: 115650 RVA: 0x008969F8 File Offset: 0x00894DF8
		public float GrabPosy
		{
			get
			{
				int num = base.__offset(84);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700279C RID: 10140
		// (get) Token: 0x0601C3C3 RID: 115651 RVA: 0x00896A34 File Offset: 0x00894E34
		public float GrabEndForceX
		{
			get
			{
				int num = base.__offset(86);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700279D RID: 10141
		// (get) Token: 0x0601C3C4 RID: 115652 RVA: 0x00896A70 File Offset: 0x00894E70
		public float GrabEndForceY
		{
			get
			{
				int num = base.__offset(88);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700279E RID: 10142
		// (get) Token: 0x0601C3C5 RID: 115653 RVA: 0x00896AAC File Offset: 0x00894EAC
		public float GrabTime
		{
			get
			{
				int num = base.__offset(90);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700279F RID: 10143
		// (get) Token: 0x0601C3C6 RID: 115654 RVA: 0x00896AE8 File Offset: 0x00894EE8
		public int GrabEndEffectType
		{
			get
			{
				int num = base.__offset(92);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170027A0 RID: 10144
		// (get) Token: 0x0601C3C7 RID: 115655 RVA: 0x00896B20 File Offset: 0x00894F20
		public int GrabAction
		{
			get
			{
				int num = base.__offset(94);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170027A1 RID: 10145
		// (get) Token: 0x0601C3C8 RID: 115656 RVA: 0x00896B58 File Offset: 0x00894F58
		public int GrabNum
		{
			get
			{
				int num = base.__offset(96);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170027A2 RID: 10146
		// (get) Token: 0x0601C3C9 RID: 115657 RVA: 0x00896B90 File Offset: 0x00894F90
		public float GrabMoveSpeed
		{
			get
			{
				int num = base.__offset(98);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170027A3 RID: 10147
		// (get) Token: 0x0601C3CA RID: 115658 RVA: 0x00896BCC File Offset: 0x00894FCC
		public bool GrabSupportQuickPressDismis
		{
			get
			{
				int num = base.__offset(100);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027A4 RID: 10148
		// (get) Token: 0x0601C3CB RID: 115659 RVA: 0x00896C08 File Offset: 0x00895008
		public bool NotGrabBati
		{
			get
			{
				int num = base.__offset(102);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027A5 RID: 10149
		// (get) Token: 0x0601C3CC RID: 115660 RVA: 0x00896C44 File Offset: 0x00895044
		public bool NotGrabGeDang
		{
			get
			{
				int num = base.__offset(104);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027A6 RID: 10150
		// (get) Token: 0x0601C3CD RID: 115661 RVA: 0x00896C80 File Offset: 0x00895080
		public bool NotUseGrabSetPos
		{
			get
			{
				int num = base.__offset(106);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027A7 RID: 10151
		// (get) Token: 0x0601C3CE RID: 115662 RVA: 0x00896CBC File Offset: 0x008950BC
		public bool NotGrabToBlock
		{
			get
			{
				int num = base.__offset(108);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027A8 RID: 10152
		// (get) Token: 0x0601C3CF RID: 115663 RVA: 0x00896CF8 File Offset: 0x008950F8
		public int BuffInfoId
		{
			get
			{
				int num = base.__offset(110);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170027A9 RID: 10153
		// (get) Token: 0x0601C3D0 RID: 115664 RVA: 0x00896D30 File Offset: 0x00895130
		public int BuffInfoIdToSelf
		{
			get
			{
				int num = base.__offset(112);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170027AA RID: 10154
		// (get) Token: 0x0601C3D1 RID: 115665 RVA: 0x00896D68 File Offset: 0x00895168
		public int BuffInfoIdToOther
		{
			get
			{
				int num = base.__offset(114);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170027AB RID: 10155
		// (get) Token: 0x0601C3D2 RID: 115666 RVA: 0x00896DA0 File Offset: 0x008951A0
		public bool IsCharge
		{
			get
			{
				int num = base.__offset(116);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027AC RID: 10156
		// (get) Token: 0x0601C3D3 RID: 115667 RVA: 0x00896DDB File Offset: 0x008951DB
		public ChargeConfig ChargeConfig
		{
			get
			{
				return this.GetChargeConfig(new ChargeConfig());
			}
		}

		// Token: 0x0601C3D4 RID: 115668 RVA: 0x00896DE8 File Offset: 0x008951E8
		public ChargeConfig GetChargeConfig(ChargeConfig obj)
		{
			int num = base.__offset(118);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x170027AD RID: 10157
		// (get) Token: 0x0601C3D5 RID: 115669 RVA: 0x00896E24 File Offset: 0x00895224
		public bool IsSpeicalOperate
		{
			get
			{
				int num = base.__offset(120);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027AE RID: 10158
		// (get) Token: 0x0601C3D6 RID: 115670 RVA: 0x00896E5F File Offset: 0x0089525F
		public OperationConfig OperationConfig
		{
			get
			{
				return this.GetOperationConfig(new OperationConfig());
			}
		}

		// Token: 0x0601C3D7 RID: 115671 RVA: 0x00896E6C File Offset: 0x0089526C
		public OperationConfig GetOperationConfig(OperationConfig obj)
		{
			int num = base.__offset(122);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x170027AF RID: 10159
		// (get) Token: 0x0601C3D8 RID: 115672 RVA: 0x00896EA8 File Offset: 0x008952A8
		public bool IsUseSelectSeatJoystick
		{
			get
			{
				int num = base.__offset(124);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027B0 RID: 10160
		// (get) Token: 0x0601C3D9 RID: 115673 RVA: 0x00896EE3 File Offset: 0x008952E3
		public SkillJoystickConfig SkillJoystickConfig
		{
			get
			{
				return this.GetSkillJoystickConfig(new SkillJoystickConfig());
			}
		}

		// Token: 0x0601C3DA RID: 115674 RVA: 0x00896EF0 File Offset: 0x008952F0
		public SkillJoystickConfig GetSkillJoystickConfig(SkillJoystickConfig obj)
		{
			int num = base.__offset(126);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x0601C3DB RID: 115675 RVA: 0x00896F2C File Offset: 0x0089532C
		public SkillEvent GetSkillEvents(int j)
		{
			return this.GetSkillEvents(new SkillEvent(), j);
		}

		// Token: 0x0601C3DC RID: 115676 RVA: 0x00896F3C File Offset: 0x0089533C
		public SkillEvent GetSkillEvents(SkillEvent obj, int j)
		{
			int num = base.__offset(128);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027B1 RID: 10161
		// (get) Token: 0x0601C3DD RID: 115677 RVA: 0x00896F80 File Offset: 0x00895380
		public int SkillEventsLength
		{
			get
			{
				int num = base.__offset(128);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x170027B2 RID: 10162
		// (get) Token: 0x0601C3DE RID: 115678 RVA: 0x00896FAC File Offset: 0x008953AC
		public int TriggerType
		{
			get
			{
				int num = base.__offset(130);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C3DF RID: 115679 RVA: 0x00896FE4 File Offset: 0x008953E4
		public HurtDecisionBox GetHurtBlocks(int j)
		{
			return this.GetHurtBlocks(new HurtDecisionBox(), j);
		}

		// Token: 0x0601C3E0 RID: 115680 RVA: 0x00896FF4 File Offset: 0x008953F4
		public HurtDecisionBox GetHurtBlocks(HurtDecisionBox obj, int j)
		{
			int num = base.__offset(132);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027B3 RID: 10163
		// (get) Token: 0x0601C3E1 RID: 115681 RVA: 0x00897038 File Offset: 0x00895438
		public int HurtBlocksLength
		{
			get
			{
				int num = base.__offset(132);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3E2 RID: 115682 RVA: 0x00897064 File Offset: 0x00895464
		public DefenceDecisionBox GetDefenceBlocks(int j)
		{
			return this.GetDefenceBlocks(new DefenceDecisionBox(), j);
		}

		// Token: 0x0601C3E3 RID: 115683 RVA: 0x00897074 File Offset: 0x00895474
		public DefenceDecisionBox GetDefenceBlocks(DefenceDecisionBox obj, int j)
		{
			int num = base.__offset(134);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027B4 RID: 10164
		// (get) Token: 0x0601C3E4 RID: 115684 RVA: 0x008970B8 File Offset: 0x008954B8
		public int DefenceBlocksLength
		{
			get
			{
				int num = base.__offset(134);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3E5 RID: 115685 RVA: 0x008970E4 File Offset: 0x008954E4
		public EntityAttachFrames GetAttachFrames(int j)
		{
			return this.GetAttachFrames(new EntityAttachFrames(), j);
		}

		// Token: 0x0601C3E6 RID: 115686 RVA: 0x008970F4 File Offset: 0x008954F4
		public EntityAttachFrames GetAttachFrames(EntityAttachFrames obj, int j)
		{
			int num = base.__offset(136);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027B5 RID: 10165
		// (get) Token: 0x0601C3E7 RID: 115687 RVA: 0x00897138 File Offset: 0x00895538
		public int AttachFramesLength
		{
			get
			{
				int num = base.__offset(136);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3E8 RID: 115688 RVA: 0x00897164 File Offset: 0x00895564
		public EffectsFrames GetEffectFrames(int j)
		{
			return this.GetEffectFrames(new EffectsFrames(), j);
		}

		// Token: 0x0601C3E9 RID: 115689 RVA: 0x00897174 File Offset: 0x00895574
		public EffectsFrames GetEffectFrames(EffectsFrames obj, int j)
		{
			int num = base.__offset(138);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027B6 RID: 10166
		// (get) Token: 0x0601C3EA RID: 115690 RVA: 0x008971B8 File Offset: 0x008955B8
		public int EffectFramesLength
		{
			get
			{
				int num = base.__offset(138);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3EB RID: 115691 RVA: 0x008971E4 File Offset: 0x008955E4
		public EntityFrames GetEntityFrames(int j)
		{
			return this.GetEntityFrames(new EntityFrames(), j);
		}

		// Token: 0x0601C3EC RID: 115692 RVA: 0x008971F4 File Offset: 0x008955F4
		public EntityFrames GetEntityFrames(EntityFrames obj, int j)
		{
			int num = base.__offset(140);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027B7 RID: 10167
		// (get) Token: 0x0601C3ED RID: 115693 RVA: 0x00897238 File Offset: 0x00895638
		public int EntityFramesLength
		{
			get
			{
				int num = base.__offset(140);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3EE RID: 115694 RVA: 0x00897264 File Offset: 0x00895664
		public DSkillFrameTag GetFrameTags(int j)
		{
			return this.GetFrameTags(new DSkillFrameTag(), j);
		}

		// Token: 0x0601C3EF RID: 115695 RVA: 0x00897274 File Offset: 0x00895674
		public DSkillFrameTag GetFrameTags(DSkillFrameTag obj, int j)
		{
			int num = base.__offset(142);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027B8 RID: 10168
		// (get) Token: 0x0601C3F0 RID: 115696 RVA: 0x008972B8 File Offset: 0x008956B8
		public int FrameTagsLength
		{
			get
			{
				int num = base.__offset(142);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3F1 RID: 115697 RVA: 0x008972E4 File Offset: 0x008956E4
		public DSkillFrameGrap GetFrameGrap(int j)
		{
			return this.GetFrameGrap(new DSkillFrameGrap(), j);
		}

		// Token: 0x0601C3F2 RID: 115698 RVA: 0x008972F4 File Offset: 0x008956F4
		public DSkillFrameGrap GetFrameGrap(DSkillFrameGrap obj, int j)
		{
			int num = base.__offset(144);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027B9 RID: 10169
		// (get) Token: 0x0601C3F3 RID: 115699 RVA: 0x00897338 File Offset: 0x00895738
		public int FrameGrapLength
		{
			get
			{
				int num = base.__offset(144);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3F4 RID: 115700 RVA: 0x00897364 File Offset: 0x00895764
		public DSkillFrameStateOp GetStateop(int j)
		{
			return this.GetStateop(new DSkillFrameStateOp(), j);
		}

		// Token: 0x0601C3F5 RID: 115701 RVA: 0x00897374 File Offset: 0x00895774
		public DSkillFrameStateOp GetStateop(DSkillFrameStateOp obj, int j)
		{
			int num = base.__offset(146);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027BA RID: 10170
		// (get) Token: 0x0601C3F6 RID: 115702 RVA: 0x008973B8 File Offset: 0x008957B8
		public int StateopLength
		{
			get
			{
				int num = base.__offset(146);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3F7 RID: 115703 RVA: 0x008973E4 File Offset: 0x008957E4
		public DSkillFaceAttacker GetFaceAttackerFrames(int j)
		{
			return this.GetFaceAttackerFrames(new DSkillFaceAttacker(), j);
		}

		// Token: 0x0601C3F8 RID: 115704 RVA: 0x008973F4 File Offset: 0x008957F4
		public DSkillFaceAttacker GetFaceAttackerFrames(DSkillFaceAttacker obj, int j)
		{
			int num = base.__offset(148);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027BB RID: 10171
		// (get) Token: 0x0601C3F9 RID: 115705 RVA: 0x00897438 File Offset: 0x00895838
		public int FaceAttackerFramesLength
		{
			get
			{
				int num = base.__offset(148);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3FA RID: 115706 RVA: 0x00897464 File Offset: 0x00895864
		public DSkillPropertyModify GetProperModify(int j)
		{
			return this.GetProperModify(new DSkillPropertyModify(), j);
		}

		// Token: 0x0601C3FB RID: 115707 RVA: 0x00897474 File Offset: 0x00895874
		public DSkillPropertyModify GetProperModify(DSkillPropertyModify obj, int j)
		{
			int num = base.__offset(150);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027BC RID: 10172
		// (get) Token: 0x0601C3FC RID: 115708 RVA: 0x008974B8 File Offset: 0x008958B8
		public int ProperModifyLength
		{
			get
			{
				int num = base.__offset(150);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C3FD RID: 115709 RVA: 0x008974E4 File Offset: 0x008958E4
		public DSkillFrameEventSceneShock GetShocks(int j)
		{
			return this.GetShocks(new DSkillFrameEventSceneShock(), j);
		}

		// Token: 0x0601C3FE RID: 115710 RVA: 0x008974F4 File Offset: 0x008958F4
		public DSkillFrameEventSceneShock GetShocks(DSkillFrameEventSceneShock obj, int j)
		{
			int num = base.__offset(152);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027BD RID: 10173
		// (get) Token: 0x0601C3FF RID: 115711 RVA: 0x00897538 File Offset: 0x00895938
		public int ShocksLength
		{
			get
			{
				int num = base.__offset(152);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C400 RID: 115712 RVA: 0x00897564 File Offset: 0x00895964
		public DSkillSfx GetSfx(int j)
		{
			return this.GetSfx(new DSkillSfx(), j);
		}

		// Token: 0x0601C401 RID: 115713 RVA: 0x00897574 File Offset: 0x00895974
		public DSkillSfx GetSfx(DSkillSfx obj, int j)
		{
			int num = base.__offset(154);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027BE RID: 10174
		// (get) Token: 0x0601C402 RID: 115714 RVA: 0x008975B8 File Offset: 0x008959B8
		public int SfxLength
		{
			get
			{
				int num = base.__offset(154);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C403 RID: 115715 RVA: 0x008975E4 File Offset: 0x008959E4
		public DSkillFrameEffect GetFrameEffects(int j)
		{
			return this.GetFrameEffects(new DSkillFrameEffect(), j);
		}

		// Token: 0x0601C404 RID: 115716 RVA: 0x008975F4 File Offset: 0x008959F4
		public DSkillFrameEffect GetFrameEffects(DSkillFrameEffect obj, int j)
		{
			int num = base.__offset(156);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027BF RID: 10175
		// (get) Token: 0x0601C405 RID: 115717 RVA: 0x00897638 File Offset: 0x00895A38
		public int FrameEffectsLength
		{
			get
			{
				int num = base.__offset(156);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C406 RID: 115718 RVA: 0x00897664 File Offset: 0x00895A64
		public DSkillCameraMove GetCameraMoves(int j)
		{
			return this.GetCameraMoves(new DSkillCameraMove(), j);
		}

		// Token: 0x0601C407 RID: 115719 RVA: 0x00897674 File Offset: 0x00895A74
		public DSkillCameraMove GetCameraMoves(DSkillCameraMove obj, int j)
		{
			int num = base.__offset(158);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027C0 RID: 10176
		// (get) Token: 0x0601C408 RID: 115720 RVA: 0x008976B8 File Offset: 0x00895AB8
		public int CameraMovesLength
		{
			get
			{
				int num = base.__offset(158);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C409 RID: 115721 RVA: 0x008976E4 File Offset: 0x00895AE4
		public DSkillWalkControl GetWalkControl(int j)
		{
			return this.GetWalkControl(new DSkillWalkControl(), j);
		}

		// Token: 0x0601C40A RID: 115722 RVA: 0x008976F4 File Offset: 0x00895AF4
		public DSkillWalkControl GetWalkControl(DSkillWalkControl obj, int j)
		{
			int num = base.__offset(160);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027C1 RID: 10177
		// (get) Token: 0x0601C40B RID: 115723 RVA: 0x00897738 File Offset: 0x00895B38
		public int WalkControlLength
		{
			get
			{
				int num = base.__offset(160);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C40C RID: 115724 RVA: 0x00897764 File Offset: 0x00895B64
		public DActionData GetActions(int j)
		{
			return this.GetActions(new DActionData(), j);
		}

		// Token: 0x0601C40D RID: 115725 RVA: 0x00897774 File Offset: 0x00895B74
		public DActionData GetActions(DActionData obj, int j)
		{
			int num = base.__offset(162);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027C2 RID: 10178
		// (get) Token: 0x0601C40E RID: 115726 RVA: 0x008977B8 File Offset: 0x00895BB8
		public int ActionsLength
		{
			get
			{
				int num = base.__offset(162);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C40F RID: 115727 RVA: 0x008977E4 File Offset: 0x00895BE4
		public DSkillBuff GetBuffs(int j)
		{
			return this.GetBuffs(new DSkillBuff(), j);
		}

		// Token: 0x0601C410 RID: 115728 RVA: 0x008977F4 File Offset: 0x00895BF4
		public DSkillBuff GetBuffs(DSkillBuff obj, int j)
		{
			int num = base.__offset(164);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027C3 RID: 10179
		// (get) Token: 0x0601C411 RID: 115729 RVA: 0x00897838 File Offset: 0x00895C38
		public int BuffsLength
		{
			get
			{
				int num = base.__offset(164);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C412 RID: 115730 RVA: 0x00897864 File Offset: 0x00895C64
		public DSkillSummon GetSummons(int j)
		{
			return this.GetSummons(new DSkillSummon(), j);
		}

		// Token: 0x0601C413 RID: 115731 RVA: 0x00897874 File Offset: 0x00895C74
		public DSkillSummon GetSummons(DSkillSummon obj, int j)
		{
			int num = base.__offset(166);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027C4 RID: 10180
		// (get) Token: 0x0601C414 RID: 115732 RVA: 0x008978B8 File Offset: 0x00895CB8
		public int SummonsLength
		{
			get
			{
				int num = base.__offset(166);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C415 RID: 115733 RVA: 0x008978E4 File Offset: 0x00895CE4
		public DSkillMechanism GetMechanisms(int j)
		{
			return this.GetMechanisms(new DSkillMechanism(), j);
		}

		// Token: 0x0601C416 RID: 115734 RVA: 0x008978F4 File Offset: 0x00895CF4
		public DSkillMechanism GetMechanisms(DSkillMechanism obj, int j)
		{
			int num = base.__offset(168);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027C5 RID: 10181
		// (get) Token: 0x0601C417 RID: 115735 RVA: 0x00897938 File Offset: 0x00895D38
		public int MechanismsLength
		{
			get
			{
				int num = base.__offset(168);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C418 RID: 115736 RVA: 0x00897964 File Offset: 0x00895D64
		public static Offset<FBSkillData> CreateFBSkillData(FlatBufferBuilder builder, StringOffset _name = default(StringOffset), int skillID = 0, int skillPriority = 0, VectorOffset skillPhases = default(VectorOffset), bool relatedAttackSpeed = false, int attackSpeed = 0, int isLoop = 0, bool notLoopLastFrame = false, bool loopAnimation = false, bool loopAnimation1 = false, StringOffset hitEffect = default(StringOffset), StringOffset goHitEffectAsset = default(StringOffset), StringOffset goSFXAsset = default(StringOffset), int hitSFXID = 0, int hurtType = 0, float hurtTime = 0f, int hurtPause = 0, float hurtPauseTime = 0f, float forcex = 0f, float forcey = 0f, StringOffset dscription = default(StringOffset), StringOffset caracterAsset = default(StringOffset), int fps = 60, StringOffset animationName = default(StringOffset), StringOffset moveName = default(StringOffset), int wapMode = 0, float iterpolationSpeed = 0f, float animationSpeed = 1f, int totalFrames = 15, int startUpFrames = 5, int activeFrames = 5, int rcoveryFrames = 5, bool ueSpellBar = false, float sellBarTime = 0f, int cmboStartFrame = 0, int cmboSkillID = 0, float skilltime = 0f, bool cameraRestore = false, float cameraRestoreTime = 0f, float grabPosx = 0f, float grabPosy = 0f, float grabEndForceX = 0f, float grabEndForceY = 0f, float grabTime = 0f, int grabEndEffectType = 0, int grabAction = 0, int grabNum = 0, float grabMoveSpeed = 0f, bool grabSupportQuickPressDismis = false, bool notGrabBati = false, bool notGrabGeDang = false, bool notUseGrabSetPos = false, bool notGrabToBlock = false, int buffInfoId = 0, int buffInfoIdToSelf = 0, int buffInfoIdToOther = 0, bool isCharge = false, Offset<ChargeConfig> chargeConfig = default(Offset<ChargeConfig>), bool isSpeicalOperate = false, Offset<OperationConfig> operationConfig = default(Offset<OperationConfig>), bool isUseSelectSeatJoystick = false, Offset<SkillJoystickConfig> skillJoystickConfig = default(Offset<SkillJoystickConfig>), VectorOffset skillEvents = default(VectorOffset), int triggerType = 0, VectorOffset HurtBlocks = default(VectorOffset), VectorOffset DefenceBlocks = default(VectorOffset), VectorOffset attachFrames = default(VectorOffset), VectorOffset effectFrames = default(VectorOffset), VectorOffset entityFrames = default(VectorOffset), VectorOffset frameTags = default(VectorOffset), VectorOffset frameGrap = default(VectorOffset), VectorOffset stateop = default(VectorOffset), VectorOffset faceAttackerFrames = default(VectorOffset), VectorOffset properModify = default(VectorOffset), VectorOffset shocks = default(VectorOffset), VectorOffset sfx = default(VectorOffset), VectorOffset frameEffects = default(VectorOffset), VectorOffset cameraMoves = default(VectorOffset), VectorOffset walkControl = default(VectorOffset), VectorOffset actions = default(VectorOffset), VectorOffset buffs = default(VectorOffset), VectorOffset summons = default(VectorOffset), VectorOffset mechanisms = default(VectorOffset))
		{
			builder.StartObject(83);
			FBSkillData.AddMechanisms(builder, mechanisms);
			FBSkillData.AddSummons(builder, summons);
			FBSkillData.AddBuffs(builder, buffs);
			FBSkillData.AddActions(builder, actions);
			FBSkillData.AddWalkControl(builder, walkControl);
			FBSkillData.AddCameraMoves(builder, cameraMoves);
			FBSkillData.AddFrameEffects(builder, frameEffects);
			FBSkillData.AddSfx(builder, sfx);
			FBSkillData.AddShocks(builder, shocks);
			FBSkillData.AddProperModify(builder, properModify);
			FBSkillData.AddFaceAttackerFrames(builder, faceAttackerFrames);
			FBSkillData.AddStateop(builder, stateop);
			FBSkillData.AddFrameGrap(builder, frameGrap);
			FBSkillData.AddFrameTags(builder, frameTags);
			FBSkillData.AddEntityFrames(builder, entityFrames);
			FBSkillData.AddEffectFrames(builder, effectFrames);
			FBSkillData.AddAttachFrames(builder, attachFrames);
			FBSkillData.AddDefenceBlocks(builder, DefenceBlocks);
			FBSkillData.AddHurtBlocks(builder, HurtBlocks);
			FBSkillData.AddTriggerType(builder, triggerType);
			FBSkillData.AddSkillEvents(builder, skillEvents);
			FBSkillData.AddSkillJoystickConfig(builder, skillJoystickConfig);
			FBSkillData.AddOperationConfig(builder, operationConfig);
			FBSkillData.AddChargeConfig(builder, chargeConfig);
			FBSkillData.AddBuffInfoIdToOther(builder, buffInfoIdToOther);
			FBSkillData.AddBuffInfoIdToSelf(builder, buffInfoIdToSelf);
			FBSkillData.AddBuffInfoId(builder, buffInfoId);
			FBSkillData.AddGrabMoveSpeed(builder, grabMoveSpeed);
			FBSkillData.AddGrabNum(builder, grabNum);
			FBSkillData.AddGrabAction(builder, grabAction);
			FBSkillData.AddGrabEndEffectType(builder, grabEndEffectType);
			FBSkillData.AddGrabTime(builder, grabTime);
			FBSkillData.AddGrabEndForceY(builder, grabEndForceY);
			FBSkillData.AddGrabEndForceX(builder, grabEndForceX);
			FBSkillData.AddGrabPosy(builder, grabPosy);
			FBSkillData.AddGrabPosx(builder, grabPosx);
			FBSkillData.AddCameraRestoreTime(builder, cameraRestoreTime);
			FBSkillData.AddSkilltime(builder, skilltime);
			FBSkillData.AddCmboSkillID(builder, cmboSkillID);
			FBSkillData.AddCmboStartFrame(builder, cmboStartFrame);
			FBSkillData.AddSellBarTime(builder, sellBarTime);
			FBSkillData.AddRcoveryFrames(builder, rcoveryFrames);
			FBSkillData.AddActiveFrames(builder, activeFrames);
			FBSkillData.AddStartUpFrames(builder, startUpFrames);
			FBSkillData.AddTotalFrames(builder, totalFrames);
			FBSkillData.AddAnimationSpeed(builder, animationSpeed);
			FBSkillData.AddIterpolationSpeed(builder, iterpolationSpeed);
			FBSkillData.AddWapMode(builder, wapMode);
			FBSkillData.AddMoveName(builder, moveName);
			FBSkillData.AddAnimationName(builder, animationName);
			FBSkillData.AddFps(builder, fps);
			FBSkillData.AddCaracterAsset(builder, caracterAsset);
			FBSkillData.AddDscription(builder, dscription);
			FBSkillData.AddForcey(builder, forcey);
			FBSkillData.AddForcex(builder, forcex);
			FBSkillData.AddHurtPauseTime(builder, hurtPauseTime);
			FBSkillData.AddHurtPause(builder, hurtPause);
			FBSkillData.AddHurtTime(builder, hurtTime);
			FBSkillData.AddHurtType(builder, hurtType);
			FBSkillData.AddHitSFXID(builder, hitSFXID);
			FBSkillData.AddGoSFXAsset(builder, goSFXAsset);
			FBSkillData.AddGoHitEffectAsset(builder, goHitEffectAsset);
			FBSkillData.AddHitEffect(builder, hitEffect);
			FBSkillData.AddIsLoop(builder, isLoop);
			FBSkillData.AddAttackSpeed(builder, attackSpeed);
			FBSkillData.AddSkillPhases(builder, skillPhases);
			FBSkillData.AddSkillPriority(builder, skillPriority);
			FBSkillData.AddSkillID(builder, skillID);
			FBSkillData.Add_name(builder, _name);
			FBSkillData.AddIsUseSelectSeatJoystick(builder, isUseSelectSeatJoystick);
			FBSkillData.AddIsSpeicalOperate(builder, isSpeicalOperate);
			FBSkillData.AddIsCharge(builder, isCharge);
			FBSkillData.AddNotGrabToBlock(builder, notGrabToBlock);
			FBSkillData.AddNotUseGrabSetPos(builder, notUseGrabSetPos);
			FBSkillData.AddNotGrabGeDang(builder, notGrabGeDang);
			FBSkillData.AddNotGrabBati(builder, notGrabBati);
			FBSkillData.AddGrabSupportQuickPressDismis(builder, grabSupportQuickPressDismis);
			FBSkillData.AddCameraRestore(builder, cameraRestore);
			FBSkillData.AddUeSpellBar(builder, ueSpellBar);
			FBSkillData.AddLoopAnimation1(builder, loopAnimation1);
			FBSkillData.AddLoopAnimation(builder, loopAnimation);
			FBSkillData.AddNotLoopLastFrame(builder, notLoopLastFrame);
			FBSkillData.AddRelatedAttackSpeed(builder, relatedAttackSpeed);
			return FBSkillData.EndFBSkillData(builder);
		}

		// Token: 0x0601C419 RID: 115737 RVA: 0x00897C14 File Offset: 0x00896014
		public static void StartFBSkillData(FlatBufferBuilder builder)
		{
			builder.StartObject(83);
		}

		// Token: 0x0601C41A RID: 115738 RVA: 0x00897C1E File Offset: 0x0089601E
		public static void Add_name(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(0, NameOffset.Value, 0);
		}

		// Token: 0x0601C41B RID: 115739 RVA: 0x00897C2F File Offset: 0x0089602F
		public static void AddSkillID(FlatBufferBuilder builder, int skillID)
		{
			builder.AddInt(1, skillID, 0);
		}

		// Token: 0x0601C41C RID: 115740 RVA: 0x00897C3A File Offset: 0x0089603A
		public static void AddSkillPriority(FlatBufferBuilder builder, int skillPriority)
		{
			builder.AddInt(2, skillPriority, 0);
		}

		// Token: 0x0601C41D RID: 115741 RVA: 0x00897C45 File Offset: 0x00896045
		public static void AddSkillPhases(FlatBufferBuilder builder, VectorOffset skillPhasesOffset)
		{
			builder.AddOffset(3, skillPhasesOffset.Value, 0);
		}

		// Token: 0x0601C41E RID: 115742 RVA: 0x00897C58 File Offset: 0x00896058
		public static VectorOffset CreateSkillPhasesVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C41F RID: 115743 RVA: 0x00897C95 File Offset: 0x00896095
		public static void StartSkillPhasesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C420 RID: 115744 RVA: 0x00897CA0 File Offset: 0x008960A0
		public static void AddRelatedAttackSpeed(FlatBufferBuilder builder, bool relatedAttackSpeed)
		{
			builder.AddBool(4, relatedAttackSpeed, false);
		}

		// Token: 0x0601C421 RID: 115745 RVA: 0x00897CAB File Offset: 0x008960AB
		public static void AddAttackSpeed(FlatBufferBuilder builder, int attackSpeed)
		{
			builder.AddInt(5, attackSpeed, 0);
		}

		// Token: 0x0601C422 RID: 115746 RVA: 0x00897CB6 File Offset: 0x008960B6
		public static void AddIsLoop(FlatBufferBuilder builder, int isLoop)
		{
			builder.AddInt(6, isLoop, 0);
		}

		// Token: 0x0601C423 RID: 115747 RVA: 0x00897CC1 File Offset: 0x008960C1
		public static void AddNotLoopLastFrame(FlatBufferBuilder builder, bool notLoopLastFrame)
		{
			builder.AddBool(7, notLoopLastFrame, false);
		}

		// Token: 0x0601C424 RID: 115748 RVA: 0x00897CCC File Offset: 0x008960CC
		public static void AddLoopAnimation(FlatBufferBuilder builder, bool loopAnimation)
		{
			builder.AddBool(8, loopAnimation, false);
		}

		// Token: 0x0601C425 RID: 115749 RVA: 0x00897CD7 File Offset: 0x008960D7
		public static void AddLoopAnimation1(FlatBufferBuilder builder, bool loopAnimation1)
		{
			builder.AddBool(9, loopAnimation1, false);
		}

		// Token: 0x0601C426 RID: 115750 RVA: 0x00897CE3 File Offset: 0x008960E3
		public static void AddHitEffect(FlatBufferBuilder builder, StringOffset hitEffectOffset)
		{
			builder.AddOffset(10, hitEffectOffset.Value, 0);
		}

		// Token: 0x0601C427 RID: 115751 RVA: 0x00897CF5 File Offset: 0x008960F5
		public static void AddGoHitEffectAsset(FlatBufferBuilder builder, StringOffset goHitEffectAssetOffset)
		{
			builder.AddOffset(11, goHitEffectAssetOffset.Value, 0);
		}

		// Token: 0x0601C428 RID: 115752 RVA: 0x00897D07 File Offset: 0x00896107
		public static void AddGoSFXAsset(FlatBufferBuilder builder, StringOffset goSFXAssetOffset)
		{
			builder.AddOffset(12, goSFXAssetOffset.Value, 0);
		}

		// Token: 0x0601C429 RID: 115753 RVA: 0x00897D19 File Offset: 0x00896119
		public static void AddHitSFXID(FlatBufferBuilder builder, int hitSFXID)
		{
			builder.AddInt(13, hitSFXID, 0);
		}

		// Token: 0x0601C42A RID: 115754 RVA: 0x00897D25 File Offset: 0x00896125
		public static void AddHurtType(FlatBufferBuilder builder, int hurtType)
		{
			builder.AddInt(14, hurtType, 0);
		}

		// Token: 0x0601C42B RID: 115755 RVA: 0x00897D31 File Offset: 0x00896131
		public static void AddHurtTime(FlatBufferBuilder builder, float hurtTime)
		{
			builder.AddFloat(15, hurtTime, 0.0);
		}

		// Token: 0x0601C42C RID: 115756 RVA: 0x00897D45 File Offset: 0x00896145
		public static void AddHurtPause(FlatBufferBuilder builder, int hurtPause)
		{
			builder.AddInt(16, hurtPause, 0);
		}

		// Token: 0x0601C42D RID: 115757 RVA: 0x00897D51 File Offset: 0x00896151
		public static void AddHurtPauseTime(FlatBufferBuilder builder, float hurtPauseTime)
		{
			builder.AddFloat(17, hurtPauseTime, 0.0);
		}

		// Token: 0x0601C42E RID: 115758 RVA: 0x00897D65 File Offset: 0x00896165
		public static void AddForcex(FlatBufferBuilder builder, float forcex)
		{
			builder.AddFloat(18, forcex, 0.0);
		}

		// Token: 0x0601C42F RID: 115759 RVA: 0x00897D79 File Offset: 0x00896179
		public static void AddForcey(FlatBufferBuilder builder, float forcey)
		{
			builder.AddFloat(19, forcey, 0.0);
		}

		// Token: 0x0601C430 RID: 115760 RVA: 0x00897D8D File Offset: 0x0089618D
		public static void AddDscription(FlatBufferBuilder builder, StringOffset dscriptionOffset)
		{
			builder.AddOffset(20, dscriptionOffset.Value, 0);
		}

		// Token: 0x0601C431 RID: 115761 RVA: 0x00897D9F File Offset: 0x0089619F
		public static void AddCaracterAsset(FlatBufferBuilder builder, StringOffset caracterAssetOffset)
		{
			builder.AddOffset(21, caracterAssetOffset.Value, 0);
		}

		// Token: 0x0601C432 RID: 115762 RVA: 0x00897DB1 File Offset: 0x008961B1
		public static void AddFps(FlatBufferBuilder builder, int fps)
		{
			builder.AddInt(22, fps, 60);
		}

		// Token: 0x0601C433 RID: 115763 RVA: 0x00897DBE File Offset: 0x008961BE
		public static void AddAnimationName(FlatBufferBuilder builder, StringOffset animationNameOffset)
		{
			builder.AddOffset(23, animationNameOffset.Value, 0);
		}

		// Token: 0x0601C434 RID: 115764 RVA: 0x00897DD0 File Offset: 0x008961D0
		public static void AddMoveName(FlatBufferBuilder builder, StringOffset moveNameOffset)
		{
			builder.AddOffset(24, moveNameOffset.Value, 0);
		}

		// Token: 0x0601C435 RID: 115765 RVA: 0x00897DE2 File Offset: 0x008961E2
		public static void AddWapMode(FlatBufferBuilder builder, int wapMode)
		{
			builder.AddInt(25, wapMode, 0);
		}

		// Token: 0x0601C436 RID: 115766 RVA: 0x00897DEE File Offset: 0x008961EE
		public static void AddIterpolationSpeed(FlatBufferBuilder builder, float iterpolationSpeed)
		{
			builder.AddFloat(26, iterpolationSpeed, 0.0);
		}

		// Token: 0x0601C437 RID: 115767 RVA: 0x00897E02 File Offset: 0x00896202
		public static void AddAnimationSpeed(FlatBufferBuilder builder, float animationSpeed)
		{
			builder.AddFloat(27, animationSpeed, 1.0);
		}

		// Token: 0x0601C438 RID: 115768 RVA: 0x00897E16 File Offset: 0x00896216
		public static void AddTotalFrames(FlatBufferBuilder builder, int totalFrames)
		{
			builder.AddInt(28, totalFrames, 15);
		}

		// Token: 0x0601C439 RID: 115769 RVA: 0x00897E23 File Offset: 0x00896223
		public static void AddStartUpFrames(FlatBufferBuilder builder, int startUpFrames)
		{
			builder.AddInt(29, startUpFrames, 5);
		}

		// Token: 0x0601C43A RID: 115770 RVA: 0x00897E2F File Offset: 0x0089622F
		public static void AddActiveFrames(FlatBufferBuilder builder, int activeFrames)
		{
			builder.AddInt(30, activeFrames, 5);
		}

		// Token: 0x0601C43B RID: 115771 RVA: 0x00897E3B File Offset: 0x0089623B
		public static void AddRcoveryFrames(FlatBufferBuilder builder, int rcoveryFrames)
		{
			builder.AddInt(31, rcoveryFrames, 5);
		}

		// Token: 0x0601C43C RID: 115772 RVA: 0x00897E47 File Offset: 0x00896247
		public static void AddUeSpellBar(FlatBufferBuilder builder, bool ueSpellBar)
		{
			builder.AddBool(32, ueSpellBar, false);
		}

		// Token: 0x0601C43D RID: 115773 RVA: 0x00897E53 File Offset: 0x00896253
		public static void AddSellBarTime(FlatBufferBuilder builder, float sellBarTime)
		{
			builder.AddFloat(33, sellBarTime, 0.0);
		}

		// Token: 0x0601C43E RID: 115774 RVA: 0x00897E67 File Offset: 0x00896267
		public static void AddCmboStartFrame(FlatBufferBuilder builder, int cmboStartFrame)
		{
			builder.AddInt(34, cmboStartFrame, 0);
		}

		// Token: 0x0601C43F RID: 115775 RVA: 0x00897E73 File Offset: 0x00896273
		public static void AddCmboSkillID(FlatBufferBuilder builder, int cmboSkillID)
		{
			builder.AddInt(35, cmboSkillID, 0);
		}

		// Token: 0x0601C440 RID: 115776 RVA: 0x00897E7F File Offset: 0x0089627F
		public static void AddSkilltime(FlatBufferBuilder builder, float skilltime)
		{
			builder.AddFloat(36, skilltime, 0.0);
		}

		// Token: 0x0601C441 RID: 115777 RVA: 0x00897E93 File Offset: 0x00896293
		public static void AddCameraRestore(FlatBufferBuilder builder, bool cameraRestore)
		{
			builder.AddBool(37, cameraRestore, false);
		}

		// Token: 0x0601C442 RID: 115778 RVA: 0x00897E9F File Offset: 0x0089629F
		public static void AddCameraRestoreTime(FlatBufferBuilder builder, float cameraRestoreTime)
		{
			builder.AddFloat(38, cameraRestoreTime, 0.0);
		}

		// Token: 0x0601C443 RID: 115779 RVA: 0x00897EB3 File Offset: 0x008962B3
		public static void AddGrabPosx(FlatBufferBuilder builder, float grabPosx)
		{
			builder.AddFloat(39, grabPosx, 0.0);
		}

		// Token: 0x0601C444 RID: 115780 RVA: 0x00897EC7 File Offset: 0x008962C7
		public static void AddGrabPosy(FlatBufferBuilder builder, float grabPosy)
		{
			builder.AddFloat(40, grabPosy, 0.0);
		}

		// Token: 0x0601C445 RID: 115781 RVA: 0x00897EDB File Offset: 0x008962DB
		public static void AddGrabEndForceX(FlatBufferBuilder builder, float grabEndForceX)
		{
			builder.AddFloat(41, grabEndForceX, 0.0);
		}

		// Token: 0x0601C446 RID: 115782 RVA: 0x00897EEF File Offset: 0x008962EF
		public static void AddGrabEndForceY(FlatBufferBuilder builder, float grabEndForceY)
		{
			builder.AddFloat(42, grabEndForceY, 0.0);
		}

		// Token: 0x0601C447 RID: 115783 RVA: 0x00897F03 File Offset: 0x00896303
		public static void AddGrabTime(FlatBufferBuilder builder, float grabTime)
		{
			builder.AddFloat(43, grabTime, 0.0);
		}

		// Token: 0x0601C448 RID: 115784 RVA: 0x00897F17 File Offset: 0x00896317
		public static void AddGrabEndEffectType(FlatBufferBuilder builder, int grabEndEffectType)
		{
			builder.AddInt(44, grabEndEffectType, 0);
		}

		// Token: 0x0601C449 RID: 115785 RVA: 0x00897F23 File Offset: 0x00896323
		public static void AddGrabAction(FlatBufferBuilder builder, int grabAction)
		{
			builder.AddInt(45, grabAction, 0);
		}

		// Token: 0x0601C44A RID: 115786 RVA: 0x00897F2F File Offset: 0x0089632F
		public static void AddGrabNum(FlatBufferBuilder builder, int grabNum)
		{
			builder.AddInt(46, grabNum, 0);
		}

		// Token: 0x0601C44B RID: 115787 RVA: 0x00897F3B File Offset: 0x0089633B
		public static void AddGrabMoveSpeed(FlatBufferBuilder builder, float grabMoveSpeed)
		{
			builder.AddFloat(47, grabMoveSpeed, 0.0);
		}

		// Token: 0x0601C44C RID: 115788 RVA: 0x00897F4F File Offset: 0x0089634F
		public static void AddGrabSupportQuickPressDismis(FlatBufferBuilder builder, bool grabSupportQuickPressDismis)
		{
			builder.AddBool(48, grabSupportQuickPressDismis, false);
		}

		// Token: 0x0601C44D RID: 115789 RVA: 0x00897F5B File Offset: 0x0089635B
		public static void AddNotGrabBati(FlatBufferBuilder builder, bool notGrabBati)
		{
			builder.AddBool(49, notGrabBati, false);
		}

		// Token: 0x0601C44E RID: 115790 RVA: 0x00897F67 File Offset: 0x00896367
		public static void AddNotGrabGeDang(FlatBufferBuilder builder, bool notGrabGeDang)
		{
			builder.AddBool(50, notGrabGeDang, false);
		}

		// Token: 0x0601C44F RID: 115791 RVA: 0x00897F73 File Offset: 0x00896373
		public static void AddNotUseGrabSetPos(FlatBufferBuilder builder, bool notUseGrabSetPos)
		{
			builder.AddBool(51, notUseGrabSetPos, false);
		}

		// Token: 0x0601C450 RID: 115792 RVA: 0x00897F7F File Offset: 0x0089637F
		public static void AddNotGrabToBlock(FlatBufferBuilder builder, bool notGrabToBlock)
		{
			builder.AddBool(52, notGrabToBlock, false);
		}

		// Token: 0x0601C451 RID: 115793 RVA: 0x00897F8B File Offset: 0x0089638B
		public static void AddBuffInfoId(FlatBufferBuilder builder, int buffInfoId)
		{
			builder.AddInt(53, buffInfoId, 0);
		}

		// Token: 0x0601C452 RID: 115794 RVA: 0x00897F97 File Offset: 0x00896397
		public static void AddBuffInfoIdToSelf(FlatBufferBuilder builder, int buffInfoIdToSelf)
		{
			builder.AddInt(54, buffInfoIdToSelf, 0);
		}

		// Token: 0x0601C453 RID: 115795 RVA: 0x00897FA3 File Offset: 0x008963A3
		public static void AddBuffInfoIdToOther(FlatBufferBuilder builder, int buffInfoIdToOther)
		{
			builder.AddInt(55, buffInfoIdToOther, 0);
		}

		// Token: 0x0601C454 RID: 115796 RVA: 0x00897FAF File Offset: 0x008963AF
		public static void AddIsCharge(FlatBufferBuilder builder, bool isCharge)
		{
			builder.AddBool(56, isCharge, false);
		}

		// Token: 0x0601C455 RID: 115797 RVA: 0x00897FBB File Offset: 0x008963BB
		public static void AddChargeConfig(FlatBufferBuilder builder, Offset<ChargeConfig> chargeConfigOffset)
		{
			builder.AddOffset(57, chargeConfigOffset.Value, 0);
		}

		// Token: 0x0601C456 RID: 115798 RVA: 0x00897FCD File Offset: 0x008963CD
		public static void AddIsSpeicalOperate(FlatBufferBuilder builder, bool isSpeicalOperate)
		{
			builder.AddBool(58, isSpeicalOperate, false);
		}

		// Token: 0x0601C457 RID: 115799 RVA: 0x00897FD9 File Offset: 0x008963D9
		public static void AddOperationConfig(FlatBufferBuilder builder, Offset<OperationConfig> operationConfigOffset)
		{
			builder.AddOffset(59, operationConfigOffset.Value, 0);
		}

		// Token: 0x0601C458 RID: 115800 RVA: 0x00897FEB File Offset: 0x008963EB
		public static void AddIsUseSelectSeatJoystick(FlatBufferBuilder builder, bool isUseSelectSeatJoystick)
		{
			builder.AddBool(60, isUseSelectSeatJoystick, false);
		}

		// Token: 0x0601C459 RID: 115801 RVA: 0x00897FF7 File Offset: 0x008963F7
		public static void AddSkillJoystickConfig(FlatBufferBuilder builder, Offset<SkillJoystickConfig> skillJoystickConfigOffset)
		{
			builder.AddOffset(61, skillJoystickConfigOffset.Value, 0);
		}

		// Token: 0x0601C45A RID: 115802 RVA: 0x00898009 File Offset: 0x00896409
		public static void AddSkillEvents(FlatBufferBuilder builder, VectorOffset skillEventsOffset)
		{
			builder.AddOffset(62, skillEventsOffset.Value, 0);
		}

		// Token: 0x0601C45B RID: 115803 RVA: 0x0089801C File Offset: 0x0089641C
		public static VectorOffset CreateSkillEventsVector(FlatBufferBuilder builder, Offset<SkillEvent>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C45C RID: 115804 RVA: 0x00898062 File Offset: 0x00896462
		public static void StartSkillEventsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C45D RID: 115805 RVA: 0x0089806D File Offset: 0x0089646D
		public static void AddTriggerType(FlatBufferBuilder builder, int triggerType)
		{
			builder.AddInt(63, triggerType, 0);
		}

		// Token: 0x0601C45E RID: 115806 RVA: 0x00898079 File Offset: 0x00896479
		public static void AddHurtBlocks(FlatBufferBuilder builder, VectorOffset HurtBlocksOffset)
		{
			builder.AddOffset(64, HurtBlocksOffset.Value, 0);
		}

		// Token: 0x0601C45F RID: 115807 RVA: 0x0089808C File Offset: 0x0089648C
		public static VectorOffset CreateHurtBlocksVector(FlatBufferBuilder builder, Offset<HurtDecisionBox>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C460 RID: 115808 RVA: 0x008980D2 File Offset: 0x008964D2
		public static void StartHurtBlocksVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C461 RID: 115809 RVA: 0x008980DD File Offset: 0x008964DD
		public static void AddDefenceBlocks(FlatBufferBuilder builder, VectorOffset DefenceBlocksOffset)
		{
			builder.AddOffset(65, DefenceBlocksOffset.Value, 0);
		}

		// Token: 0x0601C462 RID: 115810 RVA: 0x008980F0 File Offset: 0x008964F0
		public static VectorOffset CreateDefenceBlocksVector(FlatBufferBuilder builder, Offset<DefenceDecisionBox>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C463 RID: 115811 RVA: 0x00898136 File Offset: 0x00896536
		public static void StartDefenceBlocksVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C464 RID: 115812 RVA: 0x00898141 File Offset: 0x00896541
		public static void AddAttachFrames(FlatBufferBuilder builder, VectorOffset attachFramesOffset)
		{
			builder.AddOffset(66, attachFramesOffset.Value, 0);
		}

		// Token: 0x0601C465 RID: 115813 RVA: 0x00898154 File Offset: 0x00896554
		public static VectorOffset CreateAttachFramesVector(FlatBufferBuilder builder, Offset<EntityAttachFrames>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C466 RID: 115814 RVA: 0x0089819A File Offset: 0x0089659A
		public static void StartAttachFramesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C467 RID: 115815 RVA: 0x008981A5 File Offset: 0x008965A5
		public static void AddEffectFrames(FlatBufferBuilder builder, VectorOffset effectFramesOffset)
		{
			builder.AddOffset(67, effectFramesOffset.Value, 0);
		}

		// Token: 0x0601C468 RID: 115816 RVA: 0x008981B8 File Offset: 0x008965B8
		public static VectorOffset CreateEffectFramesVector(FlatBufferBuilder builder, Offset<EffectsFrames>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C469 RID: 115817 RVA: 0x008981FE File Offset: 0x008965FE
		public static void StartEffectFramesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C46A RID: 115818 RVA: 0x00898209 File Offset: 0x00896609
		public static void AddEntityFrames(FlatBufferBuilder builder, VectorOffset entityFramesOffset)
		{
			builder.AddOffset(68, entityFramesOffset.Value, 0);
		}

		// Token: 0x0601C46B RID: 115819 RVA: 0x0089821C File Offset: 0x0089661C
		public static VectorOffset CreateEntityFramesVector(FlatBufferBuilder builder, Offset<EntityFrames>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C46C RID: 115820 RVA: 0x00898262 File Offset: 0x00896662
		public static void StartEntityFramesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C46D RID: 115821 RVA: 0x0089826D File Offset: 0x0089666D
		public static void AddFrameTags(FlatBufferBuilder builder, VectorOffset frameTagsOffset)
		{
			builder.AddOffset(69, frameTagsOffset.Value, 0);
		}

		// Token: 0x0601C46E RID: 115822 RVA: 0x00898280 File Offset: 0x00896680
		public static VectorOffset CreateFrameTagsVector(FlatBufferBuilder builder, Offset<DSkillFrameTag>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C46F RID: 115823 RVA: 0x008982C6 File Offset: 0x008966C6
		public static void StartFrameTagsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C470 RID: 115824 RVA: 0x008982D1 File Offset: 0x008966D1
		public static void AddFrameGrap(FlatBufferBuilder builder, VectorOffset frameGrapOffset)
		{
			builder.AddOffset(70, frameGrapOffset.Value, 0);
		}

		// Token: 0x0601C471 RID: 115825 RVA: 0x008982E4 File Offset: 0x008966E4
		public static VectorOffset CreateFrameGrapVector(FlatBufferBuilder builder, Offset<DSkillFrameGrap>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C472 RID: 115826 RVA: 0x0089832A File Offset: 0x0089672A
		public static void StartFrameGrapVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C473 RID: 115827 RVA: 0x00898335 File Offset: 0x00896735
		public static void AddStateop(FlatBufferBuilder builder, VectorOffset stateopOffset)
		{
			builder.AddOffset(71, stateopOffset.Value, 0);
		}

		// Token: 0x0601C474 RID: 115828 RVA: 0x00898348 File Offset: 0x00896748
		public static VectorOffset CreateStateopVector(FlatBufferBuilder builder, Offset<DSkillFrameStateOp>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C475 RID: 115829 RVA: 0x0089838E File Offset: 0x0089678E
		public static void StartStateopVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C476 RID: 115830 RVA: 0x00898399 File Offset: 0x00896799
		public static void AddFaceAttackerFrames(FlatBufferBuilder builder, VectorOffset faceAttackerFramesOffset)
		{
			builder.AddOffset(72, faceAttackerFramesOffset.Value, 0);
		}

		// Token: 0x0601C477 RID: 115831 RVA: 0x008983AC File Offset: 0x008967AC
		public static VectorOffset CreateFaceAttackerFramesVector(FlatBufferBuilder builder, Offset<DSkillFaceAttacker>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C478 RID: 115832 RVA: 0x008983F2 File Offset: 0x008967F2
		public static void StartFaceAttackerFramesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C479 RID: 115833 RVA: 0x008983FD File Offset: 0x008967FD
		public static void AddProperModify(FlatBufferBuilder builder, VectorOffset properModifyOffset)
		{
			builder.AddOffset(73, properModifyOffset.Value, 0);
		}

		// Token: 0x0601C47A RID: 115834 RVA: 0x00898410 File Offset: 0x00896810
		public static VectorOffset CreateProperModifyVector(FlatBufferBuilder builder, Offset<DSkillPropertyModify>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C47B RID: 115835 RVA: 0x00898456 File Offset: 0x00896856
		public static void StartProperModifyVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C47C RID: 115836 RVA: 0x00898461 File Offset: 0x00896861
		public static void AddShocks(FlatBufferBuilder builder, VectorOffset shocksOffset)
		{
			builder.AddOffset(74, shocksOffset.Value, 0);
		}

		// Token: 0x0601C47D RID: 115837 RVA: 0x00898474 File Offset: 0x00896874
		public static VectorOffset CreateShocksVector(FlatBufferBuilder builder, Offset<DSkillFrameEventSceneShock>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C47E RID: 115838 RVA: 0x008984BA File Offset: 0x008968BA
		public static void StartShocksVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C47F RID: 115839 RVA: 0x008984C5 File Offset: 0x008968C5
		public static void AddSfx(FlatBufferBuilder builder, VectorOffset sfxOffset)
		{
			builder.AddOffset(75, sfxOffset.Value, 0);
		}

		// Token: 0x0601C480 RID: 115840 RVA: 0x008984D8 File Offset: 0x008968D8
		public static VectorOffset CreateSfxVector(FlatBufferBuilder builder, Offset<DSkillSfx>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C481 RID: 115841 RVA: 0x0089851E File Offset: 0x0089691E
		public static void StartSfxVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C482 RID: 115842 RVA: 0x00898529 File Offset: 0x00896929
		public static void AddFrameEffects(FlatBufferBuilder builder, VectorOffset frameEffectsOffset)
		{
			builder.AddOffset(76, frameEffectsOffset.Value, 0);
		}

		// Token: 0x0601C483 RID: 115843 RVA: 0x0089853C File Offset: 0x0089693C
		public static VectorOffset CreateFrameEffectsVector(FlatBufferBuilder builder, Offset<DSkillFrameEffect>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C484 RID: 115844 RVA: 0x00898582 File Offset: 0x00896982
		public static void StartFrameEffectsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C485 RID: 115845 RVA: 0x0089858D File Offset: 0x0089698D
		public static void AddCameraMoves(FlatBufferBuilder builder, VectorOffset cameraMovesOffset)
		{
			builder.AddOffset(77, cameraMovesOffset.Value, 0);
		}

		// Token: 0x0601C486 RID: 115846 RVA: 0x008985A0 File Offset: 0x008969A0
		public static VectorOffset CreateCameraMovesVector(FlatBufferBuilder builder, Offset<DSkillCameraMove>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C487 RID: 115847 RVA: 0x008985E6 File Offset: 0x008969E6
		public static void StartCameraMovesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C488 RID: 115848 RVA: 0x008985F1 File Offset: 0x008969F1
		public static void AddWalkControl(FlatBufferBuilder builder, VectorOffset walkControlOffset)
		{
			builder.AddOffset(78, walkControlOffset.Value, 0);
		}

		// Token: 0x0601C489 RID: 115849 RVA: 0x00898604 File Offset: 0x00896A04
		public static VectorOffset CreateWalkControlVector(FlatBufferBuilder builder, Offset<DSkillWalkControl>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C48A RID: 115850 RVA: 0x0089864A File Offset: 0x00896A4A
		public static void StartWalkControlVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C48B RID: 115851 RVA: 0x00898655 File Offset: 0x00896A55
		public static void AddActions(FlatBufferBuilder builder, VectorOffset actionsOffset)
		{
			builder.AddOffset(79, actionsOffset.Value, 0);
		}

		// Token: 0x0601C48C RID: 115852 RVA: 0x00898668 File Offset: 0x00896A68
		public static VectorOffset CreateActionsVector(FlatBufferBuilder builder, Offset<DActionData>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C48D RID: 115853 RVA: 0x008986AE File Offset: 0x00896AAE
		public static void StartActionsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C48E RID: 115854 RVA: 0x008986B9 File Offset: 0x00896AB9
		public static void AddBuffs(FlatBufferBuilder builder, VectorOffset buffsOffset)
		{
			builder.AddOffset(80, buffsOffset.Value, 0);
		}

		// Token: 0x0601C48F RID: 115855 RVA: 0x008986CC File Offset: 0x00896ACC
		public static VectorOffset CreateBuffsVector(FlatBufferBuilder builder, Offset<DSkillBuff>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C490 RID: 115856 RVA: 0x00898712 File Offset: 0x00896B12
		public static void StartBuffsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C491 RID: 115857 RVA: 0x0089871D File Offset: 0x00896B1D
		public static void AddSummons(FlatBufferBuilder builder, VectorOffset summonsOffset)
		{
			builder.AddOffset(81, summonsOffset.Value, 0);
		}

		// Token: 0x0601C492 RID: 115858 RVA: 0x00898730 File Offset: 0x00896B30
		public static VectorOffset CreateSummonsVector(FlatBufferBuilder builder, Offset<DSkillSummon>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C493 RID: 115859 RVA: 0x00898776 File Offset: 0x00896B76
		public static void StartSummonsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C494 RID: 115860 RVA: 0x00898781 File Offset: 0x00896B81
		public static void AddMechanisms(FlatBufferBuilder builder, VectorOffset mechanismsOffset)
		{
			builder.AddOffset(82, mechanismsOffset.Value, 0);
		}

		// Token: 0x0601C495 RID: 115861 RVA: 0x00898794 File Offset: 0x00896B94
		public static VectorOffset CreateMechanismsVector(FlatBufferBuilder builder, Offset<DSkillMechanism>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C496 RID: 115862 RVA: 0x008987DA File Offset: 0x00896BDA
		public static void StartMechanismsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C497 RID: 115863 RVA: 0x008987E8 File Offset: 0x00896BE8
		public static Offset<FBSkillData> EndFBSkillData(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FBSkillData>(value);
		}
	}
}
