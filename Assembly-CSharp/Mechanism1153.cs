using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020042C9 RID: 17097
public class Mechanism1153 : BeMechanism
{
	// Token: 0x06017A87 RID: 96903 RVA: 0x0074A629 File Offset: 0x00748A29
	public Mechanism1153(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017A88 RID: 96904 RVA: 0x0074A633 File Offset: 0x00748A33
	public override void OnInit()
	{
		this.mReAddRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017A89 RID: 96905 RVA: 0x0074A660 File Offset: 0x00748A60
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleNewA = base.owner.RegisterEventNew(BeEventType.OnConsumeRune, new BeEvent.BeEventHandleNew.Function(this.OnConsumeRuneEvent));
			this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.OnSkillFinish));
		}
	}

	// Token: 0x06017A8A RID: 96906 RVA: 0x0074A6B6 File Offset: 0x00748AB6
	private void OnConsumeRuneEvent(BeEvent.BeEventParam _eventParam)
	{
		if ((int)base.FrameRandom.Range1000() > this.mReAddRate)
		{
			return;
		}
		_eventParam.m_Bool = true;
	}

	// Token: 0x06017A8B RID: 96907 RVA: 0x0074A6D8 File Offset: 0x00748AD8
	private void OnSkillFinish(object[] args)
	{
		int num = (int)args[0];
		if (num == 1717)
		{
			this.SetRunEffect();
		}
	}

	// Token: 0x06017A8C RID: 96908 RVA: 0x0074A700 File Offset: 0x00748B00
	private void SetRunEffect()
	{
		if (base.owner != null)
		{
			Skill1710 skill = base.owner.GetSkill(1710) as Skill1710;
			if (skill != null)
			{
				this.runeManager = skill.runeManager;
			}
		}
		if (this.runeManager == null)
		{
			return;
		}
		List<Rune> runeList = this.runeManager.getRuneList();
		for (int i = 0; i < runeList.Count; i++)
		{
			if (runeList[i] != null && runeList[i].effectRune != null)
			{
				runeList[i].effectRune.SetVisible(true);
			}
		}
		this.runeManager.RepositionRunes(true);
	}

	// Token: 0x04011006 RID: 69638
	private int mReAddRate;

	// Token: 0x04011007 RID: 69639
	public Mechanism22 runeManager;
}
