using System;

namespace behaviac
{
	// Token: 0x02003628 RID: 13864
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node7 : Condition
	{
		// Token: 0x06015474 RID: 87156 RVA: 0x0066A3AE File Offset: 0x006687AE
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node7()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06015475 RID: 87157 RVA: 0x0066A3E4 File Offset: 0x006687E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE2D RID: 60973
		private int opl_p0;

		// Token: 0x0400EE2E RID: 60974
		private int opl_p1;

		// Token: 0x0400EE2F RID: 60975
		private int opl_p2;

		// Token: 0x0400EE30 RID: 60976
		private int opl_p3;
	}
}
