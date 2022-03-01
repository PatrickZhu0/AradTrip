using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004179 RID: 16761
public class BattleData
{
	// Token: 0x06016F6C RID: 94060 RVA: 0x0070A440 File Offset: 0x00708840
	public BattleData()
	{
		this.hpScale = GlobalLogic.VALUE_1000;
	}

	// Token: 0x17001F4F RID: 8015
	// (get) Token: 0x06016F6D RID: 94061 RVA: 0x0070A52A File Offset: 0x0070892A
	public FrameRandomImp FrameRandom
	{
		get
		{
			if (this.owner.FrameRandom == null)
			{
				return BeSkill.randomForTown;
			}
			return this.owner.FrameRandom;
		}
	}

	// Token: 0x17001F50 RID: 8016
	// (get) Token: 0x06016F6E RID: 94062 RVA: 0x0070A54D File Offset: 0x0070894D
	// (set) Token: 0x06016F6F RID: 94063 RVA: 0x0070A55A File Offset: 0x0070895A
	public int hp
	{
		get
		{
			return this._hp;
		}
		set
		{
			this._hp = value;
		}
	}

	// Token: 0x06016F70 RID: 94064 RVA: 0x0070A568 File Offset: 0x00708968
	private double RandmonValue(double value, int valueRange)
	{
		if (Global.Settings.isDebug && Global.Settings.damageNoRange)
		{
			return value;
		}
		int num = this.FrameRandom.InRange(0, valueRange * GlobalLogic.VALUE_2) - valueRange;
		value *= (double)GlobalLogic.VALUE_1 + (double)num / (double)GlobalLogic.VALUE_100;
		return value;
	}

	// Token: 0x06016F71 RID: 94065 RVA: 0x0070A5C0 File Offset: 0x007089C0
	public void AddDamage(int damage, BeEntity attacker, BeEntity owner)
	{
		this.totalDamage += (long)damage;
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleDataUpdate, null, null, null, null);
	}

	// Token: 0x06016F72 RID: 94066 RVA: 0x0070A5E4 File Offset: 0x007089E4
	public long GetTotalDamage()
	{
		return this.totalDamage;
	}

	// Token: 0x17001F51 RID: 8017
	// (get) Token: 0x06016F73 RID: 94067 RVA: 0x0070A5EC File Offset: 0x007089EC
	public double _baseSta
	{
		get
		{
			return (double)this.baseSta / (double)GlobalLogic.VALUE_1000;
		}
	}

	// Token: 0x17001F52 RID: 8018
	// (get) Token: 0x06016F74 RID: 94068 RVA: 0x0070A601 File Offset: 0x00708A01
	public double _baseAtk
	{
		get
		{
			return (double)this.baseAtk / (double)GlobalLogic.VALUE_1000;
		}
	}

	// Token: 0x17001F53 RID: 8019
	// (get) Token: 0x06016F75 RID: 94069 RVA: 0x0070A616 File Offset: 0x00708A16
	public double _baseInt
	{
		get
		{
			return (double)this.baseInt / (double)GlobalLogic.VALUE_1000;
		}
	}

	// Token: 0x17001F54 RID: 8020
	// (get) Token: 0x06016F76 RID: 94070 RVA: 0x0070A62B File Offset: 0x00708A2B
	public double _baseSpr
	{
		get
		{
			return (double)this.baseSpr / (double)GlobalLogic.VALUE_1000;
		}
	}

	// Token: 0x17001F55 RID: 8021
	// (get) Token: 0x06016F77 RID: 94071 RVA: 0x0070A640 File Offset: 0x00708A40
	public double _baseIndependence
	{
		get
		{
			return (double)(this.baseIndependence + this.ingoreIndependence) / (double)GlobalLogic.VALUE_1000;
		}
	}

	// Token: 0x17001F56 RID: 8022
	// (get) Token: 0x06016F78 RID: 94072 RVA: 0x0070A661 File Offset: 0x00708A61
	// (set) Token: 0x06016F79 RID: 94073 RVA: 0x0070A670 File Offset: 0x00708A70
	public int sta
	{
		get
		{
			return this.baseSta;
		}
		set
		{
			if (!this.m_NeedChangeSta)
			{
				return;
			}
			this.baseSta = value;
			double num = (double)this.hp / (double)((float)this.maxHp);
			this.maxHp = this.fMaxHp;
			this.hp = IntMath.Double2Int(num * (double)this.maxHp);
			this.hpRecover = this.fHpRecoer;
			if (this.owner != null)
			{
				this.owner.GetEntityData().ChangeMaxHpByResist();
			}
		}
	}

	// Token: 0x17001F57 RID: 8023
	// (get) Token: 0x06016F7A RID: 94074 RVA: 0x0070A700 File Offset: 0x00708B00
	// (set) Token: 0x06016F7B RID: 94075 RVA: 0x0070A710 File Offset: 0x00708B10
	public int spr
	{
		get
		{
			return this.baseSpr;
		}
		set
		{
			this.baseSpr = value;
			double num = (double)this.mp / (double)((float)this.maxMp);
			this.maxMp = this.fMaxMp;
			this.mp = IntMath.Double2Int(num * (double)this.maxMp);
			this.mpRecover = this.fMpRecover;
		}
	}

	// Token: 0x17001F58 RID: 8024
	// (get) Token: 0x06016F7C RID: 94076 RVA: 0x0070A784 File Offset: 0x00708B84
	public int displayAttack
	{
		get
		{
			double x = (double)this.attack * ((double)GlobalLogic.VALUE_1 + this._baseAtk / (double)GlobalLogic.VALUE_250) * ((double)GlobalLogic.VALUE_1 + (double)this.attackAddRate / (double)GlobalLogic.VALUE_1000) + (double)this.ignoreDefAttackAdd;
			return IntMath.Float2IntWithFixed(x, (long)GlobalLogic.VALUE_1, 100L, MidpointRounding.AwayFromZero);
		}
	}

	// Token: 0x17001F59 RID: 8025
	// (get) Token: 0x06016F7D RID: 94077 RVA: 0x0070A7EC File Offset: 0x00708BEC
	public double fAttack
	{
		get
		{
			return this.RandmonValue((double)this.attack, GlobalLogic.VALUE_10) * ((double)GlobalLogic.VALUE_1 + this._baseAtk / (double)GlobalLogic.VALUE_250) * ((double)GlobalLogic.VALUE_1 + (double)this.attackAddRate / (double)GlobalLogic.VALUE_1000) + (double)this.ignoreDefAttackAdd;
		}
	}

	// Token: 0x17001F5A RID: 8026
	// (get) Token: 0x06016F7E RID: 94078 RVA: 0x0070A850 File Offset: 0x00708C50
	public int displayMagicAttack
	{
		get
		{
			double x = (double)this.magicAttack * ((double)GlobalLogic.VALUE_1 + this._baseInt / (double)GlobalLogic.VALUE_250) * ((double)GlobalLogic.VALUE_1 + (double)this.magicAttackAddRate / (double)GlobalLogic.VALUE_1000) + (double)this.ignoreDefMagicAttackAdd;
			return IntMath.Float2IntWithFixed(x, (long)GlobalLogic.VALUE_1, 100L, MidpointRounding.AwayFromZero);
		}
	}

	// Token: 0x17001F5B RID: 8027
	// (get) Token: 0x06016F7F RID: 94079 RVA: 0x0070A8B8 File Offset: 0x00708CB8
	public double fMagicAttack
	{
		get
		{
			return this.RandmonValue((double)this.magicAttack, GlobalLogic.VALUE_10) * ((double)GlobalLogic.VALUE_1 + this._baseInt / (double)GlobalLogic.VALUE_250) * ((double)GlobalLogic.VALUE_1 + (double)this.magicAttackAddRate / (double)GlobalLogic.VALUE_1000) + (double)this.ignoreDefMagicAttackAdd;
		}
	}

	// Token: 0x17001F5C RID: 8028
	// (get) Token: 0x06016F80 RID: 94080 RVA: 0x0070A91C File Offset: 0x00708D1C
	public int fMaxHp
	{
		get
		{
			double num = this._baseSta;
			if (num <= -250.0)
			{
				num = -240.0;
			}
			double x = (double)this._maxHp * ((double)GlobalLogic.VALUE_1 + num / (double)GlobalLogic.VALUE_250) * ((double)this.hpScale / (double)GlobalLogic.VALUE_1000);
			return IntMath.Float2IntWithFixed(x, (long)GlobalLogic.VALUE_1, 100L, MidpointRounding.AwayFromZero);
		}
	}

	// Token: 0x17001F5D RID: 8029
	// (get) Token: 0x06016F81 RID: 94081 RVA: 0x0070A98C File Offset: 0x00708D8C
	public int fMaxMp
	{
		get
		{
			double num = this._baseSpr;
			if (num <= -250.0)
			{
				num = -240.0;
			}
			double x = (double)this._maxMp * ((double)GlobalLogic.VALUE_1 + num / (double)GlobalLogic.VALUE_250);
			return IntMath.Float2IntWithFixed(x, (long)GlobalLogic.VALUE_1, 100L, MidpointRounding.AwayFromZero);
		}
	}

	// Token: 0x17001F5E RID: 8030
	// (get) Token: 0x06016F82 RID: 94082 RVA: 0x0070A9E8 File Offset: 0x00708DE8
	public int fDefence
	{
		get
		{
			double x = ((double)this.defence + this._baseSta * (double)GlobalLogic.VALUE_5) * ((double)GlobalLogic.VALUE_1 + (double)this.defenceAddRate / (double)GlobalLogic.VALUE_1000);
			int val = IntMath.Float2IntWithFixed(x, (long)GlobalLogic.VALUE_1, 100L, MidpointRounding.AwayFromZero);
			return Math.Max(0, val);
		}
	}

	// Token: 0x17001F5F RID: 8031
	// (get) Token: 0x06016F83 RID: 94083 RVA: 0x0070AA44 File Offset: 0x00708E44
	public int fMagicDefence
	{
		get
		{
			double x = ((double)this.magicDefence + this._baseSpr * (double)GlobalLogic.VALUE_5) * ((double)GlobalLogic.VALUE_1 + (double)this.magicDefenceAddRate / (double)GlobalLogic.VALUE_1000);
			int val = IntMath.Float2IntWithFixed(x, (long)GlobalLogic.VALUE_1, 100L, MidpointRounding.AwayFromZero);
			return Math.Max(0, val);
		}
	}

	// Token: 0x17001F60 RID: 8032
	// (get) Token: 0x06016F84 RID: 94084 RVA: 0x0070AAA0 File Offset: 0x00708EA0
	public int fHpRecoer
	{
		get
		{
			double x = (double)this._hpRecover * ((double)GlobalLogic.VALUE_1 + this._baseSta / (double)GlobalLogic.VALUE_250);
			return IntMath.Float2IntWithFixed(x, (long)GlobalLogic.VALUE_1, 100L, MidpointRounding.AwayFromZero);
		}
	}

	// Token: 0x17001F61 RID: 8033
	// (get) Token: 0x06016F85 RID: 94085 RVA: 0x0070AAE0 File Offset: 0x00708EE0
	public int fMpRecover
	{
		get
		{
			double x = (double)this._mpRecover * ((double)GlobalLogic.VALUE_1 + this._baseSpr / (double)GlobalLogic.VALUE_250);
			return IntMath.Float2IntWithFixed(x, (long)GlobalLogic.VALUE_1, 100L, MidpointRounding.AwayFromZero);
		}
	}

	// Token: 0x17001F62 RID: 8034
	// (get) Token: 0x06016F86 RID: 94086 RVA: 0x0070AB1F File Offset: 0x00708F1F
	public double fAbnormalResist
	{
		get
		{
			return (double)this.abnormalResist / 1.2;
		}
	}

	// Token: 0x06016F87 RID: 94087 RVA: 0x0070AB38 File Offset: 0x00708F38
	public void ChangeMaxHP(int value)
	{
		double num = (double)this.hp / (double)((float)this.maxHp);
		this._maxHp += value;
		this.maxHp = this.fMaxHp;
		this.hp = IntMath.Double2Int(num * (double)this.maxHp);
	}

	// Token: 0x06016F88 RID: 94088 RVA: 0x0070AB9C File Offset: 0x00708F9C
	public void ChangeMaxMP(int value)
	{
		double num = (double)this.mp / (double)((float)this.maxMp);
		this._maxMp += value;
		this.maxMp = this.fMaxMp;
		this.mp = IntMath.Double2Int(num * (double)this.maxMp);
	}

	// Token: 0x06016F89 RID: 94089 RVA: 0x0070AC0A File Offset: 0x0070900A
	public void DebugPrint()
	{
		Utility.PrintType(typeof(BattleData), this);
	}

	// Token: 0x06016F8A RID: 94090 RVA: 0x0070AC1C File Offset: 0x0070901C
	public string GetDebugPrint()
	{
		return Utility.GetTypeInfoString(typeof(BattleData), this);
	}

	// Token: 0x06016F8B RID: 94091 RVA: 0x0070AC2E File Offset: 0x0070902E
	public void SetNeedChangeSta(bool flag)
	{
		this.m_NeedChangeSta = flag;
	}

	// Token: 0x06016F8C RID: 94092 RVA: 0x0070AC38 File Offset: 0x00709038
	public void RefreshMpInfo()
	{
		double num = (double)this.mp / (double)((float)this.maxMp);
		this.maxMp = this.fMaxMp;
		this.mp = IntMath.Double2Int(num * (double)this.maxMp);
		this.mpRecover = this.fMpRecover;
	}

	// Token: 0x06016F8D RID: 94093 RVA: 0x0070ACA0 File Offset: 0x007090A0
	public int GetValue(AttributeType attributeType)
	{
		int result = 0;
		switch (attributeType)
		{
		case AttributeType.maxHp:
			result = this._maxHp;
			break;
		case AttributeType.maxMp:
			result = this._maxMp;
			break;
		case AttributeType.hpRecover:
			result = this._hpRecover;
			break;
		case AttributeType.mpRecover:
			result = this._mpRecover;
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
		case AttributeType.criticalPercent:
			result = this.criticalPercent;
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
		case AttributeType.defenceAddRate:
			result = this.defenceAddRate;
			break;
		case AttributeType.magicDefenceAddRate:
			result = this.magicDefenceAddRate;
			break;
		case AttributeType.ingnoreDefRate:
			result = this.ingoreDefRate;
			break;
		case AttributeType.ingnoreMagicDefRate:
			result = this.ingoreMagicDefRate;
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
			result = this.baseIndependence;
			break;
		case AttributeType.baseSpr:
			result = this.baseSpr;
			break;
		case AttributeType.ingoreIndependence:
			result = this.ingoreIndependence;
			break;
		case AttributeType.hpGrow:
			result = this.hpGrow;
			break;
		case AttributeType.mpGrow:
			result = this.mpGrow;
			break;
		case AttributeType.atkGrow:
			result = this.atkGrow;
			break;
		case AttributeType.intGrow:
			result = this.intGrow;
			break;
		case AttributeType.staGrow:
			result = this.staGrow;
			break;
		case AttributeType.sprGrow:
			result = this.sprGrow;
			break;
		case AttributeType.hardGrow:
			result = this.hardGrow;
			break;
		case AttributeType.sta:
			result = this.sta;
			break;
		case AttributeType.spr:
			result = this.spr;
			break;
		case AttributeType.resistMagic:
			result = this.resistMagic;
			break;
		}
		return result;
	}

	// Token: 0x06016F8E RID: 94094 RVA: 0x0070B0E0 File Offset: 0x007094E0
	public void SetValue(AttributeType attributeType, int value, bool add = false)
	{
		switch (attributeType)
		{
		case AttributeType.maxHp:
			if (add)
			{
				this._maxHp += value;
			}
			else
			{
				this._maxHp = value;
			}
			break;
		case AttributeType.maxMp:
			if (add)
			{
				this._maxMp += value;
			}
			else
			{
				this._maxMp = value;
			}
			break;
		case AttributeType.hpRecover:
			if (add)
			{
				this._hpRecover += value;
			}
			else
			{
				this._hpRecover = value;
			}
			break;
		case AttributeType.mpRecover:
			if (add)
			{
				this._mpRecover += value;
			}
			else
			{
				this._mpRecover = value;
			}
			break;
		case AttributeType.attack:
			if (add)
			{
				this.attack += value;
			}
			else
			{
				this.attack = value;
			}
			break;
		case AttributeType.magicAttack:
			if (add)
			{
				this.magicAttack += value;
			}
			else
			{
				this.magicAttack = value;
			}
			break;
		case AttributeType.defence:
			if (add)
			{
				this.defence += value;
			}
			else
			{
				this.defence = value;
			}
			break;
		case AttributeType.magicDefence:
			if (add)
			{
				this.magicDefence += value;
			}
			else
			{
				this.magicDefence = value;
			}
			break;
		case AttributeType.attackSpeed:
			if (add)
			{
				this.attackSpeed += value;
			}
			else
			{
				this.attackSpeed = value;
			}
			break;
		case AttributeType.spellSpeed:
			if (add)
			{
				this.spellSpeed += value;
			}
			else
			{
				this.spellSpeed = value;
			}
			break;
		case AttributeType.moveSpeed:
			if (add)
			{
				this.moveSpeed += value;
			}
			else
			{
				this.moveSpeed = value;
			}
			break;
		case AttributeType.ciriticalAttack:
			if (add)
			{
				this.ciriticalAttack += value;
			}
			else
			{
				this.ciriticalAttack = value;
			}
			break;
		case AttributeType.ciriticalMagicAttack:
			if (add)
			{
				this.ciriticalMagicAttack += value;
			}
			else
			{
				this.ciriticalMagicAttack = value;
			}
			break;
		case AttributeType.dex:
			if (add)
			{
				this.dex += value;
			}
			else
			{
				this.dex = value;
			}
			break;
		case AttributeType.dodge:
			if (add)
			{
				this.dodge += value;
			}
			else
			{
				this.dodge = value;
			}
			break;
		case AttributeType.frozen:
			if (add)
			{
				this.frozen += value;
			}
			else
			{
				this.frozen = value;
			}
			break;
		case AttributeType.hard:
			if (add)
			{
				this.hard += value;
			}
			else
			{
				this.hard = value;
			}
			break;
		case AttributeType.abnormalResist:
			if (add)
			{
				this.abnormalResist += value;
			}
			else
			{
				this.abnormalResist = value;
			}
			break;
		case AttributeType.criticalPercent:
			if (add)
			{
				this.criticalPercent += value;
			}
			else
			{
				this.criticalPercent = value;
			}
			break;
		case AttributeType.cdReduceRate:
			if (add)
			{
				this.cdReduceRate += value;
			}
			else
			{
				this.cdReduceRate = value;
			}
			break;
		case AttributeType.cdReduceRateMagic:
			if (add)
			{
				this.cdReduceRateMagic += value;
			}
			else
			{
				this.cdReduceRateMagic = value;
			}
			break;
		case AttributeType.mpCostReduceRate:
			if (add)
			{
				this.mpCostReduceRate += value;
			}
			else
			{
				this.mpCostReduceRate = value;
			}
			break;
		case AttributeType.mpCostReduceRateMagic:
			if (add)
			{
				this.mpCostReduceRateMagic += value;
			}
			else
			{
				this.mpCostReduceRateMagic = value;
			}
			break;
		case AttributeType.attackAddRate:
			if (add)
			{
				this.attackAddRate += value;
			}
			else
			{
				this.attackAddRate = value;
			}
			break;
		case AttributeType.magicAttackAddRate:
			if (add)
			{
				this.magicAttackAddRate += value;
			}
			else
			{
				this.magicAttackAddRate = value;
			}
			break;
		case AttributeType.ignoreDefAttackAdd:
			if (add)
			{
				this.ignoreDefAttackAdd += value;
			}
			else
			{
				this.ignoreDefAttackAdd = value;
			}
			break;
		case AttributeType.ignoreDefMagicAttackAdd:
			if (add)
			{
				this.ignoreDefMagicAttackAdd += value;
			}
			else
			{
				this.ignoreDefMagicAttackAdd = value;
			}
			break;
		case AttributeType.attackReduceRate:
			if (add)
			{
				this.attackReduceRate += value;
			}
			else
			{
				this.attackReduceRate = value;
			}
			break;
		case AttributeType.magicAttackReduceRate:
			if (add)
			{
				this.magicAttackReduceRate += value;
			}
			else
			{
				this.magicAttackReduceRate = value;
			}
			break;
		case AttributeType.attackReduceFix:
			if (add)
			{
				this.attackReduceFix += value;
			}
			else
			{
				this.attackReduceFix = value;
			}
			break;
		case AttributeType.magicAttackReduceFix:
			if (add)
			{
				this.magicAttackReduceFix += value;
			}
			else
			{
				this.magicAttackReduceFix = value;
			}
			break;
		case AttributeType.defenceAddRate:
			if (add)
			{
				this.defenceAddRate += value;
			}
			else
			{
				this.defenceAddRate = value;
			}
			break;
		case AttributeType.magicDefenceAddRate:
			if (add)
			{
				this.magicDefenceAddRate += value;
			}
			else
			{
				this.magicDefenceAddRate = value;
			}
			break;
		case AttributeType.ingnoreDefRate:
			if (add)
			{
				this.ingoreDefRate += value;
			}
			else
			{
				this.ingoreDefRate = value;
			}
			break;
		case AttributeType.ingnoreMagicDefRate:
			if (add)
			{
				this.ingoreMagicDefRate += value;
			}
			else
			{
				this.ingoreMagicDefRate = value;
			}
			break;
		case AttributeType.baseAtk:
		{
			int num = this.baseAtk.ToInt();
			if (add)
			{
				this.baseAtk += value;
			}
			else
			{
				this.baseAtk = value;
			}
			if (this.owner != null && num != this.baseAtk)
			{
				this.owner.TriggerEvent(BeEventType.onAttrChange, new object[]
				{
					AttributeType.baseAtk
				});
			}
			break;
		}
		case AttributeType.baseInt:
		{
			int num2 = this.baseInt.ToInt();
			if (add)
			{
				this.baseInt += value;
			}
			else
			{
				this.baseInt = value;
			}
			if (this.owner != null && num2 != this.baseInt)
			{
				this.owner.TriggerEvent(BeEventType.onAttrChange, new object[]
				{
					AttributeType.baseInt
				});
			}
			break;
		}
		case AttributeType.baseSta:
		{
			int num3 = this.baseSta.ToInt();
			if (add)
			{
				this.baseSta += value;
			}
			else
			{
				this.baseSta = value;
			}
			if (this.owner != null && num3 != this.baseSta)
			{
				this.owner.TriggerEvent(BeEventType.onAttrChange, new object[]
				{
					AttributeType.baseSta
				});
			}
			break;
		}
		case AttributeType.baseIndependence:
		{
			int num4 = this.baseIndependence.ToInt();
			if (add)
			{
				this.baseIndependence += value;
			}
			else
			{
				this.baseIndependence = value;
			}
			if (this.owner != null && num4 != this.baseInt)
			{
				this.owner.TriggerEvent(BeEventType.onAttrChange, new object[]
				{
					AttributeType.baseIndependence
				});
			}
			break;
		}
		case AttributeType.baseSpr:
		{
			int num5 = this.baseSpr.ToInt();
			if (add)
			{
				this.baseSpr += value;
			}
			else
			{
				this.baseSpr = value;
			}
			if (this.owner != null && num5 != this.baseSpr)
			{
				this.owner.TriggerEvent(BeEventType.onAttrChange, new object[]
				{
					AttributeType.baseSpr
				});
			}
			break;
		}
		case AttributeType.ingoreIndependence:
		{
			int num6 = this.ingoreIndependence.ToInt();
			if (add)
			{
				this.ingoreIndependence += value;
			}
			else
			{
				this.ingoreIndependence = value;
			}
			if (this.owner != null && num6 != this.baseInt)
			{
				this.owner.TriggerEvent(BeEventType.onAttrChange, new object[]
				{
					AttributeType.ingoreIndependence
				});
			}
			break;
		}
		case AttributeType.hpGrow:
			if (add)
			{
				this.hpGrow += value;
			}
			else
			{
				this.hpGrow = value;
			}
			break;
		case AttributeType.mpGrow:
			if (add)
			{
				this.mpGrow += value;
			}
			else
			{
				this.mpGrow = value;
			}
			break;
		case AttributeType.atkGrow:
			if (add)
			{
				this.atkGrow += value;
			}
			else
			{
				this.atkGrow = value;
			}
			break;
		case AttributeType.intGrow:
			if (add)
			{
				this.intGrow += value;
			}
			else
			{
				this.intGrow = value;
			}
			break;
		case AttributeType.staGrow:
			if (add)
			{
				this.staGrow += value;
			}
			else
			{
				this.staGrow = value;
			}
			break;
		case AttributeType.sprGrow:
			if (add)
			{
				this.sprGrow += value;
			}
			else
			{
				this.sprGrow = value;
			}
			break;
		case AttributeType.hardGrow:
			if (add)
			{
				this.hardGrow += value;
			}
			else
			{
				this.hardGrow = value;
			}
			break;
		case AttributeType.sta:
			if (add)
			{
				this.sta += value;
			}
			else
			{
				this.sta = value;
			}
			break;
		case AttributeType.spr:
			if (add)
			{
				this.spr += value;
			}
			else
			{
				this.spr = value;
			}
			break;
		case AttributeType.resistMagic:
			if (add)
			{
				this.resistMagic += value;
			}
			else
			{
				this.resistMagic = value;
			}
			break;
		}
	}

	// Token: 0x0401076D RID: 67437
	public BeEntity owner;

	// Token: 0x0401076E RID: 67438
	protected CrypticInt32 _hp;

	// Token: 0x0401076F RID: 67439
	public CrypticInt32 mp;

	// Token: 0x04010770 RID: 67440
	public CrypticInt32 maxHp;

	// Token: 0x04010771 RID: 67441
	public CrypticInt32 maxMp;

	// Token: 0x04010772 RID: 67442
	public CrypticInt32 hpRecover;

	// Token: 0x04010773 RID: 67443
	public CrypticInt32 mpRecover;

	// Token: 0x04010774 RID: 67444
	public CrypticInt32 hpReduce;

	// Token: 0x04010775 RID: 67445
	public CrypticInt32 mpReduce;

	// Token: 0x04010776 RID: 67446
	public CrypticInt32 hpScale;

	// Token: 0x04010777 RID: 67447
	public CrypticInt32 baseSta;

	// Token: 0x04010778 RID: 67448
	public CrypticInt32 baseAtk;

	// Token: 0x04010779 RID: 67449
	public CrypticInt32 baseInt;

	// Token: 0x0401077A RID: 67450
	public CrypticInt32 baseSpr;

	// Token: 0x0401077B RID: 67451
	public CrypticInt32 baseIndependence;

	// Token: 0x0401077C RID: 67452
	public CrypticInt32 _maxHp;

	// Token: 0x0401077D RID: 67453
	public CrypticInt32 _maxMp;

	// Token: 0x0401077E RID: 67454
	public CrypticInt32 _hpRecover;

	// Token: 0x0401077F RID: 67455
	public CrypticInt32 _mpRecover;

	// Token: 0x04010780 RID: 67456
	public CrypticInt32 attack;

	// Token: 0x04010781 RID: 67457
	public CrypticInt32 magicAttack;

	// Token: 0x04010782 RID: 67458
	public CrypticInt32 defence;

	// Token: 0x04010783 RID: 67459
	public CrypticInt32 magicDefence;

	// Token: 0x04010784 RID: 67460
	public CrypticInt32 attackSpeed;

	// Token: 0x04010785 RID: 67461
	public CrypticInt32 spellSpeed;

	// Token: 0x04010786 RID: 67462
	public CrypticInt32 moveSpeed;

	// Token: 0x04010787 RID: 67463
	public CrypticInt32 ciriticalAttack;

	// Token: 0x04010788 RID: 67464
	public CrypticInt32 ciriticalMagicAttack;

	// Token: 0x04010789 RID: 67465
	public CrypticInt32 dex;

	// Token: 0x0401078A RID: 67466
	public CrypticInt32 dodge;

	// Token: 0x0401078B RID: 67467
	public CrypticInt32 frozen;

	// Token: 0x0401078C RID: 67468
	public CrypticInt32 hard;

	// Token: 0x0401078D RID: 67469
	public CrypticInt32 initDefence;

	// Token: 0x0401078E RID: 67470
	public CrypticInt32 initMagicDefence;

	// Token: 0x0401078F RID: 67471
	public CrypticInt32 attackAddRate;

	// Token: 0x04010790 RID: 67472
	public CrypticInt32 magicAttackAddRate;

	// Token: 0x04010791 RID: 67473
	public CrypticInt32 ignoreDefAttackAdd;

	// Token: 0x04010792 RID: 67474
	public CrypticInt32 ignoreDefMagicAttackAdd;

	// Token: 0x04010793 RID: 67475
	public CrypticInt32 ingoreIndependence;

	// Token: 0x04010794 RID: 67476
	public CrypticInt32 attackReduceRate;

	// Token: 0x04010795 RID: 67477
	public CrypticInt32 magicAttackReduceRate;

	// Token: 0x04010796 RID: 67478
	public CrypticInt32 attackReduceFix;

	// Token: 0x04010797 RID: 67479
	public CrypticInt32 magicAttackReduceFix;

	// Token: 0x04010798 RID: 67480
	public CrypticInt32 ingoreDefRate;

	// Token: 0x04010799 RID: 67481
	public CrypticInt32 ingoreMagicDefRate;

	// Token: 0x0401079A RID: 67482
	public CrypticInt32 abnormalResist;

	// Token: 0x0401079B RID: 67483
	public CrypticInt32 criticalPercent;

	// Token: 0x0401079C RID: 67484
	public CrypticInt32 cdReduceRate;

	// Token: 0x0401079D RID: 67485
	public CrypticInt32 cdReduceRateMagic;

	// Token: 0x0401079E RID: 67486
	public CrypticInt32 mpCostReduceRate;

	// Token: 0x0401079F RID: 67487
	public CrypticInt32 mpCostReduceRateMagic;

	// Token: 0x040107A0 RID: 67488
	public CrypticInt32 defenceAddRate;

	// Token: 0x040107A1 RID: 67489
	public CrypticInt32 magicDefenceAddRate;

	// Token: 0x040107A2 RID: 67490
	public CrypticInt32 attachHurtRate;

	// Token: 0x040107A3 RID: 67491
	public CrypticInt32 attachHurtFix;

	// Token: 0x040107A4 RID: 67492
	public CrypticInt32 hpGrow;

	// Token: 0x040107A5 RID: 67493
	public CrypticInt32 mpGrow;

	// Token: 0x040107A6 RID: 67494
	public CrypticInt32 atkGrow;

	// Token: 0x040107A7 RID: 67495
	public CrypticInt32 intGrow;

	// Token: 0x040107A8 RID: 67496
	public CrypticInt32 staGrow;

	// Token: 0x040107A9 RID: 67497
	public CrypticInt32 sprGrow;

	// Token: 0x040107AA RID: 67498
	public CrypticInt32 mpRecoverGrow;

	// Token: 0x040107AB RID: 67499
	public CrypticInt32 hardGrow;

	// Token: 0x040107AC RID: 67500
	public List<AddDamageInfo> attachAddDamageFix = new List<AddDamageInfo>();

	// Token: 0x040107AD RID: 67501
	public List<AddDamageInfo> attachAddDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107AE RID: 67502
	public List<AddDamageInfo> addDamageFix = new List<AddDamageInfo>();

	// Token: 0x040107AF RID: 67503
	public List<AddDamageInfo> addDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107B0 RID: 67504
	public List<AddDamageInfo> skillAddDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107B1 RID: 67505
	public List<AddDamageInfo> skillAddMagicDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107B2 RID: 67506
	public List<AddDamageInfo> reduceDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107B3 RID: 67507
	public List<AddDamageInfo> reduceDamageFix = new List<AddDamageInfo>();

	// Token: 0x040107B4 RID: 67508
	public List<AddDamageInfo> reduceExtraDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107B5 RID: 67509
	public List<AddDamageInfo> reduceMeiyingDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107B6 RID: 67510
	public List<AddDamageInfo> reduceGeDangDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107B7 RID: 67511
	public List<AddDamageInfo> reflectDamagePercent = new List<AddDamageInfo>();

	// Token: 0x040107B8 RID: 67512
	public List<AddDamageInfo> reflectDamageFix = new List<AddDamageInfo>();

	// Token: 0x040107B9 RID: 67513
	public int[] magicELements = new int[5];

	// Token: 0x040107BA RID: 67514
	public CrypticInt32[] magicElementsAttack = new CrypticInt32[5];

	// Token: 0x040107BB RID: 67515
	public CrypticInt32[] magicElementsDefence = new CrypticInt32[5];

	// Token: 0x040107BC RID: 67516
	public CrypticInt32[] abnormalResists = new CrypticInt32[13];

	// Token: 0x040107BD RID: 67517
	public CrypticInt32 resistMagic;

	// Token: 0x040107BE RID: 67518
	private long totalDamage;

	// Token: 0x040107BF RID: 67519
	private bool m_NeedChangeSta = true;

	// Token: 0x040107C0 RID: 67520
	private const long kFloatBit = 100L;
}
