using System;

namespace behaviac
{
	// Token: 0x02003693 RID: 13971
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node9 : Condition
	{
		// Token: 0x06015543 RID: 87363 RVA: 0x0066F161 File Offset: 0x0066D561
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node9()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015544 RID: 87364 RVA: 0x0066F198 File Offset: 0x0066D598
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF06 RID: 61190
		private int opl_p0;

		// Token: 0x0400EF07 RID: 61191
		private int opl_p1;

		// Token: 0x0400EF08 RID: 61192
		private int opl_p2;

		// Token: 0x0400EF09 RID: 61193
		private int opl_p3;
	}
}
