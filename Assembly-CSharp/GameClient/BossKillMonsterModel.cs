using System;
using System.Runtime.InteropServices;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CDA RID: 7386
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct BossKillMonsterModel
	{
		// Token: 0x060121E7 RID: 74215 RVA: 0x0054C4CC File Offset: 0x0054A8CC
		public BossKillMonsterModel(ActivityMonsterInfo msgData)
		{
			this = default(BossKillMonsterModel);
			if (msgData == null)
			{
				return;
			}
			this.Name = msgData.name;
			this.Id = msgData.id;
			this.MonsterType = (MonsterType)msgData.pointType;
			this.DropList = msgData.drops;
			this.StartTime = msgData.startTime;
			this.EndTime = msgData.endTime;
			this.RemainNum = msgData.remainNum;
			this.NextRollStartTime = msgData.nextRollStartTime;
			this.IsActive = (msgData.activity == 1);
		}

		// Token: 0x17001E0E RID: 7694
		// (get) Token: 0x060121E8 RID: 74216 RVA: 0x0054C556 File Offset: 0x0054A956
		// (set) Token: 0x060121E9 RID: 74217 RVA: 0x0054C55E File Offset: 0x0054A95E
		public uint Id { get; private set; }

		// Token: 0x17001E0F RID: 7695
		// (get) Token: 0x060121EA RID: 74218 RVA: 0x0054C567 File Offset: 0x0054A967
		// (set) Token: 0x060121EB RID: 74219 RVA: 0x0054C56F File Offset: 0x0054A96F
		public string Name { get; private set; }

		// Token: 0x17001E10 RID: 7696
		// (get) Token: 0x060121EC RID: 74220 RVA: 0x0054C578 File Offset: 0x0054A978
		// (set) Token: 0x060121ED RID: 74221 RVA: 0x0054C580 File Offset: 0x0054A980
		public MonsterType MonsterType { get; private set; }

		// Token: 0x17001E11 RID: 7697
		// (get) Token: 0x060121EE RID: 74222 RVA: 0x0054C589 File Offset: 0x0054A989
		// (set) Token: 0x060121EF RID: 74223 RVA: 0x0054C591 File Offset: 0x0054A991
		public bool IsActive { get; private set; }

		// Token: 0x17001E12 RID: 7698
		// (get) Token: 0x060121F0 RID: 74224 RVA: 0x0054C59A File Offset: 0x0054A99A
		// (set) Token: 0x060121F1 RID: 74225 RVA: 0x0054C5A2 File Offset: 0x0054A9A2
		public DropItem[] DropList { get; private set; }

		// Token: 0x17001E13 RID: 7699
		// (get) Token: 0x060121F2 RID: 74226 RVA: 0x0054C5AB File Offset: 0x0054A9AB
		// (set) Token: 0x060121F3 RID: 74227 RVA: 0x0054C5B3 File Offset: 0x0054A9B3
		public uint StartTime { get; private set; }

		// Token: 0x17001E14 RID: 7700
		// (get) Token: 0x060121F4 RID: 74228 RVA: 0x0054C5BC File Offset: 0x0054A9BC
		// (set) Token: 0x060121F5 RID: 74229 RVA: 0x0054C5C4 File Offset: 0x0054A9C4
		public uint EndTime { get; private set; }

		// Token: 0x17001E15 RID: 7701
		// (get) Token: 0x060121F6 RID: 74230 RVA: 0x0054C5CD File Offset: 0x0054A9CD
		// (set) Token: 0x060121F7 RID: 74231 RVA: 0x0054C5D5 File Offset: 0x0054A9D5
		public uint RemainNum { get; private set; }

		// Token: 0x17001E16 RID: 7702
		// (get) Token: 0x060121F8 RID: 74232 RVA: 0x0054C5DE File Offset: 0x0054A9DE
		// (set) Token: 0x060121F9 RID: 74233 RVA: 0x0054C5E6 File Offset: 0x0054A9E6
		public uint NextRollStartTime { get; private set; }
	}
}
