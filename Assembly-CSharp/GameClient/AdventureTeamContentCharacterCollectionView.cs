using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200140A RID: 5130
	public class AdventureTeamContentCharacterCollectionView : AdventureTeamContentBaseView
	{
		// Token: 0x0600C694 RID: 50836 RVA: 0x002FEED7 File Offset: 0x002FD2D7
		private void Awake()
		{
			this._Init();
			this._BindUIEvent();
		}

		// Token: 0x0600C695 RID: 50837 RVA: 0x002FEEE5 File Offset: 0x002FD2E5
		private void OnDestroy()
		{
			this._Clear();
			this._UnBindUIEvent();
		}

		// Token: 0x0600C696 RID: 50838 RVA: 0x002FEEF4 File Offset: 0x002FD2F4
		private void _Init()
		{
			if (this.jobMainList != null && !this.jobMainList.IsInitialised())
			{
				this.jobMainList.Initialize();
				ComUIListScriptExtension comUIListScriptExtension = this.jobMainList;
				comUIListScriptExtension.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptExtension.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnJobMainListItemVisible));
				ComUIListScriptExtension comUIListScriptExtension2 = this.jobMainList;
				comUIListScriptExtension2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptExtension2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnJobMainListItemRecycle));
				ComUIListScriptExtension comUIListScriptExtension3 = this.jobMainList;
				comUIListScriptExtension3.OnItemLocalPosAllInRectView = (ComUIListScriptExtension.OnItemLocalPosAllInRectViewDelegate)Delegate.Combine(comUIListScriptExtension3.OnItemLocalPosAllInRectView, new ComUIListScriptExtension.OnItemLocalPosAllInRectViewDelegate(this._OnJobMainListItemAllInRectView));
			}
		}

		// Token: 0x0600C697 RID: 50839 RVA: 0x002FEFA4 File Offset: 0x002FD3A4
		private void _Clear()
		{
			if (this.jobMainList != null)
			{
				this.jobMainList.SetElementAmount(0);
				ComUIListScriptExtension comUIListScriptExtension = this.jobMainList;
				comUIListScriptExtension.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptExtension.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnJobMainListItemVisible));
				ComUIListScriptExtension comUIListScriptExtension2 = this.jobMainList;
				comUIListScriptExtension2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptExtension2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnJobMainListItemRecycle));
				ComUIListScriptExtension comUIListScriptExtension3 = this.jobMainList;
				comUIListScriptExtension3.OnItemLocalPosAllInRectView = (ComUIListScriptExtension.OnItemLocalPosAllInRectViewDelegate)Delegate.Remove(comUIListScriptExtension3.OnItemLocalPosAllInRectView, new ComUIListScriptExtension.OnItemLocalPosAllInRectViewDelegate(this._OnJobMainListItemAllInRectView));
				this.jobMainList.UnInitialize();
			}
			this.currJobTabId = 0;
		}

		// Token: 0x0600C698 RID: 50840 RVA: 0x002FF055 File Offset: 0x002FD455
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamCollectionInfoRes, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamCollectionInfoRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._OnLevelChanged));
		}

		// Token: 0x0600C699 RID: 50841 RVA: 0x002FF08A File Offset: 0x002FD48A
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamCollectionInfoRes, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamCollectionInfoRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._OnLevelChanged));
		}

		// Token: 0x0600C69A RID: 50842 RVA: 0x002FF0C0 File Offset: 0x002FD4C0
		private void _OnJobTabChanged(bool isOn, int index)
		{
			if (isOn)
			{
				int[] totalBaseJobTabIds = DataManager<AdventureTeamDataManager>.GetInstance().GetTotalBaseJobTabIds();
				if (totalBaseJobTabIds == null)
				{
					return;
				}
				if (index < 0 && index >= totalBaseJobTabIds.Length)
				{
					return;
				}
				this.currJobTabId = totalBaseJobTabIds[index];
				this._RefreshJobMainList();
			}
		}

		// Token: 0x0600C69B RID: 50843 RVA: 0x002FF108 File Offset: 0x002FD508
		private void _OnJobMainListItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			List<CharacterCollectionModel> characterCollectionModelsByBaseJobId = DataManager<AdventureTeamDataManager>.GetInstance().GetCharacterCollectionModelsByBaseJobId(this.currJobTabId);
			if (characterCollectionModelsByBaseJobId == null || item.m_index >= characterCollectionModelsByBaseJobId.Count)
			{
				return;
			}
			CharacterCollectionModel characterCollectionModel = characterCollectionModelsByBaseJobId[item.m_index];
			AdventureTeamCharacterCollectionItem component = item.GetComponent<AdventureTeamCharacterCollectionItem>();
			if (component != null && characterCollectionModel != null)
			{
				AdventureTeamCharacterCollectionItem adventureTeamCharacterCollectionItem = component;
				adventureTeamCharacterCollectionItem.onWaitActiveEffectPlayEnd = (AdventureTeamCharacterCollectionItem.WaitActiveEffectPlayEndHandler)Delegate.Combine(adventureTeamCharacterCollectionItem.onWaitActiveEffectPlayEnd, new AdventureTeamCharacterCollectionItem.WaitActiveEffectPlayEndHandler(this._OnWaitActiveEffectPlayEnd));
				component.InitCollectionItem(characterCollectionModel);
				bool flag = this.jobMainList.IsElementTotalInScrollArea(item.m_index);
				if (flag && characterCollectionModel.needPlay && component.gameObject.activeInHierarchy)
				{
					component.PlayNewJobActivate();
				}
			}
		}

		// Token: 0x0600C69C RID: 50844 RVA: 0x002FF1D4 File Offset: 0x002FD5D4
		private void _OnJobMainListItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamCharacterCollectionItem component = item.GetComponent<AdventureTeamCharacterCollectionItem>();
			if (component != null)
			{
				AdventureTeamCharacterCollectionItem adventureTeamCharacterCollectionItem = component;
				adventureTeamCharacterCollectionItem.onWaitActiveEffectPlayEnd = (AdventureTeamCharacterCollectionItem.WaitActiveEffectPlayEndHandler)Delegate.Remove(adventureTeamCharacterCollectionItem.onWaitActiveEffectPlayEnd, new AdventureTeamCharacterCollectionItem.WaitActiveEffectPlayEndHandler(this._OnWaitActiveEffectPlayEnd));
				component.Clear();
			}
		}

		// Token: 0x0600C69D RID: 50845 RVA: 0x002FF22C File Offset: 0x002FD62C
		private void _OnJobMainListItemAllInRectView(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			List<CharacterCollectionModel> characterCollectionModelsByBaseJobId = DataManager<AdventureTeamDataManager>.GetInstance().GetCharacterCollectionModelsByBaseJobId(this.currJobTabId);
			if (characterCollectionModelsByBaseJobId == null || item.m_index >= characterCollectionModelsByBaseJobId.Count)
			{
				return;
			}
			CharacterCollectionModel characterCollectionModel = characterCollectionModelsByBaseJobId[item.m_index];
			AdventureTeamCharacterCollectionItem component = item.GetComponent<AdventureTeamCharacterCollectionItem>();
			if (component != null && characterCollectionModel != null && characterCollectionModel.needPlay && component.gameObject.activeInHierarchy)
			{
				component.PlayNewJobActivate();
			}
		}

		// Token: 0x0600C69E RID: 50846 RVA: 0x002FF2B6 File Offset: 0x002FD6B6
		private void _OnWaitActiveEffectPlayEnd(CharacterCollectionModel collectionData)
		{
			if (collectionData == null)
			{
				return;
			}
			DataManager<AdventureTeamDataManager>.GetInstance().ReqClearActivatedJob(new int[]
			{
				collectionData.jobTableId
			});
			DataManager<AdventureTeamDataManager>.GetInstance().ChangeSelectJobPlayStatus(collectionData, false);
		}

		// Token: 0x0600C69F RID: 50847 RVA: 0x002FF2E4 File Offset: 0x002FD6E4
		private void _OnAdventureTeamCollectionInfoRes(UIEvent uiEvent)
		{
			this._RefreshJobMainList();
		}

		// Token: 0x0600C6A0 RID: 50848 RVA: 0x002FF2EC File Offset: 0x002FD6EC
		private void _OnLevelChanged(UIEvent uiEvent)
		{
			this._TryRefreshView();
		}

		// Token: 0x0600C6A1 RID: 50849 RVA: 0x002FF2F4 File Offset: 0x002FD6F4
		private void _RefreshJobMainList()
		{
			List<CharacterCollectionModel> characterCollectionModelsByBaseJobId = DataManager<AdventureTeamDataManager>.GetInstance().GetCharacterCollectionModelsByBaseJobId(this.currJobTabId);
			if (this.jobMainList != null && characterCollectionModelsByBaseJobId != null)
			{
				this.jobMainList.SetElementAmount(characterCollectionModelsByBaseJobId.Count);
				if (this.currJobTabId != 0)
				{
					this.jobMainList.ResetContentPosition();
				}
			}
		}

		// Token: 0x0600C6A2 RID: 50850 RVA: 0x002FF350 File Offset: 0x002FD750
		private void _TryRefreshView()
		{
			this._RefreshJobMainList();
			int[] baseJobIds = new int[]
			{
				this.currJobTabId
			};
			if (this.currJobTabId == 0)
			{
				baseJobIds = DataManager<AdventureTeamDataManager>.GetInstance().GetTotalBaseJobTabIds();
			}
			DataManager<AdventureTeamDataManager>.GetInstance().ReqOwnJobInfo(baseJobIds);
		}

		// Token: 0x0600C6A3 RID: 50851 RVA: 0x002FF394 File Offset: 0x002FD794
		public override void InitData()
		{
			string[] totalBaseJobNames = DataManager<AdventureTeamDataManager>.GetInstance().GetTotalBaseJobNames();
			if (totalBaseJobNames != null && totalBaseJobNames.Length > 0 && this.jobTabControl != null)
			{
				this.jobTabControl.Init(totalBaseJobNames, this.jobTabResPath, new ComTabGroup.OnToggleValueChanged(this._OnJobTabChanged), null, this.currJobTabId, null, null);
			}
			this._TryRefreshView();
		}

		// Token: 0x0600C6A4 RID: 50852 RVA: 0x002FF3F9 File Offset: 0x002FD7F9
		public override void OnEnableView()
		{
			this._TryRefreshView();
		}

		// Token: 0x040071F5 RID: 29173
		[Header("职业选择页签")]
		[SerializeField]
		private ComTabGroup jobTabControl;

		// Token: 0x040071F6 RID: 29174
		[Header("页签预制体")]
		[SerializeField]
		private string jobTabResPath = "UIFlatten/Prefabs/AdventureTeam/ComHorizonalTabItem";

		// Token: 0x040071F7 RID: 29175
		[Header("职业主界面")]
		[SerializeField]
		private ComUIListScriptExtension jobMainList;

		// Token: 0x040071F8 RID: 29176
		private int currJobTabId;
	}
}
