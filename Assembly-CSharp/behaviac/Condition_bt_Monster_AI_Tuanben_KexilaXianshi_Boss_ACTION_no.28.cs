using System;

namespace behaviac
{
	// Token: 0x02003A5A RID: 14938
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node23 : Condition
	{
		// Token: 0x06015C7D RID: 89213 RVA: 0x00693F33 File Offset: 0x00692333
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node23()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C7E RID: 89214 RVA: 0x00693F68 File Offset: 0x00692368
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5A9 RID: 62889
		private int opl_p0;

		// Token: 0x0400F5AA RID: 62890
		private int opl_p1;

		// Token: 0x0400F5AB RID: 62891
		private int opl_p2;

		// Token: 0x0400F5AC RID: 62892
		private int opl_p3;
	}
}
