using System;

namespace behaviac
{
	// Token: 0x02003A9C RID: 15004
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node105 : Condition
	{
		// Token: 0x06015CFC RID: 89340 RVA: 0x00696E2E File Offset: 0x0069522E
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node105()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015CFD RID: 89341 RVA: 0x00696E40 File Offset: 0x00695240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F62B RID: 63019
		private int opl_p0;
	}
}
