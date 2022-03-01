using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x0200439E RID: 17310
public class Mechanism2103 : BeMechanism
{
	// Token: 0x06018008 RID: 98312 RVA: 0x00770C35 File Offset: 0x0076F035
	public Mechanism2103(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018009 RID: 98313 RVA: 0x00770C4C File Offset: 0x0076F04C
	public override void OnInit()
	{
		base.OnInit();
		this._removeBuffIdList.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			this._removeBuffIdList.Add(valueFromUnionCell);
		}
		this._addBuffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._addBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x0601800A RID: 98314 RVA: 0x00770D0C File Offset: 0x0076F10C
	public override void OnStart()
	{
		base.OnStart();
		if (!this.CanUseNewSpecialCombo())
		{
			return;
		}
		if (base.owner.GetEntityData().professtion != 11)
		{
			return;
		}
		if (base.owner.attackReplaceLigui && !BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		for (int i = 0; i < this._removeBuffIdList.Count; i++)
		{
			int buffID = this._removeBuffIdList[i];
			base.owner.buffController.RemoveBuff(buffID, 0, 0);
		}
		base.owner.buffController.TryAddBuff(this._addBuffId, this._addBuffTime, 1);
	}

	// Token: 0x0601800B RID: 98315 RVA: 0x00770DBE File Offset: 0x0076F1BE
	private bool CanUseNewSpecialCombo()
	{
		return base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.LiGuiSpecialCombo);
	}

	// Token: 0x0401149E RID: 70814
	private List<int> _removeBuffIdList = new List<int>();

	// Token: 0x0401149F RID: 70815
	private int _addBuffId;

	// Token: 0x040114A0 RID: 70816
	private int _addBuffTime;
}
