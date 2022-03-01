using System;

namespace behaviac
{
	// Token: 0x02002ACE RID: 10958
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node22 : Condition
	{
		// Token: 0x06013EB7 RID: 81591 RVA: 0x005F9FC6 File Offset: 0x005F83C6
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node22()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013EB8 RID: 81592 RVA: 0x005F9FFC File Offset: 0x005F83FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D929 RID: 55593
		private int opl_p0;

		// Token: 0x0400D92A RID: 55594
		private int opl_p1;

		// Token: 0x0400D92B RID: 55595
		private int opl_p2;

		// Token: 0x0400D92C RID: 55596
		private int opl_p3;
	}
}
