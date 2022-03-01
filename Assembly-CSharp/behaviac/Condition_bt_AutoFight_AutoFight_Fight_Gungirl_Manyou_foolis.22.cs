using System;

namespace behaviac
{
	// Token: 0x0200200F RID: 8207
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node48 : Condition
	{
		// Token: 0x060129BA RID: 76218 RVA: 0x005742FB File Offset: 0x005726FB
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node48()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060129BB RID: 76219 RVA: 0x00574330 File Offset: 0x00572730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3AC RID: 50092
		private int opl_p0;

		// Token: 0x0400C3AD RID: 50093
		private int opl_p1;

		// Token: 0x0400C3AE RID: 50094
		private int opl_p2;

		// Token: 0x0400C3AF RID: 50095
		private int opl_p3;
	}
}
