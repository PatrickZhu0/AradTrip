using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014CB RID: 5323
	public class ChallengeMapView : MonoBehaviour
	{
		// Token: 0x0600CE5C RID: 52828 RVA: 0x0032DBE7 File Offset: 0x0032BFE7
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE5D RID: 52829 RVA: 0x0032DBEF File Offset: 0x0032BFEF
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CE5E RID: 52830 RVA: 0x0032DBFD File Offset: 0x0032BFFD
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x0600CE5F RID: 52831 RVA: 0x0032DC3C File Offset: 0x0032C03C
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CE60 RID: 52832 RVA: 0x0032DC5F File Offset: 0x0032C05F
		private void ClearData()
		{
			this._challengeParamDataModel = null;
		}

		// Token: 0x0600CE61 RID: 52833 RVA: 0x0032DC68 File Offset: 0x0032C068
		public void InitView(ChallengeMapParamDataModel paramDataModel)
		{
			DungeonModelTable.eType defaultModelType = DungeonModelTable.eType.DeepModel;
			if (paramDataModel != null && paramDataModel.ModelType != DungeonModelTable.eType.Type_None)
			{
				defaultModelType = paramDataModel.ModelType;
			}
			this._challengeParamDataModel = paramDataModel;
			if (this.contentControl != null)
			{
				this.contentControl.InitMapContentData(new OnContentEffectAction(this.OnContentEffectAction));
			}
			if (this.modelControl != null)
			{
				this.modelControl.InitMapModelControl(defaultModelType, new OnChallengeMapToggleClick(this.OnChallengeMapToggleClick));
			}
		}

		// Token: 0x0600CE62 RID: 52834 RVA: 0x0032DCE8 File Offset: 0x0032C0E8
		private void OnChallengeMapToggleClick(DungeonModelTable.eType modelType)
		{
			this.UpdateTitleAndModelControl(true);
			if (this.challengeMapMoneyControl != null)
			{
				this.challengeMapMoneyControl.Init(modelType);
			}
			if (this.contentControl != null)
			{
				this.contentControl.InitMapContentControl(modelType, this._challengeParamDataModel, null);
			}
			this._challengeParamDataModel = null;
		}

		// Token: 0x0600CE63 RID: 52835 RVA: 0x0032DD44 File Offset: 0x0032C144
		private void OnContentEffectAction(bool flag)
		{
			this.UpdateTitleAndModelControl(flag);
		}

		// Token: 0x0600CE64 RID: 52836 RVA: 0x0032DD50 File Offset: 0x0032C150
		private void UpdateTitleAndModelControl(bool flag)
		{
			if (this.modelControl != null)
			{
				this.modelControl.gameObject.CustomActive(flag);
			}
			if (this.titleRoot != null)
			{
				this.titleRoot.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CE65 RID: 52837 RVA: 0x0032DDA1 File Offset: 0x0032C1A1
		private void OnCloseFrame()
		{
			ChallengeUtility.OnCloseChallengeMapFrame();
		}

		// Token: 0x04007884 RID: 30852
		private ChallengeMapParamDataModel _challengeParamDataModel;

		// Token: 0x04007885 RID: 30853
		[Space(10f)]
		[Header("Close")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x04007886 RID: 30854
		[Space(30f)]
		[Header("ModelControl")]
		[Space(20f)]
		[SerializeField]
		private ChallengeMapModelControl modelControl;

		// Token: 0x04007887 RID: 30855
		[SerializeField]
		private ChallengeMapContentControl contentControl;

		// Token: 0x04007888 RID: 30856
		[Space(30f)]
		[Header("Title")]
		[Space(30f)]
		[SerializeField]
		private GameObject titleRoot;

		// Token: 0x04007889 RID: 30857
		[SerializeField]
		private ChallengeMapMoneyControl challengeMapMoneyControl;
	}
}
