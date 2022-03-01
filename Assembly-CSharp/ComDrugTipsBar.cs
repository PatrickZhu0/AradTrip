using System;
using System.Collections;
using System.Collections.Generic;
using GameClient;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000EBF RID: 3775
public class ComDrugTipsBar : MonoBehaviour
{
	// Token: 0x17001908 RID: 6408
	// (get) Token: 0x0600949A RID: 38042 RVA: 0x001BDF17 File Offset: 0x001BC317
	public static ComDrugTipsBar instance
	{
		get
		{
			return ComDrugTipsBar._instance;
		}
	}

	// Token: 0x0600949B RID: 38043 RVA: 0x001BDF20 File Offset: 0x001BC320
	public void Init()
	{
		BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
		if (localPlayer == null)
		{
			return;
		}
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			if (i < localPlayer.playerInfo.potionPos.Length)
			{
				this.mComDrug[i].SetItemID((int)localPlayer.playerInfo.potionPos[i]);
				int count = localPlayer.UseItemById(this.mComDrug[i].mItemId, 0);
				this.mComDrug[i].SetCount(count);
			}
			this.mCacheDrugs.Add(this.mComDrug[i]);
		}
		this.mCacheDrugs.Sort();
		this.SetDrugColumnStat();
	}

	// Token: 0x0600949C RID: 38044 RVA: 0x001BDFCE File Offset: 0x001BC3CE
	private void Awake()
	{
		ComDrugTipsBar._instance = this;
		this._bindEvents();
	}

	// Token: 0x0600949D RID: 38045 RVA: 0x001BDFDC File Offset: 0x001BC3DC
	private void OnDestroy()
	{
		this._unbindEvents();
		this.mCacheDrugs.Clear();
		if (this.mComDrug != null)
		{
			for (int i = 0; i < this.mComDrug.Length; i++)
			{
				if (null != this.mComDrug[i])
				{
					InvokeMethod.RmoveInvokeIntervalCall(this.mComDrug[i]);
				}
			}
		}
	}

	// Token: 0x0600949E RID: 38046 RVA: 0x001BE03E File Offset: 0x001BC43E
	private void _bindEvents()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonQuickBuyPotionSuccess, new ClientEventSystem.UIEventHandler(this._onQuickBuyPostionSuccess));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonQuickBuyPotionFail, new ClientEventSystem.UIEventHandler(this._onQuickBuyPostionFail));
	}

	// Token: 0x0600949F RID: 38047 RVA: 0x001BE076 File Offset: 0x001BC476
	private void _unbindEvents()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonQuickBuyPotionSuccess, new ClientEventSystem.UIEventHandler(this._onQuickBuyPostionSuccess));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonQuickBuyPotionFail, new ClientEventSystem.UIEventHandler(this._onQuickBuyPostionFail));
	}

	// Token: 0x060094A0 RID: 38048 RVA: 0x001BE0B0 File Offset: 0x001BC4B0
	public void SetDrugcolumnState()
	{
		this.mComDrug[1].transform.parent.gameObject.CustomActive(true);
		this.mComDrug[2].transform.parent.gameObject.CustomActive(true);
		this.icon.CustomActive(false);
		base.Invoke("SetDrugColumnStat", 5f);
	}

	// Token: 0x060094A1 RID: 38049 RVA: 0x001BE114 File Offset: 0x001BC514
	public void SetDrugColumnStat()
	{
		this.mComDrug[1].transform.parent.gameObject.CustomActive(false);
		this.mComDrug[2].transform.parent.gameObject.CustomActive(false);
		this.icon.CustomActive(true);
	}

	// Token: 0x060094A2 RID: 38050 RVA: 0x001BE167 File Offset: 0x001BC567
	public void SetRootActive(bool isActive)
	{
		base.gameObject.SetActive(isActive);
	}

	// Token: 0x060094A3 RID: 38051 RVA: 0x001BE178 File Offset: 0x001BC578
	public void UseHpDrug(bool isAuto)
	{
		if (this._isInEndBattle())
		{
			return;
		}
		if (this._isLocalPlayerCanAutoUseHpDrugs(isAuto))
		{
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			int canUseHpDrugIndex = this.GetCanUseHpDrugIndex(isAuto);
			if (canUseHpDrugIndex >= 0 && canUseHpDrugIndex < this.mComDrug.Length)
			{
				if (!this._hasLeftCountByItemId(this.mComDrug[canUseHpDrugIndex].mItemId))
				{
					return;
				}
				if (this.mComDrug[canUseHpDrugIndex].IsCD())
				{
					return;
				}
				ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(this.mComDrug[canUseHpDrugIndex].mItemId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SubType == ItemTable.eSubType.AttributeDrug)
				{
					return;
				}
				this.UseDrugsByIdx(canUseHpDrugIndex);
			}
		}
	}

	// Token: 0x060094A4 RID: 38052 RVA: 0x001BE234 File Offset: 0x001BC634
	private int GetCanUseHpDrugIndex(bool isAuto)
	{
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		float single = mainPlayer.playerActor.GetEntityData().GetHPRate().single;
		float num = (float)DataManager<PlayerBaseData>.GetInstance().GetPotionPercent(PlayerBaseData.PotionSlotType.SlotMain) / 100f;
		float num2 = (float)DataManager<PlayerBaseData>.GetInstance().GetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend1) / 100f;
		bool flag = DataManager<PlayerBaseData>.GetInstance().GetPotionID(PlayerBaseData.PotionSlotType.SlotMain) != 0;
		bool flag2 = DataManager<PlayerBaseData>.GetInstance().GetPotionID(PlayerBaseData.PotionSlotType.SlotExtend1) != 0;
		bool flag3 = DataManager<PlayerBaseData>.GetInstance().IsPotionSlotMainSwitchOn("PotionSlotMainSwitch");
		bool flag4 = DataManager<PlayerBaseData>.GetInstance().IsPotionSlotMainSwitchOn("PotionSlot1Switch");
		if (flag3 && num >= single && flag && !this.mComDrug[0].IsCD())
		{
			int potionID = DataManager<PlayerBaseData>.GetInstance().GetPotionID(PlayerBaseData.PotionSlotType.SlotMain);
			if (potionID > 0)
			{
				return 0;
			}
		}
		if (flag4 && num2 >= single && flag2 && !this.mComDrug[1].IsCD())
		{
			int potionID2 = DataManager<PlayerBaseData>.GetInstance().GetPotionID(PlayerBaseData.PotionSlotType.SlotExtend1);
			if (potionID2 > 0)
			{
				return 1;
			}
		}
		return -1;
	}

	// Token: 0x060094A5 RID: 38053 RVA: 0x001BE358 File Offset: 0x001BC758
	public void UseMPDrug(bool isAuto)
	{
		if (this._isInEndBattle())
		{
			return;
		}
		if (this._isLocalPlayerCanAutoUseMpDrugs())
		{
			int mppotionIndex = DataManager<PlayerBaseData>.GetInstance().GetMPPotionIndex();
			if (mppotionIndex >= 0 && mppotionIndex < this.mComDrug.Length)
			{
				if (!this._hasLeftCountByItemId(this.mComDrug[mppotionIndex].mItemId))
				{
					return;
				}
				if (this.mComDrug[mppotionIndex].IsCD())
				{
					return;
				}
				ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(this.mComDrug[mppotionIndex].mItemId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SubType == ItemTable.eSubType.AttributeDrug)
				{
					return;
				}
				this.UseDrugsByIdx(mppotionIndex);
			}
		}
	}

	// Token: 0x060094A6 RID: 38054 RVA: 0x001BE408 File Offset: 0x001BC808
	private int GetLifeHpItem()
	{
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			if (this.mComDrug[i].mItemId == 200001001 && this.mComDrug[i].mLeftCount > 0)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060094A7 RID: 38055 RVA: 0x001BE45C File Offset: 0x001BC85C
	private int _getFirstAutoUseDrugIdxByType(ItemTable.eSubType subType)
	{
		for (int i = 0; i < this.mCacheDrugs.Count; i++)
		{
			if (!(null == this.mCacheDrugs[i]))
			{
				if (this.mCacheDrugs[i].itemSubType == subType)
				{
					if (!this.mCacheDrugs[i].IsCD())
					{
						if (this._hasLeftCountByItemId(this.mCacheDrugs[i].mItemId))
						{
							for (int j = 0; j < this.mComDrug.Length; j++)
							{
								if (this.mComDrug[j] == this.mCacheDrugs[i])
								{
									return j;
								}
							}
							break;
						}
					}
				}
			}
		}
		return -1;
	}

	// Token: 0x060094A8 RID: 38056 RVA: 0x001BE538 File Offset: 0x001BC938
	private bool _hasLeftCount(int idx)
	{
		return idx >= 0 && idx < this.mComDrug.Length && this._hasLeftCountByItemId(this.mComDrug[idx].mItemId);
	}

	// Token: 0x060094A9 RID: 38057 RVA: 0x001BE564 File Offset: 0x001BC964
	private bool _hasLeftCountByItemId(int itemId)
	{
		BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
		return localPlayer.CanUseItemById(itemId, 1);
	}

	// Token: 0x060094AA RID: 38058 RVA: 0x001BE588 File Offset: 0x001BC988
	private bool _isAllDrugsEmpty()
	{
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			if (this._hasLeftCount(i))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060094AB RID: 38059 RVA: 0x001BE5BD File Offset: 0x001BC9BD
	public void SwitchNext()
	{
	}

	// Token: 0x060094AC RID: 38060 RVA: 0x001BE5BF File Offset: 0x001BC9BF
	public void OnExpandClick()
	{
	}

	// Token: 0x060094AD RID: 38061 RVA: 0x001BE5C4 File Offset: 0x001BC9C4
	private void _setItemMode(bool isExpand)
	{
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			this.mComDrug[i].SetMode((!isExpand) ? ComDrug.eMode.Click : ComDrug.eMode.Drag);
		}
	}

	// Token: 0x060094AE RID: 38062 RVA: 0x001BE604 File Offset: 0x001BCA04
	public void UseDrugsByIdx(int idx)
	{
		if (this._isPlayerDead())
		{
			return;
		}
		if (!FrameSync.instance.isFire)
		{
			return;
		}
		if (this._isAllDrugsEmpty())
		{
			this._quickBuyPotionProcess();
		}
		else if (this._checkConditionByIndexWithTips(idx))
		{
			if (idx < 0 || idx >= this.mComDrug.Length)
			{
				return;
			}
			if (null == this.mComDrug[idx])
			{
				return;
			}
			if (this.mComDrug[idx].locked)
			{
				return;
			}
			InvokeMethod.RmoveInvokeIntervalCall(this.mComDrug[idx]);
			this.mComDrug[idx].locked = true;
			InvokeMethod.InvokeInterval(this.mComDrug[idx], 0.25f, 0f, 0f, null, null, delegate
			{
				this.mComDrug[idx].locked = false;
			});
			if (this.UseDrugCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.UseDrugCoroutine);
			}
			this.UseDrugCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._useItemIter(idx));
		}
		this.SetDrugColumnStat();
	}

	// Token: 0x060094AF RID: 38063 RVA: 0x001BE74C File Offset: 0x001BCB4C
	private void _quickBuyPotionProcess()
	{
		if (this._canQuickBuy(this.quickBuyPotionID, (int)this.quickBuyPotionCount))
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(ChapterBattlePotionSetUtiilty.QuickBuyPostion(this.quickBuyPotionID, (int)this.quickBuyPotionCount));
		}
		else
		{
			SystemNotifyManager.SystemNotify(8513, string.Empty);
		}
	}

	// Token: 0x060094B0 RID: 38064 RVA: 0x001BE7A0 File Offset: 0x001BCBA0
	private bool _canQuickBuy(int id, int count)
	{
		QuickBuyTable tableItem = Singleton<TableManager>.instance.GetTableItem<QuickBuyTable>(id, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return false;
		}
		int num = tableItem.CostNum * count;
		int costItemID = tableItem.CostItemID;
		ItemTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ItemTable>(costItemID, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return false;
		}
		ItemTable.eSubType subType = tableItem2.SubType;
		if (subType != ItemTable.eSubType.GOLD)
		{
			if (subType != ItemTable.eSubType.POINT)
			{
				if (subType == ItemTable.eSubType.BindGOLD)
				{
					goto IL_8A;
				}
				if (subType != ItemTable.eSubType.BindPOINT)
				{
					return false;
				}
			}
			return DataManager<PlayerBaseData>.GetInstance().CanUseTicket((ulong)((long)num));
		}
		IL_8A:
		return DataManager<PlayerBaseData>.GetInstance().CanUseGold((ulong)((long)num));
	}

	// Token: 0x060094B1 RID: 38065 RVA: 0x001BE845 File Offset: 0x001BCC45
	private bool _isInEndBattle()
	{
		return BattleMain.instance != null && BattleMain.instance.Main != null && BattleMain.instance.Main.state >= BeSceneState.onBulletTime;
	}

	// Token: 0x060094B2 RID: 38066 RVA: 0x001BE878 File Offset: 0x001BCC78
	private bool _isLocalPlayerCanAutoUseHpDrugs(bool isAuto)
	{
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		if (mainPlayer == null)
		{
			return false;
		}
		if (this._isBattleFinish())
		{
			return false;
		}
		if (!FrameSync.instance.isFire)
		{
			return false;
		}
		if (this._isPlayerDead())
		{
			return false;
		}
		float single = mainPlayer.playerActor.GetEntityData().GetHPRate().single;
		return (float)DataManager<PlayerBaseData>.GetInstance().GetHPPotionPercentMax() / 100f > single;
	}

	// Token: 0x060094B3 RID: 38067 RVA: 0x001BE8F8 File Offset: 0x001BCCF8
	private bool _isLocalPlayerCanAutoUseMpDrugs()
	{
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		if (mainPlayer == null)
		{
			return false;
		}
		if (this._isBattleFinish())
		{
			return false;
		}
		if (!FrameSync.instance.isFire)
		{
			return false;
		}
		if (DataManager<PlayerBaseData>.GetInstance().VipLevel <= 0)
		{
			return false;
		}
		this.autoUseMpRate = (float)DataManager<PlayerBaseData>.GetInstance().GetMPPotionPercentMax() / 100f;
		return !this._isPlayerDead() && mainPlayer.playerActor.GetEntityData().GetMPRate().single < this.autoUseMpRate;
	}

	// Token: 0x060094B4 RID: 38068 RVA: 0x001BE994 File Offset: 0x001BCD94
	private bool _isPlayerDead()
	{
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		if (mainPlayer == null || mainPlayer.playerActor == null)
		{
			return false;
		}
		BeEntityData entityData = mainPlayer.playerActor.GetEntityData();
		return entityData != null && entityData.GetHP() <= 0;
	}

	// Token: 0x060094B5 RID: 38069 RVA: 0x001BE9E4 File Offset: 0x001BCDE4
	private bool _isBattleFinish()
	{
		if (BattleMain.instance == null)
		{
			return true;
		}
		BeScene main = BattleMain.instance.Main;
		return main == null || BeSceneState.onFinish == main.state;
	}

	// Token: 0x060094B6 RID: 38070 RVA: 0x001BEA1C File Offset: 0x001BCE1C
	private bool _checkConditionByIndexWithTips(int index)
	{
		if (BattleMain.instance == null)
		{
			return false;
		}
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		if (mainPlayer == null)
		{
			return false;
		}
		BeEntityData entityData = mainPlayer.playerActor.GetEntityData();
		int hp = entityData.GetHP();
		int maxHP = entityData.GetMaxHP();
		int mp = entityData.GetMP();
		int maxMP = entityData.GetMaxMP();
		int mItemId = this.mComDrug[index].mItemId;
		ItemTable.eSubType itemSubType = this.mComDrug[index].itemSubType;
		bool flag = false;
		switch (itemSubType)
		{
		case ItemTable.eSubType.Hp:
			flag = (hp < maxHP);
			goto IL_CB;
		case ItemTable.eSubType.Mp:
			flag = (mp < maxMP);
			goto IL_CB;
		case ItemTable.eSubType.HpMp:
			break;
		default:
			if (itemSubType != ItemTable.eSubType.ST_NONE)
			{
				if (itemSubType != ItemTable.eSubType.AttributeDrug)
				{
					goto IL_CB;
				}
				return true;
			}
			break;
		}
		flag = (mp < maxMP || hp < maxHP);
		IL_CB:
		if (!flag)
		{
			ItemConfigTable itemConfigTalbeByID = ChapterBattlePotionSetUtiilty.GetItemConfigTalbeByID(mItemId);
			if (itemConfigTalbeByID != null)
			{
				SystemNotifyManager.SystemNotify(itemConfigTalbeByID.InvalidTipsID, string.Empty);
			}
		}
		return flag;
	}

	// Token: 0x060094B7 RID: 38071 RVA: 0x001BEB20 File Offset: 0x001BCF20
	private IEnumerator _useItemIter(int index)
	{
		ComDrug curItem = this.mComDrug[index];
		if (null == curItem)
		{
			yield break;
		}
		if (curItem.IsCD())
		{
			yield break;
		}
		BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
		if (localPlayer.CanUseItemById(curItem.mItemId, 1))
		{
			if (this.useStat == ComDrugTipsBar.UseState.idle)
			{
				yield return this._realUseDrug(index);
			}
		}
		else if (this._canQuickBuyByType(curItem.itemSubType))
		{
			this._quickBuyPotionProcess();
		}
		yield break;
	}

	// Token: 0x060094B8 RID: 38072 RVA: 0x001BEB44 File Offset: 0x001BCF44
	private bool _canQuickBuyByType(ItemTable.eSubType subType)
	{
		switch (subType)
		{
		case ItemTable.eSubType.Hp:
		case ItemTable.eSubType.Mp:
			break;
		case ItemTable.eSubType.HpMp:
			if (this._isDrugsEmptyByType(subType))
			{
				return true;
			}
			return false;
		default:
			if (subType != ItemTable.eSubType.ST_NONE)
			{
				return false;
			}
			break;
		}
		if (this._isJustTakePureHpOrPureMpOrEmpty() && (this._isDrugsEmptyByType(ItemTable.eSubType.Hp) || this._isDrugsEmptyByType(ItemTable.eSubType.Mp)))
		{
			return true;
		}
		return false;
	}

	// Token: 0x060094B9 RID: 38073 RVA: 0x001BEBB4 File Offset: 0x001BCFB4
	private bool _isJustTakePureHpOrPureMpOrEmpty()
	{
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			if (this.mComDrug[i].itemSubType == ItemTable.eSubType.HpMp)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060094BA RID: 38074 RVA: 0x001BEBF4 File Offset: 0x001BCFF4
	private bool _isDrugsEmptyByType(ItemTable.eSubType subType)
	{
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			if (this.mComDrug[i].itemSubType == subType && this._hasLeftCountByItemId(this.mComDrug[i].mItemId))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060094BB RID: 38075 RVA: 0x001BEC48 File Offset: 0x001BD048
	private void _onQuickBuyPostionFail(UIEvent ui)
	{
	}

	// Token: 0x060094BC RID: 38076 RVA: 0x001BEC4C File Offset: 0x001BD04C
	private void _onQuickBuyPostionSuccess(UIEvent ui)
	{
		int count = BattleMain.instance.GetLocalPlayer(0UL).AddItemById(this.quickBuyPotionID, this.quickBuyPotionCount);
		int num = this._getQuickBuyPotionIDIndex();
		this.mComDrug[num].SetItemID(this.quickBuyPotionID);
		this.mComDrug[num].SetCount(count);
		this.mCacheDrugs.Sort();
		if (this._isPlayerNeedUseDrugAfterQuickBuy())
		{
			this.UseDrugsByIdx(num);
		}
	}

	// Token: 0x060094BD RID: 38077 RVA: 0x001BECBC File Offset: 0x001BD0BC
	private int _getQuickBuyPotionIDIndex()
	{
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			if (this.quickBuyPotionID == this.mComDrug[i].mItemId)
			{
				return i;
			}
		}
		for (int j = 0; j < this.mComDrug.Length; j++)
		{
			if (!this._hasLeftCountByItemId(this.mComDrug[j].mItemId))
			{
				return j;
			}
		}
		return 0;
	}

	// Token: 0x060094BE RID: 38078 RVA: 0x001BED30 File Offset: 0x001BD130
	private bool _isPlayerNeedUseDrugAfterQuickBuy()
	{
		BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
		if (localPlayer == null)
		{
			return false;
		}
		BeActor playerActor = localPlayer.playerActor;
		if (playerActor == null)
		{
			return false;
		}
		BeEntityData entityData = playerActor.GetEntityData();
		return entityData != null && entityData.GetHPRate().single < this.quickBuyPotionUseHPRate;
	}

	// Token: 0x060094BF RID: 38079 RVA: 0x001BED88 File Offset: 0x001BD188
	private IEnumerator _realUseDrug(int index)
	{
		ComDrug curItem = this.mComDrug[index];
		if (null == curItem)
		{
			yield break;
		}
		ItemData itemData = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(curItem.mItemId, false, false);
		BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
		if (itemData != null)
		{
			SceneUseItem msg = new SceneUseItem();
			msg.uid = itemData.GUID;
			SceneUseItemRet msgRet = new SceneUseItemRet();
			MessageEvents msgEvent = new MessageEvents();
			yield return MessageUtility.WaitWithResend<SceneUseItem, SceneUseItemRet>(ServerType.GATE_SERVER, msgEvent, msg, msgRet, false, 3.5f, null);
			if (!msgEvent.IsAllMessageReceived())
			{
				yield break;
			}
			if (msgRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
			}
			else
			{
				int count = localPlayer.UseItemById(curItem.mItemId, 1);
				curItem.SetCount(count);
				curItem.PlayEffect();
				this._startCDByType(curItem.itemSubType, (float)itemData.CD);
			}
			this.useStat = ComDrugTipsBar.UseState.idle;
		}
		else
		{
			Logger.LogError("[PotionSet] 数据为空");
		}
		yield break;
	}

	// Token: 0x060094C0 RID: 38080 RVA: 0x001BEDAC File Offset: 0x001BD1AC
	private void _startCDByType(ItemTable.eSubType subType, float cdTime)
	{
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			if (this.mComDrug[i].itemSubType == subType)
			{
				this.mComDrug[i].StartCD(cdTime);
			}
		}
	}

	// Token: 0x060094C1 RID: 38081 RVA: 0x001BEDF4 File Offset: 0x001BD1F4
	public void Update()
	{
		for (int i = 0; i < this.mComDrug.Length; i++)
		{
			bool flag = this.mComDrug[i].IsCD();
			float fillAmount = this.mComDrug[i].mBar.fillAmount;
			this.mImages[i].fillAmount = fillAmount;
			this.mComDrug[i].RealUpdate();
			bool flag2 = this.mComDrug[i].IsCD();
			if (flag && !flag2)
			{
				this.UseHpDrug(true);
				this.UseMPDrug(true);
			}
		}
	}

	// Token: 0x060094C2 RID: 38082 RVA: 0x001BEE7E File Offset: 0x001BD27E
	private float _getRate(float rate)
	{
		return rate * this.fullRate;
	}

	// Token: 0x060094C3 RID: 38083 RVA: 0x001BEE88 File Offset: 0x001BD288
	private Quaternion _getRotate(int idx, float rate)
	{
		float num = this.fullRate * 360f;
		float num2 = num * (float)idx + ((!this.isRoateWithMiddle) ? (-num * 0.5f) : (Mathf.Clamp01(rate) * num * 0.5f));
		return Quaternion.Euler(0f, 0f, num2);
	}

	// Token: 0x04004B68 RID: 19304
	public int quickBuyPotionID = 200001004;

	// Token: 0x04004B69 RID: 19305
	public ushort quickBuyPotionCount = 10;

	// Token: 0x04004B6A RID: 19306
	public float quickBuyPotionUseHPRate = 0.6f;

	// Token: 0x04004B6B RID: 19307
	public float autoUseHpRate = 0.5f;

	// Token: 0x04004B6C RID: 19308
	public float autoUseMpRate = 0.5f;

	// Token: 0x04004B6D RID: 19309
	public float fullRate = 0.25f;

	// Token: 0x04004B6E RID: 19310
	public bool isRoateWithMiddle;

	// Token: 0x04004B6F RID: 19311
	public ComDrug[] mComDrug;

	// Token: 0x04004B70 RID: 19312
	public Image[] mImages;

	// Token: 0x04004B71 RID: 19313
	public Image icon;

	// Token: 0x04004B72 RID: 19314
	public int mUnitWeidth = 100;

	// Token: 0x04004B73 RID: 19315
	private int mSelectComDrugIdx;

	// Token: 0x04004B74 RID: 19316
	private Coroutine UseDrugCoroutine;

	// Token: 0x04004B75 RID: 19317
	private object comDrugLock = new object();

	// Token: 0x04004B76 RID: 19318
	private static ComDrugTipsBar _instance;

	// Token: 0x04004B77 RID: 19319
	private ComDrugTipsBar.eState mState = ComDrugTipsBar.eState.onContract;

	// Token: 0x04004B78 RID: 19320
	private ComDrugTipsBar.UseState useStat;

	// Token: 0x04004B79 RID: 19321
	private List<ComDrug> mCacheDrugs = new List<ComDrug>();

	// Token: 0x02000EC0 RID: 3776
	public enum eState
	{
		// Token: 0x04004B7B RID: 19323
		onExpand,
		// Token: 0x04004B7C RID: 19324
		onContract
	}

	// Token: 0x02000EC1 RID: 3777
	public enum UseState
	{
		// Token: 0x04004B7E RID: 19326
		idle,
		// Token: 0x04004B7F RID: 19327
		waitingForResult
	}
}
