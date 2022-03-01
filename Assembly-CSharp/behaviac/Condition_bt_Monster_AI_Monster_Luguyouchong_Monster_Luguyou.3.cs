using System;

namespace behaviac
{
	// Token: 0x020036C8 RID: 14024
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node6 : Condition
	{
		// Token: 0x060155A8 RID: 87464 RVA: 0x006711EA File Offset: 0x0066F5EA
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node6()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060155A9 RID: 87465 RVA: 0x00671220 File Offset: 0x0066F620
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF7A RID: 61306
		private int opl_p0;

		// Token: 0x0400EF7B RID: 61307
		private int opl_p1;

		// Token: 0x0400EF7C RID: 61308
		private int opl_p2;

		// Token: 0x0400EF7D RID: 61309
		private int opl_p3;
	}
}
