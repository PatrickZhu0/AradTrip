using System;

namespace behaviac
{
	// Token: 0x02003574 RID: 13684
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node3 : Action
	{
		// Token: 0x0601531D RID: 86813 RVA: 0x00663581 File Offset: 0x00661981
		public Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 4000;
			this.method_p1 = 0;
		}

		// Token: 0x0601531E RID: 86814 RVA: 0x006635A4 File Offset: 0x006619A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400ECDC RID: 60636
		private int method_p0;

		// Token: 0x0400ECDD RID: 60637
		private int method_p1;
	}
}
