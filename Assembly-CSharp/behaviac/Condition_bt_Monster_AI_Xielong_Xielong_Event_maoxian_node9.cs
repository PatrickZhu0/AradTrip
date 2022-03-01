using System;

namespace behaviac
{
	// Token: 0x02003E31 RID: 15921
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node9 : Condition
	{
		// Token: 0x060163E8 RID: 91112 RVA: 0x006B9BE7 File Offset: 0x006B7FE7
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node9()
		{
			this.opl_p0 = 7226;
		}

		// Token: 0x060163E9 RID: 91113 RVA: 0x006B9BFC File Offset: 0x006B7FFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC4D RID: 64589
		private int opl_p0;
	}
}
