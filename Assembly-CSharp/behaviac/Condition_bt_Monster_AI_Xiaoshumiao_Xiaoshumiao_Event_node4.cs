using System;

namespace behaviac
{
	// Token: 0x02003E23 RID: 15907
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4 : Condition
	{
		// Token: 0x060163CD RID: 91085 RVA: 0x006B94B5 File Offset: 0x006B78B5
		public Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4()
		{
			this.opl_p0 = 7244;
		}

		// Token: 0x060163CE RID: 91086 RVA: 0x006B94C8 File Offset: 0x006B78C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC35 RID: 64565
		private int opl_p0;
	}
}
