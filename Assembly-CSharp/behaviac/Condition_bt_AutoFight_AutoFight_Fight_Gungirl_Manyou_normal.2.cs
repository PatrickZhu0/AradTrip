using System;

namespace behaviac
{
	// Token: 0x0200203B RID: 8251
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node3 : Condition
	{
		// Token: 0x06012A10 RID: 76304 RVA: 0x00576F37 File Offset: 0x00575337
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012A11 RID: 76305 RVA: 0x00576F6C File Offset: 0x0057536C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C402 RID: 50178
		private int opl_p0;

		// Token: 0x0400C403 RID: 50179
		private int opl_p1;

		// Token: 0x0400C404 RID: 50180
		private int opl_p2;

		// Token: 0x0400C405 RID: 50181
		private int opl_p3;
	}
}
