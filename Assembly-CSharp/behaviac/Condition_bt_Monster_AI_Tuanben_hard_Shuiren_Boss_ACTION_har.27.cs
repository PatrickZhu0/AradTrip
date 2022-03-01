using System;

namespace behaviac
{
	// Token: 0x02003D65 RID: 15717
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node46 : Condition
	{
		// Token: 0x06016260 RID: 90720 RVA: 0x006B149B File Offset: 0x006AF89B
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node46()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016261 RID: 90721 RVA: 0x006B14D0 File Offset: 0x006AF8D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAB9 RID: 64185
		private int opl_p0;

		// Token: 0x0400FABA RID: 64186
		private int opl_p1;

		// Token: 0x0400FABB RID: 64187
		private int opl_p2;

		// Token: 0x0400FABC RID: 64188
		private int opl_p3;
	}
}
