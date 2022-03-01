using System;

namespace behaviac
{
	// Token: 0x02001D4D RID: 7501
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node1 : Condition
	{
		// Token: 0x06012459 RID: 74841 RVA: 0x005549DC File Offset: 0x00552DDC
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node1()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601245A RID: 74842 RVA: 0x00554A10 File Offset: 0x00552E10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE47 RID: 48711
		private int opl_p0;

		// Token: 0x0400BE48 RID: 48712
		private int opl_p1;

		// Token: 0x0400BE49 RID: 48713
		private int opl_p2;

		// Token: 0x0400BE4A RID: 48714
		private int opl_p3;
	}
}
