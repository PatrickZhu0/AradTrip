using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001439 RID: 5177
	public class ArtifactJarDailyRewardFrame : ClientFrame
	{
		// Token: 0x0600C8F6 RID: 51446 RVA: 0x0030DC18 File Offset: 0x0030C018
		protected override void _bindExUI()
		{
			this.mArtifactJarDailyRewardView = this.mBind.GetCom<ArtifactJarDailyRewardView>("ArtifactJarDailyRewardView");
		}

		// Token: 0x0600C8F7 RID: 51447 RVA: 0x0030DC30 File Offset: 0x0030C030
		protected override void _unbindExUI()
		{
			this.mArtifactJarDailyRewardView = null;
		}

		// Token: 0x0600C8F8 RID: 51448 RVA: 0x0030DC39 File Offset: 0x0030C039
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ArtifactJar/ArtifactJarDailyReward";
		}

		// Token: 0x0600C8F9 RID: 51449 RVA: 0x0030DC40 File Offset: 0x0030C040
		protected override void _OnOpenFrame()
		{
			this._BindUIEvent();
		}

		// Token: 0x0600C8FA RID: 51450 RVA: 0x0030DC48 File Offset: 0x0030C048
		protected override void _OnCloseFrame()
		{
			this._UnBindUIEvent();
		}

		// Token: 0x0600C8FB RID: 51451 RVA: 0x0030DC50 File Offset: 0x0030C050
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ArtifactDailyRewardUpdate, new ClientEventSystem.UIEventHandler(this._UpdateToggle));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ArtifactDailyRecordUpdate, new ClientEventSystem.UIEventHandler(this._UpdateRecord));
		}

		// Token: 0x0600C8FC RID: 51452 RVA: 0x0030DC88 File Offset: 0x0030C088
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ArtifactDailyRewardUpdate, new ClientEventSystem.UIEventHandler(this._UpdateToggle));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ArtifactDailyRecordUpdate, new ClientEventSystem.UIEventHandler(this._UpdateRecord));
		}

		// Token: 0x0600C8FD RID: 51453 RVA: 0x0030DCC0 File Offset: 0x0030C0C0
		private void _UpdateToggle(UIEvent uiEvent)
		{
			this.mArtifactJarDailyRewardView.InitView();
		}

		// Token: 0x0600C8FE RID: 51454 RVA: 0x0030DCD0 File Offset: 0x0030C0D0
		private void _UpdateRecord(UIEvent uiEvent)
		{
			int jarId = (int)uiEvent.Param1;
			this.mArtifactJarDailyRewardView.UpdateRecord(jarId);
		}

		// Token: 0x040073EF RID: 29679
		private List<ArtifactJarBuy> allJarData = new List<ArtifactJarBuy>();

		// Token: 0x040073F0 RID: 29680
		private ArtifactJarDailyRewardView mArtifactJarDailyRewardView;
	}
}
