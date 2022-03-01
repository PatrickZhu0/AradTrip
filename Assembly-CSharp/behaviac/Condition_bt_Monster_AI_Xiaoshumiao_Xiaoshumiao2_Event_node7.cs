using System;

namespace behaviac
{
	// Token: 0x02003E1F RID: 15903
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node7 : Condition
	{
		// Token: 0x060163C6 RID: 91078 RVA: 0x006B912F File Offset: 0x006B752F
		public Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node7()
		{
			this.opl_p0 = 9757;
		}

		// Token: 0x060163C7 RID: 91079 RVA: 0x006B9144 File Offset: 0x006B7544
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC2E RID: 64558
		private int opl_p0;
	}
}
