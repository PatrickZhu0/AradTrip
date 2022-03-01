using System;

// Token: 0x02004492 RID: 17554
public class Skill2200 : BeSkill
{
	// Token: 0x0601867A RID: 99962 RVA: 0x0079C30A File Offset: 0x0079A70A
	public Skill2200(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601867B RID: 99963 RVA: 0x0079C32A File Offset: 0x0079A72A
	public override void OnInit()
	{
		this.m_EffectOffset = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
	}

	// Token: 0x0601867C RID: 99964 RVA: 0x0079C350 File Offset: 0x0079A750
	public override void OnStart()
	{
		int num = this.m_EffectOffset * GlobalLogic.VALUE_10;
		this.effectOffset = ((!base.owner.GetFace()) ? num : (-num));
	}

	// Token: 0x0601867D RID: 99965 RVA: 0x0079C388 File Offset: 0x0079A788
	public override void OnFinish()
	{
		BeBuff beBuff = base.owner.buffController.HasBuffByID(this.m_BuffId);
		if (beBuff != null)
		{
			base.owner.buffController.RemoveBuff(beBuff);
		}
	}

	// Token: 0x040119CD RID: 72141
	protected int m_EffectOffset = 2000;

	// Token: 0x040119CE RID: 72142
	protected int m_BuffId = 220001;
}
