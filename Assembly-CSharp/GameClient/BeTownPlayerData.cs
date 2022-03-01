using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001191 RID: 4497
	public class BeTownPlayerData : BeBaseActorData
	{
		// Token: 0x17001A56 RID: 6742
		// (get) Token: 0x0600AC1E RID: 44062 RVA: 0x00250770 File Offset: 0x0024EB70
		// (set) Token: 0x0600AC1F RID: 44063 RVA: 0x00250778 File Offset: 0x0024EB78
		public bool bDirty { get; set; }

		// Token: 0x17001A57 RID: 6743
		// (get) Token: 0x0600AC20 RID: 44064 RVA: 0x00250781 File Offset: 0x0024EB81
		// (set) Token: 0x0600AC21 RID: 44065 RVA: 0x00250789 File Offset: 0x0024EB89
		public override string Name
		{
			get
			{
				return this.m_strName;
			}
			set
			{
				this.m_strName = value;
				this.bDirty = true;
			}
		}

		// Token: 0x17001A58 RID: 6744
		// (get) Token: 0x0600AC22 RID: 44066 RVA: 0x00250799 File Offset: 0x0024EB99
		// (set) Token: 0x0600AC23 RID: 44067 RVA: 0x002507A1 File Offset: 0x0024EBA1
		public int pkRank
		{
			get
			{
				return this.m_nPKRank;
			}
			set
			{
				this.m_nPKRank = value;
				this.bDirty = true;
			}
		}

		// Token: 0x17001A59 RID: 6745
		// (get) Token: 0x0600AC24 RID: 44068 RVA: 0x002507B1 File Offset: 0x0024EBB1
		// (set) Token: 0x0600AC25 RID: 44069 RVA: 0x002507B9 File Offset: 0x0024EBB9
		public int pkStar
		{
			get
			{
				return this.m_nPKStar;
			}
			set
			{
				this.m_nPKStar = value;
				this.bDirty = true;
			}
		}

		// Token: 0x17001A5A RID: 6746
		// (get) Token: 0x0600AC26 RID: 44070 RVA: 0x002507C9 File Offset: 0x0024EBC9
		// (set) Token: 0x0600AC27 RID: 44071 RVA: 0x002507D1 File Offset: 0x0024EBD1
		public int JobID { get; set; }

		// Token: 0x17001A5B RID: 6747
		// (get) Token: 0x0600AC28 RID: 44072 RVA: 0x002507DA File Offset: 0x0024EBDA
		// (set) Token: 0x0600AC29 RID: 44073 RVA: 0x002507E2 File Offset: 0x0024EBE2
		public int State { get; set; }

		// Token: 0x17001A5C RID: 6748
		// (get) Token: 0x0600AC2A RID: 44074 RVA: 0x002507EB File Offset: 0x0024EBEB
		// (set) Token: 0x0600AC2B RID: 44075 RVA: 0x002507F3 File Offset: 0x0024EBF3
		public ushort RoleLv { get; set; }

		// Token: 0x17001A5D RID: 6749
		// (get) Token: 0x0600AC2C RID: 44076 RVA: 0x002507FC File Offset: 0x0024EBFC
		// (set) Token: 0x0600AC2D RID: 44077 RVA: 0x00250804 File Offset: 0x0024EC04
		public bool bRoleLvDirty { get; set; }

		// Token: 0x17001A5E RID: 6750
		// (get) Token: 0x0600AC2E RID: 44078 RVA: 0x0025080D File Offset: 0x0024EC0D
		// (set) Token: 0x0600AC2F RID: 44079 RVA: 0x00250815 File Offset: 0x0024EC15
		public bool bAwakeDirty { get; set; }

		// Token: 0x17001A5F RID: 6751
		// (get) Token: 0x0600AC30 RID: 44080 RVA: 0x0025081E File Offset: 0x0024EC1E
		// (set) Token: 0x0600AC31 RID: 44081 RVA: 0x00250826 File Offset: 0x0024EC26
		public uint tittle { get; set; }

		// Token: 0x17001A60 RID: 6752
		// (get) Token: 0x0600AC32 RID: 44082 RVA: 0x0025082F File Offset: 0x0024EC2F
		// (set) Token: 0x0600AC33 RID: 44083 RVA: 0x00250837 File Offset: 0x0024EC37
		public byte GuildPost { get; set; }

		// Token: 0x17001A61 RID: 6753
		// (get) Token: 0x0600AC34 RID: 44084 RVA: 0x00250840 File Offset: 0x0024EC40
		// (set) Token: 0x0600AC35 RID: 44085 RVA: 0x00250848 File Offset: 0x0024EC48
		public string GuildName { get; set; }

		// Token: 0x17001A62 RID: 6754
		// (get) Token: 0x0600AC36 RID: 44086 RVA: 0x00250851 File Offset: 0x0024EC51
		// (set) Token: 0x0600AC37 RID: 44087 RVA: 0x00250859 File Offset: 0x0024EC59
		public string AdventureTeamName { get; set; }

		// Token: 0x17001A63 RID: 6755
		// (get) Token: 0x0600AC38 RID: 44088 RVA: 0x00250862 File Offset: 0x0024EC62
		// (set) Token: 0x0600AC39 RID: 44089 RVA: 0x0025086A File Offset: 0x0024EC6A
		public PlayerWearedTitleInfo WearedTitleInfo { get; set; }

		// Token: 0x17001A64 RID: 6756
		// (get) Token: 0x0600AC3A RID: 44090 RVA: 0x00250873 File Offset: 0x0024EC73
		// (set) Token: 0x0600AC3B RID: 44091 RVA: 0x0025087B File Offset: 0x0024EC7B
		public int GuildEmblemLv { get; set; }

		// Token: 0x0400608B RID: 24715
		private string m_strName;

		// Token: 0x0400608C RID: 24716
		private int m_nPKRank;

		// Token: 0x0400608D RID: 24717
		private int m_nPKStar;

		// Token: 0x04006096 RID: 24726
		public int vip;

		// Token: 0x04006097 RID: 24727
		public PlayerAvatar avatorInfo;

		// Token: 0x04006098 RID: 24728
		public int petID;

		// Token: 0x04006099 RID: 24729
		public int ZoneID;
	}
}
