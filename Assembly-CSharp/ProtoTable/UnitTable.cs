using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200060C RID: 1548
	public class UnitTable : IFlatbufferObject
	{
		// Token: 0x17001693 RID: 5779
		// (get) Token: 0x060051BD RID: 20925 RVA: 0x000FB5D4 File Offset: 0x000F99D4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060051BE RID: 20926 RVA: 0x000FB5E1 File Offset: 0x000F99E1
		public static UnitTable GetRootAsUnitTable(ByteBuffer _bb)
		{
			return UnitTable.GetRootAsUnitTable(_bb, new UnitTable());
		}

		// Token: 0x060051BF RID: 20927 RVA: 0x000FB5EE File Offset: 0x000F99EE
		public static UnitTable GetRootAsUnitTable(ByteBuffer _bb, UnitTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060051C0 RID: 20928 RVA: 0x000FB60A File Offset: 0x000F9A0A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060051C1 RID: 20929 RVA: 0x000FB624 File Offset: 0x000F9A24
		public UnitTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001694 RID: 5780
		// (get) Token: 0x060051C2 RID: 20930 RVA: 0x000FB630 File Offset: 0x000F9A30
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001695 RID: 5781
		// (get) Token: 0x060051C3 RID: 20931 RVA: 0x000FB67C File Offset: 0x000F9A7C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051C4 RID: 20932 RVA: 0x000FB6BE File Offset: 0x000F9ABE
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001696 RID: 5782
		// (get) Token: 0x060051C5 RID: 20933 RVA: 0x000FB6CC File Offset: 0x000F9ACC
		public string BossShowActionName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051C6 RID: 20934 RVA: 0x000FB70E File Offset: 0x000F9B0E
		public ArraySegment<byte>? GetBossShowActionNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001697 RID: 5783
		// (get) Token: 0x060051C7 RID: 20935 RVA: 0x000FB71C File Offset: 0x000F9B1C
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051C8 RID: 20936 RVA: 0x000FB75F File Offset: 0x000F9B5F
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001698 RID: 5784
		// (get) Token: 0x060051C9 RID: 20937 RVA: 0x000FB770 File Offset: 0x000F9B70
		public int MonsterMode
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001699 RID: 5785
		// (get) Token: 0x060051CA RID: 20938 RVA: 0x000FB7BC File Offset: 0x000F9BBC
		public UnitTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(14);
				return (UnitTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700169A RID: 5786
		// (get) Token: 0x060051CB RID: 20939 RVA: 0x000FB800 File Offset: 0x000F9C00
		public int IsShowPortrait
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700169B RID: 5787
		// (get) Token: 0x060051CC RID: 20940 RVA: 0x000FB84C File Offset: 0x000F9C4C
		public UnitTable.eCamp Camp
		{
			get
			{
				int num = this.__p.__offset(18);
				return (UnitTable.eCamp)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700169C RID: 5788
		// (get) Token: 0x060051CD RID: 20941 RVA: 0x000FB890 File Offset: 0x000F9C90
		public UnitTable.eMonsterRace MonsterRace
		{
			get
			{
				int num = this.__p.__offset(20);
				return (UnitTable.eMonsterRace)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700169D RID: 5789
		// (get) Token: 0x060051CE RID: 20942 RVA: 0x000FB8D4 File Offset: 0x000F9CD4
		public int Mode
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700169E RID: 5790
		// (get) Token: 0x060051CF RID: 20943 RVA: 0x000FB920 File Offset: 0x000F9D20
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700169F RID: 5791
		// (get) Token: 0x060051D0 RID: 20944 RVA: 0x000FB96C File Offset: 0x000F9D6C
		public int AutoFightNeedAttackFirst
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A0 RID: 5792
		// (get) Token: 0x060051D1 RID: 20945 RVA: 0x000FB9B8 File Offset: 0x000F9DB8
		public int SkillMonsterCanBeAttack
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A1 RID: 5793
		// (get) Token: 0x060051D2 RID: 20946 RVA: 0x000FBA04 File Offset: 0x000F9E04
		public UnionCell Scale
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016A2 RID: 5794
		// (get) Token: 0x060051D3 RID: 20947 RVA: 0x000FBA5C File Offset: 0x000F9E5C
		public int enhanceRadius
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A3 RID: 5795
		// (get) Token: 0x060051D4 RID: 20948 RVA: 0x000FBAA8 File Offset: 0x000F9EA8
		public int overHeadHeight
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A4 RID: 5796
		// (get) Token: 0x060051D5 RID: 20949 RVA: 0x000FBAF4 File Offset: 0x000F9EF4
		public int buffOriginHeight
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A5 RID: 5797
		// (get) Token: 0x060051D6 RID: 20950 RVA: 0x000FBB40 File Offset: 0x000F9F40
		public int WalkSpeed
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A6 RID: 5798
		// (get) Token: 0x060051D7 RID: 20951 RVA: 0x000FBB8C File Offset: 0x000F9F8C
		public int WalkAnimationSpeedPerent
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A7 RID: 5799
		// (get) Token: 0x060051D8 RID: 20952 RVA: 0x000FBBD8 File Offset: 0x000F9FD8
		public int MonsterTitle
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A8 RID: 5800
		// (get) Token: 0x060051D9 RID: 20953 RVA: 0x000FBC24 File Offset: 0x000FA024
		public int AttackSkillID
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016A9 RID: 5801
		// (get) Token: 0x060051DA RID: 20954 RVA: 0x000FBC70 File Offset: 0x000FA070
		public int GetupBati
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016AA RID: 5802
		// (get) Token: 0x060051DB RID: 20955 RVA: 0x000FBCBC File Offset: 0x000FA0BC
		public int GetupSkillRand
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016AB RID: 5803
		// (get) Token: 0x060051DC RID: 20956 RVA: 0x000FBD08 File Offset: 0x000FA108
		public int GetupSkillID
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016AC RID: 5804
		// (get) Token: 0x060051DD RID: 20957 RVA: 0x000FBD54 File Offset: 0x000FA154
		public int HitSkillRand
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016AD RID: 5805
		// (get) Token: 0x060051DE RID: 20958 RVA: 0x000FBDA0 File Offset: 0x000FA1A0
		public int HitSkillID
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060051DF RID: 20959 RVA: 0x000FBDEC File Offset: 0x000FA1EC
		public int SkillIDsArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016AE RID: 5806
		// (get) Token: 0x060051E0 RID: 20960 RVA: 0x000FBE3C File Offset: 0x000FA23C
		public int SkillIDsLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060051E1 RID: 20961 RVA: 0x000FBE6F File Offset: 0x000FA26F
		public ArraySegment<byte>? GetSkillIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x170016AF RID: 5807
		// (get) Token: 0x060051E2 RID: 20962 RVA: 0x000FBE7E File Offset: 0x000FA27E
		public FlatBufferArray<int> SkillIDs
		{
			get
			{
				if (this.SkillIDsValue == null)
				{
					this.SkillIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.SkillIDsArray), this.SkillIDsLength);
				}
				return this.SkillIDsValue;
			}
		}

		// Token: 0x170016B0 RID: 5808
		// (get) Token: 0x060051E3 RID: 20963 RVA: 0x000FBEB0 File Offset: 0x000FA2B0
		public string Hurt
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051E4 RID: 20964 RVA: 0x000FBEF3 File Offset: 0x000FA2F3
		public ArraySegment<byte>? GetHurtBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x170016B1 RID: 5809
		// (get) Token: 0x060051E5 RID: 20965 RVA: 0x000FBF04 File Offset: 0x000FA304
		public string FootEffectName
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051E6 RID: 20966 RVA: 0x000FBF47 File Offset: 0x000FA347
		public ArraySegment<byte>? GetFootEffectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x170016B2 RID: 5810
		// (get) Token: 0x060051E7 RID: 20967 RVA: 0x000FBF58 File Offset: 0x000FA358
		public string WeaponModel
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051E8 RID: 20968 RVA: 0x000FBF9B File Offset: 0x000FA39B
		public ArraySegment<byte>? GetWeaponModelBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x170016B3 RID: 5811
		// (get) Token: 0x060051E9 RID: 20969 RVA: 0x000FBFAC File Offset: 0x000FA3AC
		public string WeaponLocator
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051EA RID: 20970 RVA: 0x000FBFEF File Offset: 0x000FA3EF
		public ArraySegment<byte>? GetWeaponLocatorBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x170016B4 RID: 5812
		// (get) Token: 0x060051EB RID: 20971 RVA: 0x000FC000 File Offset: 0x000FA400
		public int Exp
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016B5 RID: 5813
		// (get) Token: 0x060051EC RID: 20972 RVA: 0x000FC04C File Offset: 0x000FA44C
		public string PrefixEffect
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051ED RID: 20973 RVA: 0x000FC08F File Offset: 0x000FA48F
		public ArraySegment<byte>? GetPrefixEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x170016B6 RID: 5814
		// (get) Token: 0x060051EE RID: 20974 RVA: 0x000FC0A0 File Offset: 0x000FA4A0
		public int DefaultAttackHitSFXID
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016B7 RID: 5815
		// (get) Token: 0x060051EF RID: 20975 RVA: 0x000FC0EC File Offset: 0x000FA4EC
		public int DropID
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016B8 RID: 5816
		// (get) Token: 0x060051F0 RID: 20976 RVA: 0x000FC138 File Offset: 0x000FA538
		public int DailyDropNum
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016B9 RID: 5817
		// (get) Token: 0x060051F1 RID: 20977 RVA: 0x000FC184 File Offset: 0x000FA584
		public int AwardID
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016BA RID: 5818
		// (get) Token: 0x060051F2 RID: 20978 RVA: 0x000FC1D0 File Offset: 0x000FA5D0
		public UnionCell ExistDuration
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016BB RID: 5819
		// (get) Token: 0x060051F3 RID: 20979 RVA: 0x000FC228 File Offset: 0x000FA628
		public UnionCell PVPExistDuration
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016BC RID: 5820
		// (get) Token: 0x060051F4 RID: 20980 RVA: 0x000FC280 File Offset: 0x000FA680
		public int FloatValue
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016BD RID: 5821
		// (get) Token: 0x060051F5 RID: 20981 RVA: 0x000FC2CC File Offset: 0x000FA6CC
		public string DescriptionA
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060051F6 RID: 20982 RVA: 0x000FC30F File Offset: 0x000FA70F
		public ArraySegment<byte>? GetDescriptionABytes()
		{
			return this.__p.__vector_as_arraysegment(84);
		}

		// Token: 0x170016BE RID: 5822
		// (get) Token: 0x060051F7 RID: 20983 RVA: 0x000FC320 File Offset: 0x000FA720
		public int ValueA
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060051F8 RID: 20984 RVA: 0x000FC36C File Offset: 0x000FA76C
		public int WalkSpeechArray(int j)
		{
			int num = this.__p.__offset(88);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016BF RID: 5823
		// (get) Token: 0x060051F9 RID: 20985 RVA: 0x000FC3BC File Offset: 0x000FA7BC
		public int WalkSpeechLength
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060051FA RID: 20986 RVA: 0x000FC3EF File Offset: 0x000FA7EF
		public ArraySegment<byte>? GetWalkSpeechBytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x170016C0 RID: 5824
		// (get) Token: 0x060051FB RID: 20987 RVA: 0x000FC3FE File Offset: 0x000FA7FE
		public FlatBufferArray<int> WalkSpeech
		{
			get
			{
				if (this.WalkSpeechValue == null)
				{
					this.WalkSpeechValue = new FlatBufferArray<int>(new Func<int, int>(this.WalkSpeechArray), this.WalkSpeechLength);
				}
				return this.WalkSpeechValue;
			}
		}

		// Token: 0x060051FC RID: 20988 RVA: 0x000FC430 File Offset: 0x000FA830
		public int AttackSpeechArray(int j)
		{
			int num = this.__p.__offset(90);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016C1 RID: 5825
		// (get) Token: 0x060051FD RID: 20989 RVA: 0x000FC480 File Offset: 0x000FA880
		public int AttackSpeechLength
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060051FE RID: 20990 RVA: 0x000FC4B3 File Offset: 0x000FA8B3
		public ArraySegment<byte>? GetAttackSpeechBytes()
		{
			return this.__p.__vector_as_arraysegment(90);
		}

		// Token: 0x170016C2 RID: 5826
		// (get) Token: 0x060051FF RID: 20991 RVA: 0x000FC4C2 File Offset: 0x000FA8C2
		public FlatBufferArray<int> AttackSpeech
		{
			get
			{
				if (this.AttackSpeechValue == null)
				{
					this.AttackSpeechValue = new FlatBufferArray<int>(new Func<int, int>(this.AttackSpeechArray), this.AttackSpeechLength);
				}
				return this.AttackSpeechValue;
			}
		}

		// Token: 0x06005200 RID: 20992 RVA: 0x000FC4F4 File Offset: 0x000FA8F4
		public int BirthSpeechArray(int j)
		{
			int num = this.__p.__offset(92);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016C3 RID: 5827
		// (get) Token: 0x06005201 RID: 20993 RVA: 0x000FC544 File Offset: 0x000FA944
		public int BirthSpeechLength
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005202 RID: 20994 RVA: 0x000FC577 File Offset: 0x000FA977
		public ArraySegment<byte>? GetBirthSpeechBytes()
		{
			return this.__p.__vector_as_arraysegment(92);
		}

		// Token: 0x170016C4 RID: 5828
		// (get) Token: 0x06005203 RID: 20995 RVA: 0x000FC586 File Offset: 0x000FA986
		public FlatBufferArray<int> BirthSpeech
		{
			get
			{
				if (this.BirthSpeechValue == null)
				{
					this.BirthSpeechValue = new FlatBufferArray<int>(new Func<int, int>(this.BirthSpeechArray), this.BirthSpeechLength);
				}
				return this.BirthSpeechValue;
			}
		}

		// Token: 0x170016C5 RID: 5829
		// (get) Token: 0x06005204 RID: 20996 RVA: 0x000FC5B8 File Offset: 0x000FA9B8
		public bool ShowName
		{
			get
			{
				int num = this.__p.__offset(94);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170016C6 RID: 5830
		// (get) Token: 0x06005205 RID: 20997 RVA: 0x000FC604 File Offset: 0x000FAA04
		public bool ShowHPBar
		{
			get
			{
				int num = this.__p.__offset(96);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170016C7 RID: 5831
		// (get) Token: 0x06005206 RID: 20998 RVA: 0x000FC650 File Offset: 0x000FAA50
		public int ShowFootBar
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005207 RID: 20999 RVA: 0x000FC69C File Offset: 0x000FAA9C
		public int AbilityChangeArray(int j)
		{
			int num = this.__p.__offset(100);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016C8 RID: 5832
		// (get) Token: 0x06005208 RID: 21000 RVA: 0x000FC6EC File Offset: 0x000FAAEC
		public int AbilityChangeLength
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005209 RID: 21001 RVA: 0x000FC71F File Offset: 0x000FAB1F
		public ArraySegment<byte>? GetAbilityChangeBytes()
		{
			return this.__p.__vector_as_arraysegment(100);
		}

		// Token: 0x170016C9 RID: 5833
		// (get) Token: 0x0600520A RID: 21002 RVA: 0x000FC72E File Offset: 0x000FAB2E
		public FlatBufferArray<int> AbilityChange
		{
			get
			{
				if (this.AbilityChangeValue == null)
				{
					this.AbilityChangeValue = new FlatBufferArray<int>(new Func<int, int>(this.AbilityChangeArray), this.AbilityChangeLength);
				}
				return this.AbilityChangeValue;
			}
		}

		// Token: 0x0600520B RID: 21003 RVA: 0x000FC760 File Offset: 0x000FAB60
		public int BornBuffArray(int j)
		{
			int num = this.__p.__offset(102);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016CA RID: 5834
		// (get) Token: 0x0600520C RID: 21004 RVA: 0x000FC7B0 File Offset: 0x000FABB0
		public int BornBuffLength
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600520D RID: 21005 RVA: 0x000FC7E3 File Offset: 0x000FABE3
		public ArraySegment<byte>? GetBornBuffBytes()
		{
			return this.__p.__vector_as_arraysegment(102);
		}

		// Token: 0x170016CB RID: 5835
		// (get) Token: 0x0600520E RID: 21006 RVA: 0x000FC7F2 File Offset: 0x000FABF2
		public FlatBufferArray<int> BornBuff
		{
			get
			{
				if (this.BornBuffValue == null)
				{
					this.BornBuffValue = new FlatBufferArray<int>(new Func<int, int>(this.BornBuffArray), this.BornBuffLength);
				}
				return this.BornBuffValue;
			}
		}

		// Token: 0x0600520F RID: 21007 RVA: 0x000FC824 File Offset: 0x000FAC24
		public int BornBuff2Array(int j)
		{
			int num = this.__p.__offset(104);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016CC RID: 5836
		// (get) Token: 0x06005210 RID: 21008 RVA: 0x000FC874 File Offset: 0x000FAC74
		public int BornBuff2Length
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005211 RID: 21009 RVA: 0x000FC8A7 File Offset: 0x000FACA7
		public ArraySegment<byte>? GetBornBuff2Bytes()
		{
			return this.__p.__vector_as_arraysegment(104);
		}

		// Token: 0x170016CD RID: 5837
		// (get) Token: 0x06005212 RID: 21010 RVA: 0x000FC8B6 File Offset: 0x000FACB6
		public FlatBufferArray<int> BornBuff2
		{
			get
			{
				if (this.BornBuff2Value == null)
				{
					this.BornBuff2Value = new FlatBufferArray<int>(new Func<int, int>(this.BornBuff2Array), this.BornBuff2Length);
				}
				return this.BornBuff2Value;
			}
		}

		// Token: 0x06005213 RID: 21011 RVA: 0x000FC8E8 File Offset: 0x000FACE8
		public int BornMechanismArray(int j)
		{
			int num = this.__p.__offset(106);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016CE RID: 5838
		// (get) Token: 0x06005214 RID: 21012 RVA: 0x000FC938 File Offset: 0x000FAD38
		public int BornMechanismLength
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005215 RID: 21013 RVA: 0x000FC96B File Offset: 0x000FAD6B
		public ArraySegment<byte>? GetBornMechanismBytes()
		{
			return this.__p.__vector_as_arraysegment(106);
		}

		// Token: 0x170016CF RID: 5839
		// (get) Token: 0x06005216 RID: 21014 RVA: 0x000FC97A File Offset: 0x000FAD7A
		public FlatBufferArray<int> BornMechanism
		{
			get
			{
				if (this.BornMechanismValue == null)
				{
					this.BornMechanismValue = new FlatBufferArray<int>(new Func<int, int>(this.BornMechanismArray), this.BornMechanismLength);
				}
				return this.BornMechanismValue;
			}
		}

		// Token: 0x170016D0 RID: 5840
		// (get) Token: 0x06005217 RID: 21015 RVA: 0x000FC9AC File Offset: 0x000FADAC
		public UnionCell maxFixHp
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016D1 RID: 5841
		// (get) Token: 0x06005218 RID: 21016 RVA: 0x000FCA04 File Offset: 0x000FAE04
		public int maxHp
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016D2 RID: 5842
		// (get) Token: 0x06005219 RID: 21017 RVA: 0x000FCA50 File Offset: 0x000FAE50
		public int maxMp
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016D3 RID: 5843
		// (get) Token: 0x0600521A RID: 21018 RVA: 0x000FCA9C File Offset: 0x000FAE9C
		public int hpRecover
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016D4 RID: 5844
		// (get) Token: 0x0600521B RID: 21019 RVA: 0x000FCAE8 File Offset: 0x000FAEE8
		public int mpRecover
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016D5 RID: 5845
		// (get) Token: 0x0600521C RID: 21020 RVA: 0x000FCB34 File Offset: 0x000FAF34
		public int attack
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016D6 RID: 5846
		// (get) Token: 0x0600521D RID: 21021 RVA: 0x000FCB80 File Offset: 0x000FAF80
		public int magicAttack
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016D7 RID: 5847
		// (get) Token: 0x0600521E RID: 21022 RVA: 0x000FCBCC File Offset: 0x000FAFCC
		public int defence
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016D8 RID: 5848
		// (get) Token: 0x0600521F RID: 21023 RVA: 0x000FCC18 File Offset: 0x000FB018
		public int magicDefence
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016D9 RID: 5849
		// (get) Token: 0x06005220 RID: 21024 RVA: 0x000FCC64 File Offset: 0x000FB064
		public int attackSpeed
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016DA RID: 5850
		// (get) Token: 0x06005221 RID: 21025 RVA: 0x000FCCB0 File Offset: 0x000FB0B0
		public int spellSpeed
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016DB RID: 5851
		// (get) Token: 0x06005222 RID: 21026 RVA: 0x000FCD00 File Offset: 0x000FB100
		public int moveSpeed
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016DC RID: 5852
		// (get) Token: 0x06005223 RID: 21027 RVA: 0x000FCD50 File Offset: 0x000FB150
		public int ciriticalAttack
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016DD RID: 5853
		// (get) Token: 0x06005224 RID: 21028 RVA: 0x000FCDA0 File Offset: 0x000FB1A0
		public int ciriticalMagicAttack
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016DE RID: 5854
		// (get) Token: 0x06005225 RID: 21029 RVA: 0x000FCDF0 File Offset: 0x000FB1F0
		public int dex
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016DF RID: 5855
		// (get) Token: 0x06005226 RID: 21030 RVA: 0x000FCE40 File Offset: 0x000FB240
		public int dodge
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E0 RID: 5856
		// (get) Token: 0x06005227 RID: 21031 RVA: 0x000FCE90 File Offset: 0x000FB290
		public int frozen
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E1 RID: 5857
		// (get) Token: 0x06005228 RID: 21032 RVA: 0x000FCEE0 File Offset: 0x000FB2E0
		public int hard
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E2 RID: 5858
		// (get) Token: 0x06005229 RID: 21033 RVA: 0x000FCF30 File Offset: 0x000FB330
		public int cdReduceRate
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E3 RID: 5859
		// (get) Token: 0x0600522A RID: 21034 RVA: 0x000FCF80 File Offset: 0x000FB380
		public int baseAtk
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E4 RID: 5860
		// (get) Token: 0x0600522B RID: 21035 RVA: 0x000FCFD0 File Offset: 0x000FB3D0
		public int baseInt
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E5 RID: 5861
		// (get) Token: 0x0600522C RID: 21036 RVA: 0x000FD020 File Offset: 0x000FB420
		public int sta
		{
			get
			{
				int num = this.__p.__offset(150);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E6 RID: 5862
		// (get) Token: 0x0600522D RID: 21037 RVA: 0x000FD070 File Offset: 0x000FB470
		public int spr
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E7 RID: 5863
		// (get) Token: 0x0600522E RID: 21038 RVA: 0x000FD0C0 File Offset: 0x000FB4C0
		public int ignoreDefAttackAdd
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E8 RID: 5864
		// (get) Token: 0x0600522F RID: 21039 RVA: 0x000FD110 File Offset: 0x000FB510
		public int ignoreDefMagicAttackAdd
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170016E9 RID: 5865
		// (get) Token: 0x06005230 RID: 21040 RVA: 0x000FD160 File Offset: 0x000FB560
		public int baseIndependence
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005231 RID: 21041 RVA: 0x000FD1B0 File Offset: 0x000FB5B0
		public int ElementsArray(int j)
		{
			int num = this.__p.__offset(160);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170016EA RID: 5866
		// (get) Token: 0x06005232 RID: 21042 RVA: 0x000FD200 File Offset: 0x000FB600
		public int ElementsLength
		{
			get
			{
				int num = this.__p.__offset(160);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005233 RID: 21043 RVA: 0x000FD236 File Offset: 0x000FB636
		public ArraySegment<byte>? GetElementsBytes()
		{
			return this.__p.__vector_as_arraysegment(160);
		}

		// Token: 0x170016EB RID: 5867
		// (get) Token: 0x06005234 RID: 21044 RVA: 0x000FD248 File Offset: 0x000FB648
		public FlatBufferArray<int> Elements
		{
			get
			{
				if (this.ElementsValue == null)
				{
					this.ElementsValue = new FlatBufferArray<int>(new Func<int, int>(this.ElementsArray), this.ElementsLength);
				}
				return this.ElementsValue;
			}
		}

		// Token: 0x170016EC RID: 5868
		// (get) Token: 0x06005235 RID: 21045 RVA: 0x000FD278 File Offset: 0x000FB678
		public UnionCell LightAttack
		{
			get
			{
				int num = this.__p.__offset(162);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016ED RID: 5869
		// (get) Token: 0x06005236 RID: 21046 RVA: 0x000FD2D4 File Offset: 0x000FB6D4
		public UnionCell FireAttack
		{
			get
			{
				int num = this.__p.__offset(164);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016EE RID: 5870
		// (get) Token: 0x06005237 RID: 21047 RVA: 0x000FD330 File Offset: 0x000FB730
		public UnionCell IceAttack
		{
			get
			{
				int num = this.__p.__offset(166);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016EF RID: 5871
		// (get) Token: 0x06005238 RID: 21048 RVA: 0x000FD38C File Offset: 0x000FB78C
		public UnionCell DarkAttack
		{
			get
			{
				int num = this.__p.__offset(168);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F0 RID: 5872
		// (get) Token: 0x06005239 RID: 21049 RVA: 0x000FD3E8 File Offset: 0x000FB7E8
		public UnionCell LightDefence
		{
			get
			{
				int num = this.__p.__offset(170);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F1 RID: 5873
		// (get) Token: 0x0600523A RID: 21050 RVA: 0x000FD444 File Offset: 0x000FB844
		public UnionCell FireDefence
		{
			get
			{
				int num = this.__p.__offset(172);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F2 RID: 5874
		// (get) Token: 0x0600523B RID: 21051 RVA: 0x000FD4A0 File Offset: 0x000FB8A0
		public UnionCell IceDefence
		{
			get
			{
				int num = this.__p.__offset(174);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F3 RID: 5875
		// (get) Token: 0x0600523C RID: 21052 RVA: 0x000FD4FC File Offset: 0x000FB8FC
		public UnionCell DarkDefence
		{
			get
			{
				int num = this.__p.__offset(176);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F4 RID: 5876
		// (get) Token: 0x0600523D RID: 21053 RVA: 0x000FD558 File Offset: 0x000FB958
		public UnionCell abnormalResist1
		{
			get
			{
				int num = this.__p.__offset(178);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F5 RID: 5877
		// (get) Token: 0x0600523E RID: 21054 RVA: 0x000FD5B4 File Offset: 0x000FB9B4
		public UnionCell abnormalResist2
		{
			get
			{
				int num = this.__p.__offset(180);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F6 RID: 5878
		// (get) Token: 0x0600523F RID: 21055 RVA: 0x000FD610 File Offset: 0x000FBA10
		public UnionCell abnormalResist3
		{
			get
			{
				int num = this.__p.__offset(182);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F7 RID: 5879
		// (get) Token: 0x06005240 RID: 21056 RVA: 0x000FD66C File Offset: 0x000FBA6C
		public UnionCell abnormalResist4
		{
			get
			{
				int num = this.__p.__offset(184);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F8 RID: 5880
		// (get) Token: 0x06005241 RID: 21057 RVA: 0x000FD6C8 File Offset: 0x000FBAC8
		public UnionCell abnormalResist5
		{
			get
			{
				int num = this.__p.__offset(186);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016F9 RID: 5881
		// (get) Token: 0x06005242 RID: 21058 RVA: 0x000FD724 File Offset: 0x000FBB24
		public UnionCell abnormalResist6
		{
			get
			{
				int num = this.__p.__offset(188);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016FA RID: 5882
		// (get) Token: 0x06005243 RID: 21059 RVA: 0x000FD780 File Offset: 0x000FBB80
		public UnionCell abnormalResist7
		{
			get
			{
				int num = this.__p.__offset(190);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016FB RID: 5883
		// (get) Token: 0x06005244 RID: 21060 RVA: 0x000FD7DC File Offset: 0x000FBBDC
		public UnionCell abnormalResist8
		{
			get
			{
				int num = this.__p.__offset(192);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016FC RID: 5884
		// (get) Token: 0x06005245 RID: 21061 RVA: 0x000FD838 File Offset: 0x000FBC38
		public UnionCell abnormalResist9
		{
			get
			{
				int num = this.__p.__offset(194);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016FD RID: 5885
		// (get) Token: 0x06005246 RID: 21062 RVA: 0x000FD894 File Offset: 0x000FBC94
		public UnionCell abnormalResist10
		{
			get
			{
				int num = this.__p.__offset(196);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016FE RID: 5886
		// (get) Token: 0x06005247 RID: 21063 RVA: 0x000FD8F0 File Offset: 0x000FBCF0
		public UnionCell abnormalResist11
		{
			get
			{
				int num = this.__p.__offset(198);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170016FF RID: 5887
		// (get) Token: 0x06005248 RID: 21064 RVA: 0x000FD94C File Offset: 0x000FBD4C
		public UnionCell abnormalResist12
		{
			get
			{
				int num = this.__p.__offset(200);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001700 RID: 5888
		// (get) Token: 0x06005249 RID: 21065 RVA: 0x000FD9A8 File Offset: 0x000FBDA8
		public UnionCell abnormalResist13
		{
			get
			{
				int num = this.__p.__offset(202);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001701 RID: 5889
		// (get) Token: 0x0600524A RID: 21066 RVA: 0x000FDA04 File Offset: 0x000FBE04
		public int UseProtect
		{
			get
			{
				int num = this.__p.__offset(204);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001702 RID: 5890
		// (get) Token: 0x0600524B RID: 21067 RVA: 0x000FDA54 File Offset: 0x000FBE54
		public int ProtectFloatPercent
		{
			get
			{
				int num = this.__p.__offset(206);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001703 RID: 5891
		// (get) Token: 0x0600524C RID: 21068 RVA: 0x000FDAA4 File Offset: 0x000FBEA4
		public int ProtectFloatPercent2
		{
			get
			{
				int num = this.__p.__offset(208);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001704 RID: 5892
		// (get) Token: 0x0600524D RID: 21069 RVA: 0x000FDAF4 File Offset: 0x000FBEF4
		public int ProtectGroundPercent
		{
			get
			{
				int num = this.__p.__offset(210);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001705 RID: 5893
		// (get) Token: 0x0600524E RID: 21070 RVA: 0x000FDB44 File Offset: 0x000FBF44
		public int ProtectStandPercent
		{
			get
			{
				int num = this.__p.__offset(212);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001706 RID: 5894
		// (get) Token: 0x0600524F RID: 21071 RVA: 0x000FDB94 File Offset: 0x000FBF94
		public UnitTable.eBornAI BornAI
		{
			get
			{
				int num = this.__p.__offset(214);
				return (UnitTable.eBornAI)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001707 RID: 5895
		// (get) Token: 0x06005250 RID: 21072 RVA: 0x000FDBDC File Offset: 0x000FBFDC
		public int AICombatType
		{
			get
			{
				int num = this.__p.__offset(216);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005251 RID: 21073 RVA: 0x000FDC2C File Offset: 0x000FC02C
		public int AITargetTypeArray(int j)
		{
			int num = this.__p.__offset(218);
			return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001708 RID: 5896
		// (get) Token: 0x06005252 RID: 21074 RVA: 0x000FDC7C File Offset: 0x000FC07C
		public int AITargetTypeLength
		{
			get
			{
				int num = this.__p.__offset(218);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005253 RID: 21075 RVA: 0x000FDCB2 File Offset: 0x000FC0B2
		public ArraySegment<byte>? GetAITargetTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(218);
		}

		// Token: 0x17001709 RID: 5897
		// (get) Token: 0x06005254 RID: 21076 RVA: 0x000FDCC4 File Offset: 0x000FC0C4
		public FlatBufferArray<int> AITargetType
		{
			get
			{
				if (this.AITargetTypeValue == null)
				{
					this.AITargetTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.AITargetTypeArray), this.AITargetTypeLength);
				}
				return this.AITargetTypeValue;
			}
		}

		// Token: 0x1700170A RID: 5898
		// (get) Token: 0x06005255 RID: 21077 RVA: 0x000FDCF4 File Offset: 0x000FC0F4
		public int AISight
		{
			get
			{
				int num = this.__p.__offset(220);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700170B RID: 5899
		// (get) Token: 0x06005256 RID: 21078 RVA: 0x000FDD44 File Offset: 0x000FC144
		public int AIChase
		{
			get
			{
				int num = this.__p.__offset(222);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700170C RID: 5900
		// (get) Token: 0x06005257 RID: 21079 RVA: 0x000FDD94 File Offset: 0x000FC194
		public int AIWarlike
		{
			get
			{
				int num = this.__p.__offset(224);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700170D RID: 5901
		// (get) Token: 0x06005258 RID: 21080 RVA: 0x000FDDE4 File Offset: 0x000FC1E4
		public int AIFollowDistance
		{
			get
			{
				int num = this.__p.__offset(226);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700170E RID: 5902
		// (get) Token: 0x06005259 RID: 21081 RVA: 0x000FDE34 File Offset: 0x000FC234
		public int AIKeepDistance
		{
			get
			{
				int num = this.__p.__offset(228);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700170F RID: 5903
		// (get) Token: 0x0600525A RID: 21082 RVA: 0x000FDE84 File Offset: 0x000FC284
		public int AIAttackDelay
		{
			get
			{
				int num = this.__p.__offset(230);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001710 RID: 5904
		// (get) Token: 0x0600525B RID: 21083 RVA: 0x000FDED4 File Offset: 0x000FC2D4
		public int AIDestinationChangeTerm
		{
			get
			{
				int num = this.__p.__offset(232);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001711 RID: 5905
		// (get) Token: 0x0600525C RID: 21084 RVA: 0x000FDF24 File Offset: 0x000FC324
		public int AIThinkTargetTerm
		{
			get
			{
				int num = this.__p.__offset(234);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600525D RID: 21085 RVA: 0x000FDF74 File Offset: 0x000FC374
		public string AIAttackKindArray(int j)
		{
			int num = this.__p.__offset(236);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001712 RID: 5906
		// (get) Token: 0x0600525E RID: 21086 RVA: 0x000FDFC0 File Offset: 0x000FC3C0
		public int AIAttackKindLength
		{
			get
			{
				int num = this.__p.__offset(236);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001713 RID: 5907
		// (get) Token: 0x0600525F RID: 21087 RVA: 0x000FDFF6 File Offset: 0x000FC3F6
		public FlatBufferArray<string> AIAttackKind
		{
			get
			{
				if (this.AIAttackKindValue == null)
				{
					this.AIAttackKindValue = new FlatBufferArray<string>(new Func<int, string>(this.AIAttackKindArray), this.AIAttackKindLength);
				}
				return this.AIAttackKindValue;
			}
		}

		// Token: 0x06005260 RID: 21088 RVA: 0x000FE028 File Offset: 0x000FC428
		public UnionCell DazeTimeArray(int j)
		{
			int num = this.__p.__offset(238);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17001714 RID: 5908
		// (get) Token: 0x06005261 RID: 21089 RVA: 0x000FE088 File Offset: 0x000FC488
		public int DazeTimeLength
		{
			get
			{
				int num = this.__p.__offset(238);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001715 RID: 5909
		// (get) Token: 0x06005262 RID: 21090 RVA: 0x000FE0BE File Offset: 0x000FC4BE
		public FlatBufferArray<UnionCell> DazeTime
		{
			get
			{
				if (this.DazeTimeValue == null)
				{
					this.DazeTimeValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.DazeTimeArray), this.DazeTimeLength);
				}
				return this.DazeTimeValue;
			}
		}

		// Token: 0x17001716 RID: 5910
		// (get) Token: 0x06005263 RID: 21091 RVA: 0x000FE0F0 File Offset: 0x000FC4F0
		public int AIIdleMode
		{
			get
			{
				int num = this.__p.__offset(240);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001717 RID: 5911
		// (get) Token: 0x06005264 RID: 21092 RVA: 0x000FE140 File Offset: 0x000FC540
		public int AIIsAPC
		{
			get
			{
				int num = this.__p.__offset(242);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001718 RID: 5912
		// (get) Token: 0x06005265 RID: 21093 RVA: 0x000FE190 File Offset: 0x000FC590
		public int AIIdleRand
		{
			get
			{
				int num = this.__p.__offset(244);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001719 RID: 5913
		// (get) Token: 0x06005266 RID: 21094 RVA: 0x000FE1E0 File Offset: 0x000FC5E0
		public int AIIdleDuration
		{
			get
			{
				int num = this.__p.__offset(246);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700171A RID: 5914
		// (get) Token: 0x06005267 RID: 21095 RVA: 0x000FE230 File Offset: 0x000FC630
		public int AIEscapeRand
		{
			get
			{
				int num = this.__p.__offset(248);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700171B RID: 5915
		// (get) Token: 0x06005268 RID: 21096 RVA: 0x000FE280 File Offset: 0x000FC680
		public int AIWanderRand
		{
			get
			{
				int num = this.__p.__offset(250);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700171C RID: 5916
		// (get) Token: 0x06005269 RID: 21097 RVA: 0x000FE2D0 File Offset: 0x000FC6D0
		public int AIWanderRange
		{
			get
			{
				int num = this.__p.__offset(252);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700171D RID: 5917
		// (get) Token: 0x0600526A RID: 21098 RVA: 0x000FE320 File Offset: 0x000FC720
		public int AIWalkBackRange
		{
			get
			{
				int num = this.__p.__offset(254);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700171E RID: 5918
		// (get) Token: 0x0600526B RID: 21099 RVA: 0x000FE370 File Offset: 0x000FC770
		public int AIYFirstRand
		{
			get
			{
				int num = this.__p.__offset(256);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700171F RID: 5919
		// (get) Token: 0x0600526C RID: 21100 RVA: 0x000FE3C0 File Offset: 0x000FC7C0
		public int AIMaxWalkCmdCount
		{
			get
			{
				int num = this.__p.__offset(258);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001720 RID: 5920
		// (get) Token: 0x0600526D RID: 21101 RVA: 0x000FE410 File Offset: 0x000FC810
		public int AIMaxIdleCmdCount
		{
			get
			{
				int num = this.__p.__offset(260);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001721 RID: 5921
		// (get) Token: 0x0600526E RID: 21102 RVA: 0x000FE460 File Offset: 0x000FC860
		public int AIWeaponTag
		{
			get
			{
				int num = this.__p.__offset(262);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001722 RID: 5922
		// (get) Token: 0x0600526F RID: 21103 RVA: 0x000FE4B0 File Offset: 0x000FC8B0
		public int APCIsSpecialConfig
		{
			get
			{
				int num = this.__p.__offset(264);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001723 RID: 5923
		// (get) Token: 0x06005270 RID: 21104 RVA: 0x000FE500 File Offset: 0x000FC900
		public int APCWeaponRes
		{
			get
			{
				int num = this.__p.__offset(266);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001724 RID: 5924
		// (get) Token: 0x06005271 RID: 21105 RVA: 0x000FE550 File Offset: 0x000FC950
		public int APCWeaponStrengthLevel
		{
			get
			{
				int num = this.__p.__offset(268);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001725 RID: 5925
		// (get) Token: 0x06005272 RID: 21106 RVA: 0x000FE5A0 File Offset: 0x000FC9A0
		public string AIActionPath
		{
			get
			{
				int num = this.__p.__offset(270);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005273 RID: 21107 RVA: 0x000FE5E6 File Offset: 0x000FC9E6
		public ArraySegment<byte>? GetAIActionPathBytes()
		{
			return this.__p.__vector_as_arraysegment(270);
		}

		// Token: 0x17001726 RID: 5926
		// (get) Token: 0x06005274 RID: 21108 RVA: 0x000FE5F8 File Offset: 0x000FC9F8
		public string AIDestinationSelectPath
		{
			get
			{
				int num = this.__p.__offset(272);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005275 RID: 21109 RVA: 0x000FE63E File Offset: 0x000FCA3E
		public ArraySegment<byte>? GetAIDestinationSelectPathBytes()
		{
			return this.__p.__vector_as_arraysegment(272);
		}

		// Token: 0x17001727 RID: 5927
		// (get) Token: 0x06005276 RID: 21110 RVA: 0x000FE650 File Offset: 0x000FCA50
		public string AIEventPath
		{
			get
			{
				int num = this.__p.__offset(274);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005277 RID: 21111 RVA: 0x000FE696 File Offset: 0x000FCA96
		public ArraySegment<byte>? GetAIEventPathBytes()
		{
			return this.__p.__vector_as_arraysegment(274);
		}

		// Token: 0x06005278 RID: 21112 RVA: 0x000FE6A8 File Offset: 0x000FCAA8
		public string AttackInModelStageArray(int j)
		{
			int num = this.__p.__offset(276);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001728 RID: 5928
		// (get) Token: 0x06005279 RID: 21113 RVA: 0x000FE6F4 File Offset: 0x000FCAF4
		public int AttackInModelStageLength
		{
			get
			{
				int num = this.__p.__offset(276);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001729 RID: 5929
		// (get) Token: 0x0600527A RID: 21114 RVA: 0x000FE72A File Offset: 0x000FCB2A
		public FlatBufferArray<string> AttackInModelStage
		{
			get
			{
				if (this.AttackInModelStageValue == null)
				{
					this.AttackInModelStageValue = new FlatBufferArray<string>(new Func<int, string>(this.AttackInModelStageArray), this.AttackInModelStageLength);
				}
				return this.AttackInModelStageValue;
			}
		}

		// Token: 0x1700172A RID: 5930
		// (get) Token: 0x0600527B RID: 21115 RVA: 0x000FE75C File Offset: 0x000FCB5C
		public bool playDeadAction
		{
			get
			{
				int num = this.__p.__offset(278);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700172B RID: 5931
		// (get) Token: 0x0600527C RID: 21116 RVA: 0x000FE7AC File Offset: 0x000FCBAC
		public int Height
		{
			get
			{
				int num = this.__p.__offset(280);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600527D RID: 21117 RVA: 0x000FE7F9 File Offset: 0x000FCBF9
		public static void StartUnitTable(FlatBufferBuilder builder)
		{
			builder.StartObject(139);
		}

		// Token: 0x0600527E RID: 21118 RVA: 0x000FE806 File Offset: 0x000FCC06
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600527F RID: 21119 RVA: 0x000FE811 File Offset: 0x000FCC11
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06005280 RID: 21120 RVA: 0x000FE822 File Offset: 0x000FCC22
		public static void AddBossShowActionName(FlatBufferBuilder builder, StringOffset BossShowActionNameOffset)
		{
			builder.AddOffset(2, BossShowActionNameOffset.Value, 0);
		}

		// Token: 0x06005281 RID: 21121 RVA: 0x000FE833 File Offset: 0x000FCC33
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(3, DescOffset.Value, 0);
		}

		// Token: 0x06005282 RID: 21122 RVA: 0x000FE844 File Offset: 0x000FCC44
		public static void AddMonsterMode(FlatBufferBuilder builder, int MonsterMode)
		{
			builder.AddInt(4, MonsterMode, 0);
		}

		// Token: 0x06005283 RID: 21123 RVA: 0x000FE84F File Offset: 0x000FCC4F
		public static void AddType(FlatBufferBuilder builder, UnitTable.eType Type)
		{
			builder.AddInt(5, (int)Type, 0);
		}

		// Token: 0x06005284 RID: 21124 RVA: 0x000FE85A File Offset: 0x000FCC5A
		public static void AddIsShowPortrait(FlatBufferBuilder builder, int IsShowPortrait)
		{
			builder.AddInt(6, IsShowPortrait, 0);
		}

		// Token: 0x06005285 RID: 21125 RVA: 0x000FE865 File Offset: 0x000FCC65
		public static void AddCamp(FlatBufferBuilder builder, UnitTable.eCamp Camp)
		{
			builder.AddInt(7, (int)Camp, 0);
		}

		// Token: 0x06005286 RID: 21126 RVA: 0x000FE870 File Offset: 0x000FCC70
		public static void AddMonsterRace(FlatBufferBuilder builder, UnitTable.eMonsterRace MonsterRace)
		{
			builder.AddInt(8, (int)MonsterRace, 0);
		}

		// Token: 0x06005287 RID: 21127 RVA: 0x000FE87B File Offset: 0x000FCC7B
		public static void AddMode(FlatBufferBuilder builder, int Mode)
		{
			builder.AddInt(9, Mode, 0);
		}

		// Token: 0x06005288 RID: 21128 RVA: 0x000FE887 File Offset: 0x000FCC87
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(10, Weight, 0);
		}

		// Token: 0x06005289 RID: 21129 RVA: 0x000FE893 File Offset: 0x000FCC93
		public static void AddAutoFightNeedAttackFirst(FlatBufferBuilder builder, int AutoFightNeedAttackFirst)
		{
			builder.AddInt(11, AutoFightNeedAttackFirst, 0);
		}

		// Token: 0x0600528A RID: 21130 RVA: 0x000FE89F File Offset: 0x000FCC9F
		public static void AddSkillMonsterCanBeAttack(FlatBufferBuilder builder, int SkillMonsterCanBeAttack)
		{
			builder.AddInt(12, SkillMonsterCanBeAttack, 0);
		}

		// Token: 0x0600528B RID: 21131 RVA: 0x000FE8AB File Offset: 0x000FCCAB
		public static void AddScale(FlatBufferBuilder builder, Offset<UnionCell> ScaleOffset)
		{
			builder.AddOffset(13, ScaleOffset.Value, 0);
		}

		// Token: 0x0600528C RID: 21132 RVA: 0x000FE8BD File Offset: 0x000FCCBD
		public static void AddEnhanceRadius(FlatBufferBuilder builder, int enhanceRadius)
		{
			builder.AddInt(14, enhanceRadius, 0);
		}

		// Token: 0x0600528D RID: 21133 RVA: 0x000FE8C9 File Offset: 0x000FCCC9
		public static void AddOverHeadHeight(FlatBufferBuilder builder, int overHeadHeight)
		{
			builder.AddInt(15, overHeadHeight, 0);
		}

		// Token: 0x0600528E RID: 21134 RVA: 0x000FE8D5 File Offset: 0x000FCCD5
		public static void AddBuffOriginHeight(FlatBufferBuilder builder, int buffOriginHeight)
		{
			builder.AddInt(16, buffOriginHeight, 0);
		}

		// Token: 0x0600528F RID: 21135 RVA: 0x000FE8E1 File Offset: 0x000FCCE1
		public static void AddWalkSpeed(FlatBufferBuilder builder, int WalkSpeed)
		{
			builder.AddInt(17, WalkSpeed, 0);
		}

		// Token: 0x06005290 RID: 21136 RVA: 0x000FE8ED File Offset: 0x000FCCED
		public static void AddWalkAnimationSpeedPerent(FlatBufferBuilder builder, int WalkAnimationSpeedPerent)
		{
			builder.AddInt(18, WalkAnimationSpeedPerent, 0);
		}

		// Token: 0x06005291 RID: 21137 RVA: 0x000FE8F9 File Offset: 0x000FCCF9
		public static void AddMonsterTitle(FlatBufferBuilder builder, int MonsterTitle)
		{
			builder.AddInt(19, MonsterTitle, 0);
		}

		// Token: 0x06005292 RID: 21138 RVA: 0x000FE905 File Offset: 0x000FCD05
		public static void AddAttackSkillID(FlatBufferBuilder builder, int AttackSkillID)
		{
			builder.AddInt(20, AttackSkillID, 0);
		}

		// Token: 0x06005293 RID: 21139 RVA: 0x000FE911 File Offset: 0x000FCD11
		public static void AddGetupBati(FlatBufferBuilder builder, int GetupBati)
		{
			builder.AddInt(21, GetupBati, 0);
		}

		// Token: 0x06005294 RID: 21140 RVA: 0x000FE91D File Offset: 0x000FCD1D
		public static void AddGetupSkillRand(FlatBufferBuilder builder, int GetupSkillRand)
		{
			builder.AddInt(22, GetupSkillRand, 0);
		}

		// Token: 0x06005295 RID: 21141 RVA: 0x000FE929 File Offset: 0x000FCD29
		public static void AddGetupSkillID(FlatBufferBuilder builder, int GetupSkillID)
		{
			builder.AddInt(23, GetupSkillID, 0);
		}

		// Token: 0x06005296 RID: 21142 RVA: 0x000FE935 File Offset: 0x000FCD35
		public static void AddHitSkillRand(FlatBufferBuilder builder, int HitSkillRand)
		{
			builder.AddInt(24, HitSkillRand, 0);
		}

		// Token: 0x06005297 RID: 21143 RVA: 0x000FE941 File Offset: 0x000FCD41
		public static void AddHitSkillID(FlatBufferBuilder builder, int HitSkillID)
		{
			builder.AddInt(25, HitSkillID, 0);
		}

		// Token: 0x06005298 RID: 21144 RVA: 0x000FE94D File Offset: 0x000FCD4D
		public static void AddSkillIDs(FlatBufferBuilder builder, VectorOffset SkillIDsOffset)
		{
			builder.AddOffset(26, SkillIDsOffset.Value, 0);
		}

		// Token: 0x06005299 RID: 21145 RVA: 0x000FE960 File Offset: 0x000FCD60
		public static VectorOffset CreateSkillIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600529A RID: 21146 RVA: 0x000FE99D File Offset: 0x000FCD9D
		public static void StartSkillIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600529B RID: 21147 RVA: 0x000FE9A8 File Offset: 0x000FCDA8
		public static void AddHurt(FlatBufferBuilder builder, StringOffset HurtOffset)
		{
			builder.AddOffset(27, HurtOffset.Value, 0);
		}

		// Token: 0x0600529C RID: 21148 RVA: 0x000FE9BA File Offset: 0x000FCDBA
		public static void AddFootEffectName(FlatBufferBuilder builder, StringOffset FootEffectNameOffset)
		{
			builder.AddOffset(28, FootEffectNameOffset.Value, 0);
		}

		// Token: 0x0600529D RID: 21149 RVA: 0x000FE9CC File Offset: 0x000FCDCC
		public static void AddWeaponModel(FlatBufferBuilder builder, StringOffset WeaponModelOffset)
		{
			builder.AddOffset(29, WeaponModelOffset.Value, 0);
		}

		// Token: 0x0600529E RID: 21150 RVA: 0x000FE9DE File Offset: 0x000FCDDE
		public static void AddWeaponLocator(FlatBufferBuilder builder, StringOffset WeaponLocatorOffset)
		{
			builder.AddOffset(30, WeaponLocatorOffset.Value, 0);
		}

		// Token: 0x0600529F RID: 21151 RVA: 0x000FE9F0 File Offset: 0x000FCDF0
		public static void AddExp(FlatBufferBuilder builder, int Exp)
		{
			builder.AddInt(31, Exp, 0);
		}

		// Token: 0x060052A0 RID: 21152 RVA: 0x000FE9FC File Offset: 0x000FCDFC
		public static void AddPrefixEffect(FlatBufferBuilder builder, StringOffset PrefixEffectOffset)
		{
			builder.AddOffset(32, PrefixEffectOffset.Value, 0);
		}

		// Token: 0x060052A1 RID: 21153 RVA: 0x000FEA0E File Offset: 0x000FCE0E
		public static void AddDefaultAttackHitSFXID(FlatBufferBuilder builder, int DefaultAttackHitSFXID)
		{
			builder.AddInt(33, DefaultAttackHitSFXID, 0);
		}

		// Token: 0x060052A2 RID: 21154 RVA: 0x000FEA1A File Offset: 0x000FCE1A
		public static void AddDropID(FlatBufferBuilder builder, int DropID)
		{
			builder.AddInt(34, DropID, 0);
		}

		// Token: 0x060052A3 RID: 21155 RVA: 0x000FEA26 File Offset: 0x000FCE26
		public static void AddDailyDropNum(FlatBufferBuilder builder, int DailyDropNum)
		{
			builder.AddInt(35, DailyDropNum, 0);
		}

		// Token: 0x060052A4 RID: 21156 RVA: 0x000FEA32 File Offset: 0x000FCE32
		public static void AddAwardID(FlatBufferBuilder builder, int AwardID)
		{
			builder.AddInt(36, AwardID, 0);
		}

		// Token: 0x060052A5 RID: 21157 RVA: 0x000FEA3E File Offset: 0x000FCE3E
		public static void AddExistDuration(FlatBufferBuilder builder, Offset<UnionCell> ExistDurationOffset)
		{
			builder.AddOffset(37, ExistDurationOffset.Value, 0);
		}

		// Token: 0x060052A6 RID: 21158 RVA: 0x000FEA50 File Offset: 0x000FCE50
		public static void AddPVPExistDuration(FlatBufferBuilder builder, Offset<UnionCell> PVPExistDurationOffset)
		{
			builder.AddOffset(38, PVPExistDurationOffset.Value, 0);
		}

		// Token: 0x060052A7 RID: 21159 RVA: 0x000FEA62 File Offset: 0x000FCE62
		public static void AddFloatValue(FlatBufferBuilder builder, int FloatValue)
		{
			builder.AddInt(39, FloatValue, 0);
		}

		// Token: 0x060052A8 RID: 21160 RVA: 0x000FEA6E File Offset: 0x000FCE6E
		public static void AddDescriptionA(FlatBufferBuilder builder, StringOffset DescriptionAOffset)
		{
			builder.AddOffset(40, DescriptionAOffset.Value, 0);
		}

		// Token: 0x060052A9 RID: 21161 RVA: 0x000FEA80 File Offset: 0x000FCE80
		public static void AddValueA(FlatBufferBuilder builder, int ValueA)
		{
			builder.AddInt(41, ValueA, 0);
		}

		// Token: 0x060052AA RID: 21162 RVA: 0x000FEA8C File Offset: 0x000FCE8C
		public static void AddWalkSpeech(FlatBufferBuilder builder, VectorOffset WalkSpeechOffset)
		{
			builder.AddOffset(42, WalkSpeechOffset.Value, 0);
		}

		// Token: 0x060052AB RID: 21163 RVA: 0x000FEAA0 File Offset: 0x000FCEA0
		public static VectorOffset CreateWalkSpeechVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052AC RID: 21164 RVA: 0x000FEADD File Offset: 0x000FCEDD
		public static void StartWalkSpeechVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052AD RID: 21165 RVA: 0x000FEAE8 File Offset: 0x000FCEE8
		public static void AddAttackSpeech(FlatBufferBuilder builder, VectorOffset AttackSpeechOffset)
		{
			builder.AddOffset(43, AttackSpeechOffset.Value, 0);
		}

		// Token: 0x060052AE RID: 21166 RVA: 0x000FEAFC File Offset: 0x000FCEFC
		public static VectorOffset CreateAttackSpeechVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052AF RID: 21167 RVA: 0x000FEB39 File Offset: 0x000FCF39
		public static void StartAttackSpeechVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052B0 RID: 21168 RVA: 0x000FEB44 File Offset: 0x000FCF44
		public static void AddBirthSpeech(FlatBufferBuilder builder, VectorOffset BirthSpeechOffset)
		{
			builder.AddOffset(44, BirthSpeechOffset.Value, 0);
		}

		// Token: 0x060052B1 RID: 21169 RVA: 0x000FEB58 File Offset: 0x000FCF58
		public static VectorOffset CreateBirthSpeechVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052B2 RID: 21170 RVA: 0x000FEB95 File Offset: 0x000FCF95
		public static void StartBirthSpeechVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052B3 RID: 21171 RVA: 0x000FEBA0 File Offset: 0x000FCFA0
		public static void AddShowName(FlatBufferBuilder builder, bool ShowName)
		{
			builder.AddBool(45, ShowName, false);
		}

		// Token: 0x060052B4 RID: 21172 RVA: 0x000FEBAC File Offset: 0x000FCFAC
		public static void AddShowHPBar(FlatBufferBuilder builder, bool ShowHPBar)
		{
			builder.AddBool(46, ShowHPBar, false);
		}

		// Token: 0x060052B5 RID: 21173 RVA: 0x000FEBB8 File Offset: 0x000FCFB8
		public static void AddShowFootBar(FlatBufferBuilder builder, int ShowFootBar)
		{
			builder.AddInt(47, ShowFootBar, 0);
		}

		// Token: 0x060052B6 RID: 21174 RVA: 0x000FEBC4 File Offset: 0x000FCFC4
		public static void AddAbilityChange(FlatBufferBuilder builder, VectorOffset AbilityChangeOffset)
		{
			builder.AddOffset(48, AbilityChangeOffset.Value, 0);
		}

		// Token: 0x060052B7 RID: 21175 RVA: 0x000FEBD8 File Offset: 0x000FCFD8
		public static VectorOffset CreateAbilityChangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052B8 RID: 21176 RVA: 0x000FEC15 File Offset: 0x000FD015
		public static void StartAbilityChangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052B9 RID: 21177 RVA: 0x000FEC20 File Offset: 0x000FD020
		public static void AddBornBuff(FlatBufferBuilder builder, VectorOffset BornBuffOffset)
		{
			builder.AddOffset(49, BornBuffOffset.Value, 0);
		}

		// Token: 0x060052BA RID: 21178 RVA: 0x000FEC34 File Offset: 0x000FD034
		public static VectorOffset CreateBornBuffVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052BB RID: 21179 RVA: 0x000FEC71 File Offset: 0x000FD071
		public static void StartBornBuffVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052BC RID: 21180 RVA: 0x000FEC7C File Offset: 0x000FD07C
		public static void AddBornBuff2(FlatBufferBuilder builder, VectorOffset BornBuff2Offset)
		{
			builder.AddOffset(50, BornBuff2Offset.Value, 0);
		}

		// Token: 0x060052BD RID: 21181 RVA: 0x000FEC90 File Offset: 0x000FD090
		public static VectorOffset CreateBornBuff2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052BE RID: 21182 RVA: 0x000FECCD File Offset: 0x000FD0CD
		public static void StartBornBuff2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052BF RID: 21183 RVA: 0x000FECD8 File Offset: 0x000FD0D8
		public static void AddBornMechanism(FlatBufferBuilder builder, VectorOffset BornMechanismOffset)
		{
			builder.AddOffset(51, BornMechanismOffset.Value, 0);
		}

		// Token: 0x060052C0 RID: 21184 RVA: 0x000FECEC File Offset: 0x000FD0EC
		public static VectorOffset CreateBornMechanismVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052C1 RID: 21185 RVA: 0x000FED29 File Offset: 0x000FD129
		public static void StartBornMechanismVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052C2 RID: 21186 RVA: 0x000FED34 File Offset: 0x000FD134
		public static void AddMaxFixHp(FlatBufferBuilder builder, Offset<UnionCell> maxFixHpOffset)
		{
			builder.AddOffset(52, maxFixHpOffset.Value, 0);
		}

		// Token: 0x060052C3 RID: 21187 RVA: 0x000FED46 File Offset: 0x000FD146
		public static void AddMaxHp(FlatBufferBuilder builder, int maxHp)
		{
			builder.AddInt(53, maxHp, 0);
		}

		// Token: 0x060052C4 RID: 21188 RVA: 0x000FED52 File Offset: 0x000FD152
		public static void AddMaxMp(FlatBufferBuilder builder, int maxMp)
		{
			builder.AddInt(54, maxMp, 0);
		}

		// Token: 0x060052C5 RID: 21189 RVA: 0x000FED5E File Offset: 0x000FD15E
		public static void AddHpRecover(FlatBufferBuilder builder, int hpRecover)
		{
			builder.AddInt(55, hpRecover, 0);
		}

		// Token: 0x060052C6 RID: 21190 RVA: 0x000FED6A File Offset: 0x000FD16A
		public static void AddMpRecover(FlatBufferBuilder builder, int mpRecover)
		{
			builder.AddInt(56, mpRecover, 0);
		}

		// Token: 0x060052C7 RID: 21191 RVA: 0x000FED76 File Offset: 0x000FD176
		public static void AddAttack(FlatBufferBuilder builder, int attack)
		{
			builder.AddInt(57, attack, 0);
		}

		// Token: 0x060052C8 RID: 21192 RVA: 0x000FED82 File Offset: 0x000FD182
		public static void AddMagicAttack(FlatBufferBuilder builder, int magicAttack)
		{
			builder.AddInt(58, magicAttack, 0);
		}

		// Token: 0x060052C9 RID: 21193 RVA: 0x000FED8E File Offset: 0x000FD18E
		public static void AddDefence(FlatBufferBuilder builder, int defence)
		{
			builder.AddInt(59, defence, 0);
		}

		// Token: 0x060052CA RID: 21194 RVA: 0x000FED9A File Offset: 0x000FD19A
		public static void AddMagicDefence(FlatBufferBuilder builder, int magicDefence)
		{
			builder.AddInt(60, magicDefence, 0);
		}

		// Token: 0x060052CB RID: 21195 RVA: 0x000FEDA6 File Offset: 0x000FD1A6
		public static void AddAttackSpeed(FlatBufferBuilder builder, int attackSpeed)
		{
			builder.AddInt(61, attackSpeed, 0);
		}

		// Token: 0x060052CC RID: 21196 RVA: 0x000FEDB2 File Offset: 0x000FD1B2
		public static void AddSpellSpeed(FlatBufferBuilder builder, int spellSpeed)
		{
			builder.AddInt(62, spellSpeed, 0);
		}

		// Token: 0x060052CD RID: 21197 RVA: 0x000FEDBE File Offset: 0x000FD1BE
		public static void AddMoveSpeed(FlatBufferBuilder builder, int moveSpeed)
		{
			builder.AddInt(63, moveSpeed, 0);
		}

		// Token: 0x060052CE RID: 21198 RVA: 0x000FEDCA File Offset: 0x000FD1CA
		public static void AddCiriticalAttack(FlatBufferBuilder builder, int ciriticalAttack)
		{
			builder.AddInt(64, ciriticalAttack, 0);
		}

		// Token: 0x060052CF RID: 21199 RVA: 0x000FEDD6 File Offset: 0x000FD1D6
		public static void AddCiriticalMagicAttack(FlatBufferBuilder builder, int ciriticalMagicAttack)
		{
			builder.AddInt(65, ciriticalMagicAttack, 0);
		}

		// Token: 0x060052D0 RID: 21200 RVA: 0x000FEDE2 File Offset: 0x000FD1E2
		public static void AddDex(FlatBufferBuilder builder, int dex)
		{
			builder.AddInt(66, dex, 0);
		}

		// Token: 0x060052D1 RID: 21201 RVA: 0x000FEDEE File Offset: 0x000FD1EE
		public static void AddDodge(FlatBufferBuilder builder, int dodge)
		{
			builder.AddInt(67, dodge, 0);
		}

		// Token: 0x060052D2 RID: 21202 RVA: 0x000FEDFA File Offset: 0x000FD1FA
		public static void AddFrozen(FlatBufferBuilder builder, int frozen)
		{
			builder.AddInt(68, frozen, 0);
		}

		// Token: 0x060052D3 RID: 21203 RVA: 0x000FEE06 File Offset: 0x000FD206
		public static void AddHard(FlatBufferBuilder builder, int hard)
		{
			builder.AddInt(69, hard, 0);
		}

		// Token: 0x060052D4 RID: 21204 RVA: 0x000FEE12 File Offset: 0x000FD212
		public static void AddCdReduceRate(FlatBufferBuilder builder, int cdReduceRate)
		{
			builder.AddInt(70, cdReduceRate, 0);
		}

		// Token: 0x060052D5 RID: 21205 RVA: 0x000FEE1E File Offset: 0x000FD21E
		public static void AddBaseAtk(FlatBufferBuilder builder, int baseAtk)
		{
			builder.AddInt(71, baseAtk, 0);
		}

		// Token: 0x060052D6 RID: 21206 RVA: 0x000FEE2A File Offset: 0x000FD22A
		public static void AddBaseInt(FlatBufferBuilder builder, int baseInt)
		{
			builder.AddInt(72, baseInt, 0);
		}

		// Token: 0x060052D7 RID: 21207 RVA: 0x000FEE36 File Offset: 0x000FD236
		public static void AddSta(FlatBufferBuilder builder, int sta)
		{
			builder.AddInt(73, sta, 0);
		}

		// Token: 0x060052D8 RID: 21208 RVA: 0x000FEE42 File Offset: 0x000FD242
		public static void AddSpr(FlatBufferBuilder builder, int spr)
		{
			builder.AddInt(74, spr, 0);
		}

		// Token: 0x060052D9 RID: 21209 RVA: 0x000FEE4E File Offset: 0x000FD24E
		public static void AddIgnoreDefAttackAdd(FlatBufferBuilder builder, int ignoreDefAttackAdd)
		{
			builder.AddInt(75, ignoreDefAttackAdd, 0);
		}

		// Token: 0x060052DA RID: 21210 RVA: 0x000FEE5A File Offset: 0x000FD25A
		public static void AddIgnoreDefMagicAttackAdd(FlatBufferBuilder builder, int ignoreDefMagicAttackAdd)
		{
			builder.AddInt(76, ignoreDefMagicAttackAdd, 0);
		}

		// Token: 0x060052DB RID: 21211 RVA: 0x000FEE66 File Offset: 0x000FD266
		public static void AddBaseIndependence(FlatBufferBuilder builder, int baseIndependence)
		{
			builder.AddInt(77, baseIndependence, 0);
		}

		// Token: 0x060052DC RID: 21212 RVA: 0x000FEE72 File Offset: 0x000FD272
		public static void AddElements(FlatBufferBuilder builder, VectorOffset ElementsOffset)
		{
			builder.AddOffset(78, ElementsOffset.Value, 0);
		}

		// Token: 0x060052DD RID: 21213 RVA: 0x000FEE84 File Offset: 0x000FD284
		public static VectorOffset CreateElementsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052DE RID: 21214 RVA: 0x000FEEC1 File Offset: 0x000FD2C1
		public static void StartElementsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052DF RID: 21215 RVA: 0x000FEECC File Offset: 0x000FD2CC
		public static void AddLightAttack(FlatBufferBuilder builder, Offset<UnionCell> LightAttackOffset)
		{
			builder.AddOffset(79, LightAttackOffset.Value, 0);
		}

		// Token: 0x060052E0 RID: 21216 RVA: 0x000FEEDE File Offset: 0x000FD2DE
		public static void AddFireAttack(FlatBufferBuilder builder, Offset<UnionCell> FireAttackOffset)
		{
			builder.AddOffset(80, FireAttackOffset.Value, 0);
		}

		// Token: 0x060052E1 RID: 21217 RVA: 0x000FEEF0 File Offset: 0x000FD2F0
		public static void AddIceAttack(FlatBufferBuilder builder, Offset<UnionCell> IceAttackOffset)
		{
			builder.AddOffset(81, IceAttackOffset.Value, 0);
		}

		// Token: 0x060052E2 RID: 21218 RVA: 0x000FEF02 File Offset: 0x000FD302
		public static void AddDarkAttack(FlatBufferBuilder builder, Offset<UnionCell> DarkAttackOffset)
		{
			builder.AddOffset(82, DarkAttackOffset.Value, 0);
		}

		// Token: 0x060052E3 RID: 21219 RVA: 0x000FEF14 File Offset: 0x000FD314
		public static void AddLightDefence(FlatBufferBuilder builder, Offset<UnionCell> LightDefenceOffset)
		{
			builder.AddOffset(83, LightDefenceOffset.Value, 0);
		}

		// Token: 0x060052E4 RID: 21220 RVA: 0x000FEF26 File Offset: 0x000FD326
		public static void AddFireDefence(FlatBufferBuilder builder, Offset<UnionCell> FireDefenceOffset)
		{
			builder.AddOffset(84, FireDefenceOffset.Value, 0);
		}

		// Token: 0x060052E5 RID: 21221 RVA: 0x000FEF38 File Offset: 0x000FD338
		public static void AddIceDefence(FlatBufferBuilder builder, Offset<UnionCell> IceDefenceOffset)
		{
			builder.AddOffset(85, IceDefenceOffset.Value, 0);
		}

		// Token: 0x060052E6 RID: 21222 RVA: 0x000FEF4A File Offset: 0x000FD34A
		public static void AddDarkDefence(FlatBufferBuilder builder, Offset<UnionCell> DarkDefenceOffset)
		{
			builder.AddOffset(86, DarkDefenceOffset.Value, 0);
		}

		// Token: 0x060052E7 RID: 21223 RVA: 0x000FEF5C File Offset: 0x000FD35C
		public static void AddAbnormalResist1(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist1Offset)
		{
			builder.AddOffset(87, abnormalResist1Offset.Value, 0);
		}

		// Token: 0x060052E8 RID: 21224 RVA: 0x000FEF6E File Offset: 0x000FD36E
		public static void AddAbnormalResist2(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist2Offset)
		{
			builder.AddOffset(88, abnormalResist2Offset.Value, 0);
		}

		// Token: 0x060052E9 RID: 21225 RVA: 0x000FEF80 File Offset: 0x000FD380
		public static void AddAbnormalResist3(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist3Offset)
		{
			builder.AddOffset(89, abnormalResist3Offset.Value, 0);
		}

		// Token: 0x060052EA RID: 21226 RVA: 0x000FEF92 File Offset: 0x000FD392
		public static void AddAbnormalResist4(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist4Offset)
		{
			builder.AddOffset(90, abnormalResist4Offset.Value, 0);
		}

		// Token: 0x060052EB RID: 21227 RVA: 0x000FEFA4 File Offset: 0x000FD3A4
		public static void AddAbnormalResist5(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist5Offset)
		{
			builder.AddOffset(91, abnormalResist5Offset.Value, 0);
		}

		// Token: 0x060052EC RID: 21228 RVA: 0x000FEFB6 File Offset: 0x000FD3B6
		public static void AddAbnormalResist6(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist6Offset)
		{
			builder.AddOffset(92, abnormalResist6Offset.Value, 0);
		}

		// Token: 0x060052ED RID: 21229 RVA: 0x000FEFC8 File Offset: 0x000FD3C8
		public static void AddAbnormalResist7(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist7Offset)
		{
			builder.AddOffset(93, abnormalResist7Offset.Value, 0);
		}

		// Token: 0x060052EE RID: 21230 RVA: 0x000FEFDA File Offset: 0x000FD3DA
		public static void AddAbnormalResist8(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist8Offset)
		{
			builder.AddOffset(94, abnormalResist8Offset.Value, 0);
		}

		// Token: 0x060052EF RID: 21231 RVA: 0x000FEFEC File Offset: 0x000FD3EC
		public static void AddAbnormalResist9(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist9Offset)
		{
			builder.AddOffset(95, abnormalResist9Offset.Value, 0);
		}

		// Token: 0x060052F0 RID: 21232 RVA: 0x000FEFFE File Offset: 0x000FD3FE
		public static void AddAbnormalResist10(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist10Offset)
		{
			builder.AddOffset(96, abnormalResist10Offset.Value, 0);
		}

		// Token: 0x060052F1 RID: 21233 RVA: 0x000FF010 File Offset: 0x000FD410
		public static void AddAbnormalResist11(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist11Offset)
		{
			builder.AddOffset(97, abnormalResist11Offset.Value, 0);
		}

		// Token: 0x060052F2 RID: 21234 RVA: 0x000FF022 File Offset: 0x000FD422
		public static void AddAbnormalResist12(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist12Offset)
		{
			builder.AddOffset(98, abnormalResist12Offset.Value, 0);
		}

		// Token: 0x060052F3 RID: 21235 RVA: 0x000FF034 File Offset: 0x000FD434
		public static void AddAbnormalResist13(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist13Offset)
		{
			builder.AddOffset(99, abnormalResist13Offset.Value, 0);
		}

		// Token: 0x060052F4 RID: 21236 RVA: 0x000FF046 File Offset: 0x000FD446
		public static void AddUseProtect(FlatBufferBuilder builder, int UseProtect)
		{
			builder.AddInt(100, UseProtect, 0);
		}

		// Token: 0x060052F5 RID: 21237 RVA: 0x000FF052 File Offset: 0x000FD452
		public static void AddProtectFloatPercent(FlatBufferBuilder builder, int ProtectFloatPercent)
		{
			builder.AddInt(101, ProtectFloatPercent, 0);
		}

		// Token: 0x060052F6 RID: 21238 RVA: 0x000FF05E File Offset: 0x000FD45E
		public static void AddProtectFloatPercent2(FlatBufferBuilder builder, int ProtectFloatPercent2)
		{
			builder.AddInt(102, ProtectFloatPercent2, 0);
		}

		// Token: 0x060052F7 RID: 21239 RVA: 0x000FF06A File Offset: 0x000FD46A
		public static void AddProtectGroundPercent(FlatBufferBuilder builder, int ProtectGroundPercent)
		{
			builder.AddInt(103, ProtectGroundPercent, 0);
		}

		// Token: 0x060052F8 RID: 21240 RVA: 0x000FF076 File Offset: 0x000FD476
		public static void AddProtectStandPercent(FlatBufferBuilder builder, int ProtectStandPercent)
		{
			builder.AddInt(104, ProtectStandPercent, 0);
		}

		// Token: 0x060052F9 RID: 21241 RVA: 0x000FF082 File Offset: 0x000FD482
		public static void AddBornAI(FlatBufferBuilder builder, UnitTable.eBornAI BornAI)
		{
			builder.AddInt(105, (int)BornAI, 0);
		}

		// Token: 0x060052FA RID: 21242 RVA: 0x000FF08E File Offset: 0x000FD48E
		public static void AddAICombatType(FlatBufferBuilder builder, int AICombatType)
		{
			builder.AddInt(106, AICombatType, 0);
		}

		// Token: 0x060052FB RID: 21243 RVA: 0x000FF09A File Offset: 0x000FD49A
		public static void AddAITargetType(FlatBufferBuilder builder, VectorOffset AITargetTypeOffset)
		{
			builder.AddOffset(107, AITargetTypeOffset.Value, 0);
		}

		// Token: 0x060052FC RID: 21244 RVA: 0x000FF0AC File Offset: 0x000FD4AC
		public static VectorOffset CreateAITargetTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060052FD RID: 21245 RVA: 0x000FF0E9 File Offset: 0x000FD4E9
		public static void StartAITargetTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060052FE RID: 21246 RVA: 0x000FF0F4 File Offset: 0x000FD4F4
		public static void AddAISight(FlatBufferBuilder builder, int AISight)
		{
			builder.AddInt(108, AISight, 0);
		}

		// Token: 0x060052FF RID: 21247 RVA: 0x000FF100 File Offset: 0x000FD500
		public static void AddAIChase(FlatBufferBuilder builder, int AIChase)
		{
			builder.AddInt(109, AIChase, 0);
		}

		// Token: 0x06005300 RID: 21248 RVA: 0x000FF10C File Offset: 0x000FD50C
		public static void AddAIWarlike(FlatBufferBuilder builder, int AIWarlike)
		{
			builder.AddInt(110, AIWarlike, 0);
		}

		// Token: 0x06005301 RID: 21249 RVA: 0x000FF118 File Offset: 0x000FD518
		public static void AddAIFollowDistance(FlatBufferBuilder builder, int AIFollowDistance)
		{
			builder.AddInt(111, AIFollowDistance, 0);
		}

		// Token: 0x06005302 RID: 21250 RVA: 0x000FF124 File Offset: 0x000FD524
		public static void AddAIKeepDistance(FlatBufferBuilder builder, int AIKeepDistance)
		{
			builder.AddInt(112, AIKeepDistance, 0);
		}

		// Token: 0x06005303 RID: 21251 RVA: 0x000FF130 File Offset: 0x000FD530
		public static void AddAIAttackDelay(FlatBufferBuilder builder, int AIAttackDelay)
		{
			builder.AddInt(113, AIAttackDelay, 0);
		}

		// Token: 0x06005304 RID: 21252 RVA: 0x000FF13C File Offset: 0x000FD53C
		public static void AddAIDestinationChangeTerm(FlatBufferBuilder builder, int AIDestinationChangeTerm)
		{
			builder.AddInt(114, AIDestinationChangeTerm, 0);
		}

		// Token: 0x06005305 RID: 21253 RVA: 0x000FF148 File Offset: 0x000FD548
		public static void AddAIThinkTargetTerm(FlatBufferBuilder builder, int AIThinkTargetTerm)
		{
			builder.AddInt(115, AIThinkTargetTerm, 0);
		}

		// Token: 0x06005306 RID: 21254 RVA: 0x000FF154 File Offset: 0x000FD554
		public static void AddAIAttackKind(FlatBufferBuilder builder, VectorOffset AIAttackKindOffset)
		{
			builder.AddOffset(116, AIAttackKindOffset.Value, 0);
		}

		// Token: 0x06005307 RID: 21255 RVA: 0x000FF168 File Offset: 0x000FD568
		public static VectorOffset CreateAIAttackKindVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06005308 RID: 21256 RVA: 0x000FF1AE File Offset: 0x000FD5AE
		public static void StartAIAttackKindVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005309 RID: 21257 RVA: 0x000FF1B9 File Offset: 0x000FD5B9
		public static void AddDazeTime(FlatBufferBuilder builder, VectorOffset DazeTimeOffset)
		{
			builder.AddOffset(117, DazeTimeOffset.Value, 0);
		}

		// Token: 0x0600530A RID: 21258 RVA: 0x000FF1CC File Offset: 0x000FD5CC
		public static VectorOffset CreateDazeTimeVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600530B RID: 21259 RVA: 0x000FF212 File Offset: 0x000FD612
		public static void StartDazeTimeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600530C RID: 21260 RVA: 0x000FF21D File Offset: 0x000FD61D
		public static void AddAIIdleMode(FlatBufferBuilder builder, int AIIdleMode)
		{
			builder.AddInt(118, AIIdleMode, 0);
		}

		// Token: 0x0600530D RID: 21261 RVA: 0x000FF229 File Offset: 0x000FD629
		public static void AddAIIsAPC(FlatBufferBuilder builder, int AIIsAPC)
		{
			builder.AddInt(119, AIIsAPC, 0);
		}

		// Token: 0x0600530E RID: 21262 RVA: 0x000FF235 File Offset: 0x000FD635
		public static void AddAIIdleRand(FlatBufferBuilder builder, int AIIdleRand)
		{
			builder.AddInt(120, AIIdleRand, 0);
		}

		// Token: 0x0600530F RID: 21263 RVA: 0x000FF241 File Offset: 0x000FD641
		public static void AddAIIdleDuration(FlatBufferBuilder builder, int AIIdleDuration)
		{
			builder.AddInt(121, AIIdleDuration, 0);
		}

		// Token: 0x06005310 RID: 21264 RVA: 0x000FF24D File Offset: 0x000FD64D
		public static void AddAIEscapeRand(FlatBufferBuilder builder, int AIEscapeRand)
		{
			builder.AddInt(122, AIEscapeRand, 0);
		}

		// Token: 0x06005311 RID: 21265 RVA: 0x000FF259 File Offset: 0x000FD659
		public static void AddAIWanderRand(FlatBufferBuilder builder, int AIWanderRand)
		{
			builder.AddInt(123, AIWanderRand, 0);
		}

		// Token: 0x06005312 RID: 21266 RVA: 0x000FF265 File Offset: 0x000FD665
		public static void AddAIWanderRange(FlatBufferBuilder builder, int AIWanderRange)
		{
			builder.AddInt(124, AIWanderRange, 0);
		}

		// Token: 0x06005313 RID: 21267 RVA: 0x000FF271 File Offset: 0x000FD671
		public static void AddAIWalkBackRange(FlatBufferBuilder builder, int AIWalkBackRange)
		{
			builder.AddInt(125, AIWalkBackRange, 0);
		}

		// Token: 0x06005314 RID: 21268 RVA: 0x000FF27D File Offset: 0x000FD67D
		public static void AddAIYFirstRand(FlatBufferBuilder builder, int AIYFirstRand)
		{
			builder.AddInt(126, AIYFirstRand, 0);
		}

		// Token: 0x06005315 RID: 21269 RVA: 0x000FF289 File Offset: 0x000FD689
		public static void AddAIMaxWalkCmdCount(FlatBufferBuilder builder, int AIMaxWalkCmdCount)
		{
			builder.AddInt(127, AIMaxWalkCmdCount, 0);
		}

		// Token: 0x06005316 RID: 21270 RVA: 0x000FF295 File Offset: 0x000FD695
		public static void AddAIMaxIdleCmdCount(FlatBufferBuilder builder, int AIMaxIdleCmdCount)
		{
			builder.AddInt(128, AIMaxIdleCmdCount, 0);
		}

		// Token: 0x06005317 RID: 21271 RVA: 0x000FF2A4 File Offset: 0x000FD6A4
		public static void AddAIWeaponTag(FlatBufferBuilder builder, int AIWeaponTag)
		{
			builder.AddInt(129, AIWeaponTag, 0);
		}

		// Token: 0x06005318 RID: 21272 RVA: 0x000FF2B3 File Offset: 0x000FD6B3
		public static void AddAPCIsSpecialConfig(FlatBufferBuilder builder, int APCIsSpecialConfig)
		{
			builder.AddInt(130, APCIsSpecialConfig, 0);
		}

		// Token: 0x06005319 RID: 21273 RVA: 0x000FF2C2 File Offset: 0x000FD6C2
		public static void AddAPCWeaponRes(FlatBufferBuilder builder, int APCWeaponRes)
		{
			builder.AddInt(131, APCWeaponRes, 0);
		}

		// Token: 0x0600531A RID: 21274 RVA: 0x000FF2D1 File Offset: 0x000FD6D1
		public static void AddAPCWeaponStrengthLevel(FlatBufferBuilder builder, int APCWeaponStrengthLevel)
		{
			builder.AddInt(132, APCWeaponStrengthLevel, 0);
		}

		// Token: 0x0600531B RID: 21275 RVA: 0x000FF2E0 File Offset: 0x000FD6E0
		public static void AddAIActionPath(FlatBufferBuilder builder, StringOffset AIActionPathOffset)
		{
			builder.AddOffset(133, AIActionPathOffset.Value, 0);
		}

		// Token: 0x0600531C RID: 21276 RVA: 0x000FF2F5 File Offset: 0x000FD6F5
		public static void AddAIDestinationSelectPath(FlatBufferBuilder builder, StringOffset AIDestinationSelectPathOffset)
		{
			builder.AddOffset(134, AIDestinationSelectPathOffset.Value, 0);
		}

		// Token: 0x0600531D RID: 21277 RVA: 0x000FF30A File Offset: 0x000FD70A
		public static void AddAIEventPath(FlatBufferBuilder builder, StringOffset AIEventPathOffset)
		{
			builder.AddOffset(135, AIEventPathOffset.Value, 0);
		}

		// Token: 0x0600531E RID: 21278 RVA: 0x000FF31F File Offset: 0x000FD71F
		public static void AddAttackInModelStage(FlatBufferBuilder builder, VectorOffset AttackInModelStageOffset)
		{
			builder.AddOffset(136, AttackInModelStageOffset.Value, 0);
		}

		// Token: 0x0600531F RID: 21279 RVA: 0x000FF334 File Offset: 0x000FD734
		public static VectorOffset CreateAttackInModelStageVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06005320 RID: 21280 RVA: 0x000FF37A File Offset: 0x000FD77A
		public static void StartAttackInModelStageVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005321 RID: 21281 RVA: 0x000FF385 File Offset: 0x000FD785
		public static void AddPlayDeadAction(FlatBufferBuilder builder, bool playDeadAction)
		{
			builder.AddBool(137, playDeadAction, false);
		}

		// Token: 0x06005322 RID: 21282 RVA: 0x000FF394 File Offset: 0x000FD794
		public static void AddHeight(FlatBufferBuilder builder, int Height)
		{
			builder.AddInt(138, Height, 0);
		}

		// Token: 0x06005323 RID: 21283 RVA: 0x000FF3A4 File Offset: 0x000FD7A4
		public static Offset<UnitTable> EndUnitTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<UnitTable>(value);
		}

		// Token: 0x06005324 RID: 21284 RVA: 0x000FF3BE File Offset: 0x000FD7BE
		public static void FinishUnitTableBuffer(FlatBufferBuilder builder, Offset<UnitTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E1B RID: 7707
		private Table __p = new Table();

		// Token: 0x04001E1C RID: 7708
		private FlatBufferArray<int> SkillIDsValue;

		// Token: 0x04001E1D RID: 7709
		private FlatBufferArray<int> WalkSpeechValue;

		// Token: 0x04001E1E RID: 7710
		private FlatBufferArray<int> AttackSpeechValue;

		// Token: 0x04001E1F RID: 7711
		private FlatBufferArray<int> BirthSpeechValue;

		// Token: 0x04001E20 RID: 7712
		private FlatBufferArray<int> AbilityChangeValue;

		// Token: 0x04001E21 RID: 7713
		private FlatBufferArray<int> BornBuffValue;

		// Token: 0x04001E22 RID: 7714
		private FlatBufferArray<int> BornBuff2Value;

		// Token: 0x04001E23 RID: 7715
		private FlatBufferArray<int> BornMechanismValue;

		// Token: 0x04001E24 RID: 7716
		private FlatBufferArray<int> ElementsValue;

		// Token: 0x04001E25 RID: 7717
		private FlatBufferArray<int> AITargetTypeValue;

		// Token: 0x04001E26 RID: 7718
		private FlatBufferArray<string> AIAttackKindValue;

		// Token: 0x04001E27 RID: 7719
		private FlatBufferArray<UnionCell> DazeTimeValue;

		// Token: 0x04001E28 RID: 7720
		private FlatBufferArray<string> AttackInModelStageValue;

		// Token: 0x0200060D RID: 1549
		public enum eType
		{
			// Token: 0x04001E2A RID: 7722
			HERO,
			// Token: 0x04001E2B RID: 7723
			MONSTER,
			// Token: 0x04001E2C RID: 7724
			ELITE,
			// Token: 0x04001E2D RID: 7725
			BOSS,
			// Token: 0x04001E2E RID: 7726
			NPC,
			// Token: 0x04001E2F RID: 7727
			HELL,
			// Token: 0x04001E30 RID: 7728
			ACTIVITYMONSTER,
			// Token: 0x04001E31 RID: 7729
			ACCOMPANY,
			// Token: 0x04001E32 RID: 7730
			SKILL_MONSTER,
			// Token: 0x04001E33 RID: 7731
			EGG,
			// Token: 0x04001E34 RID: 7732
			ZHS
		}

		// Token: 0x0200060E RID: 1550
		public enum eCamp
		{
			// Token: 0x04001E36 RID: 7734
			C_HERO,
			// Token: 0x04001E37 RID: 7735
			C_ENEMY,
			// Token: 0x04001E38 RID: 7736
			C_ENEMY2
		}

		// Token: 0x0200060F RID: 1551
		public enum eMonsterRace
		{
			// Token: 0x04001E3A RID: 7738
			NONE,
			// Token: 0x04001E3B RID: 7739
			EVIL,
			// Token: 0x04001E3C RID: 7740
			UNDEAD,
			// Token: 0x04001E3D RID: 7741
			ELF,
			// Token: 0x04001E3E RID: 7742
			HUMAN,
			// Token: 0x04001E3F RID: 7743
			HOMINIS,
			// Token: 0x04001E40 RID: 7744
			PUPPET,
			// Token: 0x04001E41 RID: 7745
			MACHINE
		}

		// Token: 0x02000610 RID: 1552
		public enum eBornAI
		{
			// Token: 0x04001E43 RID: 7747
			Start,
			// Token: 0x04001E44 RID: 7748
			None
		}

		// Token: 0x02000611 RID: 1553
		public enum eCrypt
		{
			// Token: 0x04001E46 RID: 7750
			code = 188128128
		}
	}
}
