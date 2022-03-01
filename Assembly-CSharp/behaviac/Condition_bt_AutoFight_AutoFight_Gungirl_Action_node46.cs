using System;

namespace behaviac
{
	// Token: 0x020024C1 RID: 9409
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node46 : Condition
	{
		// Token: 0x060132CD RID: 78541 RVA: 0x005B0F2F File Offset: 0x005AF32F
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node46()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060132CE RID: 78542 RVA: 0x005B0F64 File Offset: 0x005AF364
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCE7 RID: 52455
		private int opl_p0;

		// Token: 0x0400CCE8 RID: 52456
		private int opl_p1;

		// Token: 0x0400CCE9 RID: 52457
		private int opl_p2;

		// Token: 0x0400CCEA RID: 52458
		private int opl_p3;
	}
}
