using System;
using System.Collections.Generic;

// Token: 0x02004389 RID: 17289
public class Mechanism2081 : BeMechanism
{
	// Token: 0x06017F92 RID: 98194 RVA: 0x0076D4E3 File Offset: 0x0076B8E3
	public Mechanism2081(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F93 RID: 98195 RVA: 0x0076D500 File Offset: 0x0076B900
	public override void OnInit()
	{
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skillIdList.Clear();
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.skillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		this.removeBuffFlag = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 0);
	}

	// Token: 0x06017F94 RID: 98196 RVA: 0x0076D5C4 File Offset: 0x0076B9C4
	public override void OnStart()
	{
		this.saveAddBuff = null;
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this.OnSkillStart));
			this.handleB = base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this.OnSkillEnd));
			this.handleC = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.OnSkillEnd));
		}
	}

	// Token: 0x06017F95 RID: 98197 RVA: 0x0076D640 File Offset: 0x0076BA40
	public override void OnFinish()
	{
		this.saveAddBuff = null;
	}

	// Token: 0x06017F96 RID: 98198 RVA: 0x0076D64C File Offset: 0x0076BA4C
	private void OnSkillStart(object[] args)
	{
		if (args.Length > 0)
		{
			int item = (int)args[0];
			if (this.skillIdList.Contains(item))
			{
				if (this.removeBuffFlag)
				{
					this.saveAddBuff = base.owner.buffController.TryAddBuff(this.buffId, -1, this.level);
				}
				else
				{
					base.owner.buffController.RemoveBuff(this.buffId, 0, 0);
				}
			}
		}
	}

	// Token: 0x06017F97 RID: 98199 RVA: 0x0076D6CC File Offset: 0x0076BACC
	private void OnSkillEnd(object[] args)
	{
		if (args.Length > 0)
		{
			int item = (int)args[0];
			if (this.skillIdList.Contains(item))
			{
				if (this.removeBuffFlag)
				{
					if (this.saveAddBuff != null)
					{
						base.owner.buffController.RemoveBuff(this.saveAddBuff);
					}
				}
				else
				{
					base.owner.buffController.TryAddBuff(this.buffId, -1, this.level);
				}
			}
		}
	}

	// Token: 0x0401142E RID: 70702
	private int buffId = 38;

	// Token: 0x0401142F RID: 70703
	private List<int> skillIdList = new List<int>();

	// Token: 0x04011430 RID: 70704
	private bool removeBuffFlag;

	// Token: 0x04011431 RID: 70705
	private BeBuff saveAddBuff;
}
