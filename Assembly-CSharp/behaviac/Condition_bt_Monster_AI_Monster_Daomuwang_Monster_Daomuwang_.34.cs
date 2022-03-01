using System;

namespace behaviac
{
	// Token: 0x02003649 RID: 13897
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node22 : Condition
	{
		// Token: 0x060154B5 RID: 87221 RVA: 0x0066B8E2 File Offset: 0x00669CE2
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node22()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060154B6 RID: 87222 RVA: 0x0066B918 File Offset: 0x00669D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE6D RID: 61037
		private int opl_p0;

		// Token: 0x0400EE6E RID: 61038
		private int opl_p1;

		// Token: 0x0400EE6F RID: 61039
		private int opl_p2;

		// Token: 0x0400EE70 RID: 61040
		private int opl_p3;
	}
}
