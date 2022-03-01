using System;

namespace behaviac
{
	// Token: 0x0200200B RID: 8203
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node43 : Condition
	{
		// Token: 0x060129B2 RID: 76210 RVA: 0x0057415F File Offset: 0x0057255F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060129B3 RID: 76211 RVA: 0x00574194 File Offset: 0x00572594
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3A4 RID: 50084
		private int opl_p0;

		// Token: 0x0400C3A5 RID: 50085
		private int opl_p1;

		// Token: 0x0400C3A6 RID: 50086
		private int opl_p2;

		// Token: 0x0400C3A7 RID: 50087
		private int opl_p3;
	}
}
