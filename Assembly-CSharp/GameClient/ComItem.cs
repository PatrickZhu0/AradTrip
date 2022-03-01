using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EF5 RID: 3829
	public class ComItem : MonoBehaviour
	{
		// Token: 0x1700190B RID: 6411
		// (get) Token: 0x060095C9 RID: 38345 RVA: 0x001C4895 File Offset: 0x001C2C95
		// (set) Token: 0x060095CA RID: 38346 RVA: 0x001C489D File Offset: 0x001C2C9D
		public object UserData { get; set; }

		// Token: 0x1700190C RID: 6412
		// (get) Token: 0x060095CB RID: 38347 RVA: 0x001C48A6 File Offset: 0x001C2CA6
		public ItemData ItemData
		{
			get
			{
				return this.m_item;
			}
		}

		// Token: 0x1700190D RID: 6413
		// (get) Token: 0x060095CC RID: 38348 RVA: 0x001C48AE File Offset: 0x001C2CAE
		// (set) Token: 0x060095CD RID: 38349 RVA: 0x001C48B6 File Offset: 0x001C2CB6
		public bool needRecycle
		{
			get
			{
				return this.m_needRecycle;
			}
			set
			{
				this.m_needRecycle = value;
			}
		}

		// Token: 0x060095CE RID: 38350 RVA: 0x001C48C0 File Offset: 0x001C2CC0
		public void Reset()
		{
			base.gameObject.name = "item";
			this.m_dirty = false;
			this.m_item = null;
			this.m_slotCallback = null;
			this.m_callback = null;
			this.m_countFormatter = null;
			this.m_eSlotType = ComItem.ESlotType.Opened;
			this.m_strSlotName = string.Empty;
			this.m_bEnable = true;
			this.m_bShowSelectState = false;
			this.m_bShowBetterState = false;
			this.m_bShowUnusableState = false;
			this.m_bShowNotEnoughState = false;
			this.m_bShowRedPoint = false;
			this.m_bShowTreasureState = false;
			RectTransform component = base.gameObject.GetComponent<RectTransform>();
			component.anchorMin = new Vector2(0f, 0f);
			component.anchorMax = new Vector2(1f, 1f);
			component.anchoredPosition = new Vector2(0f, 0f);
			component.sizeDelta = new Vector2(0f, 0f);
			component.pivot = new Vector2(0.5f, 0.5f);
			Component[] components = base.gameObject.GetComponents<Component>();
			for (int i = 0; i < components.Length; i++)
			{
				if (!(components[i] is ComItem) && !(components[i] is RectTransform) && !(components[i] is ComButtonEnbale) && !(components[i] is AssetProxy) && !(components[i] is CPooledGameObjectScript))
				{
					Object.Destroy(components[i]);
				}
			}
			if (this.imgBackGround != null)
			{
				this.imgBackGround.enabled = true;
			}
			Image component2 = this.objIconFashion.GetComponent<Image>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			this.ResetTextFont();
			this._Refresh();
		}

		// Token: 0x060095CF RID: 38351 RVA: 0x001C4A69 File Offset: 0x001C2E69
		private void ResetTextFont()
		{
			if (this.labCount != null)
			{
				this.labCount.fontSize = 35;
			}
		}

		// Token: 0x060095D0 RID: 38352 RVA: 0x001C4A89 File Offset: 0x001C2E89
		public void SetActive(bool active)
		{
			base.gameObject.CustomActive(active);
		}

		// Token: 0x060095D1 RID: 38353 RVA: 0x001C4A97 File Offset: 0x001C2E97
		public void SetEnable(bool a_enable)
		{
			if (this.m_bEnable != a_enable)
			{
				this.m_bEnable = a_enable;
				this.MarkDirty();
			}
		}

		// Token: 0x060095D2 RID: 38354 RVA: 0x001C4AB2 File Offset: 0x001C2EB2
		public void SetShowSelectState(bool a_bShow)
		{
			if (this.m_bShowSelectState != a_bShow)
			{
				this.m_bShowSelectState = a_bShow;
				this.MarkDirty();
			}
		}

		// Token: 0x060095D3 RID: 38355 RVA: 0x001C4ACD File Offset: 0x001C2ECD
		public void SetShowBetterState(bool a_bShow)
		{
			if (this.m_bShowBetterState != a_bShow)
			{
				this.m_bShowBetterState = a_bShow;
				this.MarkDirty();
			}
		}

		// Token: 0x060095D4 RID: 38356 RVA: 0x001C4AE8 File Offset: 0x001C2EE8
		public void SetShowUnusableState(bool a_bShow)
		{
			if (this.m_bShowUnusableState != a_bShow)
			{
				this.m_bShowUnusableState = a_bShow;
				this.MarkDirty();
			}
		}

		// Token: 0x060095D5 RID: 38357 RVA: 0x001C4B03 File Offset: 0x001C2F03
		public void SetShowRedPoint(bool isShow)
		{
			if (this.m_bShowRedPoint != isShow)
			{
				this.m_bShowRedPoint = isShow;
				this.MarkDirty();
			}
		}

		// Token: 0x060095D6 RID: 38358 RVA: 0x001C4B1E File Offset: 0x001C2F1E
		public void SetShowTreasure(bool isShow)
		{
			if (this.m_bShowTreasureState != isShow)
			{
				this.m_bShowTreasureState = isShow;
				this.MarkDirty();
			}
		}

		// Token: 0x060095D7 RID: 38359 RVA: 0x001C4B39 File Offset: 0x001C2F39
		public void SetShowNotEnoughState(bool a_bShow)
		{
			if (this.m_bShowNotEnoughState != a_bShow)
			{
				this.m_bShowNotEnoughState = a_bShow;
				this.MarkDirty();
			}
		}

		// Token: 0x060095D8 RID: 38360 RVA: 0x001C4B54 File Offset: 0x001C2F54
		public void SetupSlot(ComItem.ESlotType a_eSlotType, string a_strSlotName, ComItem.OnSlotClicked a_slotClicked = null, string lockMaskPath = "")
		{
			this.m_eSlotType = a_eSlotType;
			this.m_strSlotName = a_strSlotName;
			this.m_slotCallback = a_slotClicked;
			if (string.IsNullOrEmpty(lockMaskPath))
			{
				this.m_lockMaskPath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Suotou";
			}
			else
			{
				this.m_lockMaskPath = lockMaskPath;
			}
			this.MarkDirty();
		}

		// Token: 0x060095D9 RID: 38361 RVA: 0x001C4BA0 File Offset: 0x001C2FA0
		public void Setup(ItemData item, ComItem.OnItemClicked callback)
		{
			this.m_item = item;
			if (item != null)
			{
				if (item.GUID != 0UL)
				{
					base.gameObject.name = item.GUID.ToString();
				}
				else
				{
					base.gameObject.name = item.TableID.ToString();
				}
			}
			else
			{
				base.gameObject.name = "item";
			}
			this.m_callback = callback;
			this.MarkDirty();
		}

		// Token: 0x060095DA RID: 38362 RVA: 0x001C4C29 File Offset: 0x001C3029
		public void SetCountFormatter(ComItem.CountFormatter a_formatter)
		{
			this.m_countFormatter = a_formatter;
			this.MarkDirty();
		}

		// Token: 0x060095DB RID: 38363 RVA: 0x001C4C38 File Offset: 0x001C3038
		public void MarkDirty()
		{
			this.m_dirty = true;
		}

		// Token: 0x060095DC RID: 38364 RVA: 0x001C4C41 File Offset: 0x001C3041
		private void Start()
		{
			this.MarkDirty();
			this.Update();
		}

		// Token: 0x060095DD RID: 38365 RVA: 0x001C4C4F File Offset: 0x001C304F
		private void Update()
		{
			if (this.m_dirty)
			{
				this._Refresh();
				this.m_dirty = false;
			}
			if (this.m_item != null)
			{
				this._UpdateCD();
			}
		}

		// Token: 0x060095DE RID: 38366 RVA: 0x001C4C7C File Offset: 0x001C307C
		private void OnDestroy()
		{
			if (null != this.btnIcon)
			{
				this.btnIcon.image.sprite = null;
				this.btnIcon = null;
			}
			if (null != this.btnSelectGroup)
			{
				this.btnSelectGroup.image.sprite = null;
				this.btnSelectGroup = null;
			}
			if (null != this.imgBackGround)
			{
				this.imgBackGround.sprite = null;
				this.imgBackGround = null;
			}
			if (null != this.imgBetterArrow)
			{
				this.imgBetterArrow.sprite = null;
				this.imgBetterArrow = null;
			}
			if (null != this.imgPunishArrow)
			{
				this.imgPunishArrow.sprite = null;
				this.imgPunishArrow = null;
			}
			if (null != this.imgNewMark)
			{
				this.imgNewMark.sprite = null;
				this.imgNewMark = null;
			}
			if (null != this.imgSelect)
			{
				this.imgSelect.sprite = null;
				this.imgSelect = null;
			}
			if (null != this.imgSeal)
			{
				this.imgSeal.sprite = null;
				this.imgSeal = null;
			}
			if (null != this.imgRedPoint)
			{
				this.imgRedPoint.sprite = null;
				this.imgRedPoint = null;
			}
			this.labCount = null;
			this.labStrengthenLevel = null;
			this.labSlot = null;
			this.labLevel = null;
		}

		// Token: 0x060095DF RID: 38367 RVA: 0x001C4DF3 File Offset: 0x001C31F3
		protected void _Refresh()
		{
			this._UpdateSlotGroup();
			this._UpdateItemGroup();
			this._UpdateEnable();
		}

		// Token: 0x060095E0 RID: 38368 RVA: 0x001C4E08 File Offset: 0x001C3208
		private void _UpdateSlotGroup()
		{
			if (this.m_item == null)
			{
				if (this.objSlotGroup != null)
				{
					this.objSlotGroup.CustomActive(true);
				}
				if (this.m_eSlotType == ComItem.ESlotType.Locked && this.imgLockMask != null)
				{
					this.imgLockMask.SafeSetImage(this.m_lockMaskPath, false);
					this.imgLockMask.SetNativeSize();
				}
				if (this.btnSlotLocked != null)
				{
					this.btnSlotLocked.CustomActive(this.m_eSlotType == ComItem.ESlotType.Locked);
					this.btnSlotLocked.onClick.RemoveAllListeners();
					if (this.btnSlotLocked.image != null)
					{
						if (this.m_slotCallback != null)
						{
							this.btnSlotLocked.image.raycastTarget = true;
							if (base.gameObject != null)
							{
								this.btnSlotLocked.onClick.AddListener(delegate()
								{
									if (this.m_slotCallback != null)
									{
										this.m_slotCallback(base.gameObject);
									}
								});
							}
						}
						else
						{
							this.btnSlotLocked.image.raycastTarget = false;
						}
					}
				}
				if (this.labSlot != null)
				{
					if (!string.IsNullOrEmpty(this.m_strSlotName))
					{
						this.labSlot.CustomActive(true);
						this.labSlot.text = this.m_strSlotName;
					}
					else
					{
						this.labSlot.CustomActive(false);
					}
				}
			}
			else if (this.objSlotGroup != null)
			{
				this.objSlotGroup.CustomActive(false);
			}
		}

		// Token: 0x060095E1 RID: 38369 RVA: 0x001C4F94 File Offset: 0x001C3394
		private void _UpdateItemGroup()
		{
			if (this.m_item != null)
			{
				if (this.objItemGroup != null)
				{
					this.objItemGroup.CustomActive(true);
				}
				this._UpdateBackground();
				this._UpdateIcon();
				this._UpdateCount();
				this._UpdateLevel();
				this._UpdateStrengthenLevel();
				this._UpdateStrengthenImg();
				this._UpdateUnusableMask();
				this._UpdateShowNotEnoughState();
				this._UpdateCD();
				this._UpdateBetterEquipHint();
				this._UpdatePunishEquipHint();
				this._UpdateSelectState();
				this._UpdateNewEffect();
				this._UpdateTimeLimit();
				this._UpdateSeal();
				this.UpdateWeaponFlag();
				this.UpdateRedPoint();
				this.UpdateEquipLock();
				this.UpdateStrengthLock();
				this._UpdateTreasure();
				this._UpdateBreathMark();
				this.UpdateEquipPlanFlag();
			}
			else if (this.objItemGroup != null)
			{
				this.objItemGroup.CustomActive(false);
			}
		}

		// Token: 0x060095E2 RID: 38370 RVA: 0x001C5070 File Offset: 0x001C3470
		private void _UpdateBackground()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.imgBackGround != null)
			{
				this.imgBackGround.CustomActive(true);
				ItemData.QualityInfo qualityInfo = this.m_item.GetQualityInfo();
				if (qualityInfo != null)
				{
					ETCImageLoader.LoadSprite(ref this.imgBackGround, qualityInfo.Background, true);
				}
			}
		}

		// Token: 0x060095E3 RID: 38371 RVA: 0x001C50CC File Offset: 0x001C34CC
		private void UpdateWeaponFlag()
		{
			this.weaponIcon.CustomActive(!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SmithShopNewFrame>(null) && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PackageNewFrame>(null));
			if (this.m_item.isInSidePack)
			{
				ETCImageLoader.LoadSprite(ref this.weaponIcon, this.sideWeaponIconPath, true);
			}
			else
			{
				ulong mainWeapon = DataManager<ItemDataManager>.GetInstance().GetMainWeapon();
				if (mainWeapon != 0UL && mainWeapon == this.m_item.GUID)
				{
					ETCImageLoader.LoadSprite(ref this.weaponIcon, this.mainWeaponIconPath, true);
				}
				else
				{
					this.weaponIcon.CustomActive(false);
				}
			}
		}

		// Token: 0x060095E4 RID: 38372 RVA: 0x001C5172 File Offset: 0x001C3572
		private void ItemQuickTool()
		{
		}

		// Token: 0x060095E5 RID: 38373 RVA: 0x001C5174 File Offset: 0x001C3574
		private void _UpdateIcon()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.btnIcon != null)
			{
				this.btnIcon.CustomActive(true);
				Image image = this.btnIcon.image;
				ETCImageLoader.LoadSprite(ref image, this.m_item.Icon, true);
				UIGray componentInParent = base.GetComponentInParent<UIGray>();
				if (componentInParent != null)
				{
					UIGray.Refresh(componentInParent);
				}
				this.btnIcon.onClick.RemoveAllListeners();
				if (this.m_callback != null)
				{
					this.btnIcon.image.raycastTarget = true;
					this.btnIcon.onClick.AddListener(new UnityAction(this._OnClickCallBack));
					this.btnIcon.onClick.AddListener(new UnityAction(this.ItemQuickTool));
				}
				else
				{
					this.btnIcon.image.raycastTarget = false;
				}
				if (this.objIconFashion != null)
				{
					this.objIconFashion.CustomActive(this.m_item.Type == ItemTable.eType.FASHION);
				}
			}
		}

		// Token: 0x060095E6 RID: 38374 RVA: 0x001C5287 File Offset: 0x001C3687
		private void _OnClickCallBack()
		{
			if (this.m_callback != null)
			{
				this.m_callback(base.gameObject, this.m_item);
			}
		}

		// Token: 0x060095E7 RID: 38375 RVA: 0x001C52AC File Offset: 0x001C36AC
		private void _UpdateCount()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.labCount != null)
			{
				if (this.m_countFormatter != null)
				{
					this.labCount.CustomActive(true);
					this.labCount.text = this.m_countFormatter(this);
				}
				else if (this.m_item.Count > 1)
				{
					this.labCount.CustomActive(true);
					this.labCount.text = this.m_item.Count.ToString();
				}
				else
				{
					this.labCount.CustomActive(false);
				}
			}
		}

		// Token: 0x060095E8 RID: 38376 RVA: 0x001C5358 File Offset: 0x001C3758
		private void _UpdateLevel()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.labLevel != null)
			{
				if (this.m_item.Type == ItemTable.eType.EQUIP && this.m_item.LevelLimit > 0)
				{
					this.labLevel.gameObject.CustomActive(true);
					this.labLevel.text = string.Format("Lv.{0}", this.m_item.LevelLimit);
					if (this.m_item.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						if (this.m_item.PackageType == EPackageType.Equip || this.m_item.PackageType == EPackageType.Storage || this.m_item.PackageType == EPackageType.RoleStorage)
						{
							this.labLevel.color = Color.red;
						}
						else
						{
							this.labLevel.color = Color.white;
						}
					}
					else
					{
						this.labLevel.color = Color.white;
					}
				}
				else
				{
					this.labLevel.color = Color.white;
					this.labLevel.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x060095E9 RID: 38377 RVA: 0x001C5488 File Offset: 0x001C3888
		public void _UpdateTreasure()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.objTreasure != null)
			{
				this.objTreasure.CustomActive(false);
				this.objTreasure.CustomActive(this.m_bShowTreasureState);
			}
		}

		// Token: 0x060095EA RID: 38378 RVA: 0x001C54C4 File Offset: 0x001C38C4
		public void _UpdateBreathMark()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.objBreathMark != null)
			{
				this.objBreathMark.CustomActive(this.m_item.EquipType == EEquipType.ET_BREATH);
			}
		}

		// Token: 0x060095EB RID: 38379 RVA: 0x001C54FC File Offset: 0x001C38FC
		private void _UpdateStrengthenLevel()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.labStrengthenLevel != null)
			{
				if (this.m_item.SubType == 25)
				{
					if (this.m_item.mPrecEnchantmentCard.iEnchantmentCardLevel > 0)
					{
						this.labStrengthenLevel.CustomActive(true);
						this.labStrengthenLevel.text = string.Format("+{0}", this.m_item.mPrecEnchantmentCard.iEnchantmentCardLevel);
					}
					else
					{
						this.labStrengthenLevel.CustomActive(false);
					}
					return;
				}
				this.labStrengthenLevel.CustomActive(false);
			}
		}

		// Token: 0x060095EC RID: 38380 RVA: 0x001C55A4 File Offset: 0x001C39A4
		private void _UpdateStrengthenImg()
		{
			if (this.m_item == null)
			{
				return;
			}
			this.objStrengthen.CustomActive(false);
			if (this.m_item.Type == ItemTable.eType.EQUIP)
			{
				if (this.m_item.EquipType == EEquipType.ET_COMMON)
				{
					if (this.m_item.StrengthenLevel > 0)
					{
						ETCImageLoader.LoadSprite(ref this.imgStrengthAdd, this.sStrengthenAddIconPath, true);
						if (this.m_item.StrengthenLevel >= 10)
						{
							this.imgStrengthen2.CustomActive(true);
							int num = this.m_item.StrengthenLevel % 10;
							int num2 = this.m_item.StrengthenLevel / 10;
							ETCImageLoader.LoadSprite(ref this.imgStrengthen2, string.Format(this.sStrengthenNumberIconPath, num), true);
							ETCImageLoader.LoadSprite(ref this.imgStrengthen1, string.Format(this.sStrengthenNumberIconPath, num2), true);
						}
						else
						{
							ETCImageLoader.LoadSprite(ref this.imgStrengthen1, string.Format(this.sStrengthenNumberIconPath, this.m_item.StrengthenLevel), true);
							this.imgStrengthen2.CustomActive(false);
						}
						this.objStrengthen.CustomActive(true);
					}
				}
				else if (this.m_item.EquipType == EEquipType.ET_REDMARK)
				{
					ETCImageLoader.LoadSprite(ref this.imgStrengthAdd, this.sGrowthAddIconPath, true);
					if (this.m_item.StrengthenLevel >= 10)
					{
						this.imgStrengthen2.CustomActive(true);
						int num3 = this.m_item.StrengthenLevel % 10;
						int num4 = this.m_item.StrengthenLevel / 10;
						ETCImageLoader.LoadSprite(ref this.imgStrengthen2, string.Format(this.sGrowthNumberIconPath, num3), true);
						ETCImageLoader.LoadSprite(ref this.imgStrengthen1, string.Format(this.sGrowthNumberIconPath, num4), true);
					}
					else
					{
						ETCImageLoader.LoadSprite(ref this.imgStrengthen1, string.Format(this.sGrowthNumberIconPath, this.m_item.StrengthenLevel), true);
						this.imgStrengthen2.CustomActive(false);
					}
					this.objStrengthen.CustomActive(true);
				}
			}
		}

		// Token: 0x060095ED RID: 38381 RVA: 0x001C57B4 File Offset: 0x001C3BB4
		private void _UpdateSelectState()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.btnSelectGroup != null && this.imgSelect != null && this.m_bShowSelectState)
			{
				this.btnSelectGroup.gameObject.CustomActive(true);
				this.btnSelectGroup.onClick.RemoveAllListeners();
				if (this.m_callback != null)
				{
					this.btnSelectGroup.image.raycastTarget = true;
					this.btnSelectGroup.onClick.AddListener(delegate()
					{
						this.m_callback(base.gameObject, this.m_item);
					});
					this.btnSelectGroup.onClick.AddListener(new UnityAction(this.ItemQuickTool));
				}
				else
				{
					this.btnSelectGroup.image.raycastTarget = false;
				}
				this.imgSelect.gameObject.CustomActive(this.m_item.IsSelected);
				return;
			}
			if (this.btnSelectGroup != null)
			{
				this.btnSelectGroup.gameObject.CustomActive(false);
			}
			if (this.imgSelect != null)
			{
				this.imgSelect.gameObject.CustomActive(false);
			}
		}

		// Token: 0x060095EE RID: 38382 RVA: 0x001C58E8 File Offset: 0x001C3CE8
		private void _UpdateNewEffect()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.imgNewMark != null)
			{
				if (this.m_item.IsNew)
				{
					this.imgNewMark.gameObject.CustomActive(true);
					DataManager<ItemDataManager>.GetInstance().NotifyItemBeOld(this.m_item);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.PackageMain, null, null, null);
				}
				else
				{
					this.imgNewMark.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x060095EF RID: 38383 RVA: 0x001C5970 File Offset: 0x001C3D70
		private void _UpdateTimeLimit()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.objTimeLimit != null)
			{
				int num;
				bool flag;
				this.m_item.GetTimeLeft(out num, out flag);
				if ((this.imgNewMark == null || !this.imgNewMark.gameObject.activeSelf) && ((flag && num > 0) || this.m_item.IsTimeLimit))
				{
					this.objTimeLimit.CustomActive(true);
					DataManager<ItemDataManager>.GetInstance().NotifyItemBeOld(this.m_item);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.PackageMain, null, null, null);
				}
				else
				{
					this.objTimeLimit.CustomActive(false);
				}
			}
		}

		// Token: 0x060095F0 RID: 38384 RVA: 0x001C5A30 File Offset: 0x001C3E30
		private void _UpdateEnable()
		{
			ComButtonEnbale component = base.GetComponent<ComButtonEnbale>();
			if (component != null)
			{
				component.SetEnable(this.m_bEnable);
			}
		}

		// Token: 0x060095F1 RID: 38385 RVA: 0x001C5A5C File Offset: 0x001C3E5C
		private void _UpdateSeal()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.imgSeal != null)
			{
				if (this.m_item.Packing)
				{
					this.imgSeal.gameObject.CustomActive(true);
				}
				else
				{
					this.imgSeal.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x060095F2 RID: 38386 RVA: 0x001C5AC0 File Offset: 0x001C3EC0
		private void UpdateEquipLock()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.imgLock == null)
			{
				return;
			}
			this.imgLock.CustomActive(this.m_item.bLocked || this.m_item.IsLease || this.m_item.bFashionItemLocked);
		}

		// Token: 0x060095F3 RID: 38387 RVA: 0x001C5B24 File Offset: 0x001C3F24
		private void UpdateStrengthLock()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.imgLock == null)
			{
				return;
			}
			this.imgStrengthLock.CustomActive(false);
			if (this.m_item.SubType == 33)
			{
				this.imgStrengthLock.CustomActive(this.m_item.BindAttr != ItemTable.eOwner.NOTBIND);
			}
		}

		// Token: 0x060095F4 RID: 38388 RVA: 0x001C5B8C File Offset: 0x001C3F8C
		private void UpdateRedPoint()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.imgRedPoint != null)
			{
				if (this.m_bShowRedPoint)
				{
					if (DataManager<PackageDataManager>.GetInstance() != null && DataManager<PackageDataManager>.GetInstance().IsItemShowRedPoint(this.m_item))
					{
						this.imgRedPoint.CustomActive(true);
					}
					else
					{
						this.imgRedPoint.CustomActive(false);
					}
				}
				else
				{
					this.imgRedPoint.CustomActive(false);
				}
			}
		}

		// Token: 0x060095F5 RID: 38389 RVA: 0x001C5C10 File Offset: 0x001C4010
		private void _UpdateUnusableMask()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.btnIcon != null)
			{
				if (this.m_bShowUnusableState)
				{
					this.btnIcon.image.color = Color.white;
					Color color;
					color..ctor(0.8627451f, 0f, 0f, 0.5882353f);
					if (this.m_item.Type == ItemTable.eType.EXPENDABLE)
					{
						if (!this.m_item.IsLevelFit() || !this.m_item.IsOccupationFit())
						{
							this.btnIcon.image.color = color;
						}
					}
					else if ((this.m_item.Type == ItemTable.eType.EQUIP || this.m_item.Type == ItemTable.eType.FASHION) && !this.m_item.CanEquip())
					{
						this.btnIcon.image.color = color;
					}
				}
				else
				{
					this.btnIcon.image.color = Color.white;
				}
			}
		}

		// Token: 0x060095F6 RID: 38390 RVA: 0x001C5D1C File Offset: 0x001C411C
		private void _UpdateShowNotEnoughState()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.btnIcon != null)
			{
				if (this.m_bShowNotEnoughState)
				{
					Graphic graphic = this.imgBackGround;
					Color color = Color.gray;
					this.btnIcon.image.color = color;
					graphic.color = color;
				}
				else
				{
					Graphic graphic2 = this.imgBackGround;
					Color color = Color.white;
					this.btnIcon.image.color = color;
					graphic2.color = color;
				}
			}
		}

		// Token: 0x060095F7 RID: 38391 RVA: 0x001C5D9C File Offset: 0x001C419C
		private void _UpdateCD()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.imgCD != null)
			{
				ItemCD itemCD = DataManager<ItemDataManager>.GetInstance().GetItemCD(this.m_item.CDGroupID);
				if (itemCD != null)
				{
					double num = itemCD.endtime;
					double num2 = num - DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
					if (num2 >= 0.0)
					{
						this.imgCD.gameObject.CustomActive(true);
						this.imgCD.fillAmount = (float)(num2 / itemCD.maxtime);
						this.imgCD.type = 3;
						this.imgCD.fillMethod = 4;
						this.imgCD.fillClockwise = false;
						return;
					}
				}
				this.imgCD.gameObject.CustomActive(false);
			}
		}

		// Token: 0x060095F8 RID: 38392 RVA: 0x001C5E64 File Offset: 0x001C4264
		private void _UpdatePunishEquipHint()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (null != this.imgPunishArrow)
			{
				if (this.m_item.PackageType == EPackageType.WearEquip)
				{
					bool bActive = DataManager<EquipMasterDataManager>.GetInstance().IsPunish(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.m_item.Quality, (int)this.m_item.EquipWearSlotType, (int)this.m_item.ThirdType);
					this.imgPunishArrow.CustomActive(bActive);
				}
				else
				{
					this.imgPunishArrow.CustomActive(false);
				}
			}
		}

		// Token: 0x060095F9 RID: 38393 RVA: 0x001C5EF4 File Offset: 0x001C42F4
		private void _UpdateBetterEquipHint()
		{
			if (this.m_item == null)
			{
				return;
			}
			if (this.imgBetterArrow != null)
			{
				if (this.m_bShowBetterState)
				{
					if (this.m_item.CheckBetterThanEquip())
					{
						this.imgBetterArrow.gameObject.CustomActive(true);
					}
					else
					{
						this.imgBetterArrow.gameObject.CustomActive(false);
					}
				}
				else
				{
					this.imgBetterArrow.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x060095FA RID: 38394 RVA: 0x001C5F76 File Offset: 0x001C4376
		public void SetLabCountIsShow(bool isShow)
		{
			if (this.labCount != null)
			{
				this.labCount.gameObject.CustomActive(isShow);
			}
		}

		// Token: 0x060095FB RID: 38395 RVA: 0x001C5F9C File Offset: 0x001C439C
		private void UpdateEquipPlanFlag()
		{
			if (this.equipPlanRoot == null)
			{
				return;
			}
			this.equipPlanRoot.CustomActive(false);
			int num = 1;
			if (!EquipPlanUtility.IsNeedShowUnUsedEquipPlanFlag(this.m_item, ref num))
			{
				this.equipPlanRoot.CustomActive(false);
			}
			else
			{
				this.equipPlanRoot.CustomActive(true);
				string path = this.equipPlanOnePath;
				if (num == 2)
				{
					path = this.equipPlanTwoPath;
				}
				ETCImageLoader.LoadSprite(ref this.equipPlanImage, path, true);
			}
		}

		// Token: 0x04004CA7 RID: 19623
		public GameObject objSlotGroup;

		// Token: 0x04004CA8 RID: 19624
		public Image imgBackGround;

		// Token: 0x04004CA9 RID: 19625
		public Button btnSlotLocked;

		// Token: 0x04004CAA RID: 19626
		public Text labSlot;

		// Token: 0x04004CAB RID: 19627
		public GameObject objItemGroup;

		// Token: 0x04004CAC RID: 19628
		public Button btnIcon;

		// Token: 0x04004CAD RID: 19629
		public GameObject objIconFashion;

		// Token: 0x04004CAE RID: 19630
		public Text labCount;

		// Token: 0x04004CAF RID: 19631
		public Text labStrengthenLevel;

		// Token: 0x04004CB0 RID: 19632
		public Text labLevel;

		// Token: 0x04004CB1 RID: 19633
		public Image imgSeal;

		// Token: 0x04004CB2 RID: 19634
		public Image imgBetterArrow;

		// Token: 0x04004CB3 RID: 19635
		public Image imgPunishArrow;

		// Token: 0x04004CB4 RID: 19636
		public Image imgNewMark;

		// Token: 0x04004CB5 RID: 19637
		public Button btnSelectGroup;

		// Token: 0x04004CB6 RID: 19638
		public Image imgSelect;

		// Token: 0x04004CB7 RID: 19639
		public Image imgCD;

		// Token: 0x04004CB8 RID: 19640
		public GameObject objTimeLimit;

		// Token: 0x04004CB9 RID: 19641
		public Image weaponIcon;

		// Token: 0x04004CBA RID: 19642
		public Image imgRedPoint;

		// Token: 0x04004CBB RID: 19643
		public Image imgLock;

		// Token: 0x04004CBC RID: 19644
		public Image imgStrengthLock;

		// Token: 0x04004CBD RID: 19645
		public GameObject objTreasure;

		// Token: 0x04004CBE RID: 19646
		public GameObject objBreathMark;

		// Token: 0x04004CBF RID: 19647
		public Image imgStrengthAdd;

		// Token: 0x04004CC0 RID: 19648
		public Image imgStrengthen1;

		// Token: 0x04004CC1 RID: 19649
		public Image imgStrengthen2;

		// Token: 0x04004CC2 RID: 19650
		public GameObject objStrengthen;

		// Token: 0x04004CC3 RID: 19651
		public GameObject equipPlanRoot;

		// Token: 0x04004CC4 RID: 19652
		public Image equipPlanImage;

		// Token: 0x04004CC6 RID: 19654
		public Image imgLockMask;

		// Token: 0x04004CC7 RID: 19655
		private const string defaultLockMaskImgPath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Suotou";

		// Token: 0x04004CC8 RID: 19656
		private bool m_needRecycle;

		// Token: 0x04004CC9 RID: 19657
		private bool m_dirty;

		// Token: 0x04004CCA RID: 19658
		private ItemData m_item;

		// Token: 0x04004CCB RID: 19659
		private ComItem.OnSlotClicked m_slotCallback;

		// Token: 0x04004CCC RID: 19660
		private ComItem.OnItemClicked m_callback;

		// Token: 0x04004CCD RID: 19661
		private ComItem.CountFormatter m_countFormatter;

		// Token: 0x04004CCE RID: 19662
		private ComItem.ESlotType m_eSlotType = ComItem.ESlotType.Opened;

		// Token: 0x04004CCF RID: 19663
		private string m_lockMaskPath;

		// Token: 0x04004CD0 RID: 19664
		private string m_strSlotName;

		// Token: 0x04004CD1 RID: 19665
		private bool m_bEnable = true;

		// Token: 0x04004CD2 RID: 19666
		private bool m_bShowSelectState;

		// Token: 0x04004CD3 RID: 19667
		private bool m_bShowBetterState;

		// Token: 0x04004CD4 RID: 19668
		private bool m_bShowUnusableState;

		// Token: 0x04004CD5 RID: 19669
		private bool m_bShowNotEnoughState;

		// Token: 0x04004CD6 RID: 19670
		private bool m_bShowRedPoint;

		// Token: 0x04004CD7 RID: 19671
		private bool m_bShowTreasureState;

		// Token: 0x04004CD8 RID: 19672
		private string sideWeaponIconPath = "UI/Image/Packed/p_UI_Package.png:UI_Package_Tubiao_Fu";

		// Token: 0x04004CD9 RID: 19673
		private string mainWeaponIconPath = "UI/Image/Packed/p_UI_Package.png:UI_Package_Tubiao_Zhu";

		// Token: 0x04004CDA RID: 19674
		private string sStrengthenAddIconPath = "UI/Image/Packed/p_UI_QiangHua.png:Number_Y_+";

		// Token: 0x04004CDB RID: 19675
		private string sGrowthAddIconPath = "UI/Image/Packed/p_UI_QiangHua.png:Number_J_+";

		// Token: 0x04004CDC RID: 19676
		private string sStrengthenNumberIconPath = "UI/Image/Packed/p_UI_QiangHua.png:Number_Y_{0}";

		// Token: 0x04004CDD RID: 19677
		private string sGrowthNumberIconPath = "UI/Image/Packed/p_UI_QiangHua.png:Number_J_{0}";

		// Token: 0x04004CDE RID: 19678
		private string equipPlanOnePath = "UI/Image/Packed/p_UI_Package.png:UI_Package_Tubiao_01";

		// Token: 0x04004CDF RID: 19679
		private string equipPlanTwoPath = "UI/Image/Packed/p_UI_Package.png:UI_Package_Tubiao_02";

		// Token: 0x02000EF6 RID: 3830
		// (Invoke) Token: 0x060095FF RID: 38399
		public delegate void OnSlotClicked(GameObject obj);

		// Token: 0x02000EF7 RID: 3831
		// (Invoke) Token: 0x06009603 RID: 38403
		public delegate void OnItemClicked(GameObject obj, ItemData item);

		// Token: 0x02000EF8 RID: 3832
		// (Invoke) Token: 0x06009607 RID: 38407
		public delegate string CountFormatter(ComItem a_comItem);

		// Token: 0x02000EF9 RID: 3833
		public enum EColorType
		{
			// Token: 0x04004CE1 RID: 19681
			Grey,
			// Token: 0x04004CE2 RID: 19682
			Normal
		}

		// Token: 0x02000EFA RID: 3834
		public enum ESlotType
		{
			// Token: 0x04004CE4 RID: 19684
			Locked,
			// Token: 0x04004CE5 RID: 19685
			Opened
		}
	}
}
