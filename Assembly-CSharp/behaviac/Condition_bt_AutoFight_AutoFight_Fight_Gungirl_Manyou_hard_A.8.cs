using System;

namespace behaviac
{
	// Token: 0x0200201F RID: 8223
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node18 : Condition
	{
		// Token: 0x060129D9 RID: 76249 RVA: 0x0057569F File Offset: 0x00573A9F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060129DA RID: 76250 RVA: 0x005756D4 File Offset: 0x00573AD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3CB RID: 50123
		private int opl_p0;

		// Token: 0x0400C3CC RID: 50124
		private int opl_p1;

		// Token: 0x0400C3CD RID: 50125
		private int opl_p2;

		// Token: 0x0400C3CE RID: 50126
		private int opl_p3;
	}
}
