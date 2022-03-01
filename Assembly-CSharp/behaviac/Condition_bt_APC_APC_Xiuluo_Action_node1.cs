using System;

namespace behaviac
{
	// Token: 0x02001E36 RID: 7734
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node1 : Condition
	{
		// Token: 0x0601261A RID: 75290 RVA: 0x0055EF1E File Offset: 0x0055D31E
		public Condition_bt_APC_APC_Xiuluo_Action_node1()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601261B RID: 75291 RVA: 0x0055EF54 File Offset: 0x0055D354
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C000 RID: 49152
		private int opl_p0;

		// Token: 0x0400C001 RID: 49153
		private int opl_p1;

		// Token: 0x0400C002 RID: 49154
		private int opl_p2;

		// Token: 0x0400C003 RID: 49155
		private int opl_p3;
	}
}
