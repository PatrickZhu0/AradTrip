using System;

namespace behaviac
{
	// Token: 0x02002DC5 RID: 11717
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node5 : Action
	{
		// Token: 0x06014469 RID: 83049 RVA: 0x00617937 File Offset: 0x00615D37
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "强化祭台已通关，神圣·卡德蒙已被加强！";
			this.method_p1 = 7f;
			this.method_p2 = 2;
		}

		// Token: 0x0601446A RID: 83050 RVA: 0x00617963 File Offset: 0x00615D63
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE29 RID: 56873
		private string method_p0;

		// Token: 0x0400DE2A RID: 56874
		private float method_p1;

		// Token: 0x0400DE2B RID: 56875
		private int method_p2;
	}
}
