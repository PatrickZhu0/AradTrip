using System;

namespace behaviac
{
	// Token: 0x0200365A RID: 13914
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node7 : Condition
	{
		// Token: 0x060154D6 RID: 87254 RVA: 0x0066C746 File Offset: 0x0066AB46
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node7()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060154D7 RID: 87255 RVA: 0x0066C77C File Offset: 0x0066AB7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE8D RID: 61069
		private int opl_p0;

		// Token: 0x0400EE8E RID: 61070
		private int opl_p1;

		// Token: 0x0400EE8F RID: 61071
		private int opl_p2;

		// Token: 0x0400EE90 RID: 61072
		private int opl_p3;
	}
}
