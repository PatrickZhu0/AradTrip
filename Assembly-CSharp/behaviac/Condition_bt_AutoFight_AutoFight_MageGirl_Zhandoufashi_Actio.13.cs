using System;

namespace behaviac
{
	// Token: 0x02002711 RID: 10001
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node13 : Condition
	{
		// Token: 0x06013764 RID: 79716 RVA: 0x005CC67E File Offset: 0x005CAA7E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node13()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x06013765 RID: 79717 RVA: 0x005CC6B4 File Offset: 0x005CAAB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1BC RID: 53692
		private int opl_p0;

		// Token: 0x0400D1BD RID: 53693
		private int opl_p1;

		// Token: 0x0400D1BE RID: 53694
		private int opl_p2;

		// Token: 0x0400D1BF RID: 53695
		private int opl_p3;
	}
}
