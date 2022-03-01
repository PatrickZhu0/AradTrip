using System;

// Token: 0x0200447B RID: 17531
public class Skill20179 : BeSkill
{
	// Token: 0x06018605 RID: 99845 RVA: 0x007986E8 File Offset: 0x00796AE8
	public Skill20179(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018606 RID: 99846 RVA: 0x00798714 File Offset: 0x00796B14
	public override void OnInit()
	{
		base.OnInit();
		this.speedX = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.speedY = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x06018607 RID: 99847 RVA: 0x00798778 File Offset: 0x00796B78
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 2)
		{
			base.owner.SetMoveSpeedX((!base.owner.GetFace()) ? this.speedX : (-this.speedX));
			base.owner.SetMoveSpeedY((!base.owner.GetFace()) ? this.speedY : (-this.speedY));
		}
	}

	// Token: 0x04011985 RID: 72069
	private VInt speedX = 70000;

	// Token: 0x04011986 RID: 72070
	private VInt speedY = 70000;
}
