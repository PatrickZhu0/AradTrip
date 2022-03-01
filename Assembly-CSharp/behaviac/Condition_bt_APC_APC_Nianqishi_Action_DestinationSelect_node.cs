using System;

namespace behaviac
{
	// Token: 0x02001DF0 RID: 7664
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_DestinationSelect_node10 : Condition
	{
		// Token: 0x06012595 RID: 75157 RVA: 0x0055BFBC File Offset: 0x0055A3BC
		public Condition_bt_APC_APC_Nianqishi_Action_DestinationSelect_node10()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012596 RID: 75158 RVA: 0x0055BFF0 File Offset: 0x0055A3F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF89 RID: 49033
		private int opl_p0;

		// Token: 0x0400BF8A RID: 49034
		private int opl_p1;

		// Token: 0x0400BF8B RID: 49035
		private int opl_p2;

		// Token: 0x0400BF8C RID: 49036
		private int opl_p3;
	}
}
