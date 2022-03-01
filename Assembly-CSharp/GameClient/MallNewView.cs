using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017A0 RID: 6048
	public class MallNewView : MonoBehaviour
	{
		// Token: 0x0600EE80 RID: 61056 RVA: 0x004005CB File Offset: 0x003FE9CB
		private void Awake()
		{
			this.InitData();
			this.BindUiEventSystem();
		}

		// Token: 0x0600EE81 RID: 61057 RVA: 0x004005D9 File Offset: 0x003FE9D9
		private void InitData()
		{
		}

		// Token: 0x0600EE82 RID: 61058 RVA: 0x004005DC File Offset: 0x003FE9DC
		private void BindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.mainTabsList != null)
			{
				this.mainTabsList.Initialize();
				ComUIListScript comUIListScript = this.mainTabsList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisible));
				ComUIListScript comUIListScript2 = this.mainTabsList;
				comUIListScript2.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript2.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnMainTabItemSelected));
			}
		}

		// Token: 0x0600EE83 RID: 61059 RVA: 0x00400690 File Offset: 0x003FEA90
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600EE84 RID: 61060 RVA: 0x0040069E File Offset: 0x003FEA9E
		private void ClearData()
		{
		}

		// Token: 0x0600EE85 RID: 61061 RVA: 0x004006A0 File Offset: 0x003FEAA0
		private void UnBindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.mainTabsList != null)
			{
				ComUIListScript comUIListScript = this.mainTabsList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisible));
				ComUIListScript comUIListScript2 = this.mainTabsList;
				comUIListScript2.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript2.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnMainTabItemSelected));
			}
		}

		// Token: 0x0600EE86 RID: 61062 RVA: 0x00400730 File Offset: 0x003FEB30
		public void InitView()
		{
			if (this.mainTabsList != null)
			{
				int count = this.mainTabsDataModelList.Count;
				this.mainTabsList.SetElementAmount(count);
			}
		}

		// Token: 0x0600EE87 RID: 61063 RVA: 0x00400766 File Offset: 0x003FEB66
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallNewFrame>(null, false);
		}

		// Token: 0x0600EE88 RID: 61064 RVA: 0x00400774 File Offset: 0x003FEB74
		private void OnMainTabItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			MallNewMainTabItem component = item.GetComponent<MallNewMainTabItem>();
			if (component == null)
			{
				return;
			}
			if (this.mainTabsDataModelList != null && item.m_index >= 0 && item.m_index < this.mainTabsDataModelList.Count)
			{
				MallNewMainTabDataModel mallNewMainTabDataModel = this.mainTabsDataModelList[item.m_index];
				if (mallNewMainTabDataModel != null)
				{
					if (mallNewMainTabDataModel.mainTabType == (MallNewType)MallNewFrame.DefaultMainTabIndex)
					{
						component.Init(mallNewMainTabDataModel, new OnMallTabClick(this.OnMallTabClick), true);
					}
					else
					{
						component.Init(mallNewMainTabDataModel, new OnMallTabClick(this.OnMallTabClick), false);
					}
					if (mallNewMainTabDataModel.isHaveEffect && this.tabItemEffect != null)
					{
						GameObject gameObject = Object.Instantiate<GameObject>(this.tabItemEffect);
						if (gameObject != null)
						{
							component.SetTabUiEffect(gameObject);
						}
					}
				}
			}
		}

		// Token: 0x0600EE89 RID: 61065 RVA: 0x0040085F File Offset: 0x003FEC5F
		private void OnMainTabItemSelected(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
		}

		// Token: 0x0600EE8A RID: 61066 RVA: 0x00400870 File Offset: 0x003FEC70
		private void OnMallTabClick(MallNewMainTabDataModel mainTabData)
		{
			if (mainTabData.mainTabType == MallNewType.IntegralMall)
			{
				this.moneiesRoot.CustomActive(false);
				this.intergralTicketRoot.CustomActive(true);
			}
			else
			{
				if (mainTabData.mainTabType == MallNewType.LimitTimeMall)
				{
					CommonUtility.UpdateGameObjectVisible(this.creditPointRoot, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.creditPointRoot, true);
				}
				this.moneiesRoot.CustomActive(true);
				this.intergralTicketRoot.CustomActive(false);
			}
		}

		// Token: 0x040091EF RID: 37359
		[Space(5f)]
		[Header("MainTabDataModelList")]
		[SerializeField]
		private List<MallNewMainTabDataModel> mainTabsDataModelList = new List<MallNewMainTabDataModel>();

		// Token: 0x040091F0 RID: 37360
		[Space(15f)]
		[SerializeField]
		private ComUIListScript mainTabsList;

		// Token: 0x040091F1 RID: 37361
		[SerializeField]
		private Button closeButton;

		// Token: 0x040091F2 RID: 37362
		[SerializeField]
		private GameObject tabItemEffect;

		// Token: 0x040091F3 RID: 37363
		[Space(10f)]
		[Header("MoneyTitle")]
		[Space(10f)]
		[SerializeField]
		private GameObject moneiesRoot;

		// Token: 0x040091F4 RID: 37364
		[SerializeField]
		private GameObject creditPointRoot;

		// Token: 0x040091F5 RID: 37365
		[SerializeField]
		private GameObject intergralTicketRoot;
	}
}
