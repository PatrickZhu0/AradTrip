using System;

namespace behaviac
{
	// Token: 0x02003250 RID: 12880
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3 : Condition
	{
		// Token: 0x06014D20 RID: 85280 RVA: 0x00645CAB File Offset: 0x006440AB
		public Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3()
		{
			this.opl_p0 = 570172;
		}

		// Token: 0x06014D21 RID: 85281 RVA: 0x00645CC0 File Offset: 0x006440C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E66C RID: 58988
		private int opl_p0;
	}
}
