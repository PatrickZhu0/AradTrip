using System;

namespace behaviac
{
	// Token: 0x02001D35 RID: 7477
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node10 : Condition
	{
		// Token: 0x0601242C RID: 74796 RVA: 0x005537DA File Offset: 0x00551BDA
		public Condition_bt_APC_APC_Guiqi_Action_node10()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601242D RID: 74797 RVA: 0x00553810 File Offset: 0x00551C10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE1C RID: 48668
		private int opl_p0;

		// Token: 0x0400BE1D RID: 48669
		private int opl_p1;

		// Token: 0x0400BE1E RID: 48670
		private int opl_p2;

		// Token: 0x0400BE1F RID: 48671
		private int opl_p3;
	}
}
