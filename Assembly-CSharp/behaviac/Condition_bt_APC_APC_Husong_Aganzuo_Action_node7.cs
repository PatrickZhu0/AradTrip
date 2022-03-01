using System;

namespace behaviac
{
	// Token: 0x02001D51 RID: 7505
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node7 : Condition
	{
		// Token: 0x06012461 RID: 74849 RVA: 0x00554B8E File Offset: 0x00552F8E
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node7()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012462 RID: 74850 RVA: 0x00554BC4 File Offset: 0x00552FC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE4F RID: 48719
		private int opl_p0;

		// Token: 0x0400BE50 RID: 48720
		private int opl_p1;

		// Token: 0x0400BE51 RID: 48721
		private int opl_p2;

		// Token: 0x0400BE52 RID: 48722
		private int opl_p3;
	}
}
