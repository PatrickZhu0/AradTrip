using System;

namespace behaviac
{
	// Token: 0x02003AA0 RID: 15008
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node108 : Condition
	{
		// Token: 0x06015D04 RID: 89348 RVA: 0x00696F1E File Offset: 0x0069531E
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node108()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015D05 RID: 89349 RVA: 0x00696F30 File Offset: 0x00695330
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 4;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F62F RID: 63023
		private int opl_p0;
	}
}
