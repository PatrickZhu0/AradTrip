using System;

namespace behaviac
{
	// Token: 0x02003624 RID: 13860
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node12 : Condition
	{
		// Token: 0x0601546C RID: 87148 RVA: 0x0066A1FA File Offset: 0x006685FA
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node12()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 8000;
			this.opl_p2 = 8000;
			this.opl_p3 = 8000;
		}

		// Token: 0x0601546D RID: 87149 RVA: 0x0066A230 File Offset: 0x00668630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE25 RID: 60965
		private int opl_p0;

		// Token: 0x0400EE26 RID: 60966
		private int opl_p1;

		// Token: 0x0400EE27 RID: 60967
		private int opl_p2;

		// Token: 0x0400EE28 RID: 60968
		private int opl_p3;
	}
}
