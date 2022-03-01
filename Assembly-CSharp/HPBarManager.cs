using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

// Token: 0x02000F89 RID: 3977
public class HPBarManager
{
	// Token: 0x17001937 RID: 6455
	// (get) Token: 0x060099CB RID: 39371 RVA: 0x001D942F File Offset: 0x001D782F
	// (set) Token: 0x060099CC RID: 39372 RVA: 0x001D9437 File Offset: 0x001D7837
	protected int currentHpBarId
	{
		get
		{
			return this.mCurrentHpBarId;
		}
		set
		{
			this.mCurrentHpBarId = value;
		}
	}

	// Token: 0x17001938 RID: 6456
	// (get) Token: 0x060099CD RID: 39373 RVA: 0x001D9440 File Offset: 0x001D7840
	// (set) Token: 0x060099CE RID: 39374 RVA: 0x001D9448 File Offset: 0x001D7848
	protected int lastHpBarId
	{
		get
		{
			return this.mLastHpBarId;
		}
		set
		{
			this.mLastHpBarId = value;
		}
	}

	// Token: 0x060099CF RID: 39375 RVA: 0x001D9451 File Offset: 0x001D7851
	public void AddHpBar(IHPBar bar, bool bActive = false)
	{
		if (bar != null)
		{
			bar.SetActive(bActive);
		}
	}

	// Token: 0x060099D0 RID: 39376 RVA: 0x001D9460 File Offset: 0x001D7860
	public void SyncHPBar(int barId, int hp, int maxHp)
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(barId);
		if (hpBarNode == null)
		{
			return;
		}
		hpBarNode.SyncHPBar(hp, maxHp);
		if (hp <= 0)
		{
			this.mRemovedHPBarIds.Add(barId);
		}
	}

	// Token: 0x060099D1 RID: 39377 RVA: 0x001D9498 File Offset: 0x001D7898
	public void ResetHpBar(int barId)
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(barId);
		if (hpBarNode == null)
		{
			return;
		}
		hpBarNode.ResetHp();
	}

	// Token: 0x060099D2 RID: 39378 RVA: 0x001D94BC File Offset: 0x001D78BC
	public int AddHpBar(BeEntity entity, eHpBarType type, string name, int singleBarHp, Sprite headIcon, Material headIconMaterial)
	{
		if (entity == null)
		{
			return -1;
		}
		BeEntityData entityData = entity.GetEntityData();
		if (entityData == null)
		{
			return -1;
		}
		int num = this._getNewBarId();
		HpBarNode hpBarNode = this._createHpBarNodeFromPool();
		hpBarNode.InitHpData(num, type, entityData.GetMaxHP(), singleBarHp);
		hpBarNode.InitInfo(name, entityData.GetLevel(), headIcon, headIconMaterial);
		this.mHpBarNodes.Add(hpBarNode);
		this._addHpBarGameObject(type);
		return num;
	}

	// Token: 0x060099D3 RID: 39379 RVA: 0x001D9524 File Offset: 0x001D7924
	private int _getNewBarId()
	{
		return ++this.mStartHpBarIdOrigin;
	}

	// Token: 0x060099D4 RID: 39380 RVA: 0x001D9542 File Offset: 0x001D7942
	public void RemoveHPBar(int barId)
	{
		this.mRemovedHPBarIds.Add(barId);
	}

	// Token: 0x060099D5 RID: 39381 RVA: 0x001D9550 File Offset: 0x001D7950
	private void _realRemoveHpBar(int barId)
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(barId);
		if (hpBarNode == null)
		{
			return;
		}
		this.mHpBarNodes.Remove(hpBarNode);
		IHPBar ihpbar = this._getHpBarGameObject(hpBarNode.barType);
		if (ihpbar != null)
		{
			ihpbar.Unload();
		}
		this._destroyHpBarNodeToPool(hpBarNode);
	}

	// Token: 0x060099D6 RID: 39382 RVA: 0x001D9599 File Offset: 0x001D7999
	public void RemoveHPBar(IHPBar bar)
	{
	}

	// Token: 0x060099D7 RID: 39383 RVA: 0x001D959C File Offset: 0x001D799C
	public void ShowHPBar(int barId, int value, HitTextType type = HitTextType.NORMAL)
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(barId);
		if (hpBarNode == null)
		{
			return;
		}
		hpBarNode.Damage(value);
		if (this._isShowNextHpBar(type) && this._getHpBarNodeByID(barId) != null)
		{
			this.currentHpBarId = barId;
		}
	}

	// Token: 0x060099D8 RID: 39384 RVA: 0x001D95DE File Offset: 0x001D79DE
	public void ShowHPBar(IHPBar bar, int value, HitTextType type = HitTextType.NORMAL)
	{
		if (bar != null)
		{
			bar.Damage(value, true);
		}
	}

	// Token: 0x060099D9 RID: 39385 RVA: 0x001D95EE File Offset: 0x001D79EE
	private bool _isShowNextHpBar(HitTextType type)
	{
		return type == HitTextType.NORMAL || type == HitTextType.CRITICAL;
	}

	// Token: 0x060099DA RID: 39386 RVA: 0x001D9600 File Offset: 0x001D7A00
	private bool _needChangeHpBarGameObjectType()
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(this.lastHpBarId);
		HpBarNode hpBarNode2;
		if (hpBarNode == null)
		{
			hpBarNode2 = this._getHpBarNodeByID(this.currentHpBarId);
			return hpBarNode2 != null && hpBarNode2.barType != this.mLastBarType;
		}
		hpBarNode2 = this._getHpBarNodeByID(this.currentHpBarId);
		return hpBarNode2 != null && hpBarNode2.barType != hpBarNode.barType;
	}

	// Token: 0x060099DB RID: 39387 RVA: 0x001D9670 File Offset: 0x001D7A70
	private HpBarNode _getHpBarNodeFromPool(int id)
	{
		for (int i = 0; i < this.mHpBarNodesPool.Count; i++)
		{
			if (this.mHpBarNodesPool[i].id == id)
			{
				return this.mHpBarNodesPool[i];
			}
		}
		return null;
	}

	// Token: 0x060099DC RID: 39388 RVA: 0x001D96C0 File Offset: 0x001D7AC0
	private void _hiddenLastHpBarGameObject()
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(this.lastHpBarId);
		if (hpBarNode != null)
		{
			IHPBar ihpbar = this._getHpBarGameObject(hpBarNode.barType);
			if (ihpbar != null)
			{
				ihpbar.SetActive(false);
			}
		}
		else
		{
			IHPBar ihpbar2 = this._getHpBarGameObject(this.mLastBarType);
			if (ihpbar2 != null)
			{
				ihpbar2.SetActive(false);
			}
		}
	}

	// Token: 0x060099DD RID: 39389 RVA: 0x001D971C File Offset: 0x001D7B1C
	private void _showCurrentHpBarGameObject()
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(this.currentHpBarId);
		if (hpBarNode != null && hpBarNode.IsHpChanged())
		{
			IHPBar ihpbar = this._getHpBarGameObject(hpBarNode.barType);
			if (ihpbar != null)
			{
				ihpbar.SetActive(true);
				ihpbar.Init(hpBarNode.maxHp, 0, hpBarNode.singleBarHp, 0);
				ihpbar.SetName(hpBarNode.name, hpBarNode.level);
				ihpbar.SetIcon(hpBarNode.headIcon, hpBarNode.headIconMaterial);
				ihpbar.Damage(hpBarNode.maxHp - (hpBarNode.hp + hpBarNode.changedHp), false);
				ihpbar.Damage(hpBarNode.changedHp, true);
			}
			this.mLastBarType = hpBarNode.barType;
			this.lastHpBarId = this.currentHpBarId;
		}
	}

	// Token: 0x060099DE RID: 39390 RVA: 0x001D97DC File Offset: 0x001D7BDC
	public void Update(int delta)
	{
		bool flag = false;
		for (int i = 0; i < this.mHpBarNodes.Count; i++)
		{
			if (this.mHpBarNodes[i].IsHpChanged())
			{
				flag = true;
				break;
			}
		}
		if (flag && this.currentHpBarId != -1)
		{
			if (this._needChangeHpBarGameObjectType())
			{
				this._hiddenLastHpBarGameObject();
			}
			this._showCurrentHpBarGameObject();
		}
		for (int j = 0; j < this.mHpBarNodes.Count; j++)
		{
			this.mHpBarNodes[j].ClearChangedHp();
		}
		for (int k = 0; k < this.mRemovedHPBarIds.Count; k++)
		{
			this._realRemoveHpBar(this.mRemovedHPBarIds[k]);
		}
		this.mRemovedHPBarIds.Clear();
	}

	// Token: 0x060099DF RID: 39391 RVA: 0x001D98B3 File Offset: 0x001D7CB3
	public void ShowMPBar(IHPBar bar, float percent)
	{
		if (bar == null)
		{
			return;
		}
		bar.SetMPRate(percent);
	}

	// Token: 0x060099E0 RID: 39392 RVA: 0x001D98C3 File Offset: 0x001D7CC3
	public void Unload()
	{
		this._unloadAllHpBarGameObject();
	}

	// Token: 0x060099E1 RID: 39393 RVA: 0x001D98CC File Offset: 0x001D7CCC
	protected void _unloadAllHpBarGameObject()
	{
		for (int i = 0; i < this.mCacheHPBar.Count; i++)
		{
			this.mCacheHPBar[i] = null;
		}
		this.mCacheHPBar.Clear();
	}

	// Token: 0x060099E2 RID: 39394 RVA: 0x001D9910 File Offset: 0x001D7D10
	private void _addHpBarGameObject(eHpBarType type)
	{
		if (this._hasCreateHpBarGameobject(type))
		{
			return;
		}
		IHPBar ihpbar = this._createHpBarAndAttach(type);
		if (ihpbar == null)
		{
			return;
		}
		this.mCacheHPBar.Add(ihpbar);
	}

	// Token: 0x060099E3 RID: 39395 RVA: 0x001D9945 File Offset: 0x001D7D45
	private bool _hasCreateHpBarGameobject(eHpBarType type)
	{
		return null != this._getHpBarGameObject(type);
	}

	// Token: 0x060099E4 RID: 39396 RVA: 0x001D9954 File Offset: 0x001D7D54
	private IHPBar _getHpBarGameObject(eHpBarType type)
	{
		for (int i = 0; i < this.mCacheHPBar.Count; i++)
		{
			if (this.mCacheHPBar[i] != null && type == this.mCacheHPBar[i].GetBarType())
			{
				return this.mCacheHPBar[i];
			}
		}
		return null;
	}

	// Token: 0x060099E5 RID: 39397 RVA: 0x001D99B4 File Offset: 0x001D7DB4
	private bool _isHpBarNodeIsHpChanged(int barId)
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(barId);
		return hpBarNode != null && hpBarNode.IsHpChanged();
	}

	// Token: 0x060099E6 RID: 39398 RVA: 0x001D99D8 File Offset: 0x001D7DD8
	public void ShowBuffName(int id, string name)
	{
		HpBarNode hpBarNode = this._getHpBarNodeByID(id);
		if (hpBarNode == null)
		{
			return;
		}
		IHPBar ihpbar = this._getHpBarGameObject(hpBarNode.barType);
		if (ihpbar != null)
		{
			ihpbar.SetBuffName(name);
		}
	}

	// Token: 0x060099E7 RID: 39399 RVA: 0x001D9A10 File Offset: 0x001D7E10
	private HpBarNode _getHpBarNodeByID(int barId)
	{
		for (int i = 0; i < this.mHpBarNodes.Count; i++)
		{
			if (barId == this.mHpBarNodes[i].id)
			{
				return this.mHpBarNodes[i];
			}
		}
		return null;
	}

	// Token: 0x060099E8 RID: 39400 RVA: 0x001D9A60 File Offset: 0x001D7E60
	private IHPBar _createHpBarAndAttach(eHpBarType type)
	{
		GameObject gameObject = this._getHpBarRoot();
		if (null == gameObject)
		{
			return null;
		}
		string path = this._getHpBarPathByType(type);
		GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		Utility.AttachTo(gameObject2, gameObject, false);
		IHPBar component = gameObject2.GetComponent<CBossHpBar>();
		component.SetActive(false);
		return component;
	}

	// Token: 0x060099E9 RID: 39401 RVA: 0x001D9AB0 File Offset: 0x001D7EB0
	private GameObject _getHpBarRoot()
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

	// Token: 0x060099EA RID: 39402 RVA: 0x001D9AF1 File Offset: 0x001D7EF1
	private string _getHpBarPathByType(eHpBarType type)
	{
		if (type == eHpBarType.Monster)
		{
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/HPBar_Monster";
		}
		if (type == eHpBarType.Elite)
		{
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/HPBar_Elite";
		}
		if (type != eHpBarType.Boss)
		{
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/HPBar_Monster";
		}
		return "UIFlatten/Prefabs/BattleUI/DungeonBar/HPBar_BOSS_NEW";
	}

	// Token: 0x060099EB RID: 39403 RVA: 0x001D9B23 File Offset: 0x001D7F23
	protected void _destroyHpBarNodeToPool(HpBarNode node)
	{
		if (node == null)
		{
			return;
		}
		node.Reset();
		this.mHpBarNodesPool.Add(node);
	}

	// Token: 0x060099EC RID: 39404 RVA: 0x001D9B40 File Offset: 0x001D7F40
	protected HpBarNode _createHpBarNodeFromPool()
	{
		if (this.mHpBarNodesPool.Count <= 0)
		{
			this._addDefaultCountBarNodes2Pool();
		}
		HpBarNode hpBarNode = this.mHpBarNodesPool[0];
		hpBarNode.Reset();
		this.mHpBarNodesPool.Remove(hpBarNode);
		return hpBarNode;
	}

	// Token: 0x060099ED RID: 39405 RVA: 0x001D9B88 File Offset: 0x001D7F88
	protected void _addDefaultCountBarNodes2Pool()
	{
		for (int i = 0; i < 8; i++)
		{
			this._addOneBarNodeToPool();
		}
	}

	// Token: 0x060099EE RID: 39406 RVA: 0x001D9BB0 File Offset: 0x001D7FB0
	protected void _addOneBarNodeToPool()
	{
		HpBarNode hpBarNode = new HpBarNode();
		hpBarNode.Reset();
		this.mHpBarNodesPool.Add(hpBarNode);
	}

	// Token: 0x04004F3C RID: 20284
	private int mStartHpBarIdOrigin = 1;

	// Token: 0x04004F3D RID: 20285
	public const int kInvalidHpBarId = -1;

	// Token: 0x04004F3E RID: 20286
	private List<HpBarNode> mHpBarNodes = new List<HpBarNode>();

	// Token: 0x04004F3F RID: 20287
	private List<int> mRemovedHPBarIds = new List<int>();

	// Token: 0x04004F40 RID: 20288
	private int mLastHpBarId = -1;

	// Token: 0x04004F41 RID: 20289
	private int mCurrentHpBarId = -1;

	// Token: 0x04004F42 RID: 20290
	private eHpBarType mLastBarType = eHpBarType.Monster;

	// Token: 0x04004F43 RID: 20291
	private List<IHPBar> mCacheHPBar = new List<IHPBar>();

	// Token: 0x04004F44 RID: 20292
	protected List<HpBarNode> mHpBarNodesPool = new List<HpBarNode>();

	// Token: 0x04004F45 RID: 20293
	protected const int kDefaultBarNodeCount = 8;
}
