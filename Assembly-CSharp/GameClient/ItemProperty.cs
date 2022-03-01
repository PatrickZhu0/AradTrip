using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020016CE RID: 5838
	public class ItemProperty
	{
		// Token: 0x0600E45C RID: 58460 RVA: 0x003B16A0 File Offset: 0x003AFAA0
		public void SaveTriggerBuffCDRemain(int buffInfoID, int cdRemain)
		{
			if (this.triggerBuffCDRemain == null)
			{
				this.triggerBuffCDRemain = new Dictionary<int, int>();
			}
			if (!this.triggerBuffCDRemain.ContainsKey(buffInfoID))
			{
				this.triggerBuffCDRemain.Add(buffInfoID, cdRemain);
			}
			else
			{
				this.triggerBuffCDRemain[buffInfoID] = cdRemain;
			}
		}

		// Token: 0x0600E45D RID: 58461 RVA: 0x003B16F4 File Offset: 0x003AFAF4
		public int GetTriggerBuffCDRemain(int buffInfoID)
		{
			if (this.triggerBuffCDRemain == null)
			{
				return 0;
			}
			if (this.triggerBuffCDRemain.ContainsKey(buffInfoID))
			{
				int result = this.triggerBuffCDRemain[buffInfoID];
				this.triggerBuffCDRemain.Remove(buffInfoID);
				return result;
			}
			return 0;
		}

		// Token: 0x0600E45E RID: 58462 RVA: 0x003B173C File Offset: 0x003AFB3C
		public void DebugPrint()
		{
			Utility.PrintType(typeof(ItemProperty), this);
		}

		// Token: 0x0600E45F RID: 58463 RVA: 0x003B1750 File Offset: 0x003AFB50
		public int GetValue(AttributeType attributeType)
		{
			int result = 0;
			switch (attributeType)
			{
			case AttributeType.maxHp:
				result = this.maxHp;
				break;
			case AttributeType.maxMp:
				result = this.maxMp;
				break;
			case AttributeType.hpRecover:
				result = this.hpRecover;
				break;
			case AttributeType.mpRecover:
				result = this.mpRecover;
				break;
			case AttributeType.attack:
				result = this.attack;
				break;
			case AttributeType.magicAttack:
				result = this.magicAttack;
				break;
			case AttributeType.defence:
				result = this.defence;
				break;
			case AttributeType.magicDefence:
				result = this.magicDefence;
				break;
			case AttributeType.attackSpeed:
				result = this.attackSpeed;
				break;
			case AttributeType.spellSpeed:
				result = this.spellSpeed;
				break;
			case AttributeType.moveSpeed:
				result = this.moveSpeed;
				break;
			case AttributeType.ciriticalAttack:
				result = this.ciriticalAttack;
				break;
			case AttributeType.ciriticalMagicAttack:
				result = this.ciriticalMagicAttack;
				break;
			case AttributeType.dex:
				result = this.dex;
				break;
			case AttributeType.dodge:
				result = this.dodge;
				break;
			case AttributeType.frozen:
				result = this.frozen;
				break;
			case AttributeType.hard:
				result = this.hard;
				break;
			case AttributeType.abnormalResist:
				result = this.abnormalResist;
				break;
			case AttributeType.cdReduceRate:
				result = this.cdReduceRate;
				break;
			case AttributeType.cdReduceRateMagic:
				result = this.cdReduceRateMagic;
				break;
			case AttributeType.mpCostReduceRate:
				result = this.mpCostReduceRate;
				break;
			case AttributeType.mpCostReduceRateMagic:
				result = this.mpCostReduceRateMagic;
				break;
			case AttributeType.attackAddRate:
				result = this.attackAddRate;
				break;
			case AttributeType.magicAttackAddRate:
				result = this.magicAttackAddRate;
				break;
			case AttributeType.ignoreDefAttackAdd:
				result = this.ignoreDefAttackAdd;
				break;
			case AttributeType.ignoreDefMagicAttackAdd:
				result = this.ignoreDefMagicAttackAdd;
				break;
			case AttributeType.attackReduceRate:
				result = this.attackReduceRate;
				break;
			case AttributeType.magicAttackReduceRate:
				result = this.magicAttackReduceRate;
				break;
			case AttributeType.attackReduceFix:
				result = this.attackReduceFix;
				break;
			case AttributeType.magicAttackReduceFix:
				result = this.magicAttackReduceFix;
				break;
			case AttributeType.baseAtk:
				result = this.baseAtk;
				break;
			case AttributeType.baseInt:
				result = this.baseInt;
				break;
			case AttributeType.baseSta:
				result = this.baseSta;
				break;
			case AttributeType.baseIndependence:
				result = this.independence;
				break;
			case AttributeType.baseSpr:
				result = this.baseSpr;
				break;
			case AttributeType.ingoreIndependence:
				result = this.ingoreIndependence;
				break;
			}
			return result;
		}

		// Token: 0x04008A06 RID: 35334
		public ulong guid;

		// Token: 0x04008A07 RID: 35335
		public CrypticInt32 itemID;

		// Token: 0x04008A08 RID: 35336
		public int strengthen;

		// Token: 0x04008A09 RID: 35337
		public int grid;

		// Token: 0x04008A0A RID: 35338
		public Dictionary<int, int> triggerBuffCDRemain;

		// Token: 0x04008A0B RID: 35339
		[EquipProp(EEquipProp.HPMax)]
		public CrypticInt32 maxHp;

		// Token: 0x04008A0C RID: 35340
		[EquipProp(EEquipProp.MPMax)]
		public CrypticInt32 maxMp;

		// Token: 0x04008A0D RID: 35341
		[EquipProp(EEquipProp.HPRecover)]
		public CrypticInt32 hpRecover;

		// Token: 0x04008A0E RID: 35342
		[EquipProp(EEquipProp.MPRecover)]
		public CrypticInt32 mpRecover;

		// Token: 0x04008A0F RID: 35343
		[EquipProp(EEquipProp.Stamina)]
		public CrypticInt32 baseSta;

		// Token: 0x04008A10 RID: 35344
		[EquipProp(EEquipProp.Strenth)]
		public CrypticInt32 baseAtk;

		// Token: 0x04008A11 RID: 35345
		[EquipProp(EEquipProp.Intellect)]
		public CrypticInt32 baseInt;

		// Token: 0x04008A12 RID: 35346
		[EquipProp(EEquipProp.Spirit)]
		public CrypticInt32 baseSpr;

		// Token: 0x04008A13 RID: 35347
		[EquipProp(EEquipProp.PhysicsAttack)]
		public CrypticInt32 attack;

		// Token: 0x04008A14 RID: 35348
		[EquipProp(EEquipProp.MagicAttack)]
		public CrypticInt32 magicAttack;

		// Token: 0x04008A15 RID: 35349
		[EquipProp(EEquipProp.PhysicsDefense)]
		public CrypticInt32 defence;

		// Token: 0x04008A16 RID: 35350
		[EquipProp(EEquipProp.MagicDefense)]
		public CrypticInt32 magicDefence;

		// Token: 0x04008A17 RID: 35351
		[EquipProp(EEquipProp.AttackSpeedRate)]
		public CrypticInt32 attackSpeed;

		// Token: 0x04008A18 RID: 35352
		[EquipProp(EEquipProp.FireSpeedRate)]
		public CrypticInt32 spellSpeed;

		// Token: 0x04008A19 RID: 35353
		[EquipProp(EEquipProp.MoveSpeedRate)]
		public CrypticInt32 moveSpeed;

		// Token: 0x04008A1A RID: 35354
		[EquipProp(EEquipProp.PhysicCritRate)]
		public CrypticInt32 ciriticalAttack;

		// Token: 0x04008A1B RID: 35355
		[EquipProp(EEquipProp.MagicCritRate)]
		public CrypticInt32 ciriticalMagicAttack;

		// Token: 0x04008A1C RID: 35356
		[EquipProp(EEquipProp.HitRate)]
		public CrypticInt32 dex;

		// Token: 0x04008A1D RID: 35357
		[EquipProp(EEquipProp.AvoidRate)]
		public CrypticInt32 dodge;

		// Token: 0x04008A1E RID: 35358
		public CrypticInt32 frozen;

		// Token: 0x04008A1F RID: 35359
		[EquipProp(EEquipProp.Spasticity)]
		public CrypticInt32 hard;

		// Token: 0x04008A20 RID: 35360
		[EquipProp(EEquipProp.AbormalResist)]
		public CrypticInt32 abnormalResist;

		// Token: 0x04008A21 RID: 35361
		[EquipProp(EEquipProp.Jump)]
		public CrypticInt32 jumpForce;

		// Token: 0x04008A22 RID: 35362
		[EquipProp(EEquipProp.PhysicsSkillMPChange)]
		public CrypticInt32 mpCostReduceRate;

		// Token: 0x04008A23 RID: 35363
		[EquipProp(EEquipProp.MagicSkillMPChange)]
		public CrypticInt32 mpCostReduceRateMagic;

		// Token: 0x04008A24 RID: 35364
		[EquipProp(EEquipProp.PhysicsSkillCDChange)]
		public CrypticInt32 cdReduceRate;

		// Token: 0x04008A25 RID: 35365
		[EquipProp(EEquipProp.MagicSkillCDChange)]
		public CrypticInt32 cdReduceRateMagic;

		// Token: 0x04008A26 RID: 35366
		[EquipProp(EEquipProp.IgnorePhysicsAttackRate)]
		public CrypticInt32 attackAddRate;

		// Token: 0x04008A27 RID: 35367
		[EquipProp(EEquipProp.IgnoreMagicAttackRate)]
		public CrypticInt32 magicAttackAddRate;

		// Token: 0x04008A28 RID: 35368
		[EquipProp(EEquipProp.IgnorePhysicsAttack)]
		public CrypticInt32 ignoreDefAttackAdd;

		// Token: 0x04008A29 RID: 35369
		[EquipProp(EEquipProp.IgnoreMagicAttack)]
		public CrypticInt32 ignoreDefMagicAttackAdd;

		// Token: 0x04008A2A RID: 35370
		[EquipProp(EEquipProp.IgnorePhysicsDefenseRate)]
		public CrypticInt32 attackReduceRate;

		// Token: 0x04008A2B RID: 35371
		[EquipProp(EEquipProp.IgnoreMagicDefenseRate)]
		public CrypticInt32 magicAttackReduceRate;

		// Token: 0x04008A2C RID: 35372
		[EquipProp(EEquipProp.IgnorePhysicsDefense)]
		public CrypticInt32 attackReduceFix;

		// Token: 0x04008A2D RID: 35373
		[EquipProp(EEquipProp.IgnoreMagicDefense)]
		public CrypticInt32 magicAttackReduceFix;

		// Token: 0x04008A2E RID: 35374
		[EquipProp(EEquipProp.Independence)]
		public CrypticInt32 independence;

		// Token: 0x04008A2F RID: 35375
		[EquipProp(EEquipProp.IngoreIndependence)]
		public CrypticInt32 ingoreIndependence;

		// Token: 0x04008A30 RID: 35376
		public IList<int> attachBuffIDs;

		// Token: 0x04008A31 RID: 35377
		public IList<int> attachMechanismIDs;

		// Token: 0x04008A32 RID: 35378
		public IList<int> attachPVPBuffIDs;

		// Token: 0x04008A33 RID: 35379
		public IList<int> attachPVPMechanismIDs;

		// Token: 0x04008A34 RID: 35380
		public int[] magicElements;

		// Token: 0x04008A35 RID: 35381
		public CrypticInt32[] magicElementsAttack = new CrypticInt32[5];

		// Token: 0x04008A36 RID: 35382
		public CrypticInt32[] magicElementsDefence = new CrypticInt32[5];

		// Token: 0x04008A37 RID: 35383
		public CrypticInt32[] abnormalResists = new CrypticInt32[13];

		// Token: 0x04008A38 RID: 35384
		public CrypticInt32 resistMagic;
	}
}
