using System;

namespace GameClient
{
	// Token: 0x020045CE RID: 17870
	public class SystemConfigData
	{
		// Token: 0x170020A2 RID: 8354
		// (get) Token: 0x060191BB RID: 102843 RVA: 0x007EEADD File Offset: 0x007ECEDD
		// (set) Token: 0x060191BC RID: 102844 RVA: 0x007EEAE5 File Offset: 0x007ECEE5
		public SoundConfig SoundConfig
		{
			get
			{
				return this.kSoundConfig;
			}
			set
			{
				this.kSoundConfig = value;
			}
		}

		// Token: 0x170020A3 RID: 8355
		// (get) Token: 0x060191BD RID: 102845 RVA: 0x007EEAEE File Offset: 0x007ECEEE
		// (set) Token: 0x060191BE RID: 102846 RVA: 0x007EEAF6 File Offset: 0x007ECEF6
		public SoundConfig MusicConfig
		{
			get
			{
				return this.kMusicConfig;
			}
			set
			{
				this.kMusicConfig = value;
			}
		}

		// Token: 0x170020A4 RID: 8356
		// (get) Token: 0x060191BF RID: 102847 RVA: 0x007EEAFF File Offset: 0x007ECEFF
		// (set) Token: 0x060191C0 RID: 102848 RVA: 0x007EEB07 File Offset: 0x007ECF07
		public ChatConfig ChatConfig
		{
			get
			{
				return this.kChatConfig;
			}
			set
			{
				this.kChatConfig = value;
			}
		}

		// Token: 0x04012000 RID: 73728
		private SoundConfig kSoundConfig = new SoundConfig(0.55f, false);

		// Token: 0x04012001 RID: 73729
		private SoundConfig kMusicConfig = new SoundConfig(0.86f, false);

		// Token: 0x04012002 RID: 73730
		private ChatConfig kChatConfig = new ChatConfig();
	}
}
