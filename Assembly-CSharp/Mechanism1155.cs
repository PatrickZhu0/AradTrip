using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020042CB RID: 17099
public class Mechanism1155 : BeMechanism
{
	// Token: 0x06017A92 RID: 96914 RVA: 0x0074AA7C File Offset: 0x00748E7C
	public Mechanism1155(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017A93 RID: 96915 RVA: 0x0074AA9C File Offset: 0x00748E9C
	public override void OnInit()
	{
		base.OnInit();
		this._buffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017A94 RID: 96916 RVA: 0x0074AACC File Offset: 0x00748ECC
	public override void OnStart()
	{
		base.OnStart();
		this.InitSummonerMonster();
		this._registerEvent();
	}

	// Token: 0x06017A95 RID: 96917 RVA: 0x0074AAE0 File Offset: 0x00748EE0
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveBuffInfo();
	}

	// Token: 0x06017A96 RID: 96918 RVA: 0x0074AAF0 File Offset: 0x00748EF0
	private void InitSummonerMonster()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.GetSummonBySummoner(list, base.owner, false, true);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			if (beActor.GetPID() != base.owner.GetPID())
			{
				if (!this._actorList.Contains(beActor))
				{
					this._actorList.Add(beActor);
					beActor.buffController.TryAddBuff(this._buffId, this._buffTime, 1);
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017A97 RID: 96919 RVA: 0x0074ABA9 File Offset: 0x00748FA9
	private void _registerEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this._OnSummon));
	}

	// Token: 0x06017A98 RID: 96920 RVA: 0x0074ABCC File Offset: 0x00748FCC
	private void _OnSummon(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null || !beActor.IsSummonMonster())
		{
			return;
		}
		if (this._actorList.Contains(beActor))
		{
			return;
		}
		this._actorList.Add(beActor);
		beActor.buffController.TryAddBuff(this._buffId, this._buffTime, 1);
	}

	// Token: 0x06017A99 RID: 96921 RVA: 0x0074AC2C File Offset: 0x0074902C
	private void RemoveBuffInfo()
	{
		for (int i = 0; i < this._actorList.Count; i++)
		{
			BeActor beActor = this._actorList[i];
			if (beActor != null && !beActor.IsDeadOrRemoved())
			{
				beActor.buffController.RemoveBuff(this._buffId, 0, 0);
			}
		}
	}

	// Token: 0x0401100C RID: 69644
	private int _buffId;

	// Token: 0x0401100D RID: 69645
	private int _buffTime = int.MaxValue;

	// Token: 0x0401100E RID: 69646
	private List<BeActor> _actorList = new List<BeActor>();
}
