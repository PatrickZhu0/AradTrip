using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000612 RID: 1554
	public class UnitTable_Level : IFlatbufferObject
	{
		// Token: 0x1700172C RID: 5932
		// (get) Token: 0x06005326 RID: 21286 RVA: 0x000FF3E0 File Offset: 0x000FD7E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005327 RID: 21287 RVA: 0x000FF3ED File Offset: 0x000FD7ED
		public static UnitTable_Level GetRootAsUnitTable_Level(ByteBuffer _bb)
		{
			return UnitTable_Level.GetRootAsUnitTable_Level(_bb, new UnitTable_Level());
		}

		// Token: 0x06005328 RID: 21288 RVA: 0x000FF3FA File Offset: 0x000FD7FA
		public static UnitTable_Level GetRootAsUnitTable_Level(ByteBuffer _bb, UnitTable_Level obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005329 RID: 21289 RVA: 0x000FF416 File Offset: 0x000FD816
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600532A RID: 21290 RVA: 0x000FF430 File Offset: 0x000FD830
		public UnitTable_Level __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700172D RID: 5933
		// (get) Token: 0x0600532B RID: 21291 RVA: 0x000FF43C File Offset: 0x000FD83C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700172E RID: 5934
		// (get) Token: 0x0600532C RID: 21292 RVA: 0x000FF488 File Offset: 0x000FD888
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600532D RID: 21293 RVA: 0x000FF4CA File Offset: 0x000FD8CA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700172F RID: 5935
		// (get) Token: 0x0600532E RID: 21294 RVA: 0x000FF4D8 File Offset: 0x000FD8D8
		public string BossShowActionName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600532F RID: 21295 RVA: 0x000FF51A File Offset: 0x000FD91A
		public ArraySegment<byte>? GetBossShowActionNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001730 RID: 5936
		// (get) Token: 0x06005330 RID: 21296 RVA: 0x000FF528 File Offset: 0x000FD928
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005331 RID: 21297 RVA: 0x000FF56B File Offset: 0x000FD96B
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001731 RID: 5937
		// (get) Token: 0x06005332 RID: 21298 RVA: 0x000FF57C File Offset: 0x000FD97C
		public int MonsterMode
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001732 RID: 5938
		// (get) Token: 0x06005333 RID: 21299 RVA: 0x000FF5C8 File Offset: 0x000FD9C8
		public UnitTable_Level.eType Type
		{
			get
			{
				int num = this.__p.__offset(14);
				return (UnitTable_Level.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001733 RID: 5939
		// (get) Token: 0x06005334 RID: 21300 RVA: 0x000FF60C File Offset: 0x000FDA0C
		public int IsShowPortrait
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001734 RID: 5940
		// (get) Token: 0x06005335 RID: 21301 RVA: 0x000FF658 File Offset: 0x000FDA58
		public UnitTable_Level.eCamp Camp
		{
			get
			{
				int num = this.__p.__offset(18);
				return (UnitTable_Level.eCamp)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001735 RID: 5941
		// (get) Token: 0x06005336 RID: 21302 RVA: 0x000FF69C File Offset: 0x000FDA9C
		public UnitTable_Level.eMonsterRace MonsterRace
		{
			get
			{
				int num = this.__p.__offset(20);
				return (UnitTable_Level.eMonsterRace)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001736 RID: 5942
		// (get) Token: 0x06005337 RID: 21303 RVA: 0x000FF6E0 File Offset: 0x000FDAE0
		public int Mode
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001737 RID: 5943
		// (get) Token: 0x06005338 RID: 21304 RVA: 0x000FF72C File Offset: 0x000FDB2C
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001738 RID: 5944
		// (get) Token: 0x06005339 RID: 21305 RVA: 0x000FF778 File Offset: 0x000FDB78
		public int AutoFightNeedAttackFirst
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001739 RID: 5945
		// (get) Token: 0x0600533A RID: 21306 RVA: 0x000FF7C4 File Offset: 0x000FDBC4
		public int SkillMonsterCanBeAttack
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700173A RID: 5946
		// (get) Token: 0x0600533B RID: 21307 RVA: 0x000FF810 File Offset: 0x000FDC10
		public UnionCell Scale
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700173B RID: 5947
		// (get) Token: 0x0600533C RID: 21308 RVA: 0x000FF868 File Offset: 0x000FDC68
		public int enhanceRadius
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700173C RID: 5948
		// (get) Token: 0x0600533D RID: 21309 RVA: 0x000FF8B4 File Offset: 0x000FDCB4
		public int overHeadHeight
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700173D RID: 5949
		// (get) Token: 0x0600533E RID: 21310 RVA: 0x000FF900 File Offset: 0x000FDD00
		public int buffOriginHeight
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700173E RID: 5950
		// (get) Token: 0x0600533F RID: 21311 RVA: 0x000FF94C File Offset: 0x000FDD4C
		public int WalkSpeed
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700173F RID: 5951
		// (get) Token: 0x06005340 RID: 21312 RVA: 0x000FF998 File Offset: 0x000FDD98
		public int WalkAnimationSpeedPerent
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001740 RID: 5952
		// (get) Token: 0x06005341 RID: 21313 RVA: 0x000FF9E4 File Offset: 0x000FDDE4
		public int MonsterTitle
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001741 RID: 5953
		// (get) Token: 0x06005342 RID: 21314 RVA: 0x000FFA30 File Offset: 0x000FDE30
		public int AttackSkillID
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001742 RID: 5954
		// (get) Token: 0x06005343 RID: 21315 RVA: 0x000FFA7C File Offset: 0x000FDE7C
		public int GetupBati
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001743 RID: 5955
		// (get) Token: 0x06005344 RID: 21316 RVA: 0x000FFAC8 File Offset: 0x000FDEC8
		public int GetupSkillRand
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001744 RID: 5956
		// (get) Token: 0x06005345 RID: 21317 RVA: 0x000FFB14 File Offset: 0x000FDF14
		public int GetupSkillID
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001745 RID: 5957
		// (get) Token: 0x06005346 RID: 21318 RVA: 0x000FFB60 File Offset: 0x000FDF60
		public int HitSkillRand
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001746 RID: 5958
		// (get) Token: 0x06005347 RID: 21319 RVA: 0x000FFBAC File Offset: 0x000FDFAC
		public int HitSkillID
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005348 RID: 21320 RVA: 0x000FFBF8 File Offset: 0x000FDFF8
		public int SkillIDsArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001747 RID: 5959
		// (get) Token: 0x06005349 RID: 21321 RVA: 0x000FFC48 File Offset: 0x000FE048
		public int SkillIDsLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600534A RID: 21322 RVA: 0x000FFC7B File Offset: 0x000FE07B
		public ArraySegment<byte>? GetSkillIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x17001748 RID: 5960
		// (get) Token: 0x0600534B RID: 21323 RVA: 0x000FFC8A File Offset: 0x000FE08A
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

		// Token: 0x17001749 RID: 5961
		// (get) Token: 0x0600534C RID: 21324 RVA: 0x000FFCBC File Offset: 0x000FE0BC
		public string Hurt
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600534D RID: 21325 RVA: 0x000FFCFF File Offset: 0x000FE0FF
		public ArraySegment<byte>? GetHurtBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x1700174A RID: 5962
		// (get) Token: 0x0600534E RID: 21326 RVA: 0x000FFD10 File Offset: 0x000FE110
		public string FootEffectName
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600534F RID: 21327 RVA: 0x000FFD53 File Offset: 0x000FE153
		public ArraySegment<byte>? GetFootEffectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x1700174B RID: 5963
		// (get) Token: 0x06005350 RID: 21328 RVA: 0x000FFD64 File Offset: 0x000FE164
		public string WeaponModel
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005351 RID: 21329 RVA: 0x000FFDA7 File Offset: 0x000FE1A7
		public ArraySegment<byte>? GetWeaponModelBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x1700174C RID: 5964
		// (get) Token: 0x06005352 RID: 21330 RVA: 0x000FFDB8 File Offset: 0x000FE1B8
		public string WeaponLocator
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005353 RID: 21331 RVA: 0x000FFDFB File Offset: 0x000FE1FB
		public ArraySegment<byte>? GetWeaponLocatorBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x1700174D RID: 5965
		// (get) Token: 0x06005354 RID: 21332 RVA: 0x000FFE0C File Offset: 0x000FE20C
		public int Exp
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700174E RID: 5966
		// (get) Token: 0x06005355 RID: 21333 RVA: 0x000FFE58 File Offset: 0x000FE258
		public string PrefixEffect
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005356 RID: 21334 RVA: 0x000FFE9B File Offset: 0x000FE29B
		public ArraySegment<byte>? GetPrefixEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x1700174F RID: 5967
		// (get) Token: 0x06005357 RID: 21335 RVA: 0x000FFEAC File Offset: 0x000FE2AC
		public int DefaultAttackHitSFXID
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001750 RID: 5968
		// (get) Token: 0x06005358 RID: 21336 RVA: 0x000FFEF8 File Offset: 0x000FE2F8
		public int DropID
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001751 RID: 5969
		// (get) Token: 0x06005359 RID: 21337 RVA: 0x000FFF44 File Offset: 0x000FE344
		public int AwardID
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001752 RID: 5970
		// (get) Token: 0x0600535A RID: 21338 RVA: 0x000FFF90 File Offset: 0x000FE390
		public UnionCell ExistDuration
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001753 RID: 5971
		// (get) Token: 0x0600535B RID: 21339 RVA: 0x000FFFE8 File Offset: 0x000FE3E8
		public UnionCell PVPExistDuration
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001754 RID: 5972
		// (get) Token: 0x0600535C RID: 21340 RVA: 0x00100040 File Offset: 0x000FE440
		public int FloatValue
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001755 RID: 5973
		// (get) Token: 0x0600535D RID: 21341 RVA: 0x0010008C File Offset: 0x000FE48C
		public string DescriptionA
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600535E RID: 21342 RVA: 0x001000CF File Offset: 0x000FE4CF
		public ArraySegment<byte>? GetDescriptionABytes()
		{
			return this.__p.__vector_as_arraysegment(82);
		}

		// Token: 0x17001756 RID: 5974
		// (get) Token: 0x0600535F RID: 21343 RVA: 0x001000E0 File Offset: 0x000FE4E0
		public int ValueA
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005360 RID: 21344 RVA: 0x0010012C File Offset: 0x000FE52C
		public int WalkSpeechArray(int j)
		{
			int num = this.__p.__offset(86);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001757 RID: 5975
		// (get) Token: 0x06005361 RID: 21345 RVA: 0x0010017C File Offset: 0x000FE57C
		public int WalkSpeechLength
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005362 RID: 21346 RVA: 0x001001AF File Offset: 0x000FE5AF
		public ArraySegment<byte>? GetWalkSpeechBytes()
		{
			return this.__p.__vector_as_arraysegment(86);
		}

		// Token: 0x17001758 RID: 5976
		// (get) Token: 0x06005363 RID: 21347 RVA: 0x001001BE File Offset: 0x000FE5BE
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

		// Token: 0x06005364 RID: 21348 RVA: 0x001001F0 File Offset: 0x000FE5F0
		public int AttackSpeechArray(int j)
		{
			int num = this.__p.__offset(88);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001759 RID: 5977
		// (get) Token: 0x06005365 RID: 21349 RVA: 0x00100240 File Offset: 0x000FE640
		public int AttackSpeechLength
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005366 RID: 21350 RVA: 0x00100273 File Offset: 0x000FE673
		public ArraySegment<byte>? GetAttackSpeechBytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x1700175A RID: 5978
		// (get) Token: 0x06005367 RID: 21351 RVA: 0x00100282 File Offset: 0x000FE682
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

		// Token: 0x06005368 RID: 21352 RVA: 0x001002B4 File Offset: 0x000FE6B4
		public int BirthSpeechArray(int j)
		{
			int num = this.__p.__offset(90);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700175B RID: 5979
		// (get) Token: 0x06005369 RID: 21353 RVA: 0x00100304 File Offset: 0x000FE704
		public int BirthSpeechLength
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600536A RID: 21354 RVA: 0x00100337 File Offset: 0x000FE737
		public ArraySegment<byte>? GetBirthSpeechBytes()
		{
			return this.__p.__vector_as_arraysegment(90);
		}

		// Token: 0x1700175C RID: 5980
		// (get) Token: 0x0600536B RID: 21355 RVA: 0x00100346 File Offset: 0x000FE746
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

		// Token: 0x1700175D RID: 5981
		// (get) Token: 0x0600536C RID: 21356 RVA: 0x00100378 File Offset: 0x000FE778
		public bool ShowName
		{
			get
			{
				int num = this.__p.__offset(92);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700175E RID: 5982
		// (get) Token: 0x0600536D RID: 21357 RVA: 0x001003C4 File Offset: 0x000FE7C4
		public bool ShowHPBar
		{
			get
			{
				int num = this.__p.__offset(94);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700175F RID: 5983
		// (get) Token: 0x0600536E RID: 21358 RVA: 0x00100410 File Offset: 0x000FE810
		public bool ShowFootBar
		{
			get
			{
				int num = this.__p.__offset(96);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600536F RID: 21359 RVA: 0x0010045C File Offset: 0x000FE85C
		public int AbilityChangeArray(int j)
		{
			int num = this.__p.__offset(98);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001760 RID: 5984
		// (get) Token: 0x06005370 RID: 21360 RVA: 0x001004AC File Offset: 0x000FE8AC
		public int AbilityChangeLength
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005371 RID: 21361 RVA: 0x001004DF File Offset: 0x000FE8DF
		public ArraySegment<byte>? GetAbilityChangeBytes()
		{
			return this.__p.__vector_as_arraysegment(98);
		}

		// Token: 0x17001761 RID: 5985
		// (get) Token: 0x06005372 RID: 21362 RVA: 0x001004EE File Offset: 0x000FE8EE
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

		// Token: 0x06005373 RID: 21363 RVA: 0x00100520 File Offset: 0x000FE920
		public int BornBuffArray(int j)
		{
			int num = this.__p.__offset(100);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001762 RID: 5986
		// (get) Token: 0x06005374 RID: 21364 RVA: 0x00100570 File Offset: 0x000FE970
		public int BornBuffLength
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005375 RID: 21365 RVA: 0x001005A3 File Offset: 0x000FE9A3
		public ArraySegment<byte>? GetBornBuffBytes()
		{
			return this.__p.__vector_as_arraysegment(100);
		}

		// Token: 0x17001763 RID: 5987
		// (get) Token: 0x06005376 RID: 21366 RVA: 0x001005B2 File Offset: 0x000FE9B2
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

		// Token: 0x06005377 RID: 21367 RVA: 0x001005E4 File Offset: 0x000FE9E4
		public int BornBuff2Array(int j)
		{
			int num = this.__p.__offset(102);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001764 RID: 5988
		// (get) Token: 0x06005378 RID: 21368 RVA: 0x00100634 File Offset: 0x000FEA34
		public int BornBuff2Length
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005379 RID: 21369 RVA: 0x00100667 File Offset: 0x000FEA67
		public ArraySegment<byte>? GetBornBuff2Bytes()
		{
			return this.__p.__vector_as_arraysegment(102);
		}

		// Token: 0x17001765 RID: 5989
		// (get) Token: 0x0600537A RID: 21370 RVA: 0x00100676 File Offset: 0x000FEA76
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

		// Token: 0x0600537B RID: 21371 RVA: 0x001006A8 File Offset: 0x000FEAA8
		public int BornMechanismArray(int j)
		{
			int num = this.__p.__offset(104);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001766 RID: 5990
		// (get) Token: 0x0600537C RID: 21372 RVA: 0x001006F8 File Offset: 0x000FEAF8
		public int BornMechanismLength
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600537D RID: 21373 RVA: 0x0010072B File Offset: 0x000FEB2B
		public ArraySegment<byte>? GetBornMechanismBytes()
		{
			return this.__p.__vector_as_arraysegment(104);
		}

		// Token: 0x17001767 RID: 5991
		// (get) Token: 0x0600537E RID: 21374 RVA: 0x0010073A File Offset: 0x000FEB3A
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

		// Token: 0x17001768 RID: 5992
		// (get) Token: 0x0600537F RID: 21375 RVA: 0x0010076C File Offset: 0x000FEB6C
		public UnionCell maxFixHp
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001769 RID: 5993
		// (get) Token: 0x06005380 RID: 21376 RVA: 0x001007C4 File Offset: 0x000FEBC4
		public int maxHp
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700176A RID: 5994
		// (get) Token: 0x06005381 RID: 21377 RVA: 0x00100810 File Offset: 0x000FEC10
		public int maxMp
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700176B RID: 5995
		// (get) Token: 0x06005382 RID: 21378 RVA: 0x0010085C File Offset: 0x000FEC5C
		public int hpRecover
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700176C RID: 5996
		// (get) Token: 0x06005383 RID: 21379 RVA: 0x001008A8 File Offset: 0x000FECA8
		public int mpRecover
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700176D RID: 5997
		// (get) Token: 0x06005384 RID: 21380 RVA: 0x001008F4 File Offset: 0x000FECF4
		public int attack
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700176E RID: 5998
		// (get) Token: 0x06005385 RID: 21381 RVA: 0x00100940 File Offset: 0x000FED40
		public int magicAttack
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700176F RID: 5999
		// (get) Token: 0x06005386 RID: 21382 RVA: 0x0010098C File Offset: 0x000FED8C
		public int defence
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001770 RID: 6000
		// (get) Token: 0x06005387 RID: 21383 RVA: 0x001009D8 File Offset: 0x000FEDD8
		public int magicDefence
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001771 RID: 6001
		// (get) Token: 0x06005388 RID: 21384 RVA: 0x00100A24 File Offset: 0x000FEE24
		public int attackSpeed
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001772 RID: 6002
		// (get) Token: 0x06005389 RID: 21385 RVA: 0x00100A70 File Offset: 0x000FEE70
		public int spellSpeed
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001773 RID: 6003
		// (get) Token: 0x0600538A RID: 21386 RVA: 0x00100ABC File Offset: 0x000FEEBC
		public int moveSpeed
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001774 RID: 6004
		// (get) Token: 0x0600538B RID: 21387 RVA: 0x00100B0C File Offset: 0x000FEF0C
		public int ciriticalAttack
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001775 RID: 6005
		// (get) Token: 0x0600538C RID: 21388 RVA: 0x00100B5C File Offset: 0x000FEF5C
		public int ciriticalMagicAttack
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001776 RID: 6006
		// (get) Token: 0x0600538D RID: 21389 RVA: 0x00100BAC File Offset: 0x000FEFAC
		public int dex
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001777 RID: 6007
		// (get) Token: 0x0600538E RID: 21390 RVA: 0x00100BFC File Offset: 0x000FEFFC
		public int dodge
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001778 RID: 6008
		// (get) Token: 0x0600538F RID: 21391 RVA: 0x00100C4C File Offset: 0x000FF04C
		public int frozen
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001779 RID: 6009
		// (get) Token: 0x06005390 RID: 21392 RVA: 0x00100C9C File Offset: 0x000FF09C
		public int hard
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700177A RID: 6010
		// (get) Token: 0x06005391 RID: 21393 RVA: 0x00100CEC File Offset: 0x000FF0EC
		public int cdReduceRate
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700177B RID: 6011
		// (get) Token: 0x06005392 RID: 21394 RVA: 0x00100D3C File Offset: 0x000FF13C
		public int baseAtk
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700177C RID: 6012
		// (get) Token: 0x06005393 RID: 21395 RVA: 0x00100D8C File Offset: 0x000FF18C
		public int baseInt
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700177D RID: 6013
		// (get) Token: 0x06005394 RID: 21396 RVA: 0x00100DDC File Offset: 0x000FF1DC
		public int sta
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700177E RID: 6014
		// (get) Token: 0x06005395 RID: 21397 RVA: 0x00100E2C File Offset: 0x000FF22C
		public int spr
		{
			get
			{
				int num = this.__p.__offset(150);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700177F RID: 6015
		// (get) Token: 0x06005396 RID: 21398 RVA: 0x00100E7C File Offset: 0x000FF27C
		public int ignoreDefAttackAdd
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001780 RID: 6016
		// (get) Token: 0x06005397 RID: 21399 RVA: 0x00100ECC File Offset: 0x000FF2CC
		public int ignoreDefMagicAttackAdd
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005398 RID: 21400 RVA: 0x00100F1C File Offset: 0x000FF31C
		public int ElementsArray(int j)
		{
			int num = this.__p.__offset(156);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001781 RID: 6017
		// (get) Token: 0x06005399 RID: 21401 RVA: 0x00100F6C File Offset: 0x000FF36C
		public int ElementsLength
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600539A RID: 21402 RVA: 0x00100FA2 File Offset: 0x000FF3A2
		public ArraySegment<byte>? GetElementsBytes()
		{
			return this.__p.__vector_as_arraysegment(156);
		}

		// Token: 0x17001782 RID: 6018
		// (get) Token: 0x0600539B RID: 21403 RVA: 0x00100FB4 File Offset: 0x000FF3B4
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

		// Token: 0x17001783 RID: 6019
		// (get) Token: 0x0600539C RID: 21404 RVA: 0x00100FE4 File Offset: 0x000FF3E4
		public UnionCell LightAttack
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001784 RID: 6020
		// (get) Token: 0x0600539D RID: 21405 RVA: 0x00101040 File Offset: 0x000FF440
		public UnionCell FireAttack
		{
			get
			{
				int num = this.__p.__offset(160);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001785 RID: 6021
		// (get) Token: 0x0600539E RID: 21406 RVA: 0x0010109C File Offset: 0x000FF49C
		public UnionCell IceAttack
		{
			get
			{
				int num = this.__p.__offset(162);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001786 RID: 6022
		// (get) Token: 0x0600539F RID: 21407 RVA: 0x001010F8 File Offset: 0x000FF4F8
		public UnionCell DarkAttack
		{
			get
			{
				int num = this.__p.__offset(164);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001787 RID: 6023
		// (get) Token: 0x060053A0 RID: 21408 RVA: 0x00101154 File Offset: 0x000FF554
		public UnionCell LightDefence
		{
			get
			{
				int num = this.__p.__offset(166);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001788 RID: 6024
		// (get) Token: 0x060053A1 RID: 21409 RVA: 0x001011B0 File Offset: 0x000FF5B0
		public UnionCell FireDefence
		{
			get
			{
				int num = this.__p.__offset(168);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001789 RID: 6025
		// (get) Token: 0x060053A2 RID: 21410 RVA: 0x0010120C File Offset: 0x000FF60C
		public UnionCell IceDefence
		{
			get
			{
				int num = this.__p.__offset(170);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700178A RID: 6026
		// (get) Token: 0x060053A3 RID: 21411 RVA: 0x00101268 File Offset: 0x000FF668
		public UnionCell DarkDefence
		{
			get
			{
				int num = this.__p.__offset(172);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700178B RID: 6027
		// (get) Token: 0x060053A4 RID: 21412 RVA: 0x001012C4 File Offset: 0x000FF6C4
		public UnionCell abnormalResist1
		{
			get
			{
				int num = this.__p.__offset(174);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700178C RID: 6028
		// (get) Token: 0x060053A5 RID: 21413 RVA: 0x00101320 File Offset: 0x000FF720
		public UnionCell abnormalResist2
		{
			get
			{
				int num = this.__p.__offset(176);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700178D RID: 6029
		// (get) Token: 0x060053A6 RID: 21414 RVA: 0x0010137C File Offset: 0x000FF77C
		public UnionCell abnormalResist3
		{
			get
			{
				int num = this.__p.__offset(178);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700178E RID: 6030
		// (get) Token: 0x060053A7 RID: 21415 RVA: 0x001013D8 File Offset: 0x000FF7D8
		public UnionCell abnormalResist4
		{
			get
			{
				int num = this.__p.__offset(180);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700178F RID: 6031
		// (get) Token: 0x060053A8 RID: 21416 RVA: 0x00101434 File Offset: 0x000FF834
		public UnionCell abnormalResist5
		{
			get
			{
				int num = this.__p.__offset(182);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001790 RID: 6032
		// (get) Token: 0x060053A9 RID: 21417 RVA: 0x00101490 File Offset: 0x000FF890
		public UnionCell abnormalResist6
		{
			get
			{
				int num = this.__p.__offset(184);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001791 RID: 6033
		// (get) Token: 0x060053AA RID: 21418 RVA: 0x001014EC File Offset: 0x000FF8EC
		public UnionCell abnormalResist7
		{
			get
			{
				int num = this.__p.__offset(186);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001792 RID: 6034
		// (get) Token: 0x060053AB RID: 21419 RVA: 0x00101548 File Offset: 0x000FF948
		public UnionCell abnormalResist8
		{
			get
			{
				int num = this.__p.__offset(188);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001793 RID: 6035
		// (get) Token: 0x060053AC RID: 21420 RVA: 0x001015A4 File Offset: 0x000FF9A4
		public UnionCell abnormalResist9
		{
			get
			{
				int num = this.__p.__offset(190);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001794 RID: 6036
		// (get) Token: 0x060053AD RID: 21421 RVA: 0x00101600 File Offset: 0x000FFA00
		public UnionCell abnormalResist10
		{
			get
			{
				int num = this.__p.__offset(192);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001795 RID: 6037
		// (get) Token: 0x060053AE RID: 21422 RVA: 0x0010165C File Offset: 0x000FFA5C
		public UnionCell abnormalResist11
		{
			get
			{
				int num = this.__p.__offset(194);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001796 RID: 6038
		// (get) Token: 0x060053AF RID: 21423 RVA: 0x001016B8 File Offset: 0x000FFAB8
		public UnionCell abnormalResist12
		{
			get
			{
				int num = this.__p.__offset(196);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001797 RID: 6039
		// (get) Token: 0x060053B0 RID: 21424 RVA: 0x00101714 File Offset: 0x000FFB14
		public UnionCell abnormalResist13
		{
			get
			{
				int num = this.__p.__offset(198);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001798 RID: 6040
		// (get) Token: 0x060053B1 RID: 21425 RVA: 0x00101770 File Offset: 0x000FFB70
		public int UseProtect
		{
			get
			{
				int num = this.__p.__offset(200);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001799 RID: 6041
		// (get) Token: 0x060053B2 RID: 21426 RVA: 0x001017C0 File Offset: 0x000FFBC0
		public int ProtectFloatPercent
		{
			get
			{
				int num = this.__p.__offset(202);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700179A RID: 6042
		// (get) Token: 0x060053B3 RID: 21427 RVA: 0x00101810 File Offset: 0x000FFC10
		public int ProtectFloatPercent2
		{
			get
			{
				int num = this.__p.__offset(204);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700179B RID: 6043
		// (get) Token: 0x060053B4 RID: 21428 RVA: 0x00101860 File Offset: 0x000FFC60
		public int ProtectGroundPercent
		{
			get
			{
				int num = this.__p.__offset(206);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700179C RID: 6044
		// (get) Token: 0x060053B5 RID: 21429 RVA: 0x001018B0 File Offset: 0x000FFCB0
		public int ProtectStandPercent
		{
			get
			{
				int num = this.__p.__offset(208);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700179D RID: 6045
		// (get) Token: 0x060053B6 RID: 21430 RVA: 0x00101900 File Offset: 0x000FFD00
		public UnitTable_Level.eBornAI BornAI
		{
			get
			{
				int num = this.__p.__offset(210);
				return (UnitTable_Level.eBornAI)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700179E RID: 6046
		// (get) Token: 0x060053B7 RID: 21431 RVA: 0x00101948 File Offset: 0x000FFD48
		public int AICombatType
		{
			get
			{
				int num = this.__p.__offset(212);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060053B8 RID: 21432 RVA: 0x00101998 File Offset: 0x000FFD98
		public int AITargetTypeArray(int j)
		{
			int num = this.__p.__offset(214);
			return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700179F RID: 6047
		// (get) Token: 0x060053B9 RID: 21433 RVA: 0x001019E8 File Offset: 0x000FFDE8
		public int AITargetTypeLength
		{
			get
			{
				int num = this.__p.__offset(214);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060053BA RID: 21434 RVA: 0x00101A1E File Offset: 0x000FFE1E
		public ArraySegment<byte>? GetAITargetTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(214);
		}

		// Token: 0x170017A0 RID: 6048
		// (get) Token: 0x060053BB RID: 21435 RVA: 0x00101A30 File Offset: 0x000FFE30
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

		// Token: 0x170017A1 RID: 6049
		// (get) Token: 0x060053BC RID: 21436 RVA: 0x00101A60 File Offset: 0x000FFE60
		public int AISight
		{
			get
			{
				int num = this.__p.__offset(216);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017A2 RID: 6050
		// (get) Token: 0x060053BD RID: 21437 RVA: 0x00101AB0 File Offset: 0x000FFEB0
		public int AIChase
		{
			get
			{
				int num = this.__p.__offset(218);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017A3 RID: 6051
		// (get) Token: 0x060053BE RID: 21438 RVA: 0x00101B00 File Offset: 0x000FFF00
		public int AIWarlike
		{
			get
			{
				int num = this.__p.__offset(220);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017A4 RID: 6052
		// (get) Token: 0x060053BF RID: 21439 RVA: 0x00101B50 File Offset: 0x000FFF50
		public int AIFollowDistance
		{
			get
			{
				int num = this.__p.__offset(222);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017A5 RID: 6053
		// (get) Token: 0x060053C0 RID: 21440 RVA: 0x00101BA0 File Offset: 0x000FFFA0
		public int AIKeepDistance
		{
			get
			{
				int num = this.__p.__offset(224);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017A6 RID: 6054
		// (get) Token: 0x060053C1 RID: 21441 RVA: 0x00101BF0 File Offset: 0x000FFFF0
		public int AIAttackDelay
		{
			get
			{
				int num = this.__p.__offset(226);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017A7 RID: 6055
		// (get) Token: 0x060053C2 RID: 21442 RVA: 0x00101C40 File Offset: 0x00100040
		public int AIDestinationChangeTerm
		{
			get
			{
				int num = this.__p.__offset(228);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017A8 RID: 6056
		// (get) Token: 0x060053C3 RID: 21443 RVA: 0x00101C90 File Offset: 0x00100090
		public int AIThinkTargetTerm
		{
			get
			{
				int num = this.__p.__offset(230);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060053C4 RID: 21444 RVA: 0x00101CE0 File Offset: 0x001000E0
		public string AIAttackKindArray(int j)
		{
			int num = this.__p.__offset(232);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017A9 RID: 6057
		// (get) Token: 0x060053C5 RID: 21445 RVA: 0x00101D2C File Offset: 0x0010012C
		public int AIAttackKindLength
		{
			get
			{
				int num = this.__p.__offset(232);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017AA RID: 6058
		// (get) Token: 0x060053C6 RID: 21446 RVA: 0x00101D62 File Offset: 0x00100162
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

		// Token: 0x170017AB RID: 6059
		// (get) Token: 0x060053C7 RID: 21447 RVA: 0x00101D94 File Offset: 0x00100194
		public int AIIdleMode
		{
			get
			{
				int num = this.__p.__offset(234);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017AC RID: 6060
		// (get) Token: 0x060053C8 RID: 21448 RVA: 0x00101DE4 File Offset: 0x001001E4
		public int AIIsAPC
		{
			get
			{
				int num = this.__p.__offset(236);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017AD RID: 6061
		// (get) Token: 0x060053C9 RID: 21449 RVA: 0x00101E34 File Offset: 0x00100234
		public int AIIdleRand
		{
			get
			{
				int num = this.__p.__offset(238);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017AE RID: 6062
		// (get) Token: 0x060053CA RID: 21450 RVA: 0x00101E84 File Offset: 0x00100284
		public int AIIdleDuration
		{
			get
			{
				int num = this.__p.__offset(240);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017AF RID: 6063
		// (get) Token: 0x060053CB RID: 21451 RVA: 0x00101ED4 File Offset: 0x001002D4
		public int AIEscapeRand
		{
			get
			{
				int num = this.__p.__offset(242);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B0 RID: 6064
		// (get) Token: 0x060053CC RID: 21452 RVA: 0x00101F24 File Offset: 0x00100324
		public int AIWanderRand
		{
			get
			{
				int num = this.__p.__offset(244);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B1 RID: 6065
		// (get) Token: 0x060053CD RID: 21453 RVA: 0x00101F74 File Offset: 0x00100374
		public int AIWanderRange
		{
			get
			{
				int num = this.__p.__offset(246);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B2 RID: 6066
		// (get) Token: 0x060053CE RID: 21454 RVA: 0x00101FC4 File Offset: 0x001003C4
		public int AIWalkBackRange
		{
			get
			{
				int num = this.__p.__offset(248);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B3 RID: 6067
		// (get) Token: 0x060053CF RID: 21455 RVA: 0x00102014 File Offset: 0x00100414
		public int AIYFirstRand
		{
			get
			{
				int num = this.__p.__offset(250);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B4 RID: 6068
		// (get) Token: 0x060053D0 RID: 21456 RVA: 0x00102064 File Offset: 0x00100464
		public int AIMaxWalkCmdCount
		{
			get
			{
				int num = this.__p.__offset(252);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B5 RID: 6069
		// (get) Token: 0x060053D1 RID: 21457 RVA: 0x001020B4 File Offset: 0x001004B4
		public int AIMaxIdleCmdCount
		{
			get
			{
				int num = this.__p.__offset(254);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B6 RID: 6070
		// (get) Token: 0x060053D2 RID: 21458 RVA: 0x00102104 File Offset: 0x00100504
		public int AIWeaponTag
		{
			get
			{
				int num = this.__p.__offset(256);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B7 RID: 6071
		// (get) Token: 0x060053D3 RID: 21459 RVA: 0x00102154 File Offset: 0x00100554
		public int APCIsSpecialConfig
		{
			get
			{
				int num = this.__p.__offset(258);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B8 RID: 6072
		// (get) Token: 0x060053D4 RID: 21460 RVA: 0x001021A4 File Offset: 0x001005A4
		public int APCWeaponRes
		{
			get
			{
				int num = this.__p.__offset(260);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017B9 RID: 6073
		// (get) Token: 0x060053D5 RID: 21461 RVA: 0x001021F4 File Offset: 0x001005F4
		public int APCWeaponStrengthLevel
		{
			get
			{
				int num = this.__p.__offset(262);
				return (num == 0) ? 0 : (-601822511 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017BA RID: 6074
		// (get) Token: 0x060053D6 RID: 21462 RVA: 0x00102244 File Offset: 0x00100644
		public string AIActionPath
		{
			get
			{
				int num = this.__p.__offset(264);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060053D7 RID: 21463 RVA: 0x0010228A File Offset: 0x0010068A
		public ArraySegment<byte>? GetAIActionPathBytes()
		{
			return this.__p.__vector_as_arraysegment(264);
		}

		// Token: 0x170017BB RID: 6075
		// (get) Token: 0x060053D8 RID: 21464 RVA: 0x0010229C File Offset: 0x0010069C
		public string AIDestinationSelectPath
		{
			get
			{
				int num = this.__p.__offset(266);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060053D9 RID: 21465 RVA: 0x001022E2 File Offset: 0x001006E2
		public ArraySegment<byte>? GetAIDestinationSelectPathBytes()
		{
			return this.__p.__vector_as_arraysegment(266);
		}

		// Token: 0x170017BC RID: 6076
		// (get) Token: 0x060053DA RID: 21466 RVA: 0x001022F4 File Offset: 0x001006F4
		public string AIEventPath
		{
			get
			{
				int num = this.__p.__offset(268);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060053DB RID: 21467 RVA: 0x0010233A File Offset: 0x0010073A
		public ArraySegment<byte>? GetAIEventPathBytes()
		{
			return this.__p.__vector_as_arraysegment(268);
		}

		// Token: 0x060053DC RID: 21468 RVA: 0x0010234C File Offset: 0x0010074C
		public string AttackInModelStageArray(int j)
		{
			int num = this.__p.__offset(270);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017BD RID: 6077
		// (get) Token: 0x060053DD RID: 21469 RVA: 0x00102398 File Offset: 0x00100798
		public int AttackInModelStageLength
		{
			get
			{
				int num = this.__p.__offset(270);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017BE RID: 6078
		// (get) Token: 0x060053DE RID: 21470 RVA: 0x001023CE File Offset: 0x001007CE
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

		// Token: 0x060053DF RID: 21471 RVA: 0x001023FE File Offset: 0x001007FE
		public static void StartUnitTable_Level(FlatBufferBuilder builder)
		{
			builder.StartObject(134);
		}

		// Token: 0x060053E0 RID: 21472 RVA: 0x0010240B File Offset: 0x0010080B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060053E1 RID: 21473 RVA: 0x00102416 File Offset: 0x00100816
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060053E2 RID: 21474 RVA: 0x00102427 File Offset: 0x00100827
		public static void AddBossShowActionName(FlatBufferBuilder builder, StringOffset BossShowActionNameOffset)
		{
			builder.AddOffset(2, BossShowActionNameOffset.Value, 0);
		}

		// Token: 0x060053E3 RID: 21475 RVA: 0x00102438 File Offset: 0x00100838
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(3, DescOffset.Value, 0);
		}

		// Token: 0x060053E4 RID: 21476 RVA: 0x00102449 File Offset: 0x00100849
		public static void AddMonsterMode(FlatBufferBuilder builder, int MonsterMode)
		{
			builder.AddInt(4, MonsterMode, 0);
		}

		// Token: 0x060053E5 RID: 21477 RVA: 0x00102454 File Offset: 0x00100854
		public static void AddType(FlatBufferBuilder builder, UnitTable_Level.eType Type)
		{
			builder.AddInt(5, (int)Type, 0);
		}

		// Token: 0x060053E6 RID: 21478 RVA: 0x0010245F File Offset: 0x0010085F
		public static void AddIsShowPortrait(FlatBufferBuilder builder, int IsShowPortrait)
		{
			builder.AddInt(6, IsShowPortrait, 0);
		}

		// Token: 0x060053E7 RID: 21479 RVA: 0x0010246A File Offset: 0x0010086A
		public static void AddCamp(FlatBufferBuilder builder, UnitTable_Level.eCamp Camp)
		{
			builder.AddInt(7, (int)Camp, 0);
		}

		// Token: 0x060053E8 RID: 21480 RVA: 0x00102475 File Offset: 0x00100875
		public static void AddMonsterRace(FlatBufferBuilder builder, UnitTable_Level.eMonsterRace MonsterRace)
		{
			builder.AddInt(8, (int)MonsterRace, 0);
		}

		// Token: 0x060053E9 RID: 21481 RVA: 0x00102480 File Offset: 0x00100880
		public static void AddMode(FlatBufferBuilder builder, int Mode)
		{
			builder.AddInt(9, Mode, 0);
		}

		// Token: 0x060053EA RID: 21482 RVA: 0x0010248C File Offset: 0x0010088C
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(10, Weight, 0);
		}

		// Token: 0x060053EB RID: 21483 RVA: 0x00102498 File Offset: 0x00100898
		public static void AddAutoFightNeedAttackFirst(FlatBufferBuilder builder, int AutoFightNeedAttackFirst)
		{
			builder.AddInt(11, AutoFightNeedAttackFirst, 0);
		}

		// Token: 0x060053EC RID: 21484 RVA: 0x001024A4 File Offset: 0x001008A4
		public static void AddSkillMonsterCanBeAttack(FlatBufferBuilder builder, int SkillMonsterCanBeAttack)
		{
			builder.AddInt(12, SkillMonsterCanBeAttack, 0);
		}

		// Token: 0x060053ED RID: 21485 RVA: 0x001024B0 File Offset: 0x001008B0
		public static void AddScale(FlatBufferBuilder builder, Offset<UnionCell> ScaleOffset)
		{
			builder.AddOffset(13, ScaleOffset.Value, 0);
		}

		// Token: 0x060053EE RID: 21486 RVA: 0x001024C2 File Offset: 0x001008C2
		public static void AddEnhanceRadius(FlatBufferBuilder builder, int enhanceRadius)
		{
			builder.AddInt(14, enhanceRadius, 0);
		}

		// Token: 0x060053EF RID: 21487 RVA: 0x001024CE File Offset: 0x001008CE
		public static void AddOverHeadHeight(FlatBufferBuilder builder, int overHeadHeight)
		{
			builder.AddInt(15, overHeadHeight, 0);
		}

		// Token: 0x060053F0 RID: 21488 RVA: 0x001024DA File Offset: 0x001008DA
		public static void AddBuffOriginHeight(FlatBufferBuilder builder, int buffOriginHeight)
		{
			builder.AddInt(16, buffOriginHeight, 0);
		}

		// Token: 0x060053F1 RID: 21489 RVA: 0x001024E6 File Offset: 0x001008E6
		public static void AddWalkSpeed(FlatBufferBuilder builder, int WalkSpeed)
		{
			builder.AddInt(17, WalkSpeed, 0);
		}

		// Token: 0x060053F2 RID: 21490 RVA: 0x001024F2 File Offset: 0x001008F2
		public static void AddWalkAnimationSpeedPerent(FlatBufferBuilder builder, int WalkAnimationSpeedPerent)
		{
			builder.AddInt(18, WalkAnimationSpeedPerent, 0);
		}

		// Token: 0x060053F3 RID: 21491 RVA: 0x001024FE File Offset: 0x001008FE
		public static void AddMonsterTitle(FlatBufferBuilder builder, int MonsterTitle)
		{
			builder.AddInt(19, MonsterTitle, 0);
		}

		// Token: 0x060053F4 RID: 21492 RVA: 0x0010250A File Offset: 0x0010090A
		public static void AddAttackSkillID(FlatBufferBuilder builder, int AttackSkillID)
		{
			builder.AddInt(20, AttackSkillID, 0);
		}

		// Token: 0x060053F5 RID: 21493 RVA: 0x00102516 File Offset: 0x00100916
		public static void AddGetupBati(FlatBufferBuilder builder, int GetupBati)
		{
			builder.AddInt(21, GetupBati, 0);
		}

		// Token: 0x060053F6 RID: 21494 RVA: 0x00102522 File Offset: 0x00100922
		public static void AddGetupSkillRand(FlatBufferBuilder builder, int GetupSkillRand)
		{
			builder.AddInt(22, GetupSkillRand, 0);
		}

		// Token: 0x060053F7 RID: 21495 RVA: 0x0010252E File Offset: 0x0010092E
		public static void AddGetupSkillID(FlatBufferBuilder builder, int GetupSkillID)
		{
			builder.AddInt(23, GetupSkillID, 0);
		}

		// Token: 0x060053F8 RID: 21496 RVA: 0x0010253A File Offset: 0x0010093A
		public static void AddHitSkillRand(FlatBufferBuilder builder, int HitSkillRand)
		{
			builder.AddInt(24, HitSkillRand, 0);
		}

		// Token: 0x060053F9 RID: 21497 RVA: 0x00102546 File Offset: 0x00100946
		public static void AddHitSkillID(FlatBufferBuilder builder, int HitSkillID)
		{
			builder.AddInt(25, HitSkillID, 0);
		}

		// Token: 0x060053FA RID: 21498 RVA: 0x00102552 File Offset: 0x00100952
		public static void AddSkillIDs(FlatBufferBuilder builder, VectorOffset SkillIDsOffset)
		{
			builder.AddOffset(26, SkillIDsOffset.Value, 0);
		}

		// Token: 0x060053FB RID: 21499 RVA: 0x00102564 File Offset: 0x00100964
		public static VectorOffset CreateSkillIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060053FC RID: 21500 RVA: 0x001025A1 File Offset: 0x001009A1
		public static void StartSkillIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060053FD RID: 21501 RVA: 0x001025AC File Offset: 0x001009AC
		public static void AddHurt(FlatBufferBuilder builder, StringOffset HurtOffset)
		{
			builder.AddOffset(27, HurtOffset.Value, 0);
		}

		// Token: 0x060053FE RID: 21502 RVA: 0x001025BE File Offset: 0x001009BE
		public static void AddFootEffectName(FlatBufferBuilder builder, StringOffset FootEffectNameOffset)
		{
			builder.AddOffset(28, FootEffectNameOffset.Value, 0);
		}

		// Token: 0x060053FF RID: 21503 RVA: 0x001025D0 File Offset: 0x001009D0
		public static void AddWeaponModel(FlatBufferBuilder builder, StringOffset WeaponModelOffset)
		{
			builder.AddOffset(29, WeaponModelOffset.Value, 0);
		}

		// Token: 0x06005400 RID: 21504 RVA: 0x001025E2 File Offset: 0x001009E2
		public static void AddWeaponLocator(FlatBufferBuilder builder, StringOffset WeaponLocatorOffset)
		{
			builder.AddOffset(30, WeaponLocatorOffset.Value, 0);
		}

		// Token: 0x06005401 RID: 21505 RVA: 0x001025F4 File Offset: 0x001009F4
		public static void AddExp(FlatBufferBuilder builder, int Exp)
		{
			builder.AddInt(31, Exp, 0);
		}

		// Token: 0x06005402 RID: 21506 RVA: 0x00102600 File Offset: 0x00100A00
		public static void AddPrefixEffect(FlatBufferBuilder builder, StringOffset PrefixEffectOffset)
		{
			builder.AddOffset(32, PrefixEffectOffset.Value, 0);
		}

		// Token: 0x06005403 RID: 21507 RVA: 0x00102612 File Offset: 0x00100A12
		public static void AddDefaultAttackHitSFXID(FlatBufferBuilder builder, int DefaultAttackHitSFXID)
		{
			builder.AddInt(33, DefaultAttackHitSFXID, 0);
		}

		// Token: 0x06005404 RID: 21508 RVA: 0x0010261E File Offset: 0x00100A1E
		public static void AddDropID(FlatBufferBuilder builder, int DropID)
		{
			builder.AddInt(34, DropID, 0);
		}

		// Token: 0x06005405 RID: 21509 RVA: 0x0010262A File Offset: 0x00100A2A
		public static void AddAwardID(FlatBufferBuilder builder, int AwardID)
		{
			builder.AddInt(35, AwardID, 0);
		}

		// Token: 0x06005406 RID: 21510 RVA: 0x00102636 File Offset: 0x00100A36
		public static void AddExistDuration(FlatBufferBuilder builder, Offset<UnionCell> ExistDurationOffset)
		{
			builder.AddOffset(36, ExistDurationOffset.Value, 0);
		}

		// Token: 0x06005407 RID: 21511 RVA: 0x00102648 File Offset: 0x00100A48
		public static void AddPVPExistDuration(FlatBufferBuilder builder, Offset<UnionCell> PVPExistDurationOffset)
		{
			builder.AddOffset(37, PVPExistDurationOffset.Value, 0);
		}

		// Token: 0x06005408 RID: 21512 RVA: 0x0010265A File Offset: 0x00100A5A
		public static void AddFloatValue(FlatBufferBuilder builder, int FloatValue)
		{
			builder.AddInt(38, FloatValue, 0);
		}

		// Token: 0x06005409 RID: 21513 RVA: 0x00102666 File Offset: 0x00100A66
		public static void AddDescriptionA(FlatBufferBuilder builder, StringOffset DescriptionAOffset)
		{
			builder.AddOffset(39, DescriptionAOffset.Value, 0);
		}

		// Token: 0x0600540A RID: 21514 RVA: 0x00102678 File Offset: 0x00100A78
		public static void AddValueA(FlatBufferBuilder builder, int ValueA)
		{
			builder.AddInt(40, ValueA, 0);
		}

		// Token: 0x0600540B RID: 21515 RVA: 0x00102684 File Offset: 0x00100A84
		public static void AddWalkSpeech(FlatBufferBuilder builder, VectorOffset WalkSpeechOffset)
		{
			builder.AddOffset(41, WalkSpeechOffset.Value, 0);
		}

		// Token: 0x0600540C RID: 21516 RVA: 0x00102698 File Offset: 0x00100A98
		public static VectorOffset CreateWalkSpeechVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600540D RID: 21517 RVA: 0x001026D5 File Offset: 0x00100AD5
		public static void StartWalkSpeechVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600540E RID: 21518 RVA: 0x001026E0 File Offset: 0x00100AE0
		public static void AddAttackSpeech(FlatBufferBuilder builder, VectorOffset AttackSpeechOffset)
		{
			builder.AddOffset(42, AttackSpeechOffset.Value, 0);
		}

		// Token: 0x0600540F RID: 21519 RVA: 0x001026F4 File Offset: 0x00100AF4
		public static VectorOffset CreateAttackSpeechVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06005410 RID: 21520 RVA: 0x00102731 File Offset: 0x00100B31
		public static void StartAttackSpeechVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005411 RID: 21521 RVA: 0x0010273C File Offset: 0x00100B3C
		public static void AddBirthSpeech(FlatBufferBuilder builder, VectorOffset BirthSpeechOffset)
		{
			builder.AddOffset(43, BirthSpeechOffset.Value, 0);
		}

		// Token: 0x06005412 RID: 21522 RVA: 0x00102750 File Offset: 0x00100B50
		public static VectorOffset CreateBirthSpeechVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06005413 RID: 21523 RVA: 0x0010278D File Offset: 0x00100B8D
		public static void StartBirthSpeechVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005414 RID: 21524 RVA: 0x00102798 File Offset: 0x00100B98
		public static void AddShowName(FlatBufferBuilder builder, bool ShowName)
		{
			builder.AddBool(44, ShowName, false);
		}

		// Token: 0x06005415 RID: 21525 RVA: 0x001027A4 File Offset: 0x00100BA4
		public static void AddShowHPBar(FlatBufferBuilder builder, bool ShowHPBar)
		{
			builder.AddBool(45, ShowHPBar, false);
		}

		// Token: 0x06005416 RID: 21526 RVA: 0x001027B0 File Offset: 0x00100BB0
		public static void AddShowFootBar(FlatBufferBuilder builder, bool ShowFootBar)
		{
			builder.AddBool(46, ShowFootBar, false);
		}

		// Token: 0x06005417 RID: 21527 RVA: 0x001027BC File Offset: 0x00100BBC
		public static void AddAbilityChange(FlatBufferBuilder builder, VectorOffset AbilityChangeOffset)
		{
			builder.AddOffset(47, AbilityChangeOffset.Value, 0);
		}

		// Token: 0x06005418 RID: 21528 RVA: 0x001027D0 File Offset: 0x00100BD0
		public static VectorOffset CreateAbilityChangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06005419 RID: 21529 RVA: 0x0010280D File Offset: 0x00100C0D
		public static void StartAbilityChangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600541A RID: 21530 RVA: 0x00102818 File Offset: 0x00100C18
		public static void AddBornBuff(FlatBufferBuilder builder, VectorOffset BornBuffOffset)
		{
			builder.AddOffset(48, BornBuffOffset.Value, 0);
		}

		// Token: 0x0600541B RID: 21531 RVA: 0x0010282C File Offset: 0x00100C2C
		public static VectorOffset CreateBornBuffVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600541C RID: 21532 RVA: 0x00102869 File Offset: 0x00100C69
		public static void StartBornBuffVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600541D RID: 21533 RVA: 0x00102874 File Offset: 0x00100C74
		public static void AddBornBuff2(FlatBufferBuilder builder, VectorOffset BornBuff2Offset)
		{
			builder.AddOffset(49, BornBuff2Offset.Value, 0);
		}

		// Token: 0x0600541E RID: 21534 RVA: 0x00102888 File Offset: 0x00100C88
		public static VectorOffset CreateBornBuff2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600541F RID: 21535 RVA: 0x001028C5 File Offset: 0x00100CC5
		public static void StartBornBuff2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005420 RID: 21536 RVA: 0x001028D0 File Offset: 0x00100CD0
		public static void AddBornMechanism(FlatBufferBuilder builder, VectorOffset BornMechanismOffset)
		{
			builder.AddOffset(50, BornMechanismOffset.Value, 0);
		}

		// Token: 0x06005421 RID: 21537 RVA: 0x001028E4 File Offset: 0x00100CE4
		public static VectorOffset CreateBornMechanismVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06005422 RID: 21538 RVA: 0x00102921 File Offset: 0x00100D21
		public static void StartBornMechanismVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005423 RID: 21539 RVA: 0x0010292C File Offset: 0x00100D2C
		public static void AddMaxFixHp(FlatBufferBuilder builder, Offset<UnionCell> maxFixHpOffset)
		{
			builder.AddOffset(51, maxFixHpOffset.Value, 0);
		}

		// Token: 0x06005424 RID: 21540 RVA: 0x0010293E File Offset: 0x00100D3E
		public static void AddMaxHp(FlatBufferBuilder builder, int maxHp)
		{
			builder.AddInt(52, maxHp, 0);
		}

		// Token: 0x06005425 RID: 21541 RVA: 0x0010294A File Offset: 0x00100D4A
		public static void AddMaxMp(FlatBufferBuilder builder, int maxMp)
		{
			builder.AddInt(53, maxMp, 0);
		}

		// Token: 0x06005426 RID: 21542 RVA: 0x00102956 File Offset: 0x00100D56
		public static void AddHpRecover(FlatBufferBuilder builder, int hpRecover)
		{
			builder.AddInt(54, hpRecover, 0);
		}

		// Token: 0x06005427 RID: 21543 RVA: 0x00102962 File Offset: 0x00100D62
		public static void AddMpRecover(FlatBufferBuilder builder, int mpRecover)
		{
			builder.AddInt(55, mpRecover, 0);
		}

		// Token: 0x06005428 RID: 21544 RVA: 0x0010296E File Offset: 0x00100D6E
		public static void AddAttack(FlatBufferBuilder builder, int attack)
		{
			builder.AddInt(56, attack, 0);
		}

		// Token: 0x06005429 RID: 21545 RVA: 0x0010297A File Offset: 0x00100D7A
		public static void AddMagicAttack(FlatBufferBuilder builder, int magicAttack)
		{
			builder.AddInt(57, magicAttack, 0);
		}

		// Token: 0x0600542A RID: 21546 RVA: 0x00102986 File Offset: 0x00100D86
		public static void AddDefence(FlatBufferBuilder builder, int defence)
		{
			builder.AddInt(58, defence, 0);
		}

		// Token: 0x0600542B RID: 21547 RVA: 0x00102992 File Offset: 0x00100D92
		public static void AddMagicDefence(FlatBufferBuilder builder, int magicDefence)
		{
			builder.AddInt(59, magicDefence, 0);
		}

		// Token: 0x0600542C RID: 21548 RVA: 0x0010299E File Offset: 0x00100D9E
		public static void AddAttackSpeed(FlatBufferBuilder builder, int attackSpeed)
		{
			builder.AddInt(60, attackSpeed, 0);
		}

		// Token: 0x0600542D RID: 21549 RVA: 0x001029AA File Offset: 0x00100DAA
		public static void AddSpellSpeed(FlatBufferBuilder builder, int spellSpeed)
		{
			builder.AddInt(61, spellSpeed, 0);
		}

		// Token: 0x0600542E RID: 21550 RVA: 0x001029B6 File Offset: 0x00100DB6
		public static void AddMoveSpeed(FlatBufferBuilder builder, int moveSpeed)
		{
			builder.AddInt(62, moveSpeed, 0);
		}

		// Token: 0x0600542F RID: 21551 RVA: 0x001029C2 File Offset: 0x00100DC2
		public static void AddCiriticalAttack(FlatBufferBuilder builder, int ciriticalAttack)
		{
			builder.AddInt(63, ciriticalAttack, 0);
		}

		// Token: 0x06005430 RID: 21552 RVA: 0x001029CE File Offset: 0x00100DCE
		public static void AddCiriticalMagicAttack(FlatBufferBuilder builder, int ciriticalMagicAttack)
		{
			builder.AddInt(64, ciriticalMagicAttack, 0);
		}

		// Token: 0x06005431 RID: 21553 RVA: 0x001029DA File Offset: 0x00100DDA
		public static void AddDex(FlatBufferBuilder builder, int dex)
		{
			builder.AddInt(65, dex, 0);
		}

		// Token: 0x06005432 RID: 21554 RVA: 0x001029E6 File Offset: 0x00100DE6
		public static void AddDodge(FlatBufferBuilder builder, int dodge)
		{
			builder.AddInt(66, dodge, 0);
		}

		// Token: 0x06005433 RID: 21555 RVA: 0x001029F2 File Offset: 0x00100DF2
		public static void AddFrozen(FlatBufferBuilder builder, int frozen)
		{
			builder.AddInt(67, frozen, 0);
		}

		// Token: 0x06005434 RID: 21556 RVA: 0x001029FE File Offset: 0x00100DFE
		public static void AddHard(FlatBufferBuilder builder, int hard)
		{
			builder.AddInt(68, hard, 0);
		}

		// Token: 0x06005435 RID: 21557 RVA: 0x00102A0A File Offset: 0x00100E0A
		public static void AddCdReduceRate(FlatBufferBuilder builder, int cdReduceRate)
		{
			builder.AddInt(69, cdReduceRate, 0);
		}

		// Token: 0x06005436 RID: 21558 RVA: 0x00102A16 File Offset: 0x00100E16
		public static void AddBaseAtk(FlatBufferBuilder builder, int baseAtk)
		{
			builder.AddInt(70, baseAtk, 0);
		}

		// Token: 0x06005437 RID: 21559 RVA: 0x00102A22 File Offset: 0x00100E22
		public static void AddBaseInt(FlatBufferBuilder builder, int baseInt)
		{
			builder.AddInt(71, baseInt, 0);
		}

		// Token: 0x06005438 RID: 21560 RVA: 0x00102A2E File Offset: 0x00100E2E
		public static void AddSta(FlatBufferBuilder builder, int sta)
		{
			builder.AddInt(72, sta, 0);
		}

		// Token: 0x06005439 RID: 21561 RVA: 0x00102A3A File Offset: 0x00100E3A
		public static void AddSpr(FlatBufferBuilder builder, int spr)
		{
			builder.AddInt(73, spr, 0);
		}

		// Token: 0x0600543A RID: 21562 RVA: 0x00102A46 File Offset: 0x00100E46
		public static void AddIgnoreDefAttackAdd(FlatBufferBuilder builder, int ignoreDefAttackAdd)
		{
			builder.AddInt(74, ignoreDefAttackAdd, 0);
		}

		// Token: 0x0600543B RID: 21563 RVA: 0x00102A52 File Offset: 0x00100E52
		public static void AddIgnoreDefMagicAttackAdd(FlatBufferBuilder builder, int ignoreDefMagicAttackAdd)
		{
			builder.AddInt(75, ignoreDefMagicAttackAdd, 0);
		}

		// Token: 0x0600543C RID: 21564 RVA: 0x00102A5E File Offset: 0x00100E5E
		public static void AddElements(FlatBufferBuilder builder, VectorOffset ElementsOffset)
		{
			builder.AddOffset(76, ElementsOffset.Value, 0);
		}

		// Token: 0x0600543D RID: 21565 RVA: 0x00102A70 File Offset: 0x00100E70
		public static VectorOffset CreateElementsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600543E RID: 21566 RVA: 0x00102AAD File Offset: 0x00100EAD
		public static void StartElementsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600543F RID: 21567 RVA: 0x00102AB8 File Offset: 0x00100EB8
		public static void AddLightAttack(FlatBufferBuilder builder, Offset<UnionCell> LightAttackOffset)
		{
			builder.AddOffset(77, LightAttackOffset.Value, 0);
		}

		// Token: 0x06005440 RID: 21568 RVA: 0x00102ACA File Offset: 0x00100ECA
		public static void AddFireAttack(FlatBufferBuilder builder, Offset<UnionCell> FireAttackOffset)
		{
			builder.AddOffset(78, FireAttackOffset.Value, 0);
		}

		// Token: 0x06005441 RID: 21569 RVA: 0x00102ADC File Offset: 0x00100EDC
		public static void AddIceAttack(FlatBufferBuilder builder, Offset<UnionCell> IceAttackOffset)
		{
			builder.AddOffset(79, IceAttackOffset.Value, 0);
		}

		// Token: 0x06005442 RID: 21570 RVA: 0x00102AEE File Offset: 0x00100EEE
		public static void AddDarkAttack(FlatBufferBuilder builder, Offset<UnionCell> DarkAttackOffset)
		{
			builder.AddOffset(80, DarkAttackOffset.Value, 0);
		}

		// Token: 0x06005443 RID: 21571 RVA: 0x00102B00 File Offset: 0x00100F00
		public static void AddLightDefence(FlatBufferBuilder builder, Offset<UnionCell> LightDefenceOffset)
		{
			builder.AddOffset(81, LightDefenceOffset.Value, 0);
		}

		// Token: 0x06005444 RID: 21572 RVA: 0x00102B12 File Offset: 0x00100F12
		public static void AddFireDefence(FlatBufferBuilder builder, Offset<UnionCell> FireDefenceOffset)
		{
			builder.AddOffset(82, FireDefenceOffset.Value, 0);
		}

		// Token: 0x06005445 RID: 21573 RVA: 0x00102B24 File Offset: 0x00100F24
		public static void AddIceDefence(FlatBufferBuilder builder, Offset<UnionCell> IceDefenceOffset)
		{
			builder.AddOffset(83, IceDefenceOffset.Value, 0);
		}

		// Token: 0x06005446 RID: 21574 RVA: 0x00102B36 File Offset: 0x00100F36
		public static void AddDarkDefence(FlatBufferBuilder builder, Offset<UnionCell> DarkDefenceOffset)
		{
			builder.AddOffset(84, DarkDefenceOffset.Value, 0);
		}

		// Token: 0x06005447 RID: 21575 RVA: 0x00102B48 File Offset: 0x00100F48
		public static void AddAbnormalResist1(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist1Offset)
		{
			builder.AddOffset(85, abnormalResist1Offset.Value, 0);
		}

		// Token: 0x06005448 RID: 21576 RVA: 0x00102B5A File Offset: 0x00100F5A
		public static void AddAbnormalResist2(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist2Offset)
		{
			builder.AddOffset(86, abnormalResist2Offset.Value, 0);
		}

		// Token: 0x06005449 RID: 21577 RVA: 0x00102B6C File Offset: 0x00100F6C
		public static void AddAbnormalResist3(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist3Offset)
		{
			builder.AddOffset(87, abnormalResist3Offset.Value, 0);
		}

		// Token: 0x0600544A RID: 21578 RVA: 0x00102B7E File Offset: 0x00100F7E
		public static void AddAbnormalResist4(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist4Offset)
		{
			builder.AddOffset(88, abnormalResist4Offset.Value, 0);
		}

		// Token: 0x0600544B RID: 21579 RVA: 0x00102B90 File Offset: 0x00100F90
		public static void AddAbnormalResist5(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist5Offset)
		{
			builder.AddOffset(89, abnormalResist5Offset.Value, 0);
		}

		// Token: 0x0600544C RID: 21580 RVA: 0x00102BA2 File Offset: 0x00100FA2
		public static void AddAbnormalResist6(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist6Offset)
		{
			builder.AddOffset(90, abnormalResist6Offset.Value, 0);
		}

		// Token: 0x0600544D RID: 21581 RVA: 0x00102BB4 File Offset: 0x00100FB4
		public static void AddAbnormalResist7(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist7Offset)
		{
			builder.AddOffset(91, abnormalResist7Offset.Value, 0);
		}

		// Token: 0x0600544E RID: 21582 RVA: 0x00102BC6 File Offset: 0x00100FC6
		public static void AddAbnormalResist8(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist8Offset)
		{
			builder.AddOffset(92, abnormalResist8Offset.Value, 0);
		}

		// Token: 0x0600544F RID: 21583 RVA: 0x00102BD8 File Offset: 0x00100FD8
		public static void AddAbnormalResist9(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist9Offset)
		{
			builder.AddOffset(93, abnormalResist9Offset.Value, 0);
		}

		// Token: 0x06005450 RID: 21584 RVA: 0x00102BEA File Offset: 0x00100FEA
		public static void AddAbnormalResist10(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist10Offset)
		{
			builder.AddOffset(94, abnormalResist10Offset.Value, 0);
		}

		// Token: 0x06005451 RID: 21585 RVA: 0x00102BFC File Offset: 0x00100FFC
		public static void AddAbnormalResist11(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist11Offset)
		{
			builder.AddOffset(95, abnormalResist11Offset.Value, 0);
		}

		// Token: 0x06005452 RID: 21586 RVA: 0x00102C0E File Offset: 0x0010100E
		public static void AddAbnormalResist12(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist12Offset)
		{
			builder.AddOffset(96, abnormalResist12Offset.Value, 0);
		}

		// Token: 0x06005453 RID: 21587 RVA: 0x00102C20 File Offset: 0x00101020
		public static void AddAbnormalResist13(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist13Offset)
		{
			builder.AddOffset(97, abnormalResist13Offset.Value, 0);
		}

		// Token: 0x06005454 RID: 21588 RVA: 0x00102C32 File Offset: 0x00101032
		public static void AddUseProtect(FlatBufferBuilder builder, int UseProtect)
		{
			builder.AddInt(98, UseProtect, 0);
		}

		// Token: 0x06005455 RID: 21589 RVA: 0x00102C3E File Offset: 0x0010103E
		public static void AddProtectFloatPercent(FlatBufferBuilder builder, int ProtectFloatPercent)
		{
			builder.AddInt(99, ProtectFloatPercent, 0);
		}

		// Token: 0x06005456 RID: 21590 RVA: 0x00102C4A File Offset: 0x0010104A
		public static void AddProtectFloatPercent2(FlatBufferBuilder builder, int ProtectFloatPercent2)
		{
			builder.AddInt(100, ProtectFloatPercent2, 0);
		}

		// Token: 0x06005457 RID: 21591 RVA: 0x00102C56 File Offset: 0x00101056
		public static void AddProtectGroundPercent(FlatBufferBuilder builder, int ProtectGroundPercent)
		{
			builder.AddInt(101, ProtectGroundPercent, 0);
		}

		// Token: 0x06005458 RID: 21592 RVA: 0x00102C62 File Offset: 0x00101062
		public static void AddProtectStandPercent(FlatBufferBuilder builder, int ProtectStandPercent)
		{
			builder.AddInt(102, ProtectStandPercent, 0);
		}

		// Token: 0x06005459 RID: 21593 RVA: 0x00102C6E File Offset: 0x0010106E
		public static void AddBornAI(FlatBufferBuilder builder, UnitTable_Level.eBornAI BornAI)
		{
			builder.AddInt(103, (int)BornAI, 0);
		}

		// Token: 0x0600545A RID: 21594 RVA: 0x00102C7A File Offset: 0x0010107A
		public static void AddAICombatType(FlatBufferBuilder builder, int AICombatType)
		{
			builder.AddInt(104, AICombatType, 0);
		}

		// Token: 0x0600545B RID: 21595 RVA: 0x00102C86 File Offset: 0x00101086
		public static void AddAITargetType(FlatBufferBuilder builder, VectorOffset AITargetTypeOffset)
		{
			builder.AddOffset(105, AITargetTypeOffset.Value, 0);
		}

		// Token: 0x0600545C RID: 21596 RVA: 0x00102C98 File Offset: 0x00101098
		public static VectorOffset CreateAITargetTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600545D RID: 21597 RVA: 0x00102CD5 File Offset: 0x001010D5
		public static void StartAITargetTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600545E RID: 21598 RVA: 0x00102CE0 File Offset: 0x001010E0
		public static void AddAISight(FlatBufferBuilder builder, int AISight)
		{
			builder.AddInt(106, AISight, 0);
		}

		// Token: 0x0600545F RID: 21599 RVA: 0x00102CEC File Offset: 0x001010EC
		public static void AddAIChase(FlatBufferBuilder builder, int AIChase)
		{
			builder.AddInt(107, AIChase, 0);
		}

		// Token: 0x06005460 RID: 21600 RVA: 0x00102CF8 File Offset: 0x001010F8
		public static void AddAIWarlike(FlatBufferBuilder builder, int AIWarlike)
		{
			builder.AddInt(108, AIWarlike, 0);
		}

		// Token: 0x06005461 RID: 21601 RVA: 0x00102D04 File Offset: 0x00101104
		public static void AddAIFollowDistance(FlatBufferBuilder builder, int AIFollowDistance)
		{
			builder.AddInt(109, AIFollowDistance, 0);
		}

		// Token: 0x06005462 RID: 21602 RVA: 0x00102D10 File Offset: 0x00101110
		public static void AddAIKeepDistance(FlatBufferBuilder builder, int AIKeepDistance)
		{
			builder.AddInt(110, AIKeepDistance, 0);
		}

		// Token: 0x06005463 RID: 21603 RVA: 0x00102D1C File Offset: 0x0010111C
		public static void AddAIAttackDelay(FlatBufferBuilder builder, int AIAttackDelay)
		{
			builder.AddInt(111, AIAttackDelay, 0);
		}

		// Token: 0x06005464 RID: 21604 RVA: 0x00102D28 File Offset: 0x00101128
		public static void AddAIDestinationChangeTerm(FlatBufferBuilder builder, int AIDestinationChangeTerm)
		{
			builder.AddInt(112, AIDestinationChangeTerm, 0);
		}

		// Token: 0x06005465 RID: 21605 RVA: 0x00102D34 File Offset: 0x00101134
		public static void AddAIThinkTargetTerm(FlatBufferBuilder builder, int AIThinkTargetTerm)
		{
			builder.AddInt(113, AIThinkTargetTerm, 0);
		}

		// Token: 0x06005466 RID: 21606 RVA: 0x00102D40 File Offset: 0x00101140
		public static void AddAIAttackKind(FlatBufferBuilder builder, VectorOffset AIAttackKindOffset)
		{
			builder.AddOffset(114, AIAttackKindOffset.Value, 0);
		}

		// Token: 0x06005467 RID: 21607 RVA: 0x00102D54 File Offset: 0x00101154
		public static VectorOffset CreateAIAttackKindVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06005468 RID: 21608 RVA: 0x00102D9A File Offset: 0x0010119A
		public static void StartAIAttackKindVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005469 RID: 21609 RVA: 0x00102DA5 File Offset: 0x001011A5
		public static void AddAIIdleMode(FlatBufferBuilder builder, int AIIdleMode)
		{
			builder.AddInt(115, AIIdleMode, 0);
		}

		// Token: 0x0600546A RID: 21610 RVA: 0x00102DB1 File Offset: 0x001011B1
		public static void AddAIIsAPC(FlatBufferBuilder builder, int AIIsAPC)
		{
			builder.AddInt(116, AIIsAPC, 0);
		}

		// Token: 0x0600546B RID: 21611 RVA: 0x00102DBD File Offset: 0x001011BD
		public static void AddAIIdleRand(FlatBufferBuilder builder, int AIIdleRand)
		{
			builder.AddInt(117, AIIdleRand, 0);
		}

		// Token: 0x0600546C RID: 21612 RVA: 0x00102DC9 File Offset: 0x001011C9
		public static void AddAIIdleDuration(FlatBufferBuilder builder, int AIIdleDuration)
		{
			builder.AddInt(118, AIIdleDuration, 0);
		}

		// Token: 0x0600546D RID: 21613 RVA: 0x00102DD5 File Offset: 0x001011D5
		public static void AddAIEscapeRand(FlatBufferBuilder builder, int AIEscapeRand)
		{
			builder.AddInt(119, AIEscapeRand, 0);
		}

		// Token: 0x0600546E RID: 21614 RVA: 0x00102DE1 File Offset: 0x001011E1
		public static void AddAIWanderRand(FlatBufferBuilder builder, int AIWanderRand)
		{
			builder.AddInt(120, AIWanderRand, 0);
		}

		// Token: 0x0600546F RID: 21615 RVA: 0x00102DED File Offset: 0x001011ED
		public static void AddAIWanderRange(FlatBufferBuilder builder, int AIWanderRange)
		{
			builder.AddInt(121, AIWanderRange, 0);
		}

		// Token: 0x06005470 RID: 21616 RVA: 0x00102DF9 File Offset: 0x001011F9
		public static void AddAIWalkBackRange(FlatBufferBuilder builder, int AIWalkBackRange)
		{
			builder.AddInt(122, AIWalkBackRange, 0);
		}

		// Token: 0x06005471 RID: 21617 RVA: 0x00102E05 File Offset: 0x00101205
		public static void AddAIYFirstRand(FlatBufferBuilder builder, int AIYFirstRand)
		{
			builder.AddInt(123, AIYFirstRand, 0);
		}

		// Token: 0x06005472 RID: 21618 RVA: 0x00102E11 File Offset: 0x00101211
		public static void AddAIMaxWalkCmdCount(FlatBufferBuilder builder, int AIMaxWalkCmdCount)
		{
			builder.AddInt(124, AIMaxWalkCmdCount, 0);
		}

		// Token: 0x06005473 RID: 21619 RVA: 0x00102E1D File Offset: 0x0010121D
		public static void AddAIMaxIdleCmdCount(FlatBufferBuilder builder, int AIMaxIdleCmdCount)
		{
			builder.AddInt(125, AIMaxIdleCmdCount, 0);
		}

		// Token: 0x06005474 RID: 21620 RVA: 0x00102E29 File Offset: 0x00101229
		public static void AddAIWeaponTag(FlatBufferBuilder builder, int AIWeaponTag)
		{
			builder.AddInt(126, AIWeaponTag, 0);
		}

		// Token: 0x06005475 RID: 21621 RVA: 0x00102E35 File Offset: 0x00101235
		public static void AddAPCIsSpecialConfig(FlatBufferBuilder builder, int APCIsSpecialConfig)
		{
			builder.AddInt(127, APCIsSpecialConfig, 0);
		}

		// Token: 0x06005476 RID: 21622 RVA: 0x00102E41 File Offset: 0x00101241
		public static void AddAPCWeaponRes(FlatBufferBuilder builder, int APCWeaponRes)
		{
			builder.AddInt(128, APCWeaponRes, 0);
		}

		// Token: 0x06005477 RID: 21623 RVA: 0x00102E50 File Offset: 0x00101250
		public static void AddAPCWeaponStrengthLevel(FlatBufferBuilder builder, int APCWeaponStrengthLevel)
		{
			builder.AddInt(129, APCWeaponStrengthLevel, 0);
		}

		// Token: 0x06005478 RID: 21624 RVA: 0x00102E5F File Offset: 0x0010125F
		public static void AddAIActionPath(FlatBufferBuilder builder, StringOffset AIActionPathOffset)
		{
			builder.AddOffset(130, AIActionPathOffset.Value, 0);
		}

		// Token: 0x06005479 RID: 21625 RVA: 0x00102E74 File Offset: 0x00101274
		public static void AddAIDestinationSelectPath(FlatBufferBuilder builder, StringOffset AIDestinationSelectPathOffset)
		{
			builder.AddOffset(131, AIDestinationSelectPathOffset.Value, 0);
		}

		// Token: 0x0600547A RID: 21626 RVA: 0x00102E89 File Offset: 0x00101289
		public static void AddAIEventPath(FlatBufferBuilder builder, StringOffset AIEventPathOffset)
		{
			builder.AddOffset(132, AIEventPathOffset.Value, 0);
		}

		// Token: 0x0600547B RID: 21627 RVA: 0x00102E9E File Offset: 0x0010129E
		public static void AddAttackInModelStage(FlatBufferBuilder builder, VectorOffset AttackInModelStageOffset)
		{
			builder.AddOffset(133, AttackInModelStageOffset.Value, 0);
		}

		// Token: 0x0600547C RID: 21628 RVA: 0x00102EB4 File Offset: 0x001012B4
		public static VectorOffset CreateAttackInModelStageVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600547D RID: 21629 RVA: 0x00102EFA File Offset: 0x001012FA
		public static void StartAttackInModelStageVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600547E RID: 21630 RVA: 0x00102F08 File Offset: 0x00101308
		public static Offset<UnitTable_Level> EndUnitTable_Level(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<UnitTable_Level>(value);
		}

		// Token: 0x0600547F RID: 21631 RVA: 0x00102F22 File Offset: 0x00101322
		public static void FinishUnitTable_LevelBuffer(FlatBufferBuilder builder, Offset<UnitTable_Level> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E47 RID: 7751
		private Table __p = new Table();

		// Token: 0x04001E48 RID: 7752
		private FlatBufferArray<int> SkillIDsValue;

		// Token: 0x04001E49 RID: 7753
		private FlatBufferArray<int> WalkSpeechValue;

		// Token: 0x04001E4A RID: 7754
		private FlatBufferArray<int> AttackSpeechValue;

		// Token: 0x04001E4B RID: 7755
		private FlatBufferArray<int> BirthSpeechValue;

		// Token: 0x04001E4C RID: 7756
		private FlatBufferArray<int> AbilityChangeValue;

		// Token: 0x04001E4D RID: 7757
		private FlatBufferArray<int> BornBuffValue;

		// Token: 0x04001E4E RID: 7758
		private FlatBufferArray<int> BornBuff2Value;

		// Token: 0x04001E4F RID: 7759
		private FlatBufferArray<int> BornMechanismValue;

		// Token: 0x04001E50 RID: 7760
		private FlatBufferArray<int> ElementsValue;

		// Token: 0x04001E51 RID: 7761
		private FlatBufferArray<int> AITargetTypeValue;

		// Token: 0x04001E52 RID: 7762
		private FlatBufferArray<string> AIAttackKindValue;

		// Token: 0x04001E53 RID: 7763
		private FlatBufferArray<string> AttackInModelStageValue;

		// Token: 0x02000613 RID: 1555
		public enum eType
		{
			// Token: 0x04001E55 RID: 7765
			HERO,
			// Token: 0x04001E56 RID: 7766
			MONSTER,
			// Token: 0x04001E57 RID: 7767
			ELITE,
			// Token: 0x04001E58 RID: 7768
			BOSS,
			// Token: 0x04001E59 RID: 7769
			NPC,
			// Token: 0x04001E5A RID: 7770
			HELL,
			// Token: 0x04001E5B RID: 7771
			ACTIVITYMONSTER,
			// Token: 0x04001E5C RID: 7772
			ACCOMPANY,
			// Token: 0x04001E5D RID: 7773
			SKILL_MONSTER,
			// Token: 0x04001E5E RID: 7774
			EGG,
			// Token: 0x04001E5F RID: 7775
			ZHS
		}

		// Token: 0x02000614 RID: 1556
		public enum eCamp
		{
			// Token: 0x04001E61 RID: 7777
			C_HERO,
			// Token: 0x04001E62 RID: 7778
			C_ENEMY,
			// Token: 0x04001E63 RID: 7779
			C_ENEMY2
		}

		// Token: 0x02000615 RID: 1557
		public enum eMonsterRace
		{
			// Token: 0x04001E65 RID: 7781
			NONE,
			// Token: 0x04001E66 RID: 7782
			EVIL,
			// Token: 0x04001E67 RID: 7783
			UNDEAD,
			// Token: 0x04001E68 RID: 7784
			ELF,
			// Token: 0x04001E69 RID: 7785
			HUMAN,
			// Token: 0x04001E6A RID: 7786
			HOMINIS,
			// Token: 0x04001E6B RID: 7787
			PUPPET,
			// Token: 0x04001E6C RID: 7788
			MACHINE
		}

		// Token: 0x02000616 RID: 1558
		public enum eBornAI
		{
			// Token: 0x04001E6E RID: 7790
			Start,
			// Token: 0x04001E6F RID: 7791
			None
		}

		// Token: 0x02000617 RID: 1559
		public enum eCrypt
		{
			// Token: 0x04001E71 RID: 7793
			code = -601822511
		}
	}
}
