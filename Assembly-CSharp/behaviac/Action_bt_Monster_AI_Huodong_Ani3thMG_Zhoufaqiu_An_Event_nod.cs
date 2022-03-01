using System;

namespace behaviac
{
	// Token: 0x0200356F RID: 13679
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node7 : Action
	{
		// Token: 0x06015314 RID: 86804 RVA: 0x00663278 File Offset: 0x00661678
		public Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node7()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 0;
		}

		// Token: 0x06015315 RID: 86805 RVA: 0x0066329C File Offset: 0x0066169C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400ECCE RID: 60622
		private int method_p0;

		// Token: 0x0400ECCF RID: 60623
		private int method_p1;
	}
}
