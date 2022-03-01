using System;

// Token: 0x02004472 RID: 17522
public class Skill1818 : BeSkill
{
	// Token: 0x060185CE RID: 99790 RVA: 0x00797325 File Offset: 0x00795725
	public Skill1818(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185CF RID: 99791 RVA: 0x00797350 File Offset: 0x00795750
	public override void OnInit()
	{
	}

	// Token: 0x060185D0 RID: 99792 RVA: 0x00797352 File Offset: 0x00795752
	public override void OnStart()
	{
		if (this.m_ReplaceSkillHandle != null)
		{
			this.m_ReplaceSkillHandle.Remove();
		}
		this.m_ReplaceSkillHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			BeBuff beBuff = base.owner.buffController.HasBuffByID(this.m_BuffId);
			if (array[0] == this.m_PhaseTwoId && beBuff != null)
			{
				array[0] = this.m_PhaseThreeId;
			}
		});
	}

	// Token: 0x04011965 RID: 72037
	protected int m_BuffId = 181101;

	// Token: 0x04011966 RID: 72038
	protected int m_PhaseTwoId = 18180;

	// Token: 0x04011967 RID: 72039
	protected int m_PhaseThreeId = 181801;

	// Token: 0x04011968 RID: 72040
	protected BeEventHandle m_ReplaceSkillHandle;
}
