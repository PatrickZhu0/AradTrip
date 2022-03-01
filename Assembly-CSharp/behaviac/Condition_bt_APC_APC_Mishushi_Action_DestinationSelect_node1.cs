using System;

namespace behaviac
{
	// Token: 0x02001DD0 RID: 7632
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_DestinationSelect_node10 : Condition
	{
		// Token: 0x06012557 RID: 75095 RVA: 0x0055AA67 File Offset: 0x00558E67
		public Condition_bt_APC_APC_Mishushi_Action_DestinationSelect_node10()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012558 RID: 75096 RVA: 0x0055AA9C File Offset: 0x00558E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF4A RID: 48970
		private int opl_p0;

		// Token: 0x0400BF4B RID: 48971
		private int opl_p1;

		// Token: 0x0400BF4C RID: 48972
		private int opl_p2;

		// Token: 0x0400BF4D RID: 48973
		private int opl_p3;
	}
}
