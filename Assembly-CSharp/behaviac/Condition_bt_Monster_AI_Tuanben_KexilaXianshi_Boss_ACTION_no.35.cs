using System;

namespace behaviac
{
	// Token: 0x02003A64 RID: 14948
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node34 : Condition
	{
		// Token: 0x06015C91 RID: 89233 RVA: 0x006943D6 File Offset: 0x006927D6
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node34()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C92 RID: 89234 RVA: 0x0069440C File Offset: 0x0069280C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5C1 RID: 62913
		private int opl_p0;

		// Token: 0x0400F5C2 RID: 62914
		private int opl_p1;

		// Token: 0x0400F5C3 RID: 62915
		private int opl_p2;

		// Token: 0x0400F5C4 RID: 62916
		private int opl_p3;
	}
}
