using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001144 RID: 4420
	public sealed class BeFighterData : BeBaseActorData
	{
		// Token: 0x17001A04 RID: 6660
		// (get) Token: 0x0600A8A8 RID: 43176 RVA: 0x0023893B File Offset: 0x00236D3B
		// (set) Token: 0x0600A8A9 RID: 43177 RVA: 0x00238943 File Offset: 0x00236D43
		public bool bDirty { get; set; }

		// Token: 0x17001A05 RID: 6661
		// (get) Token: 0x0600A8AA RID: 43178 RVA: 0x0023894C File Offset: 0x00236D4C
		// (set) Token: 0x0600A8AB RID: 43179 RVA: 0x00238954 File Offset: 0x00236D54
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

		// Token: 0x17001A06 RID: 6662
		// (get) Token: 0x0600A8AC RID: 43180 RVA: 0x00238964 File Offset: 0x00236D64
		// (set) Token: 0x0600A8AD RID: 43181 RVA: 0x0023896C File Offset: 0x00236D6C
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

		// Token: 0x17001A07 RID: 6663
		// (get) Token: 0x0600A8AE RID: 43182 RVA: 0x0023897C File Offset: 0x00236D7C
		// (set) Token: 0x0600A8AF RID: 43183 RVA: 0x00238984 File Offset: 0x00236D84
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

		// Token: 0x17001A08 RID: 6664
		// (get) Token: 0x0600A8B0 RID: 43184 RVA: 0x00238994 File Offset: 0x00236D94
		// (set) Token: 0x0600A8B1 RID: 43185 RVA: 0x0023899C File Offset: 0x00236D9C
		public int JobID { get; set; }

		// Token: 0x17001A09 RID: 6665
		// (get) Token: 0x0600A8B2 RID: 43186 RVA: 0x002389A5 File Offset: 0x00236DA5
		// (set) Token: 0x0600A8B3 RID: 43187 RVA: 0x002389AD File Offset: 0x00236DAD
		public int State { get; set; }

		// Token: 0x17001A0A RID: 6666
		// (get) Token: 0x0600A8B4 RID: 43188 RVA: 0x002389B6 File Offset: 0x00236DB6
		// (set) Token: 0x0600A8B5 RID: 43189 RVA: 0x002389BE File Offset: 0x00236DBE
		public ushort RoleLv { get; set; }

		// Token: 0x17001A0B RID: 6667
		// (get) Token: 0x0600A8B6 RID: 43190 RVA: 0x002389C7 File Offset: 0x00236DC7
		// (set) Token: 0x0600A8B7 RID: 43191 RVA: 0x002389CF File Offset: 0x00236DCF
		public bool bRoleLvDirty { get; set; }

		// Token: 0x17001A0C RID: 6668
		// (get) Token: 0x0600A8B8 RID: 43192 RVA: 0x002389D8 File Offset: 0x00236DD8
		// (set) Token: 0x0600A8B9 RID: 43193 RVA: 0x002389E0 File Offset: 0x00236DE0
		public bool bAwakeDirty { get; set; }

		// Token: 0x17001A0D RID: 6669
		// (get) Token: 0x0600A8BA RID: 43194 RVA: 0x002389E9 File Offset: 0x00236DE9
		// (set) Token: 0x0600A8BB RID: 43195 RVA: 0x002389F1 File Offset: 0x00236DF1
		public uint tittle { get; set; }

		// Token: 0x17001A0E RID: 6670
		// (get) Token: 0x0600A8BC RID: 43196 RVA: 0x002389FA File Offset: 0x00236DFA
		// (set) Token: 0x0600A8BD RID: 43197 RVA: 0x00238A02 File Offset: 0x00236E02
		public byte GuildPost { get; set; }

		// Token: 0x17001A0F RID: 6671
		// (get) Token: 0x0600A8BE RID: 43198 RVA: 0x00238A0B File Offset: 0x00236E0B
		// (set) Token: 0x0600A8BF RID: 43199 RVA: 0x00238A13 File Offset: 0x00236E13
		public string GuildName { get; set; }

		// Token: 0x17001A10 RID: 6672
		// (get) Token: 0x0600A8C0 RID: 43200 RVA: 0x00238A1C File Offset: 0x00236E1C
		// (set) Token: 0x0600A8C1 RID: 43201 RVA: 0x00238A24 File Offset: 0x00236E24
		public string AdventureTeamName { get; set; }

		// Token: 0x17001A11 RID: 6673
		// (get) Token: 0x0600A8C2 RID: 43202 RVA: 0x00238A2D File Offset: 0x00236E2D
		// (set) Token: 0x0600A8C3 RID: 43203 RVA: 0x00238A35 File Offset: 0x00236E35
		public PlayerWearedTitleInfo WearedTitleInfo { get; set; }

		// Token: 0x17001A12 RID: 6674
		// (get) Token: 0x0600A8C4 RID: 43204 RVA: 0x00238A3E File Offset: 0x00236E3E
		// (set) Token: 0x0600A8C5 RID: 43205 RVA: 0x00238A46 File Offset: 0x00236E46
		public int GuildEmblemLv { get; set; }

		// Token: 0x04005E32 RID: 24114
		private string m_strName;

		// Token: 0x04005E33 RID: 24115
		private int m_nPKRank;

		// Token: 0x04005E34 RID: 24116
		private int m_nPKStar;

		// Token: 0x04005E3D RID: 24125
		public int vip;

		// Token: 0x04005E3E RID: 24126
		public PlayerAvatar avatorInfo;

		// Token: 0x04005E3F RID: 24127
		public int petID;

		// Token: 0x04005E40 RID: 24128
		public int ZoneID;

		// Token: 0x04005E41 RID: 24129
		public int awaken;
	}
}
