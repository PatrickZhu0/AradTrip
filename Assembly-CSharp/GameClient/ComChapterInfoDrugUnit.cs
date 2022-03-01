using System;
using System.Collections;
using System.Collections.Generic;
using Battle;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E8A RID: 3722
	public class ComChapterInfoDrugUnit : ComBaseComponet
	{
		// Token: 0x06009349 RID: 37705 RVA: 0x001B7723 File Offset: 0x001B5B23
		protected override void Init()
		{
			this._updateState(this.mID);
		}

		// Token: 0x0600934A RID: 37706 RVA: 0x001B7731 File Offset: 0x001B5B31
		protected override void UnInit()
		{
		}

		// Token: 0x17001904 RID: 6404
		// (get) Token: 0x0600934B RID: 37707 RVA: 0x001B7733 File Offset: 0x001B5B33
		// (set) Token: 0x0600934C RID: 37708 RVA: 0x001B773B File Offset: 0x001B5B3B
		public ComChapterInfoDrugUnit.eMarkState markState
		{
			get
			{
				return this.mMarkState;
			}
			set
			{
				this.mMarkState = value;
				this.mChecktoggle.isOn = (this.mMarkState == ComChapterInfoDrugUnit.eMarkState.Marked);
			}
		}

		// Token: 0x17001905 RID: 6405
		// (get) Token: 0x0600934D RID: 37709 RVA: 0x001B7758 File Offset: 0x001B5B58
		// (set) Token: 0x0600934E RID: 37710 RVA: 0x001B7760 File Offset: 0x001B5B60
		private ComChapterInfoDrugUnit.eState state
		{
			get
			{
				return this.mState;
			}
			set
			{
				if (this.mState != value)
				{
					this.mState = value;
					this._updateBg(value);
				}
			}
		}

		// Token: 0x0600934F RID: 37711 RVA: 0x001B777C File Offset: 0x001B5B7C
		private void _updateBg(ComChapterInfoDrugUnit.eState state)
		{
			if (null != this.mBind)
			{
				GameObject gameObject = this.mBind.GetGameObject("checkmask");
				if (state != ComChapterInfoDrugUnit.eState.Ready)
				{
					if (state == ComChapterInfoDrugUnit.eState.Used)
					{
						gameObject.CustomActive(true);
					}
				}
				else
				{
					gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x06009350 RID: 37712 RVA: 0x001B77D8 File Offset: 0x001B5BD8
		public void LoadUnit(int id)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mID = id;
				this._init(this.mBind, id, tableItem.Icon);
				this._updateState(id);
				this._updateCost(id);
			}
		}

		// Token: 0x06009351 RID: 37713 RVA: 0x001B7829 File Offset: 0x001B5C29
		public void UnloadUnit()
		{
			this._uninit(this.mBind);
		}

		// Token: 0x06009352 RID: 37714 RVA: 0x001B7837 File Offset: 0x001B5C37
		public void UpdateCount()
		{
			this._updateState(this.mID);
		}

		// Token: 0x06009353 RID: 37715 RVA: 0x001B7845 File Offset: 0x001B5C45
		public void UpdateCost()
		{
			this._updateCost(this.mID);
			this._updateState(this.mID);
		}

		// Token: 0x06009354 RID: 37716 RVA: 0x001B7860 File Offset: 0x001B5C60
		private string _getName(int id)
		{
			BuffDrugConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffDrugConfigTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Name;
			}
			return string.Empty;
		}

		// Token: 0x06009355 RID: 37717 RVA: 0x001B7898 File Offset: 0x001B5C98
		private string _getDescription(int id)
		{
			BuffDrugConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffDrugConfigTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Description;
			}
			return string.Empty;
		}

		// Token: 0x06009356 RID: 37718 RVA: 0x001B78D0 File Offset: 0x001B5CD0
		private bool _isFree2Use(int id)
		{
			BuffDrugConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffDrugConfigTable>(id, string.Empty, string.Empty);
			return tableItem != null && tableItem.FreeUseLevel >= (int)DataManager<PlayerBaseData>.GetInstance().Level;
		}

		// Token: 0x06009357 RID: 37719 RVA: 0x001B7910 File Offset: 0x001B5D10
		private ComChapterInfoDrugUnit.eCostType _getCostType(int id)
		{
			QuickBuyTable tableItem = Singleton<TableManager>.instance.GetTableItem<QuickBuyTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return ComChapterInfoDrugUnit.eCostType.Gold;
			}
			ItemTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ItemTable>(tableItem.CostItemID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				ItemTable.eSubType subType = tableItem2.SubType;
				if (subType != ItemTable.eSubType.GOLD)
				{
					if (subType != ItemTable.eSubType.POINT)
					{
						if (subType == ItemTable.eSubType.BindGOLD)
						{
							return ComChapterInfoDrugUnit.eCostType.Gold;
						}
						if (subType != ItemTable.eSubType.BindPOINT)
						{
							return ComChapterInfoDrugUnit.eCostType.Gold;
						}
					}
					return ComChapterInfoDrugUnit.eCostType.Point;
				}
				return ComChapterInfoDrugUnit.eCostType.Gold;
			}
			return ComChapterInfoDrugUnit.eCostType.Gold;
		}

		// Token: 0x06009358 RID: 37720 RVA: 0x001B7990 File Offset: 0x001B5D90
		private int _getCost(int id)
		{
			QuickBuyTable tableItem = Singleton<TableManager>.instance.GetTableItem<QuickBuyTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.CostNum;
			}
			return 0;
		}

		// Token: 0x06009359 RID: 37721 RVA: 0x001B79C1 File Offset: 0x001B5DC1
		private int _getCnt(int id)
		{
			return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(id, true);
		}

		// Token: 0x0600935A RID: 37722 RVA: 0x001B79D0 File Offset: 0x001B5DD0
		private void _init(ComCommonBind bind, int id, string iconpath)
		{
			if (null != bind)
			{
				Image com = bind.GetCom<Image>("icon");
				Text com2 = bind.GetCom<Text>("name");
				Text com3 = bind.GetCom<Text>("desc");
				Button com4 = bind.GetCom<Button>("usebutton");
				ETCImageLoader.LoadSprite(ref com, iconpath, true);
				com2.text = this._getName(id);
				com3.text = this._getDescription(id);
			}
		}

		// Token: 0x0600935B RID: 37723 RVA: 0x001B7A40 File Offset: 0x001B5E40
		private void _uninit(ComCommonBind bind)
		{
			if (null != bind)
			{
				Button com = bind.GetCom<Button>("usebutton");
				if (null != com)
				{
					com.onClick.RemoveAllListeners();
				}
			}
		}

		// Token: 0x0600935C RID: 37724 RVA: 0x001B7A7C File Offset: 0x001B5E7C
		private void _updateState(int id)
		{
			this.state = ((!this._isUsed(id)) ? ComChapterInfoDrugUnit.eState.Ready : ComChapterInfoDrugUnit.eState.Used);
			this.markState = ((!DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugMarked(this.mID)) ? ComChapterInfoDrugUnit.eMarkState.UnMarked : ComChapterInfoDrugUnit.eMarkState.Marked);
		}

		// Token: 0x0600935D RID: 37725 RVA: 0x001B7ABC File Offset: 0x001B5EBC
		private void _updateCostEx()
		{
			if (null != this.mBind)
			{
				Text com = this.mBind.GetCom<Text>("cost");
				Image com2 = this.mBind.GetCom<Image>("costicon");
				if (this.state == ComChapterInfoDrugUnit.eState.Used)
				{
					if (null != com2)
					{
						com2.enabled = false;
					}
					com.text = "<color=#418fc5>已使用</color>";
				}
			}
		}

		// Token: 0x0600935E RID: 37726 RVA: 0x001B7B28 File Offset: 0x001B5F28
		private void _updateCost(int id)
		{
			ChapterBuffDrugManager.eBuffDrugUseType buffDrugType = ChapterBuffDrugManager.GetBuffDrugType(this.mID);
			this.mCount.text = ChapterBuffDrugManager.GetBuffDrugCount(this.mID).ToString();
			switch (buffDrugType)
			{
			case ChapterBuffDrugManager.eBuffDrugUseType.None:
				this.mCostRoot.SetActive(false);
				this.mCosticon.enabled = false;
				this.mCost.text = string.Empty;
				break;
			case ChapterBuffDrugManager.eBuffDrugUseType.FreeUse:
				this.mCostRoot.SetActive(true);
				this.mCosticon.enabled = false;
				this.mCost.text = "<color=#00ff78>免费</color>";
				break;
			case ChapterBuffDrugManager.eBuffDrugUseType.PackageUse:
				this.mCostRoot.SetActive(false);
				this.mCosticon.enabled = false;
				this.mCost.text = string.Empty;
				break;
			case ChapterBuffDrugManager.eBuffDrugUseType.PayUse:
			case ChapterBuffDrugManager.eBuffDrugUseType.NotEnoughPay2Use:
			{
				CostItemManager.CostInfo buffDrugCost = ChapterBuffDrugManager.GetBuffDrugCost(this.mID);
				this.mCost.text = string.Format("{0}", buffDrugCost.nCount);
				this.mCostRoot.SetActive(true);
				this.mCosticon.enabled = true;
				ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(buffDrugCost.nMoneyID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ItemTable.eSubType subType = tableItem.SubType;
					if (subType != ItemTable.eSubType.GOLD)
					{
						if (subType != ItemTable.eSubType.POINT)
						{
							if (subType == ItemTable.eSubType.BindGOLD)
							{
								goto IL_13F;
							}
							if (subType != ItemTable.eSubType.BindPOINT)
							{
								break;
							}
						}
						this.mBind.GetSprite("point", ref this.mCosticon);
						break;
					}
					IL_13F:
					this.mBind.GetSprite("gold", ref this.mCosticon);
				}
				break;
			}
			}
		}

		// Token: 0x0600935F RID: 37727 RVA: 0x001B7CDC File Offset: 0x001B60DC
		private bool _canUseItem(int id)
		{
			CostItemManager.CostInfo buffDrugCost = ChapterBuffDrugManager.GetBuffDrugCost(id);
			return DataManager<CostItemManager>.GetInstance().IsEnough2Cost(buffDrugCost);
		}

		// Token: 0x06009360 RID: 37728 RVA: 0x001B7CFC File Offset: 0x001B60FC
		private void _onUseDrug(int id)
		{
			if (this.state == ComChapterInfoDrugUnit.eState.Ready)
			{
				this.state = ComChapterInfoDrugUnit.eState.Wait;
				if (this._isFree2Use(id))
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._useItem());
					Singleton<GameStatisticManager>.instance.DoStatDrugUse(id, "free");
				}
				else
				{
					int num = this._getCnt(id);
					if (num > 0)
					{
						this._usePackageItem(id);
						Singleton<GameStatisticManager>.instance.DoStatDrugUse(id, "package");
					}
					else if (this._canUseItem(id))
					{
						int num2 = this._getCost(id);
						ComChapterInfoDrugUnit.eCostType eCostType = this._getCostType(id);
						MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._quickBuy(id));
						Singleton<GameStatisticManager>.instance.DoStatDrugUse(id, "pay&use");
					}
					else
					{
						this.state = ComChapterInfoDrugUnit.eState.Ready;
					}
				}
			}
		}

		// Token: 0x06009361 RID: 37729 RVA: 0x001B7DC8 File Offset: 0x001B61C8
		private byte _getBuffDrugIdx(int id, int itemid)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				FlatBufferArray<int> buffDrugConfig = tableItem.BuffDrugConfig;
				for (int i = 0; i < buffDrugConfig.Count; i++)
				{
					if (buffDrugConfig[i] == itemid)
					{
						return (byte)i;
					}
				}
			}
			return byte.MaxValue;
		}

		// Token: 0x06009362 RID: 37730 RVA: 0x001B7E24 File Offset: 0x001B6224
		private void _usePackageItem(int id)
		{
			ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(id, true, true);
			DataManager<ItemDataManager>.GetInstance().UseItem(itemByTableID, false, 0, 0);
		}

		// Token: 0x06009363 RID: 37731 RVA: 0x001B7E50 File Offset: 0x001B6250
		private IEnumerator _useItem()
		{
			MessageEvents msg = new MessageEvents();
			SceneQuickUseItemRet res = new SceneQuickUseItemRet();
			SceneQuickUseItemReq req = new SceneQuickUseItemReq();
			int id = ChapterBaseFrame.sDungeonID;
			req.dungenid = (uint)id;
			req.idx = this._getBuffDrugIdx(id, this.mID);
			yield return MessageUtility.Wait<SceneQuickUseItemReq, SceneQuickUseItemRet>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			if (msg.IsAllMessageReceived())
			{
				if (res.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)res.code, string.Empty);
				}
				else
				{
					SystemNotifyManager.SystemNotify(5010, string.Empty);
				}
			}
			this._updateState(this.mID);
			yield break;
		}

		// Token: 0x06009364 RID: 37732 RVA: 0x001B7E6C File Offset: 0x001B626C
		private IEnumerator _quickBuy(int id)
		{
			yield return this._useItem();
			yield break;
		}

		// Token: 0x06009365 RID: 37733 RVA: 0x001B7E88 File Offset: 0x001B6288
		private bool _isUsed(int id)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int buffID = tableItem.OnUseBuffId;
				IList<int> buffIDs = tableItem.MutexBuff;
				Battle.DungeonBuff dungeonBuff = DataManager<PlayerBaseData>.GetInstance().buffList.Find(delegate(Battle.DungeonBuff x)
				{
					if (x.id == buffID)
					{
						return true;
					}
					for (int i = 0; i < buffIDs.Count; i++)
					{
						if (x.id == buffIDs[i])
						{
							return true;
						}
					}
					return false;
				});
				return dungeonBuff != null;
			}
			return false;
		}

		// Token: 0x06009366 RID: 37734 RVA: 0x001B7EF4 File Offset: 0x001B62F4
		protected override void _bindExUI()
		{
			this.mCount = this.mBind.GetCom<Text>("count");
			this.mName = this.mBind.GetCom<Text>("name");
			this.mIcon = this.mBind.GetCom<Image>("icon");
			this.mCost = this.mBind.GetCom<Text>("cost");
			this.mUsebutton = this.mBind.GetCom<Button>("usebutton");
			this.mUsebutton.onClick.AddListener(new UnityAction(this._onUsebuttonButtonClick));
			this.mBg = this.mBind.GetCom<Image>("bg");
			this.mCosticon = this.mBind.GetCom<Image>("costicon");
			this.mDesc = this.mBind.GetCom<Text>("desc");
			this.mCheckmask = this.mBind.GetGameObject("checkmask");
			this.mChecktoggle = this.mBind.GetCom<Toggle>("checktoggle");
			this.mChecktoggle.onValueChanged.AddListener(new UnityAction<bool>(this._onChecktoggleToggleValueChange));
			this.mCostRoot = this.mBind.GetGameObject("costRoot");
		}

		// Token: 0x06009367 RID: 37735 RVA: 0x001B802C File Offset: 0x001B642C
		protected override void _unbindExUI()
		{
			this.mCount = null;
			this.mName = null;
			this.mIcon = null;
			this.mCost = null;
			this.mUsebutton.onClick.RemoveListener(new UnityAction(this._onUsebuttonButtonClick));
			this.mUsebutton = null;
			this.mBg = null;
			this.mCosticon = null;
			this.mDesc = null;
			this.mCheckmask = null;
			this.mChecktoggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onChecktoggleToggleValueChange));
			this.mChecktoggle = null;
			this.mCostRoot = null;
		}

		// Token: 0x06009368 RID: 37736 RVA: 0x001B80C0 File Offset: 0x001B64C0
		private void _onUsebuttonButtonClick()
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1235, string.Empty);
				return;
			}
			ComChapterInfoDrugUnit.eMarkState markState = this.markState;
			if (markState != ComChapterInfoDrugUnit.eMarkState.Marked)
			{
				if (markState == ComChapterInfoDrugUnit.eMarkState.UnMarked)
				{
					DataManager<ChapterBuffDrugManager>.GetInstance().MarkBuffDrug2Use(this.mID);
				}
			}
			else
			{
				DataManager<ChapterBuffDrugManager>.GetInstance().UnMarkBuffDrug2Use(this.mID);
			}
			this.markState = ((!DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugMarked(this.mID)) ? ComChapterInfoDrugUnit.eMarkState.UnMarked : ComChapterInfoDrugUnit.eMarkState.Marked);
		}

		// Token: 0x06009369 RID: 37737 RVA: 0x001B8153 File Offset: 0x001B6553
		private void _onChecktoggleToggleValueChange(bool changed)
		{
		}

		// Token: 0x04004A53 RID: 19027
		private ComChapterInfoDrugUnit.eMarkState mMarkState = ComChapterInfoDrugUnit.eMarkState.UnMarked;

		// Token: 0x04004A54 RID: 19028
		private int mID;

		// Token: 0x04004A55 RID: 19029
		private ComChapterInfoDrugUnit.eState mState;

		// Token: 0x04004A56 RID: 19030
		private Text mCount;

		// Token: 0x04004A57 RID: 19031
		private Text mName;

		// Token: 0x04004A58 RID: 19032
		private Image mIcon;

		// Token: 0x04004A59 RID: 19033
		private Text mCost;

		// Token: 0x04004A5A RID: 19034
		private Button mUsebutton;

		// Token: 0x04004A5B RID: 19035
		private Image mBg;

		// Token: 0x04004A5C RID: 19036
		private Image mCosticon;

		// Token: 0x04004A5D RID: 19037
		private Text mDesc;

		// Token: 0x04004A5E RID: 19038
		private GameObject mCheckmask;

		// Token: 0x04004A5F RID: 19039
		private Toggle mChecktoggle;

		// Token: 0x04004A60 RID: 19040
		private GameObject mCostRoot;

		// Token: 0x02000E8B RID: 3723
		public enum eMarkState
		{
			// Token: 0x04004A62 RID: 19042
			Marked,
			// Token: 0x04004A63 RID: 19043
			UnMarked
		}

		// Token: 0x02000E8C RID: 3724
		private enum eState
		{
			// Token: 0x04004A65 RID: 19045
			None,
			// Token: 0x04004A66 RID: 19046
			Ready,
			// Token: 0x04004A67 RID: 19047
			Wait,
			// Token: 0x04004A68 RID: 19048
			Used,
			// Token: 0x04004A69 RID: 19049
			CoolDown
		}

		// Token: 0x02000E8D RID: 3725
		private enum eCostType
		{
			// Token: 0x04004A6B RID: 19051
			Gold,
			// Token: 0x04004A6C RID: 19052
			Point
		}
	}
}
