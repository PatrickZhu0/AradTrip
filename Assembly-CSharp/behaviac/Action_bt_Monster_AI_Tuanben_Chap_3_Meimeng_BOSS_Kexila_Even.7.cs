using System;

namespace behaviac
{
	// Token: 0x02003952 RID: 14674
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8 : Action
	{
		// Token: 0x06015A7E RID: 88702 RVA: 0x0068A9D9 File Offset: 0x00688DD9
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 2;
		}

		// Token: 0x06015A7F RID: 88703 RVA: 0x0068A9FC File Offset: 0x00688DFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F415 RID: 62485
		private int method_p0;

		// Token: 0x0400F416 RID: 62486
		private int method_p1;
	}
}
