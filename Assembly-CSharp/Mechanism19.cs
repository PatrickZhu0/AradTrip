using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x02004330 RID: 17200
public class Mechanism19 : BeMechanism
{
	// Token: 0x06017CBA RID: 97466 RVA: 0x00758F1D File Offset: 0x0075731D
	public Mechanism19(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CBB RID: 97467 RVA: 0x00758F50 File Offset: 0x00757350
	public override void OnInit()
	{
		this.delay = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.tipId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.m_StopRebornFlag = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) != 0);
	}

	// Token: 0x06017CBC RID: 97468 RVA: 0x00759034 File Offset: 0x00757434
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			if (this.IsTargetAlive(this.monsterID))
			{
				this.m_RebornFlag = true;
				SpellBar spellBar = base.owner.StartSpellBar(eDungeonCharactorBar.Progress, this.delay, true, this.text, false);
				if (spellBar != null)
				{
					spellBar.alwaysRefreshUI = true;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleDoubleBossTips, this.delay, this.tipId, null, null);
				base.owner.delayCaller.DelayCall(this.delay, delegate
				{
					if (this.IsTargetAlive(this.monsterID))
					{
						this.m_RebornFlag = false;
						base.owner.Reborn();
						if (base.owner.CanUseSkill(this.skillID))
						{
							base.owner.UseSkill(this.skillID, true);
						}
					}
					else
					{
						base.owner.SetLifeState(EntityLifeState.ELS_CANREMOVE);
					}
				}, 0, 0, false);
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onMarkRemove, delegate(object[] args)
		{
			if (this.IsTargetAlive(this.monsterID))
			{
				int[] array = (int[])args[0];
				array[0] = 1;
			}
		});
		this.RegisterTargetMonsterDead();
	}

	// Token: 0x06017CBD RID: 97469 RVA: 0x00759088 File Offset: 0x00757488
	protected void RegisterTargetMonsterDead()
	{
		if (!this.m_StopRebornFlag)
		{
			return;
		}
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.sceneHandleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onMonsterDead, new BeEventHandle.Del(this.RegisterDeadEvent));
	}

	// Token: 0x06017CBE RID: 97470 RVA: 0x007590D8 File Offset: 0x007574D8
	protected void RegisterDeadEvent(object[] args)
	{
		BeActor beActor = (BeActor)args[0];
		if (beActor == null)
		{
			return;
		}
		if (beActor.GetEntityData().monsterID != this.monsterID)
		{
			return;
		}
		this.RemoveEffect();
	}

	// Token: 0x06017CBF RID: 97471 RVA: 0x00759112 File Offset: 0x00757512
	protected void RemoveEffect()
	{
		if (!this.m_RebornFlag)
		{
			return;
		}
		SystemNotifyManager.ClearDungeonSkillTip();
		base.owner.StopSpellBar(eDungeonCharactorBar.Progress, true);
	}

	// Token: 0x06017CC0 RID: 97472 RVA: 0x00759134 File Offset: 0x00757534
	private bool IsTargetAlive(int monsterID)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, monsterID, true);
		bool result = list.Count > 0;
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06017CC1 RID: 97473 RVA: 0x0075916C File Offset: 0x0075756C
	public override void OnFinish()
	{
		this.RemoveEffect();
	}

	// Token: 0x040111E6 RID: 70118
	private int delay = 3000;

	// Token: 0x040111E7 RID: 70119
	private string text = "复活中";

	// Token: 0x040111E8 RID: 70120
	private int monsterID = 102;

	// Token: 0x040111E9 RID: 70121
	private int skillID = 5449;

	// Token: 0x040111EA RID: 70122
	private int tipId;

	// Token: 0x040111EB RID: 70123
	protected bool m_StopRebornFlag;

	// Token: 0x040111EC RID: 70124
	protected bool m_RebornFlag;
}
