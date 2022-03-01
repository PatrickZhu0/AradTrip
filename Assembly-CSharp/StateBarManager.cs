using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

// Token: 0x02000F91 RID: 3985
public class StateBarManager
{
	// Token: 0x06009A1F RID: 39455 RVA: 0x001DA9DC File Offset: 0x001D8DDC
	public void CreateStateBar()
	{
		if (this.goStateBar == null)
		{
			string path = "UIFlatten/Prefabs/BattleUI/DungeonBar/StateBar";
			this.goStateBar = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			if (this.goStateBar != null)
			{
				GameObject gameObject = this._getStateBarRoot();
				if (gameObject != null)
				{
					Utility.AttachTo(this.goStateBar, gameObject, false);
				}
				this.stateBar = this.goStateBar.GetComponent<CStateBar>();
			}
		}
	}

	// Token: 0x06009A20 RID: 39456 RVA: 0x001DAA58 File Offset: 0x001D8E58
	private GameObject _getStateBarRoot()
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemBattle;
		if (clientSystemBattle == null)
		{
			clientSystemBattle = (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle);
		}
		if (clientSystemBattle == null)
		{
			return null;
		}
		return clientSystemBattle.MonsterBossRoot;
	}

	// Token: 0x06009A21 RID: 39457 RVA: 0x001DAA99 File Offset: 0x001D8E99
	public void SetBarActive(bool active)
	{
		if (this.stateBar != null)
		{
			this.stateBar.SetActive(active);
		}
	}

	// Token: 0x06009A22 RID: 39458 RVA: 0x001DAAB8 File Offset: 0x001D8EB8
	public void SetCurrentId(int id)
	{
		if (this.stateBar == null)
		{
			return;
		}
		if (this.currentId == id)
		{
			return;
		}
		this.currentId = id;
		this.currentData = null;
		if (this.currentId == StateBarManager.kInvalidStateBarId)
		{
			this.SetBarActive(false);
			return;
		}
		for (int i = 0; i < this.listData.Count; i++)
		{
			if (this.listData[i].id == this.currentId)
			{
				this.currentData = this.listData[i];
				this.stateBar.SetStateBarInfo(this.currentData.text, this.currentData.color);
				break;
			}
		}
	}

	// Token: 0x06009A23 RID: 39459 RVA: 0x001DAB7C File Offset: 0x001D8F7C
	public int AddStateBar(string text, int duration, CStateBar.eBarColor color = CStateBar.eBarColor.Yellow, bool reverse = false)
	{
		int num = this._getStateBarId();
		StateBarData item = new StateBarData(num, text, duration, color, reverse);
		this.listData.Add(item);
		this.SetCurrentId(num);
		return num;
	}

	// Token: 0x06009A24 RID: 39460 RVA: 0x001DABB0 File Offset: 0x001D8FB0
	private int _getStateBarId()
	{
		return ++this.idAcc;
	}

	// Token: 0x06009A25 RID: 39461 RVA: 0x001DABD0 File Offset: 0x001D8FD0
	public void RemoveStateBar(int id)
	{
		StateBarData stateBarData = this.listData.Find((StateBarData x) => x.id == id);
		if (stateBarData != null)
		{
			this.listData.Remove(stateBarData);
			if (this.currentData != null && stateBarData.id == this.currentData.id)
			{
				this.SetCurrentId(StateBarManager.kInvalidStateBarId);
			}
		}
	}

	// Token: 0x06009A26 RID: 39462 RVA: 0x001DAC44 File Offset: 0x001D9044
	public void Update(int deltaTime)
	{
		if (this.stateBar == null)
		{
			return;
		}
		for (int i = 0; i < this.listData.Count; i++)
		{
			StateBarData stateBarData = this.listData[i];
			if (stateBarData != null)
			{
				if (stateBarData.reverse)
				{
					stateBarData.time += deltaTime;
				}
				else
				{
					stateBarData.time -= deltaTime;
				}
			}
		}
		if (this.currentData != null)
		{
			if (this.currentData.time <= 0 || this.currentData.time >= this.currentData.duration)
			{
				this.SetCurrentId(StateBarManager.kInvalidStateBarId);
			}
			else
			{
				this.stateBar.SetPercent(1f * (float)this.currentData.time / (float)this.currentData.duration);
				this.stateBar.SetTimeText(this.currentData.time);
			}
		}
		else if (this.stateBar.GetActive())
		{
			this.stateBar.SetActive(false);
		}
	}

	// Token: 0x06009A27 RID: 39463 RVA: 0x001DAD66 File Offset: 0x001D9166
	public void Unload()
	{
		this.listData.Clear();
		this.currentActor = null;
		this.stateBar = null;
		if (this.goStateBar != null)
		{
			Object.Destroy(this.goStateBar);
			this.goStateBar = null;
		}
	}

	// Token: 0x04004F71 RID: 20337
	public static int kInvalidStateBarId = -1;

	// Token: 0x04004F72 RID: 20338
	private int idAcc;

	// Token: 0x04004F73 RID: 20339
	private List<StateBarData> listData = new List<StateBarData>();

	// Token: 0x04004F74 RID: 20340
	private int currentId;

	// Token: 0x04004F75 RID: 20341
	private StateBarData currentData;

	// Token: 0x04004F76 RID: 20342
	private GameObject goStateBar;

	// Token: 0x04004F77 RID: 20343
	private CStateBar stateBar;

	// Token: 0x04004F78 RID: 20344
	public GeActorEx currentActor;
}
