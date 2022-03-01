using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020043C3 RID: 17347
public class Mechanism2134 : BeMechanism
{
	// Token: 0x060180FC RID: 98556 RVA: 0x00778F9B File Offset: 0x0077739B
	public Mechanism2134(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180FD RID: 98557 RVA: 0x00778FBC File Offset: 0x007773BC
	public override void OnInit()
	{
		base.OnInit();
		this._registerBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._addBufIdList.Clear();
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this._addBufIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
	}

	// Token: 0x060180FE RID: 98558 RVA: 0x00779050 File Offset: 0x00777450
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x060180FF RID: 98559 RVA: 0x0077905E File Offset: 0x0077745E
	public override void OnFinish()
	{
		base.OnFinish();
		this._RemoveEvent();
		this._RemoveAllAddBuff();
	}

	// Token: 0x06018100 RID: 98560 RVA: 0x00779074 File Offset: 0x00777474
	private void _RegisterEvent()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this._handleList.Add(base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onAddBuff, new BeEvent.BeEventHandleNew.Function(this._OnAddBuff)));
		this._handleList.Add(base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onRemoveBuff, new BeEvent.BeEventHandleNew.Function(this._OnRemoveBuff)));
	}

	// Token: 0x06018101 RID: 98561 RVA: 0x007790E4 File Offset: 0x007774E4
	private void _RemoveEvent()
	{
		for (int i = 0; i < this._handleList.Count; i++)
		{
			BeEvent.BeEventHandleNew beEventHandleNew = this._handleList[i];
			if (beEventHandleNew != null)
			{
				beEventHandleNew.Remove();
			}
		}
		this._handleList.Clear();
	}

	// Token: 0x06018102 RID: 98562 RVA: 0x00779134 File Offset: 0x00777534
	private void _OnAddBuff(BeEvent.BeEventParam param)
	{
		BeActor beActor = param.m_Obj2 as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!beActor.isMainActor)
		{
			return;
		}
		BeBuff beBuff = param.m_Obj as BeBuff;
		if (beBuff == null)
		{
			return;
		}
		if (beBuff.buffID != this._registerBuffId)
		{
			return;
		}
		this._CheckBuffCount();
	}

	// Token: 0x06018103 RID: 98563 RVA: 0x0077918C File Offset: 0x0077758C
	private void _OnRemoveBuff(BeEvent.BeEventParam param)
	{
		BeActor beActor = param.m_Obj2 as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!beActor.isMainActor)
		{
			return;
		}
		BeBuff beBuff = param.m_Obj as BeBuff;
		if (beBuff == null)
		{
			return;
		}
		if (beBuff.buffID != this._registerBuffId)
		{
			return;
		}
		this._CheckBuffCount();
	}

	// Token: 0x06018104 RID: 98564 RVA: 0x007791E4 File Offset: 0x007775E4
	private void _CheckBuffCount()
	{
		int num = this._HowManyPlayerHaveBuff();
		for (int i = 0; i < this._addBufIdList.Count; i++)
		{
			int buffID = this._addBufIdList[i];
			int buffCountByID = base.owner.buffController.GetBuffCountByID(buffID);
			if (buffCountByID > num)
			{
				base.owner.buffController.RemoveBuff(buffID, buffCountByID - num, 0);
			}
			else if (buffCountByID < num)
			{
				for (int j = 0; j < num - buffCountByID; j++)
				{
					base.owner.buffController.TryAddBuff(buffID, int.MaxValue, this.level);
				}
			}
		}
	}

	// Token: 0x06018105 RID: 98565 RVA: 0x00779298 File Offset: 0x00777698
	private int _HowManyPlayerHaveBuff()
	{
		if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return 0;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null)
			{
				if (playerActor.buffController.HasBuffByID(this._registerBuffId) != null)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06018106 RID: 98566 RVA: 0x00779338 File Offset: 0x00777738
	private void _RemoveAllAddBuff()
	{
		for (int i = 0; i < this._addBufIdList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this._addBufIdList[i], 0, 0);
		}
	}

	// Token: 0x0401156F RID: 71023
	private List<BeEvent.BeEventHandleNew> _handleList = new List<BeEvent.BeEventHandleNew>();

	// Token: 0x04011570 RID: 71024
	private int _registerBuffId;

	// Token: 0x04011571 RID: 71025
	private List<int> _addBufIdList = new List<int>();
}
