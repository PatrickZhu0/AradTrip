using System;

namespace behaviac
{
	// Token: 0x020024EB RID: 9451
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node60 : Condition
	{
		// Token: 0x06013320 RID: 78624 RVA: 0x005B2F86 File Offset: 0x005B1386
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node60()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013321 RID: 78625 RVA: 0x005B2FBC File Offset: 0x005B13BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD3E RID: 52542
		private int opl_p0;

		// Token: 0x0400CD3F RID: 52543
		private int opl_p1;

		// Token: 0x0400CD40 RID: 52544
		private int opl_p2;

		// Token: 0x0400CD41 RID: 52545
		private int opl_p3;
	}
}
