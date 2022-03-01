using System;

namespace behaviac
{
	// Token: 0x02001DA7 RID: 7591
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node10 : Condition
	{
		// Token: 0x06012508 RID: 75016 RVA: 0x00558511 File Offset: 0x00556911
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node10()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012509 RID: 75017 RVA: 0x00558548 File Offset: 0x00556948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEF6 RID: 48886
		private int opl_p0;

		// Token: 0x0400BEF7 RID: 48887
		private int opl_p1;

		// Token: 0x0400BEF8 RID: 48888
		private int opl_p2;

		// Token: 0x0400BEF9 RID: 48889
		private int opl_p3;
	}
}
