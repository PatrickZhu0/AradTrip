using System;

namespace behaviac
{
	// Token: 0x02003245 RID: 12869
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node6 : Condition
	{
		// Token: 0x06014D0B RID: 85259 RVA: 0x006457B9 File Offset: 0x00643BB9
		public Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node6()
		{
			this.opl_p0 = 570173;
		}

		// Token: 0x06014D0C RID: 85260 RVA: 0x006457CC File Offset: 0x00643BCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E65C RID: 58972
		private int opl_p0;
	}
}
