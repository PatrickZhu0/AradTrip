using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000E8F RID: 3727
public class ComCharactorHPBar : ComBaseComponet, IHPBar
{
	// Token: 0x06009370 RID: 37744 RVA: 0x001B8658 File Offset: 0x001B6A58
	protected override void _bindExUI()
	{
		this.mIcon = this.mBind.GetCom<Image>("icon");
		this.mLevel = this.mBind.GetCom<Text>("level");
		this.mName = this.mBind.GetCom<Text>("name");
		this.mHpText = this.mBind.GetCom<Text>("hpText");
		this.mCurHpText = this.mBind.GetCom<Text>("curHpText");
		this.mMaxHpText = this.mBind.GetCom<Text>("maxHpText");
		this.mMpText = this.mBind.GetCom<Text>("mpText");
		this.mReborn = this.mBind.GetCom<Button>("reborn");
		if (null != this.mReborn)
		{
			this.mReborn.onClick.AddListener(new UnityAction(this._onRebornButtonClick));
		}
		this.mRebornRoot = this.mBind.GetGameObject("rebornRoot");
		this.mHp = this.mBind.GetCom<Slider>("hp");
		this.mMp = this.mBind.GetCom<Slider>("mp");
		this.mIconGray = this.mBind.GetCom<UIGray>("iconGray");
		this.mIconFg = this.mBind.GetGameObject("iconFg");
		this.mSignal = this.mBind.GetCom<Image>("signal");
		this.mSignalgray = this.mBind.GetCom<UIGray>("signalgray");
		this.mChatMsg = this.mBind.GetCom<ComTeamChatMessage>("chatMsg");
		this.resentment = this.mBind.GetCom<Text>("resentment");
		this.resentmentChange = this.mBind.GetGameObject("YuanNianZhi");
		if (this.resentmentChange != null)
		{
			this.resentmentText = this.resentmentChange.GetComponentInChildren<Text>();
		}
		this.mRebornBtnGray = this.mBind.GetCom<UIGray>("RebornBtnGray");
		this.mTeamleaderFlag = this.mBind.GetGameObject("teamleaderFlag");
		this.mReplaceHeadPortraitFrame = this.mBind.GetCom<ReplaceHeadPortraitFrame>("ReplaceHeadPortraitFrame");
		this.mHellHeadEffect = this.mBind.GetGameObject("HellEffectRoot");
		this.mHellHeadText = this.mBind.GetGameObject("HellTextRoot");
		this._bindEvent();
	}

	// Token: 0x06009371 RID: 37745 RVA: 0x001B88B4 File Offset: 0x001B6CB4
	protected override void _unbindExUI()
	{
		this._unbindEvent();
		this.mIcon = null;
		this.mLevel = null;
		this.mName = null;
		this.mHpText = null;
		this.mMpText = null;
		this.mCurHpText = null;
		this.mMaxHpText = null;
		if (null != this.mReborn)
		{
			this.mReborn.onClick.RemoveListener(new UnityAction(this._onRebornButtonClick));
		}
		this.mReborn = null;
		this.mRebornRoot = null;
		this.mHp = null;
		this.mMp = null;
		this.mIconGray = null;
		this.mIconFg = null;
		this.mSignal = null;
		this.mSignalgray = null;
		this.mChatMsg = null;
		this.mRebornBtnGray = null;
		this.mTeamleaderFlag = null;
		this.mReplaceHeadPortraitFrame = null;
		this.mHellHeadEffect = null;
		this.mHellHeadText = null;
	}

	// Token: 0x06009372 RID: 37746 RVA: 0x001B8988 File Offset: 0x001B6D88
	private void _onRebornButtonClick()
	{
		byte seat = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerInfo.seat;
		int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
		DungeonUtility.StartRebornProcess(seat, this.mSeat, dungeonID);
	}

	// Token: 0x06009373 RID: 37747 RVA: 0x001B89D8 File Offset: 0x001B6DD8
	protected void _bindEvent()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattlePlayerDead, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattlePlayerAlive, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattlePlayerBack, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattlePlayerLeave, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattlePlayerInfoChange, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AddRerbornCount, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamNotifyChatMsg, new ClientEventSystem.UIEventHandler(this._updateTeamChatMsg));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTeamMateDropSS, new ClientEventSystem.UIEventHandler(this._onPlayerGetHellDropSS));
	}

	// Token: 0x06009374 RID: 37748 RVA: 0x001B8AC0 File Offset: 0x001B6EC0
	protected void _unbindEvent()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattlePlayerDead, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattlePlayerAlive, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattlePlayerBack, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattlePlayerLeave, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattlePlayerInfoChange, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AddRerbornCount, new ClientEventSystem.UIEventHandler(this._onUpdatePlayerStatus));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamNotifyChatMsg, new ClientEventSystem.UIEventHandler(this._updateTeamChatMsg));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTeamMateDropSS, new ClientEventSystem.UIEventHandler(this._onPlayerGetHellDropSS));
	}

	// Token: 0x06009375 RID: 37749 RVA: 0x001B8BA8 File Offset: 0x001B6FA8
	private void _updateTeamChatMsg(UIEvent ui)
	{
		ulong num = (ulong)ui.Param1;
		string message = (string)ui.Param2;
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		if (playerBySeat != null && playerBySeat.playerInfo.roleId == num)
		{
			this.mChatMsg.SetMessage(message);
		}
	}

	// Token: 0x06009376 RID: 37750 RVA: 0x001B8C08 File Offset: 0x001B7008
	protected bool _canReborn(byte seat)
	{
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		IBattle battle = BattleMain.instance.GetBattle();
		if (battle != null && !battle.CanReborn())
		{
			return false;
		}
		if (playerBySeat != null && playerBySeat.netState != BattlePlayer.eNetState.Online)
		{
			return false;
		}
		int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
		return DungeonUtility.CanReborn(dungeonID, false);
	}

	// Token: 0x06009377 RID: 37751 RVA: 0x001B8C80 File Offset: 0x001B7080
	public bool IsDungeonRebornLimit()
	{
		if (BattleMain.instance == null || BattleMain.instance.GetPlayerManager() == null)
		{
			return false;
		}
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		if (playerBySeat == null)
		{
			return false;
		}
		int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
		int dungeonRebornCount = DungeonUtility.GetDungeonRebornCount(dungeonID);
		bool flag = true;
		IBattle battle = BattleMain.instance.GetBattle();
		if (battle != null && battle.IsRebornCountLimit())
		{
			flag = (battle.GetLeftRebornCount() > 0);
		}
		if (!flag)
		{
			return true;
		}
		if (dungeonRebornCount <= 0)
		{
			return false;
		}
		int dungeonRebornCount2 = playerBySeat.playerActor.dungeonRebornCount;
		return dungeonRebornCount2 >= dungeonRebornCount;
	}

	// Token: 0x06009378 RID: 37752 RVA: 0x001B8D3C File Offset: 0x001B713C
	protected void _onUpdatePlayerStatus(UIEvent ui)
	{
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		if (playerBySeat != null)
		{
			BattlePlayer.EState state = playerBySeat.state;
			if (state != BattlePlayer.EState.Dead)
			{
				if (state == BattlePlayer.EState.None)
				{
					this.mIconGray.enabled = false;
					this.mIconFg.SetActive(false);
					this.mRebornRoot.SetActive(false);
				}
			}
			else
			{
				this.mIconGray.enabled = true;
				this.mIconFg.SetActive(true);
				if (this._canReborn(this.mSeat))
				{
					this.mRebornRoot.SetActive(true);
					if (this.IsDungeonRebornLimit())
					{
						this.mRebornBtnGray.enabled = true;
						this.mReborn.enabled = false;
					}
					else
					{
						this.mRebornBtnGray.enabled = false;
						this.mReborn.enabled = true;
					}
				}
				else
				{
					this.mRebornRoot.SetActive(false);
				}
				if (playerBySeat == BattleMain.instance.GetPlayerManager().GetMainPlayer())
				{
					ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
					if (clientSystemBattle != null)
					{
						clientSystemBattle.ShowDeadTips(false);
					}
				}
			}
			switch (playerBySeat.netQuality)
			{
			case BattlePlayer.eNetQuality.Off:
				this.mBind.GetSprite("signalbad", ref this.mSignal);
				break;
			case BattlePlayer.eNetQuality.Bad:
				this.mBind.GetSprite("signalbad", ref this.mSignal);
				break;
			case BattlePlayer.eNetQuality.Good:
				this.mBind.GetSprite("signalgood", ref this.mSignal);
				break;
			case BattlePlayer.eNetQuality.Best:
				this.mBind.GetSprite("signalbest", ref this.mSignal);
				break;
			}
			BattlePlayer.eNetState netState = playerBySeat.netState;
			if (netState != BattlePlayer.eNetState.Online)
			{
				if (netState == BattlePlayer.eNetState.Offline || netState == BattlePlayer.eNetState.Quit)
				{
					this.mIconGray.enabled = true;
					this.mSignalgray.enabled = true;
				}
			}
			else
			{
				this.mSignalgray.enabled = false;
			}
		}
	}

	// Token: 0x06009379 RID: 37753 RVA: 0x001B8F45 File Offset: 0x001B7345
	public void SetSeat(byte seat)
	{
		this.mSeat = seat;
		this._updateTeamLeaderFlag();
	}

	// Token: 0x0600937A RID: 37754 RVA: 0x001B8F54 File Offset: 0x001B7354
	public eHpBarType GetBarType()
	{
		return this.type;
	}

	// Token: 0x0600937B RID: 37755 RVA: 0x001B8F5C File Offset: 0x001B735C
	public void SetHPRate(float rate)
	{
		if (null == this || null == this.mHp || null == this.mMaxHpText || null == this.mCurHpText)
		{
			return;
		}
		this.mHp.value = Mathf.Clamp01(rate);
		int num = Math.Max(0, this.mCurHp);
		if (this.m_LastCurHpValue != num)
		{
			this.mCurHpText.text = num.ToString();
			this.m_LastCurHpValue = num;
		}
		if (this.m_LastMaxHpValue != this.mMaxHp)
		{
			this.mMaxHpText.text = this.mMaxHp.ToString();
			this.m_LastMaxHpValue = this.mMaxHp;
		}
		if (BattleMain.instance.GetPlayerManager().GetMainPlayer().playerInfo.seat == this.mSeat)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ShowDeadTips(rate <= this.mRateLimit);
			}
		}
	}

	// Token: 0x0600937C RID: 37756 RVA: 0x001B9078 File Offset: 0x001B7478
	public void SetMPRate(float rate)
	{
		if (null == this || null == this.mMp || null == this.mMpText)
		{
			return;
		}
		this.mMp.value = Mathf.Clamp01(rate);
		int val = (int)(this.mMp.value * (float)this.mMaxMp);
		val = Math.Max(0, val);
	}

	// Token: 0x0600937D RID: 37757 RVA: 0x001B90E4 File Offset: 0x001B74E4
	public void SetIcon(Sprite sprite, Material material)
	{
		if (null == this || null == this.mIcon)
		{
			return;
		}
		if (this.mIcon && sprite != null)
		{
			this.mIcon.sprite = sprite;
			this.mIcon.material = material;
		}
	}

	// Token: 0x0600937E RID: 37758 RVA: 0x001B9143 File Offset: 0x001B7543
	public void SetName(string name, int level)
	{
		if (null == this)
		{
			return;
		}
		this.SetName(name);
		this.SetLevel(level);
	}

	// Token: 0x0600937F RID: 37759 RVA: 0x001B9160 File Offset: 0x001B7560
	public void SetName(string name)
	{
		if (null == this)
		{
			return;
		}
		if (this.mName)
		{
			this.mName.text = string.Format("{0}", name);
		}
	}

	// Token: 0x06009380 RID: 37760 RVA: 0x001B9195 File Offset: 0x001B7595
	public void SetLevel(int level)
	{
		if (null == this)
		{
			return;
		}
		if (this.mLevel != null)
		{
			this.mLevel.text = string.Format("{0}", level);
		}
	}

	// Token: 0x06009381 RID: 37761 RVA: 0x001B91D0 File Offset: 0x001B75D0
	public void SetHP(int curHP, int maxHP)
	{
		this.mMaxHp = maxHP;
		this.mCurHp = curHP;
		this.SetHPRate((float)curHP / (float)maxHP);
	}

	// Token: 0x06009382 RID: 37762 RVA: 0x001B91EB File Offset: 0x001B75EB
	public void SetMP(int curMP, int maxMP)
	{
		this.mMaxMp = maxMP;
		this.mCurMp = maxMP;
		this.SetMPRate((float)curMP / (float)maxMP);
	}

	// Token: 0x06009383 RID: 37763 RVA: 0x001B9208 File Offset: 0x001B7608
	public void Init(int maxHp, int maxMp, int count = 1, int resistVale = 0)
	{
		this.mCurHp = maxHp;
		this.mMaxHp = maxHp;
		this.mCurMp = maxMp;
		this.mMaxMp = maxMp;
		this.SetHP(this.mCurHp, maxHp);
		this.SetMP(this.mCurMp, maxMp);
		this.SetMPRate(1f);
		if (this.mSignal != null)
		{
			this.mSignal.transform.parent.gameObject.CustomActive(BattleMain.IsModeMultiplayer(BattleMain.mode));
		}
		this._updateTeamLeaderFlag();
	}

	// Token: 0x06009384 RID: 37764 RVA: 0x001B9298 File Offset: 0x001B7698
	public void _InitHellDropItemRoot(bool isMainPlayer)
	{
		if (DataManager<BattleDataManager>.GetInstance() == null || DataManager<BattleDataManager>.GetInstance().BattleInfo == null || DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo == null || DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.mode == DungeonHellMode.Null)
		{
			return;
		}
		this.mOpenHellDropEffect = !isMainPlayer;
		if (this.mHellHeadEffect != null)
		{
			if (this.mHellEffect == null)
			{
				this.mHellEffect = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_Shishidiaoluo/Prefab/EffUI_Shishidiaoluo", true, 0U);
			}
			if (this.mHellEffect != null)
			{
				Utility.AttachTo(this.mHellEffect, this.mHellHeadEffect, false);
			}
		}
	}

	// Token: 0x06009385 RID: 37765 RVA: 0x001B9354 File Offset: 0x001B7754
	private void _onPlayerGetHellDropSS(UIEvent ui)
	{
		if (!this.mOpenHellDropEffect)
		{
			return;
		}
		ulong roleId = (ulong)ui.Param1;
		int id = (int)((uint)ui.Param2);
		BattlePlayer playerByRoleID = BattleMain.instance.GetPlayerManager().GetPlayerByRoleID(roleId);
		if (playerByRoleID == null || playerByRoleID.GetPlayerSeat() != this.mSeat)
		{
			return;
		}
		if (this.mHellEffect != null)
		{
			this.mHellEffect.CustomActive(true);
			this.mDropSSEffectTime -= 4.5f;
		}
		if (this.mHellHeadText != null)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Battle/Bars/Charactor/HeadSSDropText", true, 0U);
				if (gameObject != null)
				{
					Utility.AttachTo(gameObject, this.mHellHeadText, false);
					this.mDropItemList.Add(gameObject);
					Text[] componentsInChildren = gameObject.GetComponentsInChildren<Text>(true);
					if (componentsInChildren.Length > 0 && componentsInChildren[0] != null)
					{
						componentsInChildren[0].text = tableItem.Name;
					}
				}
			}
		}
	}

	// Token: 0x06009386 RID: 37766 RVA: 0x001B9477 File Offset: 0x001B7877
	private void UpdateDropSSItem()
	{
		this.UpdateDropSSEffect();
		this.UpdateDropSSText();
	}

	// Token: 0x06009387 RID: 37767 RVA: 0x001B9488 File Offset: 0x001B7888
	private void UpdateDropSSEffect()
	{
		if (this.mDropSSEffectTime < 4.5f)
		{
			this.mDropSSEffectTime += 0.1f;
			if (this.mDropSSEffectTime >= 4.5f && this.mHellEffect != null)
			{
				this.mHellEffect.CustomActive(false);
			}
		}
	}

	// Token: 0x06009388 RID: 37768 RVA: 0x001B94E4 File Offset: 0x001B78E4
	private void UpdateDropSSText()
	{
		if (this.mDropItemList.Count > 0)
		{
			if (this.mUpdateDropItemIndex < this.mDropItemList.Count && this.mUpdateDropItemTime >= 4.5f)
			{
				this.mUpdateDropItemTime = 0f;
				this.mDropItemList[this.mUpdateDropItemIndex++].CustomActive(true);
			}
			else
			{
				this.mUpdateDropItemTime += 0.1f;
				if (this.mDropItemList.Count == this.mUpdateDropItemIndex && this.mUpdateDropItemTime >= 4.5f)
				{
					for (int i = 0; i < this.mDropItemList.Count; i++)
					{
						Object.Destroy(this.mDropItemList[i]);
					}
					this.mDropItemList.Clear();
					this.mUpdateDropItemIndex = 0;
				}
			}
		}
	}

	// Token: 0x06009389 RID: 37769 RVA: 0x001B95D4 File Offset: 0x001B79D4
	private void _updateTeamLeaderFlag()
	{
		if (null != this.mTeamleaderFlag)
		{
			BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
			this.mTeamleaderFlag.SetActive(false);
			if (playerBySeat != null && playerBySeat.playerInfo != null && DataManager<TeamDataManager>.GetInstance().IsTeamLeaderByRoleID(playerBySeat.playerInfo.roleId))
			{
				this.mTeamleaderFlag.SetActive(true);
			}
		}
	}

	// Token: 0x0600938A RID: 37770 RVA: 0x001B964C File Offset: 0x001B7A4C
	private void _updateHpMpValue()
	{
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		if (playerBySeat == null)
		{
			return;
		}
		if (playerBySeat.playerActor == null)
		{
			return;
		}
		BeEntityData entityData = playerBySeat.playerActor.GetEntityData();
		if (entityData == null)
		{
			return;
		}
		this.SetHP(entityData.GetHP(), entityData.GetMaxHP());
		this.SetMP(entityData.GetMP(), entityData.GetMaxMP());
	}

	// Token: 0x0600938B RID: 37771 RVA: 0x001B96BC File Offset: 0x001B7ABC
	private void UpdateResentment()
	{
		if (this.resentment == null)
		{
			return;
		}
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		if (playerBySeat == null)
		{
			return;
		}
		if (playerBySeat.playerActor == null)
		{
			return;
		}
		Mechanism2004 mechanism = playerBySeat.playerActor.GetMechanism(5300) as Mechanism2004;
		if (mechanism == null)
		{
			return;
		}
		this.resentment.CustomActive(true);
		this.resentment.text = mechanism.GetResentmentValue().ToString();
	}

	// Token: 0x0600938C RID: 37772 RVA: 0x001B974C File Offset: 0x001B7B4C
	public void Damage(int value, bool withAiniate = false)
	{
		if (value > 0)
		{
			this._updateHpMpValue();
		}
	}

	// Token: 0x0600938D RID: 37773 RVA: 0x001B975B File Offset: 0x001B7B5B
	public void SetActive(bool active)
	{
		if (null != this && base.gameObject != null)
		{
			base.gameObject.CustomActive(active);
		}
	}

	// Token: 0x0600938E RID: 37774 RVA: 0x001B9786 File Offset: 0x001B7B86
	public void Unload()
	{
	}

	// Token: 0x0600938F RID: 37775 RVA: 0x001B9788 File Offset: 0x001B7B88
	public void SetHidden(bool hidden)
	{
		this.mHidden = hidden;
	}

	// Token: 0x06009390 RID: 37776 RVA: 0x001B9791 File Offset: 0x001B7B91
	public bool GetHidden()
	{
		return this.mHidden;
	}

	// Token: 0x06009391 RID: 37777 RVA: 0x001B979C File Offset: 0x001B7B9C
	public void Update()
	{
		this.mCountTime += Time.deltaTime;
		if (this.mCountTime > 0.1f)
		{
			this.mCountTime = 0f;
			this._updateHpMpValue();
			this.UpdateResentment();
			this.UpdateDropSSItem();
		}
		this.UpdateResentmentChange();
	}

	// Token: 0x06009392 RID: 37778 RVA: 0x001B97F0 File Offset: 0x001B7BF0
	private void UpdateResentmentChange()
	{
		this.calcTime += Time.deltaTime;
		if (this.calcTime > 1f && this.flag)
		{
			this.resentmentChange.CustomActive(false);
			this.flag = false;
			this.calcTime = 0f;
		}
	}

	// Token: 0x06009393 RID: 37779 RVA: 0x001B9848 File Offset: 0x001B7C48
	public void ShowResentmentChange(int value)
	{
		if (this.resentmentText != null)
		{
			if (this.resentmentChange != null)
			{
				Image component = this.resentmentChange.GetComponent<Image>();
				component.color = ((value >= 0) ? Color.white : Color.red);
			}
			string str = (value <= 0) ? string.Empty : "+";
			this.resentmentText.text = str + value.ToString();
			this.resentmentChange.CustomActive(true);
			this.calcTime = 0f;
			this.flag = true;
		}
	}

	// Token: 0x06009394 RID: 37780 RVA: 0x001B98F4 File Offset: 0x001B7CF4
	public void InitResistMagic(int value, BeActor actor)
	{
		int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
		int dungeonResistMagicValueById = DungeonUtility.GetDungeonResistMagicValueById(dungeonID);
		if (dungeonResistMagicValueById == 0)
		{
			return;
		}
		this.SetResistIcon(value, dungeonResistMagicValueById, actor);
	}

	// Token: 0x06009395 RID: 37781 RVA: 0x001B9934 File Offset: 0x001B7D34
	private void SetResistIcon(int value, int dungeonValue, BeActor player)
	{
		if (player == null)
		{
			return;
		}
		for (int i = 0; i < this.ResistMagicBuffID.Length; i++)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleBuffCancel, this.ResistMagicBuffID[i], player, null, null);
		}
		if (value < dungeonValue)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleBuffAdded, this.ResistMagicBuffID[0], player, null, null);
		}
		else if (value == dungeonValue)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleBuffAdded, this.ResistMagicBuffID[1], player, null, null);
		}
		else
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleBuffAdded, this.ResistMagicBuffID[2], player, null, null);
		}
	}

	// Token: 0x06009396 RID: 37782 RVA: 0x001B99F5 File Offset: 0x001B7DF5
	public void SetBuffName(string text)
	{
	}

	// Token: 0x06009397 RID: 37783 RVA: 0x001B99F7 File Offset: 0x001B7DF7
	public void SetHeadPortraitFrame(PlayerLabelInfo playerLabelInfo)
	{
		if (playerLabelInfo == null)
		{
			return;
		}
		if (playerLabelInfo.headFrame != 0U)
		{
			this.mReplaceHeadPortraitFrame.ReplacePhotoFrame((int)playerLabelInfo.headFrame);
		}
		else
		{
			this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
		}
	}

	// Token: 0x04004A72 RID: 19058
	public eHpBarType type = eHpBarType.Player;

	// Token: 0x04004A73 RID: 19059
	public float mRateLimit = 0.2f;

	// Token: 0x04004A74 RID: 19060
	private Image mIcon;

	// Token: 0x04004A75 RID: 19061
	private Text mLevel;

	// Token: 0x04004A76 RID: 19062
	private Text mName;

	// Token: 0x04004A77 RID: 19063
	private Text mHpText;

	// Token: 0x04004A78 RID: 19064
	private Text mCurHpText;

	// Token: 0x04004A79 RID: 19065
	private Text mMaxHpText;

	// Token: 0x04004A7A RID: 19066
	private Text mMpText;

	// Token: 0x04004A7B RID: 19067
	private Button mReborn;

	// Token: 0x04004A7C RID: 19068
	private GameObject mRebornRoot;

	// Token: 0x04004A7D RID: 19069
	private Slider mHp;

	// Token: 0x04004A7E RID: 19070
	private Slider mMp;

	// Token: 0x04004A7F RID: 19071
	private UIGray mIconGray;

	// Token: 0x04004A80 RID: 19072
	private GameObject mIconFg;

	// Token: 0x04004A81 RID: 19073
	private Image mSignal;

	// Token: 0x04004A82 RID: 19074
	private UIGray mSignalgray;

	// Token: 0x04004A83 RID: 19075
	private ComTeamChatMessage mChatMsg;

	// Token: 0x04004A84 RID: 19076
	private UIGray mRebornBtnGray;

	// Token: 0x04004A85 RID: 19077
	private GameObject mTeamleaderFlag;

	// Token: 0x04004A86 RID: 19078
	private ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

	// Token: 0x04004A87 RID: 19079
	private Text resentment;

	// Token: 0x04004A88 RID: 19080
	private GameObject resentmentChange;

	// Token: 0x04004A89 RID: 19081
	private Text resentmentText;

	// Token: 0x04004A8A RID: 19082
	private GameObject mHellHeadEffect;

	// Token: 0x04004A8B RID: 19083
	private GameObject mHellHeadText;

	// Token: 0x04004A8C RID: 19084
	private int m_LastCurHpValue;

	// Token: 0x04004A8D RID: 19085
	private int m_LastMaxHpValue;

	// Token: 0x04004A8E RID: 19086
	private byte mSeat;

	// Token: 0x04004A8F RID: 19087
	private int mMaxHp;

	// Token: 0x04004A90 RID: 19088
	private int mMaxMp;

	// Token: 0x04004A91 RID: 19089
	private int mCurHp;

	// Token: 0x04004A92 RID: 19090
	private int mCurMp;

	// Token: 0x04004A93 RID: 19091
	private bool mOpenHellDropEffect;

	// Token: 0x04004A94 RID: 19092
	private GameObject mHellEffect;

	// Token: 0x04004A95 RID: 19093
	private const float mUpdateOneSSDropItemAcc = 4.5f;

	// Token: 0x04004A96 RID: 19094
	private float mDropSSEffectTime = 4.5f;

	// Token: 0x04004A97 RID: 19095
	private int mUpdateDropItemIndex;

	// Token: 0x04004A98 RID: 19096
	private float mUpdateDropItemTime = 4.5f;

	// Token: 0x04004A99 RID: 19097
	private List<GameObject> mDropItemList = new List<GameObject>();

	// Token: 0x04004A9A RID: 19098
	private bool mHidden;

	// Token: 0x04004A9B RID: 19099
	private float mCountTime;

	// Token: 0x04004A9C RID: 19100
	private bool flag;

	// Token: 0x04004A9D RID: 19101
	private float calcTime;

	// Token: 0x04004A9E RID: 19102
	private int[] ResistMagicBuffID = new int[]
	{
		820001,
		820002,
		820003
	};
}
