using System;

namespace behaviac
{
	// Token: 0x02003571 RID: 13681
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node8 : Action
	{
		// Token: 0x06015318 RID: 86808 RVA: 0x00663329 File Offset: 0x00661729
		public Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 1;
		}

		// Token: 0x06015319 RID: 86809 RVA: 0x0066334C File Offset: 0x0066174C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400ECD5 RID: 60629
		private int method_p0;

		// Token: 0x0400ECD6 RID: 60630
		private int method_p1;
	}
}
