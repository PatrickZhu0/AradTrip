using System;

namespace behaviac
{
	// Token: 0x02003E26 RID: 15910
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node7 : Condition
	{
		// Token: 0x060163D3 RID: 91091 RVA: 0x006B9607 File Offset: 0x006B7A07
		public Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node7()
		{
			this.opl_p0 = 7244;
		}

		// Token: 0x060163D4 RID: 91092 RVA: 0x006B961C File Offset: 0x006B7A1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC3B RID: 64571
		private int opl_p0;
	}
}
