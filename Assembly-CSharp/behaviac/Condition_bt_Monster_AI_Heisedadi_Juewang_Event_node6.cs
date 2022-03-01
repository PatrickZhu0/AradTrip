using System;

namespace behaviac
{
	// Token: 0x02003484 RID: 13444
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node6 : Condition
	{
		// Token: 0x06015151 RID: 86353 RVA: 0x0065A340 File Offset: 0x00658740
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node6()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x06015152 RID: 86354 RVA: 0x0065A350 File Offset: 0x00658750
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA51 RID: 59985
		private EventType opl_p0;
	}
}
