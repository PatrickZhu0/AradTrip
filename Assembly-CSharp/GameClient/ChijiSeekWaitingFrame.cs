using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001115 RID: 4373
	public class ChijiSeekWaitingFrame : ClientFrame
	{
		// Token: 0x0600A5EB RID: 42475 RVA: 0x00226145 File Offset: 0x00224545
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiSeekWaitFrame";
		}

		// Token: 0x0600A5EC RID: 42476 RVA: 0x0022614C File Offset: 0x0022454C
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateChijiPrepareScenePlayerNum, new ClientEventSystem.UIEventHandler(this.OnUpdateChijiPrepareScenePlayerNum));
			this.UpdateCountDownDesc();
		}

		// Token: 0x0600A5ED RID: 42477 RVA: 0x0022616F File Offset: 0x0022456F
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateChijiPrepareScenePlayerNum, new ClientEventSystem.UIEventHandler(this.OnUpdateChijiPrepareScenePlayerNum));
		}

		// Token: 0x0600A5EE RID: 42478 RVA: 0x0022618C File Offset: 0x0022458C
		private void OnUpdateChijiPrepareScenePlayerNum(UIEvent uiEvent)
		{
			this.UpdateCountDownDesc();
		}

		// Token: 0x0600A5EF RID: 42479 RVA: 0x00226194 File Offset: 0x00224594
		private void UpdateCountDownDesc()
		{
			this.mCountDown.text = TR.Value("Chiji_Seek_Wait_Desc", DataManager<ChijiDataManager>.GetInstance().PrepareScenePlayerNum, DataManager<ChijiDataManager>.GetInstance().PrepareSceneMaxPlayerNum);
		}

		// Token: 0x0600A5F0 RID: 42480 RVA: 0x002261C9 File Offset: 0x002245C9
		protected override void _bindExUI()
		{
			this.mCountDown = this.mBind.GetCom<Text>("CountDown");
		}

		// Token: 0x0600A5F1 RID: 42481 RVA: 0x002261E1 File Offset: 0x002245E1
		protected override void _unbindExUI()
		{
			this.mCountDown = null;
		}

		// Token: 0x04005CBE RID: 23742
		private Text mCountDown;
	}
}
