using System;

namespace behaviac
{
	// Token: 0x02001D28 RID: 7464
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node4 : Condition
	{
		// Token: 0x06012413 RID: 74771 RVA: 0x005523FA File Offset: 0x005507FA
		public Condition_bt_APC_APC_Guiqi2_Action_node4()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012414 RID: 74772 RVA: 0x00552430 File Offset: 0x00550830
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE02 RID: 48642
		private int opl_p0;

		// Token: 0x0400BE03 RID: 48643
		private int opl_p1;

		// Token: 0x0400BE04 RID: 48644
		private int opl_p2;

		// Token: 0x0400BE05 RID: 48645
		private int opl_p3;
	}
}
