using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001520 RID: 5408
	public class ChapterBattlePotionSetFrame : ClientFrame
	{
		// Token: 0x0600D23D RID: 53821 RVA: 0x0033F9B2 File Offset: 0x0033DDB2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Normal/ChapterBattlePotionSetFrame";
		}

		// Token: 0x0600D23E RID: 53822 RVA: 0x0033F9BC File Offset: 0x0033DDBC
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonPotionSetChanged, new ClientEventSystem.UIEventHandler(this._onUpdateBattlePostionSet));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._onUpdateLevelLimitStatus));
		}

		// Token: 0x0600D23F RID: 53823 RVA: 0x0033FABC File Offset: 0x0033DEBC
		private void _unbindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._onUpdateAllBattlePostion));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonPotionSetChanged, new ClientEventSystem.UIEventHandler(this._onUpdateBattlePostionSet));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._onUpdateLevelLimitStatus));
		}

		// Token: 0x0600D240 RID: 53824 RVA: 0x0033FBB9 File Offset: 0x0033DFB9
		private void _onUpdateAllBattlePostion(UIEvent ui)
		{
			this.mIsAllBattlePostionDirty = true;
		}

		// Token: 0x0600D241 RID: 53825 RVA: 0x0033FBC4 File Offset: 0x0033DFC4
		private void _bindDragDropEvent()
		{
			for (int i = 0; i < this.mDropItems.Length; i++)
			{
				this.mDropItems[i].OnDropEvent.AddListener(new UnityAction<ComDrop, ComDrag>(this._onDropComDrop));
				this.mDropItems[i].OnEnterEvent.AddListener(new UnityAction<ComDrop, ComDrag>(this._onDropComEnter));
				this.mDropItems[i].OnExitEvent.AddListener(new UnityAction<ComDrop, ComDrag>(this._onDropComExit));
				this.mDragItems[i].OnEndDragEvent.AddListener(new UnityAction<ComDrag>(this._onDragMainComEnd));
				this.mDragItems[i].OnBeginDragEvent.AddListener(new UnityAction<ComDrag>(this._onDragMainComBegin));
			}
			this.mCancelDrop.OnDropEvent.AddListener(new UnityAction<ComDrop, ComDrag>(this._onDropComCancel));
		}

		// Token: 0x0600D242 RID: 53826 RVA: 0x0033FC9C File Offset: 0x0033E09C
		private void _unbindDragDropEvent()
		{
			for (int i = 0; i < this.mDropItems.Length; i++)
			{
				this.mDropItems[i].OnDropEvent.RemoveListener(new UnityAction<ComDrop, ComDrag>(this._onDropComDrop));
				this.mDropItems[i].OnEnterEvent.RemoveListener(new UnityAction<ComDrop, ComDrag>(this._onDropComEnter));
				this.mDropItems[i].OnExitEvent.RemoveListener(new UnityAction<ComDrop, ComDrag>(this._onDropComExit));
				this.mDragItems[i].OnEndDragEvent.RemoveListener(new UnityAction<ComDrag>(this._onDragMainComEnd));
				this.mDragItems[i].OnBeginDragEvent.RemoveListener(new UnityAction<ComDrag>(this._onDragMainComBegin));
			}
			this.mCancelDrop.OnDropEvent.RemoveListener(new UnityAction<ComDrop, ComDrag>(this._onDropComCancel));
		}

		// Token: 0x0600D243 RID: 53827 RVA: 0x0033FD74 File Offset: 0x0033E174
		private void _onDropComEnter(ComDrop drop, ComDrag drag)
		{
			ChapterBattlePotionSetFrameData data = this._findDataByGameObject(drag.gameObject);
			int idx = this._getDropComIdx(drop);
			this._onDropComEnterCB(idx, data);
		}

		// Token: 0x0600D244 RID: 53828 RVA: 0x0033FD9E File Offset: 0x0033E19E
		private string GetSlotNotityText(PlayerBaseData.PotionSlotType potionSlotType)
		{
			if (potionSlotType == PlayerBaseData.PotionSlotType.SlotMain || potionSlotType == PlayerBaseData.PotionSlotType.SlotExtend1)
			{
				return TR.Value("hp_slot_tips");
			}
			if (potionSlotType == PlayerBaseData.PotionSlotType.SlotExtend2)
			{
				return TR.Value("mp_slot_tips");
			}
			return string.Empty;
		}

		// Token: 0x0600D245 RID: 53829 RVA: 0x0033FDD0 File Offset: 0x0033E1D0
		private bool SlotCanSetPotion(PlayerBaseData.PotionSlotType potionSlotType, uint id)
		{
			if (id == 0U)
			{
				return true;
			}
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>((int)id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			ItemTable.eSubType subType = tableItem.SubType;
			return subType == ItemTable.eSubType.HpMp || subType == ItemTable.eSubType.AttributeDrug || (subType == ItemTable.eSubType.Hp && (potionSlotType == PlayerBaseData.PotionSlotType.SlotMain || potionSlotType == PlayerBaseData.PotionSlotType.SlotExtend1)) || (subType == ItemTable.eSubType.Mp && potionSlotType == PlayerBaseData.PotionSlotType.SlotExtend2);
		}

		// Token: 0x0600D246 RID: 53830 RVA: 0x0033FE48 File Offset: 0x0033E248
		private void _onDropComDrop(ComDrop drop, ComDrag drag)
		{
			if (null != drag.DragObject)
			{
				drag.DragObject.SetActive(false);
			}
			int num = this._getDropComIdx(drop);
			int num2 = this._getDropComIdx(drag);
			ChapterBattlePotionSetFrameData chapterBattlePotionSetFrameData = this._findDataByGameObject(drag.gameObject);
			if (chapterBattlePotionSetFrameData == null)
			{
				this._onDropComDropSwapCB(num, num2);
			}
			else
			{
				uint id = this._convertItemGUID2TalbeID(chapterBattlePotionSetFrameData.id);
				num2 = ChapterBattlePotionSetUtiilty._getItemIdx(id);
				if (num2 >= 0)
				{
					this._onDropComDropSwapCB(num, num2);
				}
				else
				{
					this._onDropComDropCB(num, chapterBattlePotionSetFrameData);
				}
			}
		}

		// Token: 0x0600D247 RID: 53831 RVA: 0x0033FED4 File Offset: 0x0033E2D4
		private void _onDropComExit(ComDrop drop, ComDrag drag)
		{
			ChapterBattlePotionSetFrameData data = this._findDataByGameObject(drag.gameObject);
			int idx = this._getDropComIdx(drop);
			this._onDropComExitCB(idx, data);
		}

		// Token: 0x0600D248 RID: 53832 RVA: 0x0033FEFE File Offset: 0x0033E2FE
		private void _onDragMainComBegin(ComDrag drag)
		{
			if (null == drag)
			{
				return;
			}
			if (null == drag.DragObject)
			{
				return;
			}
			drag.DragObject.SetActive(true);
		}

		// Token: 0x0600D249 RID: 53833 RVA: 0x0033FF2B File Offset: 0x0033E32B
		private void _onDragMainComEnd(ComDrag drag)
		{
			if (null == drag)
			{
				return;
			}
			if (null == drag.DragObject)
			{
				return;
			}
			drag.DragObject.SetActive(false);
		}

		// Token: 0x0600D24A RID: 53834 RVA: 0x0033FF58 File Offset: 0x0033E358
		private void _onDropComCancel(ComDrop drop, ComDrag drag)
		{
			int num = this._getDropComIdx(drag);
			if (num < 0)
			{
				return;
			}
			this._onDropComCancelCB(num);
		}

		// Token: 0x0600D24B RID: 53835 RVA: 0x0033FF7C File Offset: 0x0033E37C
		private int _getDropComIdx(ComDrop drop)
		{
			for (int i = 0; i < this.mDropItems.Length; i++)
			{
				if (this.mDropItems[i] == drop)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600D24C RID: 53836 RVA: 0x0033FFB8 File Offset: 0x0033E3B8
		private int _getDropComIdx(ComDrag drag)
		{
			for (int i = 0; i < this.mDropItems.Length; i++)
			{
				if (this.mDragItems[i] == drag)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600D24D RID: 53837 RVA: 0x0033FFF4 File Offset: 0x0033E3F4
		private ChapterBattlePotionSetFrameData _findDataByGameObject(GameObject root)
		{
			for (int i = 0; i < this.mAllBattlePostions.Count; i++)
			{
				if (null != this.mAllBattlePostions[i].bind && this.mAllBattlePostions[i].bind.gameObject == root)
				{
					return this.mAllBattlePostions[i];
				}
			}
			return null;
		}

		// Token: 0x0600D24E RID: 53838 RVA: 0x00340068 File Offset: 0x0033E468
		private void _bindNetMessage()
		{
			NetProcess.AddMsgHandler(500965U, new Action<MsgDATA>(this._onSceneSetDungeonPotionRes));
		}

		// Token: 0x0600D24F RID: 53839 RVA: 0x00340080 File Offset: 0x0033E480
		private void _unBindNetMessage()
		{
			NetProcess.RemoveMsgHandler(500965U, new Action<MsgDATA>(this._onSceneSetDungeonPotionRes));
		}

		// Token: 0x0600D250 RID: 53840 RVA: 0x00340098 File Offset: 0x0033E498
		private void _onSceneSetDungeonPotionRes(MsgDATA data)
		{
			SceneSetDungeonPotionRes stream = new SceneSetDungeonPotionRes();
			stream.decode(data.bytes);
		}

		// Token: 0x0600D251 RID: 53841 RVA: 0x003400B7 File Offset: 0x0033E4B7
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600D252 RID: 53842 RVA: 0x003400BC File Offset: 0x0033E4BC
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mDrugRoot = this.mBind.GetGameObject("drugRoot");
			this.mCancelDrop = this.mBind.GetCom<ComDrop>("cancelDrop");
			this.mToggleGroup = this.mBind.GetCom<ToggleGroup>("toggleGroup");
			this.mScroll = this.mBind.GetCom<ScrollRect>("scroll");
		}

		// Token: 0x0600D253 RID: 53843 RVA: 0x00340154 File Offset: 0x0033E554
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mDrugRoot = null;
			this.mCancelDrop = null;
			this.mToggleGroup = null;
			this.mScroll = null;
		}

		// Token: 0x0600D254 RID: 53844 RVA: 0x003401A0 File Offset: 0x0033E5A0
		protected void _bindDragDropUI(ComCommonBind bind)
		{
			this.mDropItems[0] = bind.GetCom<ComDrop>("dropItem0");
			this.mDropItems[1] = bind.GetCom<ComDrop>("dropItem1");
			this.mDropItems[2] = bind.GetCom<ComDrop>("dropItem2");
			this.mConfigItems[0] = bind.GetCom<Image>("configItem0");
			this.mConfigItems[1] = bind.GetCom<Image>("configItem1");
			this.mConfigItems[2] = bind.GetCom<Image>("configItem2");
			this.mConfigItemSelects[0] = bind.GetCom<CanvasGroup>("configItemSelect0");
			this.mConfigItemSelects[1] = bind.GetCom<CanvasGroup>("configItemSelect1");
			this.mConfigItemSelects[2] = bind.GetCom<CanvasGroup>("configItemSelect2");
			this.mDragFgItems[0] = bind.GetCom<Image>("dragFgItem0");
			this.mDragFgItems[1] = bind.GetCom<Image>("dragFgItem1");
			this.mDragFgItems[2] = bind.GetCom<Image>("dragFgItem2");
			this.mDragItems[0] = bind.GetCom<ComDrag>("dragItem0");
			this.mDragItems[1] = bind.GetCom<ComDrag>("dragItem1");
			this.mDragItems[2] = bind.GetCom<ComDrag>("dragItem2");
		}

		// Token: 0x0600D255 RID: 53845 RVA: 0x003402CC File Offset: 0x0033E6CC
		protected void _unbindDragDropUI()
		{
			this.mDropItems[0] = null;
			this.mDropItems[1] = null;
			this.mDropItems[2] = null;
			this.mConfigItems[0] = null;
			this.mConfigItems[1] = null;
			this.mConfigItems[2] = null;
			this.mConfigItemSelects[0] = null;
			this.mConfigItemSelects[1] = null;
			this.mConfigItemSelects[2] = null;
			this.mDragFgItems[0] = null;
			this.mDragFgItems[1] = null;
			this.mDragFgItems[2] = null;
			this.mDragItems[0] = null;
			this.mDragItems[1] = null;
			this.mDragItems[2] = null;
		}

		// Token: 0x0600D256 RID: 53846 RVA: 0x00340360 File Offset: 0x0033E760
		private void _onCloseButtonClick()
		{
			this._close();
		}

		// Token: 0x0600D257 RID: 53847 RVA: 0x00340368 File Offset: 0x0033E768
		private void _close()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<ChapterBattlePotionSetFrame>(this, false);
		}

		// Token: 0x0600D258 RID: 53848 RVA: 0x00340376 File Offset: 0x0033E776
		private void _onUpdateBattlePostionSet(UIEvent ui)
		{
			this._updateBattlePostionSet();
		}

		// Token: 0x0600D259 RID: 53849 RVA: 0x00340380 File Offset: 0x0033E780
		private void _onUpdateLevelLimitStatus(UIEvent ui)
		{
			for (int i = 0; i < this.mAllBattlePostions.Count; i++)
			{
				this._updateLevelLimitStatus(this.mAllBattlePostions[i]);
			}
		}

		// Token: 0x0600D25A RID: 53850 RVA: 0x003403BC File Offset: 0x0033E7BC
		private void _onDropComEnterCB(int idx, ChapterBattlePotionSetFrameData data)
		{
			for (int i = 0; i < this.mConfigItemSelects.Length; i++)
			{
				this.mConfigItemSelects[i].alpha = ((idx != i) ? 0f : 1f);
			}
		}

		// Token: 0x0600D25B RID: 53851 RVA: 0x00340408 File Offset: 0x0033E808
		private void _onDropComDropCB(int idx, ChapterBattlePotionSetFrameData data)
		{
			uint id = this._convertItemGUID2TalbeID(data.id);
			if (!this.SlotCanSetPotion((PlayerBaseData.PotionSlotType)idx, id))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(this.GetSlotNotityText((PlayerBaseData.PotionSlotType)idx), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			ChapterBattlePotionSetUtiilty.Save(idx, id);
			this._updateBattlePostionSetByIdx(idx, id);
		}

		// Token: 0x0600D25C RID: 53852 RVA: 0x00340450 File Offset: 0x0033E850
		private void _onDropComDropSwapCB(int fstIdx, int sndIdx)
		{
			if (fstIdx < DataManager<PlayerBaseData>.GetInstance().potionSets.Count && sndIdx < DataManager<PlayerBaseData>.GetInstance().potionSets.Count)
			{
				uint id = DataManager<PlayerBaseData>.GetInstance().potionSets[fstIdx];
				uint id2 = DataManager<PlayerBaseData>.GetInstance().potionSets[sndIdx];
				if (!this.SlotCanSetPotion((PlayerBaseData.PotionSlotType)fstIdx, id2))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(this.GetSlotNotityText((PlayerBaseData.PotionSlotType)fstIdx), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (!this.SlotCanSetPotion((PlayerBaseData.PotionSlotType)sndIdx, id))
				{
					ChapterBattlePotionSetUtiilty.Save(fstIdx, id2);
					ChapterBattlePotionSetUtiilty.Cancel(sndIdx);
					return;
				}
			}
			if (ChapterBattlePotionSetUtiilty.Swap(fstIdx, sndIdx))
			{
				uint id3 = DataManager<PlayerBaseData>.GetInstance().potionSets[fstIdx];
				uint id4 = DataManager<PlayerBaseData>.GetInstance().potionSets[sndIdx];
				this._updateBattlePostionSetByIdx(fstIdx, id3);
				this._updateBattlePostionSetByIdx(sndIdx, id4);
			}
		}

		// Token: 0x0600D25D RID: 53853 RVA: 0x0034051E File Offset: 0x0033E91E
		private void _onDropComExitCB(int idx, ChapterBattlePotionSetFrameData data)
		{
			if (idx < 0 || idx >= this.mConfigItemSelects.Length)
			{
				return;
			}
			this.mConfigItemSelects[idx].alpha = 0f;
		}

		// Token: 0x0600D25E RID: 53854 RVA: 0x00340548 File Offset: 0x0033E948
		private void _onDropComCancelCB(int cancelIdx)
		{
			ChapterBattlePotionSetUtiilty.Cancel(cancelIdx);
		}

		// Token: 0x0600D25F RID: 53855 RVA: 0x00340550 File Offset: 0x0033E950
		private uint _convertItemGUID2TalbeID(ulong id)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
			if (item == null)
			{
				return 0U;
			}
			return (uint)item.TableID;
		}

		// Token: 0x0600D260 RID: 53856 RVA: 0x00340578 File Offset: 0x0033E978
		protected override void _OnOpenFrame()
		{
			string prefabPath = this.mBind.GetPrefabPath("potionSet");
			this.mBind.ClearCacheBinds(prefabPath);
			ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
			Utility.AttachTo(comCommonBind.gameObject, this.mBind.GetGameObject("setParent"), false);
			this._bindDragDropUI(comCommonBind);
			this._bindNetMessage();
			this._bindEvents();
			this._bindDragDropEvent();
			this._initAllBattlePostionData();
			this._updateBattlePostionSet();
			this._updateAllBattlePostions();
		}

		// Token: 0x0600D261 RID: 53857 RVA: 0x003405F6 File Offset: 0x0033E9F6
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ClosePotionSetFrame, null, null, null, null);
			this._clearAllBattlePostionData();
			this._unBindNetMessage();
			this._unbindDragDropEvent();
			this._unbindEvents();
			this._unbindDragDropUI();
		}

		// Token: 0x0600D262 RID: 53858 RVA: 0x00340629 File Offset: 0x0033EA29
		protected override void _OnUpdate(float delta)
		{
			if (this.mIsAllBattlePostionDirty)
			{
				this._updateAllBattlePostions();
				this.mIsAllBattlePostionDirty = false;
			}
		}

		// Token: 0x0600D263 RID: 53859 RVA: 0x00340644 File Offset: 0x0033EA44
		private void _updateBattlePostionSet()
		{
			List<uint> potionSets = DataManager<PlayerBaseData>.GetInstance().potionSets;
			for (int i = 0; i < 3; i++)
			{
				uint id = 0U;
				if (i < potionSets.Count)
				{
					id = potionSets[i];
				}
				this._updateBattlePostionSetByIdx(i, id);
			}
		}

		// Token: 0x0600D264 RID: 53860 RVA: 0x0034068C File Offset: 0x0033EA8C
		private void _updateBattlePostionSetByIdx(int i, uint id)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>((int)id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				this.mConfigItems[i].color = Color.clear;
				this.mDragFgItems[i].color = Color.clear;
			}
			else
			{
				this.mConfigItems[i].color = Color.white;
				ETCImageLoader.LoadSprite(ref this.mConfigItems[i], tableItem.Icon, true);
				this.mDragFgItems[i].color = this.mConfigItems[i].color;
				this.mDragFgItems[i].sprite = this.mConfigItems[i].sprite;
				this.mDragFgItems[i].material = this.mConfigItems[i].material;
			}
			this._updateBattlePostionStatus();
		}

		// Token: 0x0600D265 RID: 53861 RVA: 0x00340760 File Offset: 0x0033EB60
		private void _updateBattlePostionStatus()
		{
			for (int i = 0; i < this.mAllBattlePostions.Count; i++)
			{
				ChapterBattlePotionSetFrameData chapterBattlePotionSetFrameData = this.mAllBattlePostions[i];
				ComCommonBind bind = chapterBattlePotionSetFrameData.bind;
				if (!(null == bind))
				{
					CanvasGroup com = bind.GetCom<CanvasGroup>("select");
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(chapterBattlePotionSetFrameData.id);
					if (item == null)
					{
						com.alpha = 0f;
					}
					else
					{
						com.alpha = ((!this._isAlreadyInPotionSet(item.TableID)) ? 0f : 1f);
					}
				}
			}
		}

		// Token: 0x0600D266 RID: 53862 RVA: 0x0034080C File Offset: 0x0033EC0C
		private ChapterBattlePotionSetFrameData _findDataById(ulong id)
		{
			for (int i = 0; i < this.mAllBattlePostions.Count; i++)
			{
				if (this.mAllBattlePostions[i].id == id)
				{
					return this.mAllBattlePostions[i];
				}
			}
			return null;
		}

		// Token: 0x0600D267 RID: 53863 RVA: 0x0034085C File Offset: 0x0033EC5C
		private void _addDataById(ulong id)
		{
			if (this._findDataById(id) == null)
			{
				ChapterBattlePotionSetFrameData chapterBattlePotionSetFrameData = this._findDataById(ulong.MaxValue);
				if (chapterBattlePotionSetFrameData != null)
				{
					chapterBattlePotionSetFrameData.id = id;
				}
			}
		}

		// Token: 0x0600D268 RID: 53864 RVA: 0x00340890 File Offset: 0x0033EC90
		private void _removeDataById(ulong id)
		{
			ChapterBattlePotionSetFrameData chapterBattlePotionSetFrameData = this._findDataById(id);
			if (chapterBattlePotionSetFrameData == null)
			{
				return;
			}
			chapterBattlePotionSetFrameData.id = ulong.MaxValue;
		}

		// Token: 0x0600D269 RID: 53865 RVA: 0x003408B4 File Offset: 0x0033ECB4
		private void _clearAllBattlePostionData()
		{
			for (int i = 0; i < this.mAllBattlePostions.Count; i++)
			{
				ComCommonBind bind = this.mAllBattlePostions[i].bind;
				ComDrag com = bind.GetCom<ComDrag>("dragCom");
				com.OnBeginDragEvent.RemoveAllListeners();
				com.OnEndDragEvent.RemoveAllListeners();
			}
			this.mAllBattlePostions.Clear();
		}

		// Token: 0x0600D26A RID: 53866 RVA: 0x0034091C File Offset: 0x0033ED1C
		private void _initAllBattlePostionData()
		{
			string prefabPath = this.mBind.GetPrefabPath("unit");
			this.mBind.ClearCacheBinds(prefabPath);
			for (int i = 0; i < 21; i++)
			{
				this._loadOneUnit();
			}
			this.mScroll.verticalNormalizedPosition = 1f;
			LayoutRebuilder.ForceRebuildLayoutImmediate(this.mScroll.content);
		}

		// Token: 0x0600D26B RID: 53867 RVA: 0x00340980 File Offset: 0x0033ED80
		private void _loadOneUnit()
		{
			string prefabPath = this.mBind.GetPrefabPath("unit");
			ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
			ComDrag com = comCommonBind.GetCom<ComDrag>("dragCom");
			Toggle com2 = comCommonBind.GetCom<Toggle>("toggle");
			ChapterBattlePotionSetFrameData item = new ChapterBattlePotionSetFrameData(comCommonBind, ulong.MaxValue);
			com.OnBeginDragEvent.RemoveAllListeners();
			com.OnBeginDragEvent.AddListener(new UnityAction<ComDrag>(this._onDragComBeginDrag));
			com.OnEndDragEvent.RemoveAllListeners();
			com.OnEndDragEvent.AddListener(new UnityAction<ComDrag>(this._onDragComEndDrag));
			com2.group = this.mToggleGroup;
			Utility.AttachTo(comCommonBind.gameObject, this.mDrugRoot, false);
			this.mAllBattlePostions.Add(item);
		}

		// Token: 0x0600D26C RID: 53868 RVA: 0x00340A3C File Offset: 0x0033EE3C
		private void _onDragComBeginDrag(ComDrag drag)
		{
			ChapterBattlePotionSetFrameData chapterBattlePotionSetFrameData = this._findDataByGameObject(drag.gameObject);
			if (chapterBattlePotionSetFrameData == null)
			{
				return;
			}
			if (null == drag.DragObject)
			{
				return;
			}
			drag.DragObject.SetActive(true);
			if (null != chapterBattlePotionSetFrameData.bind)
			{
				chapterBattlePotionSetFrameData.bind.GetCom<Toggle>("toggle").isOn = true;
			}
		}

		// Token: 0x0600D26D RID: 53869 RVA: 0x00340AA4 File Offset: 0x0033EEA4
		private void _onDragComEndDrag(ComDrag drag)
		{
			if (this._findDataByGameObject(drag.gameObject) == null)
			{
				return;
			}
			if (null == drag.DragObject)
			{
				return;
			}
			drag.DragObject.SetActive(false);
		}

		// Token: 0x0600D26E RID: 53870 RVA: 0x00340AE4 File Offset: 0x0033EEE4
		private void _updateAllBattlePostions()
		{
			List<ulong> list = this._getAllBattleDrugs();
			List<ulong> list2 = new List<ulong>();
			List<ulong> list3 = new List<ulong>();
			List<ulong> list4 = new List<ulong>();
			for (int i = 0; i < list.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(list[i]);
				if (item != null)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.NeedLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level)
						{
							if (tableItem.ID == 200001001)
							{
								list2.Add(list[i]);
							}
							else
							{
								list3.Add(list[i]);
							}
						}
						else
						{
							list4.Add(list[i]);
						}
					}
				}
			}
			this.Sortmethod(list3);
			list.Clear();
			for (int j = 0; j < list2.Count; j++)
			{
				list.Add(list2[j]);
			}
			for (int k = 0; k < list3.Count; k++)
			{
				list.Add(list3[k]);
			}
			for (int l = 0; l < list4.Count; l++)
			{
				list.Add(list4[l]);
			}
			for (int m = 0; m < list.Count; m++)
			{
				if (this._findDataById(list[m]) == null)
				{
					this._addDataById(list[m]);
				}
			}
			for (int n = 0; n < this.mAllBattlePostions.Count; n++)
			{
				bool flag = false;
				for (int num = 0; num < list.Count; num++)
				{
					if (list[num] == this.mAllBattlePostions[n].id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this._removeDataById(this.mAllBattlePostions[n].id);
				}
			}
			this._sortAllBattlePosition();
		}

		// Token: 0x0600D26F RID: 53871 RVA: 0x00340D14 File Offset: 0x0033F114
		private List<ulong> _getAllBattleDrugs()
		{
			ItemTable.eSubType[] array = new ItemTable.eSubType[]
			{
				ItemTable.eSubType.Hp,
				ItemTable.eSubType.Mp,
				ItemTable.eSubType.AttributeDrug,
				ItemTable.eSubType.HpMp
			};
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < array.Length; i++)
			{
				list.AddRange(DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Consumable, array[i]));
			}
			return list;
		}

		// Token: 0x0600D270 RID: 53872 RVA: 0x00340D64 File Offset: 0x0033F164
		private void _sortAllBattlePosition()
		{
			for (int i = 0; i < this.mAllBattlePostions.Count; i++)
			{
				this._initOnePotionConfig(this.mAllBattlePostions[i]);
			}
		}

		// Token: 0x0600D271 RID: 53873 RVA: 0x00340DA0 File Offset: 0x0033F1A0
		private void Sortmethod(List<ulong> setData)
		{
			for (int i = 0; i < setData.Count; i++)
			{
				for (int j = 0; j < setData.Count - 1 - i; j++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(setData[j]);
					if (item != null)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (item != null)
						{
							ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(setData[j + 1]);
							if (item2 != null)
							{
								ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item2.TableID, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									if (tableItem.ID < tableItem2.ID)
									{
										ulong value = setData[j];
										setData[j] = setData[j + 1];
										setData[j + 1] = value;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600D272 RID: 53874 RVA: 0x00340EA4 File Offset: 0x0033F2A4
		private void _initOnePotionConfig(ChapterBattlePotionSetFrameData data)
		{
			if (data == null)
			{
				Logger.LogErrorFormat("[PotionData] frame data is nil", new object[0]);
				return;
			}
			ComCommonBind bind = data.bind;
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(data.id);
			Image com = bind.GetCom<Image>("board");
			Image com2 = bind.GetCom<Image>("icon");
			Text com3 = bind.GetCom<Text>("cnt");
			GameObject gameObject = bind.GetGameObject("root");
			ComDrag com4 = bind.GetCom<ComDrag>("dragCom");
			Image com5 = bind.GetCom<Image>("dragIcon");
			CanvasGroup com6 = bind.GetCom<CanvasGroup>("select");
			GameObject gameObject2 = bind.GetGameObject("lockRoot");
			gameObject.SetActive(null != item);
			com6.alpha = 0f;
			if (item == null)
			{
				gameObject2.SetActive(false);
				com4.enabled = false;
				return;
			}
			bool flag = this._isLevelLimite(data);
			gameObject2.SetActive(flag);
			com4.enabled = !flag;
			com6.alpha = ((!this._isAlreadyInPotionSet(item.TableID)) ? 0f : 1f);
			ETCImageLoader.LoadSprite(ref com2, item.Icon, true);
			com5.sprite = com2.sprite;
			com5.material = com2.material;
			ETCImageLoader.LoadSprite(ref com, item.GetQualityInfo().Background, true);
			com3.text = item.Count.ToString();
		}

		// Token: 0x0600D273 RID: 53875 RVA: 0x00341014 File Offset: 0x0033F414
		private void _updateLevelLimitStatus(ChapterBattlePotionSetFrameData data)
		{
			if (data == null)
			{
				return;
			}
			ComCommonBind bind = data.bind;
			if (null == bind)
			{
				return;
			}
			ComDrag com = bind.GetCom<ComDrag>("dragCom");
			GameObject gameObject = bind.GetGameObject("lockRoot");
			if (DataManager<ItemDataManager>.GetInstance().GetItem(data.id) == null)
			{
				com.enabled = false;
				gameObject.SetActive(false);
				return;
			}
			bool flag = this._isLevelLimite(data);
			gameObject.SetActive(flag);
			com.enabled = !flag;
			if (flag)
			{
			}
		}

		// Token: 0x0600D274 RID: 53876 RVA: 0x003410A4 File Offset: 0x0033F4A4
		private bool _isLevelLimite(ChapterBattlePotionSetFrameData data)
		{
			if (data == null)
			{
				return false;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(data.id);
			return item != null && item.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level;
		}

		// Token: 0x0600D275 RID: 53877 RVA: 0x003410E4 File Offset: 0x0033F4E4
		private bool _isAlreadyInPotionSet(int tableID)
		{
			List<uint> potionSets = DataManager<PlayerBaseData>.GetInstance().potionSets;
			for (int i = 0; i < potionSets.Count; i++)
			{
				if ((long)tableID == (long)((ulong)potionSets[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04007B2B RID: 31531
		private const int kMaxBattlePotionSetCount = 3;

		// Token: 0x04007B2C RID: 31532
		private const int kMaxBattlePotionCount = 21;

		// Token: 0x04007B2D RID: 31533
		private const ulong kDefaultBattlePotionId = 18446744073709551615UL;

		// Token: 0x04007B2E RID: 31534
		private List<ChapterBattlePotionSetFrameData> mAllBattlePostions = new List<ChapterBattlePotionSetFrameData>();

		// Token: 0x04007B2F RID: 31535
		private bool mIsAllBattlePostionDirty;

		// Token: 0x04007B30 RID: 31536
		private Button mClose;

		// Token: 0x04007B31 RID: 31537
		private GameObject mDrugRoot;

		// Token: 0x04007B32 RID: 31538
		private ComDrop[] mDropItems = new ComDrop[3];

		// Token: 0x04007B33 RID: 31539
		private Image[] mConfigItems = new Image[3];

		// Token: 0x04007B34 RID: 31540
		private ScrollRect mScroll;

		// Token: 0x04007B35 RID: 31541
		private CanvasGroup[] mConfigItemSelects = new CanvasGroup[3];

		// Token: 0x04007B36 RID: 31542
		private ComDrag[] mDragItems = new ComDrag[3];

		// Token: 0x04007B37 RID: 31543
		private Image[] mDragFgItems = new Image[3];

		// Token: 0x04007B38 RID: 31544
		private ComDrop mCancelDrop;

		// Token: 0x04007B39 RID: 31545
		private ToggleGroup mToggleGroup;
	}
}
