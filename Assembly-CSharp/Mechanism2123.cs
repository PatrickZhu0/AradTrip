using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020043B7 RID: 17335
public class Mechanism2123 : BeMechanism
{
	// Token: 0x060180AA RID: 98474 RVA: 0x00776C1B File Offset: 0x0077501B
	public Mechanism2123(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180AB RID: 98475 RVA: 0x00776C25 File Offset: 0x00775025
	public override void OnInit()
	{
		this.m_BuffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060180AC RID: 98476 RVA: 0x00776C4F File Offset: 0x0077504F
	public override void OnStart()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onEnterRepairStat, new BeEvent.BeEventHandleNew.Function(this._onEnterRepaireStat));
	}

	// Token: 0x060180AD RID: 98477 RVA: 0x00776C88 File Offset: 0x00775088
	private void _onEnterRepaireStat(BeEvent.BeEventParam param)
	{
		if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null || base.owner.CurrentBeBattle.dungeonManager == null || base.owner.CurrentBeBattle.dungeonManager.IsFinishFight())
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return;
		}
		int num = allPlayers.Count;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i] != null && allPlayers[i].playerActor != null && allPlayers[i].playerActor.buffController != null)
			{
				if (allPlayers[i].playerActor.buffController.HasBuffByID(this.m_BuffID) != null)
				{
					num--;
				}
			}
		}
		if (num <= 0)
		{
			base.owner.CurrentBeBattle.OnCriticalElementDisappear();
			base.owner.CurrentBeScene.TriggerEventNew(BeEventSceneType.onRaceGameEnd, new EventParam
			{
				m_Int = 0
			});
		}
	}

	// Token: 0x04011529 RID: 70953
	private int m_BuffID;
}
