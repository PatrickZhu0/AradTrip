using System;
using System.Collections.Generic;

// Token: 0x020042AD RID: 17069
public class Mechanism1116 : BeMechanism
{
	// Token: 0x060179D3 RID: 96723 RVA: 0x0074653A File Offset: 0x0074493A
	public Mechanism1116(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179D4 RID: 96724 RVA: 0x0074655C File Offset: 0x0074495C
	public override void OnInit()
	{
		if (this.data.ValueA.Count != this.data.ValueB.Count || this.data.ValueA.Count != this.data.ValueC.Count)
		{
			Logger.LogError("1116配置文件，参数配置数量错误");
		}
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			Mechanism1116.ComboPrecentBuff item = default(Mechanism1116.ComboPrecentBuff);
			item.combo = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			item.buffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			item.precent = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			this.m_comboList.Add(item);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.m_TriggerCD = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
	}

	// Token: 0x060179D5 RID: 96725 RVA: 0x007466AB File Offset: 0x00744AAB
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOtherAfterHurt, new BeEventHandle.Del(this.OnHit));
	}

	// Token: 0x060179D6 RID: 96726 RVA: 0x007466CC File Offset: 0x00744ACC
	private void OnHit(object[] arges)
	{
		if (base.owner == null)
		{
			return;
		}
		if (base.owner.actorData == null)
		{
			return;
		}
		if (this.m_TriggerCD > 0 && this.m_CD.IsCD())
		{
			return;
		}
		if (this.m_TriggerCD > 0)
		{
			this.m_CD.StartCD(this.m_TriggerCD);
		}
		for (int i = this.m_comboList.Count - 1; i >= 0; i--)
		{
			Mechanism1116.ComboPrecentBuff comboPrecentBuff = this.m_comboList[i];
			if (comboPrecentBuff.combo <= base.owner.actorData.GetCurComboCount())
			{
				if ((int)base.FrameRandom.Range1000() <= comboPrecentBuff.precent)
				{
					base.owner.buffController.TryAddBuffInfo(comboPrecentBuff.buffInfoId, base.owner, this.level);
				}
				return;
			}
		}
	}

	// Token: 0x060179D7 RID: 96727 RVA: 0x007467B8 File Offset: 0x00744BB8
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_TriggerCD > 0)
		{
			this.m_CD.UpdateCD(deltaTime);
		}
	}

	// Token: 0x04010F8F RID: 69519
	private List<Mechanism1116.ComboPrecentBuff> m_comboList = new List<Mechanism1116.ComboPrecentBuff>();

	// Token: 0x04010F90 RID: 69520
	private int m_TriggerCD;

	// Token: 0x04010F91 RID: 69521
	private CoolDown m_CD = new CoolDown();

	// Token: 0x020042AE RID: 17070
	private struct ComboPrecentBuff
	{
		// Token: 0x04010F92 RID: 69522
		public int combo;

		// Token: 0x04010F93 RID: 69523
		public int buffInfoId;

		// Token: 0x04010F94 RID: 69524
		public int precent;
	}
}
