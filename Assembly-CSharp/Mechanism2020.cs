using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x0200434A RID: 17226
public class Mechanism2020 : BeMechanism
{
	// Token: 0x06017D96 RID: 97686 RVA: 0x0075EF64 File Offset: 0x0075D364
	public Mechanism2020(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D97 RID: 97687 RVA: 0x0075EFB0 File Offset: 0x0075D3B0
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x06017D98 RID: 97688 RVA: 0x0075EFB8 File Offset: 0x0075D3B8
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff.buffID == this.buffID)
			{
				List<BeActor> list2 = ListPool<BeActor>.Get();
				base.owner.CurrentBeScene.FindMonsterByIDAndCamp(list2, this.monsterID, base.owner.GetCamp());
				for (int j = 0; j < list2.Count; j++)
				{
					BeActor beActor = list2[j];
					if (!beActor.IsDead())
					{
						beActor.buffController.TryAddBuff(this.changeBuffID, -1, 1);
					}
				}
				ListPool<BeActor>.Release(list2);
			}
		});
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindMonsterByIDAndCamp(list, this.summonMonsterID, base.owner.GetCamp());
		for (int i = 0; i < list.Count; i++)
		{
			BeEventHandle item = list[i].RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				if (base.owner.buffController.HasBuffByID(this.buffID) == null)
				{
					return;
				}
				BeActor beActor = args[0] as BeActor;
				if (beActor != null)
				{
					beActor.buffController.TryAddBuff(this.changeBuffID, -1, 1);
				}
			});
			this.handleList.Add(item);
		}
	}

	// Token: 0x06017D99 RID: 97689 RVA: 0x0075F054 File Offset: 0x0075D454
	private void RemoveHandleList()
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

	// Token: 0x06017D9A RID: 97690 RVA: 0x0075F0B7 File Offset: 0x0075D4B7
	public override void OnDead()
	{
		base.OnDead();
		this.RemoveHandleList();
	}

	// Token: 0x06017D9B RID: 97691 RVA: 0x0075F0C5 File Offset: 0x0075D4C5
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandleList();
	}

	// Token: 0x04011296 RID: 70294
	private int buffID = 521716;

	// Token: 0x04011297 RID: 70295
	private int summonMonsterID = 30950011;

	// Token: 0x04011298 RID: 70296
	private int monsterID = 31130011;

	// Token: 0x04011299 RID: 70297
	private int changeBuffID = 521724;

	// Token: 0x0401129A RID: 70298
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
