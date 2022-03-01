using System;

namespace behaviac
{
	// Token: 0x02001DEB RID: 7659
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node2 : Condition
	{
		// Token: 0x0601258C RID: 75148 RVA: 0x0055B6EE File Offset: 0x00559AEE
		public Condition_bt_APC_APC_Nianqishi_Action_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 3;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601258D RID: 75149 RVA: 0x0055B720 File Offset: 0x00559B20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF7E RID: 49022
		private int opl_p0;

		// Token: 0x0400BF7F RID: 49023
		private int opl_p1;

		// Token: 0x0400BF80 RID: 49024
		private int opl_p2;

		// Token: 0x0400BF81 RID: 49025
		private int opl_p3;
	}
}
