using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004361 RID: 17249
public class Mechanism2042 : BeMechanism
{
	// Token: 0x06017E39 RID: 97849 RVA: 0x007637B4 File Offset: 0x00761BB4
	public Mechanism2042(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017E3A RID: 97850 RVA: 0x007637CC File Offset: 0x00761BCC
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.monsters.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.filter = new BeMonsterIDFilter(this.monsters);
	}

	// Token: 0x06017E3B RID: 97851 RVA: 0x00763868 File Offset: 0x00761C68
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.handleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onMouthClose, new BeEventHandle.Del(this.OnMouthClose));
	}

	// Token: 0x06017E3C RID: 97852 RVA: 0x007638BC File Offset: 0x00761CBC
	private void OnMouthClose(object[] args)
	{
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		bool flag = (bool)args[0];
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list, base.owner, true, this.filter);
		if (flag)
		{
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				if (beActor != null && beActor.buffController != null)
				{
					beActor.buffController.TryAddBuff(this.buffID, null, false, null, 0);
				}
			}
		}
		else
		{
			for (int j = 0; j < list.Count; j++)
			{
				BeActor beActor2 = list[j];
				if (beActor2 != null && beActor2.buffController != null)
				{
					beActor2.buffController.RemoveBuff(this.buffID, 0, 0);
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04011310 RID: 70416
	private List<int> monsters = new List<int>();

	// Token: 0x04011311 RID: 70417
	private int buffID;

	// Token: 0x04011312 RID: 70418
	private BeMonsterIDFilter filter;
}
