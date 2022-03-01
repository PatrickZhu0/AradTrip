using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018DB RID: 6363
	public class ChangeFashionSpecialExchangeItem : ActivityItemBase
	{
		// Token: 0x0600F868 RID: 63592 RVA: 0x00438338 File Offset: 0x00436738
		public override void InitFromMode(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionNormalItemSelected, new ClientEventSystem.UIEventHandler(this.OnFashionNormalItemSelected));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionTicketBuyFinished, new ClientEventSystem.UIEventHandler(this.updateItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.updateItem));
			this.mActivityId = data.Id;
			this.mOnItemClick = onItemClick;
			this.thisMode = data;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				this.InitTask(data.TaskDatas[i]);
			}
			int num = -1;
			for (int j = 0; j < data.TaskDatas.Count; j++)
			{
				if (data.TaskDatas[j].State != OpActTaskState.OATS_OVER)
				{
					num = (int)data.TaskDatas[j].ParamNums2[0];
					break;
				}
			}
			switch (num)
			{
			case 12:
				this.mToggleHead.isOn = true;
				break;
			case 13:
				this.mToggleWaist.isOn = true;
				break;
			case 14:
				this.mToggleClothes.isOn = true;
				break;
			case 15:
				this.mTogglePants.isOn = true;
				break;
			case 16:
				this.mToggleChest.isOn = true;
				break;
			default:
				this.mToggleHead.isOn = true;
				break;
			}
			this.mPreviewBtn.SafeAddOnClickListener(delegate
			{
				this._ShowAvartar(this.mFashionItemId);
			});
		}

		// Token: 0x0600F869 RID: 63593 RVA: 0x004384D0 File Offset: 0x004368D0
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			for (int i = 0; i < this.thisMode.TaskDatas.Count; i++)
			{
				if (this.thisMode.TaskDatas[i].DataId == data.DataId)
				{
					this.thisMode.TaskDatas[i] = data;
				}
			}
			if (this.mCurFashionPart == (int)data.ParamNums2[0])
			{
				this.UpdateMiddleUI((int)data.DataId);
				this.UpdateTitle(data);
			}
		}

		// Token: 0x0600F86A RID: 63594 RVA: 0x0043855B File Offset: 0x0043695B
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
		}

		// Token: 0x0600F86B RID: 63595 RVA: 0x00438560 File Offset: 0x00436960
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
			this.mPreviewBtn.SafeRemoveAllListener();
			this.mGetFashionBtn.SafeRemoveAllListener();
			this.mGetBoxBtn.SafeRemoveAllListener();
			this.mExchangeBtn.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionNormalItemSelected, new ClientEventSystem.UIEventHandler(this.OnFashionNormalItemSelected));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionTicketBuyFinished, new ClientEventSystem.UIEventHandler(this.updateItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.updateItem));
		}

		// Token: 0x0600F86C RID: 63596 RVA: 0x00438642 File Offset: 0x00436A42
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600F86D RID: 63597 RVA: 0x0043865C File Offset: 0x00436A5C
		private void UpdateMiddleUI(int taskId)
		{
			ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = null;
			for (int i = 0; i < this.thisMode.TaskDatas.Count; i++)
			{
				if ((ulong)this.thisMode.TaskDatas[i].DataId == (ulong)((long)taskId))
				{
					limitTimeActivityTaskDataModel = this.thisMode.TaskDatas[i];
				}
			}
			if (limitTimeActivityTaskDataModel == null)
			{
				return;
			}
			this.mId = limitTimeActivityTaskDataModel.DataId;
			this.mCurSelectFashionUid = 0UL;
			this.mCurFashionPart = (int)limitTimeActivityTaskDataModel.ParamNums2[0];
			this.mCurSelectTaskId = taskId;
			List<ItemData> itemDataListBySubType = DataManager<ItemDataManager>.GetInstance().GetItemDataListBySubType((int)limitTimeActivityTaskDataModel.ParamNums2[0], EPackageType.Fashion);
			if (itemDataListBySubType == null)
			{
				return;
			}
			ItemData itemData = null;
			for (int j = 0; j < itemDataListBySubType.Count; j++)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemDataListBySubType[j].TableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.Color == ItemTable.eColor.PURPLE)
					{
						if (tableItem.TimeLeft == 0)
						{
							itemData = itemDataListBySubType[j];
							this.mCurSelectFashionUid = itemDataListBySubType[j].GUID;
							break;
						}
					}
				}
			}
			if (itemData != null)
			{
				this.SetMaterialFashion(itemData);
				this.mGetFashionBtnText.text = "替换";
			}
			else
			{
				this.SetMaterialFashion(null);
				this.mGetFashionBtnText.text = "获取";
			}
			ComItem comItem = this.mMaterialBox.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				ComItem comItem2 = ComItemManager.Create(this.mMaterialBox);
				comItem = comItem2;
				this.mComItems.Add(comItem);
			}
			ItemData BoxItemDetailData = ItemDataManager.CreateItemDataFromTable((int)limitTimeActivityTaskDataModel.ParamNums[0], 100, 0);
			if (BoxItemDetailData == null)
			{
				return;
			}
			string arg;
			if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)limitTimeActivityTaskDataModel.ParamNums[0], true) < (int)limitTimeActivityTaskDataModel.ParamNums[1])
			{
				arg = string.Format("<color=red>{0}</color>", DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)limitTimeActivityTaskDataModel.ParamNums[0], true));
			}
			else
			{
				arg = string.Format("<color=green>{0}</color>", DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)limitTimeActivityTaskDataModel.ParamNums[0], true));
			}
			this.mBoxCount.text = string.Format("{0}/{1}", arg, (int)limitTimeActivityTaskDataModel.ParamNums[1]);
			BoxItemDetailData.Count = 1;
			comItem.Setup(BoxItemDetailData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(BoxItemDetailData);
			});
			ComItem comItem3 = this.mTargetFashion.GetComponentInChildren<ComItem>();
			if (comItem3 == null)
			{
				ComItem comItem4 = ComItemManager.Create(this.mTargetFashion);
				comItem3 = comItem4;
				this.mComItems.Add(comItem3);
			}
			int itemIdInGiftPack = this.getItemIdInGiftPack((int)limitTimeActivityTaskDataModel.AwardDataList[0].id);
			ItemData FashionItemDetailData;
			if (itemIdInGiftPack == -1)
			{
				FashionItemDetailData = ItemDataManager.CreateItemDataFromTable((int)limitTimeActivityTaskDataModel.AwardDataList[0].id, 100, 0);
			}
			else
			{
				FashionItemDetailData = ItemDataManager.CreateItemDataFromTable(itemIdInGiftPack, 100, 0);
			}
			if (FashionItemDetailData == null)
			{
				return;
			}
			FashionItemDetailData.Count = (int)limitTimeActivityTaskDataModel.AwardDataList[0].num;
			comItem3.Setup(FashionItemDetailData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(FashionItemDetailData);
			});
			if (limitTimeActivityTaskDataModel.State == OpActTaskState.OATS_OVER)
			{
				this.mGrayBtn.CustomActive(true);
			}
			else
			{
				this.mGrayBtn.CustomActive(false);
			}
			this.mExchangeBtn.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mGetFashionBtn.SafeAddOnClickListener(new UnityAction(this.AddMergeFashionOnClick));
			this.mGetBoxBtn.SafeAddOnClickListener(delegate
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeToggleChange, 10100, null, null, null);
			});
			if (limitTimeActivityTaskDataModel.State == OpActTaskState.OATS_FINISHED)
			{
				Image component = this.mExchangeBtn.GetComponent<Image>();
				if (component != null)
				{
					ETCImageLoader.LoadSprite(ref component, "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_01", true);
				}
			}
			else
			{
				Image component2 = this.mExchangeBtn.GetComponent<Image>();
				if (component2 != null)
				{
					ETCImageLoader.LoadSprite(ref component2, "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_02", true);
				}
			}
			string arg2;
			if (limitTimeActivityTaskDataModel.DoneNum < limitTimeActivityTaskDataModel.TotalNum)
			{
				arg2 = string.Format("<color=red>{0}</color>", limitTimeActivityTaskDataModel.DoneNum);
			}
			else
			{
				arg2 = string.Format("<color=white>{0}</color>", limitTimeActivityTaskDataModel.DoneNum);
			}
			this.mExchangeBtnText.SafeSetText(string.Format("兑换（{0}/{1}）", arg2, limitTimeActivityTaskDataModel.TotalNum));
		}

		// Token: 0x0600F86E RID: 63598 RVA: 0x00438B24 File Offset: 0x00436F24
		private void SetMaterialFashion(ItemData itemData)
		{
			if (itemData != null)
			{
				ComItem comItem = this.mMaterialFashion.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					ComItem comItem2 = ComItemManager.Create(this.mMaterialFashion);
					comItem = comItem2;
					this.mComItems.Add(comItem);
				}
				ItemData ItemDetailData = itemData;
				if (ItemDetailData == null)
				{
					return;
				}
				ItemDetailData.Count = 1;
				comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
				{
					this._OnShowTips(ItemDetailData);
				});
				this.mCurSelectFashionUid = itemData.GUID;
			}
		}

		// Token: 0x0600F86F RID: 63599 RVA: 0x00438BBC File Offset: 0x00436FBC
		public void AddMergeFashionOnClick()
		{
			FashionItemSelectedType userData = new FashionItemSelectedType
			{
				FashionPart = (ItemTable.eSubType)this.mCurFashionPart,
				IsLeft = true,
				NeedBlue = false
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionMergeNewItemFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600F870 RID: 63600 RVA: 0x00438BFD File Offset: 0x00436FFD
		protected override void _OnItemClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick((int)this.mId, 0, this.mCurSelectFashionUid);
			}
		}

		// Token: 0x0600F871 RID: 63601 RVA: 0x00438C24 File Offset: 0x00437024
		private void _ShowAvartar(int id)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PlayerTryOnFrame>(null))
			{
				PlayerTryOnFrame playerTryOnFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PlayerTryOnFrame)) as PlayerTryOnFrame;
				if (playerTryOnFrame != null)
				{
					playerTryOnFrame.Reset(id);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, id, string.Empty);
			}
		}

		// Token: 0x0600F872 RID: 63602 RVA: 0x00438C84 File Offset: 0x00437084
		private int getItemIdInGiftPack(int id)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return -1;
			}
			GiftPackTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(tableItem.PackageID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return -1;
			}
			for (int i = 0; i < tableItem2.Items.Count; i++)
			{
				GiftTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(tableItem2.Items[i], string.Empty, string.Empty);
				if (tableItem3.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
				{
					return tableItem3.ItemID;
				}
			}
			return -1;
		}

		// Token: 0x0600F873 RID: 63603 RVA: 0x00438D38 File Offset: 0x00437138
		private void InitTask(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null && data.AwardDataList != null)
			{
				switch (data.ParamNums2[0])
				{
				case 12U:
				{
					ComItem comItem = ComItemManager.Create(this.mToggleHead.gameObject);
					if (comItem != null)
					{
						int itemIdInGiftPack = this.getItemIdInGiftPack((int)data.AwardDataList[0].id);
						ItemData itemData;
						if (itemIdInGiftPack == -1)
						{
							itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[0].id, 100, 0);
						}
						else
						{
							itemData = ItemDataManager.CreateItemDataFromTable(itemIdInGiftPack, 100, 0);
						}
						itemData.Count = (int)data.AwardDataList[0].num;
						comItem.Setup(itemData, null);
						this.mComItems.Add(comItem);
					}
					this.mToggleHead.onValueChanged.RemoveAllListeners();
					this.mToggleHead.onValueChanged.AddListener(delegate(bool value)
					{
						if (value)
						{
							this.UpdateMiddleUI((int)data.DataId);
						}
					});
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mToggleHeadGray.enabled = false;
					}
					else
					{
						this.mToggleHeadGray.enabled = true;
					}
					break;
				}
				case 13U:
				{
					ComItem comItem2 = ComItemManager.Create(this.mToggleWaist.gameObject);
					if (comItem2 != null)
					{
						int itemIdInGiftPack2 = this.getItemIdInGiftPack((int)data.AwardDataList[0].id);
						ItemData itemData2;
						if (itemIdInGiftPack2 == -1)
						{
							itemData2 = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[0].id, 100, 0);
						}
						else
						{
							itemData2 = ItemDataManager.CreateItemDataFromTable(itemIdInGiftPack2, 100, 0);
						}
						itemData2.Count = (int)data.AwardDataList[0].num;
						comItem2.Setup(itemData2, null);
						this.mComItems.Add(comItem2);
					}
					this.mToggleWaist.onValueChanged.RemoveAllListeners();
					this.mToggleWaist.onValueChanged.AddListener(delegate(bool value)
					{
						if (value)
						{
							this.UpdateMiddleUI((int)data.DataId);
						}
					});
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mToggleWaistGray.enabled = false;
					}
					else
					{
						this.mToggleWaistGray.enabled = true;
					}
					break;
				}
				case 14U:
				{
					ComItem comItem3 = ComItemManager.Create(this.mToggleClothes.gameObject);
					if (comItem3 != null)
					{
						int itemIdInGiftPack3 = this.getItemIdInGiftPack((int)data.AwardDataList[0].id);
						ItemData itemData3;
						if (itemIdInGiftPack3 == -1)
						{
							itemData3 = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[0].id, 100, 0);
						}
						else
						{
							itemData3 = ItemDataManager.CreateItemDataFromTable(itemIdInGiftPack3, 100, 0);
						}
						itemData3.Count = (int)data.AwardDataList[0].num;
						comItem3.Setup(itemData3, null);
						this.mComItems.Add(comItem3);
					}
					this.mToggleClothes.onValueChanged.RemoveAllListeners();
					this.mToggleClothes.onValueChanged.AddListener(delegate(bool value)
					{
						if (value)
						{
							this.UpdateMiddleUI((int)data.DataId);
						}
					});
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mToggleClothesGray.enabled = false;
					}
					else
					{
						this.mToggleClothesGray.enabled = true;
					}
					break;
				}
				case 15U:
				{
					ComItem comItem4 = ComItemManager.Create(this.mTogglePants.gameObject);
					if (comItem4 != null)
					{
						int itemIdInGiftPack4 = this.getItemIdInGiftPack((int)data.AwardDataList[0].id);
						ItemData itemData4;
						if (itemIdInGiftPack4 == -1)
						{
							itemData4 = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[0].id, 100, 0);
						}
						else
						{
							itemData4 = ItemDataManager.CreateItemDataFromTable(itemIdInGiftPack4, 100, 0);
						}
						itemData4.Count = (int)data.AwardDataList[0].num;
						comItem4.Setup(itemData4, null);
						this.mComItems.Add(comItem4);
					}
					this.mTogglePants.onValueChanged.RemoveAllListeners();
					this.mTogglePants.onValueChanged.AddListener(delegate(bool value)
					{
						if (value)
						{
							this.UpdateMiddleUI((int)data.DataId);
						}
					});
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mTogglePantsGray.enabled = false;
					}
					else
					{
						this.mTogglePantsGray.enabled = true;
					}
					break;
				}
				case 16U:
				{
					ComItem comItem5 = ComItemManager.Create(this.mToggleChest.gameObject);
					if (comItem5 != null)
					{
						int itemIdInGiftPack5 = this.getItemIdInGiftPack((int)data.AwardDataList[0].id);
						ItemData itemData5;
						if (itemIdInGiftPack5 == -1)
						{
							itemData5 = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[0].id, 100, 0);
						}
						else
						{
							itemData5 = ItemDataManager.CreateItemDataFromTable(itemIdInGiftPack5, 100, 0);
						}
						itemData5.Count = (int)data.AwardDataList[0].num;
						comItem5.Setup(itemData5, null);
						this.mComItems.Add(comItem5);
					}
					this.mToggleChest.onValueChanged.RemoveAllListeners();
					this.mToggleChest.onValueChanged.AddListener(delegate(bool value)
					{
						if (value)
						{
							this.UpdateMiddleUI((int)data.DataId);
						}
					});
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mToggleChestGray.enabled = false;
					}
					else
					{
						this.mToggleChestGray.enabled = true;
					}
					break;
				}
				}
			}
		}

		// Token: 0x0600F874 RID: 63604 RVA: 0x004392D0 File Offset: 0x004376D0
		private void UpdateTitle(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null && data.AwardDataList != null)
			{
				switch (data.ParamNums2[0])
				{
				case 12U:
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mToggleHeadGray.enabled = false;
					}
					else
					{
						this.mToggleHeadGray.enabled = true;
					}
					break;
				case 13U:
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mToggleWaistGray.enabled = false;
					}
					else
					{
						this.mToggleWaistGray.enabled = true;
					}
					break;
				case 14U:
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mToggleClothesGray.enabled = false;
					}
					else
					{
						this.mToggleClothesGray.enabled = true;
					}
					break;
				case 15U:
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mTogglePantsGray.enabled = false;
					}
					else
					{
						this.mTogglePantsGray.enabled = true;
					}
					break;
				case 16U:
					if (data.State == OpActTaskState.OATS_OVER)
					{
						this.mToggleChestGray.enabled = false;
					}
					else
					{
						this.mToggleChestGray.enabled = true;
					}
					break;
				}
			}
		}

		// Token: 0x0600F875 RID: 63605 RVA: 0x00439404 File Offset: 0x00437804
		private int GetFastBuyItemId(MallItemTable mallItemTableData)
		{
			string s = "-1";
			int result = -1;
			try
			{
				switch (this.mCurFashionPart)
				{
				case 12:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[0].Split(new char[]
					{
						':'
					})[0];
					break;
				case 13:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[4].Split(new char[]
					{
						':'
					})[0];
					break;
				case 14:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[1].Split(new char[]
					{
						':'
					})[0];
					break;
				case 15:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[3].Split(new char[]
					{
						':'
					})[0];
					break;
				case 16:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[2].Split(new char[]
					{
						':'
					})[0];
					break;
				}
				int.TryParse(s, out result);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("{0}", new object[]
				{
					ex.ToString()
				});
				return -1;
			}
			return result;
		}

		// Token: 0x0600F876 RID: 63606 RVA: 0x00439584 File Offset: 0x00437984
		private void OnFashionNormalItemSelected(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			ComFashionMergeItemEx comFashionMergeItemEx = uiEvent.Param1 as ComFashionMergeItemEx;
			this.SetMaterialFashion(comFashionMergeItemEx.ItemData);
		}

		// Token: 0x0600F877 RID: 63607 RVA: 0x004395B0 File Offset: 0x004379B0
		private void updateItem(UIEvent uiEvent)
		{
			this.UpdateMiddleUI(this.mCurSelectTaskId);
		}

		// Token: 0x040099A4 RID: 39332
		[SerializeField]
		private Toggle mToggleHead;

		// Token: 0x040099A5 RID: 39333
		[SerializeField]
		private UIGray mToggleHeadGray;

		// Token: 0x040099A6 RID: 39334
		[SerializeField]
		private Toggle mToggleClothes;

		// Token: 0x040099A7 RID: 39335
		[SerializeField]
		private UIGray mToggleClothesGray;

		// Token: 0x040099A8 RID: 39336
		[SerializeField]
		private Toggle mTogglePants;

		// Token: 0x040099A9 RID: 39337
		[SerializeField]
		private UIGray mTogglePantsGray;

		// Token: 0x040099AA RID: 39338
		[SerializeField]
		private Toggle mToggleChest;

		// Token: 0x040099AB RID: 39339
		[SerializeField]
		private UIGray mToggleChestGray;

		// Token: 0x040099AC RID: 39340
		[SerializeField]
		private Toggle mToggleWaist;

		// Token: 0x040099AD RID: 39341
		[SerializeField]
		private UIGray mToggleWaistGray;

		// Token: 0x040099AE RID: 39342
		[SerializeField]
		private Button mPreviewBtn;

		// Token: 0x040099AF RID: 39343
		[SerializeField]
		private GameObject mMaterialFashion;

		// Token: 0x040099B0 RID: 39344
		[SerializeField]
		private GameObject mMaterialBox;

		// Token: 0x040099B1 RID: 39345
		[SerializeField]
		private GameObject mTargetFashion;

		// Token: 0x040099B2 RID: 39346
		[SerializeField]
		private Button mGetFashionBtn;

		// Token: 0x040099B3 RID: 39347
		[SerializeField]
		private Button mGetBoxBtn;

		// Token: 0x040099B4 RID: 39348
		[SerializeField]
		private Button mExchangeBtn;

		// Token: 0x040099B5 RID: 39349
		[SerializeField]
		private GameObject mGrayBtn;

		// Token: 0x040099B6 RID: 39350
		[SerializeField]
		private int mFashionItemId;

		// Token: 0x040099B7 RID: 39351
		[SerializeField]
		private Text mBoxCount;

		// Token: 0x040099B8 RID: 39352
		[SerializeField]
		private Text mExchangeBtnText;

		// Token: 0x040099B9 RID: 39353
		[SerializeField]
		private Text mGetFashionBtnText;

		// Token: 0x040099BA RID: 39354
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x040099BB RID: 39355
		private ulong mCurSelectFashionUid;

		// Token: 0x040099BC RID: 39356
		private int mCurFashionPart = -1;

		// Token: 0x040099BD RID: 39357
		private int mCurSelectTaskId;

		// Token: 0x040099BE RID: 39358
		private ILimitTimeActivityModel thisMode;

		// Token: 0x040099BF RID: 39359
		private const string yellowBtnImagePath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_01";

		// Token: 0x040099C0 RID: 39360
		private const string blueBtnImagePath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_02";
	}
}
