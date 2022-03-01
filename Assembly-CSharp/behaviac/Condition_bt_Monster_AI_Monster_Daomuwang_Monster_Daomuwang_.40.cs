using System;

namespace behaviac
{
	// Token: 0x02003652 RID: 13906
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node2 : Condition
	{
		// Token: 0x060154C6 RID: 87238 RVA: 0x0066C3DE File Offset: 0x0066A7DE
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060154C7 RID: 87239 RVA: 0x0066C414 File Offset: 0x0066A814
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE7D RID: 61053
		private int opl_p0;

		// Token: 0x0400EE7E RID: 61054
		private int opl_p1;

		// Token: 0x0400EE7F RID: 61055
		private int opl_p2;

		// Token: 0x0400EE80 RID: 61056
		private int opl_p3;
	}
}
