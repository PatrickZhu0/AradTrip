using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004334 RID: 17204
public class Mechanism2000 : BeMechanism
{
	// Token: 0x06017CCE RID: 97486 RVA: 0x00759684 File Offset: 0x00757A84
	public Mechanism2000(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CCF RID: 97487 RVA: 0x007596BC File Offset: 0x00757ABC
	public override void OnInit()
	{
		base.OnInit();
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Count; i++)
			{
				this.reduceCDTimeArr[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			}
		}
	}

	// Token: 0x06017CD0 RID: 97488 RVA: 0x00759730 File Offset: 0x00757B30
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.FindMechanismMonster();
		this.sceneHandleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onSummon, delegate(object[] args)
		{
			BeActor monster = (BeActor)args[0];
			if (monster != null && monster.GetEntityData().monsterID == this.mechanismMonsterId && monster.m_iCamp == base.owner.m_iCamp)
			{
				BeEventHandle item = monster.RegisterEvent(BeEventType.onAddMechanism, delegate(object[] args1)
				{
					int num = (int)args1[0];
					if (num == this.mechanismId)
					{
						this.mechanismMonster = monster;
						this.ChangeCDTime(true);
					}
				});
				this.handleList.Add(item);
			}
		});
	}

	// Token: 0x06017CD1 RID: 97489 RVA: 0x00759780 File Offset: 0x00757B80
	public override void OnFinish()
	{
		base.OnFinish();
		this.RestoreCDTime();
		for (int i = 0; i < this.handleList.Count; i++)
		{
			BeEventHandle beEventHandle = this.handleList[i];
			if (beEventHandle != null)
			{
				beEventHandle.Remove();
			}
		}
	}

	// Token: 0x06017CD2 RID: 97490 RVA: 0x007597D0 File Offset: 0x00757BD0
	protected void FindMechanismMonster()
	{
		if (this.mechanismMonster != null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByIDAndCamp(list, this.mechanismMonsterId, base.owner.GetCamp());
		if (list != null && list.Count > 0)
		{
			this.mechanismMonster = list[0];
		}
		ListPool<BeActor>.Release(list);
		this.ChangeCDTime(false);
	}

	// Token: 0x06017CD3 RID: 97491 RVA: 0x0075983E File Offset: 0x00757C3E
	protected void RestoreCDTime()
	{
		if (this.mechanismMonster == null)
		{
			return;
		}
		this.ChangeCDTime(false);
	}

	// Token: 0x06017CD4 RID: 97492 RVA: 0x00759854 File Offset: 0x00757C54
	protected void ChangeCDTime(bool isAdd = false)
	{
		if (this.mechanismMonster == null)
		{
			return;
		}
		Mechanism140 mechanism = this.mechanismMonster.GetMechanism(this.mechanismId) as Mechanism140;
		if (mechanism == null)
		{
			return;
		}
		for (int i = 0; i < this.reduceCDTimeArr.Length; i++)
		{
			if (isAdd)
			{
				mechanism.createCDArr[i] -= this.reduceCDTimeArr[i];
			}
			else
			{
				mechanism.createCDArr[i] += this.reduceCDTimeArr[i];
			}
		}
	}

	// Token: 0x040111F8 RID: 70136
	protected int[] reduceCDTimeArr = new int[4];

	// Token: 0x040111F9 RID: 70137
	protected int mechanismId = 5186;

	// Token: 0x040111FA RID: 70138
	protected int mechanismMonsterId = 93030031;

	// Token: 0x040111FB RID: 70139
	protected BeActor mechanismMonster;

	// Token: 0x040111FC RID: 70140
	protected List<BeEventHandle> handleList = new List<BeEventHandle>();
}
