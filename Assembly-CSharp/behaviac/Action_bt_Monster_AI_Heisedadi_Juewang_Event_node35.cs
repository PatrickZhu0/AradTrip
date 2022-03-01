using System;

namespace behaviac
{
	// Token: 0x0200347B RID: 13435
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node35 : Action
	{
		// Token: 0x0601513F RID: 86335 RVA: 0x0065A076 File Offset: 0x00658476
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 560001;
		}

		// Token: 0x06015140 RID: 86336 RVA: 0x0065A097 File Offset: 0x00658497
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA41 RID: 59969
		private BE_Target method_p0;

		// Token: 0x0400EA42 RID: 59970
		private int method_p1;
	}
}
