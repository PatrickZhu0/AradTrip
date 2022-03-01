using System;

namespace behaviac
{
	// Token: 0x02003E2B RID: 15915
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node4 : Condition
	{
		// Token: 0x060163DC RID: 91100 RVA: 0x006B99D3 File Offset: 0x006B7DD3
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node4()
		{
			this.opl_p0 = 7226;
		}

		// Token: 0x060163DD RID: 91101 RVA: 0x006B99E8 File Offset: 0x006B7DE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC44 RID: 64580
		private int opl_p0;
	}
}
