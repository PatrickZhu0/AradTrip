using System;

namespace behaviac
{
	// Token: 0x02002013 RID: 8211
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node3 : Condition
	{
		// Token: 0x060129C1 RID: 76225 RVA: 0x0057511B File Offset: 0x0057351B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060129C2 RID: 76226 RVA: 0x00575150 File Offset: 0x00573550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3B3 RID: 50099
		private int opl_p0;

		// Token: 0x0400C3B4 RID: 50100
		private int opl_p1;

		// Token: 0x0400C3B5 RID: 50101
		private int opl_p2;

		// Token: 0x0400C3B6 RID: 50102
		private int opl_p3;
	}
}
