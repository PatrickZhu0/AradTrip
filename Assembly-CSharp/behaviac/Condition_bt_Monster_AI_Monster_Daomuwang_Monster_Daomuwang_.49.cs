using System;

namespace behaviac
{
	// Token: 0x0200365E RID: 13918
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node17 : Condition
	{
		// Token: 0x060154DE RID: 87262 RVA: 0x0066C8FA File Offset: 0x0066ACFA
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060154DF RID: 87263 RVA: 0x0066C930 File Offset: 0x0066AD30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE95 RID: 61077
		private int opl_p0;

		// Token: 0x0400EE96 RID: 61078
		private int opl_p1;

		// Token: 0x0400EE97 RID: 61079
		private int opl_p2;

		// Token: 0x0400EE98 RID: 61080
		private int opl_p3;
	}
}
