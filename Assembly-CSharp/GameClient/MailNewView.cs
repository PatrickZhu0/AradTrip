using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001751 RID: 5969
	public class MailNewView : MonoBehaviour
	{
		// Token: 0x0600EA7A RID: 60026 RVA: 0x003E26D0 File Offset: 0x003E0AD0
		private void Awake()
		{
			this.InitMailInfoMationView();
			this.RegisterUIEventHandler();
			this.InitBtnClick();
		}

		// Token: 0x0600EA7B RID: 60027 RVA: 0x003E26E4 File Offset: 0x003E0AE4
		private void OnDestroy()
		{
			this.UnRegisterUIEventHandler();
			this.UnInitBtnClick();
		}

		// Token: 0x0600EA7C RID: 60028 RVA: 0x003E26F4 File Offset: 0x003E0AF4
		private void InitMailInfoMationView()
		{
			UIPrefabWrapper component = this.mMailInfomationRoot.GetComponent<UIPrefabWrapper>();
			if (component == null)
			{
				return;
			}
			GameObject gameObject = component.LoadUIPrefab();
			Utility.AttachTo(gameObject, this.mMailInfomationRoot, false);
			if (this.mMailInfoMationView == null)
			{
				this.mMailInfoMationView = gameObject.GetComponent<MailInfomationView>();
			}
		}

		// Token: 0x0600EA7D RID: 60029 RVA: 0x003E274B File Offset: 0x003E0B4B
		public void InitView(OnMailMainTabAddListener mailMainTabAddListener)
		{
			this.mMailMainTabAddListener = mailMainTabAddListener;
			this.InitTabComUIListScripts();
		}

		// Token: 0x0600EA7E RID: 60030 RVA: 0x003E275C File Offset: 0x003E0B5C
		private int GetOneKeyReceiveNum()
		{
			int result = 0;
			switch (MailDataManager.CurrentSelectMailTabType)
			{
			case MailTabType.MTT_ANNOUNCEMENT:
				result = MailDataManager.AnnouncmentMailOneKeyReceiveNum;
				break;
			case MailTabType.MTT_REWARD:
				result = MailDataManager.RewardMailOneKeyReceiveNum;
				break;
			case MailTabType.MTT_GUILD:
				result = MailDataManager.GuildMailOneKeyReceiveNum;
				break;
			}
			return result;
		}

		// Token: 0x0600EA7F RID: 60031 RVA: 0x003E27B4 File Offset: 0x003E0BB4
		private int GetOneKeyDeleteMailNum()
		{
			int result = 0;
			switch (MailDataManager.CurrentSelectMailTabType)
			{
			case MailTabType.MTT_ANNOUNCEMENT:
				result = MailDataManager.AnnouncementMailOneKeyDeleteNum;
				break;
			case MailTabType.MTT_REWARD:
				result = MailDataManager.RewardMailOneKeyDeleteNum;
				break;
			case MailTabType.MTT_GUILD:
				result = MailDataManager.GuildMailOneKeyDeleteNum;
				break;
			}
			return result;
		}

		// Token: 0x0600EA80 RID: 60032 RVA: 0x003E2810 File Offset: 0x003E0C10
		private void InitBtnClick()
		{
			if (this.mBtnClose != null)
			{
				this.mBtnClose.onClick.RemoveAllListeners();
				this.mBtnClose.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<MailNewFrame>(null, false);
					DataManager<MailDataManager>.GetInstance().SortMailList();
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewMailNotify, null, null, null, null);
				});
			}
			if (this.mBtnAcceptAll != null)
			{
				this.mBtnAcceptAll.onClick.RemoveAllListeners();
				this.mBtnAcceptAll.onClick.AddListener(delegate()
				{
					int oneKeyReceiveNum = this.GetOneKeyReceiveNum();
					if (oneKeyReceiveNum <= 0)
					{
						SystemNotifyManager.SystemNotify(1022, string.Empty);
						return;
					}
					DataManager<MailDataManager>.GetInstance().OnSendReceiveMailReq(true, this.mCurSelectMailID);
				});
			}
			if (this.mBtnAccpet != null)
			{
				this.mBtnAccpet.onClick.RemoveAllListeners();
				this.mBtnAccpet.onClick.AddListener(delegate()
				{
					MailTitleInfo mailTitleInfo = DataManager<MailDataManager>.GetInstance().FindMailTitleInfo(this.mSelfMailTitleInfoList, this.mCurSelectMailID);
					if (mailTitleInfo == null)
					{
						SystemNotifyManager.SystemNotify(1022, string.Empty);
						return;
					}
					if (mailTitleInfo.hasItem == 0)
					{
						SystemNotifyManager.SystemNotify(1021, string.Empty);
						return;
					}
					DataManager<MailDataManager>.GetInstance().OnSendReceiveMailReq(false, this.mCurSelectMailID);
				});
				if (this.mBtnDeleteAll != null)
				{
					this.mBtnDeleteAll.onClick.RemoveAllListeners();
					this.mBtnDeleteAll.onClick.AddListener(delegate()
					{
						int oneKeyDeleteMailNum = this.GetOneKeyDeleteMailNum();
						if (oneKeyDeleteMailNum <= 0)
						{
							SystemNotifyManager.SystemNotify(1024, string.Empty);
							return;
						}
						DataManager<MailDataManager>.GetInstance().OnSendDeleteMailReq(true, this.mCurSelectMailID);
					});
				}
				if (this.mBtnDelete != null)
				{
					this.mBtnDelete.onClick.RemoveAllListeners();
					this.mBtnDelete.onClick.AddListener(delegate()
					{
						MailTitleInfo mailTitleInfo = DataManager<MailDataManager>.GetInstance().FindMailTitleInfo(this.mSelfMailTitleInfoList, this.mCurSelectMailID);
						if (mailTitleInfo == null)
						{
							SystemNotifyManager.SystemNotify(1024, string.Empty);
							return;
						}
						if (mailTitleInfo.hasItem == 1)
						{
							SystemNotifyManager.SystemNotify(1023, string.Empty);
							return;
						}
						DataManager<MailDataManager>.GetInstance().OnSendDeleteMailReq(false, this.mCurSelectMailID);
					});
				}
			}
		}

		// Token: 0x0600EA81 RID: 60033 RVA: 0x003E2960 File Offset: 0x003E0D60
		private void UnInitBtnClick()
		{
			if (this.mBtnClose != null)
			{
				this.mBtnClose.onClick.RemoveAllListeners();
			}
			if (this.mBtnAcceptAll != null)
			{
				this.mBtnAcceptAll.onClick.RemoveAllListeners();
			}
			if (this.mBtnAccpet != null)
			{
				this.mBtnAccpet.onClick.RemoveAllListeners();
			}
			if (this.mBtnDeleteAll != null)
			{
				this.mBtnDeleteAll.onClick.RemoveAllListeners();
			}
			if (this.mBtnDelete != null)
			{
				this.mBtnDelete.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600EA82 RID: 60034 RVA: 0x003E2A14 File Offset: 0x003E0E14
		private void RegisterUIEventHandler()
		{
			if (this.mMailUIListScript != null)
			{
				this.mMailUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mMailUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindMailItemDelegate));
				ComUIListScript comUIListScript2 = this.mMailUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBindMailItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mMailUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mMailUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x0600EA83 RID: 60035 RVA: 0x003E2ADC File Offset: 0x003E0EDC
		private void UnRegisterUIEventHandler()
		{
			if (this.mMailUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mMailUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindMailItemDelegate));
				ComUIListScript comUIListScript2 = this.mMailUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBindMailItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mMailUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mMailUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
			this.mMailUIListScript = null;
			if (this.mMailMainTabList != null)
			{
				ComUIListScript comUIListScript5 = this.mMailMainTabList;
				comUIListScript5.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript5.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript6 = this.mMailMainTabList;
				comUIListScript6.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript6.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.mMailMainTabList = null;
			this.mMailInfoMationView = null;
			this.mMailMainTabAddListener = null;
			this.mSelfMailTitleInfoList = null;
			this.mCurrentSelectMailTabType = MailTabType.MTT_NONE;
		}

		// Token: 0x0600EA84 RID: 60036 RVA: 0x003E2C20 File Offset: 0x003E1020
		private void InitTabComUIListScripts()
		{
			if (this.mMailMainTabList != null)
			{
				this.mMailMainTabList.Initialize();
				ComUIListScript comUIListScript = this.mMailMainTabList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMailMainTabList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				this.mMailMainTabList.SetElementAmount(this.mMailMainTabDataModelList.Count);
			}
		}

		// Token: 0x0600EA85 RID: 60037 RVA: 0x003E2CAD File Offset: 0x003E10AD
		private MailMainTabItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<MailMainTabItem>();
		}

		// Token: 0x0600EA86 RID: 60038 RVA: 0x003E2CB8 File Offset: 0x003E10B8
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			MailMainTabItem mailMainTabItem = item.gameObjectBindScript as MailMainTabItem;
			if (mailMainTabItem != null && item.m_index >= 0 && item.m_index < this.mMailMainTabDataModelList.Count)
			{
				if (item.m_index == MailDataManager.DefaultMailMainTabIndex)
				{
					mailMainTabItem.Init(this.mMailMainTabDataModelList[item.m_index], this.mMailMainTabAddListener, true);
				}
				else
				{
					mailMainTabItem.Init(this.mMailMainTabDataModelList[item.m_index], this.mMailMainTabAddListener, false);
				}
			}
		}

		// Token: 0x0600EA87 RID: 60039 RVA: 0x003E2D50 File Offset: 0x003E1150
		private MailItem OnBindMailItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<MailItem>();
		}

		// Token: 0x0600EA88 RID: 60040 RVA: 0x003E2D58 File Offset: 0x003E1158
		private void OnBindMailItemVisiableDelegate(ComUIListElementScript item)
		{
			MailItem mailItem = item.gameObjectBindScript as MailItem;
			if (mailItem == null)
			{
				return;
			}
			if (this.mSelfMailTitleInfoList != null && item.m_index >= 0 && item.m_index < this.mSelfMailTitleInfoList.Count)
			{
				mailItem.UpdateItemVisiable(this.mSelfMailTitleInfoList[item.m_index]);
			}
		}

		// Token: 0x0600EA89 RID: 60041 RVA: 0x003E2DC4 File Offset: 0x003E11C4
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			MailItem mailItem = item.gameObjectBindScript as MailItem;
			if (mailItem == null)
			{
				return;
			}
			if (mailItem.GetMailTitleInfo.id == this.mCurSelectMailID)
			{
				return;
			}
			this.mCurSelectMailID = mailItem.GetMailTitleInfo.id;
			if (mailItem.GetMailTitleInfo.status == 0)
			{
				this.OnSendReadMailReq(this.mCurSelectMailID);
			}
			else
			{
				MailDataModel mailDataModel = null;
				switch (MailDataManager.CurrentSelectMailTabType)
				{
				case MailTabType.MTT_ANNOUNCEMENT:
					mailDataModel = DataManager<MailDataManager>.GetInstance().FindMailDataModel(DataManager<MailDataManager>.GetInstance().mAnnouncementMailDataModelDict, this.mCurSelectMailID);
					break;
				case MailTabType.MTT_REWARD:
					mailDataModel = DataManager<MailDataManager>.GetInstance().FindMailDataModel(DataManager<MailDataManager>.GetInstance().mRewardMailDataModelDict, this.mCurSelectMailID);
					break;
				case MailTabType.MTT_GUILD:
					mailDataModel = DataManager<MailDataManager>.GetInstance().FindMailDataModel(DataManager<MailDataManager>.GetInstance().mGuildMailDataModelDict, this.mCurSelectMailID);
					break;
				}
				if (mailDataModel == null)
				{
					this.OnSendReadMailReq(this.mCurSelectMailID);
				}
				else
				{
					this.UpdateMailInfoMationView(mailDataModel);
				}
			}
		}

		// Token: 0x0600EA8A RID: 60042 RVA: 0x003E2EDC File Offset: 0x003E12DC
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			MailItem mailItem = item.gameObjectBindScript as MailItem;
			if (mailItem == null)
			{
				return;
			}
			mailItem.OnItemChangeDisplay(bSelected);
		}

		// Token: 0x0600EA8B RID: 60043 RVA: 0x003E2F09 File Offset: 0x003E1309
		private void OnSendReadMailReq(ulong id)
		{
			DataManager<MailDataManager>.GetInstance().OnSendReadMailReq(id);
		}

		// Token: 0x0600EA8C RID: 60044 RVA: 0x003E2F18 File Offset: 0x003E1318
		public void UpdateSelfMailTitleInfoList(List<MailTitleInfo> mailTitleInfoList)
		{
			this.mSelfMailTitleInfoList = new List<MailTitleInfo>();
			if (this.mCurrentSelectMailTabType != MailDataManager.CurrentSelectMailTabType)
			{
				this.mCurSelectMailID = 0UL;
				this.mCurrentSelectMailTabType = MailDataManager.CurrentSelectMailTabType;
			}
			if (mailTitleInfoList.Count > 0)
			{
				this.mSelfMailTitleInfoList = mailTitleInfoList;
				this.ResetMailUIListData();
				this.SetElementAmount(this.mSelfMailTitleInfoList.Count);
				this.SetSelectMailInfoItem();
			}
			else
			{
				this.SetElementAmount(0);
			}
			this.mContent.CustomActive(this.mSelfMailTitleInfoList.Count > 0);
		}

		// Token: 0x0600EA8D RID: 60045 RVA: 0x003E2FA8 File Offset: 0x003E13A8
		public void SetElementAmount(int Count)
		{
			this.mMailUIListScript.SetElementAmount(Count);
		}

		// Token: 0x0600EA8E RID: 60046 RVA: 0x003E2FB6 File Offset: 0x003E13B6
		public void UpdateMailTitleInfo(List<MailTitleInfo> mailTitleInfoList)
		{
			if (mailTitleInfoList.Count > 0)
			{
				this.mSelfMailTitleInfoList = mailTitleInfoList;
				this.SetElementAmount(this.mSelfMailTitleInfoList.Count);
			}
			else
			{
				this.SetElementAmount(0);
			}
		}

		// Token: 0x0600EA8F RID: 60047 RVA: 0x003E2FE8 File Offset: 0x003E13E8
		public void UpdateNewMailNotify(List<MailTitleInfo> mailTitleInfoList)
		{
			if (this.mSelfMailTitleInfoList.Count <= 0)
			{
				this.UpdateSelfMailTitleInfoList(mailTitleInfoList);
			}
			else
			{
				this.mSelfMailTitleInfoList = mailTitleInfoList;
				this.ResetMailUIListData();
				this.SetElementAmount(this.mSelfMailTitleInfoList.Count);
			}
		}

		// Token: 0x0600EA90 RID: 60048 RVA: 0x003E3025 File Offset: 0x003E1425
		public void SetSelectMailInfoItem()
		{
			if (this.mMailUIListScript != null)
			{
				if (!this.mMailUIListScript.IsElementInScrollArea(0))
				{
					this.mMailUIListScript.EnsureElementVisable(0);
				}
				this.mMailUIListScript.SelectElement(0, true);
			}
		}

		// Token: 0x0600EA91 RID: 60049 RVA: 0x003E3062 File Offset: 0x003E1462
		private void ResetMailUIListData()
		{
			this.mMailUIListScript.ResetSelectedElementIndex();
			this.mMailUIListScript.MoveElementInScrollArea(0, true);
		}

		// Token: 0x0600EA92 RID: 60050 RVA: 0x003E307C File Offset: 0x003E147C
		public void UpdateMailInfoMationView(MailDataModel mailData)
		{
			if (this.mMailInfoMationView != null)
			{
				this.mMailInfoMationView.UpdateMailInfoMationView(mailData);
			}
			if (mailData.info != null)
			{
				this.mBtnAccpet.gameObject.CustomActive(mailData.info.hasItem == 1);
			}
		}

		// Token: 0x0600EA93 RID: 60051 RVA: 0x003E30D0 File Offset: 0x003E14D0
		public void UpdateBtnStatue(MailNewMainTabDataModel mailNewMainTabData)
		{
			if (mailNewMainTabData == null)
			{
				return;
			}
			switch (mailNewMainTabData.mailTabType)
			{
			case MailTabType.MTT_ANNOUNCEMENT:
				this.mBtnStartContrl.Key = this.mAnnouncement;
				break;
			case MailTabType.MTT_REWARD:
				this.mBtnStartContrl.Key = this.mReward;
				break;
			case MailTabType.MTT_GUILD:
				this.mBtnStartContrl.Key = this.mGuild;
				break;
			}
		}

		// Token: 0x04008E35 RID: 36405
		[Space(5f)]
		[Header("MailMainTabDataModelList")]
		[SerializeField]
		private List<MailNewMainTabDataModel> mMailMainTabDataModelList = new List<MailNewMainTabDataModel>();

		// Token: 0x04008E36 RID: 36406
		[Space(10f)]
		[SerializeField]
		private ComUIListScript mMailMainTabList;

		// Token: 0x04008E37 RID: 36407
		[SerializeField]
		private ComUIListScript mMailUIListScript;

		// Token: 0x04008E38 RID: 36408
		[SerializeField]
		private GameObject mMailInfomationRoot;

		// Token: 0x04008E39 RID: 36409
		[SerializeField]
		private GameObject mNoMailTipRoot;

		// Token: 0x04008E3A RID: 36410
		[SerializeField]
		private GameObject mContent;

		// Token: 0x04008E3B RID: 36411
		[Space(10f)]
		[Header("Button")]
		[SerializeField]
		private Button mBtnDeleteAll;

		// Token: 0x04008E3C RID: 36412
		[SerializeField]
		private Button mBtnAcceptAll;

		// Token: 0x04008E3D RID: 36413
		[SerializeField]
		private Button mBtnDelete;

		// Token: 0x04008E3E RID: 36414
		[SerializeField]
		private Button mBtnAccpet;

		// Token: 0x04008E3F RID: 36415
		[SerializeField]
		private Button mBtnClose;

		// Token: 0x04008E40 RID: 36416
		[Space(10f)]
		[Header("StateController")]
		[SerializeField]
		private StateController mBtnStartContrl;

		// Token: 0x04008E41 RID: 36417
		[SerializeField]
		private string mAnnouncement;

		// Token: 0x04008E42 RID: 36418
		[SerializeField]
		private string mReward;

		// Token: 0x04008E43 RID: 36419
		[SerializeField]
		private string mGuild;

		// Token: 0x04008E44 RID: 36420
		private OnMailMainTabAddListener mMailMainTabAddListener;

		// Token: 0x04008E45 RID: 36421
		private List<MailTitleInfo> mSelfMailTitleInfoList = new List<MailTitleInfo>();

		// Token: 0x04008E46 RID: 36422
		private MailInfomationView mMailInfoMationView;

		// Token: 0x04008E47 RID: 36423
		private MailTabType mCurrentSelectMailTabType;

		// Token: 0x04008E48 RID: 36424
		private ulong mCurSelectMailID;
	}
}
