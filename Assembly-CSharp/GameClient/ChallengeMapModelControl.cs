using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014CF RID: 5327
	public class ChallengeMapModelControl : MonoBehaviour
	{
		// Token: 0x0600CE7C RID: 52860 RVA: 0x0032E301 File Offset: 0x0032C701
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE7D RID: 52861 RVA: 0x0032E309 File Offset: 0x0032C709
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CE7E RID: 52862 RVA: 0x0032E318 File Offset: 0x0032C718
		private void BindEvents()
		{
			if (this.modelItemList != null)
			{
				this.modelItemList.Initialize();
				ComUIListScript comUIListScript = this.modelItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnModelItemVisible));
			}
		}

		// Token: 0x0600CE7F RID: 52863 RVA: 0x0032E368 File Offset: 0x0032C768
		private void UnBindEvents()
		{
			if (this.modelItemList != null)
			{
				ComUIListScript comUIListScript = this.modelItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnModelItemVisible));
			}
		}

		// Token: 0x0600CE80 RID: 52864 RVA: 0x0032E3A2 File Offset: 0x0032C7A2
		private void ClearData()
		{
			this._defaultModelType = DungeonModelTable.eType.Type_None;
			this._toggleDataModelList = null;
			this._onChallengeMapToggleClick = null;
		}

		// Token: 0x0600CE81 RID: 52865 RVA: 0x0032E3B9 File Offset: 0x0032C7B9
		public void InitMapModelControl(DungeonModelTable.eType defaultModelType, OnChallengeMapToggleClick onChallengeMapToggleClick)
		{
			this._defaultModelType = defaultModelType;
			this._onChallengeMapToggleClick = onChallengeMapToggleClick;
			this.InitMapModelContent();
		}

		// Token: 0x0600CE82 RID: 52866 RVA: 0x0032E3D0 File Offset: 0x0032C7D0
		private void InitToggleDataModelList()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<DungeonModelTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					DungeonModelTable dungeonModelTable = keyValuePair.Value as DungeonModelTable;
					if (dungeonModelTable != null)
					{
						if (dungeonModelTable.Type == DungeonModelTable.eType.VoidCrackModel)
						{
							FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(75, string.Empty, string.Empty);
							if (tableItem == null)
							{
								continue;
							}
							if (!Utility.IsUnLockArea(tableItem.AreaID))
							{
								continue;
							}
						}
						if (dungeonModelTable.Type != DungeonModelTable.eType.TeamDuplicationModel || TeamDuplicationUtility.IsTeamDuplicationServerSwitchOpen())
						{
							if (dungeonModelTable.IsShowTab != 0)
							{
								ChallengeMapModelDataModel challengeMapModelDataModel = new ChallengeMapModelDataModel();
								challengeMapModelDataModel.ModelType = dungeonModelTable.Type;
								challengeMapModelDataModel.ToggleName = dungeonModelTable.Name;
								challengeMapModelDataModel.ModelId = dungeonModelTable.ID;
								if (this._toggleDataModelList == null)
								{
									this._toggleDataModelList = new List<ChallengeMapModelDataModel>();
								}
								this._toggleDataModelList.Add(challengeMapModelDataModel);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600CE83 RID: 52867 RVA: 0x0032E4E4 File Offset: 0x0032C8E4
		private void InitMapModelContent()
		{
			if (this._defaultModelType == DungeonModelTable.eType.Type_None)
			{
				this._defaultModelType = DungeonModelTable.eType.DeepModel;
			}
			this.InitToggleDataModelList();
			if (this.modelItemList != null)
			{
				if (this._toggleDataModelList == null)
				{
					this.modelItemList.SetElementAmount(0);
				}
				else
				{
					this.modelItemList.SetElementAmount(this._toggleDataModelList.Count);
				}
			}
		}

		// Token: 0x0600CE84 RID: 52868 RVA: 0x0032E54C File Offset: 0x0032C94C
		private void OnModelItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChallengeMapModelItem component = item.GetComponent<ChallengeMapModelItem>();
			if (component == null)
			{
				return;
			}
			if (this._toggleDataModelList != null && item.m_index >= 0 && item.m_index < this._toggleDataModelList.Count)
			{
				ChallengeMapModelDataModel challengeMapModelDataModel = this._toggleDataModelList[item.m_index];
				if (challengeMapModelDataModel != null)
				{
					if (this._defaultModelType == challengeMapModelDataModel.ModelType)
					{
						component.Init(challengeMapModelDataModel, new OnChallengeMapToggleClick(this.OnTabClicked), true);
					}
					else
					{
						component.Init(challengeMapModelDataModel, new OnChallengeMapToggleClick(this.OnTabClicked), false);
					}
				}
			}
		}

		// Token: 0x0600CE85 RID: 52869 RVA: 0x0032E5FD File Offset: 0x0032C9FD
		private void OnTabClicked(DungeonModelTable.eType modelType)
		{
			if (this._onChallengeMapToggleClick != null)
			{
				this._onChallengeMapToggleClick(modelType);
			}
		}

		// Token: 0x0400789C RID: 30876
		private DungeonModelTable.eType _defaultModelType;

		// Token: 0x0400789D RID: 30877
		private List<ChallengeMapModelDataModel> _toggleDataModelList = new List<ChallengeMapModelDataModel>();

		// Token: 0x0400789E RID: 30878
		private OnChallengeMapToggleClick _onChallengeMapToggleClick;

		// Token: 0x0400789F RID: 30879
		[SerializeField]
		private ComUIListScript modelItemList;
	}
}
