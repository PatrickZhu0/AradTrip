using System;
using System.Runtime.InteropServices;

namespace DataModel
{
	// Token: 0x02001CD5 RID: 7381
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HistroyPlayerData
	{
		// Token: 0x060121A6 RID: 74150 RVA: 0x0054C034 File Offset: 0x0054A434
		public HistroyPlayerData(string name, string serverName, string platformName, int groupId, uint investment, bool isPlayer)
		{
			this = default(HistroyPlayerData);
			this.Name = name;
			this.ServerName = serverName;
			this.PlatformName = platformName;
			this.GroupId = groupId;
			this.TotalInvestment = investment;
			this.IsPlayer = isPlayer;
		}

		// Token: 0x17001DF0 RID: 7664
		// (get) Token: 0x060121A7 RID: 74151 RVA: 0x0054C06A File Offset: 0x0054A46A
		// (set) Token: 0x060121A8 RID: 74152 RVA: 0x0054C072 File Offset: 0x0054A472
		public string Name { get; private set; }

		// Token: 0x17001DF1 RID: 7665
		// (get) Token: 0x060121A9 RID: 74153 RVA: 0x0054C07B File Offset: 0x0054A47B
		// (set) Token: 0x060121AA RID: 74154 RVA: 0x0054C083 File Offset: 0x0054A483
		public string ServerName { get; private set; }

		// Token: 0x17001DF2 RID: 7666
		// (get) Token: 0x060121AB RID: 74155 RVA: 0x0054C08C File Offset: 0x0054A48C
		// (set) Token: 0x060121AC RID: 74156 RVA: 0x0054C094 File Offset: 0x0054A494
		public string PlatformName { get; private set; }

		// Token: 0x17001DF3 RID: 7667
		// (get) Token: 0x060121AD RID: 74157 RVA: 0x0054C09D File Offset: 0x0054A49D
		// (set) Token: 0x060121AE RID: 74158 RVA: 0x0054C0A5 File Offset: 0x0054A4A5
		public int GroupId { get; private set; }

		// Token: 0x17001DF4 RID: 7668
		// (get) Token: 0x060121AF RID: 74159 RVA: 0x0054C0AE File Offset: 0x0054A4AE
		// (set) Token: 0x060121B0 RID: 74160 RVA: 0x0054C0B6 File Offset: 0x0054A4B6
		public uint TotalInvestment { get; private set; }

		// Token: 0x17001DF5 RID: 7669
		// (get) Token: 0x060121B1 RID: 74161 RVA: 0x0054C0BF File Offset: 0x0054A4BF
		// (set) Token: 0x060121B2 RID: 74162 RVA: 0x0054C0C7 File Offset: 0x0054A4C7
		public bool IsPlayer { get; private set; }
	}
}
