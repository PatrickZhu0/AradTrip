using System;

namespace behaviac
{
	// Token: 0x02002007 RID: 8199
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node38 : Condition
	{
		// Token: 0x060129AA RID: 76202 RVA: 0x00573EB7 File Offset: 0x005722B7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060129AB RID: 76203 RVA: 0x00573EEC File Offset: 0x005722EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C39C RID: 50076
		private int opl_p0;

		// Token: 0x0400C39D RID: 50077
		private int opl_p1;

		// Token: 0x0400C39E RID: 50078
		private int opl_p2;

		// Token: 0x0400C39F RID: 50079
		private int opl_p3;
	}
}
