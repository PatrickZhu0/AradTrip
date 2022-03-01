using System;

namespace behaviac
{
	// Token: 0x02002CDE RID: 11486
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node29 : Condition
	{
		// Token: 0x060142AC RID: 82604 RVA: 0x0060E9C1 File Offset: 0x0060CDC1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node29()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060142AD RID: 82605 RVA: 0x0060E9F8 File Offset: 0x0060CDF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC5B RID: 56411
		private int opl_p0;

		// Token: 0x0400DC5C RID: 56412
		private int opl_p1;

		// Token: 0x0400DC5D RID: 56413
		private int opl_p2;

		// Token: 0x0400DC5E RID: 56414
		private int opl_p3;
	}
}
