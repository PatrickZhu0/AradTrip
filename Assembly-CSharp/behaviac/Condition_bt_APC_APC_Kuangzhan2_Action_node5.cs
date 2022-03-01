using System;

namespace behaviac
{
	// Token: 0x02001D83 RID: 7555
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node5 : Condition
	{
		// Token: 0x060124C1 RID: 74945 RVA: 0x00556F01 File Offset: 0x00555301
		public Condition_bt_APC_APC_Kuangzhan2_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060124C2 RID: 74946 RVA: 0x00556F38 File Offset: 0x00555338
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEAB RID: 48811
		private int opl_p0;

		// Token: 0x0400BEAC RID: 48812
		private int opl_p1;

		// Token: 0x0400BEAD RID: 48813
		private int opl_p2;

		// Token: 0x0400BEAE RID: 48814
		private int opl_p3;
	}
}
