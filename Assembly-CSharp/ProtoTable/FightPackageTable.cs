using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200043D RID: 1085
	public class FightPackageTable : IFlatbufferObject
	{
		// Token: 0x17000CA5 RID: 3237
		// (get) Token: 0x06003394 RID: 13204 RVA: 0x000B4D70 File Offset: 0x000B3170
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003395 RID: 13205 RVA: 0x000B4D7D File Offset: 0x000B317D
		public static FightPackageTable GetRootAsFightPackageTable(ByteBuffer _bb)
		{
			return FightPackageTable.GetRootAsFightPackageTable(_bb, new FightPackageTable());
		}

		// Token: 0x06003396 RID: 13206 RVA: 0x000B4D8A File Offset: 0x000B318A
		public static FightPackageTable GetRootAsFightPackageTable(ByteBuffer _bb, FightPackageTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003397 RID: 13207 RVA: 0x000B4DA6 File Offset: 0x000B31A6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003398 RID: 13208 RVA: 0x000B4DC0 File Offset: 0x000B31C0
		public FightPackageTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000CA6 RID: 3238
		// (get) Token: 0x06003399 RID: 13209 RVA: 0x000B4DCC File Offset: 0x000B31CC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CA7 RID: 3239
		// (get) Token: 0x0600339A RID: 13210 RVA: 0x000B4E18 File Offset: 0x000B3218
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600339B RID: 13211 RVA: 0x000B4E5A File Offset: 0x000B325A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000CA8 RID: 3240
		// (get) Token: 0x0600339C RID: 13212 RVA: 0x000B4E68 File Offset: 0x000B3268
		public int Power
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CA9 RID: 3241
		// (get) Token: 0x0600339D RID: 13213 RVA: 0x000B4EB4 File Offset: 0x000B32B4
		public int Intellect
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CAA RID: 3242
		// (get) Token: 0x0600339E RID: 13214 RVA: 0x000B4F00 File Offset: 0x000B3300
		public int Streangth
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CAB RID: 3243
		// (get) Token: 0x0600339F RID: 13215 RVA: 0x000B4F4C File Offset: 0x000B334C
		public int Spirit
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CAC RID: 3244
		// (get) Token: 0x060033A0 RID: 13216 RVA: 0x000B4F98 File Offset: 0x000B3398
		public int HP
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CAD RID: 3245
		// (get) Token: 0x060033A1 RID: 13217 RVA: 0x000B4FE4 File Offset: 0x000B33E4
		public int MP
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CAE RID: 3246
		// (get) Token: 0x060033A2 RID: 13218 RVA: 0x000B5030 File Offset: 0x000B3430
		public int HPRecover
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CAF RID: 3247
		// (get) Token: 0x060033A3 RID: 13219 RVA: 0x000B507C File Offset: 0x000B347C
		public int MPRecover
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB0 RID: 3248
		// (get) Token: 0x060033A4 RID: 13220 RVA: 0x000B50C8 File Offset: 0x000B34C8
		public int PhysicAttack
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB1 RID: 3249
		// (get) Token: 0x060033A5 RID: 13221 RVA: 0x000B5114 File Offset: 0x000B3514
		public int MagicAttack
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB2 RID: 3250
		// (get) Token: 0x060033A6 RID: 13222 RVA: 0x000B5160 File Offset: 0x000B3560
		public int PhysicDefence
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB3 RID: 3251
		// (get) Token: 0x060033A7 RID: 13223 RVA: 0x000B51AC File Offset: 0x000B35AC
		public int MagicDefence
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB4 RID: 3252
		// (get) Token: 0x060033A8 RID: 13224 RVA: 0x000B51F8 File Offset: 0x000B35F8
		public int AttackSpeed
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB5 RID: 3253
		// (get) Token: 0x060033A9 RID: 13225 RVA: 0x000B5244 File Offset: 0x000B3644
		public int SpellSpeed
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB6 RID: 3254
		// (get) Token: 0x060033AA RID: 13226 RVA: 0x000B5290 File Offset: 0x000B3690
		public int MoveSpeed
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB7 RID: 3255
		// (get) Token: 0x060033AB RID: 13227 RVA: 0x000B52DC File Offset: 0x000B36DC
		public int PhysicalCritical
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB8 RID: 3256
		// (get) Token: 0x060033AC RID: 13228 RVA: 0x000B5328 File Offset: 0x000B3728
		public int MagicCritical
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CB9 RID: 3257
		// (get) Token: 0x060033AD RID: 13229 RVA: 0x000B5374 File Offset: 0x000B3774
		public int HitRate
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CBA RID: 3258
		// (get) Token: 0x060033AE RID: 13230 RVA: 0x000B53C0 File Offset: 0x000B37C0
		public int MissRate
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CBB RID: 3259
		// (get) Token: 0x060033AF RID: 13231 RVA: 0x000B540C File Offset: 0x000B380C
		public int StarkValue
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CBC RID: 3260
		// (get) Token: 0x060033B0 RID: 13232 RVA: 0x000B5458 File Offset: 0x000B3858
		public int HardValue
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CBD RID: 3261
		// (get) Token: 0x060033B1 RID: 13233 RVA: 0x000B54A4 File Offset: 0x000B38A4
		public int LightAttack
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CBE RID: 3262
		// (get) Token: 0x060033B2 RID: 13234 RVA: 0x000B54F0 File Offset: 0x000B38F0
		public int FireAttack
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CBF RID: 3263
		// (get) Token: 0x060033B3 RID: 13235 RVA: 0x000B553C File Offset: 0x000B393C
		public int IceAttack
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CC0 RID: 3264
		// (get) Token: 0x060033B4 RID: 13236 RVA: 0x000B5588 File Offset: 0x000B3988
		public int DarkAttack
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CC1 RID: 3265
		// (get) Token: 0x060033B5 RID: 13237 RVA: 0x000B55D4 File Offset: 0x000B39D4
		public int LightDefence
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CC2 RID: 3266
		// (get) Token: 0x060033B6 RID: 13238 RVA: 0x000B5620 File Offset: 0x000B3A20
		public int FireDefence
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CC3 RID: 3267
		// (get) Token: 0x060033B7 RID: 13239 RVA: 0x000B566C File Offset: 0x000B3A6C
		public int IceDefence
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CC4 RID: 3268
		// (get) Token: 0x060033B8 RID: 13240 RVA: 0x000B56B8 File Offset: 0x000B3AB8
		public int DarkDefence
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CC5 RID: 3269
		// (get) Token: 0x060033B9 RID: 13241 RVA: 0x000B5704 File Offset: 0x000B3B04
		public int AbormalResist
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060033BA RID: 13242 RVA: 0x000B5750 File Offset: 0x000B3B50
		public string AbormalResistsArray(int j)
		{
			int num = this.__p.__offset(68);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000CC6 RID: 3270
		// (get) Token: 0x060033BB RID: 13243 RVA: 0x000B5798 File Offset: 0x000B3B98
		public int AbormalResistsLength
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000CC7 RID: 3271
		// (get) Token: 0x060033BC RID: 13244 RVA: 0x000B57CB File Offset: 0x000B3BCB
		public FlatBufferArray<string> AbormalResists
		{
			get
			{
				if (this.AbormalResistsValue == null)
				{
					this.AbormalResistsValue = new FlatBufferArray<string>(new Func<int, string>(this.AbormalResistsArray), this.AbormalResistsLength);
				}
				return this.AbormalResistsValue;
			}
		}

		// Token: 0x17000CC8 RID: 3272
		// (get) Token: 0x060033BD RID: 13245 RVA: 0x000B57FC File Offset: 0x000B3BFC
		public int Cold
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CC9 RID: 3273
		// (get) Token: 0x060033BE RID: 13246 RVA: 0x000B5848 File Offset: 0x000B3C48
		public int HPLevel
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CCA RID: 3274
		// (get) Token: 0x060033BF RID: 13247 RVA: 0x000B5894 File Offset: 0x000B3C94
		public int MPLevel
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CCB RID: 3275
		// (get) Token: 0x060033C0 RID: 13248 RVA: 0x000B58E0 File Offset: 0x000B3CE0
		public int PowerLevel
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CCC RID: 3276
		// (get) Token: 0x060033C1 RID: 13249 RVA: 0x000B592C File Offset: 0x000B3D2C
		public int IntellectLevel
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CCD RID: 3277
		// (get) Token: 0x060033C2 RID: 13250 RVA: 0x000B5978 File Offset: 0x000B3D78
		public int StrengthLevel
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CCE RID: 3278
		// (get) Token: 0x060033C3 RID: 13251 RVA: 0x000B59C4 File Offset: 0x000B3DC4
		public int SpiritLevel
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CCF RID: 3279
		// (get) Token: 0x060033C4 RID: 13252 RVA: 0x000B5A10 File Offset: 0x000B3E10
		public int MPRecoverLevel
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CD0 RID: 3280
		// (get) Token: 0x060033C5 RID: 13253 RVA: 0x000B5A5C File Offset: 0x000B3E5C
		public int HardValueLevel
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CD1 RID: 3281
		// (get) Token: 0x060033C6 RID: 13254 RVA: 0x000B5AA8 File Offset: 0x000B3EA8
		public int TransformAttirbuleAdd
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : (1532815736 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060033C7 RID: 13255 RVA: 0x000B5AF4 File Offset: 0x000B3EF4
		public static Offset<FightPackageTable> CreateFightPackageTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int Power = 0, int Intellect = 0, int Streangth = 0, int Spirit = 0, int HP = 0, int MP = 0, int HPRecover = 0, int MPRecover = 0, int PhysicAttack = 0, int MagicAttack = 0, int PhysicDefence = 0, int MagicDefence = 0, int AttackSpeed = 0, int SpellSpeed = 0, int MoveSpeed = 0, int PhysicalCritical = 0, int MagicCritical = 0, int HitRate = 0, int MissRate = 0, int StarkValue = 0, int HardValue = 0, int LightAttack = 0, int FireAttack = 0, int IceAttack = 0, int DarkAttack = 0, int LightDefence = 0, int FireDefence = 0, int IceDefence = 0, int DarkDefence = 0, int AbormalResist = 0, VectorOffset AbormalResistsOffset = default(VectorOffset), int Cold = 0, int HPLevel = 0, int MPLevel = 0, int PowerLevel = 0, int IntellectLevel = 0, int StrengthLevel = 0, int SpiritLevel = 0, int MPRecoverLevel = 0, int HardValueLevel = 0, int TransformAttirbuleAdd = 0)
		{
			builder.StartObject(43);
			FightPackageTable.AddTransformAttirbuleAdd(builder, TransformAttirbuleAdd);
			FightPackageTable.AddHardValueLevel(builder, HardValueLevel);
			FightPackageTable.AddMPRecoverLevel(builder, MPRecoverLevel);
			FightPackageTable.AddSpiritLevel(builder, SpiritLevel);
			FightPackageTable.AddStrengthLevel(builder, StrengthLevel);
			FightPackageTable.AddIntellectLevel(builder, IntellectLevel);
			FightPackageTable.AddPowerLevel(builder, PowerLevel);
			FightPackageTable.AddMPLevel(builder, MPLevel);
			FightPackageTable.AddHPLevel(builder, HPLevel);
			FightPackageTable.AddCold(builder, Cold);
			FightPackageTable.AddAbormalResists(builder, AbormalResistsOffset);
			FightPackageTable.AddAbormalResist(builder, AbormalResist);
			FightPackageTable.AddDarkDefence(builder, DarkDefence);
			FightPackageTable.AddIceDefence(builder, IceDefence);
			FightPackageTable.AddFireDefence(builder, FireDefence);
			FightPackageTable.AddLightDefence(builder, LightDefence);
			FightPackageTable.AddDarkAttack(builder, DarkAttack);
			FightPackageTable.AddIceAttack(builder, IceAttack);
			FightPackageTable.AddFireAttack(builder, FireAttack);
			FightPackageTable.AddLightAttack(builder, LightAttack);
			FightPackageTable.AddHardValue(builder, HardValue);
			FightPackageTable.AddStarkValue(builder, StarkValue);
			FightPackageTable.AddMissRate(builder, MissRate);
			FightPackageTable.AddHitRate(builder, HitRate);
			FightPackageTable.AddMagicCritical(builder, MagicCritical);
			FightPackageTable.AddPhysicalCritical(builder, PhysicalCritical);
			FightPackageTable.AddMoveSpeed(builder, MoveSpeed);
			FightPackageTable.AddSpellSpeed(builder, SpellSpeed);
			FightPackageTable.AddAttackSpeed(builder, AttackSpeed);
			FightPackageTable.AddMagicDefence(builder, MagicDefence);
			FightPackageTable.AddPhysicDefence(builder, PhysicDefence);
			FightPackageTable.AddMagicAttack(builder, MagicAttack);
			FightPackageTable.AddPhysicAttack(builder, PhysicAttack);
			FightPackageTable.AddMPRecover(builder, MPRecover);
			FightPackageTable.AddHPRecover(builder, HPRecover);
			FightPackageTable.AddMP(builder, MP);
			FightPackageTable.AddHP(builder, HP);
			FightPackageTable.AddSpirit(builder, Spirit);
			FightPackageTable.AddStreangth(builder, Streangth);
			FightPackageTable.AddIntellect(builder, Intellect);
			FightPackageTable.AddPower(builder, Power);
			FightPackageTable.AddName(builder, NameOffset);
			FightPackageTable.AddID(builder, ID);
			return FightPackageTable.EndFightPackageTable(builder);
		}

		// Token: 0x060033C8 RID: 13256 RVA: 0x000B5C64 File Offset: 0x000B4064
		public static void StartFightPackageTable(FlatBufferBuilder builder)
		{
			builder.StartObject(43);
		}

		// Token: 0x060033C9 RID: 13257 RVA: 0x000B5C6E File Offset: 0x000B406E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060033CA RID: 13258 RVA: 0x000B5C79 File Offset: 0x000B4079
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060033CB RID: 13259 RVA: 0x000B5C8A File Offset: 0x000B408A
		public static void AddPower(FlatBufferBuilder builder, int Power)
		{
			builder.AddInt(2, Power, 0);
		}

		// Token: 0x060033CC RID: 13260 RVA: 0x000B5C95 File Offset: 0x000B4095
		public static void AddIntellect(FlatBufferBuilder builder, int Intellect)
		{
			builder.AddInt(3, Intellect, 0);
		}

		// Token: 0x060033CD RID: 13261 RVA: 0x000B5CA0 File Offset: 0x000B40A0
		public static void AddStreangth(FlatBufferBuilder builder, int Streangth)
		{
			builder.AddInt(4, Streangth, 0);
		}

		// Token: 0x060033CE RID: 13262 RVA: 0x000B5CAB File Offset: 0x000B40AB
		public static void AddSpirit(FlatBufferBuilder builder, int Spirit)
		{
			builder.AddInt(5, Spirit, 0);
		}

		// Token: 0x060033CF RID: 13263 RVA: 0x000B5CB6 File Offset: 0x000B40B6
		public static void AddHP(FlatBufferBuilder builder, int HP)
		{
			builder.AddInt(6, HP, 0);
		}

		// Token: 0x060033D0 RID: 13264 RVA: 0x000B5CC1 File Offset: 0x000B40C1
		public static void AddMP(FlatBufferBuilder builder, int MP)
		{
			builder.AddInt(7, MP, 0);
		}

		// Token: 0x060033D1 RID: 13265 RVA: 0x000B5CCC File Offset: 0x000B40CC
		public static void AddHPRecover(FlatBufferBuilder builder, int HPRecover)
		{
			builder.AddInt(8, HPRecover, 0);
		}

		// Token: 0x060033D2 RID: 13266 RVA: 0x000B5CD7 File Offset: 0x000B40D7
		public static void AddMPRecover(FlatBufferBuilder builder, int MPRecover)
		{
			builder.AddInt(9, MPRecover, 0);
		}

		// Token: 0x060033D3 RID: 13267 RVA: 0x000B5CE3 File Offset: 0x000B40E3
		public static void AddPhysicAttack(FlatBufferBuilder builder, int PhysicAttack)
		{
			builder.AddInt(10, PhysicAttack, 0);
		}

		// Token: 0x060033D4 RID: 13268 RVA: 0x000B5CEF File Offset: 0x000B40EF
		public static void AddMagicAttack(FlatBufferBuilder builder, int MagicAttack)
		{
			builder.AddInt(11, MagicAttack, 0);
		}

		// Token: 0x060033D5 RID: 13269 RVA: 0x000B5CFB File Offset: 0x000B40FB
		public static void AddPhysicDefence(FlatBufferBuilder builder, int PhysicDefence)
		{
			builder.AddInt(12, PhysicDefence, 0);
		}

		// Token: 0x060033D6 RID: 13270 RVA: 0x000B5D07 File Offset: 0x000B4107
		public static void AddMagicDefence(FlatBufferBuilder builder, int MagicDefence)
		{
			builder.AddInt(13, MagicDefence, 0);
		}

		// Token: 0x060033D7 RID: 13271 RVA: 0x000B5D13 File Offset: 0x000B4113
		public static void AddAttackSpeed(FlatBufferBuilder builder, int AttackSpeed)
		{
			builder.AddInt(14, AttackSpeed, 0);
		}

		// Token: 0x060033D8 RID: 13272 RVA: 0x000B5D1F File Offset: 0x000B411F
		public static void AddSpellSpeed(FlatBufferBuilder builder, int SpellSpeed)
		{
			builder.AddInt(15, SpellSpeed, 0);
		}

		// Token: 0x060033D9 RID: 13273 RVA: 0x000B5D2B File Offset: 0x000B412B
		public static void AddMoveSpeed(FlatBufferBuilder builder, int MoveSpeed)
		{
			builder.AddInt(16, MoveSpeed, 0);
		}

		// Token: 0x060033DA RID: 13274 RVA: 0x000B5D37 File Offset: 0x000B4137
		public static void AddPhysicalCritical(FlatBufferBuilder builder, int PhysicalCritical)
		{
			builder.AddInt(17, PhysicalCritical, 0);
		}

		// Token: 0x060033DB RID: 13275 RVA: 0x000B5D43 File Offset: 0x000B4143
		public static void AddMagicCritical(FlatBufferBuilder builder, int MagicCritical)
		{
			builder.AddInt(18, MagicCritical, 0);
		}

		// Token: 0x060033DC RID: 13276 RVA: 0x000B5D4F File Offset: 0x000B414F
		public static void AddHitRate(FlatBufferBuilder builder, int HitRate)
		{
			builder.AddInt(19, HitRate, 0);
		}

		// Token: 0x060033DD RID: 13277 RVA: 0x000B5D5B File Offset: 0x000B415B
		public static void AddMissRate(FlatBufferBuilder builder, int MissRate)
		{
			builder.AddInt(20, MissRate, 0);
		}

		// Token: 0x060033DE RID: 13278 RVA: 0x000B5D67 File Offset: 0x000B4167
		public static void AddStarkValue(FlatBufferBuilder builder, int StarkValue)
		{
			builder.AddInt(21, StarkValue, 0);
		}

		// Token: 0x060033DF RID: 13279 RVA: 0x000B5D73 File Offset: 0x000B4173
		public static void AddHardValue(FlatBufferBuilder builder, int HardValue)
		{
			builder.AddInt(22, HardValue, 0);
		}

		// Token: 0x060033E0 RID: 13280 RVA: 0x000B5D7F File Offset: 0x000B417F
		public static void AddLightAttack(FlatBufferBuilder builder, int LightAttack)
		{
			builder.AddInt(23, LightAttack, 0);
		}

		// Token: 0x060033E1 RID: 13281 RVA: 0x000B5D8B File Offset: 0x000B418B
		public static void AddFireAttack(FlatBufferBuilder builder, int FireAttack)
		{
			builder.AddInt(24, FireAttack, 0);
		}

		// Token: 0x060033E2 RID: 13282 RVA: 0x000B5D97 File Offset: 0x000B4197
		public static void AddIceAttack(FlatBufferBuilder builder, int IceAttack)
		{
			builder.AddInt(25, IceAttack, 0);
		}

		// Token: 0x060033E3 RID: 13283 RVA: 0x000B5DA3 File Offset: 0x000B41A3
		public static void AddDarkAttack(FlatBufferBuilder builder, int DarkAttack)
		{
			builder.AddInt(26, DarkAttack, 0);
		}

		// Token: 0x060033E4 RID: 13284 RVA: 0x000B5DAF File Offset: 0x000B41AF
		public static void AddLightDefence(FlatBufferBuilder builder, int LightDefence)
		{
			builder.AddInt(27, LightDefence, 0);
		}

		// Token: 0x060033E5 RID: 13285 RVA: 0x000B5DBB File Offset: 0x000B41BB
		public static void AddFireDefence(FlatBufferBuilder builder, int FireDefence)
		{
			builder.AddInt(28, FireDefence, 0);
		}

		// Token: 0x060033E6 RID: 13286 RVA: 0x000B5DC7 File Offset: 0x000B41C7
		public static void AddIceDefence(FlatBufferBuilder builder, int IceDefence)
		{
			builder.AddInt(29, IceDefence, 0);
		}

		// Token: 0x060033E7 RID: 13287 RVA: 0x000B5DD3 File Offset: 0x000B41D3
		public static void AddDarkDefence(FlatBufferBuilder builder, int DarkDefence)
		{
			builder.AddInt(30, DarkDefence, 0);
		}

		// Token: 0x060033E8 RID: 13288 RVA: 0x000B5DDF File Offset: 0x000B41DF
		public static void AddAbormalResist(FlatBufferBuilder builder, int AbormalResist)
		{
			builder.AddInt(31, AbormalResist, 0);
		}

		// Token: 0x060033E9 RID: 13289 RVA: 0x000B5DEB File Offset: 0x000B41EB
		public static void AddAbormalResists(FlatBufferBuilder builder, VectorOffset AbormalResistsOffset)
		{
			builder.AddOffset(32, AbormalResistsOffset.Value, 0);
		}

		// Token: 0x060033EA RID: 13290 RVA: 0x000B5E00 File Offset: 0x000B4200
		public static VectorOffset CreateAbormalResistsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060033EB RID: 13291 RVA: 0x000B5E46 File Offset: 0x000B4246
		public static void StartAbormalResistsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060033EC RID: 13292 RVA: 0x000B5E51 File Offset: 0x000B4251
		public static void AddCold(FlatBufferBuilder builder, int Cold)
		{
			builder.AddInt(33, Cold, 0);
		}

		// Token: 0x060033ED RID: 13293 RVA: 0x000B5E5D File Offset: 0x000B425D
		public static void AddHPLevel(FlatBufferBuilder builder, int HPLevel)
		{
			builder.AddInt(34, HPLevel, 0);
		}

		// Token: 0x060033EE RID: 13294 RVA: 0x000B5E69 File Offset: 0x000B4269
		public static void AddMPLevel(FlatBufferBuilder builder, int MPLevel)
		{
			builder.AddInt(35, MPLevel, 0);
		}

		// Token: 0x060033EF RID: 13295 RVA: 0x000B5E75 File Offset: 0x000B4275
		public static void AddPowerLevel(FlatBufferBuilder builder, int PowerLevel)
		{
			builder.AddInt(36, PowerLevel, 0);
		}

		// Token: 0x060033F0 RID: 13296 RVA: 0x000B5E81 File Offset: 0x000B4281
		public static void AddIntellectLevel(FlatBufferBuilder builder, int IntellectLevel)
		{
			builder.AddInt(37, IntellectLevel, 0);
		}

		// Token: 0x060033F1 RID: 13297 RVA: 0x000B5E8D File Offset: 0x000B428D
		public static void AddStrengthLevel(FlatBufferBuilder builder, int StrengthLevel)
		{
			builder.AddInt(38, StrengthLevel, 0);
		}

		// Token: 0x060033F2 RID: 13298 RVA: 0x000B5E99 File Offset: 0x000B4299
		public static void AddSpiritLevel(FlatBufferBuilder builder, int SpiritLevel)
		{
			builder.AddInt(39, SpiritLevel, 0);
		}

		// Token: 0x060033F3 RID: 13299 RVA: 0x000B5EA5 File Offset: 0x000B42A5
		public static void AddMPRecoverLevel(FlatBufferBuilder builder, int MPRecoverLevel)
		{
			builder.AddInt(40, MPRecoverLevel, 0);
		}

		// Token: 0x060033F4 RID: 13300 RVA: 0x000B5EB1 File Offset: 0x000B42B1
		public static void AddHardValueLevel(FlatBufferBuilder builder, int HardValueLevel)
		{
			builder.AddInt(41, HardValueLevel, 0);
		}

		// Token: 0x060033F5 RID: 13301 RVA: 0x000B5EBD File Offset: 0x000B42BD
		public static void AddTransformAttirbuleAdd(FlatBufferBuilder builder, int TransformAttirbuleAdd)
		{
			builder.AddInt(42, TransformAttirbuleAdd, 0);
		}

		// Token: 0x060033F6 RID: 13302 RVA: 0x000B5ECC File Offset: 0x000B42CC
		public static Offset<FightPackageTable> EndFightPackageTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FightPackageTable>(value);
		}

		// Token: 0x060033F7 RID: 13303 RVA: 0x000B5EE6 File Offset: 0x000B42E6
		public static void FinishFightPackageTableBuffer(FlatBufferBuilder builder, Offset<FightPackageTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001507 RID: 5383
		private Table __p = new Table();

		// Token: 0x04001508 RID: 5384
		private FlatBufferArray<string> AbormalResistsValue;

		// Token: 0x0200043E RID: 1086
		public enum eCrypt
		{
			// Token: 0x0400150A RID: 5386
			code = 1532815736
		}
	}
}
