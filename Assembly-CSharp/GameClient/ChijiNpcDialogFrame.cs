using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001112 RID: 4370
	public class ChijiNpcDialogFrame : ClientFrame
	{
		// Token: 0x0600A5B2 RID: 42418 RVA: 0x00224CA3 File Offset: 0x002230A3
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiNpcDialogFrame";
		}

		// Token: 0x0600A5B3 RID: 42419 RVA: 0x00224CAC File Offset: 0x002230AC
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				ChijiNpcData chijiNpcData = this.userData as ChijiNpcData;
				if (chijiNpcData != null)
				{
					this.NpcData.guid = chijiNpcData.guid;
					this.NpcData.npcTableId = chijiNpcData.npcTableId;
				}
			}
			this._BindUIEvent();
			this._InitInterface();
		}

		// Token: 0x0600A5B4 RID: 42420 RVA: 0x00224D04 File Offset: 0x00223104
		protected override void _OnCloseFrame()
		{
			this._UnBindUIEvent();
			this._ClearData();
		}

		// Token: 0x0600A5B5 RID: 42421 RVA: 0x00224D12 File Offset: 0x00223112
		private void _ClearData()
		{
			if (this.NpcData != null)
			{
				this.NpcData.guid = 0UL;
				this.NpcData.npcTableId = 0;
			}
			this.needHp = 0;
		}

		// Token: 0x0600A5B6 RID: 42422 RVA: 0x00224D40 File Offset: 0x00223140
		private void _InitInterface()
		{
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this.NpcData.npcTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("NpcTable tableData is null in Chiji, NpcID = {0}", new object[]
				{
					this.NpcData.npcTableId
				});
				return;
			}
			if (this.mHeadIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mHeadIcon, tableItem.NpcBody, true);
			}
			if (this.mNpcName != null)
			{
				this.mNpcName.text = tableItem.NpcName;
			}
			if (this.mBtCancelText != null)
			{
				if (tableItem.SubType == NpcTable.eSubType.ShopNpc)
				{
					this.mBtCancelText.text = "打扰了";
				}
				else
				{
					this.mBtCancelText.text = "我点错了";
				}
			}
			if (this.mBtOKText != null)
			{
				if (tableItem.SubType == NpcTable.eSubType.ShopNpc)
				{
					this.mBtOKText.text = "上交装备";
				}
				else
				{
					this.mBtOKText.text = "我来收拾你";
				}
			}
			List<int> list = new List<int>();
			int num = 0;
			string text = string.Empty;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChiJiNpcRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ChiJiNpcRewardTable chiJiNpcRewardTable = keyValuePair.Value as ChiJiNpcRewardTable;
					if (chiJiNpcRewardTable != null)
					{
						if (chiJiNpcRewardTable.npcId == this.NpcData.npcTableId)
						{
							if (tableItem.SubType == NpcTable.eSubType.MonsterNpc)
							{
								num = chiJiNpcRewardTable.param;
								this.needHp = chiJiNpcRewardTable.param2;
								text = chiJiNpcRewardTable.NpcDialogue;
							}
							if (chiJiNpcRewardTable.rewards != null)
							{
								for (int i = 0; i < chiJiNpcRewardTable.rewards.Length; i++)
								{
									list.Add(chiJiNpcRewardTable.rewards[i]);
								}
							}
						}
					}
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(list[j], 100, 0);
				ComItem comItem = base.CreateComItem(this.mContent);
				LayoutElement layoutElement = comItem.gameObject.AddComponent<LayoutElement>();
				if (layoutElement != null)
				{
					layoutElement.minWidth = 110f;
					layoutElement.minHeight = 110f;
				}
				if (itemData != null && comItem != null)
				{
					comItem.Setup(itemData, new ComItem.OnItemClicked(this._OnItemClicked));
				}
			}
			if (this.mTalkContent != null)
			{
				if (tableItem.SubType == NpcTable.eSubType.ShopNpc)
				{
					this.mTalkContent.text = TR.Value("Chiji_npc_shop");
				}
				else
				{
					int num2 = 0;
					List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
					for (int k = 0; k < itemsByPackageType.Count; k++)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[k]);
						num2 = (int)(num2 + item.Quality);
					}
					if (num2 < num)
					{
						this.mTalkContent.text = text;
						this.mFirstLayer.CustomActive(false);
						this.mSecondLayer.CustomActive(true);
					}
					else
					{
						this.mTalkContent.text = TR.Value("Chiji_npc_monster", this.needHp / 10);
						this.mFirstLayer.CustomActive(true);
						this.mSecondLayer.CustomActive(false);
					}
				}
			}
		}

		// Token: 0x0600A5B7 RID: 42423 RVA: 0x002250C7 File Offset: 0x002234C7
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ExchangeSuccess, new ClientEventSystem.UIEventHandler(this._OnExchangeSuccess));
		}

		// Token: 0x0600A5B8 RID: 42424 RVA: 0x002250E4 File Offset: 0x002234E4
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ExchangeSuccess, new ClientEventSystem.UIEventHandler(this._OnExchangeSuccess));
		}

		// Token: 0x0600A5B9 RID: 42425 RVA: 0x00225101 File Offset: 0x00223501
		private void _OnExchangeSuccess(UIEvent uiEvent)
		{
			this.mTalkContent.text = TR.Value("Chiji_npc_monster_fail");
			this.mFirstLayer.CustomActive(false);
			this.mSecondLayer.CustomActive(true);
		}

		// Token: 0x0600A5BA RID: 42426 RVA: 0x00225130 File Offset: 0x00223530
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (item == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600A5BB RID: 42427 RVA: 0x0022514C File Offset: 0x0022354C
		protected override void _bindExUI()
		{
			this.mHeadIcon = this.mBind.GetCom<Image>("HeadIcon");
			this.mNpcName = this.mBind.GetCom<Text>("NpcName");
			this.mTalkContent = this.mBind.GetCom<Text>("TalkContent");
			this.mFirstLayer = this.mBind.GetGameObject("FirstLayer");
			this.mSecondLayer = this.mBind.GetGameObject("SecondLayer");
			this.mContent = this.mBind.GetGameObject("Content");
			this.mBtCancelText = this.mBind.GetCom<Text>("btCancelText");
			this.mBtOKText = this.mBind.GetCom<Text>("btOKText");
			this.mBtCancel = this.mBind.GetCom<Button>("btCancel");
			if (null != this.mBtCancel)
			{
				this.mBtCancel.onClick.AddListener(new UnityAction(this._onBtCancelButtonClick));
			}
			this.mBtOK = this.mBind.GetCom<Button>("btOK");
			if (null != this.mBtOK)
			{
				this.mBtOK.onClick.AddListener(new UnityAction(this._onBtOKButtonClick));
			}
			this.mBtReturn = this.mBind.GetCom<Button>("btReturn");
			if (null != this.mBtReturn)
			{
				this.mBtReturn.onClick.AddListener(new UnityAction(this._onBtReturnButtonClick));
			}
			this.mBtBack = this.mBind.GetCom<Button>("btBack");
			if (null != this.mBtBack)
			{
				this.mBtBack.onClick.AddListener(new UnityAction(this._onBtBackButtonClick));
			}
		}

		// Token: 0x0600A5BC RID: 42428 RVA: 0x00225318 File Offset: 0x00223718
		protected override void _unbindExUI()
		{
			this.mHeadIcon = null;
			this.mNpcName = null;
			this.mTalkContent = null;
			this.mFirstLayer = null;
			this.mSecondLayer = null;
			this.mContent = null;
			this.mBtCancelText = null;
			this.mBtOKText = null;
			if (null != this.mBtCancel)
			{
				this.mBtCancel.onClick.RemoveListener(new UnityAction(this._onBtCancelButtonClick));
			}
			this.mBtCancel = null;
			if (null != this.mBtOK)
			{
				this.mBtOK.onClick.RemoveListener(new UnityAction(this._onBtOKButtonClick));
			}
			this.mBtOK = null;
			if (null != this.mBtReturn)
			{
				this.mBtReturn.onClick.RemoveListener(new UnityAction(this._onBtReturnButtonClick));
			}
			this.mBtReturn = null;
			if (null != this.mBtBack)
			{
				this.mBtBack.onClick.RemoveListener(new UnityAction(this._onBtBackButtonClick));
			}
			this.mBtBack = null;
		}

		// Token: 0x0600A5BD RID: 42429 RVA: 0x0022542D File Offset: 0x0022382D
		private void _onBtCancelButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiNpcDialogFrame>(this, false);
		}

		// Token: 0x0600A5BE RID: 42430 RVA: 0x0022543C File Offset: 0x0022383C
		private void _onBtOKButtonClick()
		{
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this.NpcData.npcTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SubType == NpcTable.eSubType.ShopNpc)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiHandInEquipmentFrame>(FrameLayer.Middle, this.NpcData, string.Empty);
			}
			else
			{
				if ((float)this.needHp < DataManager<PlayerBaseData>.GetInstance().Chiji_HP_Percent)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你当前血量不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				DataManager<ChijiDataManager>.GetInstance().SendNpcTradeReq((uint)this.NpcData.npcTableId, this.NpcData.guid, null);
			}
		}

		// Token: 0x0600A5BF RID: 42431 RVA: 0x002254DC File Offset: 0x002238DC
		private void _onBtReturnButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiNpcDialogFrame>(this, false);
		}

		// Token: 0x0600A5C0 RID: 42432 RVA: 0x002254EB File Offset: 0x002238EB
		private void _onBtBackButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiNpcDialogFrame>(this, false);
		}

		// Token: 0x04005C9F RID: 23711
		private ChijiNpcData NpcData = new ChijiNpcData();

		// Token: 0x04005CA0 RID: 23712
		private int needHp;

		// Token: 0x04005CA1 RID: 23713
		private Image mHeadIcon;

		// Token: 0x04005CA2 RID: 23714
		private Text mNpcName;

		// Token: 0x04005CA3 RID: 23715
		private Text mTalkContent;

		// Token: 0x04005CA4 RID: 23716
		private GameObject mFirstLayer;

		// Token: 0x04005CA5 RID: 23717
		private GameObject mSecondLayer;

		// Token: 0x04005CA6 RID: 23718
		private GameObject mContent;

		// Token: 0x04005CA7 RID: 23719
		private Text mBtCancelText;

		// Token: 0x04005CA8 RID: 23720
		private Text mBtOKText;

		// Token: 0x04005CA9 RID: 23721
		private Button mBtCancel;

		// Token: 0x04005CAA RID: 23722
		private Button mBtOK;

		// Token: 0x04005CAB RID: 23723
		private Button mBtReturn;

		// Token: 0x04005CAC RID: 23724
		private Button mBtBack;
	}
}
