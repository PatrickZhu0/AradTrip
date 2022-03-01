using System;
using System.Collections.Generic;

// Token: 0x02004103 RID: 16643
public class BDAddBuffInfoOrBuff : BDEventBase
{
	// Token: 0x06016A75 RID: 92789 RVA: 0x006DDC52 File Offset: 0x006DC052
	public BDAddBuffInfoOrBuff(int bid, List<int> bufInfoList, int d, bool phaseDelete, bool finishDeleteAll, int lv, bool lvBySkill)
	{
		this.buffID = bid;
		this.buffInfoList = bufInfoList;
		this.buffTime = d;
		this.phaseDelete = phaseDelete;
		this.finishDeleteAll = finishDeleteAll;
		this.level = lv;
		this.levelBySkill = lvBySkill;
	}

	// Token: 0x06016A76 RID: 92790 RVA: 0x006DDC90 File Offset: 0x006DC090
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		BeActor beActor = pkEntity as BeActor;
		if (beActor != null)
		{
			BeSkill curSkill = beActor.GetCurSkill();
			if (curSkill != null && this.levelBySkill)
			{
				this.level = curSkill.level;
			}
			List<BeBuff> list = new List<BeBuff>();
			list.Add(beActor.buffController.TryAddBuff(this.buffID, this.buffTime, this.level));
			for (int i = 0; i < this.buffInfoList.Count; i++)
			{
				list.Add(beActor.buffController.TryAddBuff(this.buffInfoList[i], null, false, null, this.level));
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j] != null && this.phaseDelete)
				{
					beActor.buffController.AddPhaseDelete(list[j]);
				}
				if (list[j] != null && this.finishDeleteAll)
				{
					beActor.buffController.AddFinishDeleteAll(list[j]);
				}
			}
		}
	}

	// Token: 0x04010266 RID: 66150
	private int buffTime;

	// Token: 0x04010267 RID: 66151
	private int buffID;

	// Token: 0x04010268 RID: 66152
	private List<int> buffInfoList;

	// Token: 0x04010269 RID: 66153
	private bool phaseDelete;

	// Token: 0x0401026A RID: 66154
	private bool finishDeleteAll;

	// Token: 0x0401026B RID: 66155
	private int level;

	// Token: 0x0401026C RID: 66156
	private bool levelBySkill;
}
