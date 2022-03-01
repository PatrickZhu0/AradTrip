using System;

namespace behaviac
{
	// Token: 0x020030E5 RID: 12517
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node9 : Condition
	{
		// Token: 0x06014A7D RID: 84605 RVA: 0x0063852D File Offset: 0x0063692D
		public Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node9()
		{
			this.opl_p0 = 20707;
		}

		// Token: 0x06014A7E RID: 84606 RVA: 0x00638540 File Offset: 0x00636940
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3ED RID: 58349
		private int opl_p0;
	}
}
