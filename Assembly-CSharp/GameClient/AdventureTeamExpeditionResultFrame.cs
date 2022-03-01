using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001415 RID: 5141
	public class AdventureTeamExpeditionResultFrame : ClientFrame
	{
		// Token: 0x0600C749 RID: 51017 RVA: 0x00302F02 File Offset: 0x00301302
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventureTeam/AdventureTeamExpeditionResultFrame";
		}

		// Token: 0x0600C74A RID: 51018 RVA: 0x00302F0C File Offset: 0x0030130C
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				return;
			}
			this.mFinishedMapModels = (this.userData as List<ExpeditionMapModel>);
			if (this.mAdventureTeamChangeNameView != null)
			{
				this.mAdventureTeamChangeNameView.InitView(this.mFinishedMapModels);
			}
		}

		// Token: 0x0600C74B RID: 51019 RVA: 0x00302F58 File Offset: 0x00301358
		protected override void _OnCloseFrame()
		{
			if (this.mFinishedMapModels != null)
			{
				this.mFinishedMapModels.Clear();
			}
			if (this.tempLastNetMapInfo != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionResultFrameClose, new ExpeditionMapNetInfo
				{
					mapId = this.tempLastNetMapInfo.mapId
				}, null, null, null);
				this.tempLastNetMapInfo = null;
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionResultFrameClose, null, null, null, null);
			}
		}

		// Token: 0x0600C74C RID: 51020 RVA: 0x00302FD0 File Offset: 0x003013D0
		protected override void _bindExUI()
		{
			this.mAdventureTeamChangeNameView = this.mBind.GetCom<AdventureTeamExpeditionResultView>("MainContentView");
			this.mOkButton = this.mBind.GetCom<Button>("okButton");
			this.mOkButton.onClick.AddListener(new UnityAction(this._onOkButtonButtonClick));
		}

		// Token: 0x0600C74D RID: 51021 RVA: 0x00303025 File Offset: 0x00301425
		protected override void _unbindExUI()
		{
			this.mAdventureTeamChangeNameView = null;
			this.mOkButton.onClick.RemoveListener(new UnityAction(this._onOkButtonButtonClick));
			this.mOkButton = null;
		}

		// Token: 0x0600C74E RID: 51022 RVA: 0x00303054 File Offset: 0x00301454
		private void _onOkButtonButtonClick()
		{
			if (this.mFinishedMapModels != null && this.mFinishedMapModels.Count > 0)
			{
				if (this.mFinishedMapModels[this.mFinishedMapModels.Count - 1] != null)
				{
					this.tempLastNetMapInfo = this.mFinishedMapModels[this.mFinishedMapModels.Count - 1].mapNetInfo;
				}
				for (int i = 0; i < this.mFinishedMapModels.Count; i++)
				{
					ExpeditionMapModel expeditionMapModel = this.mFinishedMapModels[i];
					if (expeditionMapModel != null && expeditionMapModel.mapNetInfo != null)
					{
						DataManager<AdventureTeamDataManager>.GetInstance().ReqGetExpeditionRewards(expeditionMapModel.mapNetInfo.mapId);
					}
				}
			}
			base.Close(false);
		}

		// Token: 0x04007266 RID: 29286
		private List<ExpeditionMapModel> mFinishedMapModels;

		// Token: 0x04007267 RID: 29287
		private ExpeditionMapNetInfo tempLastNetMapInfo;

		// Token: 0x04007268 RID: 29288
		private AdventureTeamExpeditionResultView mAdventureTeamChangeNameView;

		// Token: 0x04007269 RID: 29289
		private Button mOkButton;
	}
}
