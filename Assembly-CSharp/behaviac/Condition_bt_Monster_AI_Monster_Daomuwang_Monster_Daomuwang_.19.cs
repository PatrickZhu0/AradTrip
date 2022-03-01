using System;

namespace behaviac
{
	// Token: 0x02003635 RID: 13877
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node27 : Condition
	{
		// Token: 0x0601548D RID: 87181 RVA: 0x0066B05E File Offset: 0x0066945E
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node27()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601548E RID: 87182 RVA: 0x0066B094 File Offset: 0x00669494
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE45 RID: 60997
		private int opl_p0;

		// Token: 0x0400EE46 RID: 60998
		private int opl_p1;

		// Token: 0x0400EE47 RID: 60999
		private int opl_p2;

		// Token: 0x0400EE48 RID: 61000
		private int opl_p3;
	}
}
