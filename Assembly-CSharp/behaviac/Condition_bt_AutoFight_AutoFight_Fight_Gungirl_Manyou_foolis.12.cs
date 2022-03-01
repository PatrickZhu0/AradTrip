using System;

namespace behaviac
{
	// Token: 0x02001FFB RID: 8187
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node23 : Condition
	{
		// Token: 0x06012992 RID: 76178 RVA: 0x00573933 File Offset: 0x00571D33
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012993 RID: 76179 RVA: 0x00573968 File Offset: 0x00571D68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C384 RID: 50052
		private int opl_p0;

		// Token: 0x0400C385 RID: 50053
		private int opl_p1;

		// Token: 0x0400C386 RID: 50054
		private int opl_p2;

		// Token: 0x0400C387 RID: 50055
		private int opl_p3;
	}
}
