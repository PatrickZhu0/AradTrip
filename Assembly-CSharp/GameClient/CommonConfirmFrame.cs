using System;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000E16 RID: 3606
	public class CommonConfirmFrame : ClientFrame
	{
		// Token: 0x06009064 RID: 36964 RVA: 0x001AB16F File Offset: 0x001A956F
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x06009065 RID: 36965 RVA: 0x001AB171 File Offset: 0x001A9571
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06009066 RID: 36966 RVA: 0x001AB173 File Offset: 0x001A9573
		public override string GetPrefabPath()
		{
			return string.Empty;
		}

		// Token: 0x06009067 RID: 36967 RVA: 0x001AB17A File Offset: 0x001A957A
		[UIEventHandle("main/Panel/BtnOK")]
		private void OnClickOK()
		{
			this.frameMgr.CloseFrame<CommonConfirmFrame>(this, false);
		}

		// Token: 0x06009068 RID: 36968 RVA: 0x001AB189 File Offset: 0x001A9589
		public void SetMsgContent(string str)
		{
		}

		// Token: 0x06009069 RID: 36969 RVA: 0x001AB18B File Offset: 0x001A958B
		public void SetTitleContent(string str)
		{
		}

		// Token: 0x0600906A RID: 36970 RVA: 0x001AB190 File Offset: 0x001A9590
		public void SetNotifyDataByTable(CommonTipsDesc NotifyData, string content)
		{
			if (NotifyData != null)
			{
				this.SetTitleContent(NotifyData.TitleText);
				this.SetMsgContent(content);
				if (!(NotifyData.ButtonText != string.Empty) || !(NotifyData.ButtonText != "-") || NotifyData.ButtonText != "0")
				{
				}
			}
		}

		// Token: 0x0600906B RID: 36971 RVA: 0x001AB1F5 File Offset: 0x001A95F5
		public void AddListener(UnityAction OnOKCallBack)
		{
			if (OnOKCallBack != null)
			{
			}
		}

		// Token: 0x0600906C RID: 36972 RVA: 0x001AB1FD File Offset: 0x001A95FD
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600906D RID: 36973 RVA: 0x001AB200 File Offset: 0x001A9600
		protected override void _OnUpdate(float timeElapsed)
		{
		}
	}
}
