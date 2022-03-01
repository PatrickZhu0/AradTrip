using System;

namespace behaviac
{
	// Token: 0x02003A61 RID: 14945
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node31 : Condition
	{
		// Token: 0x06015C8B RID: 89227 RVA: 0x0069426B File Offset: 0x0069266B
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node31()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C8C RID: 89228 RVA: 0x006942A0 File Offset: 0x006926A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5BA RID: 62906
		private int opl_p0;

		// Token: 0x0400F5BB RID: 62907
		private int opl_p1;

		// Token: 0x0400F5BC RID: 62908
		private int opl_p2;

		// Token: 0x0400F5BD RID: 62909
		private int opl_p3;
	}
}
