using System;

namespace behaviac
{
	// Token: 0x02002ABE RID: 10942
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node2 : Condition
	{
		// Token: 0x06013E99 RID: 81561 RVA: 0x005F968E File Offset: 0x005F7A8E
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013E9A RID: 81562 RVA: 0x005F96C4 File Offset: 0x005F7AC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D90B RID: 55563
		private int opl_p0;

		// Token: 0x0400D90C RID: 55564
		private int opl_p1;

		// Token: 0x0400D90D RID: 55565
		private int opl_p2;

		// Token: 0x0400D90E RID: 55566
		private int opl_p3;
	}
}
