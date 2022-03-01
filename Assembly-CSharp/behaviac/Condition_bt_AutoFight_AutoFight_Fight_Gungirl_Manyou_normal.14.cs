using System;

namespace behaviac
{
	// Token: 0x02002053 RID: 8275
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node33 : Condition
	{
		// Token: 0x06012A40 RID: 76352 RVA: 0x00577A3F File Offset: 0x00575E3F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A41 RID: 76353 RVA: 0x00577A74 File Offset: 0x00575E74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C432 RID: 50226
		private int opl_p0;

		// Token: 0x0400C433 RID: 50227
		private int opl_p1;

		// Token: 0x0400C434 RID: 50228
		private int opl_p2;

		// Token: 0x0400C435 RID: 50229
		private int opl_p3;
	}
}
