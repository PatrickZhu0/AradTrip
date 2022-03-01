using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004346 RID: 17222
public class Mechanism2016 : BeMechanism
{
	// Token: 0x06017D76 RID: 97654 RVA: 0x0075E134 File Offset: 0x0075C534
	public Mechanism2016(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D77 RID: 97655 RVA: 0x0075E154 File Offset: 0x0075C554
	public override void OnInit()
	{
		base.OnInit();
		this.singleHurtRate = new VFactor((long)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), (long)GlobalLogic.VALUE_1000);
		this.totalHurtMaxLimit = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017D78 RID: 97656 RVA: 0x0075E1C3 File Offset: 0x0075C5C3
	public override void OnStart()
	{
		base.OnStart();
		this.SetEquipAdd();
		this.RegisterHurtEvent();
	}

	// Token: 0x06017D79 RID: 97657 RVA: 0x0075E1D7 File Offset: 0x0075C5D7
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandle();
	}

	// Token: 0x06017D7A RID: 97658 RVA: 0x0075E1E8 File Offset: 0x0075C5E8
	private void RegisterHurtEvent()
	{
		if (base.owner == null)
		{
			return;
		}
		List<BeActor> list = new List<BeActor>();
		BeUtility.GetAllFriendPlayers(base.owner, list);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				BeActor actor = list[i];
				if (actor != base.owner)
				{
					BeEventHandle item = actor.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, delegate(object[] args)
					{
						int[] array = (int[])args[0];
						int hurtId = (int)args[1];
						if (array[0] == 0)
						{
							return;
						}
						if (!BeUtility.NeedShareBySGSH(hurtId, actor))
						{
							return;
						}
						int num = array[0] * this.singleHurtRate;
						if (this.totalHurtValue + num < this.totalHurtMaxLimit)
						{
							this.totalHurtValue += num;
							array[0] -= num;
							this.owner.DoHurt(num, null, HitTextType.NORMAL, null, HitTextType.FRIEND_HURT, false);
						}
					});
					this.handleList.Add(item);
				}
			}
		}
	}

	// Token: 0x06017D7B RID: 97659 RVA: 0x0075E284 File Offset: 0x0075C684
	private void RemoveHandle()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x06017D7C RID: 97660 RVA: 0x0075E2E8 File Offset: 0x0075C6E8
	private void SetEquipAdd()
	{
		BeActor attachBuffReleaser = base.GetAttachBuffReleaser();
		if (attachBuffReleaser == null)
		{
			return;
		}
		List<BeMechanism> mechanismList = attachBuffReleaser.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		for (int i = 0; i < mechanismList.Count; i++)
		{
			Mechanism2026 mechanism = mechanismList[i] as Mechanism2026;
			if (mechanism != null)
			{
				this.totalHurtMaxLimit *= VFactor.one + mechanism.singleHurtRateAdd;
			}
		}
	}

	// Token: 0x04011285 RID: 70277
	private VFactor singleHurtRate = VFactor.zero;

	// Token: 0x04011286 RID: 70278
	private int totalHurtMaxLimit;

	// Token: 0x04011287 RID: 70279
	private int totalHurtValue;

	// Token: 0x04011288 RID: 70280
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
