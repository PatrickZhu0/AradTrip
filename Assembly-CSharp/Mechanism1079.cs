using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004298 RID: 17048
public class Mechanism1079 : BeMechanism
{
	// Token: 0x06017963 RID: 96611 RVA: 0x00743402 File Offset: 0x00741802
	public Mechanism1079(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017964 RID: 96612 RVA: 0x00743430 File Offset: 0x00741830
	public override void OnInit()
	{
		base.OnInit();
		this.deadMonsterIds.Clear();
		this.relatedMonsterIds.Clear();
		this.relatedBuffIds.Clear();
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Count; i++)
			{
				this.deadMonsterIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			for (int j = 0; j < this.data.ValueB.Count; j++)
			{
				this.relatedMonsterIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
			}
		}
		if (this.data.ValueC.Count > 0)
		{
			for (int k = 0; k < this.data.ValueC.Count; k++)
			{
				this.relatedBuffIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true));
			}
		}
	}

	// Token: 0x06017965 RID: 96613 RVA: 0x00743590 File Offset: 0x00741990
	private void onMonsterDead(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		int i = 0;
		while (i < this.deadMonsterIds.Count)
		{
			if (beActor.GetEntityData() != null && beActor.GetEntityData().MonsterIDEqual(this.deadMonsterIds[i]))
			{
				if (i < 0 && i >= this.relatedMonsterIds.Count)
				{
					Logger.LogErrorFormat("mechanism {0} summonMonsterIds {1} is out of range {2}", new object[]
					{
						this.mechianismID,
						i,
						this.relatedMonsterIds[i]
					});
					return;
				}
				if (i < 0 && i >= this.relatedBuffIds.Count)
				{
					Logger.LogErrorFormat("mechanism {0} buffIds {1} is out of range {2}", new object[]
					{
						this.mechianismID,
						i,
						this.relatedBuffIds[i]
					});
					return;
				}
				List<BeActor> list = ListPool<BeActor>.Get();
				base.owner.CurrentBeScene.FindActorById2(list, this.relatedMonsterIds[i], false);
				if (list.Count > 0)
				{
					for (int j = 0; j < list.Count; j++)
					{
						BeActor beActor2 = list[j];
						if (beActor2 != null && !beActor2.IsDead() && beActor2.buffController != null && beActor2.buffController.HasBuffByID(this.relatedBuffIds[i]) != null)
						{
							VInt3 position = beActor.GetPosition();
							position.z = 0;
							beActor2.SetPosition(position, false, true, false);
							beActor2.DoDead(true);
							break;
						}
					}
				}
				ListPool<BeActor>.Release(list);
				return;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x06017966 RID: 96614 RVA: 0x00743758 File Offset: 0x00741B58
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.sceneHandleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onMonsterDead, new BeEventHandle.Del(this.onMonsterDead));
	}

	// Token: 0x04010F28 RID: 69416
	private List<int> deadMonsterIds = new List<int>();

	// Token: 0x04010F29 RID: 69417
	private List<int> relatedMonsterIds = new List<int>();

	// Token: 0x04010F2A RID: 69418
	private List<int> relatedBuffIds = new List<int>();
}
