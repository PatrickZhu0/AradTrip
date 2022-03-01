using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x0200439F RID: 17311
public class Mechanism2104 : BeMechanism
{
	// Token: 0x0601800C RID: 98316 RVA: 0x00770DF0 File Offset: 0x0076F1F0
	public Mechanism2104(int id, int level) : base(id, level)
	{
	}

	// Token: 0x0601800D RID: 98317 RVA: 0x00770E10 File Offset: 0x0076F210
	public override void OnInit()
	{
		this.mListenSkillIds.Clear();
		this.mReplaceRuneNums.Clear();
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.mListenSkillIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Length; j++)
		{
			this.mReplaceRuneNums.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
	}

	// Token: 0x0601800E RID: 98318 RVA: 0x00770ECF File Offset: 0x0076F2CF
	public override void OnStart()
	{
		this.RegistEvent();
	}

	// Token: 0x0601800F RID: 98319 RVA: 0x00770ED8 File Offset: 0x0076F2D8
	protected void RegistEvent()
	{
		if (this.mListenSkillIds.Count != this.mReplaceRuneNums.Count)
		{
			return;
		}
		if (base.owner != null)
		{
			this.handleNewA = base.owner.RegisterEventNew(BeEventType.onCalcRuneAddDamage, new BeEvent.BeEventHandleNew.Function(this.OnCalcAddDamageEvent));
		}
	}

	// Token: 0x06018010 RID: 98320 RVA: 0x00770F30 File Offset: 0x0076F330
	protected void OnCalcAddDamageEvent(BeEvent.BeEventParam param)
	{
		int num = this.mListenSkillIds.IndexOf(param.m_Int);
		if (num >= 0 && num < this.mReplaceRuneNums.Count)
		{
			param.m_Int2 = this.mReplaceRuneNums[num];
		}
	}

	// Token: 0x040114A1 RID: 70817
	protected List<int> mListenSkillIds = new List<int>();

	// Token: 0x040114A2 RID: 70818
	protected List<int> mReplaceRuneNums = new List<int>();
}
