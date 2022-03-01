using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001405 RID: 5125
	public class AdventureTeamInformationView : MonoBehaviour
	{
		// Token: 0x0600C66F RID: 50799 RVA: 0x002FE318 File Offset: 0x002FC718
		private void Awake()
		{
			this.BindEvents();
			this.mainTabItems = new List<AdventureTeamMainTabItem>();
		}

		// Token: 0x0600C670 RID: 50800 RVA: 0x002FE32B File Offset: 0x002FC72B
		private void OnDestroy()
		{
			this.UnBindEvents();
			if (this.mainTabItems != null)
			{
				this.mainTabItems.Clear();
				this.mainTabItems = null;
			}
		}

		// Token: 0x0600C671 RID: 50801 RVA: 0x002FE350 File Offset: 0x002FC750
		private void BindEvents()
		{
			if (this.mainTabItemList != null)
			{
				this.mainTabItemList.Initialize();
				ComUIListScript comUIListScript = this.mainTabItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x0600C672 RID: 50802 RVA: 0x002FE3D0 File Offset: 0x002FC7D0
		private void UnBindEvents()
		{
			if (this.mainTabItemList != null)
			{
				ComUIListScript comUIListScript = this.mainTabItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x0600C673 RID: 50803 RVA: 0x002FE444 File Offset: 0x002FC844
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamMainTabItem component = item.GetComponent<AdventureTeamMainTabItem>();
			if (component == null)
			{
				return;
			}
			if (this.mainTabDataModelList != null && item.m_index >= 0 && item.m_index < this.mainTabDataModelList.Count)
			{
				AdventureTeamMainTabDataModel adventureTeamMainTabDataModel = this.mainTabDataModelList[item.m_index];
				if (adventureTeamMainTabDataModel != null)
				{
					if (this._defaultSelectedType == (AdventureTeamMainTabType)item.m_index)
					{
						component.Init(adventureTeamMainTabDataModel, true);
					}
					else
					{
						component.Init(adventureTeamMainTabDataModel, false);
					}
					this.mainTabItems.Add(component);
				}
			}
		}

		// Token: 0x0600C674 RID: 50804 RVA: 0x002FE4E9 File Offset: 0x002FC8E9
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdventureTeamInformationFrame>(null, false);
		}

		// Token: 0x0600C675 RID: 50805 RVA: 0x002FE4F8 File Offset: 0x002FC8F8
		public void InitView(AdventureTeamMainTabType type)
		{
			if (this.mainTabDataModelList == null)
			{
				return;
			}
			int count = this.mainTabDataModelList.Count;
			if (count <= 0)
			{
				return;
			}
			if (type < AdventureTeamMainTabType.BaseInformation || type >= (AdventureTeamMainTabType)count)
			{
				this._defaultSelectedType = AdventureTeamMainTabType.BaseInformation;
			}
			else
			{
				this._defaultSelectedType = type;
			}
			if (this.mainTabItemList != null)
			{
				this.mainTabItemList.SetElementAmount(count);
			}
			if (this.comRedPointBinder != null)
			{
				this.comRedPointBinder.InitBinder(this.mainTabItems);
				this.comRedPointBinder.CheckRedPointsShowOnUIEventCome();
			}
		}

		// Token: 0x0600C676 RID: 50806 RVA: 0x002FE590 File Offset: 0x002FC990
		public void SelectViewByTab(AdventureTeamMainTabType type)
		{
			if (this.mainTabDataModelList == null)
			{
				return;
			}
			int count = this.mainTabDataModelList.Count;
			if (count <= 0)
			{
				return;
			}
			if (type < AdventureTeamMainTabType.BaseInformation || type >= (AdventureTeamMainTabType)count)
			{
				this._defaultSelectedType = AdventureTeamMainTabType.BaseInformation;
			}
			else
			{
				this._defaultSelectedType = type;
			}
			int count2 = this.mainTabItems.Count;
			if (this.mainTabItems != null && count2 > 0)
			{
				for (int i = 0; i < count2; i++)
				{
					AdventureTeamMainTabItem adventureTeamMainTabItem = this.mainTabItems[i];
					if (!(adventureTeamMainTabItem == null))
					{
						if (adventureTeamMainTabItem.GetTabType() == type)
						{
							adventureTeamMainTabItem.SetTabSelect();
							break;
						}
					}
				}
			}
		}

		// Token: 0x040071D9 RID: 29145
		[Space(10f)]
		[Header("AdventureTeamInformationData")]
		[SerializeField]
		private List<AdventureTeamMainTabDataModel> mainTabDataModelList = new List<AdventureTeamMainTabDataModel>();

		// Token: 0x040071DA RID: 29146
		[Space(10f)]
		[Header("Control")]
		[SerializeField]
		private ComUIListScript mainTabItemList;

		// Token: 0x040071DB RID: 29147
		[SerializeField]
		private Button closeButton;

		// Token: 0x040071DC RID: 29148
		[SerializeField]
		private ComAdventureTeamTabRedPointBinder comRedPointBinder;

		// Token: 0x040071DD RID: 29149
		private List<AdventureTeamMainTabItem> mainTabItems;

		// Token: 0x040071DE RID: 29150
		private AdventureTeamMainTabType _defaultSelectedType;
	}
}
