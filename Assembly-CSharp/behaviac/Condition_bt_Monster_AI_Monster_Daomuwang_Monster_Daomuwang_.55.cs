using System;

namespace behaviac
{
	// Token: 0x02003667 RID: 13927
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node27 : Condition
	{
		// Token: 0x060154EF RID: 87279 RVA: 0x0066D3F6 File Offset: 0x0066B7F6
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node27()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060154F0 RID: 87280 RVA: 0x0066D42C File Offset: 0x0066B82C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEA5 RID: 61093
		private int opl_p0;

		// Token: 0x0400EEA6 RID: 61094
		private int opl_p1;

		// Token: 0x0400EEA7 RID: 61095
		private int opl_p2;

		// Token: 0x0400EEA8 RID: 61096
		private int opl_p3;
	}
}
