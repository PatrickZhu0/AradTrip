using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

namespace _Settings
{
	// Token: 0x02001A23 RID: 6691
	public class HelpDebugSettings : SettingsBindUI
	{
		// Token: 0x060106D1 RID: 67281 RVA: 0x0049EE4B File Offset: 0x0049D24B
		public HelpDebugSettings(GameObject root, ClientFrame frame) : base(root, frame)
		{
		}

		// Token: 0x060106D2 RID: 67282 RVA: 0x0049EE65 File Offset: 0x0049D265
		protected override string GetCurrGameObjectPath()
		{
			return "UIRoot/UI2DRoot/Middle/SettingPanel/Panel/Contents/debug";
		}

		// Token: 0x060106D3 RID: 67283 RVA: 0x0049EE6C File Offset: 0x0049D26C
		protected override void InitBind()
		{
			for (int i = 0; i < HelpDebugSettings.debugCount; i++)
			{
				string name = string.Format("DebugSetting{0}", i + 1);
				Toggle com = this.mBind.GetCom<Toggle>(name);
				com.onValueChanged.AddListener(delegate(bool isOn)
				{
				});
				this.debugSettings[i] = com;
				com.isOn = false;
			}
		}

		// Token: 0x060106D4 RID: 67284 RVA: 0x0049EEEC File Offset: 0x0049D2EC
		protected override void UnInitBind()
		{
			for (int i = 0; i < HelpDebugSettings.debugCount; i++)
			{
				if (this.debugSettings[i] != null)
				{
					this.debugSettings[i].onValueChanged.RemoveAllListeners();
				}
			}
		}

		// Token: 0x060106D5 RID: 67285 RVA: 0x0049EF34 File Offset: 0x0049D334
		protected override void OnShowOut()
		{
		}

		// Token: 0x060106D6 RID: 67286 RVA: 0x0049EF36 File Offset: 0x0049D336
		protected override void OnHideIn()
		{
		}

		// Token: 0x0400A6F4 RID: 42740
		private static string[] DEBUG_NAMES = new string[]
		{
			"DummyEffect",
			"DisableAnimMaterial",
			"DisableGameObjPool",
			"DisableAnimation",
			"DisableHitText",
			"DisableAudio",
			"DisableChatDisplay",
			"DisableModuleLoad",
			"DisableSnap",
			"DisableAI",
			"DisablePreload",
			"EnableActionFrameCache",
			"EnableDSkillDataCache",
			"EnableTestFashionEquip"
		};

		// Token: 0x0400A6F5 RID: 42741
		private static int debugCount = 14;

		// Token: 0x0400A6F6 RID: 42742
		private Toggle[] debugSettings = new Toggle[HelpDebugSettings.debugCount];
	}
}
