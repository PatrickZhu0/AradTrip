using System;

namespace behaviac
{
	// Token: 0x02002023 RID: 8227
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node23 : Condition
	{
		// Token: 0x060129E1 RID: 76257 RVA: 0x0057583B File Offset: 0x00573C3B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060129E2 RID: 76258 RVA: 0x00575870 File Offset: 0x00573C70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3D3 RID: 50131
		private int opl_p0;

		// Token: 0x0400C3D4 RID: 50132
		private int opl_p1;

		// Token: 0x0400C3D5 RID: 50133
		private int opl_p2;

		// Token: 0x0400C3D6 RID: 50134
		private int opl_p3;
	}
}
