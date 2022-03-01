using System;

namespace behaviac
{
	// Token: 0x02003A2F RID: 14895
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node22 : Condition
	{
		// Token: 0x06015C28 RID: 89128 RVA: 0x006924DE File Offset: 0x006908DE
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node22()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015C29 RID: 89129 RVA: 0x00692514 File Offset: 0x00690914
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F53F RID: 62783
		private int opl_p0;

		// Token: 0x0400F540 RID: 62784
		private int opl_p1;

		// Token: 0x0400F541 RID: 62785
		private int opl_p2;

		// Token: 0x0400F542 RID: 62786
		private int opl_p3;
	}
}
