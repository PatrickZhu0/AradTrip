using System;

// Token: 0x02004178 RID: 16760
public enum AttributeType
{
	// Token: 0x04010739 RID: 67385
	[UIProperty("HP最大值", "+{0}", true)]
	maxHp,
	// Token: 0x0401073A RID: 67386
	[UIProperty("MP最大值", "+{0}", true)]
	maxMp,
	// Token: 0x0401073B RID: 67387
	[UIProperty("HP回复", "+{0}", true)]
	hpRecover,
	// Token: 0x0401073C RID: 67388
	[UIProperty("MP回复", "+{0}", true)]
	mpRecover,
	// Token: 0x0401073D RID: 67389
	[UIProperty("物理攻击", "+{0}", true)]
	attack,
	// Token: 0x0401073E RID: 67390
	[UIProperty("魔法攻击", "+{0}", true)]
	magicAttack,
	// Token: 0x0401073F RID: 67391
	[UIProperty("物理防御", "+{0}", true)]
	defence,
	// Token: 0x04010740 RID: 67392
	[UIProperty("魔法防御", "+{0}", true)]
	magicDefence,
	// Token: 0x04010741 RID: 67393
	[UIProperty("攻击速度", "+{0}%", true)]
	attackSpeed,
	// Token: 0x04010742 RID: 67394
	[UIProperty("施放速度", "+{0}%", true)]
	spellSpeed,
	// Token: 0x04010743 RID: 67395
	[UIProperty("移动速度", "+{0}%", true)]
	moveSpeed,
	// Token: 0x04010744 RID: 67396
	[UIProperty("物理爆击", "+{0}%", true)]
	ciriticalAttack,
	// Token: 0x04010745 RID: 67397
	[UIProperty("魔法爆击", "+{0}%", true)]
	ciriticalMagicAttack,
	// Token: 0x04010746 RID: 67398
	[UIProperty("命中率", "+{0}%", true)]
	dex,
	// Token: 0x04010747 RID: 67399
	[UIProperty("闪避", "+{0}%", true)]
	dodge,
	// Token: 0x04010748 RID: 67400
	[UIProperty("僵值", "+{0}", true)]
	frozen,
	// Token: 0x04010749 RID: 67401
	[UIProperty("硬值", "+{0}", true)]
	hard,
	// Token: 0x0401074A RID: 67402
	[UIProperty("异常状态抗性", "+{0}", true)]
	abnormalResist,
	// Token: 0x0401074B RID: 67403
	[UIProperty("暴击伤害百分比", "+{0}%", true)]
	criticalPercent,
	// Token: 0x0401074C RID: 67404
	[UIProperty("物理技能CD缩减百分比", "+{0}%", true)]
	cdReduceRate,
	// Token: 0x0401074D RID: 67405
	[UIProperty("魔法技能CD缩减百分比", "+{0}%", true)]
	cdReduceRateMagic,
	// Token: 0x0401074E RID: 67406
	[UIProperty("物理技能mp消耗缩减百分比", "+{0}%", true)]
	mpCostReduceRate,
	// Token: 0x0401074F RID: 67407
	[UIProperty("魔法技能mp消耗缩减百分比", "+{0}%", true)]
	mpCostReduceRateMagic,
	// Token: 0x04010750 RID: 67408
	[UIProperty("物理攻击增加百分比", "+{0}%", true)]
	attackAddRate,
	// Token: 0x04010751 RID: 67409
	[UIProperty("魔法攻击增加百分比", "+{0}%", true)]
	magicAttackAddRate,
	// Token: 0x04010752 RID: 67410
	[UIProperty("无视物理防御攻击力", "+{0}", true)]
	ignoreDefAttackAdd,
	// Token: 0x04010753 RID: 67411
	[UIProperty("无视魔法防御攻击力", "+{0}", true)]
	ignoreDefMagicAttackAdd,
	// Token: 0x04010754 RID: 67412
	[UIProperty("物理攻击减免百分比", "-{0}%", false)]
	attackReduceRate,
	// Token: 0x04010755 RID: 67413
	[UIProperty("魔法攻击减免百分比", "-{0}%", false)]
	magicAttackReduceRate,
	// Token: 0x04010756 RID: 67414
	[UIProperty("物理攻击减免固定值", "-{0}", false)]
	attackReduceFix,
	// Token: 0x04010757 RID: 67415
	[UIProperty("魔法攻击减免固定值", "-{0}", false)]
	magicAttackReduceFix,
	// Token: 0x04010758 RID: 67416
	[UIProperty("物理防御增加百分比", "-{0}%", false)]
	defenceAddRate,
	// Token: 0x04010759 RID: 67417
	[UIProperty("魔法防御增加百分比", "-{0}%", false)]
	magicDefenceAddRate,
	// Token: 0x0401075A RID: 67418
	[UIProperty("无视物理防御百分比", "+{0}%", false)]
	ingnoreDefRate,
	// Token: 0x0401075B RID: 67419
	[UIProperty("无视魔法防御百分比", "+{0}%", false)]
	ingnoreMagicDefRate,
	// Token: 0x0401075C RID: 67420
	[UIProperty("力量", "+{0}", true)]
	baseAtk,
	// Token: 0x0401075D RID: 67421
	[UIProperty("智力", "+{0}", true)]
	baseInt,
	// Token: 0x0401075E RID: 67422
	[UIProperty("体力", "+{0}", true)]
	baseSta,
	// Token: 0x0401075F RID: 67423
	[UIProperty("独立攻击力", "+{0}", true)]
	baseIndependence,
	// Token: 0x04010760 RID: 67424
	[UIProperty("精神", "+{0}", true)]
	baseSpr,
	// Token: 0x04010761 RID: 67425
	[UIProperty("强化固定攻击力", "+{0}", true)]
	ingoreIndependence,
	// Token: 0x04010762 RID: 67426
	hpGrow,
	// Token: 0x04010763 RID: 67427
	mpGrow,
	// Token: 0x04010764 RID: 67428
	atkGrow,
	// Token: 0x04010765 RID: 67429
	intGrow,
	// Token: 0x04010766 RID: 67430
	staGrow,
	// Token: 0x04010767 RID: 67431
	sprGrow,
	// Token: 0x04010768 RID: 67432
	hardGrow,
	// Token: 0x04010769 RID: 67433
	sta,
	// Token: 0x0401076A RID: 67434
	spr,
	// Token: 0x0401076B RID: 67435
	resistMagic,
	// Token: 0x0401076C RID: 67436
	COUNT
}
