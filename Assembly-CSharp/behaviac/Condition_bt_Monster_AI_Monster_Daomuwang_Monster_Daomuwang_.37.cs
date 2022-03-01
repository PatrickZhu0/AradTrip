using System;

namespace behaviac
{
	// Token: 0x0200364E RID: 13902
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node27 : Condition
	{
		// Token: 0x060154BE RID: 87230 RVA: 0x0066C22A File Offset: 0x0066A62A
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node27()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060154BF RID: 87231 RVA: 0x0066C260 File Offset: 0x0066A660
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE75 RID: 61045
		private int opl_p0;

		// Token: 0x0400EE76 RID: 61046
		private int opl_p1;

		// Token: 0x0400EE77 RID: 61047
		private int opl_p2;

		// Token: 0x0400EE78 RID: 61048
		private int opl_p3;
	}
}
