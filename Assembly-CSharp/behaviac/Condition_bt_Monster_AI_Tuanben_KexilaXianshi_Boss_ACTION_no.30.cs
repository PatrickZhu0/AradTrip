using System;

namespace behaviac
{
	// Token: 0x02003A5D RID: 14941
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node26 : Condition
	{
		// Token: 0x06015C83 RID: 89219 RVA: 0x0069409E File Offset: 0x0069249E
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node26()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C84 RID: 89220 RVA: 0x006940D4 File Offset: 0x006924D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5B0 RID: 62896
		private int opl_p0;

		// Token: 0x0400F5B1 RID: 62897
		private int opl_p1;

		// Token: 0x0400F5B2 RID: 62898
		private int opl_p2;

		// Token: 0x0400F5B3 RID: 62899
		private int opl_p3;
	}
}
