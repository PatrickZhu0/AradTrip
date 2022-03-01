using System;

namespace behaviac
{
	// Token: 0x02003D06 RID: 15622
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node12 : Condition
	{
		// Token: 0x060161AA RID: 90538 RVA: 0x006AEA27 File Offset: 0x006ACE27
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node12()
		{
			this.opl_p0 = 21302;
		}

		// Token: 0x060161AB RID: 90539 RVA: 0x006AEA3C File Offset: 0x006ACE3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA3C RID: 64060
		private int opl_p0;
	}
}
