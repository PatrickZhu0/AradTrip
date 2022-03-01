using System;

namespace behaviac
{
	// Token: 0x02002047 RID: 8263
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node18 : Condition
	{
		// Token: 0x06012A28 RID: 76328 RVA: 0x005774BB File Offset: 0x005758BB
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A29 RID: 76329 RVA: 0x005774F0 File Offset: 0x005758F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C41A RID: 50202
		private int opl_p0;

		// Token: 0x0400C41B RID: 50203
		private int opl_p1;

		// Token: 0x0400C41C RID: 50204
		private int opl_p2;

		// Token: 0x0400C41D RID: 50205
		private int opl_p3;
	}
}
