using System;

namespace behaviac
{
	// Token: 0x02003E22 RID: 15906
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3 : Condition
	{
		// Token: 0x060163CB RID: 91083 RVA: 0x006B943A File Offset: 0x006B783A
		public Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3()
		{
			this.opl_p0 = 500;
			this.opl_p1 = 500;
			this.opl_p2 = 500;
			this.opl_p3 = 500;
		}

		// Token: 0x060163CC RID: 91084 RVA: 0x006B9470 File Offset: 0x006B7870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC31 RID: 64561
		private int opl_p0;

		// Token: 0x0400FC32 RID: 64562
		private int opl_p1;

		// Token: 0x0400FC33 RID: 64563
		private int opl_p2;

		// Token: 0x0400FC34 RID: 64564
		private int opl_p3;
	}
}
