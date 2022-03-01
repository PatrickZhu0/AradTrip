using System;

namespace GameClient
{
	// Token: 0x020016C3 RID: 5827
	public enum EServerProp
	{
		// Token: 0x0400895F RID: 35167
		IRP_NONE,
		// Token: 0x04008960 RID: 35168
		[MapEnum(EEquipProp.Strenth)]
		IRP_STR,
		// Token: 0x04008961 RID: 35169
		[MapEnum(EEquipProp.Stamina)]
		IRP_STA,
		// Token: 0x04008962 RID: 35170
		[MapEnum(EEquipProp.Intellect)]
		IRP_INT,
		// Token: 0x04008963 RID: 35171
		[MapEnum(EEquipProp.Spirit)]
		IRP_SPR,
		// Token: 0x04008964 RID: 35172
		[MapEnum(EEquipProp.HPMax)]
		IRP_HPMAX,
		// Token: 0x04008965 RID: 35173
		[MapEnum(EEquipProp.MPMax)]
		IRP_MPMAX,
		// Token: 0x04008966 RID: 35174
		[MapEnum(EEquipProp.HPRecover)]
		IRP_HPREC,
		// Token: 0x04008967 RID: 35175
		[MapEnum(EEquipProp.MPRecover)]
		IRP_MPREC,
		// Token: 0x04008968 RID: 35176
		[MapEnum(EEquipProp.HitRate)]
		IRP_HIT,
		// Token: 0x04008969 RID: 35177
		[MapEnum(EEquipProp.AvoidRate)]
		IRP_DEX,
		// Token: 0x0400896A RID: 35178
		[MapEnum(EEquipProp.PhysicCritRate)]
		IRP_PHYCRT,
		// Token: 0x0400896B RID: 35179
		[MapEnum(EEquipProp.MagicCritRate)]
		IRP_MGCCRT,
		// Token: 0x0400896C RID: 35180
		[MapEnum(EEquipProp.AttackSpeedRate)]
		IRP_ATKSPD,
		// Token: 0x0400896D RID: 35181
		[MapEnum(EEquipProp.FireSpeedRate)]
		IRP_RDYSPD,
		// Token: 0x0400896E RID: 35182
		[MapEnum(EEquipProp.MoveSpeedRate)]
		IRP_MOVSPD,
		// Token: 0x0400896F RID: 35183
		[MapEnum(EEquipProp.Jump)]
		IRP_JUMP,
		// Token: 0x04008970 RID: 35184
		[MapEnum(EEquipProp.Spasticity)]
		IRP_HITREC,
		// Token: 0x04008971 RID: 35185
		IRP_LIGHT = 22,
		// Token: 0x04008972 RID: 35186
		IRP_FIRE,
		// Token: 0x04008973 RID: 35187
		IRP_ICE,
		// Token: 0x04008974 RID: 35188
		IRP_DARK,
		// Token: 0x04008975 RID: 35189
		[MapEnum(EEquipProp.LightAttack)]
		IRP_LIGHT_ATK,
		// Token: 0x04008976 RID: 35190
		[MapEnum(EEquipProp.FireAttack)]
		IRP_FIRE_ATK,
		// Token: 0x04008977 RID: 35191
		[MapEnum(EEquipProp.IceAttack)]
		IRP_ICE_ATK,
		// Token: 0x04008978 RID: 35192
		[MapEnum(EEquipProp.DarkAttack)]
		IRP_DARK_ATK,
		// Token: 0x04008979 RID: 35193
		[MapEnum(EEquipProp.LightDefence)]
		IRP_LIGHT_DEF,
		// Token: 0x0400897A RID: 35194
		[MapEnum(EEquipProp.FireDefence)]
		IRP_FIRE_DEF,
		// Token: 0x0400897B RID: 35195
		[MapEnum(EEquipProp.IceDefence)]
		IRP_ICE_DEF,
		// Token: 0x0400897C RID: 35196
		[MapEnum(EEquipProp.DarkDefence)]
		IRP_DARK_DEF,
		// Token: 0x0400897D RID: 35197
		[MapEnum(EEquipProp.abnormalResist1)]
		IRP_GDKX,
		// Token: 0x0400897E RID: 35198
		[MapEnum(EEquipProp.abnormalResist2)]
		IRP_CXKX,
		// Token: 0x0400897F RID: 35199
		[MapEnum(EEquipProp.abnormalResist3)]
		IRP_ZSKX,
		// Token: 0x04008980 RID: 35200
		[MapEnum(EEquipProp.abnormalResist4)]
		IRP_ZDKX,
		// Token: 0x04008981 RID: 35201
		[MapEnum(EEquipProp.abnormalResist5)]
		IRP_SMKX,
		// Token: 0x04008982 RID: 35202
		[MapEnum(EEquipProp.abnormalResist6)]
		IRP_XYKX,
		// Token: 0x04008983 RID: 35203
		[MapEnum(EEquipProp.abnormalResist7)]
		IRP_SHKX,
		// Token: 0x04008984 RID: 35204
		[MapEnum(EEquipProp.abnormalResist8)]
		IRP_BDKX,
		// Token: 0x04008985 RID: 35205
		[MapEnum(EEquipProp.abnormalResist9)]
		IRP_SLKX,
		// Token: 0x04008986 RID: 35206
		[MapEnum(EEquipProp.abnormalResist10)]
		IRP_HLKX,
		// Token: 0x04008987 RID: 35207
		[MapEnum(EEquipProp.abnormalResist11)]
		IRP_SFKX,
		// Token: 0x04008988 RID: 35208
		[MapEnum(EEquipProp.abnormalResist12)]
		IRP_JSKX,
		// Token: 0x04008989 RID: 35209
		[MapEnum(EEquipProp.abnormalResist13)]
		IRP_ZZKX,
		// Token: 0x0400898A RID: 35210
		[MapEnum(EEquipProp.AbormalResist)]
		IRP_YKXZ,
		// Token: 0x0400898B RID: 35211
		[MapEnum(EEquipProp.Independence)]
		IRP_INDEPENDENCE,
		// Token: 0x0400898C RID: 35212
		IRP_MAX
	}
}
