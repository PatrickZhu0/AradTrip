using System;
using System.Collections.Generic;

// Token: 0x020043C4 RID: 17348
public class Mechanism2135 : BeMechanism
{
	// Token: 0x06018107 RID: 98567 RVA: 0x0077937F File Offset: 0x0077777F
	public Mechanism2135(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018108 RID: 98568 RVA: 0x00779394 File Offset: 0x00777794
	public override void OnInit()
	{
		base.OnInit();
		this._registerBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._ownerAddBuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._friendAddBuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this._finishRemoveAddBuffInfo = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) != 0);
	}

	// Token: 0x06018109 RID: 98569 RVA: 0x00779453 File Offset: 0x00777853
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x0601810A RID: 98570 RVA: 0x00779461 File Offset: 0x00777861
	public override void OnFinish()
	{
		base.OnFinish();
		this._RemoveAddBuffIdList();
	}

	// Token: 0x0601810B RID: 98571 RVA: 0x0077946F File Offset: 0x0077786F
	private void _RegisterEvent()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, new BeEventHandle.Del(this._OnAddBuff));
	}

	// Token: 0x0601810C RID: 98572 RVA: 0x007794A4 File Offset: 0x007778A4
	private void _OnAddBuff(object[] param)
	{
		BeBuff beBuff = param[0] as BeBuff;
		if (beBuff == null)
		{
			return;
		}
		if (beBuff.buffID != this._registerBuffId)
		{
			return;
		}
		if (beBuff.releaser != null && beBuff.releaser.GetPID() != base.owner.GetPID())
		{
			return;
		}
		this._addBuffActorList.Clear();
		if (base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					if (playerActor.GetPID() == base.owner.GetPID())
					{
						base.owner.buffController.TryAddBuffInfo(this._ownerAddBuffInfoId, base.owner, this.level);
					}
					else
					{
						playerActor.buffController.TryAddBuffInfo(this._friendAddBuffInfoId, base.owner, this.level);
					}
					if (!this._addBuffActorList.Contains(playerActor))
					{
						this._addBuffActorList.Add(playerActor);
					}
				}
			}
		}
	}

	// Token: 0x0601810D RID: 98573 RVA: 0x007795F4 File Offset: 0x007779F4
	private void _RemoveAddBuffIdList()
	{
		if (!this._finishRemoveAddBuffInfo)
		{
			return;
		}
		for (int i = 0; i < this._addBuffActorList.Count; i++)
		{
			BeActor beActor = this._addBuffActorList[i];
			if (beActor != null)
			{
				if (beActor.GetPID() == base.owner.GetPID())
				{
					beActor.buffController.RemoveBuffByBuffInfoID(this._ownerAddBuffInfoId);
				}
				else
				{
					beActor.buffController.RemoveBuffByBuffInfoID(this._friendAddBuffInfoId);
				}
			}
		}
	}

	// Token: 0x04011572 RID: 71026
	private int _registerBuffId;

	// Token: 0x04011573 RID: 71027
	private int _ownerAddBuffInfoId;

	// Token: 0x04011574 RID: 71028
	private int _friendAddBuffInfoId;

	// Token: 0x04011575 RID: 71029
	private bool _finishRemoveAddBuffInfo;

	// Token: 0x04011576 RID: 71030
	private List<BeActor> _addBuffActorList = new List<BeActor>();
}
