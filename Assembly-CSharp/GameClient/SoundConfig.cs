using System;

namespace GameClient
{
	// Token: 0x020045CD RID: 17869
	public class SoundConfig
	{
		// Token: 0x060191B4 RID: 102836 RVA: 0x007EEA33 File Offset: 0x007ECE33
		public SoundConfig(float volume, bool mute)
		{
			this.fVolume = (double)volume;
			this.bMute = mute;
		}

		// Token: 0x060191B5 RID: 102837 RVA: 0x007EEA59 File Offset: 0x007ECE59
		public SoundConfig()
		{
			this.fVolume = 0.55;
			this.bMute = false;
		}

		// Token: 0x170020A0 RID: 8352
		// (get) Token: 0x060191B6 RID: 102838 RVA: 0x007EEA86 File Offset: 0x007ECE86
		// (set) Token: 0x060191B7 RID: 102839 RVA: 0x007EEA8E File Offset: 0x007ECE8E
		public double Volume
		{
			get
			{
				return this.fVolume;
			}
			set
			{
				this.fVolume = value;
			}
		}

		// Token: 0x170020A1 RID: 8353
		// (get) Token: 0x060191B8 RID: 102840 RVA: 0x007EEA97 File Offset: 0x007ECE97
		// (set) Token: 0x060191B9 RID: 102841 RVA: 0x007EEA9F File Offset: 0x007ECE9F
		public bool Mute
		{
			get
			{
				return this.bMute;
			}
			set
			{
				this.bMute = value;
			}
		}

		// Token: 0x04011FFE RID: 73726
		private double fVolume = 0.55;

		// Token: 0x04011FFF RID: 73727
		private bool bMute;
	}
}
