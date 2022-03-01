using System;

namespace behaviac
{
	// Token: 0x02001DB6 RID: 7606
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node18 : Condition
	{
		// Token: 0x06012525 RID: 75045 RVA: 0x005595A1 File Offset: 0x005579A1
		public Condition_bt_APC_APC_Kuangzhan_Action_node18()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x06012526 RID: 75046 RVA: 0x005595D8 File Offset: 0x005579D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF17 RID: 48919
		private int opl_p0;

		// Token: 0x0400BF18 RID: 48920
		private int opl_p1;

		// Token: 0x0400BF19 RID: 48921
		private int opl_p2;

		// Token: 0x0400BF1A RID: 48922
		private int opl_p3;
	}
}
