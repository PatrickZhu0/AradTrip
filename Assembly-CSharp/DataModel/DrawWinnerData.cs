using System;
using System.Runtime.InteropServices;
using Protocol;

namespace DataModel
{
	// Token: 0x02001CD6 RID: 7382
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct DrawWinnerData
	{
		// Token: 0x060121B3 RID: 74163 RVA: 0x0054C0D0 File Offset: 0x0054A4D0
		public DrawWinnerData(string rate, string name, string serverName, string platformName)
		{
			this = default(DrawWinnerData);
			this.Rate = rate;
			this.ServerName = serverName;
			this.Name = name;
			this.PlatformName = platformName;
		}

		// Token: 0x060121B4 RID: 74164 RVA: 0x0054C0F6 File Offset: 0x0054A4F6
		public DrawWinnerData(GambingParticipantInfo info)
		{
			this = default(DrawWinnerData);
			this.Rate = info.gambingRate;
			this.Name = info.participantName;
			this.ServerName = info.participantServerName;
			this.PlatformName = info.participantPlatform;
		}

		// Token: 0x17001DF6 RID: 7670
		// (get) Token: 0x060121B5 RID: 74165 RVA: 0x0054C12F File Offset: 0x0054A52F
		// (set) Token: 0x060121B6 RID: 74166 RVA: 0x0054C137 File Offset: 0x0054A537
		public string Name { get; private set; }

		// Token: 0x17001DF7 RID: 7671
		// (get) Token: 0x060121B7 RID: 74167 RVA: 0x0054C140 File Offset: 0x0054A540
		// (set) Token: 0x060121B8 RID: 74168 RVA: 0x0054C148 File Offset: 0x0054A548
		public string ServerName { get; private set; }

		// Token: 0x17001DF8 RID: 7672
		// (get) Token: 0x060121B9 RID: 74169 RVA: 0x0054C151 File Offset: 0x0054A551
		// (set) Token: 0x060121BA RID: 74170 RVA: 0x0054C159 File Offset: 0x0054A559
		public string PlatformName { get; private set; }

		// Token: 0x17001DF9 RID: 7673
		// (get) Token: 0x060121BB RID: 74171 RVA: 0x0054C162 File Offset: 0x0054A562
		// (set) Token: 0x060121BC RID: 74172 RVA: 0x0054C16A File Offset: 0x0054A56A
		public string Rate { get; private set; }
	}
}
