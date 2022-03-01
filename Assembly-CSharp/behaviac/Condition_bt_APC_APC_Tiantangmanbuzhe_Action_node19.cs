using System;

namespace behaviac
{
	// Token: 0x02001E1A RID: 7706
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node19 : Condition
	{
		// Token: 0x060125E5 RID: 75237 RVA: 0x0055DA7F File Offset: 0x0055BE7F
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node19()
		{
			this.opl_p0 = 8014;
		}

		// Token: 0x060125E6 RID: 75238 RVA: 0x0055DA94 File Offset: 0x0055BE94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFCF RID: 49103
		private int opl_p0;
	}
}
