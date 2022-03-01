using System;

namespace behaviac
{
	// Token: 0x02002B1E RID: 11038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node24 : Condition
	{
		// Token: 0x06013F4E RID: 81742 RVA: 0x005FD75F File Offset: 0x005FBB5F
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node24()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = 0;
		}

		// Token: 0x06013F4F RID: 81743 RVA: 0x005FD778 File Offset: 0x005FBB78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D98A RID: 55690
		private LevelCounterType opl_p0;

		// Token: 0x0400D98B RID: 55691
		private int opl_p1;
	}
}
