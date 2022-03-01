using System;

namespace behaviac
{
	// Token: 0x02001E18 RID: 7704
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node16 : Condition
	{
		// Token: 0x060125E1 RID: 75233 RVA: 0x0055D9BE File Offset: 0x0055BDBE
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node16()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060125E2 RID: 75234 RVA: 0x0055D9F4 File Offset: 0x0055BDF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFCA RID: 49098
		private int opl_p0;

		// Token: 0x0400BFCB RID: 49099
		private int opl_p1;

		// Token: 0x0400BFCC RID: 49100
		private int opl_p2;

		// Token: 0x0400BFCD RID: 49101
		private int opl_p3;
	}
}
