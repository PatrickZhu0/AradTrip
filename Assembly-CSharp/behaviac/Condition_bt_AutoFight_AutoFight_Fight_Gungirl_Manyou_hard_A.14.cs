using System;

namespace behaviac
{
	// Token: 0x0200202B RID: 8235
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node33 : Condition
	{
		// Token: 0x060129F1 RID: 76273 RVA: 0x00575C23 File Offset: 0x00574023
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060129F2 RID: 76274 RVA: 0x00575C58 File Offset: 0x00574058
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3E3 RID: 50147
		private int opl_p0;

		// Token: 0x0400C3E4 RID: 50148
		private int opl_p1;

		// Token: 0x0400C3E5 RID: 50149
		private int opl_p2;

		// Token: 0x0400C3E6 RID: 50150
		private int opl_p3;
	}
}
