using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200174E RID: 5966
	public class MailMainTabItem : MonoBehaviour
	{
		// Token: 0x0600EA64 RID: 60004 RVA: 0x003E2214 File Offset: 0x003E0614
		private void Awake()
		{
			this.InitData();
			if (this.mMainTabTog != null)
			{
				this.mMainTabTog.onValueChanged.RemoveAllListeners();
				this.mMainTabTog.onValueChanged.AddListener(new UnityAction<bool>(this.OnMainTabClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewMailNotify, new ClientEventSystem.UIEventHandler(this.OnUpdateRePoint));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateMailStatus, new ClientEventSystem.UIEventHandler(this.OnUpdateRePoint));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMailDeleteSuccess, new ClientEventSystem.UIEventHandler(this.OnUpdateRePoint));
		}

		// Token: 0x0600EA65 RID: 60005 RVA: 0x003E22B5 File Offset: 0x003E06B5
		private void InitData()
		{
			this.mMainNewMainTabDataModel = null;
			this.mMailMainTabAddListener = null;
			this.mIsSelected = false;
		}

		// Token: 0x0600EA66 RID: 60006 RVA: 0x003E22CC File Offset: 0x003E06CC
		private void OnDestroy()
		{
			if (this.mMainTabTog != null)
			{
				this.mMainTabTog.onValueChanged.RemoveAllListeners();
			}
			this.mMainNewMainTabDataModel = null;
			this.mMailMainTabAddListener = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewMailNotify, new ClientEventSystem.UIEventHandler(this.OnUpdateRePoint));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateMailStatus, new ClientEventSystem.UIEventHandler(this.OnUpdateRePoint));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMailDeleteSuccess, new ClientEventSystem.UIEventHandler(this.OnUpdateRePoint));
		}

		// Token: 0x0600EA67 RID: 60007 RVA: 0x003E2359 File Offset: 0x003E0759
		private void OnUpdateRePoint(UIEvent uiEvent)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MailNewFrame>(null))
			{
				this.SetRedPoint();
			}
		}

		// Token: 0x0600EA68 RID: 60008 RVA: 0x003E2374 File Offset: 0x003E0774
		public void Init(MailNewMainTabDataModel mailNewMainTabDataModel, OnMailMainTabAddListener mailMainTabAddListener, bool isSelected = false)
		{
			this.mMainNewMainTabDataModel = mailNewMainTabDataModel;
			this.mMailMainTabAddListener = mailMainTabAddListener;
			if (this.mMainNewMainTabDataModel == null)
			{
				return;
			}
			if (this.mMainTabName != null)
			{
				this.mMainTabName.text = this.mMainNewMainTabDataModel.mainTabName;
			}
			this.SetRedPoint();
			if (isSelected && this.mMainTabTog != null)
			{
				this.mMainTabTog.isOn = true;
			}
		}

		// Token: 0x0600EA69 RID: 60009 RVA: 0x003E23EB File Offset: 0x003E07EB
		private void SetRedPoint()
		{
			if (this.mRedPoint != null && this.mMainNewMainTabDataModel != null)
			{
				this.mRedPoint.CustomActive(DataManager<MailDataManager>.GetInstance().CheckRedPoint(this.mMainNewMainTabDataModel.mailTabType));
			}
		}

		// Token: 0x0600EA6A RID: 60010 RVA: 0x003E242C File Offset: 0x003E082C
		private void OnMainTabClick(bool value)
		{
			if (this.mMainNewMainTabDataModel == null)
			{
				return;
			}
			if (this.mIsSelected == value)
			{
				return;
			}
			this.mIsSelected = value;
			if (value && this.mMailMainTabAddListener != null)
			{
				this.mMailMainTabAddListener(this.mMainNewMainTabDataModel);
			}
		}

		// Token: 0x04008E2B RID: 36395
		[SerializeField]
		private Text mMainTabName;

		// Token: 0x04008E2C RID: 36396
		[SerializeField]
		private Toggle mMainTabTog;

		// Token: 0x04008E2D RID: 36397
		[SerializeField]
		private GameObject mRedPoint;

		// Token: 0x04008E2E RID: 36398
		private MailNewMainTabDataModel mMainNewMainTabDataModel;

		// Token: 0x04008E2F RID: 36399
		private bool mIsSelected;

		// Token: 0x04008E30 RID: 36400
		private OnMailMainTabAddListener mMailMainTabAddListener;
	}
}
