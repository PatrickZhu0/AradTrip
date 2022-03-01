using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001550 RID: 5456
	internal class TalkTabFrame : ClientFrame
	{
		// Token: 0x0600D53D RID: 54589 RVA: 0x0035514E File Offset: 0x0035354E
		public static void Open()
		{
			ClientFrame.OpenTargetFrame<TalkTabFrame>(FrameLayer.Middle, null);
		}

		// Token: 0x0600D53E RID: 54590 RVA: 0x00355158 File Offset: 0x00353558
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/Talktab";
		}

		// Token: 0x0600D53F RID: 54591 RVA: 0x0035515F File Offset: 0x0035355F
		protected override void _OnOpenFrame()
		{
			this._InitFilters();
		}

		// Token: 0x0600D540 RID: 54592 RVA: 0x00355167 File Offset: 0x00353567
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600D541 RID: 54593 RVA: 0x00355169 File Offset: 0x00353569
		[UIEventHandle("Close")]
		private void _OnClickClose()
		{
			this.frameMgr.CloseFrame<TalkTabFrame>(this, false);
		}

		// Token: 0x0600D542 RID: 54594 RVA: 0x00355178 File Offset: 0x00353578
		private void _InitFilters()
		{
			string[] array = new string[]
			{
				"TabC",
				string.Empty,
				string.Empty,
				"TabB",
				"TabA",
				"TabD",
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]))
				{
					Toggle toggle = Utility.FindComponent<Toggle>(this.frame, array[i], true);
					toggle.isOn = DataManager<SystemConfigManager>.GetInstance().IsChatToggleOn((ChatType)i);
					ChatType eChatType = (ChatType)i;
					GameObject goCheckMark = Utility.FindChild(toggle.gameObject, "CheckMark");
					goCheckMark.CustomActive(toggle.isOn);
					toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						DataManager<SystemConfigManager>.GetInstance().SetChatToggle(eChatType, bValue);
						goCheckMark.CustomActive(bValue);
					});
				}
			}
		}
	}
}
