using System;
using GameClient;
using UnityEngine;

// Token: 0x0200435A RID: 17242
public class Mechanism2035 : BeMechanism
{
	// Token: 0x06017DF9 RID: 97785 RVA: 0x00761AA4 File Offset: 0x0075FEA4
	public Mechanism2035(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017DFA RID: 97786 RVA: 0x00761AB9 File Offset: 0x0075FEB9
	public override void OnInit()
	{
		base.OnInit();
		this.prefabPath = this.data.StringValueA[0];
	}

	// Token: 0x06017DFB RID: 97787 RVA: 0x00761AD8 File Offset: 0x0075FED8
	public override void OnStart()
	{
		base.OnStart();
		this.InitSystem();
		GameObject gameObject = this._getHpBarRoot();
		if (null == gameObject)
		{
			return;
		}
		this.barGo = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.prefabPath, true, 0U);
		if (null == this.barGo)
		{
			return;
		}
		Utility.AttachTo(this.barGo, gameObject, false);
		int maxHP = base.owner.GetEntityData().GetMaxHP();
		int hp = base.owner.GetEntityData().GetHP();
		IHPBar barCom = this.barGo.GetComponent<CBossHpBar>();
		if (barCom == null)
		{
			return;
		}
		barCom.Init(maxHP, 0, -1, 0);
		barCom.SetName(base.owner.GetEntityData().name, base.owner.GetEntityData().level);
		this.SetPlayerHpBar(false);
		this.handleA = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			int value = (int)args[0];
			if (barCom == null)
			{
				return;
			}
			barCom.Damage(value, true);
		});
		this.handleB = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.OnEndAirBattle, delegate(object[] args)
		{
			this.SetPlayerHpBar(true);
			this.Unload();
		});
	}

	// Token: 0x06017DFC RID: 97788 RVA: 0x00761C11 File Offset: 0x00760011
	private void SetPlayerHpBar(bool value)
	{
		if (this.system == null || this.system.PlayerSelfInfoRoot == null)
		{
			return;
		}
		this.system.PlayerSelfInfoRoot.SetActive(value);
	}

	// Token: 0x06017DFD RID: 97789 RVA: 0x00761C46 File Offset: 0x00760046
	private GameObject _getHpBarRoot()
	{
		if (this.system == null)
		{
			return null;
		}
		return this.system.MonsterBossRoot;
	}

	// Token: 0x06017DFE RID: 97790 RVA: 0x00761C60 File Offset: 0x00760060
	private void InitSystem()
	{
		this.system = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemBattle);
		if (this.system == null)
		{
			this.system = (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle);
		}
	}

	// Token: 0x06017DFF RID: 97791 RVA: 0x00761C97 File Offset: 0x00760097
	public override void OnDead()
	{
		base.OnDead();
		this.Unload();
	}

	// Token: 0x06017E00 RID: 97792 RVA: 0x00761CA5 File Offset: 0x007600A5
	private void Unload()
	{
		if (this.barGo != null)
		{
			Object.Destroy(this.barGo);
			this.barGo = null;
		}
	}

	// Token: 0x06017E01 RID: 97793 RVA: 0x00761CCA File Offset: 0x007600CA
	public override void OnFinish()
	{
		base.OnFinish();
		this.Unload();
	}

	// Token: 0x040112E7 RID: 70375
	private string prefabPath = "UIFlatten/Prefabs/BattleUI/DungeonBar/SpecialHpBar";

	// Token: 0x040112E8 RID: 70376
	private GameObject barGo;

	// Token: 0x040112E9 RID: 70377
	private ClientSystemBattle system;
}
