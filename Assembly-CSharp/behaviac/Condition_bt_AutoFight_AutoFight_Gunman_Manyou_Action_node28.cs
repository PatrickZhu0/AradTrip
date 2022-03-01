using System;

namespace behaviac
{
	// Token: 0x02002608 RID: 9736
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node28 : Condition
	{
		// Token: 0x06013556 RID: 79190 RVA: 0x005C082B File Offset: 0x005BEC2B
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node28()
		{
			this.opl_p0 = 3800;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013557 RID: 79191 RVA: 0x005C0860 File Offset: 0x005BEC60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFA1 RID: 53153
		private int opl_p0;

		// Token: 0x0400CFA2 RID: 53154
		private int opl_p1;

		// Token: 0x0400CFA3 RID: 53155
		private int opl_p2;

		// Token: 0x0400CFA4 RID: 53156
		private int opl_p3;
	}
}
