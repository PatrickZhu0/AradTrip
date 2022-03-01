using System;

namespace behaviac
{
	// Token: 0x02002DC1 RID: 11713
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node28 : Action
	{
		// Token: 0x06014461 RID: 83041 RVA: 0x00617827 File Offset: 0x00615C27
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "弱化祭台已通关，神圣·卡德蒙已被削弱！";
			this.method_p1 = 7f;
			this.method_p2 = 2;
		}

		// Token: 0x06014462 RID: 83042 RVA: 0x00617853 File Offset: 0x00615C53
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE22 RID: 56866
		private string method_p0;

		// Token: 0x0400DE23 RID: 56867
		private float method_p1;

		// Token: 0x0400DE24 RID: 56868
		private int method_p2;
	}
}
