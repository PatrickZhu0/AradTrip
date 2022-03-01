using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019CC RID: 6604
	public class ComRandomTreasureSiteBtn : MonoBehaviour
	{
		// Token: 0x060102AC RID: 66220 RVA: 0x00481BED File Offset: 0x0047FFED
		private void Awake()
		{
			this._SetOpenedTipItemShow(false);
			this._SetGoldBgShowByStatus(false, true);
			this._SetSilverBgShowByStatus(false, true);
		}

		// Token: 0x060102AD RID: 66221 RVA: 0x00481C08 File Offset: 0x00480008
		private void Start()
		{
			if (this.mFuncBtn)
			{
				this.mFuncBtn.onClick.AddListener(new UnityAction(this._OnFuncBtnClick));
			}
			if (this.mTipBtn)
			{
				this.mTipBtn.onClick.AddListener(new UnityAction(this._OnTipBtnClick));
			}
			this.mTips_Treasure_IsOpened = TR.Value("random_treasure_map_site_isopened");
		}

		// Token: 0x060102AE RID: 66222 RVA: 0x00481C80 File Offset: 0x00480080
		private void Update()
		{
			if (!this.bDirtyCD)
			{
				return;
			}
			this.mServerTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if ((ulong)(this.mServerTime - this.mChangeStatusTime) < (ulong)((long)this.mShowOpenedItemSecond) || (ulong)(this.mServerTime - this.mRefreshTime) < (ulong)((long)this.mShowOpenedItemSecond))
			{
				this._SetOpenedTipItemShow(true);
				this._SetTypeTreasureShow(true);
			}
			else
			{
				this._SetOpenedTipItemShow(false);
				this._SetTypeTreasureShow(false);
				this.bDirtyCD = false;
			}
		}

		// Token: 0x060102AF RID: 66223 RVA: 0x00481D08 File Offset: 0x00480108
		private void OnDestroy()
		{
			if (this.mFuncBtn)
			{
				this.mFuncBtn.onClick.RemoveListener(new UnityAction(this._OnFuncBtnClick));
				this.mFuncBtn = null;
			}
			this.mSiteModel = null;
			this.bDirtyCD = false;
			if (this.mTipItem != null)
			{
				ComItemManager.Destroy(this.mTipItem);
				this.mTipItem = null;
			}
			this.mTipItemData = null;
			if (this.mTipBtn)
			{
				this.mTipBtn.onClick.RemoveListener(new UnityAction(this._OnTipBtnClick));
				this.mTipBtn = null;
			}
			this.mParent = null;
			this.mTips_Treasure_IsOpened = string.Empty;
		}

		// Token: 0x060102B0 RID: 66224 RVA: 0x00481DC8 File Offset: 0x004801C8
		private void _SetTypeTreasureShow(bool bForceHide = false)
		{
			if (this.mSiteModel == null)
			{
				return;
			}
			bool bOpen = false;
			DigStatus status = this.mSiteModel.status;
			if (status != DigStatus.DIG_STATUS_OPEN)
			{
				if (status != DigStatus.DIG_STATUS_INIT)
				{
					if (status == DigStatus.DIG_STATUS_INVALID)
					{
						bOpen = false;
					}
				}
				else
				{
					bOpen = false;
				}
			}
			else
			{
				bOpen = true;
			}
			if (this.mSiteModel.type == DigType.DIG_GLOD)
			{
				this._SetGoldBgShowByStatus(bOpen, bForceHide);
				this._SetSilverBgShowByStatus(false, true);
			}
			else if (this.mSiteModel.type == DigType.DIG_SILVER)
			{
				this._SetSilverBgShowByStatus(bOpen, bForceHide);
				this._SetGoldBgShowByStatus(false, true);
			}
		}

		// Token: 0x060102B1 RID: 66225 RVA: 0x00481E64 File Offset: 0x00480264
		private void _SetParentGoShow(bool bShow)
		{
			if (this.mParent)
			{
				this.mParent.CustomActive(bShow);
			}
		}

		// Token: 0x060102B2 RID: 66226 RVA: 0x00481E84 File Offset: 0x00480284
		private void _SetGoldBgShowByStatus(bool bOpen, bool bForceHide)
		{
			if (this.mGoldBg)
			{
				this.mGoldBg.enabled = (!bOpen && !bForceHide);
			}
			if (this.mGoldBg_Open)
			{
				this.mGoldBg_Open.enabled = (bOpen && !bForceHide);
			}
		}

		// Token: 0x060102B3 RID: 66227 RVA: 0x00481EE4 File Offset: 0x004802E4
		private void _SetSilverBgShowByStatus(bool bOpen, bool bForceHide)
		{
			if (this.mSilverBg)
			{
				this.mSilverBg.enabled = (!bOpen && !bForceHide);
			}
			if (this.mSilverBg_Open)
			{
				this.mSilverBg_Open.enabled = (bOpen && !bForceHide);
			}
		}

		// Token: 0x060102B4 RID: 66228 RVA: 0x00481F44 File Offset: 0x00480344
		private void _SetOpenedTipItem(ItemSimpleData sData)
		{
			if (sData == null)
			{
				return;
			}
			if (this.mTipImg && this.mTipBtn)
			{
				this.mTipItemData = ItemDataManager.CreateItemDataFromTable(sData.ItemID, 100, 0);
				if (this.mTipItemData == null)
				{
					Logger.LogError("[ComRandomTreasureSiteBtn] - _SetOpenedTipItem  Please check item data null");
					return;
				}
				ETCImageLoader.LoadSprite(ref this.mTipImg, this.mTipItemData.Icon, true);
			}
		}

		// Token: 0x060102B5 RID: 66229 RVA: 0x00481FBA File Offset: 0x004803BA
		private void _SetOpenedTipItemShow(bool bShow)
		{
			if (this.mTipImg)
			{
				this.mTipImg.enabled = bShow;
			}
			if (this.mTipBtn)
			{
				this.mTipBtn.interactable = bShow;
			}
		}

		// Token: 0x060102B6 RID: 66230 RVA: 0x00481FF4 File Offset: 0x004803F4
		private void _OnFuncBtnClick()
		{
			if (this.mSiteModel != null)
			{
				if (this.mSiteModel.status == DigStatus.DIG_STATUS_OPEN || this.mSiteModel.status == DigStatus.DIG_STATUS_INVALID)
				{
					SystemNotifyManager.SysNotifyTextAnimation(this.mTips_Treasure_IsOpened, CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				DataManager<RandomTreasureDataManager>.GetInstance().ReqWatchTreasureSite(this.mSiteModel);
			}
			else
			{
				Logger.LogError("[ComRandomTreasureSiteBtn] - OnFuncBtnClick : SiteModel is null");
			}
		}

		// Token: 0x060102B7 RID: 66231 RVA: 0x00482059 File Offset: 0x00480459
		private void _OnTipBtnClick()
		{
			if (this.mTipItemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(this.mTipItemData, null, 4, true, false, true);
		}

		// Token: 0x060102B8 RID: 66232 RVA: 0x0048207C File Offset: 0x0048047C
		public void Refresh(RandomTreasureMapDigSiteModel siteModel, GameObject parent = null)
		{
			this.bDirtyCD = false;
			this.mSiteModel = siteModel;
			this.mParent = parent;
			if (siteModel == null)
			{
				return;
			}
			if (siteModel.type == DigType.DIG_INVALID || siteModel.status == DigStatus.DIG_STATUS_INVALID)
			{
				this._SetParentGoShow(false);
				return;
			}
			this._SetParentGoShow(true);
			this._SetOpenedTipItemShow(false);
			this._SetTypeTreasureShow(false);
			this.mRefreshTime = siteModel.refreshTime;
			this.mChangeStatusTime = siteModel.changeStatusTime;
			this.mServerTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (siteModel.status == DigStatus.DIG_STATUS_OPEN && ((ulong)(this.mServerTime - this.mChangeStatusTime) < (ulong)((long)this.mShowOpenedItemSecond) || (ulong)(this.mServerTime - this.mRefreshTime) < (ulong)((long)this.mShowOpenedItemSecond)))
			{
				this._SetOpenedTipItem(siteModel.openItem);
				this.bDirtyCD = true;
			}
		}

		// Token: 0x0400A366 RID: 41830
		private RandomTreasureMapDigSiteModel mSiteModel;

		// Token: 0x0400A367 RID: 41831
		private uint mRefreshTime;

		// Token: 0x0400A368 RID: 41832
		private uint mChangeStatusTime;

		// Token: 0x0400A369 RID: 41833
		private uint mServerTime;

		// Token: 0x0400A36A RID: 41834
		private bool bDirtyCD;

		// Token: 0x0400A36B RID: 41835
		private ComItem mTipItem;

		// Token: 0x0400A36C RID: 41836
		private ItemData mTipItemData;

		// Token: 0x0400A36D RID: 41837
		private string mTips_Treasure_IsOpened = string.Empty;

		// Token: 0x0400A36E RID: 41838
		[SerializeField]
		private Image mGoldBg;

		// Token: 0x0400A36F RID: 41839
		[SerializeField]
		private Image mGoldBg_Open;

		// Token: 0x0400A370 RID: 41840
		[SerializeField]
		private Image mSilverBg;

		// Token: 0x0400A371 RID: 41841
		[SerializeField]
		private Image mSilverBg_Open;

		// Token: 0x0400A372 RID: 41842
		[SerializeField]
		private Button mFuncBtn;

		// Token: 0x0400A373 RID: 41843
		[SerializeField]
		private Image mTipImg;

		// Token: 0x0400A374 RID: 41844
		[SerializeField]
		private Button mTipBtn;

		// Token: 0x0400A375 RID: 41845
		[Header("打开后展示道具的倒计时（秒）")]
		[SerializeField]
		private int mShowOpenedItemSecond = 60;

		// Token: 0x0400A376 RID: 41846
		private GameObject mParent;
	}
}
