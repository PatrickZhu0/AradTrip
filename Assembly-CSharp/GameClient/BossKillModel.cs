using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CD8 RID: 7384
	public struct BossKillModel : ILimitTimeNote
	{
		// Token: 0x060121CC RID: 74188 RVA: 0x0054C2B8 File Offset: 0x0054A6B8
		public BossKillModel(WorldActivityMonsterRes monsterData, ActivityInfo msg)
		{
			this = default(BossKillModel);
			if (msg == null)
			{
				return;
			}
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>((int)msg.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.Id = msg.id;
			this.Name = tableItem.Name;
			this.RuleDesc = tableItem.PurDesc;
			this.LogoDesc = tableItem.ParticularDesc;
			this.State = (OpActivityState)msg.state;
			this.Desc = tableItem.Desc;
			this.LogoPath = tableItem.BgPath;
			this.ItemPath = ((!string.IsNullOrEmpty(tableItem.templateName)) ? tableItem.templateName : "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/BossKillItem");
			this.MonsterDatas = new List<BossKillMonsterModel>();
			if (monsterData != null && monsterData.monsters != null)
			{
				for (int i = 0; i < monsterData.monsters.Length; i++)
				{
					this.MonsterDatas.Add(new BossKillMonsterModel(monsterData.monsters[i]));
				}
			}
			this.mData = msg;
			this.StartTime = msg.startTime;
			this.EndTime = msg.dueTime;
			this.NoteBgPath = null;
			this.NotePrefabPath = tableItem.ActiveFrameTabPath;
		}

		// Token: 0x17001E01 RID: 7681
		// (get) Token: 0x060121CD RID: 74189 RVA: 0x0054C3EE File Offset: 0x0054A7EE
		// (set) Token: 0x060121CE RID: 74190 RVA: 0x0054C3F6 File Offset: 0x0054A7F6
		public uint Id { get; private set; }

		// Token: 0x17001E02 RID: 7682
		// (get) Token: 0x060121CF RID: 74191 RVA: 0x0054C3FF File Offset: 0x0054A7FF
		// (set) Token: 0x060121D0 RID: 74192 RVA: 0x0054C407 File Offset: 0x0054A807
		public uint StartTime { get; private set; }

		// Token: 0x17001E03 RID: 7683
		// (get) Token: 0x060121D1 RID: 74193 RVA: 0x0054C410 File Offset: 0x0054A810
		// (set) Token: 0x060121D2 RID: 74194 RVA: 0x0054C418 File Offset: 0x0054A818
		public uint EndTime { get; private set; }

		// Token: 0x17001E04 RID: 7684
		// (get) Token: 0x060121D3 RID: 74195 RVA: 0x0054C421 File Offset: 0x0054A821
		// (set) Token: 0x060121D4 RID: 74196 RVA: 0x0054C429 File Offset: 0x0054A829
		public string RuleDesc { get; private set; }

		// Token: 0x17001E05 RID: 7685
		// (get) Token: 0x060121D5 RID: 74197 RVA: 0x0054C432 File Offset: 0x0054A832
		// (set) Token: 0x060121D6 RID: 74198 RVA: 0x0054C43A File Offset: 0x0054A83A
		public string LogoDesc { get; private set; }

		// Token: 0x17001E06 RID: 7686
		// (get) Token: 0x060121D7 RID: 74199 RVA: 0x0054C443 File Offset: 0x0054A843
		// (set) Token: 0x060121D8 RID: 74200 RVA: 0x0054C44B File Offset: 0x0054A84B
		public string Desc { get; private set; }

		// Token: 0x17001E07 RID: 7687
		// (get) Token: 0x060121D9 RID: 74201 RVA: 0x0054C454 File Offset: 0x0054A854
		// (set) Token: 0x060121DA RID: 74202 RVA: 0x0054C45C File Offset: 0x0054A85C
		public string LogoPath { get; private set; }

		// Token: 0x17001E08 RID: 7688
		// (get) Token: 0x060121DB RID: 74203 RVA: 0x0054C465 File Offset: 0x0054A865
		// (set) Token: 0x060121DC RID: 74204 RVA: 0x0054C46D File Offset: 0x0054A86D
		public string NoteBgPath { get; private set; }

		// Token: 0x17001E09 RID: 7689
		// (get) Token: 0x060121DD RID: 74205 RVA: 0x0054C476 File Offset: 0x0054A876
		// (set) Token: 0x060121DE RID: 74206 RVA: 0x0054C47E File Offset: 0x0054A87E
		public string NotePrefabPath { get; private set; }

		// Token: 0x17001E0A RID: 7690
		// (get) Token: 0x060121DF RID: 74207 RVA: 0x0054C487 File Offset: 0x0054A887
		// (set) Token: 0x060121E0 RID: 74208 RVA: 0x0054C48F File Offset: 0x0054A88F
		public string ItemPath { get; private set; }

		// Token: 0x17001E0B RID: 7691
		// (get) Token: 0x060121E1 RID: 74209 RVA: 0x0054C498 File Offset: 0x0054A898
		// (set) Token: 0x060121E2 RID: 74210 RVA: 0x0054C4A0 File Offset: 0x0054A8A0
		public OpActivityState State { get; private set; }

		// Token: 0x17001E0C RID: 7692
		// (get) Token: 0x060121E3 RID: 74211 RVA: 0x0054C4A9 File Offset: 0x0054A8A9
		// (set) Token: 0x060121E4 RID: 74212 RVA: 0x0054C4B1 File Offset: 0x0054A8B1
		public string Name { get; private set; }

		// Token: 0x17001E0D RID: 7693
		// (get) Token: 0x060121E5 RID: 74213 RVA: 0x0054C4BA File Offset: 0x0054A8BA
		// (set) Token: 0x060121E6 RID: 74214 RVA: 0x0054C4C2 File Offset: 0x0054A8C2
		public List<BossKillMonsterModel> MonsterDatas { get; private set; }

		// Token: 0x0400BCE6 RID: 48358
		private ActivityInfo mData;
	}
}
