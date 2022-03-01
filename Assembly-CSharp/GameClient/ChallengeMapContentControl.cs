using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014CC RID: 5324
	public class ChallengeMapContentControl : MonoBehaviour
	{
		// Token: 0x0600CE67 RID: 52839 RVA: 0x0032DDB0 File Offset: 0x0032C1B0
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE68 RID: 52840 RVA: 0x0032DDB8 File Offset: 0x0032C1B8
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CE69 RID: 52841 RVA: 0x0032DDC6 File Offset: 0x0032C1C6
		private void BindEvents()
		{
		}

		// Token: 0x0600CE6A RID: 52842 RVA: 0x0032DDC8 File Offset: 0x0032C1C8
		private void UnBindEvents()
		{
		}

		// Token: 0x0600CE6B RID: 52843 RVA: 0x0032DDCA File Offset: 0x0032C1CA
		private void ClearData()
		{
			this._baseDungeonId = 0;
			this._detailDungeonId = 0;
			this._modelType = DungeonModelTable.eType.Type_None;
			this._paramDataModel = null;
		}

		// Token: 0x0600CE6C RID: 52844 RVA: 0x0032DDE8 File Offset: 0x0032C1E8
		public void InitMapContentData(OnContentEffectAction onContentEffectAction)
		{
			this._onContentEffectAction = onContentEffectAction;
		}

		// Token: 0x0600CE6D RID: 52845 RVA: 0x0032DDF1 File Offset: 0x0032C1F1
		public void InitMapContentControl(DungeonModelTable.eType modelType, ChallengeMapParamDataModel mapParamDataModel = null, OnContentEffectAction onContentEffectAction = null)
		{
			this._modelType = modelType;
			this._paramDataModel = mapParamDataModel;
			this.InitMapContent();
		}

		// Token: 0x0600CE6E RID: 52846 RVA: 0x0032DE08 File Offset: 0x0032C208
		private void InitMapContent()
		{
			this.ResetContentRoot();
			switch (this._modelType)
			{
			case DungeonModelTable.eType.DeepModel:
				this.OnDeepClicked();
				break;
			case DungeonModelTable.eType.AncientModel:
				this.OnAncientClicked();
				break;
			case DungeonModelTable.eType.WeekHellModel:
				this.OnWeekHellClicked();
				break;
			case DungeonModelTable.eType.VoidCrackModel:
				this.OnVoidCrackClicked();
				break;
			case DungeonModelTable.eType.TeamDuplicationModel:
				this.OnTeamDuplicationClicked();
				break;
			}
		}

		// Token: 0x0600CE6F RID: 52847 RVA: 0x0032DE80 File Offset: 0x0032C280
		private ChallengeMapViewControl LoadContentBaseView(GameObject contentRoot)
		{
			if (contentRoot == null)
			{
				return null;
			}
			ChallengeMapViewControl result = null;
			UIPrefabWrapper component = contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(contentRoot.transform, false);
					result = gameObject.GetComponent<ChallengeMapViewControl>();
				}
			}
			return result;
		}

		// Token: 0x0600CE70 RID: 52848 RVA: 0x0032DEE0 File Offset: 0x0032C2E0
		private void OnDeepClicked()
		{
			if (this.deepRoot != null && !this.deepRoot.activeSelf)
			{
				this.deepRoot.CustomActive(true);
			}
			if (this._deepView == null)
			{
				this._deepView = this.LoadContentBaseView(this.deepRoot);
				if (this._deepView != null)
				{
					this._deepView.InitMapModelControl(this._modelType, this._paramDataModel, this._onContentEffectAction);
				}
			}
			else if (this._deepView != null)
			{
				this._deepView.OnEnableView();
			}
		}

		// Token: 0x0600CE71 RID: 52849 RVA: 0x0032DF8C File Offset: 0x0032C38C
		private void OnAncientClicked()
		{
			if (this.ancientRoot != null && !this.ancientRoot.activeSelf)
			{
				this.ancientRoot.CustomActive(true);
			}
			if (this._ancientView == null)
			{
				this._ancientView = this.LoadContentBaseView(this.ancientRoot);
				if (this._ancientView != null)
				{
					this._ancientView.InitMapModelControl(this._modelType, this._paramDataModel, this._onContentEffectAction);
				}
			}
			else if (this._ancientView != null)
			{
				this._ancientView.OnEnableView();
			}
		}

		// Token: 0x0600CE72 RID: 52850 RVA: 0x0032E038 File Offset: 0x0032C438
		private void OnWeekHellClicked()
		{
			if (this.weekHellRoot != null && !this.weekHellRoot.activeSelf)
			{
				this.weekHellRoot.CustomActive(true);
			}
			if (this._weekHellView == null)
			{
				this._weekHellView = this.LoadContentBaseView(this.weekHellRoot);
				if (this._weekHellView != null)
				{
					this._weekHellView.InitMapModelControl(this._modelType, this._paramDataModel, this._onContentEffectAction);
				}
			}
			else if (this._weekHellView != null)
			{
				this._weekHellView.OnEnableView();
			}
		}

		// Token: 0x0600CE73 RID: 52851 RVA: 0x0032E0E4 File Offset: 0x0032C4E4
		private void OnVoidCrackClicked()
		{
			if (this.viodCrackRoot != null && !this.viodCrackRoot.activeSelf)
			{
				this.viodCrackRoot.CustomActive(true);
			}
			if (this._viodCrackView == null)
			{
				this._viodCrackView = this.LoadContentBaseView(this.viodCrackRoot);
				if (this._viodCrackView != null)
				{
					this._viodCrackView.InitMapModelControl(this._modelType, this._paramDataModel, this._onContentEffectAction);
				}
			}
			else if (this._viodCrackView != null)
			{
				this._viodCrackView.OnEnableView();
			}
		}

		// Token: 0x0600CE74 RID: 52852 RVA: 0x0032E190 File Offset: 0x0032C590
		private void OnTeamDuplicationClicked()
		{
			if (this.teamDuplicationRoot != null && !this.teamDuplicationRoot.activeSelf)
			{
				this.teamDuplicationRoot.CustomActive(true);
			}
			if (this._teamDuplicationView == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.teamDuplicationRoot);
				if (gameObject != null)
				{
					this._teamDuplicationView = gameObject.GetComponent<ChallengeTeamDuplicationView>();
					int teamDuplicationType = 1;
					if (this._paramDataModel != null)
					{
						teamDuplicationType = this._paramDataModel.BaseDungeonId;
					}
					if (this._teamDuplicationView != null)
					{
						this._teamDuplicationView.InitView(teamDuplicationType);
					}
				}
			}
			else
			{
				this._teamDuplicationView.OnEnableView();
			}
		}

		// Token: 0x0600CE75 RID: 52853 RVA: 0x0032E248 File Offset: 0x0032C648
		private void ResetContentRoot()
		{
			if (this.deepRoot != null)
			{
				this.deepRoot.CustomActive(false);
			}
			if (this.ancientRoot != null)
			{
				this.ancientRoot.CustomActive(false);
			}
			if (this.weekHellRoot != null)
			{
				this.weekHellRoot.CustomActive(false);
			}
			if (this.viodCrackRoot != null)
			{
				this.viodCrackRoot.CustomActive(false);
			}
			if (this.teamDuplicationRoot != null)
			{
				this.teamDuplicationRoot.CustomActive(false);
			}
		}

		// Token: 0x0400788A RID: 30858
		private DungeonModelTable.eType _modelType;

		// Token: 0x0400788B RID: 30859
		private ChallengeMapParamDataModel _paramDataModel;

		// Token: 0x0400788C RID: 30860
		private int _baseDungeonId;

		// Token: 0x0400788D RID: 30861
		private int _detailDungeonId;

		// Token: 0x0400788E RID: 30862
		private ChallengeMapViewControl _deepView;

		// Token: 0x0400788F RID: 30863
		private ChallengeMapViewControl _ancientView;

		// Token: 0x04007890 RID: 30864
		private ChallengeMapViewControl _weekHellView;

		// Token: 0x04007891 RID: 30865
		private ChallengeMapViewControl _viodCrackView;

		// Token: 0x04007892 RID: 30866
		private ChallengeTeamDuplicationView _teamDuplicationView;

		// Token: 0x04007893 RID: 30867
		private OnContentEffectAction _onContentEffectAction;

		// Token: 0x04007894 RID: 30868
		[Space(15f)]
		[Header("AuctionNewContent")]
		[SerializeField]
		private GameObject deepRoot;

		// Token: 0x04007895 RID: 30869
		[SerializeField]
		private GameObject ancientRoot;

		// Token: 0x04007896 RID: 30870
		[SerializeField]
		private GameObject weekHellRoot;

		// Token: 0x04007897 RID: 30871
		[SerializeField]
		private GameObject viodCrackRoot;

		// Token: 0x04007898 RID: 30872
		[SerializeField]
		private GameObject teamDuplicationRoot;
	}
}
