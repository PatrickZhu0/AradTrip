using System;

namespace behaviac
{
	// Token: 0x02002173 RID: 8563
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node43 : Condition
	{
		// Token: 0x06012C77 RID: 76919 RVA: 0x0058550F File Offset: 0x0058390F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012C78 RID: 76920 RVA: 0x00585544 File Offset: 0x00583944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C669 RID: 50793
		private int opl_p0;

		// Token: 0x0400C66A RID: 50794
		private int opl_p1;

		// Token: 0x0400C66B RID: 50795
		private int opl_p2;

		// Token: 0x0400C66C RID: 50796
		private int opl_p3;
	}
}
