using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004327 RID: 17191
public class Mechanism159 : BeMechanism
{
	// Token: 0x06017C8F RID: 97423 RVA: 0x00757EB3 File Offset: 0x007562B3
	public Mechanism159(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C90 RID: 97424 RVA: 0x00757EE0 File Offset: 0x007562E0
	public override void OnInit()
	{
		this.damagePercent = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.buffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		this.textLastTime = (float)TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) / 1000f;
		if (this.data.StringValueA.Length > 0)
		{
			this.textInfo = this.data.StringValueA[0];
		}
	}

	// Token: 0x06017C91 RID: 97425 RVA: 0x00757FC0 File Offset: 0x007563C0
	public override void OnStart()
	{
		base.OnStart();
		this.damagePercentFactor = new VFactor((long)this.damagePercent, (long)GlobalLogic.VALUE_1000);
		this.handleA = base.owner.RegisterEvent(BeEventType.onHurt, delegate(object[] args)
		{
			this._CheckDamage((int)args[0]);
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.OnBuffDamage, delegate(object[] args)
		{
			this._CheckDamage((int)args[0]);
		});
	}

	// Token: 0x06017C92 RID: 97426 RVA: 0x0075802C File Offset: 0x0075642C
	private void _CheckDamage(int hurtValue)
	{
		int maxHP = base.owner.GetEntityData().GetMaxHP();
		this.damageValue += hurtValue;
		VFactor a = new VFactor((long)this.damageValue, (long)maxHP);
		if (a > this.damagePercentFactor)
		{
			this.AddBuffInfo();
			this.damageValue = 0;
			if (this.textInfo.Length > 0)
			{
				SystemNotifyManager.SysDungeonSkillTip(this.textInfo, this.textLastTime, false);
			}
		}
	}

	// Token: 0x06017C93 RID: 97427 RVA: 0x007580AC File Offset: 0x007564AC
	private void AddBuffInfo()
	{
		for (int i = 0; i < this.buffInfoIdList.Count; i++)
		{
			base.owner.buffController.TryAddBuff(this.buffInfoIdList[i], null, false, null, 0);
		}
	}

	// Token: 0x040111C0 RID: 70080
	protected int damagePercent;

	// Token: 0x040111C1 RID: 70081
	protected List<int> buffInfoIdList = new List<int>();

	// Token: 0x040111C2 RID: 70082
	protected int damageValue;

	// Token: 0x040111C3 RID: 70083
	protected VFactor damagePercentFactor = VFactor.zero;

	// Token: 0x040111C4 RID: 70084
	protected string textInfo = string.Empty;

	// Token: 0x040111C5 RID: 70085
	protected float textLastTime;
}
