using System;

namespace behaviac
{
	// Token: 0x02001DA6 RID: 7590
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node2 : Condition
	{
		// Token: 0x06012506 RID: 75014 RVA: 0x0055849A File Offset: 0x0055689A
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 3;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012507 RID: 75015 RVA: 0x005584CC File Offset: 0x005568CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEF2 RID: 48882
		private int opl_p0;

		// Token: 0x0400BEF3 RID: 48883
		private int opl_p1;

		// Token: 0x0400BEF4 RID: 48884
		private int opl_p2;

		// Token: 0x0400BEF5 RID: 48885
		private int opl_p3;
	}
}
