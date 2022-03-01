using System;

namespace GameClient
{
	// Token: 0x02001573 RID: 5491
	public struct VoiceTalkConfig
	{
		// Token: 0x04007DED RID: 32237
		public string resPath;

		// Token: 0x04007DEE RID: 32238
		public PluginManager.VoiceSDKSwitch switchType;

		// Token: 0x04007DEF RID: 32239
		public bool isMicOnAtFirst;

		// Token: 0x04007DF0 RID: 32240
		public bool isPlayerOnAtFirst;

		// Token: 0x04007DF1 RID: 32241
		public bool isGlobalSilenceAtFirst;
	}
}
