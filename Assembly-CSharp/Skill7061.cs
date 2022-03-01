using System;

// Token: 0x020044FC RID: 17660
public class Skill7061 : BeSkill
{
	// Token: 0x06018935 RID: 100661 RVA: 0x007AD114 File Offset: 0x007AB514
	public Skill7061(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018936 RID: 100662 RVA: 0x007AD152 File Offset: 0x007AB552
	public override void OnInit()
	{
		this.m_TrapRadius = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
	}

	// Token: 0x06018937 RID: 100663 RVA: 0x007AD17C File Offset: 0x007AB57C
	public override void OnStart()
	{
		this.m_SpiderBornPoint = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().GetBirthPosition();
	}

	// Token: 0x06018938 RID: 100664 RVA: 0x007AD1A0 File Offset: 0x007AB5A0
	public override bool CanUseSkill()
	{
		VInt3 position = base.owner.GetPosition();
		int num = Math.Abs(position.x - this.m_SpiderBornPoint.x);
		int num2 = Math.Abs(position.y - this.m_SpiderBornPoint.y);
		int i = IntMath.Sqrt((long)(num * num + num2 * num2));
		return !(i <= this.m_TrapRadius);
	}

	// Token: 0x04011BAC RID: 72620
	protected VInt3 m_SpiderBornPoint = default(VInt3);

	// Token: 0x04011BAD RID: 72621
	protected VInt m_TrapRadius = VInt.one.i * 5;
}
