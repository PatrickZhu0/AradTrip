using System;

// Token: 0x02004489 RID: 17545
public class Skill7274 : Skill2112
{
	// Token: 0x06018637 RID: 99895 RVA: 0x0079A2D1 File Offset: 0x007986D1
	public Skill7274(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018638 RID: 99896 RVA: 0x0079A2DC File Offset: 0x007986DC
	public override void OnInit()
	{
		this.distancex = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true), GlobalLogic.VALUE_1000);
		this.distancey = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true), GlobalLogic.VALUE_1000);
		this.effectPath = "Effects/Monster_Renzhe/Prefab/Eff_renzhe_yanwu";
		this.isCreatePoppet = false;
	}
}
