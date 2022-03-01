using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016F2 RID: 5874
	internal class PackageNewFrame : ClientFrame
	{
		// Token: 0x0600E5FC RID: 58876 RVA: 0x003BF91C File Offset: 0x003BDD1C
		public PackageNewFrame()
		{
			int[] array = new int[4];
			array[1] = 1;
			this.m_PlayList = array;
			this.m_QuickSellToggles = new Toggle[3];
			this.m_arrQualityToggles = new Toggle[3];
			this.mDecomposeMask = 1;
			this.m_arrItemTabInfos = new PackageNewFrame.ItemTabInfo[]
			{
				new PackageNewFrame.ItemTabInfo
				{
					ePackageType = EPackageType.Equip
				},
				new PackageNewFrame.ItemTabInfo
				{
					ePackageType = EPackageType.Material
				},
				new PackageNewFrame.ItemTabInfo
				{
					ePackageType = EPackageType.Consumable
				},
				new PackageNewFrame.ItemTabInfo
				{
					ePackageType = EPackageType.Fashion
				},
				new PackageNewFrame.ItemTabInfo
				{
					ePackageType = EPackageType.Title
				},
				new PackageNewFrame.ItemTabInfo
				{
					ePackageType = EPackageType.Inscription
				}
			};
			base..ctor();
		}

		// Token: 0x0600E5FD RID: 58877 RVA: 0x003BFC8C File Offset: 0x003BE08C
		protected override void _bindExUI()
		{
			this.mPackagButtom = this.mBind.GetGameObject("packagButtom");
			this.mPackageItemListTabs = this.mBind.GetGameObject("packageItemListTabs");
			this.mPackageActorShow = this.mBind.GetGameObject("packageActorShow");
			this.mPackageItemListView = this.mBind.GetGameObject("packageItemListView");
			this.mPackageFulltips = this.mBind.GetCom<Button>("packageFulltips");
			this.mPackageFulltips.onClick.AddListener(new UnityAction(this._onPackageFulltipsButtonClick));
			this.mPackageFulText = this.mBind.GetCom<Text>("packageFulText");
			this.mPetRoot = this.mBind.GetGameObject("petRoot");
			this.m_scrollRect = this.mBind.GetCom<ScrollRect>("ItemScrollRect");
			this.m_comItemList = this.mBind.GetCom<ComUIListScriptEx>("ItemListView");
			this.m_objShop = this.mBind.GetCom<Button>("Shop");
			this.m_objShop.SafeAddOnClickListener(new UnityAction(this._OnShopClicked));
			this.m_objFashionMerge = this.mBind.GetCom<Button>("FashionMerge");
			this.m_objFashionMerge.SafeAddOnClickListener(new UnityAction(this._OnFashionMergeClicked));
			this.fashionEquipDecomposeRoot = this.mBind.GetGameObject("fashionEquipDecomposeRoot");
		}

		// Token: 0x0600E5FE RID: 58878 RVA: 0x003BFDEC File Offset: 0x003BE1EC
		protected override void _unbindExUI()
		{
			this.mPackageSwitchWeapon = null;
			this.mPackagButtom = null;
			this.mPackageItemListTabs = null;
			this.mPackageActorShow = null;
			this.mPackageItemListView = null;
			this.mPackageFulltips.onClick.RemoveListener(new UnityAction(this._onPackageFulltipsButtonClick));
			this.switchWeaponBtn.SafeRemoveOnClickListener(new UnityAction(this.OnSwitchWeaponFrame));
			this.mPackageFulltips = null;
			this.mPackageFulText = null;
			this.mPetRoot = null;
			this.m_scrollRect = null;
			this.m_comItemList = null;
			this.switchWeaponBtn = null;
			this.m_objShop.SafeRemoveOnClickListener(new UnityAction(this._OnShopClicked));
			this.m_objShop = null;
			this.m_objFashionMerge.SafeRemoveOnClickListener(new UnityAction(this._OnFashionMergeClicked));
			this.m_objFashionMerge = null;
			this.fashionEquipDecomposeRoot = null;
		}

		// Token: 0x0600E5FF RID: 58879 RVA: 0x003BFEBC File Offset: 0x003BE2BC
		private void _onPackageFulltipsButtonClick()
		{
			this._SetPackageFullTipActive(false);
		}

		// Token: 0x0600E600 RID: 58880 RVA: 0x003BFEC8 File Offset: 0x003BE2C8
		private void _onSkillDamageButtonClick()
		{
			SkillDamageFrame skillDamageFrame = Singleton<ClientSystemManager>.instance.OpenFrame<SkillDamageFrame>(FrameLayer.Middle, null, string.Empty) as SkillDamageFrame;
			if (skillDamageFrame != null)
			{
				skillDamageFrame.InitData(false);
			}
		}

		// Token: 0x0600E601 RID: 58881 RVA: 0x003BFEF9 File Offset: 0x003BE2F9
		private void OnOpenTitleBookFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TitleBookFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600E602 RID: 58882 RVA: 0x003BFF0D File Offset: 0x003BE30D
		private void OnOpeWeaponLeaseFrame()
		{
			WeaponLeaseShopFrame.OpenLinkFrame("26");
		}

		// Token: 0x0600E603 RID: 58883 RVA: 0x003BFF19 File Offset: 0x003BE319
		private void OnOpenEnchantmentsBookFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EnchantmentsBookFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600E604 RID: 58884 RVA: 0x003BFF2D File Offset: 0x003BE32D
		private void OnSwitchWeaponFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SwitchWeaponFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("SwitchWeapon");
		}

		// Token: 0x0600E605 RID: 58885 RVA: 0x003BFF50 File Offset: 0x003BE350
		private void _OnOpenChapterPotionSetClicked()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<ChapterBattlePotionSetFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600E606 RID: 58886 RVA: 0x003BFF64 File Offset: 0x003BE364
		private void _OnOpenQuickDecomposeClicked()
		{
			this._OpenQuickDecompose();
		}

		// Token: 0x0600E607 RID: 58887 RVA: 0x003BFF6C File Offset: 0x003BE36C
		private void _OnOpenQuickSellClicked()
		{
			this._OpenQuickSell();
		}

		// Token: 0x0600E608 RID: 58888 RVA: 0x003BFF74 File Offset: 0x003BE374
		private void _OnArrangePackage()
		{
			SceneTrimItem cmd = new SceneTrimItem
			{
				pack = (byte)this.m_currentItemType
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneTrimItem>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneTrimItemRet>(delegate(SceneTrimItemRet msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.code != 0U)
				{
					CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)msgRet.code, string.Empty, string.Empty);
					if (tableItem != null)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					}
					else
					{
						SystemNotifyManager.SysNotifyMsgBoxOK(Utility.ProtocolErrorString(msgRet.code), null, string.Empty, false);
					}
				}
				else
				{
					DataManager<ItemDataManager>.GetInstance().ArrangeItemsInPackageFrame(this.m_currentItemType);
					this._RefreshItemTab();
					this._RefreshItemList(false);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600E609 RID: 58889 RVA: 0x003BFFC3 File Offset: 0x003BE3C3
		private void _OnLevelupGridCountClicked()
		{
			this._UpgradePackageSize();
		}

		// Token: 0x0600E60A RID: 58890 RVA: 0x003BFFCB File Offset: 0x003BE3CB
		private void OnOpenActorAttTipShow()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RoleAttributeTipFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600E60B RID: 58891 RVA: 0x003BFFDF File Offset: 0x003BE3DF
		protected void _OnClose()
		{
			this.frameMgr.CloseFrame<PackageNewFrame>(this, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<PetPacketFrame>(null, false);
		}

		// Token: 0x0600E60C RID: 58892 RVA: 0x003BFFFC File Offset: 0x003BE3FC
		private void _OnShopClicked()
		{
			MallNewFrameParamData userData = new MallNewFrameParamData
			{
				MallNewType = MallNewType.FashionMall
			};
			this.frameMgr.OpenFrame<MallNewFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600E60D RID: 58893 RVA: 0x003C002B File Offset: 0x003BE42B
		private void _OnFashionMergeClicked()
		{
			FashionMergeNewFrame.OpenLinkFrame(string.Format("1|0|{0}|{1}|{2}", (int)DataManager<FashionMergeManager>.GetInstance().FashionType, (int)DataManager<FashionMergeManager>.GetInstance().FashionPart, 0));
		}

		// Token: 0x0600E60E RID: 58894 RVA: 0x003C0060 File Offset: 0x003BE460
		private void _OnInscriptionMergeClicked()
		{
			SmithShopNewLinkData smithShopNewLinkData = new SmithShopNewLinkData();
			smithShopNewLinkData.iDefaultFirstTabId = 4;
			smithShopNewLinkData.iDefaultSecondTabId = 1;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, smithShopNewLinkData, string.Empty);
		}

		// Token: 0x0600E60F RID: 58895 RVA: 0x003C0094 File Offset: 0x003BE494
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				int num = int.Parse(strParam);
				EPackageOpenMode epackageOpenMode = (EPackageOpenMode)num;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, epackageOpenMode, string.Empty);
			}
			catch (Exception ex)
			{
				Logger.LogError("PackageFrame.OpenLinkFrame : ==>" + ex.ToString());
			}
		}

		// Token: 0x0600E610 RID: 58896 RVA: 0x003C00F4 File Offset: 0x003BE4F4
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/PackageNew";
		}

		// Token: 0x0600E611 RID: 58897 RVA: 0x003C00FB File Offset: 0x003BE4FB
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600E612 RID: 58898 RVA: 0x003C00FE File Offset: 0x003BE4FE
		private void OnAddNewItem(List<Item> items)
		{
		}

		// Token: 0x0600E613 RID: 58899 RVA: 0x003C0100 File Offset: 0x003BE500
		private void OnUpdateItem(List<Item> items)
		{
			this._OnOnlyUpdateItemList(null);
		}

		// Token: 0x0600E614 RID: 58900 RVA: 0x003C0109 File Offset: 0x003BE509
		private void OnRemoveItem(ItemData data)
		{
		}

		// Token: 0x0600E615 RID: 58901 RVA: 0x003C010C File Offset: 0x003BE50C
		protected sealed override void _OnOpenFrame()
		{
			this.m_bInited = true;
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			base.StartCoroutine(this._InitUIDelay());
		}

		// Token: 0x0600E616 RID: 58902 RVA: 0x003C01A0 File Offset: 0x003BE5A0
		private void _switch2Group(EPackageOpenMode mode)
		{
			switch (mode)
			{
			case EPackageOpenMode.Equip:
				this.m_togEquipGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Equip).toggle.isOn = true;
				break;
			case EPackageOpenMode.EquipWithDecompose:
				this.m_togEquipGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Equip).toggle.isOn = true;
				this._OpenQuickDecompose();
				break;
			case EPackageOpenMode.Material:
				this.m_togEquipGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Material).toggle.isOn = true;
				break;
			case EPackageOpenMode.Consumables:
				this.m_togEquipGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Consumable).toggle.isOn = true;
				break;
			case EPackageOpenMode.Fashion:
				this.m_togFashionGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Fashion).toggle.isOn = true;
				break;
			case EPackageOpenMode.Title:
				this.m_togTitleGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Title).toggle.isOn = true;
				break;
			case EPackageOpenMode.EquipWithQuickSell:
				this.m_togEquipGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Equip).toggle.isOn = true;
				this._OpenQuickSell();
				break;
			case EPackageOpenMode.Pet:
				this.m_togPetGroup.isOn = true;
				break;
			case EPackageOpenMode.FashionWithDecompose:
				this.m_togEquipGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Fashion).toggle.isOn = true;
				this._OpenFashionDecompose(null);
				break;
			case EPackageOpenMode.Inscription:
				this.m_togFashionGroup.isOn = true;
				this._GetItemTabInfo(EPackageType.Inscription).toggle.isOn = true;
				break;
			}
		}

		// Token: 0x0600E617 RID: 58903 RVA: 0x003C0344 File Offset: 0x003BE744
		private void _OnPackageSwitch2OneGroup(UIEvent ui)
		{
			try
			{
				EPackageOpenMode mode = (EPackageOpenMode)ui.Param1;
				this._switch2Group(mode);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[PackageNewFrame] _OnPackageSwitch2OneGroup {0} not in the EPackageOpenMode, with error {1}", new object[]
				{
					ui.Param1,
					ex.ToString()
				});
			}
		}

		// Token: 0x0600E618 RID: 58904 RVA: 0x003C03A4 File Offset: 0x003BE7A4
		protected sealed override void _OnCloseFrame()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			Singleton<ClientSystemManager>.instance.CloseFrame<PetPacketFrame>(null, false);
			this._ClearBaseInfo();
			this._ClearDetailInfos();
			this._ClearEquipSlot();
			this._ClearFashionSlot();
			this._ClearModel();
			this._ClearQuickSell();
			this._ClearQuickDecompose();
			this._ClearItemTab();
			this._ClearItemList();
			this._ClearActorShow();
			this._ClearTabs();
			this._ClearBottom();
			this._UnRegisterUIEvent();
			this.m_bInited = false;
			if (this.Tempitem != null)
			{
				this.Tempitem = null;
			}
			this.StopEnumerator();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionEquipDecomposeFrame>(null, false);
		}

		// Token: 0x0600E619 RID: 58905 RVA: 0x003C04A8 File Offset: 0x003BE8A8
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (null != this.m_AvatarRenderer)
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
				this.m_AvatarRenderer.m_LightRot = Global.Settings.avatarLightDir;
				if (this.m_AvatarRenderer.IsCurActionEnd())
				{
					this.m_AvatarRenderer.ChangeAction(this.m_ActionTable[this.m_PlayList[this.m_PlayIdx]], 1f, false);
					this.m_PlayIdx++;
					if (this.m_PlayIdx >= this.m_PlayList.Length)
					{
						this.m_PlayIdx = Random.Range(0, this.m_PlayList.Length);
					}
					this.m_PlayIdx %= this.m_PlayList.Length;
				}
			}
		}

		// Token: 0x0600E61A RID: 58906 RVA: 0x003C06B0 File Offset: 0x003BEAB0
		private IEnumerator _InitUIDelay()
		{
			this._InitTabs();
			this._InitItemTab();
			this._InitActorShow();
			this._InitPetTab();
			this._InitItemList();
			this._InitBottom();
			this._InitBgPanel();
			this._InitBaseInfo();
			this._InitDetailInfos();
			this._InitMainTabs();
			this._InitPackageFullTips();
			this._RegisterUIEvent();
			EPackageOpenMode mode = EPackageOpenMode.Equip;
			if (this.userData != null)
			{
				mode = (EPackageOpenMode)this.userData;
			}
			this._switch2Group(mode);
			yield return null;
			this._InitEquipSlot();
			this._InitFashionSlot();
			yield break;
		}

		// Token: 0x0600E61B RID: 58907 RVA: 0x003C06CC File Offset: 0x003BEACC
		private void _InitBgPanel()
		{
			Transform transform = this.frame.transform.Find(this.mBind.GetPrefabPath("BgRoot"));
			if (transform != null)
			{
				UIPrefabWrapper component = transform.GetComponent<UIPrefabWrapper>();
				if (component != null)
				{
					GameObject gameObject = component.LoadUIPrefab(transform);
					if (gameObject != null)
					{
						ComCommonBind component2 = gameObject.gameObject.GetComponent<ComCommonBind>();
						if (component2 != null)
						{
							this.mButtonClose = component2.GetCom<Button>("ButtonClose");
							this.mButtonClose.SafeAddOnClickListener(new UnityAction(this._OnClose));
						}
					}
				}
			}
		}

		// Token: 0x0600E61C RID: 58908 RVA: 0x003C0770 File Offset: 0x003BEB70
		private void _InitActorShow()
		{
			UIPrefabWrapper component = this.mPackageActorShow.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab(this.mPackageActorShow.transform);
				if (gameObject != null)
				{
					this.mPackageActorShow = gameObject;
					ComCommonBind component2 = this.mPackageActorShow.GetComponent<ComCommonBind>();
					if (component2 != null)
					{
						this.goArmyRoot = component2.GetGameObject("ArmyRoot");
						this.mButtonMagicCard = component2.GetCom<Button>("ButtonMagicCard");
						this.mButtonMagicCard.onClick.AddListener(new UnityAction(this.OnOpenEnchantmentsBookFrame));
						this.mButtonTitleBook = component2.GetCom<Button>("ButtonTitleBook");
						this.mButtonTitleBook.onClick.AddListener(new UnityAction(this.OnOpenTitleBookFrame));
						this.mButtonWeaponlease = component2.GetCom<Button>("ButtonWeaponLease");
						this.mButtonWeaponlease.onClick.AddListener(new UnityAction(this.OnOpeWeaponLeaseFrame));
						this.m_objMagicCard = component2.GetGameObject("MagicCard");
						this.m_objTitleBook = component2.GetGameObject("TitleBook");
						this.m_objWeaponLease = component2.GetGameObject("WeaponLease");
						this.m_imgSeasonSubLV = component2.GetCom<Image>("SeasonSubLV");
						this.m_imgSeasonMainLV = component2.GetCom<Image>("SeasonMainLV");
						this.m_labVipLevel = component2.GetCom<Text>("VipLevel");
						this.m_labPlayerLevel = component2.GetCom<Text>("PlayerLevel");
						this.m_labPlayerJob = component2.GetCom<Text>("PlayerJob");
						this.m_labPlayerName = component2.GetCom<Text>("PlayerName");
						this.m_objFashionsRoot = component2.GetGameObject("FashionRoot");
						this.m_objFashionTipRoot = component2.GetGameObject("FashionWeaponTipRoot");
						this.m_objFashionTipToggle = component2.GetCom<Toggle>("FashionWeaponTipToggle");
						if (this.m_objFashionTipToggle != null)
						{
							this.m_objFashionTipToggle.onValueChanged.RemoveAllListeners();
							this.m_objFashionTipToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnFashionTipToggleValueChanged));
						}
						this.m_objFashionWeaponShowButton = component2.GetCom<Button>("FashionWeaponShowButton");
						if (this.m_objFashionWeaponShowButton != null)
						{
							this.m_objFashionWeaponShowButton.onClick.RemoveAllListeners();
							this.m_objFashionWeaponShowButton.onClick.AddListener(new UnityAction(this.OnFashionWeaponShowButtonClicked));
						}
						this.m_objEquipRoot = component2.GetGameObject("EquipRoot");
						this.m_objActorRoot = component2.GetGameObject("ActorRoot");
						this.m_AvatarRenderer = component2.GetCom<GeAvatarRendererEx>("ModelRenderTexture");
						this.m_btnVipLevel = component2.GetCom<Button>("btnVipLevel");
						if (this.m_btnVipLevel != null)
						{
							this.m_btnVipLevel.onClick.RemoveAllListeners();
							this.m_btnVipLevel.onClick.AddListener(new UnityAction(this._onVipLevelButtonClick));
						}
						this.m_titleName = component2.GetCom<Text>("TitleName");
						this.mTitleImg = component2.GetCom<Image>("TitleImg");
						this.m_titleBtn = component2.GetCom<Button>("TitleBtn");
						if (this.m_titleBtn != null)
						{
							this.m_titleBtn.onClick.RemoveAllListeners();
							this.m_titleBtn.onClick.AddListener(new UnityAction(this._onTitleButtonClick));
						}
						this.emblemName = component2.GetCom<Image>("emblemName");
						this.mPackageSwitchWeapon = component2.GetGameObject("packageSwitchWeapon");
						this.switchWeaponBtn = component2.GetCom<Button>("SwitchWeaponBtn");
						this.switchWeaponBtn.SafeAddOnClickListener(new UnityAction(this.OnSwitchWeaponFrame));
						this.m_HonorSystemEntryController = component2.GetCom<PackageHonorSystemEntryController>("HonorSystemRoot");
						this.mHonorImg = component2.GetCom<Image>("HonorImg");
						this.mTitleRoot = component2.GetGameObject("TitleRoot");
					}
				}
			}
		}

		// Token: 0x0600E61D RID: 58909 RVA: 0x003C0B2F File Offset: 0x003BEF2F
		private void OnFashionTipToggleValueChanged(bool value)
		{
		}

		// Token: 0x0600E61E RID: 58910 RVA: 0x003C0B31 File Offset: 0x003BEF31
		private void OnIsShowFashionWeapon(UIEvent uievent)
		{
			if (this.m_objFashionTipToggle == null)
			{
				return;
			}
			if (!this.m_objFashionTipToggle.gameObject.activeSelf)
			{
				return;
			}
			this.m_objFashionTipToggle.isOn = DataManager<PlayerBaseData>.GetInstance().isShowFashionWeapon;
		}

		// Token: 0x0600E61F RID: 58911 RVA: 0x003C0B70 File Offset: 0x003BEF70
		private void OnTitleNameUpdate(UIEvent uievent)
		{
			this.ShowTitle();
		}

		// Token: 0x0600E620 RID: 58912 RVA: 0x003C0B78 File Offset: 0x003BEF78
		private void ShowTitle()
		{
			PlayerWearedTitleInfo wearedTitleInfo = DataManager<PlayerBaseData>.GetInstance().WearedTitleInfo;
			bool flag = DataManager<TitleDataManager>.GetInstance().IsHaveTitle();
			this.m_titleBtn.CustomActive(flag);
			if (!flag)
			{
				this.m_titleName.CustomActive(false);
				this.mTitleImg.CustomActive(false);
				this.mHonorImg.CustomActive(false);
				this.mTitleRoot.CustomActive(false);
				return;
			}
			if (wearedTitleInfo != null)
			{
				if (wearedTitleInfo.style == 1)
				{
					this.mTitleRoot.CustomActive(true);
					this.m_titleName.CustomActive(true);
					this.mTitleImg.CustomActive(false);
					this.mHonorImg.CustomActive(false);
					this.m_titleName.SafeSetText(wearedTitleInfo.name);
					LayoutRebuilder.ForceRebuildLayoutImmediate(this.mTitleRoot.GetComponent<RectTransform>());
				}
				else if (wearedTitleInfo.style == 2)
				{
					this.mTitleRoot.CustomActive(false);
					this.m_titleName.CustomActive(false);
					this.mTitleImg.CustomActive(true);
					if (this.mTitleImg != null)
					{
						NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>((int)wearedTitleInfo.titleId, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ETCImageLoader.LoadSprite(ref this.mTitleImg, tableItem.path, true);
						}
					}
				}
				else if (wearedTitleInfo.style == 3)
				{
					this.mTitleImg.CustomActive(false);
					this.m_titleName.SafeSetText(wearedTitleInfo.name);
					this.mTitleRoot.CustomActive(true);
					this.m_titleName.CustomActive(true);
					this.mHonorImg.CustomActive(true);
					if (this.mHonorImg != null)
					{
						NewTitleTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>((int)wearedTitleInfo.titleId, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							ETCImageLoader.LoadSprite(ref this.mHonorImg, tableItem2.path, true);
						}
					}
					LayoutRebuilder.ForceRebuildLayoutImmediate(this.mTitleRoot.GetComponent<RectTransform>());
				}
			}
		}

		// Token: 0x0600E621 RID: 58913 RVA: 0x003C0D62 File Offset: 0x003BF162
		private void OnPetPropertyReselect(UIEvent uiEvent)
		{
			this._RefreshDetailAttrs();
		}

		// Token: 0x0600E622 RID: 58914 RVA: 0x003C0D6A File Offset: 0x003BF16A
		private void OnCloseFashionEquipDecompose(UIEvent uiEvent)
		{
			this._CloseFashionDecompose();
		}

		// Token: 0x0600E623 RID: 58915 RVA: 0x003C0D74 File Offset: 0x003BF174
		private void OnFashionWeaponShowButtonClicked()
		{
			if (this.m_objFashionTipToggle == null)
			{
				return;
			}
			if (!this.m_objFashionTipToggle.gameObject.activeSelf)
			{
				return;
			}
			bool setFashionWeaponFlag = !this.m_objFashionTipToggle.isOn;
			DataManager<PackageDataManager>.GetInstance().SendShowFashionWeaponReq(setFashionWeaponFlag);
		}

		// Token: 0x0600E624 RID: 58916 RVA: 0x003C0DD0 File Offset: 0x003BF1D0
		private void _onVipLevelButtonClick()
		{
			if (this.frameMgr.IsFrameOpen<VipFrame>(null))
			{
				this.frameMgr.CloseFrame<VipFrame>(null, false);
			}
			this.frameMgr.OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("VIPLevel");
		}

		// Token: 0x0600E625 RID: 58917 RVA: 0x003C0E1D File Offset: 0x003BF21D
		private void _onTitleButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PersonalSettingFrame>(FrameLayer.Middle, 0, string.Empty);
		}

		// Token: 0x0600E626 RID: 58918 RVA: 0x003C0E38 File Offset: 0x003BF238
		private void _ClearActorShow()
		{
			this.goArmyRoot = null;
			this.mButtonMagicCard.SafeRemoveOnClickListener(new UnityAction(this.OnOpenEnchantmentsBookFrame));
			this.mButtonMagicCard = null;
			this.mButtonTitleBook.SafeRemoveOnClickListener(new UnityAction(this.OnOpenTitleBookFrame));
			this.mButtonTitleBook = null;
			this.mButtonWeaponlease.SafeRemoveOnClickListener(new UnityAction(this.OnOpeWeaponLeaseFrame));
			this.mButtonWeaponlease = null;
			this.m_objMagicCard = null;
			this.m_objTitleBook = null;
			this.m_objWeaponLease = null;
			this.m_imgSeasonSubLV = null;
			this.m_imgSeasonMainLV = null;
			this.m_labVipLevel = null;
			this.m_labPlayerLevel = null;
			this.m_labPlayerJob = null;
			this.m_labPlayerName = null;
			this.m_objFashionsRoot = null;
			this.m_objFashionTipRoot = null;
			if (this.m_objFashionTipToggle != null)
			{
				this.m_objFashionTipToggle.onValueChanged.RemoveAllListeners();
				this.m_objFashionTipToggle = null;
			}
			if (this.m_objFashionWeaponShowButton != null)
			{
				this.m_objFashionWeaponShowButton.onClick.RemoveAllListeners();
				this.m_objFashionWeaponShowButton = null;
			}
			this.m_objEquipRoot = null;
			this.m_objActorRoot = null;
			if (this.m_AvatarRenderer != null)
			{
				this.m_AvatarRenderer.ClearAvatar();
				this.m_AvatarRenderer = null;
			}
			this.m_btnVipLevel = null;
			this.m_titleName = null;
			if (this.m_titleBtn != null)
			{
				this.m_titleBtn.onClick.RemoveAllListeners();
				this.m_titleBtn = null;
			}
			this.m_HonorSystemEntryController = null;
			this.emblemName = null;
		}

		// Token: 0x0600E627 RID: 58919 RVA: 0x003C0FB8 File Offset: 0x003BF3B8
		private void _InitTabs()
		{
			Transform transform = this.frame.transform.Find(this.mBind.GetPrefabPath("TabsPlaceHolder"));
			if (transform != null)
			{
				UIPrefabWrapper component = transform.GetComponent<UIPrefabWrapper>();
				if (component != null)
				{
					GameObject gameObject = component.LoadUIPrefab(transform);
					if (gameObject != null)
					{
						ComCommonBind component2 = gameObject.gameObject.GetComponent<ComCommonBind>();
						if (component2 != null)
						{
							this.m_goFashionRePoint = component2.GetGameObject("FashionRedPoint");
							this.m_togEquipGroup = component2.GetCom<Toggle>("EquipGroup");
							this.m_togFashionGroup = component2.GetCom<Toggle>("FashionGroup");
							this.m_togTitleGroup = component2.GetCom<Toggle>("TitleGroup");
							this.m_togPetGroup = component2.GetCom<Toggle>("PetGroup");
							this.m_objPetGroupRoot = this.m_togPetGroup.gameObject;
						}
					}
				}
			}
		}

		// Token: 0x0600E628 RID: 58920 RVA: 0x003C1097 File Offset: 0x003BF497
		private void _ClearTabs()
		{
			this.m_goFashionRePoint = null;
			this.m_togEquipGroup = null;
			this.m_togFashionGroup = null;
			this.m_togTitleGroup = null;
			this.m_togPetGroup = null;
			this.m_objPetGroupRoot = null;
		}

		// Token: 0x0600E629 RID: 58921 RVA: 0x003C10C4 File Offset: 0x003BF4C4
		private void _InitBottom()
		{
			Transform transform = this.frame.transform.Find(this.mBind.GetPrefabPath("BottomPlaceHolder"));
			if (transform != null)
			{
				UIPrefabWrapper component = transform.GetComponent<UIPrefabWrapper>();
				if (component != null)
				{
					GameObject gameObject = component.LoadUIPrefab(transform);
					if (gameObject != null)
					{
						ComCommonBind component2 = gameObject.gameObject.GetComponent<ComCommonBind>();
						this.mPackagButtom = gameObject;
						if (component2 != null)
						{
							this.m_toggleDetailAttr = component2.GetCom<Toggle>("ToggleDetail");
							this.m_gridCount = component2.GetCom<Text>("GridCount");
							this.m_comBtnChapterPotionSet = component2.GetCom<ComButtonEnbale>("ChapterPotionSet");
							this.m_comBtnQuickDecompose = component2.GetCom<ComButtonEnbale>("QuickDecompose");
							this.m_comBtnQuickSell = component2.GetCom<ComButtonEnbale>("QuickSell");
							this.mButtonArrage = component2.GetCom<Button>("Arrange");
							this.mButtonArrage.SafeAddOnClickListener(new UnityAction(this._OnArrangePackage));
							this.mButtonLevelUp = component2.GetCom<Button>("LevelUp");
							this.mButtonLevelUp.SafeAddOnClickListener(new UnityAction(this._OnLevelupGridCountClicked));
							Button component3 = this.m_comBtnQuickSell.GetComponent<Button>();
							component3.SafeAddOnClickListener(new UnityAction(this._OnOpenQuickSellClicked));
							Button component4 = this.m_comBtnQuickDecompose.GetComponent<Button>();
							component4.SafeAddOnClickListener(new UnityAction(this._OnOpenQuickDecomposeClicked));
							Button component5 = this.m_comBtnChapterPotionSet.GetComponent<Button>();
							component5.SafeAddOnClickListener(new UnityAction(this._OnOpenChapterPotionSetClicked));
							this.mSkillDamageBtn = component2.GetCom<Button>("SkillDamageBtn");
							if (null != this.mSkillDamageBtn)
							{
								this.mSkillDamageBtn.onClick.AddListener(new UnityAction(this._onSkillDamageButtonClick));
							}
							this.btnFashionEquipDecompose = component2.GetCom<Button>("btnFashionEquipDecompose");
							this.btnFashionEquipDecompose.SafeSetOnClickListener(delegate
							{
								this._OpenFashionDecompose(null);
							});
							this.m_objFashionMerge = component2.GetCom<Button>("FashionMerge");
							this.m_objFashionMerge.SafeAddOnClickListener(new UnityAction(this._OnFashionMergeClicked));
							this.m_objInscriptionMerge = component2.GetCom<Button>("InscriptionMerge");
							this.m_objInscriptionMerge.SafeAddOnClickListener(new UnityAction(this._OnInscriptionMergeClicked));
						}
					}
				}
			}
		}

		// Token: 0x0600E62A RID: 58922 RVA: 0x003C1300 File Offset: 0x003BF700
		private void _ClearBottom()
		{
			if (this.m_comBtnQuickSell != null)
			{
				Button component = this.m_comBtnQuickSell.GetComponent<Button>();
				component.SafeRemoveOnClickListener(new UnityAction(this._OnOpenQuickSellClicked));
			}
			if (this.m_comBtnQuickDecompose != null)
			{
				Button component2 = this.m_comBtnQuickDecompose.GetComponent<Button>();
				component2.SafeRemoveOnClickListener(new UnityAction(this._OnOpenQuickDecomposeClicked));
			}
			if (this.m_comBtnChapterPotionSet != null)
			{
				Button component3 = this.m_comBtnChapterPotionSet.GetComponent<Button>();
				component3.SafeRemoveOnClickListener(new UnityAction(this._OnOpenChapterPotionSetClicked));
			}
			this.m_toggleDetailAttr = null;
			this.m_gridCount = null;
			this.m_comBtnChapterPotionSet = null;
			this.m_comBtnQuickDecompose = null;
			this.m_comBtnQuickSell = null;
			this.mButtonArrage.SafeRemoveOnClickListener(new UnityAction(this._OnArrangePackage));
			this.mButtonArrage = null;
			this.mButtonLevelUp.SafeRemoveOnClickListener(new UnityAction(this._OnLevelupGridCountClicked));
			this.mButtonLevelUp = null;
			if (null != this.mSkillDamageBtn)
			{
				this.mSkillDamageBtn.onClick.RemoveListener(new UnityAction(this._onSkillDamageButtonClick));
			}
		}

		// Token: 0x0600E62B RID: 58923 RVA: 0x003C1428 File Offset: 0x003BF828
		private void _setTabActive(PackageNewFrame.TabMode tabmode, EPackageType packageType)
		{
			int num = this._getEPackageTypeIndex(packageType);
			int upperBound = PackageNewFrame.sTabPackageTypeFlag.GetUpperBound(0);
			if (tabmode < PackageNewFrame.TabMode.TM_EQUIP || tabmode > (PackageNewFrame.TabMode)upperBound)
			{
				return;
			}
			upperBound = PackageNewFrame.sTabPackageTypeFlag.GetUpperBound(1);
			if (num < 0 || num > upperBound)
			{
				return;
			}
			PackageNewFrame.ItemTabInfo itemTabInfo = this._GetItemTabInfo(packageType);
			if (itemTabInfo != null && itemTabInfo.toggle != null)
			{
				itemTabInfo.toggle.CustomActive(PackageNewFrame.sTabPackageTypeFlag[(int)tabmode, num]);
				if (!PackageNewFrame.sTabPackageTypeFlag[(int)tabmode, num])
				{
					itemTabInfo.toggle.isOn = false;
				}
			}
		}

		// Token: 0x0600E62C RID: 58924 RVA: 0x003C14C8 File Offset: 0x003BF8C8
		private int _getEPackageTypeIndex(EPackageType type)
		{
			switch (type)
			{
			case EPackageType.Equip:
				return 0;
			case EPackageType.Material:
				return 1;
			case EPackageType.Consumable:
				return 2;
			default:
				if (type != EPackageType.Inscription)
				{
					return -1;
				}
				return 5;
			case EPackageType.Fashion:
				return 3;
			case EPackageType.Title:
				return 4;
			}
		}

		// Token: 0x0600E62D RID: 58925 RVA: 0x003C1524 File Offset: 0x003BF924
		private void _ChangeMode(PackageNewFrame.TabMode eTabMode)
		{
			if (!DataManager<ChijiDataManager>.GetInstance().CheckCurrentSystemIsClientSystemGameBattle())
			{
			}
			this.mPackageActorShow.CustomActive(eTabMode != PackageNewFrame.TabMode.TM_PET);
			this.mPackageItemListTabs.CustomActive(eTabMode != PackageNewFrame.TabMode.TM_PET);
			this.mPackagButtom.CustomActive(eTabMode != PackageNewFrame.TabMode.TM_PET);
			this.mPackageItemListView.CustomActive(eTabMode != PackageNewFrame.TabMode.TM_PET);
			if (eTabMode == PackageNewFrame.TabMode.TM_PET)
			{
				this._ClearModel();
				Singleton<ClientSystemManager>.instance.OpenFrame<PetPacketFrame>(this.mPetRoot, null, string.Empty);
			}
			else
			{
				this._InitModel();
				Singleton<ClientSystemManager>.instance.CloseFrame<PetPacketFrame>(null, false);
			}
			this.m_objTitleBook.CustomActive(false);
			this.m_objMagicCard.CustomActive(false);
			this.m_objWeaponLease.CustomActive(false);
			this.m_objEquipRoot.CustomActive(eTabMode == PackageNewFrame.TabMode.TM_EQUIP || eTabMode == PackageNewFrame.TabMode.TM_TITLE);
			this.m_objFashionsRoot.CustomActive(eTabMode == PackageNewFrame.TabMode.TM_FASHION);
			this.m_objShop.CustomActive(eTabMode == PackageNewFrame.TabMode.TM_FASHION);
			if (eTabMode == PackageNewFrame.TabMode.TM_FASHION)
			{
				this.m_objFashionTipRoot.CustomActive(true);
				this.m_objFashionTipToggle.isOn = DataManager<PlayerBaseData>.GetInstance().isShowFashionWeapon;
			}
			else
			{
				this.m_objFashionTipRoot.CustomActive(false);
			}
			DataManager<PackageDataManager>.GetInstance().ResetSendFashionWeaponReqFlag();
			this._setTabActive(eTabMode, EPackageType.Equip);
			this._setTabActive(eTabMode, EPackageType.Material);
			this._setTabActive(eTabMode, EPackageType.Consumable);
			this._setTabActive(eTabMode, EPackageType.Fashion);
			this._setTabActive(eTabMode, EPackageType.Title);
			this._setTabActive(eTabMode, EPackageType.Inscription);
			if (eTabMode != PackageNewFrame.TabMode.TM_EQUIP)
			{
				if (eTabMode != PackageNewFrame.TabMode.TM_FASHION)
				{
					if (eTabMode == PackageNewFrame.TabMode.TM_TITLE)
					{
						this._RefreshEquipSlot();
						if (this.m_bInited)
						{
							this._GetItemTabInfo(EPackageType.Title).toggle.isOn = true;
						}
					}
				}
				else
				{
					this._RefreshFashionSlot();
					if (this.m_bInited)
					{
						this._GetItemTabInfo(EPackageType.Fashion).toggle.isOn = true;
					}
				}
			}
			else
			{
				this._RefreshEquipSlot();
				if (this.m_bInited)
				{
					this._GetItemTabInfo(EPackageType.Equip).toggle.isOn = true;
				}
			}
		}

		// Token: 0x0600E62E RID: 58926 RVA: 0x003C1728 File Offset: 0x003BFB28
		private void _InitMainTabs()
		{
			this.m_togEquipGroup.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._ChangeMode(PackageNewFrame.TabMode.TM_EQUIP);
				}
			});
			this.m_togFashionGroup.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._ChangeMode(PackageNewFrame.TabMode.TM_FASHION);
				}
			});
			this.m_togTitleGroup.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._ChangeMode(PackageNewFrame.TabMode.TM_TITLE);
				}
			});
			this.m_togPetGroup.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._ChangeMode(PackageNewFrame.TabMode.TM_PET);
				}
			});
		}

		// Token: 0x0600E62F RID: 58927 RVA: 0x003C17A5 File Offset: 0x003BFBA5
		private void _InitPetTab()
		{
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Pet))
			{
				this.m_objPetGroupRoot.CustomActive(true);
			}
			else
			{
				this.m_objPetGroupRoot.CustomActive(false);
			}
		}

		// Token: 0x0600E630 RID: 58928 RVA: 0x003C17D0 File Offset: 0x003BFBD0
		private void _InitEquipSlot()
		{
			this.m_equipList.Clear();
			ComCommonBind component = this.mPackageActorShow.GetComponent<ComCommonBind>();
			if (component != null)
			{
				GameObject gameObject = component.GetGameObject("bgItemRoot14");
				gameObject.CustomActive(DataManager<PlayerBaseData>.GetInstance().JobTableID == 15);
			}
			for (int i = 0; i < this.mConfigs.Length; i++)
			{
				bool flag = false;
				if (DataManager<PlayerBaseData>.GetInstance().JobTableID != 15 && i == 14)
				{
					flag = true;
				}
				GameObject goParent = Utility.FindGameObject(this.frame, string.Format(this.mConfigs[i].root, i), true);
				ComItem comItem = base.CreateComItem(goParent);
				comItem.SetupSlot(ComItem.ESlotType.Opened, this._GetEquipSlotDesc(i), null, string.Empty);
				if (flag)
				{
					comItem.Setup(null, null);
					comItem.gameObject.CustomActive(false);
				}
				if (i == 17)
				{
					comItem.SetupSlot(ComItem.ESlotType.Locked, string.Empty, null, string.Empty);
				}
				this.m_equipList.Add(comItem);
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int j = 0; j < itemsByPackageType.Count; j++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
				if (item != null)
				{
					Type type = item.EquipWearSlotType.GetType();
					string name = Enum.GetName(type, item.EquipWearSlotType);
					FieldInfo field = type.GetField(name);
					object[] customAttributes = field.GetCustomAttributes(typeof(MapIndex), false);
					if (customAttributes.Length > 0)
					{
						int num = (customAttributes[0] as MapIndex).Index;
						if (num == 98)
						{
							num = 15;
						}
						else if (num == 99)
						{
							num = 16;
						}
						else if (num == 100)
						{
							num = 17;
						}
						if (num >= 0 && num < this.m_equipList.Count)
						{
							this.m_equipList[num].Setup(item, new ComItem.OnItemClicked(this._OnWearedItemClicked));
						}
					}
				}
			}
			this.m_bEquipSoltInited = true;
		}

		// Token: 0x0600E631 RID: 58929 RVA: 0x003C19FE File Offset: 0x003BFDFE
		private void _ClearEquipSlot()
		{
			this.m_bEquipSoltInited = false;
			this.m_equipList.Clear();
		}

		// Token: 0x0600E632 RID: 58930 RVA: 0x003C1A14 File Offset: 0x003BFE14
		private void _RefreshEquipSlot()
		{
			if (!this.m_bEquipSoltInited)
			{
				return;
			}
			if (!this.m_objEquipRoot.activeSelf)
			{
				return;
			}
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < this.m_equipList.Count; i++)
			{
				if (this.m_equipList[i].ItemData != null)
				{
					list.Add(this.m_equipList[i].ItemData.GUID);
				}
				else
				{
					list.Add(0UL);
				}
				this.m_equipList[i].Setup(null, null);
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int j = 0; j < itemsByPackageType.Count; j++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
				if (item != null)
				{
					Type type = item.EquipWearSlotType.GetType();
					string name = Enum.GetName(type, item.EquipWearSlotType);
					FieldInfo field = type.GetField(name);
					object[] customAttributes = field.GetCustomAttributes(typeof(MapIndex), false);
					if (customAttributes.Length > 0)
					{
						int num = (customAttributes[0] as MapIndex).Index;
						if (num == 98)
						{
							num = 15;
						}
						else if (num == 99)
						{
							num = 16;
						}
						else if (num == 100)
						{
							num = 17;
						}
						if (num >= 0 && num < this.m_equipList.Count)
						{
							this.m_equipList[num].Setup(item, new ComItem.OnItemClicked(this._OnWearedItemClicked));
							if (list[num] == 0UL && list[num] != this.m_equipList[num].ItemData.GUID)
							{
								GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_Equip", true, 0U);
								gameObject.transform.SetParent(this.m_equipList[num].transform, false);
								GameObject root = Utility.FindGameObject(gameObject, "EffUI_wupinzhuangbei", true);
								Utility.FindGameObject(root, "fang", true).GetComponent<ParticleSystem>().Play();
							}
						}
					}
				}
			}
		}

		// Token: 0x0600E633 RID: 58931 RVA: 0x003C1C48 File Offset: 0x003C0048
		private string _GetEquipSlotDesc(int index)
		{
			Type typeFromHandle = typeof(EEquipWearSlotType);
			string[] names = Enum.GetNames(typeFromHandle);
			for (int i = 0; i < names.Length; i++)
			{
				FieldInfo field = typeFromHandle.GetField(names[i]);
				object[] customAttributes = field.GetCustomAttributes(typeof(MapIndex), false);
				if (customAttributes.Length > 0)
				{
					int num = (customAttributes[0] as MapIndex).Index;
					if (num == 98)
					{
						num = 15;
					}
					else if (num == 99)
					{
						num = 16;
					}
					else if (num == 100)
					{
						num = 17;
					}
					if (num == index)
					{
						object[] customAttributes2 = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
						if (customAttributes2.Length > 0)
						{
							return TR.Value((customAttributes2[0] as DescriptionAttribute).Description);
						}
						break;
					}
				}
			}
			return string.Empty;
		}

		// Token: 0x0600E634 RID: 58932 RVA: 0x003C1D28 File Offset: 0x003C0128
		private void _InitFashionSlot()
		{
			this.m_fashionList.Clear();
			for (int i = 0; i < 5; i++)
			{
				GameObject goParent = Utility.FindGameObject(this.frame, string.Format("Content/ActorShow/Fashions/Left/ItemRoot{0}", i), true);
				ComItem comItem = base.CreateComItem(goParent);
				comItem.SetupSlot(ComItem.ESlotType.Opened, this._GetFashionNewSlotDesc(i), null, string.Empty);
				this.m_fashionList.Add(comItem);
			}
			for (int j = 5; j < 8; j++)
			{
				GameObject goParent2 = Utility.FindGameObject(this.frame, string.Format("Content/ActorShow/Fashions/Right/ItemRoot{0}", j), true);
				ComItem comItem2 = base.CreateComItem(goParent2);
				comItem2.SetupSlot(ComItem.ESlotType.Opened, this._GetFashionNewSlotDesc(j), null, string.Empty);
				this.m_fashionList.Add(comItem2);
			}
			this.UpdateFashionSlot(false, null);
			this.m_bFashionSoltInited = true;
		}

		// Token: 0x0600E635 RID: 58933 RVA: 0x003C1E04 File Offset: 0x003C0204
		private void UpdateFashionSlot(bool isRefresh = false, List<ulong> oldGuids = null)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					Type typeFromHandle = typeof(EFashionWearNewSlotType);
					EFashionWearNewSlotType fashionWearNewSlotTypeByItemFashionWearSlotType = DataManager<PackageDataManager>.GetInstance().GetFashionWearNewSlotTypeByItemFashionWearSlotType(item.FashionWearSlotType);
					string name = Enum.GetName(typeFromHandle, fashionWearNewSlotTypeByItemFashionWearSlotType);
					FieldInfo field = typeFromHandle.GetField(name);
					object[] customAttributes = field.GetCustomAttributes(typeof(MapIndex), false);
					if (customAttributes.Length > 0)
					{
						int index = (customAttributes[0] as MapIndex).Index;
						if (index >= 0 && index < this.m_fashionList.Count)
						{
							this.m_fashionList[index].Setup(item, new ComItem.OnItemClicked(this._OnWearedItemClicked));
							if (isRefresh && oldGuids != null && oldGuids[index] == 0UL && oldGuids[index] != this.m_fashionList[index].ItemData.GUID)
							{
								GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_Equip", true, 0U);
								gameObject.transform.SetParent(this.m_fashionList[index].transform, false);
								GameObject root = Utility.FindGameObject(gameObject, "EffUI_wupinzhuangbei", true);
								Utility.FindGameObject(root, "fang", true).GetComponent<ParticleSystem>().Play();
							}
						}
					}
				}
			}
		}

		// Token: 0x0600E636 RID: 58934 RVA: 0x003C1F80 File Offset: 0x003C0380
		private void _ClearFashionSlot()
		{
			this.m_bFashionSoltInited = false;
			this.m_fashionList.Clear();
		}

		// Token: 0x0600E637 RID: 58935 RVA: 0x003C1F94 File Offset: 0x003C0394
		private void _RefreshFashionSlot()
		{
			if (!this.m_bFashionSoltInited)
			{
				return;
			}
			if (!this.m_objFashionsRoot.activeSelf)
			{
				return;
			}
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < this.m_fashionList.Count; i++)
			{
				if (this.m_fashionList[i].ItemData != null)
				{
					list.Add(this.m_fashionList[i].ItemData.GUID);
				}
				else
				{
					list.Add(0UL);
				}
				this.m_fashionList[i].Setup(null, null);
			}
			this.UpdateFashionSlot(true, list);
		}

		// Token: 0x0600E638 RID: 58936 RVA: 0x003C203C File Offset: 0x003C043C
		private string _GetFashionNewSlotDesc(int index)
		{
			Type typeFromHandle = typeof(EFashionWearNewSlotType);
			string[] names = Enum.GetNames(typeFromHandle);
			int i = 0;
			while (i < names.Length)
			{
				FieldInfo field = typeFromHandle.GetField(names[i]);
				object[] customAttributes = field.GetCustomAttributes(typeof(MapIndex), false);
				if (customAttributes.Length > 0 && (customAttributes[0] as MapIndex).Index == index)
				{
					object[] customAttributes2 = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
					if (customAttributes2.Length > 0)
					{
						return TR.Value((customAttributes2[0] as DescriptionAttribute).Description);
					}
					break;
				}
				else
				{
					i++;
				}
			}
			return string.Empty;
		}

		// Token: 0x0600E639 RID: 58937 RVA: 0x003C20E8 File Offset: 0x003C04E8
		private string _GetFashionSlotDesc(int index)
		{
			Type typeFromHandle = typeof(EFashionWearSlotType);
			string[] names = Enum.GetNames(typeFromHandle);
			int i = 0;
			while (i < names.Length)
			{
				FieldInfo field = typeFromHandle.GetField(names[i]);
				object[] customAttributes = field.GetCustomAttributes(typeof(MapIndex), false);
				if (customAttributes.Length > 0 && (customAttributes[0] as MapIndex).Index == index)
				{
					object[] customAttributes2 = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
					if (customAttributes2.Length > 0)
					{
						return TR.Value((customAttributes2[0] as DescriptionAttribute).Description);
					}
					break;
				}
				else
				{
					i++;
				}
			}
			return string.Empty;
		}

		// Token: 0x0600E63A RID: 58938 RVA: 0x003C2194 File Offset: 0x003C0594
		private void _InitBaseInfo()
		{
			this.m_objTitleBook.SetActive(false);
			this.m_objMagicCard.SetActive(false);
			this.switchWeaponBtn.CustomActive(this.SwitchWeaponOpen() && this.m_currentItemType != EPackageType.Fashion && this.m_currentItemType != EPackageType.Inscription);
			this._RefreshBaseInfo();
		}

		// Token: 0x0600E63B RID: 58939 RVA: 0x003C21F1 File Offset: 0x003C05F1
		private bool SwitchWeaponOpen()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.SideWeapon);
		}

		// Token: 0x0600E63C RID: 58940 RVA: 0x003C21FC File Offset: 0x003C05FC
		private void _RefreshBaseInfo()
		{
			this.m_labPlayerName.text = DataManager<PlayerBaseData>.GetInstance().Name;
			this.m_labPlayerLevel.text = string.Format("Lv.{0}", DataManager<PlayerBaseData>.GetInstance().Level);
			this.ShowTitle();
			this.m_labVipLevel.text = TR.Value("common_vip_level", DataManager<PlayerBaseData>.GetInstance().VipLevel);
			this.m_labVipLevel.transform.parent.gameObject.CustomActive(true);
			this.emblemName.SafeSetImage(DataManager<GuildDataManager>.GetInstance().GetEmblemNamePath(DataManager<GuildDataManager>.GetInstance().GetEmblemLv()), false);
			if (this.emblemName != null)
			{
				this.emblemName.SetNativeSize();
			}
			this.emblemName.CustomActive(DataManager<GuildDataManager>.GetInstance().GetEmblemLv() > 0);
			this.emblemName.CustomActive(false);
			int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
			if (DataManager<SeasonDataManager>.GetInstance().IsLevelValid(seasonLevel))
			{
				this.m_imgSeasonMainLV.gameObject.SetActive(true);
				ETCImageLoader.LoadSprite(ref this.m_imgSeasonMainLV, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon(seasonLevel), true);
				ETCImageLoader.LoadSprite(ref this.m_imgSeasonSubLV, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon(seasonLevel), true);
				this.m_imgSeasonSubLV.SetNativeSize();
			}
			else
			{
				this.m_imgSeasonMainLV.gameObject.SetActive(false);
				this.m_imgSeasonSubLV.gameObject.SetActive(false);
			}
			string text = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				text = tableItem.Name;
			}
			this.m_labPlayerJob.text = text;
		}

		// Token: 0x0600E63D RID: 58941 RVA: 0x003C23B3 File Offset: 0x003C07B3
		private void _ClearBaseInfo()
		{
		}

		// Token: 0x0600E63E RID: 58942 RVA: 0x003C23B8 File Offset: 0x003C07B8
		private void _InitModel()
		{
			if (this.m_AvatarRenderer == null)
			{
				GameObject gameObject = Utility.FindGameObject(this.frame, "Content/ActorShow/Model/ModelRenderTexture", true);
				if (null != gameObject)
				{
					this.m_AvatarRenderer = gameObject.gameObject.GetComponent<GeAvatarRendererEx>();
				}
			}
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError("职业ID找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
			}
			else
			{
				ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogError("职业ID Mode表 找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
				}
				else
				{
					this.m_AvatarRenderer.LoadAvatar(tableItem2.ModelPath, -1);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.m_AvatarRenderer, null, false);
					this.m_AvatarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/EffectUI/Eff_chuangjue/Prefab/EffUI_chuangjue_beibao", "[actor]Orign", false, true, false, 0f);
					this.m_AvatarRenderer.ChangeAction(this.m_ActionTable[0], 1f, true);
				}
			}
		}

		// Token: 0x0600E63F RID: 58943 RVA: 0x003C250E File Offset: 0x003C090E
		private void _OnAvatarChagned(UIEvent e)
		{
			this._RefreshModel();
		}

		// Token: 0x0600E640 RID: 58944 RVA: 0x003C2518 File Offset: 0x003C0918
		private void _RefreshModel()
		{
			if (this.m_AvatarRenderer != null)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.m_AvatarRenderer, null, true);
				this.m_AvatarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/EffectUI/Eff_chuangjue/Prefab/EffUI_chuangjue_beibao", "[actor]Orign", false, true, false, 0f);
			}
		}

		// Token: 0x0600E641 RID: 58945 RVA: 0x003C256B File Offset: 0x003C096B
		private void _ClearModel()
		{
			this.m_PlayIdx = 0;
		}

		// Token: 0x0600E642 RID: 58946 RVA: 0x003C2574 File Offset: 0x003C0974
		public static void SetPersonalInfo(DisplayAttribute attribute, GameObject objLeftRoot, GameObject objRightRoot)
		{
			for (int i = 0; i < 41; i++)
			{
				AttributeType attributeType = (AttributeType)i;
				if (attributeType != AttributeType.abnormalResist)
				{
					string attributeString = Global.GetAttributeString((AttributeType)i);
					PackageNewFrame._ShowAttrValue(attributeString, attributeType, attribute, objLeftRoot, objRightRoot);
				}
			}
			string[] array = new string[]
			{
				"lightAttack",
				"fireAttack",
				"iceAttack",
				"darkAttack",
				"lightDefence",
				"fireDefence",
				"iceDefence",
				"darkDefence",
				"resistMagic"
			};
			for (int j = 0; j < array.Length; j++)
			{
				PackageNewFrame._ShowAttrValue(array[j], AttributeType.COUNT, attribute, objLeftRoot, objRightRoot);
			}
		}

		// Token: 0x0600E643 RID: 58947 RVA: 0x003C262C File Offset: 0x003C0A2C
		private static void _ShowAttrValue(string childName, AttributeType at, DisplayAttribute attribute, GameObject objLeftRoot, GameObject objRightRoot)
		{
			GameObject gameObject = Utility.FindGameObject(objLeftRoot, childName, false);
			if (gameObject == null)
			{
				gameObject = Utility.FindGameObject(objRightRoot, childName, false);
				if (gameObject == null)
				{
					return;
				}
			}
			GameObject gameObject2 = Utility.FindGameObject(gameObject, "Value", true);
			if (gameObject2 == null)
			{
				return;
			}
			FieldInfo field = attribute.GetType().GetField(childName);
			if (childName == "lightAttack")
			{
			}
			float num = 0f;
			if (field != null)
			{
				num = (float)field.GetValue(attribute);
			}
			Text component = gameObject2.GetComponent<Text>();
			component.color = Color.white;
			if (attribute.attachValue.ContainsKey(childName))
			{
				if (attribute.attachValue[childName] > 0)
				{
					component.color = Color.green;
				}
				else if (attribute.attachValue[childName] < 0)
				{
					component.color = Color.red;
				}
			}
			if (childName == "resistMagic")
			{
				int mainPlayerResistAddByBuff = BeUtility.GetMainPlayerResistAddByBuff();
				if (mainPlayerResistAddByBuff > 0)
				{
					component.color = Color.green;
				}
				else
				{
					component.color = Color.white;
				}
			}
			if (at == AttributeType.attackSpeed || at == AttributeType.moveSpeed || at == AttributeType.spellSpeed || at == AttributeType.ciriticalAttack || at == AttributeType.ciriticalMagicAttack || at == AttributeType.dex || at == AttributeType.dodge)
			{
				string text = "{0:F1}%";
				if (num > 0f)
				{
					text = "+" + text;
				}
				component.text = string.Format(text, num);
			}
			else
			{
				component.text = string.Format("{0}", num);
			}
		}

		// Token: 0x0600E644 RID: 58948 RVA: 0x003C27E8 File Offset: 0x003C0BE8
		private void _InitDetailInfos()
		{
			this.m_toggleDetailAttr.onValueChanged.RemoveAllListeners();
			this.m_toggleDetailAttr.onValueChanged.AddListener(delegate(bool var)
			{
				if (!this.m_bDetailInfosUIInited)
				{
					this._LoadDetailInfoUI();
					this._RefreshDetailAttrs();
					this._RefreshDetailPlayerInfo(false);
					this._RefreshWeaponAttackAttributeTypeInfo();
					this._RefreshEquipScoreNumber();
				}
				if (var)
				{
					this.m_detailAttrDotween.DOPlayForward();
				}
				else
				{
					this.m_detailAttrDotween.DOPlayBackwards();
				}
			});
		}

		// Token: 0x0600E645 RID: 58949 RVA: 0x003C2818 File Offset: 0x003C0C18
		private void _LoadDetailInfoUI()
		{
			if (!this.m_bDetailInfosUIInited)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Package/PersonalInformation", true, 0U);
				GameObject gameObject2 = Utility.FindGameObject("Content/ActorShow/Viewport", true);
				gameObject.transform.SetParent(gameObject2.transform, false);
				this.m_labPlayerNameDetail = Utility.GetComponetInChild<Text>(gameObject, "Base/Name");
				this.m_labPlayerJobDetail = Utility.GetComponetInChild<Text>(gameObject, "Base/Job");
				this.m_labPlayerLevelDetail = Utility.GetComponetInChild<Text>(gameObject, "Base/Level");
				this.m_labVipLevelDetail = Utility.GetComponetInChild<Text>(gameObject, "Base/VipLevel/Text");
				this.m_imgSeasonMainLVDetail = Utility.GetComponetInChild<Image>(gameObject, "Base/PkGroup/Main");
				this.m_imgSeasonSubLVDetail = Utility.GetComponetInChild<Image>(gameObject, "Base/PkGroup/Main/Sub");
				this.m_comExpBar = Utility.GetComponetInChild<ComExpBar>(gameObject, "Base/ExpBar");
				this.m_detailAttrDotween = gameObject.GetComponent<DOTweenAnimation>();
				this.m_objAttrLeft = Utility.FindGameObject(gameObject, "Attr/Scroll View/Viewport/Content/Left", true);
				this.m_objAttrRight = Utility.FindGameObject(gameObject, "Attr/Scroll View/Viewport/Content/Right", true);
				this.m_OpenRoleAttrTipsBtn = Utility.GetComponetInChild<Button>(gameObject, "Attr");
				this.m_WeaponAttackAttributeTypeText = Utility.GetComponetInChild<Text>(gameObject, "Attr/Scroll View/Viewport/Content/Left/WeaponAttackAttributeType/Value");
				this.m_EquipScoreTxt = Utility.GetComponetInChild<Text>(gameObject, "Attr/Scroll View/Viewport/Content/Left/EquipScore/Value");
				if (this.m_OpenRoleAttrTipsBtn != null)
				{
					this.m_OpenRoleAttrTipsBtn.onClick.RemoveListener(new UnityAction(this.OnOpenActorAttTipShow));
					this.m_OpenRoleAttrTipsBtn.onClick.AddListener(new UnityAction(this.OnOpenActorAttTipShow));
				}
				if (this.m_comExpBar != null)
				{
					this.m_comExpBar.TextFormat = delegate(ulong exp)
					{
						KeyValuePair<ulong, ulong> curRoleExp = Singleton<TableManager>.instance.GetCurRoleExp(exp);
						if (curRoleExp.Value == 0UL)
						{
							return "max";
						}
						double num = curRoleExp.Key / curRoleExp.Value;
						return string.Format("{0}/{1}", curRoleExp.Key, curRoleExp.Value);
					};
				}
				this.m_bDetailInfosUIInited = true;
			}
		}

		// Token: 0x0600E646 RID: 58950 RVA: 0x003C29C4 File Offset: 0x003C0DC4
		private void _RefreshDetailPlayerInfo(bool a_bPlayExpEffect)
		{
			if (this.m_bDetailInfosUIInited)
			{
				this.m_labPlayerNameDetail.text = DataManager<PlayerBaseData>.GetInstance().Name;
				this.m_labPlayerLevelDetail.text = string.Format("Lv.{0}", DataManager<PlayerBaseData>.GetInstance().Level);
				this.m_labVipLevelDetail.text = TR.Value("common_vip_level", DataManager<PlayerBaseData>.GetInstance().VipLevel);
				int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
				if (DataManager<SeasonDataManager>.GetInstance().IsLevelValid(seasonLevel))
				{
					this.m_imgSeasonMainLVDetail.gameObject.SetActive(true);
					ETCImageLoader.LoadSprite(ref this.m_imgSeasonMainLVDetail, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon(seasonLevel), true);
					ETCImageLoader.LoadSprite(ref this.m_imgSeasonSubLVDetail, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon(seasonLevel), true);
					this.m_imgSeasonSubLVDetail.SetNativeSize();
				}
				else
				{
					this.m_imgSeasonMainLVDetail.gameObject.SetActive(false);
					this.m_imgSeasonSubLVDetail.gameObject.SetActive(false);
				}
				string text = string.Empty;
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					text = tableItem.Name;
				}
				this.m_labPlayerJobDetail.text = text;
				this.m_comExpBar.SetExp(DataManager<PlayerBaseData>.GetInstance().Exp, !a_bPlayExpEffect, (ulong exp) => Singleton<TableManager>.instance.GetCurRoleExp(exp));
			}
		}

		// Token: 0x0600E647 RID: 58951 RVA: 0x003C2B3C File Offset: 0x003C0F3C
		private void _RefreshWeaponAttackAttributeTypeInfo()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			if (itemsByPackageType == null)
			{
				return;
			}
			ItemData itemData = null;
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.EQUIP)
					{
						if (item.SubType == 1)
						{
							itemData = item;
						}
					}
				}
			}
			if (itemData == null)
			{
				if (this.m_WeaponAttackAttributeTypeText != null)
				{
					this.m_WeaponAttackAttributeTypeText.text = "无";
				}
				return;
			}
			string weaponAttackAttributeDescs = itemData.GetWeaponAttackAttributeDescs();
			if (this.m_WeaponAttackAttributeTypeText != null)
			{
				this.m_WeaponAttackAttributeTypeText.text = weaponAttackAttributeDescs;
			}
		}

		// Token: 0x0600E648 RID: 58952 RVA: 0x003C2C04 File Offset: 0x003C1004
		private void _RefreshEquipScoreNumber()
		{
			if (this.m_EquipScoreTxt != null)
			{
				this.m_EquipScoreTxt.text = DataManager<PlayerBaseData>.GetInstance().TotalEquipScore.ToString();
			}
		}

		// Token: 0x0600E649 RID: 58953 RVA: 0x003C2C48 File Offset: 0x003C1048
		private void _RefreshDetailAttrs()
		{
			if (this.m_bDetailInfosUIInited)
			{
				DisplayAttribute displayAttribute = null;
				ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle != null)
				{
					BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
					if (mainPlayer != null && mainPlayer.playerActor != null)
					{
						BeEntityData entityData = mainPlayer.playerActor.GetEntityData();
						displayAttribute = BeEntityData.GetActorAttributeForDisplay(entityData);
					}
				}
				else
				{
					displayAttribute = BeUtility.GetMainPlayerActorAttribute(false, false);
				}
				if (displayAttribute != null)
				{
					PackageNewFrame.SetPersonalInfo(displayAttribute, this.m_objAttrLeft, this.m_objAttrRight);
				}
			}
		}

		// Token: 0x0600E64A RID: 58954 RVA: 0x003C2CD4 File Offset: 0x003C10D4
		private void _ClearDetailInfos()
		{
			this.m_bDetailInfosUIInited = false;
			this.m_labPlayerNameDetail = null;
			this.m_labPlayerJobDetail = null;
			this.m_labPlayerLevelDetail = null;
			this.m_labVipLevelDetail = null;
			this.m_imgSeasonMainLVDetail = null;
			this.m_imgSeasonSubLVDetail = null;
			this.m_comExpBar = null;
			this.m_detailAttrDotween = null;
			this.m_objAttrLeft = null;
			this.m_objAttrRight = null;
			this.m_WeaponAttackAttributeTypeText = null;
			if (this.m_OpenRoleAttrTipsBtn != null)
			{
				this.m_OpenRoleAttrTipsBtn.onClick.RemoveListener(new UnityAction(this.OnOpenActorAttTipShow));
				this.m_OpenRoleAttrTipsBtn = null;
			}
		}

		// Token: 0x0600E64B RID: 58955 RVA: 0x003C2D69 File Offset: 0x003C1169
		private void _ClearQuickSell()
		{
			this._CloseQuickSell();
			this.m_bQuickSellUIInited = false;
			this.m_objQuickSellMask = null;
			this.m_objQuickSellRoot = null;
		}

		// Token: 0x0600E64C RID: 58956 RVA: 0x003C2D88 File Offset: 0x003C1188
		private void _CloseQuickSell()
		{
			if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.QuickSell)
			{
				this.m_eShowMode = PackageNewFrame.EItemsShowMode.Normal;
				this._RefreshItemList(false);
				this._ClearSelectState();
				this.m_objQuickSellRoot.SetActive(false);
				for (int i = 0; i < this.m_QuickSellToggles.Length; i++)
				{
					this.m_QuickSellToggles[i].isOn = false;
				}
			}
		}

		// Token: 0x0600E64D RID: 58957 RVA: 0x003C2DE8 File Offset: 0x003C11E8
		private void _QuickSellEquips(Action a_okCallback, params ItemData[] a_arrItems)
		{
			if (a_arrItems == null || a_arrItems.Length == 0)
			{
				return;
			}
			ulong[] arrGuids = new ulong[a_arrItems.Length];
			for (int i = 0; i < a_arrItems.Length; i++)
			{
				arrGuids[i] = a_arrItems[i].GUID;
			}
			string msgContent = string.Empty;
			if (a_arrItems.Length == 1)
			{
				ItemData itemData = a_arrItems[0];
				if (itemData.EquipType == EEquipType.ET_REDMARK)
				{
					msgContent = TR.Value("growth_equip_desc", "确定要出售吗");
				}
				else if (itemData.StrengthenLevel >= 5)
				{
					msgContent = TR.Value("equip_single_quicksell_ask_01", itemData.GetColorName("[{0}]", true), itemData.StrengthenLevel);
				}
				else if (itemData.Quality > ItemTable.eColor.BLUE)
				{
					msgContent = TR.Value("equip_single_quicksell_ask_03", itemData.GetQualityDesc(), itemData.GetColorName("[{0}]", true));
				}
				else
				{
					msgContent = TR.Value("equip_single_quicksell_ask_02", itemData.GetColorName("[{0}]", true));
				}
			}
			else
			{
				List<ItemData> list = new List<ItemData>();
				bool flag = false;
				foreach (ItemData itemData2 in a_arrItems)
				{
					if (itemData2.EquipType == EEquipType.ET_REDMARK)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					msgContent = TR.Value("selected_equipment_has_red_equip_desc", "是否确认出售？");
				}
				else
				{
					foreach (ItemData itemData3 in a_arrItems)
					{
						if (itemData3.StrengthenLevel >= 5 || itemData3.Quality > ItemTable.eColor.BLUE)
						{
							list.Add(itemData3);
						}
					}
					int num = a_arrItems.Length - list.Count;
					if (list.Count > 0)
					{
						list.Sort(delegate(ItemData var1, ItemData var2)
						{
							ulong basePriceByItemData = DataManager<AuctionDataManager>.GetInstance().GetBasePriceByItemData(var1);
							ulong basePriceByItemData2 = DataManager<AuctionDataManager>.GetInstance().GetBasePriceByItemData(var2);
							if (basePriceByItemData > basePriceByItemData2)
							{
								return -1;
							}
							if (basePriceByItemData < basePriceByItemData2)
							{
								return 1;
							}
							return var2.StrengthenLevel - var1.StrengthenLevel;
						});
						string text = string.Empty;
						for (int l = 0; l < list.Count; l++)
						{
							if (l > 5)
							{
								break;
							}
							text += list[l].GetColorName(" [{0}]", true);
						}
						text += " ";
						if (list.Count <= 5)
						{
							if (num > 0)
							{
								msgContent = TR.Value("equip_multi_quicksell_ask_01", text, list.Count, num);
							}
							else
							{
								msgContent = TR.Value("equip_multi_quicksell_ask_02", text, list.Count);
							}
						}
						else if (num > 0)
						{
							msgContent = TR.Value("equip_multi_quicksell_ask_03", text, list.Count, num);
						}
						else
						{
							msgContent = TR.Value("equip_multi_quicksell_ask_04", text, list.Count);
						}
					}
					else
					{
						msgContent = TR.Value("equip_multi_quicksell_ask_05", num);
					}
				}
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<ItemDataManager>.GetInstance().SendSellItem(arrGuids);
				if (a_okCallback != null)
				{
					a_okCallback();
				}
			}, null, 0f, false);
		}

		// Token: 0x0600E64E RID: 58958 RVA: 0x003C3100 File Offset: 0x003C1500
		private void _OnQuickSellClicked()
		{
			List<ItemData> selectItems = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && item.IsSelected)
				{
					selectItems.Add(item);
				}
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(delegate
			{
				for (int j = 0; j < selectItems.Count; j++)
				{
					ItemData itemData = selectItems[j];
					if (itemData != null && itemData.Quality >= ItemTable.eColor.PURPLE)
					{
						return true;
					}
				}
				return false;
			}, null))
			{
				return;
			}
			if (selectItems.Count > 0)
			{
				this._QuickSellEquips(delegate
				{
					this._CloseQuickSell();
				}, selectItems.ToArray());
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("package_quick_sell_no_select"), null, string.Empty, false);
			}
		}

		// Token: 0x0600E64F RID: 58959 RVA: 0x003C31E4 File Offset: 0x003C15E4
		private void _InitQuickSell()
		{
			if (!this.m_bQuickSellUIInited)
			{
				this.m_objQuickSellRoot = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Package/QuickSellGroup", true, 0U);
				GameObject gameObject = Utility.FindGameObject("Content/QuickSellRoot", true);
				this.m_objQuickSellRoot.transform.SetParent(gameObject.transform, false);
				if (MonoSingleton<LeanTween>.instance.frameBlackMask != null)
				{
					this.m_objQuickSellMask = Object.Instantiate<GameObject>(MonoSingleton<LeanTween>.instance.frameBlackMask);
					this.m_objQuickSellMask.transform.SetParent(Singleton<ClientSystemManager>.GetInstance().GetLayer(FrameLayer.Middle).transform, false);
					this.m_objQuickSellMask.transform.SetParent(this.m_objQuickSellRoot.transform, true);
					this.m_objQuickSellMask.transform.SetAsFirstSibling();
				}
				for (int i = 1; i <= 3; i++)
				{
					Toggle componetInChild = Utility.GetComponetInChild<Toggle>(this.m_objQuickSellRoot, string.Format("SelectGroup/Toggle{0}", i));
					int nIdx = i - 1;
					this.m_QuickSellToggles[nIdx] = componetInChild;
					componetInChild.isOn = false;
					componetInChild.onValueChanged.RemoveAllListeners();
					componetInChild.onValueChanged.AddListener(delegate(bool var)
					{
						this._OnSelectQualityChanged(nIdx, var);
					});
				}
				Button componetInChild2 = Utility.GetComponetInChild<Button>(this.m_objQuickSellRoot, "Cancel");
				componetInChild2.onClick.RemoveAllListeners();
				componetInChild2.onClick.AddListener(new UnityAction(this._CloseQuickSell));
				Button componetInChild3 = Utility.GetComponetInChild<Button>(this.m_objQuickSellRoot, "Confirm");
				componetInChild3.onClick.RemoveAllListeners();
				componetInChild3.onClick.AddListener(new UnityAction(this._OnQuickSellClicked));
				this._ClearSelectState();
				this.m_objQuickSellRoot.SetActive(false);
				this.m_bQuickSellUIInited = true;
			}
		}

		// Token: 0x0600E650 RID: 58960 RVA: 0x003C33AD File Offset: 0x003C17AD
		private void _OpenQuickSell()
		{
			if (!this.m_bQuickSellUIInited)
			{
				this._InitQuickSell();
			}
			if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.Normal)
			{
				this.m_eShowMode = PackageNewFrame.EItemsShowMode.QuickSell;
				this._RefreshItemList(false);
				this._ClearSelectState();
				this.m_objQuickSellRoot.CustomActive(true);
			}
		}

		// Token: 0x0600E651 RID: 58961 RVA: 0x003C33EC File Offset: 0x003C17EC
		private void _InitQuickDecompose()
		{
			if (!this.m_bDecomposeUIInited)
			{
				this.m_objQuickDecomposeRoot = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Package/DecomposeGroup", true, 0U);
				GameObject gameObject = Utility.FindGameObject("Content/DecomposeRoot", true);
				this.m_objQuickDecomposeRoot.transform.SetParent(gameObject.transform, false);
				if (MonoSingleton<LeanTween>.instance.frameBlackMask != null)
				{
					this.m_objQuickDecomposeMask = Object.Instantiate<GameObject>(MonoSingleton<LeanTween>.instance.frameBlackMask);
					this.m_objQuickDecomposeMask.transform.SetParent(Singleton<ClientSystemManager>.GetInstance().GetLayer(FrameLayer.Middle).transform, false);
					this.m_objQuickDecomposeMask.transform.SetParent(this.m_objQuickDecomposeRoot.transform, true);
					this.m_objQuickDecomposeMask.transform.SetAsFirstSibling();
				}
				for (int i = 1; i <= 3; i++)
				{
					Toggle componetInChild = Utility.GetComponetInChild<Toggle>(this.m_objQuickDecomposeRoot, string.Format("SelectGroup/Toggle{0}", i));
					int nIdx = i - 1;
					this.m_arrQualityToggles[nIdx] = componetInChild;
					if (componetInChild.isOn)
					{
						ComSetTextColor component = componetInChild.gameObject.GetComponent<ComSetTextColor>();
						if (component != null)
						{
							Object.DestroyImmediate(component);
						}
					}
					componetInChild.isOn = false;
					componetInChild.onValueChanged.RemoveAllListeners();
					componetInChild.onValueChanged.AddListener(delegate(bool var)
					{
						this._OnSelectQualityChanged(nIdx, var);
					});
				}
				Button componetInChild2 = Utility.GetComponetInChild<Button>(this.m_objQuickDecomposeRoot, "Cancel");
				componetInChild2.onClick.RemoveAllListeners();
				componetInChild2.onClick.AddListener(new UnityAction(this._OnReturnClicked));
				Button componetInChild3 = Utility.GetComponetInChild<Button>(this.m_objQuickDecomposeRoot, "Confirm");
				componetInChild3.onClick.RemoveAllListeners();
				componetInChild3.onClick.AddListener(new UnityAction(this._OnQuickDecomposeClicked));
				this._ClearSelectState();
				this.m_objQuickDecomposeRoot.SetActive(false);
			}
		}

		// Token: 0x0600E652 RID: 58962 RVA: 0x003C35DC File Offset: 0x003C19DC
		private void _ApplyDefaultDecomposeSetting()
		{
			this.mDecomposeMask &= -5;
			this.mDecomposeMask |= 1;
			for (int i = 0; i < this.m_arrQualityToggles.Length; i++)
			{
				Toggle toggle = this.m_arrQualityToggles[i];
				if (!(null == toggle))
				{
					toggle.isOn = (1 == (this.mDecomposeMask >> i & 1));
					if (toggle.isOn)
					{
						ComSetTextColor component = toggle.gameObject.GetComponent<ComSetTextColor>();
						if (component == null)
						{
							toggle.gameObject.AddComponent<ComSetTextColor>();
						}
					}
				}
			}
		}

		// Token: 0x0600E653 RID: 58963 RVA: 0x003C3680 File Offset: 0x003C1A80
		private void _SaveDecomposeSetting()
		{
			for (int i = 0; i < this.m_arrQualityToggles.Length; i++)
			{
				Toggle toggle = this.m_arrQualityToggles[i];
				if (!(null == toggle))
				{
					if (toggle.isOn)
					{
						this.mDecomposeMask |= 1 << i;
					}
					else
					{
						this.mDecomposeMask &= ~(1 << i);
					}
				}
			}
		}

		// Token: 0x0600E654 RID: 58964 RVA: 0x003C36F8 File Offset: 0x003C1AF8
		private void _ClearQuickDecompose()
		{
			this._CloseQuickDecompose();
			this.m_bDecomposeUIInited = false;
			this.m_objQuickDecomposeMask = null;
			this.m_objQuickDecomposeMask = null;
			this.m_objQuickDecomposeRoot = null;
			for (int i = 0; i < this.m_arrQualityToggles.Length; i++)
			{
				this.m_arrQualityToggles[i] = null;
			}
			this.m_eShowMode = PackageNewFrame.EItemsShowMode.Normal;
		}

		// Token: 0x0600E655 RID: 58965 RVA: 0x003C3750 File Offset: 0x003C1B50
		private void _OpenQuickDecompose()
		{
			if (!this.m_bDecomposeUIInited)
			{
				this._InitQuickDecompose();
				this.m_bDecomposeUIInited = true;
			}
			if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.Normal)
			{
				this.m_eShowMode = PackageNewFrame.EItemsShowMode.Decompose;
				this._ClearSelectState();
				this.m_objQuickDecomposeRoot.SetActive(true);
			}
			if (DataManager<PlayerBaseData>.GetInstance().Level >= 15)
			{
				this._ApplyDefaultDecomposeSetting();
			}
			this._RefreshItemList(false);
		}

		// Token: 0x0600E656 RID: 58966 RVA: 0x003C37B8 File Offset: 0x003C1BB8
		private void _OpenFashionDecompose(List<ulong> GUIDs = null)
		{
			if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.Normal)
			{
				this.m_eShowMode = PackageNewFrame.EItemsShowMode.FashionDecompose;
				this._ClearSelectState();
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionEquipDecomposeFrame>(this.fashionEquipDecomposeRoot, GUIDs, string.Empty);
				if (GUIDs != null)
				{
					for (int i = 0; i < GUIDs.Count; i++)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(GUIDs[i]);
						if (item != null)
						{
							item.IsSelected = true;
						}
					}
				}
			}
			this._RefreshItemList(false);
		}

		// Token: 0x0600E657 RID: 58967 RVA: 0x003C3838 File Offset: 0x003C1C38
		private void _CloseQuickDecompose()
		{
			if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.Decompose)
			{
				this.m_eShowMode = PackageNewFrame.EItemsShowMode.Normal;
				this._RefreshItemList(false);
				this._ClearSelectState();
				this.m_objQuickDecomposeRoot.SetActive(false);
				for (int i = 0; i < this.m_arrQualityToggles.Length; i++)
				{
					if (this.m_arrQualityToggles[i].isOn)
					{
						ComSetTextColor component = this.m_arrQualityToggles[i].gameObject.GetComponent<ComSetTextColor>();
						if (component != null)
						{
							Object.DestroyImmediate(component);
						}
					}
					this.m_arrQualityToggles[i].isOn = false;
				}
			}
		}

		// Token: 0x0600E658 RID: 58968 RVA: 0x003C38CF File Offset: 0x003C1CCF
		private void _CloseFashionDecompose()
		{
			if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.FashionDecompose)
			{
				this.m_eShowMode = PackageNewFrame.EItemsShowMode.Normal;
				this._RefreshItemList(false);
				this._ClearSelectState();
			}
		}

		// Token: 0x0600E659 RID: 58969 RVA: 0x003C38F4 File Offset: 0x003C1CF4
		private List<ItemData> _GetItemsByQuality(ItemTable.eColor a_quality)
		{
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && item.Quality == a_quality && item.CanDecompose)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0600E65A RID: 58970 RVA: 0x003C3968 File Offset: 0x003C1D68
		private void _ClearSelectState()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && item != null)
				{
					item.IsSelected = false;
				}
			}
		}

		// Token: 0x0600E65B RID: 58971 RVA: 0x003C39C4 File Offset: 0x003C1DC4
		private void _DecomposeEquips(Action a_okCallback, params ItemData[] a_arrItems)
		{
			if (a_arrItems == null || a_arrItems.Length == 0)
			{
				return;
			}
			ulong[] arrGuids = new ulong[a_arrItems.Length];
			for (int i = 0; i < a_arrItems.Length; i++)
			{
				arrGuids[i] = a_arrItems[i].GUID;
			}
			string msgContent = string.Empty;
			if (a_arrItems.Length == 1)
			{
				ItemData itemData = a_arrItems[0];
				if (itemData.EquipType == EEquipType.ET_REDMARK)
				{
					msgContent = TR.Value("growth_equip_desc", "您确定要分解吗");
				}
				else if (itemData.StrengthenLevel >= 5)
				{
					msgContent = TR.Value("equip_single_decompose_ask_01", itemData.GetColorName("[{0}]", true), itemData.StrengthenLevel);
				}
				else if (itemData.Quality > ItemTable.eColor.BLUE)
				{
					msgContent = TR.Value("equip_single_decompose_ask_03", itemData.GetQualityDesc(), itemData.GetColorName("[{0}]", true));
				}
				else
				{
					msgContent = TR.Value("equip_single_decompose_ask_02", itemData.GetColorName("[{0}]", true));
				}
			}
			else
			{
				List<ItemData> list = new List<ItemData>();
				bool flag = false;
				foreach (ItemData itemData2 in a_arrItems)
				{
					if (itemData2.EquipType == EEquipType.ET_REDMARK)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					msgContent = TR.Value("selected_equipment_has_red_equip_desc", "是否确认分解？");
				}
				else
				{
					foreach (ItemData itemData3 in a_arrItems)
					{
						if (itemData3.StrengthenLevel >= 5 || itemData3.Quality > ItemTable.eColor.BLUE)
						{
							list.Add(itemData3);
						}
					}
					int num = a_arrItems.Length - list.Count;
					if (list.Count > 0)
					{
						list.Sort(delegate(ItemData var1, ItemData var2)
						{
							ulong basePriceByItemData = DataManager<AuctionDataManager>.GetInstance().GetBasePriceByItemData(var1);
							ulong basePriceByItemData2 = DataManager<AuctionDataManager>.GetInstance().GetBasePriceByItemData(var2);
							if (basePriceByItemData > basePriceByItemData2)
							{
								return -1;
							}
							if (basePriceByItemData < basePriceByItemData2)
							{
								return 1;
							}
							return var2.StrengthenLevel - var1.StrengthenLevel;
						});
						string text = string.Empty;
						for (int l = 0; l < list.Count; l++)
						{
							if (l > 5)
							{
								break;
							}
							text += list[l].GetColorName(" [{0}]", true);
						}
						text += " ";
						if (list.Count <= 5)
						{
							if (num > 0)
							{
								msgContent = TR.Value("equip_multi_decompose_ask_01", text, list.Count, num);
							}
							else
							{
								msgContent = TR.Value("equip_multi_decompose_ask_02", text, list.Count);
							}
						}
						else if (num > 0)
						{
							msgContent = TR.Value("equip_multi_decompose_ask_03", text, list.Count, num);
						}
						else
						{
							msgContent = TR.Value("equip_multi_decompose_ask_04", text, list.Count);
						}
					}
					else
					{
						msgContent = TR.Value("equip_multi_decompose_ask_05", num);
					}
				}
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<ItemDataManager>.GetInstance().SendDecomposeItem(arrGuids, false);
				if (a_okCallback != null)
				{
					a_okCallback();
				}
			}, null, 0f, false);
		}

		// Token: 0x0600E65C RID: 58972 RVA: 0x003C3CDB File Offset: 0x003C20DB
		private void _OnReturnClicked()
		{
			this._CloseQuickDecompose();
		}

		// Token: 0x0600E65D RID: 58973 RVA: 0x003C3CE4 File Offset: 0x003C20E4
		private void _OnQuickDecomposeClicked()
		{
			List<ItemData> selectItems = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && item.IsSelected)
				{
					selectItems.Add(item);
				}
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(delegate
			{
				for (int j = 0; j < selectItems.Count; j++)
				{
					ItemData itemData = selectItems[j];
					if (itemData != null && itemData.Quality >= ItemTable.eColor.PURPLE)
					{
						return true;
					}
				}
				return false;
			}, null))
			{
				return;
			}
			if (selectItems.Count > 0)
			{
				this._DecomposeEquips(delegate
				{
					this._SaveDecomposeSetting();
					this._CloseQuickDecompose();
				}, selectItems.ToArray());
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("package_quick_decompose_no_select"), null, string.Empty, false);
			}
		}

		// Token: 0x0600E65E RID: 58974 RVA: 0x003C3DC8 File Offset: 0x003C21C8
		private void _OnSelectQualityChanged(int index, bool isChecked)
		{
			if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.Decompose || this.m_eShowMode == PackageNewFrame.EItemsShowMode.QuickSell)
			{
				List<ItemData> list;
				if (index == 0)
				{
					list = this._GetItemsByQuality(ItemTable.eColor.WHITE);
				}
				else if (index == 1)
				{
					list = this._GetItemsByQuality(ItemTable.eColor.BLUE);
				}
				else if (index == 2)
				{
					list = this._GetItemsByQuality(ItemTable.eColor.PURPLE);
				}
				else
				{
					list = new List<ItemData>();
				}
				if (index >= 0 && this.m_arrQualityToggles != null && index < this.m_arrQualityToggles.Length)
				{
					Toggle toggle = this.m_arrQualityToggles[index];
					if (toggle != null)
					{
						ComSetTextColor component = toggle.gameObject.GetComponent<ComSetTextColor>();
						if (isChecked)
						{
							if (component == null)
							{
								toggle.gameObject.AddComponent<ComSetTextColor>();
							}
						}
						else if (component != null)
						{
							Object.DestroyImmediate(component);
						}
					}
				}
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
				for (int i = 0; i < list.Count; i++)
				{
					list[i].IsSelected = (isChecked && list[i].StrengthenLevel < 10 && !list[i].bLocked);
				}
				if (list.Count > 0)
				{
					ulong guid = list[0].GUID;
					for (int j = 0; j < itemsByPackageType.Count; j++)
					{
						if (guid == itemsByPackageType[j])
						{
							this.m_comItemList.EnsureElementVisable(j);
						}
					}
				}
				this.m_comItemList.SetElementAmount(this._GetRefreshMaxNum());
			}
		}

		// Token: 0x0600E65F RID: 58975 RVA: 0x003C3F6C File Offset: 0x003C236C
		private void UpdateGridLevelUpStatus()
		{
			if (this.mButtonLevelUp != null && (this.m_currentItemType == EPackageType.Title || this.m_currentItemType == EPackageType.Fashion))
			{
			}
		}

		// Token: 0x0600E660 RID: 58976 RVA: 0x003C3FA0 File Offset: 0x003C23A0
		private void _InitItemTab()
		{
			for (int i = 0; i < this.m_arrItemTabInfos.Length; i++)
			{
				PackageNewFrame.ItemTabInfo info = this.m_arrItemTabInfos[i];
				int ePackageType = (int)info.ePackageType;
				info.toggle = Utility.GetComponetInChild<Toggle>(this.frame, string.Format("Content/ItemListTabs/Title{0}", ePackageType));
				info.toggle.onValueChanged.RemoveAllListeners();
				info.toggle.onValueChanged.AddListener(delegate(bool var)
				{
					if (var)
					{
						EPackageType ePackageType2 = info.ePackageType;
						if (this.m_currentItemType != ePackageType2)
						{
							this.m_currentItemType = ePackageType2;
							DataManager<ItemDataManager>.GetInstance().ArrangeItemsInPackageFrame(this.m_currentItemType);
							this._RefreshItemTab();
							this._RefreshItemList(true);
							this.UpdateGridLevelUpStatus();
							this.switchWeaponBtn.CustomActive(this.SwitchWeaponOpen() && this.m_currentItemType != EPackageType.Fashion && this.m_currentItemType != EPackageType.Inscription);
						}
					}
					else
					{
						info.objRedPoint.SetActive(this.IsItemTabShowRedPoint(info.ePackageType));
					}
				});
				info.objRedPoint = Utility.FindGameObject(this.frame, string.Format("Content/ItemListTabs/Title{0}/RedPoint", ePackageType), true);
				info.objRedPoint.SetActive(this.IsItemTabShowRedPoint(info.ePackageType));
				info.toggle.gameObject.SetActive(false);
			}
			this._UpdateFashionRedPoint();
			this.m_objShop.CustomActive(false);
		}

		// Token: 0x0600E661 RID: 58977 RVA: 0x003C40BC File Offset: 0x003C24BC
		private void _RefreshItemTab()
		{
			for (int i = 0; i < this.m_arrItemTabInfos.Length; i++)
			{
				PackageNewFrame.ItemTabInfo itemTabInfo = this.m_arrItemTabInfos[i];
				itemTabInfo.objRedPoint.CustomActive(this.IsItemTabShowRedPoint(itemTabInfo.ePackageType));
			}
		}

		// Token: 0x0600E662 RID: 58978 RVA: 0x003C4102 File Offset: 0x003C2502
		private bool IsItemTabShowRedPoint(EPackageType packageType)
		{
			return DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(packageType) || (packageType == EPackageType.Consumable && DataManager<PackageDataManager>.GetInstance().IsPackageTabShowRedPoint(packageType));
		}

		// Token: 0x0600E663 RID: 58979 RVA: 0x003C412C File Offset: 0x003C252C
		private void _ClearItemTab()
		{
			for (int i = 0; i < this.m_arrItemTabInfos.Length; i++)
			{
				PackageNewFrame.ItemTabInfo itemTabInfo = this.m_arrItemTabInfos[i];
				itemTabInfo.objRedPoint = null;
				itemTabInfo.toggle = null;
			}
			this.m_currentItemType = EPackageType.Invalid;
		}

		// Token: 0x0600E664 RID: 58980 RVA: 0x003C4170 File Offset: 0x003C2570
		private PackageNewFrame.ItemTabInfo _GetItemTabInfo(EPackageType a_type)
		{
			for (int i = 0; i < this.m_arrItemTabInfos.Length; i++)
			{
				if (this.m_arrItemTabInfos[i].ePackageType == a_type)
				{
					return this.m_arrItemTabInfos[i];
				}
			}
			return null;
		}

		// Token: 0x0600E665 RID: 58981 RVA: 0x003C41B4 File Offset: 0x003C25B4
		private void _InitItemList()
		{
			this.m_comItemList.Initialize();
			this.m_comItemList.onBindItem = ((GameObject obj) => base.CreateComItem(obj));
			this.m_comItemList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				ComGridBindItem component = item.GetComponent<ComGridBindItem>();
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
				int num = this._GetRefreshMaxNum();
				if (item.m_index >= 0 && item.m_index < num)
				{
					if (item.m_index < itemsByPackageType.Count)
					{
						ComItem comItem = item.gameObjectBindScript as ComItem;
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[item.m_index]);
						if (item2 != null)
						{
							comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
							comItem.Setup(item2, new ComItem.OnItemClicked(this._OnPackageItemClicked));
							if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.Decompose)
							{
								comItem.SetEnable(item2.CanDecompose && item2.StrengthenLevel < 10);
							}
							else if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.QuickSell)
							{
								comItem.SetEnable(item2.CanSell && item2.StrengthenLevel < 10);
							}
							else if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.FashionDecompose)
							{
								comItem.SetEnable(item2.CanDecompose && !item2.bFashionItemLocked && item2.DeadTimestamp <= 0);
							}
							else
							{
								comItem.SetEnable(true);
							}
							comItem.SetShowSelectState(this.m_eShowMode == PackageNewFrame.EItemsShowMode.Decompose || this.m_eShowMode == PackageNewFrame.EItemsShowMode.QuickSell || this.m_eShowMode == PackageNewFrame.EItemsShowMode.FashionDecompose);
							comItem.SetShowBetterState(this.m_currentItemType == EPackageType.Equip);
							comItem.SetShowUnusableState(true);
							comItem.SetShowRedPoint(true);
							if (component != null)
							{
								component.param1 = item.gameObject.name;
								component.param2 = item2.GUID;
							}
						}
						else
						{
							comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
							comItem.Setup(null, null);
							comItem.SetEnable(true);
							comItem.SetShowBetterState(false);
							comItem.SetShowSelectState(false);
							comItem.SetShowUnusableState(false);
							comItem.SetShowRedPoint(false);
							if (component != null)
							{
								component.param1 = null;
								component.param2 = 0;
							}
						}
					}
					else if (item.m_index < DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType])
					{
						ComItem comItem2 = item.gameObjectBindScript as ComItem;
						comItem2.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
						comItem2.Setup(null, null);
						comItem2.SetEnable(true);
						comItem2.SetShowBetterState(false);
						comItem2.SetShowSelectState(false);
						comItem2.SetShowUnusableState(false);
						comItem2.SetShowRedPoint(false);
						if (component != null)
						{
							component.param1 = null;
							component.param2 = 0;
						}
					}
					else
					{
						string lockMaskPath = string.Empty;
						if (item.m_index == DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType])
						{
							lockMaskPath = "UI/Image/Packed/p_UI_Set.png:UI_Shezhi_Tubiao_Jiahao";
						}
						ComItem comItem3 = item.gameObjectBindScript as ComItem;
						comItem3.SetupSlot(ComItem.ESlotType.Locked, string.Empty, delegate(GameObject var)
						{
							this._UpgradePackageSize();
						}, lockMaskPath);
						comItem3.Setup(null, null);
						comItem3.SetEnable(true);
						comItem3.SetShowBetterState(false);
						comItem3.SetShowSelectState(false);
						comItem3.SetShowUnusableState(false);
						comItem3.SetShowRedPoint(false);
						if (component != null)
						{
							component.param1 = null;
							component.param2 = 0;
						}
					}
				}
			};
			this.m_bItemlistInited = true;
		}

		// Token: 0x0600E666 RID: 58982 RVA: 0x003C4204 File Offset: 0x003C2604
		private void _RefreshItemList(bool resetScrollPos = false)
		{
			if (!this.m_bItemlistInited)
			{
				return;
			}
			this.m_comItemList.SetElementAmount(this._GetRefreshMaxNum());
			if (resetScrollPos && this.m_scrollRect)
			{
				this.m_scrollRect.verticalNormalizedPosition = 1f;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			if (this.m_currentItemType < (EPackageType)DataManager<PlayerBaseData>.GetInstance().PackTotalSize.Count)
			{
				this.m_gridCount.text = TR.Value("grid_info", itemsByPackageType.Count, DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType]);
			}
			this.m_comBtnChapterPotionSet.CustomActive(false);
			this.btnFashionEquipDecompose.CustomActive(false);
			this.m_objFashionMerge.CustomActive(false);
			this.m_objInscriptionMerge.CustomActive(false);
			this.m_comBtnQuickDecompose.CustomActive(this.m_currentItemType == EPackageType.Equip);
			this.m_comBtnQuickSell.CustomActive(this.m_currentItemType == EPackageType.Equip);
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.BattleDrugs))
			{
				this.m_comBtnChapterPotionSet.CustomActive(this.m_currentItemType == EPackageType.Consumable);
			}
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Inscription))
			{
				this.btnFashionEquipDecompose.CustomActive(this.m_currentItemType == EPackageType.Fashion);
			}
			bool bActive = Utility.IsUnLockFunc(45) && !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_FASHION_MERGO) && this.m_currentItemType == EPackageType.Fashion;
			this.m_objFashionMerge.CustomActive(bActive);
			bool bActive2 = Utility.IsUnLockFunc(92) && this.m_currentItemType == EPackageType.Inscription;
			this.m_objInscriptionMerge.CustomActive(bActive2);
		}

		// Token: 0x0600E667 RID: 58983 RVA: 0x003C43B0 File Offset: 0x003C27B0
		private int _GetRefreshMaxNum()
		{
			if (this.m_currentItemType < EPackageType.Invalid || this.m_currentItemType >= (EPackageType)DataManager<PlayerBaseData>.GetInstance().PackTotalSize.Count)
			{
				return 100;
			}
			int result;
			if (DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType] < 100)
			{
				result = 100;
			}
			else if (DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType] % 4 == 0)
			{
				result = DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType];
			}
			else
			{
				int num = 4 - DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType] % 4;
				result = DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType] + num;
			}
			return result;
		}

		// Token: 0x0600E668 RID: 58984 RVA: 0x003C4476 File Offset: 0x003C2876
		private void _ClearItemList()
		{
			this.m_bItemlistInited = false;
		}

		// Token: 0x0600E669 RID: 58985 RVA: 0x003C4480 File Offset: 0x003C2880
		private void _UpgradePackageSize()
		{
			int num = DataManager<PlayerBaseData>.GetInstance().PackBaseSize + 10;
			if (num <= 100)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(num, string.Empty, string.Empty);
				SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(num + 1, string.Empty, string.Empty);
				if (tableItem != null && tableItem2 != null)
				{
					CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo
					{
						nMoneyID = tableItem2.Value,
						nCount = tableItem.Value
					};
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("package_unlock_grids", DataManager<CostItemManager>.GetInstance().GetCostMoneiesDesc(new CostItemManager.CostInfo[]
					{
						costInfo
					})), delegate()
					{
						DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
						{
							SceneEnlargePackage cmd = new SceneEnlargePackage();
							NetManager.Instance().SendCommand<SceneEnlargePackage>(ServerType.GATE_SERVER, cmd);
							DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneEnlargePackageRet>(delegate(SceneEnlargePackageRet msgRet)
							{
								if (msgRet == null)
								{
									return;
								}
								if (msgRet.code != 0U)
								{
									SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
								}
								else
								{
									this._RefreshItemTab();
									this._RefreshItemList(false);
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdatePackageTabRedPoint, null, null, null, null);
								}
							}, true, 15f, null);
						}, "common_money_cost", null);
					}, null, 0f, false);
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("package_unlock_max"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600E66A RID: 58986 RVA: 0x003C4564 File Offset: 0x003C2964
		private void _OnWearedItemClicked(GameObject obj, ItemData item)
		{
			List<TipFuncButon> list = new List<TipFuncButon>();
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
				if (tableItem != null && item.Type == ItemTable.eType.EQUIP)
				{
					TipFuncButonSpecial item2 = new TipFuncButonSpecial
					{
						text = TR.Value("tip_takeoff"),
						callback = new OnTipFuncClicked(this._OnUnWear)
					};
					list.Add(item2);
				}
			}
			else if (item.Type == ItemTable.eType.EQUIP || item.Type == ItemTable.eType.FASHION || item.Type == ItemTable.eType.FUCKTITTLE)
			{
				int num;
				bool flag;
				item.GetTimeLeft(out num, out flag);
				if ((!flag || num > 0) && item.Type == ItemTable.eType.FASHION && this._CanAllUse(item.TableID))
				{
					TipFuncButon item3 = new TipFuncButon
					{
						text = TR.Value("tip_all_takeoff"),
						callback = new OnTipFuncClicked(this._OnTakeOffAllFashion)
					};
					list.Add(item3);
				}
				if (flag && item.CanRenewal())
				{
					TipFuncButon item3 = new TipFuncButon
					{
						text = TR.Value("tip_renewal"),
						name = "Renewal",
						callback = new OnTipFuncClicked(this._OnItemRenewal)
					};
					list.Add(item3);
				}
				if (!flag || num > 0)
				{
					TipFuncButonSpecial item4 = new TipFuncButonSpecial
					{
						text = TR.Value("tip_takeoff"),
						callback = new OnTipFuncClicked(this._OnUnWear)
					};
					list.Add(item4);
					if (item.SubType == 1 && this.SwitchWeaponOpen())
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_weapon_set"),
							name = "AdjustItemGrade",
							callback = new OnTipFuncClicked(this.OpenWeaponSetFram)
						};
						list.Add(item3);
					}
					if (item.Type == ItemTable.eType.EQUIP && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Forge) && !item.bLocked && !item.IsLease)
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_forge"),
							name = "Forge",
							callback = new OnTipFuncClicked(this._OnStrengthenItem)
						};
						list.Add(item3);
					}
					if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Forge) && !item.isInSidePack && !item.bLocked && !item.IsLease && item.Type == ItemTable.eType.FUCKTITTLE && item.SubType == 10 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Bead) && item.DeadTimestamp == 0)
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_BeadMosaic"),
							name = "BeadMosaic",
							callback = new OnTipFuncClicked(this._OnForgeItem)
						};
						list.Add(item3);
					}
					if (Utility._CheckFashionCanMerge(item.GUID) && item.SuitID != 101139 && Utility.IsUnLockFunc(45) && !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_FASHION_MERGO))
					{
						list.Add(DataManager<FashionMergeManager>.GetInstance().MergeFunction);
					}
					if (item.Type == ItemTable.eType.FASHION && item.SubType != 11 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.FashionAttrSel) && item.HasFashionAttribute)
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_fashion_attr_sel"),
							name = "fashion_attr_sel",
							callback = new OnTipFuncClicked(this._OnFashionAttrSelItem)
						};
						list.Add(item3);
					}
					if (item.Quality > ItemTable.eColor.PURPLE || (item.Type == ItemTable.eType.FUCKTITTLE && item.Quality > ItemTable.eColor.BLUE))
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_share"),
							callback = new OnTipFuncClicked(this._OnShareClicked)
						};
						list.Add(item3);
					}
				}
				if (item.Type == ItemTable.eType.EQUIP)
				{
					if (!item.bLocked && !item.IsLease)
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_lock_item"),
							name = "LockItem",
							callback = new OnTipFuncClicked(this._OnLockItem)
						};
						list.Add(item3);
					}
					else if (!item.IsLease)
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_unlock_item"),
							name = "UnLockItem",
							callback = new OnTipFuncClicked(this._OnUnLockItem)
						};
						list.Add(item3);
					}
				}
				else if (item.Type == ItemTable.eType.FASHION)
				{
					if (item.bFashionItemLocked)
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_unlock_item"),
							name = "UnLockItem",
							callback = new OnTipFuncClicked(this._OnUnLockItem)
						};
						list.Add(item3);
					}
					else
					{
						TipFuncButon item3 = new TipFuncButon
						{
							text = TR.Value("tip_lock_item"),
							name = "LockItem",
							callback = new OnTipFuncClicked(this._OnLockItem)
						};
						list.Add(item3);
					}
				}
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, list, 5, true, false, true);
		}

		// Token: 0x0600E66B RID: 58987 RVA: 0x003C4B04 File Offset: 0x003C2F04
		private void _OnPackageItemClicked(GameObject obj, ItemData item)
		{
			if (item == null)
			{
				return;
			}
			List<TipFuncButon> list = new List<TipFuncButon>();
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (!item.IsCooling())
					{
						if (item.PackageType == EPackageType.Equip)
						{
							list.Add(new TipFuncButonSpecial
							{
								text = TR.Value("tip_wear"),
								callback = new OnTipFuncClicked(this._TryOnUseItem)
							});
						}
						else if (item.ThirdType != ItemTable.eThirdType.UseToOther && item.ThirdType != ItemTable.eThirdType.ST_CHIJI_MIANZHAN)
						{
							list.Add(new TipFuncButonSpecial
							{
								text = TR.Value("tip_use"),
								callback = new OnTipFuncClicked(this._TryOnUseItem)
							});
						}
						if (item.CanSell)
						{
							TipFuncButon tipFuncButon = new TipFuncButon
							{
								text = TR.Value("tip_sell"),
								name = "Sell",
								callback = new OnTipFuncClicked(this._OnSellItemInChijiScene),
								tipFuncButtonType = TipFuncButtonType.Trigger
							};
							list.Add(tipFuncButon);
						}
					}
					list.Add(new TipFuncButon
					{
						text = TR.Value("tip_throwoff"),
						name = "ThrowOff",
						callback = new OnTipFuncClicked(this._TryOnThrowOffItem)
					});
				}
			}
			else
			{
				bool isItemInUnUsedEquipPlan = item.IsItemInUnUsedEquipPlan;
				if (item.SubType == 55 && DataManager<PackageDataManager>.GetInstance().AlreadyUseTotalMagicBox)
				{
					return;
				}
				if (item.SubType == 56 && DataManager<PackageDataManager>.GetInstance().AlreadyUseTotalMagicHammer)
				{
					return;
				}
				if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.Decompose)
				{
					if (item.CanDecompose)
					{
						item.IsSelected = !item.IsSelected;
						if (item.bLocked)
						{
							item.IsSelected = false;
						}
						obj.GetComponent<ComItem>().MarkDirty();
					}
					return;
				}
				if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.FashionDecompose)
				{
					if (item.CanDecompose)
					{
						item.IsSelected = !item.IsSelected;
						if (item.bFashionItemLocked)
						{
							item.IsSelected = false;
						}
						obj.GetComponent<ComItem>().MarkDirty();
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SelectFashionEquipToDecompose, item.GUID, item.IsSelected, null, null);
					}
					return;
				}
				if (this.m_eShowMode == PackageNewFrame.EItemsShowMode.QuickSell)
				{
					if (item.CanSell)
					{
						item.IsSelected = !item.IsSelected;
						if (item.bLocked)
						{
							item.IsSelected = false;
						}
						obj.GetComponent<ComItem>().MarkDirty();
					}
					return;
				}
				int num;
				bool flag;
				item.GetTimeLeft(out num, out flag);
				if ((!flag || num > 0) && item.Type == ItemTable.eType.FASHION && item.OccupationLimit[0] == Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID) && this._CanAllUse(item.TableID))
				{
					TipFuncButon tipFuncButon = new TipFuncButon
					{
						text = TR.Value("tip_all_wear"),
						callback = new OnTipFuncClicked(this._OnWearAllFashion)
					};
					list.Add(tipFuncButon);
				}
				if (flag && item.CanRenewal())
				{
					TipFuncButon tipFuncButon = new TipFuncButon
					{
						text = TR.Value("tip_renewal"),
						name = "Renewal",
						callback = new OnTipFuncClicked(this._OnItemRenewal)
					};
					list.Add(tipFuncButon);
				}
				if (!flag || num > 0)
				{
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
					if (tableItem2 != null && !string.IsNullOrEmpty(tableItem2.LinkInfo))
					{
						string text = TR.Value("tip_itemLink");
						if (EquipTransferUtility.IsTransferStone(item.TableID))
						{
							text = TR.Value("tip_itemLink_transfer");
						}
						if (tableItem2.SubType == ItemTable.eSubType.Perfect_washing)
						{
							text = TR.Value("tip_perfectquality");
						}
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = text,
							name = "itemLink",
							callback = new OnTipFuncClicked(this._OnItemLink)
						};
						list.Add(tipFuncButon);
					}
					TipFuncButon tipFuncButon2 = DataManager<ItemDataManager>.GetInstance().GetAddDrugUseTipFunc(item) as TipFuncButon;
					if (tipFuncButon2 != null)
					{
						list.Add(tipFuncButon2);
					}
					if (item.SubType == 125)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_sendGift"),
							callback = new OnTipFuncClicked(this._OnSendGiftCick)
						};
						list.Add(tipFuncButon);
					}
					if (item.UseType == ItemTable.eCanUse.UseOne || item.UseType == ItemTable.eCanUse.UseTotal)
					{
						if (item.SubType != 132)
						{
							if (!item.IsCooling() && !item.isInSidePack && item.EquipType != EEquipType.ET_BREATH)
							{
								TipFuncButon tipFuncButon = new TipFuncButonSpecial();
								if (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.Fashion || item.PackageType == EPackageType.Title)
								{
									tipFuncButon.text = TR.Value("tip_wear");
									if (item.HasTransfered)
									{
										tipFuncButon.callback = new OnTipFuncClicked(this._TryDeTransferClicked);
									}
									else if (item.Packing)
									{
										tipFuncButon.callback = new OnTipFuncClicked(this._TryDeSealClicked);
									}
									else
									{
										tipFuncButon.callback = new OnTipFuncClicked(this._TryOnUseItem);
									}
								}
								else if (item.PackageType == EPackageType.Consumable && item.SubType == 53)
								{
									tipFuncButon.text = TR.Value("tip_use");
									tipFuncButon.callback = new OnTipFuncClicked(this._OnUseChangeName);
								}
								else if (item.PackageType == EPackageType.Consumable && item.SubType == 55)
								{
									tipFuncButon.text = TR.Value("tip_use");
									tipFuncButon.callback = new OnTipFuncClicked(this._OnUseMagicBox);
								}
								else if (item.PackageType == EPackageType.Consumable && item.SubType == 56)
								{
									tipFuncButon.text = TR.Value("tip_use");
									tipFuncButon.callback = new OnTipFuncClicked(this._OnUseMagicHammer);
								}
								else if (item.PackageType == EPackageType.Consumable && item.SubType == 85)
								{
									tipFuncButon.text = TR.Value("tip_use");
									tipFuncButon.callback = new OnTipFuncClicked(this._OnUseExtendRoleFieldCard);
								}
								else
								{
									tipFuncButon.text = TR.Value("tip_use");
									tipFuncButon.callback = new OnTipFuncClicked(this._TryOnUseItem);
								}
								list.Add(tipFuncButon);
							}
						}
					}
					if ((item.UseType == ItemTable.eCanUse.UseOne || item.UseType == ItemTable.eCanUse.UseTotal) && DataManager<PlayerBaseData>.GetInstance().JobTableID == 15 && item.SubType == 1 && !item.IsCooling())
					{
						TipFuncButon tipFuncButon = new TipFuncButon();
						if (item.PackageType == EPackageType.Equip && item.EquipType != EEquipType.ET_BREATH)
						{
							tipFuncButon.text = TR.Value("tip_second_Wear");
							if (item.HasTransfered)
							{
								tipFuncButon.callback = new OnTipFuncClicked(this._SecondTryDeTransferClicked);
							}
							else if (item.Packing)
							{
								tipFuncButon.callback = new OnTipFuncClicked(this._SecondTryDeSealClicked);
							}
							else
							{
								tipFuncButon.callback = new OnTipFuncClicked(this._SecondTryOnUseItem);
							}
						}
						list.Add(tipFuncButon);
					}
					if (item.UseType == ItemTable.eCanUse.UseTotal && item.CD <= 0 && !item.IsCooling() && item.Count > 1)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_use_total"),
							callback = new OnTipFuncClicked(this._OnUseTotalItem)
						};
						list.Add(tipFuncButon);
					}
					if (item.PackageType == EPackageType.Title && DataManager<TittleBookManager>.GetInstance().CanAsMergeMaterial(item))
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_title_merge"),
							callback = new OnTipFuncClicked(DataManager<TittleBookManager>.GetInstance().OnGotoMerge)
						};
						list.Add(tipFuncButon);
					}
					if (tableItem2 != null && tableItem2.ComeLink != null && tableItem2.ComeLink.Count > 0)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_try_get_item"),
							callback = new OnTipFuncClicked(this._OnTryGetItem)
						};
						list.Add(tipFuncButon);
					}
					if (item.Type == ItemTable.eType.EQUIP || (item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 25) || (item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 54) || (item.Type == ItemTable.eType.FUCKTITTLE && item.SubType == 10))
					{
						if (this.SwitchWeaponOpen() && item.EquipType != EEquipType.ET_BREATH && item.SubType == 1 && this.SwitchWeaponOpen())
						{
							TipFuncButon tipFuncButon = new TipFuncButon
							{
								text = TR.Value("tip_weapon_set"),
								name = "AdjustItemGrade",
								callback = new OnTipFuncClicked(this.OpenWeaponSetFram)
							};
							list.Add(tipFuncButon);
						}
						if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Forge) && !item.isInSidePack && !item.bLocked && !item.IsLease)
						{
							TipFuncButon tipFuncButon = new TipFuncButon();
							if (item.SubType == 25 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Enchant))
							{
								tipFuncButon.text = TR.Value("tip_enchanting");
								tipFuncButon.name = "Enchanting";
								tipFuncButon.callback = new OnTipFuncClicked(this._OnForgeItem);
								list.Add(tipFuncButon);
							}
							else if ((item.SubType == 54 || (item.Type == ItemTable.eType.FUCKTITTLE && item.SubType == 10 && item.DeadTimestamp == 0)) && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Bead))
							{
								tipFuncButon.text = TR.Value("tip_BeadMosaic");
								tipFuncButon.name = "BeadMosaic";
								tipFuncButon.callback = new OnTipFuncClicked(this._OnForgeItem);
								list.Add(tipFuncButon);
							}
							else if (item.Type == ItemTable.eType.EQUIP)
							{
								tipFuncButon.text = TR.Value("tip_forge");
								tipFuncButon.name = "Forge";
								tipFuncButon.callback = new OnTipFuncClicked(this._OnForgeItem);
								list.Add(tipFuncButon);
							}
						}
					}
					if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Forge) && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Enchant) && !item.isInSidePack && !item.bLocked && !item.IsLease && item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 25 && DataManager<EnchantmentsCardManager>.GetInstance().CheckEnchantmentCardIsUpgrade(item))
					{
						list.Add(new TipFuncButon
						{
							text = TR.Value("tip_BeadUpgrade"),
							name = "EnchantmentCardUpgrade",
							callback = new OnTipFuncClicked(this._OnEmchantmentCardUpgradeClick)
						});
					}
					if (Utility._CheckFashionCanMerge(item.GUID) && item.SuitID != 101139 && Utility.IsUnLockFunc(45) && !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_FASHION_MERGO))
					{
						list.Add(DataManager<FashionMergeManager>.GetInstance().MergeFunction);
					}
					if (item.Type == ItemTable.eType.FASHION && item.SubType != 11 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.FashionAttrSel) && item.HasFashionAttribute)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_fashion_attr_sel"),
							name = "fashion_attr_sel",
							callback = new OnTipFuncClicked(this._OnFashionAttrSelItem)
						};
						list.Add(tipFuncButon);
					}
					if (item.isInSidePack)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_takeoff"),
							callback = new OnTipFuncClicked(this._UnloadWeapon)
						};
						list.Add(tipFuncButon);
					}
				}
				if ((!flag || num > 0) && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Auction) && !item.bLocked && !item.IsLease && !item.CheckEquipIsMosaicInscription())
				{
					List<EPackageType> list2 = new List<EPackageType>();
					list2.Add(EPackageType.Equip);
					list2.Add(EPackageType.Material);
					list2.Add(EPackageType.Consumable);
					list2.Add(EPackageType.Task);
					list2.Add(EPackageType.Fashion);
					list2.Add(EPackageType.Title);
					list2.Add(EPackageType.Inscription);
					if (DataManager<ItemDataManager>.GetInstance().TradeItemTypeFliter(list2, item.PackageType) && DataManager<ItemDataManager>.GetInstance().TradeItemStateFliter(item) && !item.isInSidePack && !isItemInUnUsedEquipPlan)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_auction"),
							name = "Auction",
							callback = new OnTipFuncClicked(this._OnAuction)
						};
						list.Add(tipFuncButon);
					}
				}
				if (item.Type == ItemTable.eType.EQUIP)
				{
					if (!item.bLocked && !item.IsLease)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_lock_item"),
							name = "LockItem",
							callback = new OnTipFuncClicked(this._OnLockItem)
						};
						list.Add(tipFuncButon);
					}
					else if (!item.IsLease)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_unlock_item"),
							name = "UnLockItem",
							callback = new OnTipFuncClicked(this._OnUnLockItem)
						};
						list.Add(tipFuncButon);
					}
				}
				else if (item.Type == ItemTable.eType.FASHION)
				{
					if (item.bFashionItemLocked)
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_unlock_item"),
							name = "UnLockItem",
							callback = new OnTipFuncClicked(this._OnUnLockItem)
						};
						list.Add(tipFuncButon);
					}
					else
					{
						TipFuncButon tipFuncButon = new TipFuncButon
						{
							text = TR.Value("tip_lock_item"),
							name = "LockItem",
							callback = new OnTipFuncClicked(this._OnLockItem)
						};
						list.Add(tipFuncButon);
					}
				}
				if (item.CanSell && !item.bLocked && !item.IsLease && !isItemInUnUsedEquipPlan)
				{
					TipFuncButon tipFuncButon = new TipFuncButon
					{
						text = TR.Value("tip_sell"),
						name = "Sell",
						callback = new OnTipFuncClicked(this._OnSellItem),
						tipFuncButtonType = TipFuncButtonType.Trigger
					};
					list.Add(tipFuncButon);
				}
				if (item.CanDecompose && !item.bLocked && !item.IsLease && !item.bFashionItemLocked && !isItemInUnUsedEquipPlan && (item.Type == ItemTable.eType.EQUIP || (item.Type == ItemTable.eType.FASHION && item.DeadTimestamp <= 0 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Inscription))))
				{
					TipFuncButon tipFuncButon = new TipFuncButon
					{
						text = TR.Value("tip_decompose"),
						name = "Decompose",
						callback = new OnTipFuncClicked(this._OnDecomposeClicked),
						tipFuncButtonType = TipFuncButtonType.Trigger
					};
					list.Add(tipFuncButon);
				}
				if (item.Quality > ItemTable.eColor.PURPLE || (item.Type == ItemTable.eType.FUCKTITTLE && item.Quality > ItemTable.eColor.BLUE))
				{
					TipFuncButon tipFuncButon = new TipFuncButon
					{
						text = TR.Value("tip_share"),
						name = "Share",
						callback = new OnTipFuncClicked(this._OnShareClicked),
						tipFuncButtonType = TipFuncButtonType.Trigger
					};
					list.Add(tipFuncButon);
				}
				if (item.Type == ItemTable.eType.EQUIP)
				{
					TipFuncButon tipFuncButon = new TipFuncButtonOther
					{
						text = TR.Value("tip_more_and_more"),
						name = "More",
						callback = new OnTipFuncClicked(this._OnMoreAndMoreClick),
						tipFuncButtonType = TipFuncButtonType.Other
					};
					list.Add(tipFuncButon);
				}
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

		// Token: 0x0600E66C RID: 58988 RVA: 0x003C5BA2 File Offset: 0x003C3FA2
		private void _OnSendGiftCick(ItemData item, object param1)
		{
			DataManager<ItemTipManager>.GetInstance().CloseTip(0);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SendGiftFrame>(FrameLayer.Middle, item, string.Empty);
		}

		// Token: 0x0600E66D RID: 58989 RVA: 0x003C5BC1 File Offset: 0x003C3FC1
		private void _OnAuction(ItemData item, object data)
		{
			AuctionNewUtility.OpenAuctionNewFrame(item);
		}

		// Token: 0x0600E66E RID: 58990 RVA: 0x003C5BCC File Offset: 0x003C3FCC
		private void _OnLockItem(ItemData item, object data)
		{
			SceneItemLockReq sceneItemLockReq = new SceneItemLockReq();
			sceneItemLockReq.itemUid = item.GUID;
			sceneItemLockReq.opType = 1U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneItemLockReq>(ServerType.GATE_SERVER, sceneItemLockReq);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E66F RID: 58991 RVA: 0x003C5C0B File Offset: 0x003C400B
		private void _OnMoreAndMoreClick(ItemData item, object data)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoreAndMoreBtnHandle, null, null, null, null);
			this.DoStartFrameOperation("ItemTipsFrame", "MoreAndMore_3");
		}

		// Token: 0x0600E670 RID: 58992 RVA: 0x003C5C30 File Offset: 0x003C4030
		private void _OnUnLockItem(ItemData item, object data)
		{
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			SceneItemLockReq sceneItemLockReq = new SceneItemLockReq();
			sceneItemLockReq.itemUid = item.GUID;
			sceneItemLockReq.opType = 0U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneItemLockReq>(ServerType.GATE_SERVER, sceneItemLockReq);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E671 RID: 58993 RVA: 0x003C5C84 File Offset: 0x003C4084
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

		// Token: 0x0600E672 RID: 58994 RVA: 0x003C5D35 File Offset: 0x003C4135
		private void _OnItemRenewal(ItemData item, object data)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RenewalItemFrame>(FrameLayer.Middle, item, string.Empty);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E673 RID: 58995 RVA: 0x003C5D53 File Offset: 0x003C4153
		private void _OnUnWear(ItemData item, object data)
		{
			if (item != null)
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
				MonoSingleton<AudioManager>.instance.PlaySound(103);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
				this.DoStartFrameOperation("ItemTipsFrame", "UnWear_3");
			}
		}

		// Token: 0x0600E674 RID: 58996 RVA: 0x003C5D90 File Offset: 0x003C4190
		private void _TryOnThrowOffItem(ItemData item, object data)
		{
			this.Tempitem = item;
			SystemNotifyManager.SysNotifyMsgBoxOkCancel("丢弃后装备将被删除，是否确定丢弃？", new UnityAction(this._OnClickThrowOffOk), null, 0f, false);
		}

		// Token: 0x0600E675 RID: 58997 RVA: 0x003C5DB6 File Offset: 0x003C41B6
		private void _OnClickThrowOffOk()
		{
			if (this.Tempitem != null)
			{
				DataManager<ChijiDataManager>.GetInstance().SendDelItemReq(this.Tempitem.GUID);
				MonoSingleton<AudioManager>.instance.PlaySound(103);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E676 RID: 58998 RVA: 0x003C5DF0 File Offset: 0x003C41F0
		private void _OnTakeOffAllFashion(ItemData a_item, object a_data)
		{
			EquipmentRelationTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipmentRelationTable>(a_item.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			EquipmentRelationTable.eItemType itemType = tableItem.ItemType;
			EquipmentRelationTable.eSubType subType = tableItem.SubType;
			Dictionary<int, ItemData> dictionary = new Dictionary<int, ItemData>();
			dictionary.Clear();
			dictionary[(int)subType] = DataManager<ItemDataManager>.GetInstance().GetItem(a_item.GUID);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipmentRelationTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				EquipmentRelationTable equipmentRelationTable = keyValuePair.Value as EquipmentRelationTable;
				if (equipmentRelationTable.SubType != subType && equipmentRelationTable.ItemType == itemType)
				{
					int subType2 = (int)equipmentRelationTable.SubType;
					int priority = equipmentRelationTable.Priority;
					ulong itemGUIDForType = DataManager<ItemDataManager>.GetInstance().GetItemGUIDForType(equipmentRelationTable.ID, EPackageType.WearFashion);
					if (itemGUIDForType > 0UL)
					{
						dictionary[subType2] = DataManager<ItemDataManager>.GetInstance().GetItem(itemGUIDForType);
					}
				}
			}
			foreach (KeyValuePair<int, ItemData> keyValuePair2 in dictionary)
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(keyValuePair2.Value, false, 0, 0);
			}
			MonoSingleton<AudioManager>.instance.PlaySound(103);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E677 RID: 58999 RVA: 0x003C5F5C File Offset: 0x003C435C
		private bool _CanAllUse(int tableID)
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<EquipmentRelationTable>(tableID, string.Empty, string.Empty) != null;
		}

		// Token: 0x0600E678 RID: 59000 RVA: 0x003C5F88 File Offset: 0x003C4388
		private void _OnStrengthenItem(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData userData = new SmithShopNewLinkData
				{
					itemData = a_item,
					iDefaultFirstTabId = 0
				};
				ClientFrame.OpenTargetFrame<SmithShopNewFrame>(FrameLayer.Middle, userData);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E679 RID: 59001 RVA: 0x003C5FC4 File Offset: 0x003C43C4
		private void _OnEnchantingItem(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData userData = new SmithShopNewLinkData
				{
					itemData = a_item,
					iDefaultFirstTabId = 2,
					iDefaultSecondTabId = 0
				};
				ClientFrame.OpenTargetFrame<SmithShopNewFrame>(FrameLayer.Middle, userData);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E67A RID: 59002 RVA: 0x003C6008 File Offset: 0x003C4408
		private void _OnAdjustItemGrade(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData userData = new SmithShopNewLinkData
				{
					itemData = a_item,
					iDefaultFirstTabId = 5
				};
				ClientFrame.OpenTargetFrame<SmithShopNewFrame>(FrameLayer.Middle, userData);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E67B RID: 59003 RVA: 0x003C6043 File Offset: 0x003C4443
		private void OpenWeaponSetFram(ItemData a_item, object a_data)
		{
			ClientFrame.OpenTargetFrame<SwitchWeaponFrame>(FrameLayer.Middle, null);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("tip_weapon_set");
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E67C RID: 59004 RVA: 0x003C6066 File Offset: 0x003C4466
		private void _OnFashionAttrSelItem(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				FashionSmithShopFrame.OpenLinkFrame(string.Format("0_{0}", a_item.GUID));
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E67D RID: 59005 RVA: 0x003C6094 File Offset: 0x003C4494
		private void _OnWearAllFashion(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				EquipmentRelationTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipmentRelationTable>(a_item.TableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				EquipmentRelationTable.eItemType itemType = tableItem.ItemType;
				FlatBufferArray<int> occu = tableItem.Occu;
				EquipmentRelationTable.eSubType subType = tableItem.SubType;
				Dictionary<int, ItemData> dictionary = new Dictionary<int, ItemData>();
				Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
				dictionary.Clear();
				dictionary2.Clear();
				dictionary[(int)subType] = DataManager<ItemDataManager>.GetInstance().GetItem(a_item.GUID);
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipmentRelationTable>();
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					EquipmentRelationTable equipmentRelationTable = keyValuePair.Value as EquipmentRelationTable;
					if (equipmentRelationTable.SubType != subType && equipmentRelationTable.ItemType == itemType)
					{
						int subType2 = (int)equipmentRelationTable.SubType;
						int priority = equipmentRelationTable.Priority;
						if (!dictionary2.ContainsKey(subType2) || dictionary2[subType2] < priority)
						{
							ulong itemGUIDForType = DataManager<ItemDataManager>.GetInstance().GetItemGUIDForType(equipmentRelationTable.ID, EPackageType.Fashion);
							if (itemGUIDForType > 0UL)
							{
								int equalFashionPriority = DataManager<ItemDataManager>.GetInstance().GetEqualFashionPriority((int)equipmentRelationTable.ItemType, (int)equipmentRelationTable.SubType);
								if (priority > equalFashionPriority || equalFashionPriority == 0)
								{
									ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemGUIDForType);
									if (item != null)
									{
										if (item.OccupationLimit[0] == Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID))
										{
											dictionary2[subType2] = priority;
											dictionary[subType2] = DataManager<ItemDataManager>.GetInstance().GetItem(itemGUIDForType);
										}
									}
								}
							}
						}
					}
				}
				this.StopEnumerator();
				this.m_iEnumerator = base.StartCoroutine(this.WearAllFashion(dictionary));
			}
		}

		// Token: 0x0600E67E RID: 59006 RVA: 0x003C6269 File Offset: 0x003C4669
		private void StopEnumerator()
		{
			if (this.m_iEnumerator != null)
			{
				base.StopCoroutine(this.m_iEnumerator);
			}
		}

		// Token: 0x0600E67F RID: 59007 RVA: 0x003C6284 File Offset: 0x003C4684
		private IEnumerator WearAllFashion(Dictionary<int, ItemData> itemDic)
		{
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			foreach (KeyValuePair<int, ItemData> item in itemDic)
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(item.Value, false, 0, 0);
				yield return Yielders.GetWaitForSeconds(0.04f);
			}
			MonoSingleton<AudioManager>.instance.PlaySound(102);
			yield break;
		}

		// Token: 0x0600E680 RID: 59008 RVA: 0x003C62A0 File Offset: 0x003C46A0
		private void _OnUseMagicBox(ItemData item, object data)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
			if (itemsByPackageType != null)
			{
				int num = 0;
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item2 != null)
					{
						if (item2.SubType == 56)
						{
							num = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(item2.TableID);
						}
					}
				}
				if (num >= 4)
				{
					DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, 1);
				}
				else
				{
					ItemComeLink.OnLink(800002002, 0, true, null, false, false, false, null, string.Empty);
				}
			}
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E681 RID: 59009 RVA: 0x003C6364 File Offset: 0x003C4764
		private void _OnUseMagicHammer(ItemData item, object data)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
			if (itemsByPackageType != null)
			{
				int num = 0;
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item2 != null)
					{
						if (item2.SubType == 55)
						{
							num = item2.Count;
						}
					}
				}
				if (num >= 1)
				{
					int itemCountInPackage = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(item.TableID);
					if (itemCountInPackage >= 4)
					{
						DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, 1);
					}
					else
					{
						ItemComeLink.OnLink(800002002, 0, true, null, false, false, false, null, string.Empty);
					}
				}
				else
				{
					ItemComeLink.OnLink(800002001, 0, true, null, false, false, false, null, string.Empty);
				}
			}
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E682 RID: 59010 RVA: 0x003C6450 File Offset: 0x003C4850
		private void OpenMagicBoxFrame()
		{
			MagicBoxFrame.MagicBoxResultFrameData userData = new MagicBoxFrame.MagicBoxResultFrameData
			{
				itemRewards = DataManager<MagicBoxDataManager>.GetInstance().itemRrewardList,
				ItemDoubleRewards = DataManager<MagicBoxDataManager>.GetInstance().itemDoubleRewardList
			};
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MagicBoxFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MagicBoxFrame>(null, false);
			}
			ClientFrame.OpenTargetFrame<MagicBoxFrame>(FrameLayer.Middle, userData);
			DataManager<PackageDataManager>.GetInstance().ResetMagicBoxAndMagicHammer();
		}

		// Token: 0x0600E683 RID: 59011 RVA: 0x003C64B3 File Offset: 0x003C48B3
		private void _OnUseExtendRoleFieldCard(ItemData a_item, object data)
		{
			if (a_item == null)
			{
				return;
			}
			DataManager<AdventureTeamDataManager>.GetInstance().ReqExtendRoleFieldUnlock(a_item.GUID, a_item.TableID);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E684 RID: 59012 RVA: 0x003C64DC File Offset: 0x003C48DC
		private void _TryOnUseItem(ItemData item, object data)
		{
			this._RealTryOnUseItem(item, data, false);
		}

		// Token: 0x0600E685 RID: 59013 RVA: 0x003C64E7 File Offset: 0x003C48E7
		private void _SecondTryOnUseItem(ItemData item, object data)
		{
			this._RealTryOnUseItem(item, data, true);
		}

		// Token: 0x0600E686 RID: 59014 RVA: 0x003C64F4 File Offset: 0x003C48F4
		private void _RealTryOnUseItem(ItemData item, object data, bool isSecondWear = false)
		{
			if (item.Type == ItemTable.eType.EQUIP)
			{
				int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
				if (masterPriority == 2)
				{
					SystemNotifyManager.SystemNotifyOkCancel(7019, delegate
					{
						this._OnUseItem(item, data, isSecondWear);
					}, null, FrameLayer.High, false);
					return;
				}
			}
			if (item.ThirdType == ItemTable.eThirdType.UseToSelf && DataManager<PlayerBaseData>.GetInstance().Chiji_HP_Percent >= 1f)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("你的血量已满，无需补充！", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (item.ThirdType == ItemTable.eThirdType.VoidCrackTicket)
			{
				int dungeonDailyFinishedTimes = DungeonUtility.GetDungeonDailyFinishedTimes(3101000);
				int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(3101000);
				int num = dungeonDailyMaxTimes - dungeonDailyFinishedTimes;
				if (num < 0)
				{
					num = 0;
				}
				int dungeonDailyBaseTimes = DungeonUtility.GetDungeonDailyBaseTimes(3101000);
				if (num >= dungeonDailyBaseTimes && !DataManager<ItemDataManager>.GetInstance().bUseVoidCrackTicketIsPlayPrompt)
				{
					CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData = new CommonMsgBoxOkCancelNewParamData();
					commonMsgBoxOkCancelNewParamData.ContentLabel = TR.Value("item_use_vanity_pass_desc", dungeonDailyBaseTimes, item.GetColorName(string.Empty, false));
					commonMsgBoxOkCancelNewParamData.IsShowNotify = true;
					commonMsgBoxOkCancelNewParamData.OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateseVoidCrackTicketIsPlayPrompt);
					commonMsgBoxOkCancelNewParamData.LeftButtonText = TR.Value("common_data_cancel");
					commonMsgBoxOkCancelNewParamData.RightButtonText = TR.Value("common_data_sure_2");
					CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData2 = commonMsgBoxOkCancelNewParamData;
					commonMsgBoxOkCancelNewParamData2.OnRightButtonClickCallBack = (Action)Delegate.Combine(commonMsgBoxOkCancelNewParamData2.OnRightButtonClickCallBack, new Action(delegate()
					{
						this._OnUseItem(item, data, isSecondWear);
					}));
					SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(commonMsgBoxOkCancelNewParamData);
					return;
				}
			}
			this._OnUseItem(item, data, isSecondWear);
		}

		// Token: 0x0600E687 RID: 59015 RVA: 0x003C66D0 File Offset: 0x003C4AD0
		private void _OnUseItem(ItemData item, object data, bool isSecondWear)
		{
			if (item != null)
			{
				int a_nParam = (!isSecondWear) ? 0 : 1;
				if (item.PackID > 0)
				{
					GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(item.PackID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.FilterType == GiftPackTable.eFilterType.Custom || tableItem.FilterType == GiftPackTable.eFilterType.CustomWithJob)
						{
							if (tableItem.FilterCount > 0)
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<SelectItemFrame>(FrameLayer.Middle, item, string.Empty);
							}
							else
							{
								Logger.LogErrorFormat("礼包{0}的FilterCount小于等于0", new object[]
								{
									item.PackID
								});
							}
						}
						else
						{
							DataManager<ItemDataManager>.GetInstance().UseItem(item, false, a_nParam, 0);
							if (item.Count <= 1 || item.CD > 0)
							{
								DataManager<ItemTipManager>.GetInstance().CloseAll();
							}
						}
					}
					else
					{
						Logger.LogErrorFormat("道具{0}的礼包ID{1}不存在", new object[]
						{
							item.TableID,
							item.PackID
						});
					}
				}
				else
				{
					DataManager<ItemDataManager>.GetInstance().UseItem(item, false, a_nParam, 0);
					if (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.Fashion)
					{
						MonoSingleton<AudioManager>.instance.PlaySound(102);
					}
					if (item.Count <= 1 || item.CD > 0)
					{
						DataManager<ItemTipManager>.GetInstance().CloseAll();
					}
				}
			}
		}

		// Token: 0x0600E688 RID: 59016 RVA: 0x003C6837 File Offset: 0x003C4C37
		private void OnUpdateseVoidCrackTicketIsPlayPrompt(bool value)
		{
			DataManager<ItemDataManager>.GetInstance().bUseVoidCrackTicketIsPlayPrompt = value;
		}

		// Token: 0x0600E689 RID: 59017 RVA: 0x003C6844 File Offset: 0x003C4C44
		private void _OnUseChangeName(ItemData a_item, object a_data)
		{
			if (a_item == null)
			{
				return;
			}
			if (a_item.ThirdType == ItemTable.eThirdType.ChangeGuildName)
			{
				GuildCommonModifyData userData = new GuildCommonModifyData
				{
					bHasCost = false,
					nMaxWords = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(120, string.Empty, string.Empty).Value,
					onOkClicked = delegate(string a_strValue)
					{
						DataManager<GuildDataManager>.GetInstance().ChangeName((uint)a_item.TableID, a_item.GUID, a_strValue);
					},
					strTitle = TR.Value("guild_change_name"),
					strEmptyDesc = TR.Value("guild_change_name_desc"),
					strDefultContent = ((!DataManager<GuildDataManager>.GetInstance().HasSelfGuild()) ? string.Empty : DataManager<GuildDataManager>.GetInstance().myGuild.strName),
					eMode = EGuildCommonModifyMode.Short
				};
				this.frameMgr.OpenFrame<GuildCommonModifyFrame>(FrameLayer.Middle, userData, string.Empty);
			}
			else if (a_item.ThirdType == ItemTable.eThirdType.ChangePlayerName)
			{
				GuildCommonModifyData userData2 = new GuildCommonModifyData
				{
					bHasCost = false,
					nMaxWords = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(120, string.Empty, string.Empty).Value,
					onOkClicked = delegate(string a_strValue)
					{
						DataManager<PlayerBaseData>.GetInstance().CheckNameValid(a_item.GUID, a_strValue);
					},
					strTitle = TR.Value("player_change_name"),
					strEmptyDesc = TR.Value("player_change_name_desc"),
					strDefultContent = DataManager<PlayerBaseData>.GetInstance().Name,
					eMode = EGuildCommonModifyMode.Short
				};
				this.frameMgr.OpenFrame<GuildCommonModifyFrame>(FrameLayer.Middle, userData2, string.Empty);
			}
			else if (a_item.ThirdType == ItemTable.eThirdType.ChangeAdventureName)
			{
				AdventureTeamRenameModel userData3 = new AdventureTeamRenameModel
				{
					renameItemGUID = a_item.GUID,
					renameItemTableId = (uint)a_item.TableID
				};
				this.frameMgr.OpenFrame<AdventureTeamChangeNameFrame>(FrameLayer.Middle, userData3, string.Empty);
			}
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E68A RID: 59018 RVA: 0x003C6A38 File Offset: 0x003C4E38
		private void _OnUseTotalItem(ItemData item, object data)
		{
			if (item != null)
			{
				if (item.SubType == 55)
				{
					List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
					if (itemsByPackageType != null)
					{
						int num = 0;
						for (int i = 0; i < itemsByPackageType.Count; i++)
						{
							ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
							if (item2 != null)
							{
								if (item2.SubType == 56)
								{
									int itemCountInPackage = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(item2.TableID);
									num = Mathf.FloorToInt((float)(itemCountInPackage / 4));
								}
							}
						}
						if (num >= item.Count)
						{
							DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, item.Count);
							DataManager<PackageDataManager>.GetInstance().UsingMagicBoxAndMagicHammer();
						}
						else if (num < item.Count && num != 0)
						{
							DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, num);
							DataManager<PackageDataManager>.GetInstance().UsingMagicBoxAndMagicHammer();
						}
						else
						{
							ItemComeLink.OnLink(800002002, 0, true, null, false, false, false, null, string.Empty);
						}
					}
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}
				else if (item.SubType == 56)
				{
					List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
					if (itemsByPackageType2 != null)
					{
						int num2 = 0;
						for (int j = 0; j < itemsByPackageType2.Count; j++)
						{
							ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[j]);
							if (item3 != null)
							{
								if (item3.SubType == 55)
								{
									num2 = item3.Count;
								}
							}
						}
						if (num2 > 0)
						{
							int itemCountInPackage2 = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(item.TableID);
							int num3 = Mathf.FloorToInt((float)(itemCountInPackage2 / 4));
							if (num3 >= num2)
							{
								DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, num2);
								DataManager<PackageDataManager>.GetInstance().UsingMagicBoxAndMagicHammer();
							}
							else if (num3 < num2 && num3 != 0)
							{
								DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, num3);
								DataManager<PackageDataManager>.GetInstance().UsingMagicBoxAndMagicHammer();
							}
							else
							{
								ItemComeLink.OnLink(800002002, 0, true, null, false, false, false, null, string.Empty);
							}
						}
						else
						{
							ItemComeLink.OnLink(800002001, 0, true, null, false, false, false, null, string.Empty);
						}
					}
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}
				else
				{
					DataManager<ItemDataManager>.GetInstance().UseItem(item, true, 0, 0);
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}
			}
		}

		// Token: 0x0600E68B RID: 59019 RVA: 0x003C6CE0 File Offset: 0x003C50E0
		private void _OnTryGetItem(ItemData item, object data)
		{
			if (item != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
				ItemComeLink.OnLink(item.TableID, 0, false, null, false, tableItem.bNeedJump > 0, false, null, string.Empty);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E68C RID: 59020 RVA: 0x003C6D38 File Offset: 0x003C5138
		private void _OnForgeItem(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData smithShopNewLinkData = new SmithShopNewLinkData
				{
					itemData = a_item
				};
				if (a_item.SubType == 25)
				{
					smithShopNewLinkData.iDefaultFirstTabId = 2;
					smithShopNewLinkData.iDefaultSecondTabId = 0;
				}
				else if (a_item.SubType == 54 || a_item.SubType == 10)
				{
					smithShopNewLinkData.iDefaultFirstTabId = 3;
				}
				else
				{
					smithShopNewLinkData.iDefaultFirstTabId = 0;
				}
				DataManager<PlayerBaseData>.GetInstance().IsSelectedPerfectWashingRollTab = false;
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, smithShopNewLinkData, string.Empty);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
				if (a_item.Type == ItemTable.eType.EQUIP)
				{
					this.DoStartFrameOperation("ItemTipsFrame", "Forge_3");
				}
			}
		}

		// Token: 0x0600E68D RID: 59021 RVA: 0x003C6DF8 File Offset: 0x003C51F8
		private void _OnEmchantmentCardUpgradeClick(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData userData = new SmithShopNewLinkData
				{
					itemData = a_item,
					iDefaultFirstTabId = 2,
					iDefaultSecondTabId = 2
				};
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, userData, string.Empty);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E68E RID: 59022 RVA: 0x003C6E50 File Offset: 0x003C5250
		private void _OnBeadUpgrade(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData userData = new SmithShopNewLinkData
				{
					itemData = a_item,
					iDefaultFirstTabId = 10
				};
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, userData, string.Empty);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E68F RID: 59023 RVA: 0x003C6EA2 File Offset: 0x003C52A2
		private void _OnSellItemInChijiScene(ItemData item, object data)
		{
			ChijiShopUtility.OnSellItemInChijiScene(item);
		}

		// Token: 0x0600E690 RID: 59024 RVA: 0x003C6EAC File Offset: 0x003C52AC
		private void _OnSellItem(ItemData item, object data)
		{
			if (item != null)
			{
				if (item.Type == ItemTable.eType.FASHION && item.bFashionItemLocked)
				{
					SystemNotifyManager.SystemNotify(10008, string.Empty);
					return;
				}
				if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(() => item.Quality >= ItemTable.eColor.PURPLE, null))
				{
					return;
				}
				this.frameMgr.OpenFrame<SellItemFrame>(FrameLayer.Middle, item, string.Empty);
				this.DoStartFrameOperation("ItemTipsFrame", "Sell_3");
			}
		}

		// Token: 0x0600E691 RID: 59025 RVA: 0x003C6F47 File Offset: 0x003C5347
		private void _UnloadWeapon(ItemData item, object data)
		{
			DataManager<SwitchWeaponDataManager>.GetInstance().TakeOnSideWeapon(1U, 0UL);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E692 RID: 59026 RVA: 0x003C6F60 File Offset: 0x003C5360
		private void _OnShareClicked(ItemData item, object data)
		{
			DataManager<ChatManager>.GetInstance().ShareEquipment(item, ChatType.CT_WORLD);
		}

		// Token: 0x0600E693 RID: 59027 RVA: 0x003C6F6E File Offset: 0x003C536E
		private void _TryDeTransferClicked(ItemData item, object data)
		{
			this._RealTryDeTransferClicked(item, data, false);
		}

		// Token: 0x0600E694 RID: 59028 RVA: 0x003C6F79 File Offset: 0x003C5379
		private void _SecondTryDeTransferClicked(ItemData item, object data)
		{
			this._RealTryDeTransferClicked(item, data, false);
		}

		// Token: 0x0600E695 RID: 59029 RVA: 0x003C6F84 File Offset: 0x003C5384
		private void _RealTryDeTransferClicked(ItemData item, object data, bool isSecondWear = false)
		{
			if (item == null)
			{
				return;
			}
			int secondWear = (!isSecondWear) ? 0 : 1;
			SystemNotifyManager.SystemNotify(9066, delegate()
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(item, false, secondWear, 0);
				MonoSingleton<AudioManager>.instance.PlaySound(102);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}, null, new object[]
			{
				item.GetColorName(string.Empty, false)
			});
		}

		// Token: 0x0600E696 RID: 59030 RVA: 0x003C6FEE File Offset: 0x003C53EE
		private void _TryDeSealClicked(ItemData item, object data)
		{
			this._RealTryDeSealClicked(item, data, false);
		}

		// Token: 0x0600E697 RID: 59031 RVA: 0x003C6FF9 File Offset: 0x003C53F9
		private void _SecondTryDeSealClicked(ItemData item, object data)
		{
			this._RealTryDeSealClicked(item, data, true);
		}

		// Token: 0x0600E698 RID: 59032 RVA: 0x003C7004 File Offset: 0x003C5404
		private void _RealTryDeSealClicked(ItemData item, object data, bool isSecondWear = false)
		{
			if (item.Type == ItemTable.eType.EQUIP && item.PackageType == EPackageType.Equip)
			{
				int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
				if (masterPriority == 2)
				{
					SystemNotifyManager.SystemNotifyOkCancel(7019, delegate
					{
						this._OnDeSealClicked(item, data, isSecondWear);
					}, null, FrameLayer.High, false);
					return;
				}
			}
			this._OnDeSealClicked(item, data, isSecondWear);
		}

		// Token: 0x0600E699 RID: 59033 RVA: 0x003C70C4 File Offset: 0x003C54C4
		private void _OnDeSealClicked(ItemData item, object data, bool isSecondWear = false)
		{
			if (item != null && item.Packing)
			{
				if (item.CanEquip())
				{
					int secondWear = (!isSecondWear) ? 0 : 1;
					SystemNotifyManager.SystemNotify(2006, delegate()
					{
						DataManager<ItemDataManager>.GetInstance().UseItem(item, false, secondWear, 0);
						MonoSingleton<AudioManager>.instance.PlaySound(102);
						DataManager<ItemTipManager>.GetInstance().CloseAll();
					}, null, new object[]
					{
						item.GetColorName(string.Empty, false)
					});
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("equip_deseal_notify_cannot", item.GetColorName(string.Empty, false)), null, string.Empty, false);
				}
			}
		}

		// Token: 0x0600E69A RID: 59034 RVA: 0x003C7188 File Offset: 0x003C5588
		private void _OnDecomposeClicked(ItemData item, object data)
		{
			if (item != null && item.CanDecompose)
			{
				if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(() => item.Quality >= ItemTable.eColor.PURPLE, null))
				{
					return;
				}
				if (item.Type == ItemTable.eType.FASHION)
				{
					DataManager<ItemTipManager>.GetInstance().CloseAll();
					this._OpenFashionDecompose(new List<ulong>
					{
						item.GUID
					});
					return;
				}
				this._DecomposeEquips(delegate
				{
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}, new ItemData[]
				{
					item
				});
				this.DoStartFrameOperation("ItemTipsFrame", "Decompose_3");
			}
		}

		// Token: 0x0600E69B RID: 59035 RVA: 0x003C7258 File Offset: 0x003C5658
		private void _OnItemLink(ItemData item, object data)
		{
			if (item.TableID == 330000201 && !DataManager<ActivityManager>.GetInstance().IsActivityOpen(10000))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("cannot_use_fashion_ticket"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem != null && !string.IsNullOrEmpty(tableItem.LinkInfo))
			{
				FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(tableItem.FunctionID, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.FinishLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SystemNotify(tableItem2.CommDescID, string.Empty);
					return;
				}
				if (tableItem.Type == ItemTable.eType.ITEM_INSCRIPTION && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SmithShopNewFrame>(null))
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Inscriptions_Purposes_Desc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (tableItem.Type == ItemTable.eType.MATERIAL && tableItem.SubType == ItemTable.eSubType.Perfect_washing)
				{
					DataManager<PlayerBaseData>.GetInstance().IsSelectedPerfectWashingRollTab = true;
				}
				else
				{
					DataManager<PlayerBaseData>.GetInstance().IsSelectedPerfectWashingRollTab = false;
				}
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem.LinkInfo, null, false);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E69C RID: 59036 RVA: 0x003C7394 File Offset: 0x003C5794
		private void _InitPackageFullTips()
		{
			bool flag = this._checkIsFullByType(EPackageType.Equip);
			if (flag)
			{
				DOTweenAnimation[] components = this.mPackageFulltips.GetComponents<DOTweenAnimation>();
				DOTweenAnimation[] components2 = this.mPackageFulText.GetComponents<DOTweenAnimation>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].DORestart(false);
					components2[i].DORestart(false);
				}
				this._SetPackageFullTipActive(true);
			}
			else
			{
				this._SetPackageFullTipActive(false);
			}
		}

		// Token: 0x0600E69D RID: 59037 RVA: 0x003C7400 File Offset: 0x003C5800
		private bool _checkIsFullByType(EPackageType type)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(type);
			int num = 0;
			if (itemsByPackageType != null)
			{
				num = itemsByPackageType.Count;
			}
			return DataManager<PlayerBaseData>.GetInstance().PackTotalSize.Count > (int)type && DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)type] <= num;
		}

		// Token: 0x0600E69E RID: 59038 RVA: 0x003C7455 File Offset: 0x003C5855
		private void _SetPackageFullTipActive(bool bActive)
		{
			if (bActive)
			{
				this.mPackageFulltips.gameObject.CustomActive(true);
			}
			else
			{
				this.mPackageFulltips.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600E69F RID: 59039 RVA: 0x003C7484 File Offset: 0x003C5884
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AvatarChanged, new ClientEventSystem.UIEventHandler(this._OnAvatarChagned));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemsAttrChanged, new ClientEventSystem.UIEventHandler(this._OnItemAttrChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStrengthenSuccess, new ClientEventSystem.UIEventHandler(this._OnItemStrengthFinished));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStrengthenFail, new ClientEventSystem.UIEventHandler(this._OnItemStrengthFinished));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._OnExpChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this._OnBuffChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffRemoved, new ClientEventSystem.UIEventHandler(this._OnBuffChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NameChanged, new ClientEventSystem.UIEventHandler(this._OnNameChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SwitchEquipSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._OnItemSellSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemQualityChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DecomposeFinished, new ClientEventSystem.UIEventHandler(this._OnItemDecomposeFinished));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PackageSwitch2OneGroup, new ClientEventSystem.UIEventHandler(this._OnPackageSwitch2OneGroup));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnlyUpdateItemList, new ClientEventSystem.UIEventHandler(this._OnOnlyUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRefreshPackageProperty, new ClientEventSystem.UIEventHandler(this._OnRefreshPackageProperty));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnIsShowFashionWeapon, new ClientEventSystem.UIEventHandler(this.OnIsShowFashionWeapon));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TitleNameUpdate, new ClientEventSystem.UIEventHandler(this.OnTitleNameUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetPropertyReselect, new ClientEventSystem.UIEventHandler(this.OnPetPropertyReselect));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CloseFashionEquipDecompose, new ClientEventSystem.UIEventHandler(this.OnCloseFashionEquipDecompose));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateEquipmentScore, new ClientEventSystem.UIEventHandler(this.OnUpdateEquipmentScore));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveEquipPlanItemEndTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveEquipPlanItemEndTimeMessage));
		}

		// Token: 0x0600E6A0 RID: 59040 RVA: 0x003C7794 File Offset: 0x003C5B94
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AvatarChanged, new ClientEventSystem.UIEventHandler(this._OnAvatarChagned));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SwitchEquipSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemsAttrChanged, new ClientEventSystem.UIEventHandler(this._OnItemAttrChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStrengthenSuccess, new ClientEventSystem.UIEventHandler(this._OnItemStrengthFinished));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStrengthenFail, new ClientEventSystem.UIEventHandler(this._OnItemStrengthFinished));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._OnExpChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this._OnBuffChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffRemoved, new ClientEventSystem.UIEventHandler(this._OnBuffChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NameChanged, new ClientEventSystem.UIEventHandler(this._OnNameChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._OnItemSellSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemQualityChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DecomposeFinished, new ClientEventSystem.UIEventHandler(this._OnItemDecomposeFinished));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnlyUpdateItemList, new ClientEventSystem.UIEventHandler(this._OnOnlyUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PackageSwitch2OneGroup, new ClientEventSystem.UIEventHandler(this._OnPackageSwitch2OneGroup));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRefreshPackageProperty, new ClientEventSystem.UIEventHandler(this._OnRefreshPackageProperty));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnIsShowFashionWeapon, new ClientEventSystem.UIEventHandler(this.OnIsShowFashionWeapon));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TitleNameUpdate, new ClientEventSystem.UIEventHandler(this.OnTitleNameUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetPropertyReselect, new ClientEventSystem.UIEventHandler(this.OnPetPropertyReselect));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CloseFashionEquipDecompose, new ClientEventSystem.UIEventHandler(this.OnCloseFashionEquipDecompose));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateEquipmentScore, new ClientEventSystem.UIEventHandler(this.OnUpdateEquipmentScore));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveEquipPlanItemEndTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveEquipPlanItemEndTimeMessage));
		}

		// Token: 0x0600E6A1 RID: 59041 RVA: 0x003C7AA1 File Offset: 0x003C5EA1
		private void _OnRedPointChanged(UIEvent uiEvent)
		{
			this._UpdateFashionRedPoint();
		}

		// Token: 0x0600E6A2 RID: 59042 RVA: 0x003C7AA9 File Offset: 0x003C5EA9
		private void _UpdateFashionRedPoint()
		{
			this.m_goFashionRePoint.CustomActive(DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(EPackageType.Fashion) || DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(EPackageType.Inscription));
		}

		// Token: 0x0600E6A3 RID: 59043 RVA: 0x003C7AD8 File Offset: 0x003C5ED8
		private void _OnItemAttrChanged(UIEvent uiEvent)
		{
			List<ItemData> list = (List<ItemData>)uiEvent.Param1;
			if (list == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				ItemData tempItemData = list[i];
				if (tempItemData.PackageType == EPackageType.WearEquip || tempItemData.PackageType == EPackageType.WearFashion)
				{
					flag = true;
					break;
				}
				if (tempItemData.PackageType == EPackageType.Equip || tempItemData.PackageType == EPackageType.Title)
				{
					int num = this.m_equipList.FindIndex((ComItem var) => var.ItemData != null && var.ItemData.GUID == tempItemData.GUID);
					if (num >= 0 && num < this.m_equipList.Count)
					{
						flag = true;
						break;
					}
				}
				if (tempItemData.PackageType == EPackageType.Fashion)
				{
					int num2 = this.m_fashionList.FindIndex((ComItem var) => var.ItemData != null && var.ItemData.GUID == tempItemData.GUID);
					if (num2 >= 0 && num2 < this.m_fashionList.Count)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				this._RefreshEquipSlot();
				this._RefreshFashionSlot();
				this._RefreshDetailAttrs();
				this._RefreshWeaponAttackAttributeTypeInfo();
				this._RefreshEquipScoreNumber();
			}
		}

		// Token: 0x0600E6A4 RID: 59044 RVA: 0x003C7C19 File Offset: 0x003C6019
		private void _OnRefreshPackageProperty(UIEvent a_event)
		{
			this._RefreshDetailAttrs();
			this._RefreshWeaponAttackAttributeTypeInfo();
			this._RefreshEquipScoreNumber();
		}

		// Token: 0x0600E6A5 RID: 59045 RVA: 0x003C7C2D File Offset: 0x003C602D
		private void _OnItemStrengthFinished(UIEvent a_event)
		{
			this._RefreshEquipSlot();
			this._RefreshFashionSlot();
			this._RefreshDetailAttrs();
			this._OnUpdateItemList(a_event);
			this._RefreshWeaponAttackAttributeTypeInfo();
			this._RefreshEquipScoreNumber();
		}

		// Token: 0x0600E6A6 RID: 59046 RVA: 0x003C7C54 File Offset: 0x003C6054
		private void OnUpdateEquipmentScore(UIEvent uiEvent)
		{
			this._RefreshEquipScoreNumber();
		}

		// Token: 0x0600E6A7 RID: 59047 RVA: 0x003C7C5C File Offset: 0x003C605C
		private void _OnExpChanged(UIEvent uiEvent)
		{
			this._RefreshBaseInfo();
			this._RefreshDetailPlayerInfo(true);
		}

		// Token: 0x0600E6A8 RID: 59048 RVA: 0x003C7C6B File Offset: 0x003C606B
		private void _OnBuffChanged(UIEvent a_event)
		{
			this._RefreshDetailAttrs();
		}

		// Token: 0x0600E6A9 RID: 59049 RVA: 0x003C7C73 File Offset: 0x003C6073
		private void _OnNameChanged(UIEvent uiEvent)
		{
			this._RefreshBaseInfo();
			this._RefreshDetailPlayerInfo(false);
		}

		// Token: 0x0600E6AA RID: 59050 RVA: 0x003C7C82 File Offset: 0x003C6082
		private void _OnItemDecomposeFinished(UIEvent a_event)
		{
			this._ClearSelectState();
			this._RefreshItemTab();
			this._RefreshItemList(false);
		}

		// Token: 0x0600E6AB RID: 59051 RVA: 0x003C7C97 File Offset: 0x003C6097
		private void _OnItemSellSuccess(UIEvent a_event)
		{
			this._RefreshItemTab();
			this._RefreshItemList(false);
		}

		// Token: 0x0600E6AC RID: 59052 RVA: 0x003C7CA6 File Offset: 0x003C60A6
		private void _OnOnlyUpdateItemList(UIEvent a_event)
		{
			this._RefreshItemTab();
			this._RefreshItemList(false);
		}

		// Token: 0x0600E6AD RID: 59053 RVA: 0x003C7CB8 File Offset: 0x003C60B8
		private void _OnUpdateItemList(UIEvent a_event)
		{
			this._RefreshItemTab();
			this._RefreshItemList(false);
			this._InitPetTab();
			if (a_event.EventID == EUIEventID.ItemUseSuccess)
			{
				ItemData itemData = (ItemData)a_event.Param1;
				if (itemData.PackageType == EPackageType.Consumable)
				{
					Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PetTable>();
					Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
					bool flag = false;
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, object> keyValuePair = enumerator.Current;
						PetTable petTable = keyValuePair.Value as PetTable;
						if (petTable != null)
						{
							if (petTable.PetEggID == itemData.TableID)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OpenPetEggFrame>(null))
						{
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<OpenPetEggFrame>(null, false);
						}
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<OpenPetEggFrame>(FrameLayer.Middle, itemData, string.Empty);
					}
				}
			}
		}

		// Token: 0x0600E6AE RID: 59054 RVA: 0x003C7D98 File Offset: 0x003C6198
		private void DoStartFrameOperation(string mFrameName, string mName)
		{
			string dateTime = Function.GetDateTime((int)DataManager<TimeManager>.GetInstance().GetServerTime(), true);
			Singleton<GameStatisticManager>.GetInstance().DoStartFrameOperation(mFrameName, mName, dateTime);
		}

		// Token: 0x0600E6AF RID: 59055 RVA: 0x003C7DC3 File Offset: 0x003C61C3
		private void OnReceiveEquipPlanItemEndTimeMessage(UIEvent uiEvent)
		{
			if (this.m_currentItemType != EPackageType.Equip && this.m_currentItemType != EPackageType.Title)
			{
				return;
			}
			this._RefreshItemList(false);
		}

		// Token: 0x04008B59 RID: 35673
		private GameObject mPackageSwitchWeapon;

		// Token: 0x04008B5A RID: 35674
		private GameObject mPackagButtom;

		// Token: 0x04008B5B RID: 35675
		private GameObject mPackageItemListTabs;

		// Token: 0x04008B5C RID: 35676
		private GameObject mPackageActorShow;

		// Token: 0x04008B5D RID: 35677
		private GameObject mPackageItemListView;

		// Token: 0x04008B5E RID: 35678
		private Button mPackageFulltips;

		// Token: 0x04008B5F RID: 35679
		private Text mPackageFulText;

		// Token: 0x04008B60 RID: 35680
		private GameObject mPetRoot;

		// Token: 0x04008B61 RID: 35681
		private Button mSkillDamageBtn;

		// Token: 0x04008B62 RID: 35682
		private GameObject fashionEquipDecomposeRoot;

		// Token: 0x04008B63 RID: 35683
		private Toggle m_togEquipGroup;

		// Token: 0x04008B64 RID: 35684
		private Toggle m_togFashionGroup;

		// Token: 0x04008B65 RID: 35685
		private Toggle m_togTitleGroup;

		// Token: 0x04008B66 RID: 35686
		private Toggle m_togPetGroup;

		// Token: 0x04008B67 RID: 35687
		private GameObject m_objPetGroupRoot;

		// Token: 0x04008B68 RID: 35688
		private GameObject m_objActorRoot;

		// Token: 0x04008B69 RID: 35689
		private GameObject m_objEquipRoot;

		// Token: 0x04008B6A RID: 35690
		private GameObject m_objFashionsRoot;

		// Token: 0x04008B6B RID: 35691
		private GameObject m_objFashionTipRoot;

		// Token: 0x04008B6C RID: 35692
		private Toggle m_objFashionTipToggle;

		// Token: 0x04008B6D RID: 35693
		private Button m_objFashionWeaponShowButton;

		// Token: 0x04008B6E RID: 35694
		private Text m_labPlayerName;

		// Token: 0x04008B6F RID: 35695
		private Text m_labPlayerJob;

		// Token: 0x04008B70 RID: 35696
		private Text m_labPlayerLevel;

		// Token: 0x04008B71 RID: 35697
		private Text m_labVipLevel;

		// Token: 0x04008B72 RID: 35698
		private Text m_titleName;

		// Token: 0x04008B73 RID: 35699
		private Image mTitleImg;

		// Token: 0x04008B74 RID: 35700
		private Button m_titleBtn;

		// Token: 0x04008B75 RID: 35701
		private Image m_imgSeasonMainLV;

		// Token: 0x04008B76 RID: 35702
		private Image m_imgSeasonSubLV;

		// Token: 0x04008B77 RID: 35703
		private GameObject m_objTitleBook;

		// Token: 0x04008B78 RID: 35704
		private GameObject m_objMagicCard;

		// Token: 0x04008B79 RID: 35705
		private GameObject m_objWeaponLease;

		// Token: 0x04008B7A RID: 35706
		private Button mButtonMagicCard;

		// Token: 0x04008B7B RID: 35707
		private Button mButtonTitleBook;

		// Token: 0x04008B7C RID: 35708
		private Button mButtonWeaponlease;

		// Token: 0x04008B7D RID: 35709
		private Image emblemName;

		// Token: 0x04008B7E RID: 35710
		private Button switchWeaponBtn;

		// Token: 0x04008B7F RID: 35711
		private Button m_btnVipLevel;

		// Token: 0x04008B80 RID: 35712
		private GameObject m_goFashionRePoint;

		// Token: 0x04008B81 RID: 35713
		private Toggle m_toggleDetailAttr;

		// Token: 0x04008B82 RID: 35714
		private ScrollRect m_scrollRect;

		// Token: 0x04008B83 RID: 35715
		private ComUIListScriptEx m_comItemList;

		// Token: 0x04008B84 RID: 35716
		private Text m_gridCount;

		// Token: 0x04008B85 RID: 35717
		private ComButtonEnbale m_comBtnChapterPotionSet;

		// Token: 0x04008B86 RID: 35718
		private ComButtonEnbale m_comBtnQuickDecompose;

		// Token: 0x04008B87 RID: 35719
		private ComButtonEnbale m_comBtnQuickSell;

		// Token: 0x04008B88 RID: 35720
		private Button btnFashionEquipDecompose;

		// Token: 0x04008B89 RID: 35721
		private Button mButtonArrage;

		// Token: 0x04008B8A RID: 35722
		private Button mButtonLevelUp;

		// Token: 0x04008B8B RID: 35723
		private Button m_objShop;

		// Token: 0x04008B8C RID: 35724
		private Button m_objFashionMerge;

		// Token: 0x04008B8D RID: 35725
		private Button m_objInscriptionMerge;

		// Token: 0x04008B8E RID: 35726
		private Image mHonorImg;

		// Token: 0x04008B8F RID: 35727
		private GameObject mTitleRoot;

		// Token: 0x04008B90 RID: 35728
		private PackageHonorSystemEntryController m_HonorSystemEntryController;

		// Token: 0x04008B91 RID: 35729
		private Button mButtonClose;

		// Token: 0x04008B92 RID: 35730
		private GameObject goArmyRoot;

		// Token: 0x04008B93 RID: 35731
		private bool m_bInited;

		// Token: 0x04008B94 RID: 35732
		private static bool[,] sTabPackageTypeFlag = new bool[,]
		{
			{
				true,
				true,
				true,
				false,
				false,
				false
			},
			{
				false,
				false,
				false,
				true,
				false,
				true
			},
			{
				false,
				false,
				false,
				false,
				true,
				false
			},
			{
				false,
				false,
				false,
				false,
				false,
				false
			}
		};

		// Token: 0x04008B95 RID: 35733
		private bool m_bEquipSoltInited;

		// Token: 0x04008B96 RID: 35734
		private List<ComItem> m_equipList = new List<ComItem>();

		// Token: 0x04008B97 RID: 35735
		private static string mLeftRoot = "Content/ActorShow/Equips/Left/ItemRoot{0}";

		// Token: 0x04008B98 RID: 35736
		private static string mRightRoot = "Content/ActorShow/Equips/Right/ItemRoot{0}";

		// Token: 0x04008B99 RID: 35737
		private static string mMiddleRoot = "Content/ActorShow/Equips/Middle/ItemRoot{0}";

		// Token: 0x04008B9A RID: 35738
		private ComItemConfig[] mConfigs = new ComItemConfig[]
		{
			new ComItemConfig
			{
				root = PackageNewFrame.mLeftRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mLeftRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mLeftRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mLeftRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mLeftRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mRightRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mRightRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mRightRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mRightRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mRightRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mLeftRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mLeftRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mRightRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mRightRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mRightRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mMiddleRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mMiddleRoot
			},
			new ComItemConfig
			{
				root = PackageNewFrame.mMiddleRoot
			}
		};

		// Token: 0x04008B9B RID: 35739
		private bool m_bFashionSoltInited;

		// Token: 0x04008B9C RID: 35740
		private List<ComItem> m_fashionList = new List<ComItem>();

		// Token: 0x04008B9D RID: 35741
		private GeAvatarRendererEx m_AvatarRenderer;

		// Token: 0x04008B9E RID: 35742
		private readonly string[] m_ActionTable = new string[]
		{
			"Anim_Show_Idle",
			"Anim_Show_Idle_special01"
		};

		// Token: 0x04008B9F RID: 35743
		private readonly int[] m_PlayList;

		// Token: 0x04008BA0 RID: 35744
		private int m_PlayIdx;

		// Token: 0x04008BA1 RID: 35745
		private bool m_bDetailInfosUIInited;

		// Token: 0x04008BA2 RID: 35746
		private Text m_labPlayerNameDetail;

		// Token: 0x04008BA3 RID: 35747
		private Text m_labPlayerJobDetail;

		// Token: 0x04008BA4 RID: 35748
		private Text m_labPlayerLevelDetail;

		// Token: 0x04008BA5 RID: 35749
		private Text m_labVipLevelDetail;

		// Token: 0x04008BA6 RID: 35750
		private Image m_imgSeasonMainLVDetail;

		// Token: 0x04008BA7 RID: 35751
		private Image m_imgSeasonSubLVDetail;

		// Token: 0x04008BA8 RID: 35752
		private ComExpBar m_comExpBar;

		// Token: 0x04008BA9 RID: 35753
		private DOTweenAnimation m_detailAttrDotween;

		// Token: 0x04008BAA RID: 35754
		private GameObject m_objAttrLeft;

		// Token: 0x04008BAB RID: 35755
		private GameObject m_objAttrRight;

		// Token: 0x04008BAC RID: 35756
		private Button m_OpenRoleAttrTipsBtn;

		// Token: 0x04008BAD RID: 35757
		private Text m_WeaponAttackAttributeTypeText;

		// Token: 0x04008BAE RID: 35758
		private Text m_EquipScoreTxt;

		// Token: 0x04008BAF RID: 35759
		private bool m_bQuickSellUIInited;

		// Token: 0x04008BB0 RID: 35760
		private GameObject m_objQuickSellMask;

		// Token: 0x04008BB1 RID: 35761
		private GameObject m_objQuickSellRoot;

		// Token: 0x04008BB2 RID: 35762
		private Toggle[] m_QuickSellToggles;

		// Token: 0x04008BB3 RID: 35763
		private bool m_bDecomposeUIInited;

		// Token: 0x04008BB4 RID: 35764
		private GameObject m_objQuickDecomposeMask;

		// Token: 0x04008BB5 RID: 35765
		private GameObject m_objQuickDecomposeRoot;

		// Token: 0x04008BB6 RID: 35766
		private Toggle[] m_arrQualityToggles;

		// Token: 0x04008BB7 RID: 35767
		private PackageNewFrame.EItemsShowMode m_eShowMode;

		// Token: 0x04008BB8 RID: 35768
		private int mDecomposeMask;

		// Token: 0x04008BB9 RID: 35769
		private PackageNewFrame.ItemTabInfo[] m_arrItemTabInfos;

		// Token: 0x04008BBA RID: 35770
		private EPackageType m_currentItemType;

		// Token: 0x04008BBB RID: 35771
		private bool m_bItemlistInited;

		// Token: 0x04008BBC RID: 35772
		private const string addPackSizeImgPath = "UI/Image/Packed/p_UI_Set.png:UI_Shezhi_Tubiao_Jiahao";

		// Token: 0x04008BBD RID: 35773
		private ItemData Tempitem;

		// Token: 0x04008BBE RID: 35774
		private IEnumerator m_iEnumerator;

		// Token: 0x020016F3 RID: 5875
		private enum TabMode
		{
			// Token: 0x04008BC5 RID: 35781
			TM_EQUIP,
			// Token: 0x04008BC6 RID: 35782
			TM_FASHION,
			// Token: 0x04008BC7 RID: 35783
			TM_TITLE,
			// Token: 0x04008BC8 RID: 35784
			TM_PET
		}

		// Token: 0x020016F4 RID: 5876
		private enum EItemsShowMode
		{
			// Token: 0x04008BCA RID: 35786
			Normal,
			// Token: 0x04008BCB RID: 35787
			Decompose,
			// Token: 0x04008BCC RID: 35788
			QuickSell,
			// Token: 0x04008BCD RID: 35789
			FashionDecompose
		}

		// Token: 0x020016F5 RID: 5877
		public enum OperateMask
		{
			// Token: 0x04008BCF RID: 35791
			OM_WHITE = 1,
			// Token: 0x04008BD0 RID: 35792
			OM_BLUE,
			// Token: 0x04008BD1 RID: 35793
			OM_PURPLE = 4,
			// Token: 0x04008BD2 RID: 35794
			OM_DEFAULT = 1
		}

		// Token: 0x020016F6 RID: 5878
		private class ItemTabInfo
		{
			// Token: 0x04008BD3 RID: 35795
			public EPackageType ePackageType;

			// Token: 0x04008BD4 RID: 35796
			public Toggle toggle;

			// Token: 0x04008BD5 RID: 35797
			public GameObject objRedPoint;
		}
	}
}
