using System;

namespace behaviac
{
	// Token: 0x02003641 RID: 13889
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node7 : Condition
	{
		// Token: 0x060154A5 RID: 87205 RVA: 0x0066B57A File Offset: 0x0066997A
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node7()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060154A6 RID: 87206 RVA: 0x0066B5B0 File Offset: 0x006699B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE5D RID: 61021
		private int opl_p0;

		// Token: 0x0400EE5E RID: 61022
		private int opl_p1;

		// Token: 0x0400EE5F RID: 61023
		private int opl_p2;

		// Token: 0x0400EE60 RID: 61024
		private int opl_p3;
	}
}
