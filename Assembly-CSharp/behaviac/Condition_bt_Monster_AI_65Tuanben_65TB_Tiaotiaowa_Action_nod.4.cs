using System;

namespace behaviac
{
	// Token: 0x02002CDA RID: 11482
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node31 : Condition
	{
		// Token: 0x060142A4 RID: 82596 RVA: 0x0060E841 File Offset: 0x0060CC41
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node31()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060142A5 RID: 82597 RVA: 0x0060E878 File Offset: 0x0060CC78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC54 RID: 56404
		private int opl_p0;

		// Token: 0x0400DC55 RID: 56405
		private int opl_p1;

		// Token: 0x0400DC56 RID: 56406
		private int opl_p2;

		// Token: 0x0400DC57 RID: 56407
		private int opl_p3;
	}
}
