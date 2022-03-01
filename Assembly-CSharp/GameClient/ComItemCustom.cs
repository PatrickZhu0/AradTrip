using System;
using System.Collections.Generic;
using Parser;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BC1 RID: 7105
	[ExecuteInEditMode]
	public class ComItemCustom : MonoBehaviour, IComItemCustom
	{
		// Token: 0x17001DAB RID: 7595
		// (get) Token: 0x06011608 RID: 71176 RVA: 0x00508D56 File Offset: 0x00507156
		public ItemData M_ItemData
		{
			get
			{
				return this.m_ItemData;
			}
		}

		// Token: 0x06011609 RID: 71177 RVA: 0x00508D60 File Offset: 0x00507160
		private void Start()
		{
			if (this.m_CustomItemIconBtn)
			{
				this.m_CustomItemIconBtn.onClick.AddListener(new UnityAction(this._OnItemBtnClick));
			}
			if (this.m_CustomItemToggle)
			{
				this.m_CustomItemToggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnItemToggleClick));
				if (this.m_CustomItemToggleGroup)
				{
					this.m_CustomItemToggle.group = this.m_CustomItemToggleGroup;
				}
			}
			if (this.m_ExtendImgs != null)
			{
				for (int i = 0; i < this.m_ExtendImgs.Count; i++)
				{
					this.m_ExtendImgs[i].CustomActive(true);
					this.m_ExtendImgs[i].enabled = false;
				}
			}
			if (this.m_ExtendBtn_1)
			{
				this.m_ExtendBtn_1.onClick.AddListener(new UnityAction(this._OnExtendBtn1Click));
			}
		}

		// Token: 0x0601160A RID: 71178 RVA: 0x00508E60 File Offset: 0x00507260
		private void OnDestroy()
		{
			if (this.m_CustomItemIconBtn)
			{
				this.m_CustomItemIconBtn.onClick.RemoveListener(new UnityAction(this._OnItemBtnClick));
			}
			if (this.m_CustomItemToggle)
			{
				this.m_CustomItemToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnItemToggleClick));
			}
			if (this.m_ExtendBtn_1)
			{
				this.m_ExtendBtn_1.onClick.RemoveListener(new UnityAction(this._OnExtendBtn1Click));
			}
			this.Clear();
		}

		// Token: 0x0601160B RID: 71179 RVA: 0x00508EF8 File Offset: 0x005072F8
		private void _Init()
		{
			ComItemCustomClickType clickType = this.m_ClickType;
			if (clickType != ComItemCustomClickType.Button)
			{
				if (clickType != ComItemCustomClickType.Toggle)
				{
					if (this.m_CustomItemIconBtn)
					{
						this.m_CustomItemIconBtn.enabled = false;
						this.m_CustomItemIconBtn.targetGraphic.enabled = false;
					}
					if (this.m_CustomItemToggle)
					{
						this.m_CustomItemToggle.isOn = false;
						this.m_CustomItemToggle.enabled = false;
						this.m_CustomItemToggle.targetGraphic.enabled = false;
					}
				}
				else
				{
					if (this.m_CustomItemToggle)
					{
						this.m_CustomItemToggle.isOn = false;
						this.m_CustomItemToggle.enabled = true;
						this.m_CustomItemToggle.targetGraphic.enabled = true;
					}
					if (this.m_CustomItemIconBtn)
					{
						this.m_CustomItemIconBtn.enabled = false;
						this.m_CustomItemIconBtn.targetGraphic.enabled = false;
					}
				}
			}
			else
			{
				if (this.m_CustomItemIconBtn)
				{
					this.m_CustomItemIconBtn.enabled = true;
					this.m_CustomItemIconBtn.targetGraphic.enabled = true;
				}
				if (this.m_CustomItemToggle)
				{
					this.m_CustomItemToggle.isOn = false;
					this.m_CustomItemToggle.enabled = false;
					this.m_CustomItemToggle.targetGraphic.enabled = false;
				}
			}
			this.SetCustomItemSelectActive(false);
			this.SetExtendImgsActive(null);
			this.SetExtendBtn1ShowAndEnable(false, false);
			this._SetCustomItemImg();
			this._SetCustomItemCount();
			this._SetCustomItemDesc();
			this._SetCustomItemBindLockImgShow();
		}

		// Token: 0x0601160C RID: 71180 RVA: 0x0050908E File Offset: 0x0050748E
		private void _OnItemBtnClick()
		{
			if (this.bItemShowTipEnable)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(this.m_ItemData, null, 4, true, false, true);
			}
			else if (this.onItemBtnClick != null)
			{
				this.onItemBtnClick();
			}
		}

		// Token: 0x0601160D RID: 71181 RVA: 0x005090CB File Offset: 0x005074CB
		private void _OnItemToggleClick(bool isOn)
		{
			if (this.onTitleToggleClick != null)
			{
				this.onTitleToggleClick(isOn);
			}
		}

		// Token: 0x0601160E RID: 71182 RVA: 0x005090E4 File Offset: 0x005074E4
		private void _OnExtendBtn1Click()
		{
			if (this.onExtendBtn1Click != null)
			{
				this.onExtendBtn1Click();
			}
		}

		// Token: 0x0601160F RID: 71183 RVA: 0x005090FC File Offset: 0x005074FC
		private void SetNameColorByQuality()
		{
			if (this.m_ItemData == null)
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.m_ItemData.TableID, string.Empty, string.Empty);
			if (this.m_CustomItemDesc == null)
			{
				return;
			}
			string arg = "white";
			if (tableItem != null)
			{
				arg = ItemParser.GetItemColor(tableItem);
			}
			string text = this.m_CustomItemDesc.text;
			this.m_CustomItemDesc.text = string.Format("<color={0}>", arg) + text + "</color>";
		}

		// Token: 0x06011610 RID: 71184 RVA: 0x00509188 File Offset: 0x00507588
		private void _SetCustomItemCount()
		{
			string text = string.Empty;
			if (this.bInitHideCount)
			{
				text = string.Empty;
			}
			else if (this.m_ItemData != null && this.m_ItemData.Count > 1)
			{
				text = this.m_ItemData.Count.ToString();
			}
			if (this.m_CustomItemCount)
			{
				this.m_CustomItemCount.text = text;
			}
		}

		// Token: 0x06011611 RID: 71185 RVA: 0x00509200 File Offset: 0x00507600
		private void _SetCustomItemImg()
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (this.m_ItemData != null)
			{
				text = this.m_ItemData.GetQualityInfo().Background;
				text2 = this.m_ItemData.Icon;
			}
			if (this.m_CustomItemIconBgImg && !string.IsNullOrEmpty(text))
			{
				this.m_CustomItemIconBgImg.enabled = true;
				ETCImageLoader.LoadSprite(ref this.m_CustomItemIconBgImg, text, true);
			}
			if (this.m_CustomItemIconImg && !string.IsNullOrEmpty(text2))
			{
				this.m_CustomItemIconImg.enabled = true;
				ETCImageLoader.LoadSprite(ref this.m_CustomItemIconImg, text2, true);
			}
		}

		// Token: 0x06011612 RID: 71186 RVA: 0x005092AB File Offset: 0x005076AB
		private void _SetCustomItemDesc()
		{
			if (this.m_CustomItemDesc)
			{
				this.m_CustomItemDesc.CustomActive(this.hasBottomExtendDesc);
			}
		}

		// Token: 0x06011613 RID: 71187 RVA: 0x005092D0 File Offset: 0x005076D0
		private void _SetCustomItemBindLockImgShow()
		{
			if (this.m_CustomItemBindLockImg)
			{
				this.m_CustomItemBindLockImg.enabled = false;
				if (this.m_ItemData != null && this.m_ItemData.SubType == 33)
				{
					this.m_CustomItemBindLockImg.enabled = (this.m_ItemData.BindAttr != ItemTable.eOwner.NOTBIND);
				}
			}
		}

		// Token: 0x06011614 RID: 71188 RVA: 0x00509332 File Offset: 0x00507732
		public void Init(bool enableTips, ItemData itemData, bool bHideCount, bool hasBottomDesc, ComItemCustomClickType clickType)
		{
			this.Clear();
			this.bItemShowTipEnable = enableTips;
			this.bInitHideCount = bHideCount;
			this.hasBottomExtendDesc = hasBottomDesc;
			this.m_ClickType = clickType;
			this.m_ItemData = itemData;
			this._Init();
		}

		// Token: 0x06011615 RID: 71189 RVA: 0x00509368 File Offset: 0x00507768
		public void Init(bool enableTips, ItemSimpleData itemSData, bool bOwned, bool bHideCount, bool hasBottomDesc, ComItemCustomClickType clickType)
		{
			this.Clear();
			this.bItemShowTipEnable = enableTips;
			this.bInitHideCount = bHideCount;
			this.hasBottomExtendDesc = hasBottomDesc;
			this.m_ClickType = clickType;
			if (itemSData != null)
			{
				if (bOwned)
				{
					this.m_ItemData = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(itemSData.ItemID, true, true);
				}
				else
				{
					this.m_ItemData = ItemDataManager.CreateItemDataFromTable(itemSData.ItemID, 100, 0);
				}
			}
			this._Init();
		}

		// Token: 0x06011616 RID: 71190 RVA: 0x005093E0 File Offset: 0x005077E0
		public void Init(bool enableTips, int itemDataId, bool bOwned, bool bHideCount, bool hasBottomDesc, ComItemCustomClickType clickType)
		{
			this.Clear();
			this.bItemShowTipEnable = enableTips;
			this.bInitHideCount = bHideCount;
			this.hasBottomExtendDesc = hasBottomDesc;
			this.m_ClickType = clickType;
			if (bOwned)
			{
				this.m_ItemData = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(itemDataId, true, true);
			}
			else
			{
				this.m_ItemData = ItemDataManager.CreateItemDataFromTable(itemDataId, 100, 0);
			}
			this._Init();
		}

		// Token: 0x06011617 RID: 71191 RVA: 0x00509448 File Offset: 0x00507848
		public void Clear()
		{
			this.onItemBtnClick = null;
			this.onTitleToggleClick = null;
			this.onExtendBtn1Click = null;
			this.m_ItemData = null;
			this.bInitHideCount = false;
			this.hasBottomExtendDesc = false;
			this.bItemShowTipEnable = true;
			if (this.m_CustomItemIconBtn)
			{
				this.m_CustomItemIconBtn.enabled = false;
				this.m_CustomItemIconBtn.targetGraphic.enabled = false;
			}
			if (this.m_CustomItemToggle)
			{
				this.m_CustomItemToggle.isOn = false;
				this.m_CustomItemToggle.enabled = false;
				this.m_CustomItemToggle.targetGraphic.enabled = false;
			}
			if (this.m_CustomItemIconImg)
			{
				this.m_CustomItemIconImg.sprite = null;
				this.m_CustomItemIconImg.enabled = false;
			}
			if (this.m_CustomItemIconBgImg)
			{
				this.m_CustomItemIconBgImg.sprite = null;
				this.m_CustomItemIconBgImg.enabled = false;
			}
			if (this.m_CustomItemIconSelectImg)
			{
				this.m_CustomItemIconSelectImg.enabled = false;
			}
			if (this.m_CustomItemBindLockImg)
			{
				this.m_CustomItemBindLockImg.enabled = false;
			}
			if (this.m_CustomItemCount)
			{
				this.m_CustomItemCount.text = string.Empty;
			}
			if (this.m_CustomItemDesc)
			{
				this.m_CustomItemDesc.text = string.Empty;
			}
		}

		// Token: 0x06011618 RID: 71192 RVA: 0x005095B4 File Offset: 0x005079B4
		public void SetDescStr(string desc, bool isParser = true)
		{
			if (this.m_CustomItemDesc)
			{
				this.m_CustomItemDesc.text = desc;
				if (isParser)
				{
					this.SetNameColorByQuality();
				}
			}
		}

		// Token: 0x06011619 RID: 71193 RVA: 0x005095DE File Offset: 0x005079DE
		public void SetCustomItemSelectActive(bool bActive)
		{
			if (this.m_CustomItemIconSelectImg)
			{
				this.m_CustomItemIconSelectImg.enabled = bActive;
			}
		}

		// Token: 0x0601161A RID: 71194 RVA: 0x005095FC File Offset: 0x005079FC
		public void SetCustomItemCount(bool checkItemOne = true, string formatStr = "")
		{
			string text = string.Empty;
			if (this.bInitHideCount)
			{
				text = string.Empty;
			}
			else if (checkItemOne)
			{
				if (this.m_ItemData.Count == 1)
				{
					text = string.Empty;
				}
				else
				{
					text = this.m_ItemData.Count.ToString();
				}
			}
			else
			{
				text = formatStr;
			}
			if (this.m_CustomItemCount)
			{
				this.m_CustomItemCount.text = text;
			}
		}

		// Token: 0x0601161B RID: 71195 RVA: 0x00509681 File Offset: 0x00507A81
		public void SetCustomItemToggleOn(bool isOn)
		{
			if (this.m_ClickType == ComItemCustomClickType.Toggle && this.m_CustomItemToggle)
			{
				this.m_CustomItemToggle.isOn = isOn;
			}
		}

		// Token: 0x0601161C RID: 71196 RVA: 0x005096AB File Offset: 0x00507AAB
		public bool GetCustomItemToggleIsOn()
		{
			return this.m_CustomItemToggle && this.m_CustomItemToggle.isOn;
		}

		// Token: 0x0601161D RID: 71197 RVA: 0x005096CC File Offset: 0x00507ACC
		public void SetExtendImgsActive(List<int> activeIndexes = null)
		{
			if (this.m_ExtendImgs == null)
			{
				return;
			}
			for (int i = 0; i < this.m_ExtendImgs.Count; i++)
			{
				this.m_ExtendImgs[i].enabled = false;
			}
			if (activeIndexes != null)
			{
				for (int j = 0; j < activeIndexes.Count; j++)
				{
					int num = activeIndexes[j];
					if (num < this.m_ExtendImgs.Count)
					{
						this.m_ExtendImgs[num].enabled = true;
					}
				}
			}
		}

		// Token: 0x0601161E RID: 71198 RVA: 0x0050975C File Offset: 0x00507B5C
		public void SetExtendBtn1ShowAndEnable(bool bShow, bool bEnable)
		{
			if (this.m_ExtendBtn_1)
			{
				this.m_ExtendBtn_1.enabled = bEnable;
				this.m_ExtendBtn_1.targetGraphic.enabled = bShow;
			}
			if (this.m_ExtendBtnImg_1)
			{
				this.m_ExtendBtnImg_1.enabled = bEnable;
			}
		}

		// Token: 0x0400B458 RID: 46168
		public ComItemCustom.ItemBtnClickHandle onItemBtnClick;

		// Token: 0x0400B459 RID: 46169
		public ComItemCustom.ItemBtnClickHandle onExtendBtn1Click;

		// Token: 0x0400B45A RID: 46170
		public ComItemCustom.ItemToggleClickHandle onTitleToggleClick;

		// Token: 0x0400B45B RID: 46171
		public ComItemCustom.CountFormatter m_countFormatter;

		// Token: 0x0400B45C RID: 46172
		private ItemData m_ItemData;

		// Token: 0x0400B45D RID: 46173
		private bool bInitHideCount;

		// Token: 0x0400B45E RID: 46174
		private bool hasBottomExtendDesc;

		// Token: 0x0400B45F RID: 46175
		private bool bItemShowTipEnable = true;

		// Token: 0x0400B460 RID: 46176
		private ComItemCustomClickType m_ClickType;

		// Token: 0x0400B461 RID: 46177
		[SerializeField]
		private GameObject m_CustomItemDisplayObj;

		// Token: 0x0400B462 RID: 46178
		[SerializeField]
		private GameObject m_CustomItemEventObj;

		// Token: 0x0400B463 RID: 46179
		[SerializeField]
		private Image m_CustomItemIconBgImg;

		// Token: 0x0400B464 RID: 46180
		[SerializeField]
		private Image m_CustomItemIconImg;

		// Token: 0x0400B465 RID: 46181
		[SerializeField]
		private Image m_CustomItemIconSelectImg;

		// Token: 0x0400B466 RID: 46182
		[SerializeField]
		private Text m_CustomItemCount;

		// Token: 0x0400B467 RID: 46183
		[SerializeField]
		private Text m_CustomItemDesc;

		// Token: 0x0400B468 RID: 46184
		[SerializeField]
		private Image m_CustomItemBindLockImg;

		// Token: 0x0400B469 RID: 46185
		[SerializeField]
		private Button m_CustomItemIconBtn;

		// Token: 0x0400B46A RID: 46186
		[SerializeField]
		private Toggle m_CustomItemToggle;

		// Token: 0x0400B46B RID: 46187
		[SerializeField]
		private ToggleGroup m_CustomItemToggleGroup;

		// Token: 0x0400B46C RID: 46188
		[SerializeField]
		[Header("扩展图片")]
		private List<Image> m_ExtendImgs;

		// Token: 0x0400B46D RID: 46189
		[SerializeField]
		[Header("扩展按钮1")]
		private Button m_ExtendBtn_1;

		// Token: 0x0400B46E RID: 46190
		[SerializeField]
		[Header("扩展按钮1图片")]
		private Image m_ExtendBtnImg_1;

		// Token: 0x02001BC2 RID: 7106
		// (Invoke) Token: 0x06011620 RID: 71200
		public delegate void ItemBtnClickHandle();

		// Token: 0x02001BC3 RID: 7107
		// (Invoke) Token: 0x06011624 RID: 71204
		public delegate void ItemToggleClickHandle(bool isOn);

		// Token: 0x02001BC4 RID: 7108
		// (Invoke) Token: 0x06011628 RID: 71208
		public delegate string CountFormatter(ComItemCustom a_comItem);
	}
}
