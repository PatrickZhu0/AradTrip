using System;

namespace behaviac
{
	// Token: 0x02002B31 RID: 11057
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node1 : Condition
	{
		// Token: 0x06013F72 RID: 81778 RVA: 0x005FE85A File Offset: 0x005FCC5A
		public Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node1()
		{
			this.opl_p0 = 80490011;
		}

		// Token: 0x06013F73 RID: 81779 RVA: 0x005FE870 File Offset: 0x005FCC70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_HaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9A4 RID: 55716
		private int opl_p0;
	}
}
