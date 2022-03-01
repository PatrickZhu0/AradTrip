using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CDB RID: 7387
	public class BossExchangeModelBase : ILimitTimeNote
	{
		// Token: 0x060121FA RID: 74234 RVA: 0x0054C5F0 File Offset: 0x0054A9F0
		public BossExchangeModelBase(ActivityInfo msg)
		{
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
			this.Desc = tableItem.Desc;
			this.RuleDesc = tableItem.PurDesc;
			this.LogoDesc = tableItem.ParticularDesc;
			this.ItemParent = tableItem.awardparent;
			this.PrefabPath = tableItem.prefabDesc;
			this.NoteBgPath = null;
			this.NotePrefabPath = tableItem.ActiveFrameTabPath;
			this.StartTime = msg.startTime;
			this.EndTime = msg.dueTime;
			this.LogoPath = tableItem.BgPath;
			this.ItemPath = ((!string.IsNullOrEmpty(tableItem.templateName)) ? tableItem.templateName : "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/BossExchangeItem");
			this.State = (OpActivityState)msg.state;
		}

		// Token: 0x17001E17 RID: 7703
		// (get) Token: 0x060121FB RID: 74235 RVA: 0x0054C6E9 File Offset: 0x0054AAE9
		// (set) Token: 0x060121FC RID: 74236 RVA: 0x0054C6F1 File Offset: 0x0054AAF1
		public uint Id { get; private set; }

		// Token: 0x17001E18 RID: 7704
		// (get) Token: 0x060121FD RID: 74237 RVA: 0x0054C6FA File Offset: 0x0054AAFA
		// (set) Token: 0x060121FE RID: 74238 RVA: 0x0054C702 File Offset: 0x0054AB02
		public uint StartTime { get; private set; }

		// Token: 0x17001E19 RID: 7705
		// (get) Token: 0x060121FF RID: 74239 RVA: 0x0054C70B File Offset: 0x0054AB0B
		// (set) Token: 0x06012200 RID: 74240 RVA: 0x0054C713 File Offset: 0x0054AB13
		public uint EndTime { get; private set; }

		// Token: 0x17001E1A RID: 7706
		// (get) Token: 0x06012201 RID: 74241 RVA: 0x0054C71C File Offset: 0x0054AB1C
		// (set) Token: 0x06012202 RID: 74242 RVA: 0x0054C724 File Offset: 0x0054AB24
		public string RuleDesc { get; private set; }

		// Token: 0x17001E1B RID: 7707
		// (get) Token: 0x06012203 RID: 74243 RVA: 0x0054C72D File Offset: 0x0054AB2D
		// (set) Token: 0x06012204 RID: 74244 RVA: 0x0054C735 File Offset: 0x0054AB35
		public string LogoDesc { get; private set; }

		// Token: 0x17001E1C RID: 7708
		// (get) Token: 0x06012205 RID: 74245 RVA: 0x0054C73E File Offset: 0x0054AB3E
		// (set) Token: 0x06012206 RID: 74246 RVA: 0x0054C746 File Offset: 0x0054AB46
		public string Desc { get; private set; }

		// Token: 0x17001E1D RID: 7709
		// (get) Token: 0x06012207 RID: 74247 RVA: 0x0054C74F File Offset: 0x0054AB4F
		// (set) Token: 0x06012208 RID: 74248 RVA: 0x0054C757 File Offset: 0x0054AB57
		public string LogoPath { get; private set; }

		// Token: 0x17001E1E RID: 7710
		// (get) Token: 0x06012209 RID: 74249 RVA: 0x0054C760 File Offset: 0x0054AB60
		// (set) Token: 0x0601220A RID: 74250 RVA: 0x0054C768 File Offset: 0x0054AB68
		public string NoteBgPath { get; private set; }

		// Token: 0x17001E1F RID: 7711
		// (get) Token: 0x0601220B RID: 74251 RVA: 0x0054C771 File Offset: 0x0054AB71
		// (set) Token: 0x0601220C RID: 74252 RVA: 0x0054C779 File Offset: 0x0054AB79
		public string NotePrefabPath { get; private set; }

		// Token: 0x17001E20 RID: 7712
		// (get) Token: 0x0601220D RID: 74253 RVA: 0x0054C782 File Offset: 0x0054AB82
		// (set) Token: 0x0601220E RID: 74254 RVA: 0x0054C78A File Offset: 0x0054AB8A
		public string ItemPath { get; private set; }

		// Token: 0x17001E21 RID: 7713
		// (get) Token: 0x0601220F RID: 74255 RVA: 0x0054C793 File Offset: 0x0054AB93
		// (set) Token: 0x06012210 RID: 74256 RVA: 0x0054C79B File Offset: 0x0054AB9B
		public OpActivityState State { get; private set; }

		// Token: 0x17001E22 RID: 7714
		// (get) Token: 0x06012211 RID: 74257 RVA: 0x0054C7A4 File Offset: 0x0054ABA4
		// (set) Token: 0x06012212 RID: 74258 RVA: 0x0054C7AC File Offset: 0x0054ABAC
		public string Name { get; private set; }

		// Token: 0x17001E23 RID: 7715
		// (get) Token: 0x06012213 RID: 74259 RVA: 0x0054C7B5 File Offset: 0x0054ABB5
		// (set) Token: 0x06012214 RID: 74260 RVA: 0x0054C7BD File Offset: 0x0054ABBD
		public string[] StrParam { get; set; }

		// Token: 0x17001E24 RID: 7716
		// (get) Token: 0x06012215 RID: 74261 RVA: 0x0054C7C6 File Offset: 0x0054ABC6
		// (set) Token: 0x06012216 RID: 74262 RVA: 0x0054C7CE File Offset: 0x0054ABCE
		public string ItemParent { get; set; }

		// Token: 0x17001E25 RID: 7717
		// (get) Token: 0x06012217 RID: 74263 RVA: 0x0054C7D7 File Offset: 0x0054ABD7
		// (set) Token: 0x06012218 RID: 74264 RVA: 0x0054C7DF File Offset: 0x0054ABDF
		public string PrefabPath { get; set; }
	}
}
