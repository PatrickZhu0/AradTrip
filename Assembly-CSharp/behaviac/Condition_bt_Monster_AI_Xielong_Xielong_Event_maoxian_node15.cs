using System;

namespace behaviac
{
	// Token: 0x02003E36 RID: 15926
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node15 : Condition
	{
		// Token: 0x060163F2 RID: 91122 RVA: 0x006B9D9B File Offset: 0x006B819B
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node15()
		{
			this.opl_p0 = 7226;
		}

		// Token: 0x060163F3 RID: 91123 RVA: 0x006B9DB0 File Offset: 0x006B81B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC53 RID: 64595
		private int opl_p0;
	}
}
