using System;
using GameClient;

// Token: 0x020042D9 RID: 17113
public class Mechanism1164 : BeMechanism
{
	// Token: 0x06017ADE RID: 96990 RVA: 0x0074C567 File Offset: 0x0074A967
	public Mechanism1164(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017ADF RID: 96991 RVA: 0x0074C57C File Offset: 0x0074A97C
	public override void OnInit()
	{
		this.mCountDownTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017AE0 RID: 96992 RVA: 0x0074C5A6 File Offset: 0x0074A9A6
	public override void OnStart()
	{
		this.InitUI();
		this.SetUIBarData();
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, new BeEventHandle.Del(this.OnMonsterHpChangeEvent));
		}
	}

	// Token: 0x06017AE1 RID: 96993 RVA: 0x0074C5DE File Offset: 0x0074A9DE
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateCountDown(deltaTime);
	}

	// Token: 0x06017AE2 RID: 96994 RVA: 0x0074C5E7 File Offset: 0x0074A9E7
	public override void OnFinish()
	{
		this.DeInitUI();
	}

	// Token: 0x06017AE3 RID: 96995 RVA: 0x0074C5EF File Offset: 0x0074A9EF
	protected void OnMonsterHpChangeEvent(object[] args)
	{
		this.SetUIBarData();
	}

	// Token: 0x06017AE4 RID: 96996 RVA: 0x0074C5F7 File Offset: 0x0074A9F7
	protected void InitUI()
	{
		this.m_Battle = (Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle);
		this.ShowUIBar(true);
	}

	// Token: 0x06017AE5 RID: 96997 RVA: 0x0074C615 File Offset: 0x0074AA15
	protected void DeInitUI()
	{
		this.ShowUIBar(false);
		this.m_Battle = null;
	}

	// Token: 0x06017AE6 RID: 96998 RVA: 0x0074C625 File Offset: 0x0074AA25
	protected void ShowUIBar(bool show)
	{
		if (this.m_Battle != null)
		{
			this.m_Battle.ShowDamageBar(show);
		}
	}

	// Token: 0x06017AE7 RID: 96999 RVA: 0x0074C640 File Offset: 0x0074AA40
	protected void SetUIBarData()
	{
		if (this.m_Battle != null && base.owner != null && base.owner.GetEntityData() != null)
		{
			this.m_Battle.ChangeDamageData((float)base.owner.GetEntityData().GetHP(), (float)base.owner.GetEntityData().GetMaxHP(), true);
		}
	}

	// Token: 0x06017AE8 RID: 97000 RVA: 0x0074C6A4 File Offset: 0x0074AAA4
	protected void UpdateCountDown(int deltaTime)
	{
		this.mCountDownTime -= deltaTime;
		int num = this.mCountDownTime / 1000;
		if (num == this.mAccCountTime)
		{
			return;
		}
		this.mAccCountTime = num;
		if (this.m_Battle != null)
		{
			this.m_Battle.ChangeCountDown(this.mAccCountTime);
		}
		if (this.mCountDownTime <= 0)
		{
			this.RemoveThisMechanism();
		}
	}

	// Token: 0x06017AE9 RID: 97001 RVA: 0x0074C70E File Offset: 0x0074AB0E
	protected void RemoveThisMechanism()
	{
		base.Finish();
	}

	// Token: 0x0401104D RID: 69709
	protected int mCountDownTime;

	// Token: 0x0401104E RID: 69710
	private ClientSystemBattle m_Battle;

	// Token: 0x0401104F RID: 69711
	private int mAccCountTime = int.MinValue;
}
