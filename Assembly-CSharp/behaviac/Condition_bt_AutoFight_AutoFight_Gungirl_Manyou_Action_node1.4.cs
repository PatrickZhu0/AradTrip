using System;

namespace behaviac
{
	// Token: 0x02002502 RID: 9474
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node15 : Condition
	{
		// Token: 0x0601334E RID: 78670 RVA: 0x005B3B8B File Offset: 0x005B1F8B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node15()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601334F RID: 78671 RVA: 0x005B3BC0 File Offset: 0x005B1FC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD6D RID: 52589
		private int opl_p0;

		// Token: 0x0400CD6E RID: 52590
		private int opl_p1;

		// Token: 0x0400CD6F RID: 52591
		private int opl_p2;

		// Token: 0x0400CD70 RID: 52592
		private int opl_p3;
	}
}
