using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200112C RID: 4396
	public class MapItemFrame : ClientFrame
	{
		// Token: 0x0600A700 RID: 42752 RVA: 0x0022CB6E File Offset: 0x0022AF6E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/MapItemFrame";
		}

		// Token: 0x0600A701 RID: 42753 RVA: 0x0022CB75 File Offset: 0x0022AF75
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this._InitNearItemScrollListBind();
			this.RefreshNearItemListCount();
		}

		// Token: 0x0600A702 RID: 42754 RVA: 0x0022CB89 File Offset: 0x0022AF89
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this._ClearData();
		}

		// Token: 0x0600A703 RID: 42755 RVA: 0x0022CB97 File Offset: 0x0022AF97
		private void _ClearData()
		{
		}

		// Token: 0x0600A704 RID: 42756 RVA: 0x0022CB99 File Offset: 0x0022AF99
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NearItemsChanged, new ClientEventSystem.UIEventHandler(this._OnNearItemsChanged));
		}

		// Token: 0x0600A705 RID: 42757 RVA: 0x0022CBB6 File Offset: 0x0022AFB6
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NearItemsChanged, new ClientEventSystem.UIEventHandler(this._OnNearItemsChanged));
		}

		// Token: 0x0600A706 RID: 42758 RVA: 0x0022CBD3 File Offset: 0x0022AFD3
		private void _OnNearItemsChanged(UIEvent iEvent)
		{
			this.RefreshNearItemListCount();
		}

		// Token: 0x0600A707 RID: 42759 RVA: 0x0022CBDB File Offset: 0x0022AFDB
		private void OnUpdateAvatar(UIEvent iEvent)
		{
			this._UpdateActorShow();
		}

		// Token: 0x0600A708 RID: 42760 RVA: 0x0022CBE3 File Offset: 0x0022AFE3
		private void _OnAddNewItem(List<Item> items)
		{
		}

		// Token: 0x0600A709 RID: 42761 RVA: 0x0022CBE5 File Offset: 0x0022AFE5
		private void _OnRemoveItem(ItemData data)
		{
		}

		// Token: 0x0600A70A RID: 42762 RVA: 0x0022CBE7 File Offset: 0x0022AFE7
		private void _OnUpdateItem(List<Item> items)
		{
		}

		// Token: 0x0600A70B RID: 42763 RVA: 0x0022CBEC File Offset: 0x0022AFEC
		private void _InitNearItemScrollListBind()
		{
			this.mMapItemsScrollView.Initialize();
			this.mMapItemsScrollView.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateItemScrollListBind(item);
				}
			};
			this.mMapItemsScrollView.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("item");
				com.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600A70C RID: 42764 RVA: 0x0022CC43 File Offset: 0x0022B043
		private void _InitPackageItemList()
		{
			this.mPackageItemsScrollView.Initialize();
			this.mPackageItemsScrollView.onBindItem = ((GameObject obj) => base.CreateComItem(obj));
			this.mPackageItemsScrollView.onItemVisiable = delegate(ComUIListElementScript item)
			{
				List<ulong> packageItems = DataManager<ItemDataManager>.GetInstance().GetPackageItems();
				if (item.m_index >= 0)
				{
					ComItem comItem = item.gameObjectBindScript as ComItem;
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(packageItems[item.m_index]);
					if (item2 != null)
					{
						comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
						comItem.Setup(item2, new ComItem.OnItemClicked(this._OnPackageItemClicked));
						comItem.SetEnable(true);
					}
				}
			};
		}

		// Token: 0x0600A70D RID: 42765 RVA: 0x0022CC80 File Offset: 0x0022B080
		private void _UpdateItemScrollListBind(ComUIListElementScript item)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			if (clientSystemGameBattle.MainPlayer == null)
			{
				return;
			}
			List<BeItem> list = clientSystemGameBattle.MainPlayer.FindNearestTownItems();
			if (list == null || item.m_index < 0 || item.m_index >= list.Count)
			{
				return;
			}
			this.RefreshItemInfo(item, list[item.m_index].ItemID, list[item.m_index].ActorData.GUID);
		}

		// Token: 0x0600A70E RID: 42766 RVA: 0x0022CD10 File Offset: 0x0022B110
		private void RefreshItemInfo(ComUIListElementScript item, int itemId, ulong GUID)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("name");
			Image com2 = component.GetCom<Image>("icon");
			Button com3 = component.GetCom<Button>("item");
			Image com4 = component.GetCom<Image>("itemBg");
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemId, 100, 0);
			if (itemData == null)
			{
				return;
			}
			if (com != null)
			{
				com.text = itemData.GetColorName(string.Empty, false);
			}
			if (com2 != null)
			{
				ETCImageLoader.LoadSprite(ref com2, itemData.Icon, true);
			}
			if (com4 != null)
			{
				ETCImageLoader.LoadSprite(ref com4, itemData.GetQualityInfo().Background, true);
			}
			if (com3 != null)
			{
				com3.onClick.RemoveAllListeners();
				int itemid = itemId;
				ulong guid = GUID;
				com3.onClick.AddListener(delegate()
				{
					this._OnClickNearItem(itemid, guid);
				});
			}
		}

		// Token: 0x0600A70F RID: 42767 RVA: 0x0022CE20 File Offset: 0x0022B220
		public void RefreshNearItemListCount()
		{
			if (this.mMapItemsScrollView == null)
			{
				return;
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			if (clientSystemGameBattle.MainPlayer == null)
			{
				return;
			}
			List<BeItem> list = clientSystemGameBattle.MainPlayer.FindNearestTownItems();
			if (list == null)
			{
				return;
			}
			this.mMapItemsScrollView.SetElementAmount(list.Count);
		}

		// Token: 0x0600A710 RID: 42768 RVA: 0x0022CE88 File Offset: 0x0022B288
		private void _RefreshPackageItemListCount()
		{
			if (this.mPackageItemsScrollView == null)
			{
				return;
			}
			List<ulong> packageItems = DataManager<ItemDataManager>.GetInstance().GetPackageItems();
			if (packageItems == null)
			{
				return;
			}
			this.mPackageItemsScrollView.SetElementAmount(packageItems.Count);
		}

		// Token: 0x0600A711 RID: 42769 RVA: 0x0022CECC File Offset: 0x0022B2CC
		private void _UpdateActorShow()
		{
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find JobTable with id:{0}", new object[]
				{
					DataManager<PlayerBaseData>.GetInstance().JobTableID
				});
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
				{
					tableItem.Mode
				});
				return;
			}
			this.mActorShowGeAvatarRender.ClearAvatar();
			this.mActorShowGeAvatarRender.LoadAvatar(tableItem2.ModelPath, -1);
			DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.mActorShowGeAvatarRender, null, false);
			this.mActorShowGeAvatarRender.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
			this.mActorShowGeAvatarRender.SuitAvatar(true, false);
			this.mActorShowGeAvatarRender.ChangeAction("Anim_Show_Idle", 1f, true);
		}

		// Token: 0x0600A712 RID: 42770 RVA: 0x0022CFD8 File Offset: 0x0022B3D8
		private void _OnClickNearItem(int itemId, ulong guid)
		{
			if (itemId <= 0)
			{
				return;
			}
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle))
			{
				Logger.LogError("Current System is not GameBattle!!!");
				return;
			}
			DataManager<ChijiDataManager>.GetInstance().SendPickUpMapBoxs(guid);
		}

		// Token: 0x0600A713 RID: 42771 RVA: 0x0022D01C File Offset: 0x0022B41C
		private void _OnPackageItemClicked(GameObject obj, ItemData item)
		{
			if (item == null)
			{
				return;
			}
			List<TipFuncButon> list = new List<TipFuncButon>();
			if ((item.UseType == ItemTable.eCanUse.UseOne || item.UseType == ItemTable.eCanUse.UseTotal) && !item.IsCooling() && !item.isInSidePack)
			{
				TipFuncButon tipFuncButon = new TipFuncButonSpecial();
				if (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.Fashion || item.PackageType == EPackageType.Title)
				{
					tipFuncButon.text = TR.Value("tip_wear");
					tipFuncButon.callback = new OnTipFuncClicked(this._TryOnUseItem);
				}
				else if (item.PackageType == EPackageType.Consumable && item.SubType == 53)
				{
					tipFuncButon.text = TR.Value("tip_use");
				}
				else
				{
					tipFuncButon.text = TR.Value("tip_use");
				}
				list.Add(tipFuncButon);
			}
			ItemData itemData = this._GetCompareItem(item);
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTipWithCompareItem(item, itemData, list, true);
			}
			else
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, list, 3, true, false, true);
			}
		}

		// Token: 0x0600A714 RID: 42772 RVA: 0x0022D130 File Offset: 0x0022B530
		private void _TryOnUseItem(ItemData item, object data)
		{
			if (item.Type == ItemTable.eType.EQUIP)
			{
				int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
				if (masterPriority == 2)
				{
					SystemNotifyManager.SystemNotifyOkCancel(7019, delegate
					{
						this._OnUseItem(item, data);
					}, null, FrameLayer.High, false);
					return;
				}
			}
			this._OnUseItem(item, data);
		}

		// Token: 0x0600A715 RID: 42773 RVA: 0x0022D1D4 File Offset: 0x0022B5D4
		private void _OnUseItem(ItemData item, object data)
		{
			if (item == null)
			{
				return;
			}
			DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
			if (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.Fashion)
			{
				MonoSingleton<AudioManager>.instance.PlaySound(102);
			}
			if (item.Count <= 1 || item.CD > 0)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600A716 RID: 42774 RVA: 0x0022D240 File Offset: 0x0022B640
		private ItemData _GetCompareItem(ItemData item)
		{
			ItemData result = null;
			if (item != null && item.WillCanEquip())
			{
				List<ulong> list = null;
				if (item.PackageType == EPackageType.Equip)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				}
				else if (item.PackageType == EPackageType.Fashion)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
				}
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(list[i]);
						if (item2 != null && item2.GUID != item.GUID && item2.IsWearSoltEqual(item))
						{
							result = item2;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600A717 RID: 42775 RVA: 0x0022D2F1 File Offset: 0x0022B6F1
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A718 RID: 42776 RVA: 0x0022D2F4 File Offset: 0x0022B6F4
		protected override void _OnUpdate(float timeElapsed)
		{
			if (null != this.mActorShowGeAvatarRender)
			{
				while (Global.Settings.avatarLightDir.x > 360f)
				{
					GlobalSetting settings = Global.Settings;
					settings.avatarLightDir.x = settings.avatarLightDir.x - 360f;
				}
				while (Global.Settings.avatarLightDir.x < 0f)
				{
					GlobalSetting settings2 = Global.Settings;
					settings2.avatarLightDir.x = settings2.avatarLightDir.x + 360f;
				}
				while (Global.Settings.avatarLightDir.y > 360f)
				{
					GlobalSetting settings3 = Global.Settings;
					settings3.avatarLightDir.y = settings3.avatarLightDir.y - 360f;
				}
				while (Global.Settings.avatarLightDir.y < 0f)
				{
					GlobalSetting settings4 = Global.Settings;
					settings4.avatarLightDir.y = settings4.avatarLightDir.y + 360f;
				}
				while (Global.Settings.avatarLightDir.z > 360f)
				{
					GlobalSetting settings5 = Global.Settings;
					settings5.avatarLightDir.z = settings5.avatarLightDir.z - 360f;
				}
				while (Global.Settings.avatarLightDir.z < 0f)
				{
					GlobalSetting settings6 = Global.Settings;
					settings6.avatarLightDir.z = settings6.avatarLightDir.z + 360f;
				}
				this.mActorShowGeAvatarRender.m_LightRot = Global.Settings.avatarLightDir;
			}
		}

		// Token: 0x0600A719 RID: 42777 RVA: 0x0022D480 File Offset: 0x0022B880
		protected override void _bindExUI()
		{
			this.mMapItemsScrollView = this.mBind.GetCom<ComUIListScript>("MapItemsScrollView");
			this.mPackageItemsScrollView = this.mBind.GetCom<ComUIListScript>("PackageItemsScrollView");
			this.mActorShowGeAvatarRender = this.mBind.GetCom<GeAvatarRendererEx>("ActorShowGeAvatarRender");
			this.mAllPickUp = this.mBind.GetCom<Button>("PickUp");
			if (null != this.mAllPickUp)
			{
				this.mAllPickUp.onClick.AddListener(new UnityAction(this._onAllPickUpButtonClick));
			}
			this.mNearitemsRect = this.mBind.GetCom<RectTransform>("nearitemsRect");
		}

		// Token: 0x0600A71A RID: 42778 RVA: 0x0022D528 File Offset: 0x0022B928
		protected override void _unbindExUI()
		{
			this.mMapItemsScrollView = null;
			this.mPackageItemsScrollView = null;
			this.mActorShowGeAvatarRender = null;
			if (null != this.mAllPickUp)
			{
				this.mAllPickUp.onClick.RemoveListener(new UnityAction(this._onAllPickUpButtonClick));
			}
			this.mAllPickUp = null;
			this.mNearitemsRect = null;
		}

		// Token: 0x0600A71B RID: 42779 RVA: 0x0022D588 File Offset: 0x0022B988
		private void _onAllPickUpButtonClick()
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			if (clientSystemGameBattle.MainPlayer == null)
			{
				return;
			}
			List<BeItem> list = clientSystemGameBattle.MainPlayer.FindNearestTownItems();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					DataManager<ChijiDataManager>.GetInstance().SendPickUpMapBoxs(list[i].ActorData.GUID);
				}
			}
		}

		// Token: 0x04005D7F RID: 23935
		private ComUIListScript mMapItemsScrollView;

		// Token: 0x04005D80 RID: 23936
		private ComUIListScript mPackageItemsScrollView;

		// Token: 0x04005D81 RID: 23937
		private GeAvatarRendererEx mActorShowGeAvatarRender;

		// Token: 0x04005D82 RID: 23938
		private Button mAllPickUp;

		// Token: 0x04005D83 RID: 23939
		private RectTransform mNearitemsRect;
	}
}
