using System;

namespace behaviac
{
	// Token: 0x02002003 RID: 8195
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node33 : Condition
	{
		// Token: 0x060129A2 RID: 76194 RVA: 0x00573D1B File Offset: 0x0057211B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060129A3 RID: 76195 RVA: 0x00573D50 File Offset: 0x00572150
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C394 RID: 50068
		private int opl_p0;

		// Token: 0x0400C395 RID: 50069
		private int opl_p1;

		// Token: 0x0400C396 RID: 50070
		private int opl_p2;

		// Token: 0x0400C397 RID: 50071
		private int opl_p3;
	}
}
