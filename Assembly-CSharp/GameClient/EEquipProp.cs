using System;

namespace GameClient
{
	// Token: 0x020016C7 RID: 5831
	public enum EEquipProp
	{
		// Token: 0x04008997 RID: 35223
		Invalid = -1,
		// Token: 0x04008998 RID: 35224
		[Prop("物理攻击", "Atk", false)]
		PhysicsAttack,
		// Token: 0x04008999 RID: 35225
		[Prop("魔法攻击", "MagicAtk", false)]
		MagicAttack,
		// Token: 0x0400899A RID: 35226
		[Prop("物理防御", "Def", false)]
		PhysicsDefense,
		// Token: 0x0400899B RID: 35227
		[Prop("魔法防御", "MagicDef", false)]
		MagicDefense,
		// Token: 0x0400899C RID: 35228
		[Prop("力量", "Strenth", false)]
		Strenth,
		// Token: 0x0400899D RID: 35229
		[Prop("智力", "Intellect", false)]
		Intellect,
		// Token: 0x0400899E RID: 35230
		[Prop("精神", "Spirit", false)]
		Spirit,
		// Token: 0x0400899F RID: 35231
		[Prop("体力", "Stamina", false)]
		Stamina,
		// Token: 0x040089A0 RID: 35232
		[Prop("物理技能耗蓝", "PhySkillMp", true)]
		PhysicsSkillMPChange,
		// Token: 0x040089A1 RID: 35233
		[Prop("物理技能冷却", "PhySkillCd", true)]
		PhysicsSkillCDChange,
		// Token: 0x040089A2 RID: 35234
		[Prop("魔法技能耗蓝", "MagSkillMp", true)]
		MagicSkillMPChange,
		// Token: 0x040089A3 RID: 35235
		[Prop("魔法技能冷却", "MagSkillCd", true)]
		MagicSkillCDChange,
		// Token: 0x040089A4 RID: 35236
		[Prop("生命最大值", "HPMax", false)]
		HPMax,
		// Token: 0x040089A5 RID: 35237
		[Prop("魔力最大值", "MPMax", false)]
		MPMax,
		// Token: 0x040089A6 RID: 35238
		[Prop("生命恢复", "HPRecover", false)]
		HPRecover,
		// Token: 0x040089A7 RID: 35239
		[Prop("魔力恢复", "MPRecover", false)]
		MPRecover,
		// Token: 0x040089A8 RID: 35240
		[Prop("攻速等级", "AttackSpeedRate", false)]
		AttackSpeedRate,
		// Token: 0x040089A9 RID: 35241
		[Prop("施法等级", "FireSpeedRate", false)]
		FireSpeedRate,
		// Token: 0x040089AA RID: 35242
		[Prop("移速等级", "MoveSpeedRate", false)]
		MoveSpeedRate,
		// Token: 0x040089AB RID: 35243
		[Prop("所有异常状态抗性", "AbormalResist", false)]
		AbormalResist,
		// Token: 0x040089AC RID: 35244
		[Prop("各种异常状态抗性", "AbormalResists", false)]
		AbormalResists,
		// Token: 0x040089AD RID: 35245
		[Prop("攻击附带属性", "Elements", false)]
		Elements,
		// Token: 0x040089AE RID: 35246
		[Prop("光属性强化", "LightAttack", false)]
		LightAttack,
		// Token: 0x040089AF RID: 35247
		[Prop("火属性强化", "FireAttack", false)]
		FireAttack,
		// Token: 0x040089B0 RID: 35248
		[Prop("冰属性强化", "IceAttack", false)]
		IceAttack,
		// Token: 0x040089B1 RID: 35249
		[Prop("暗属性强化", "DarkAttack", false)]
		DarkAttack,
		// Token: 0x040089B2 RID: 35250
		[Prop("光属性抗性", "LightDefence", false)]
		LightDefence,
		// Token: 0x040089B3 RID: 35251
		[Prop("火属性抗性", "FireDefence", false)]
		FireDefence,
		// Token: 0x040089B4 RID: 35252
		[Prop("冰属性抗性", "IceDefence", false)]
		IceDefence,
		// Token: 0x040089B5 RID: 35253
		[Prop("暗属性抗性", "DarkDefence", false)]
		DarkDefence,
		// Token: 0x040089B6 RID: 35254
		[Prop("命中等级", "HitRate", false)]
		HitRate,
		// Token: 0x040089B7 RID: 35255
		[Prop("闪避等级", "AvoidRate", false)]
		AvoidRate,
		// Token: 0x040089B8 RID: 35256
		[Prop("物暴等级", "PhysicCrit", false)]
		PhysicCritRate,
		// Token: 0x040089B9 RID: 35257
		[Prop("魔暴等级", "MagicCrit", false)]
		MagicCritRate,
		// Token: 0x040089BA RID: 35258
		[Prop("硬直", "Spasticity", false)]
		Spasticity,
		// Token: 0x040089BB RID: 35259
		[Prop("跳跃力", "Jump", false)]
		Jump,
		// Token: 0x040089BC RID: 35260
		[Prop("城镇移速等级", "TownMoveSpeedRate", false)]
		TownMoveSpeedRate,
		// Token: 0x040089BD RID: 35261
		[Prop("无视防御物攻", "", false)]
		IgnorePhysicsAttackRate,
		// Token: 0x040089BE RID: 35262
		[Prop("无视防御魔攻", "", false)]
		IgnoreMagicAttackRate,
		// Token: 0x040089BF RID: 35263
		[Prop("无视防御物攻", "", false)]
		IgnorePhysicsAttack,
		// Token: 0x040089C0 RID: 35264
		[Prop("无视防御魔攻", "", false)]
		IgnoreMagicAttack,
		// Token: 0x040089C1 RID: 35265
		[Prop("物理伤害减少", "", true)]
		IgnorePhysicsDefenseRate,
		// Token: 0x040089C2 RID: 35266
		[Prop("魔法伤害减少", "", true)]
		IgnoreMagicDefenseRate,
		// Token: 0x040089C3 RID: 35267
		[Prop("物理伤害减少", "", true)]
		IgnorePhysicsDefense,
		// Token: 0x040089C4 RID: 35268
		[Prop("魔法伤害减少", "", true)]
		IgnoreMagicDefense,
		// Token: 0x040089C5 RID: 35269
		[Prop("感电抗性", "abnormalResist1", false)]
		abnormalResist1,
		// Token: 0x040089C6 RID: 35270
		[Prop("出血抗性", "abnormalResist2", false)]
		abnormalResist2,
		// Token: 0x040089C7 RID: 35271
		[Prop("灼烧抗性", "abnormalResist3", false)]
		abnormalResist3,
		// Token: 0x040089C8 RID: 35272
		[Prop("中毒抗性", "abnormalResist4", false)]
		abnormalResist4,
		// Token: 0x040089C9 RID: 35273
		[Prop("失明抗性", "abnormalResist5", false)]
		abnormalResist5,
		// Token: 0x040089CA RID: 35274
		[Prop("眩晕抗性", "abnormalResist6", false)]
		abnormalResist6,
		// Token: 0x040089CB RID: 35275
		[Prop("石化抗性", "abnormalResist7", false)]
		abnormalResist7,
		// Token: 0x040089CC RID: 35276
		[Prop("冰冻抗性", "abnormalResist8", false)]
		abnormalResist8,
		// Token: 0x040089CD RID: 35277
		[Prop("睡眠抗性", "abnormalResist9", false)]
		abnormalResist9,
		// Token: 0x040089CE RID: 35278
		[Prop("混乱抗性", "abnormalResist10", false)]
		abnormalResist10,
		// Token: 0x040089CF RID: 35279
		[Prop("束缚抗性", "abnormalResist11", false)]
		abnormalResist11,
		// Token: 0x040089D0 RID: 35280
		[Prop("减速抗性", "abnormalResist12", false)]
		abnormalResist12,
		// Token: 0x040089D1 RID: 35281
		[Prop("诅咒抗性", "abnormalResist13", false)]
		abnormalResist13,
		// Token: 0x040089D2 RID: 35282
		[Prop("侵蚀抗性", "ResistMagic", false)]
		resistMagic,
		// Token: 0x040089D3 RID: 35283
		[Prop("固定攻击", "Independce", false)]
		Independence,
		// Token: 0x040089D4 RID: 35284
		[Prop("固定攻击", "", false)]
		IngoreIndependence,
		// Token: 0x040089D5 RID: 35285
		Count
	}
}
