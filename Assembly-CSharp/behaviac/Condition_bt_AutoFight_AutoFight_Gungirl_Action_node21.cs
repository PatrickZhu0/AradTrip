using System;

namespace behaviac
{
	// Token: 0x020024AE RID: 9390
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node21 : Condition
	{
		// Token: 0x060132A7 RID: 78503 RVA: 0x005B053B File Offset: 0x005AE93B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node21()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060132A8 RID: 78504 RVA: 0x005B0570 File Offset: 0x005AE970
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCC0 RID: 52416
		private int opl_p0;

		// Token: 0x0400CCC1 RID: 52417
		private int opl_p1;

		// Token: 0x0400CCC2 RID: 52418
		private int opl_p2;

		// Token: 0x0400CCC3 RID: 52419
		private int opl_p3;
	}
}
