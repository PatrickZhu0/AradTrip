using System;

namespace behaviac
{
	// Token: 0x0200367B RID: 13947
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node22 : Condition
	{
		// Token: 0x06015517 RID: 87319 RVA: 0x0066DC7A File Offset: 0x0066C07A
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node22()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015518 RID: 87320 RVA: 0x0066DCB0 File Offset: 0x0066C0B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EECD RID: 61133
		private int opl_p0;

		// Token: 0x0400EECE RID: 61134
		private int opl_p1;

		// Token: 0x0400EECF RID: 61135
		private int opl_p2;

		// Token: 0x0400EED0 RID: 61136
		private int opl_p3;
	}
}
