using System;

namespace behaviac
{
	// Token: 0x02003A33 RID: 14899
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node29 : Condition
	{
		// Token: 0x06015C30 RID: 89136 RVA: 0x0069265D File Offset: 0x00690A5D
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node29()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C31 RID: 89137 RVA: 0x00692694 File Offset: 0x00690A94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F546 RID: 62790
		private int opl_p0;

		// Token: 0x0400F547 RID: 62791
		private int opl_p1;

		// Token: 0x0400F548 RID: 62792
		private int opl_p2;

		// Token: 0x0400F549 RID: 62793
		private int opl_p3;
	}
}
