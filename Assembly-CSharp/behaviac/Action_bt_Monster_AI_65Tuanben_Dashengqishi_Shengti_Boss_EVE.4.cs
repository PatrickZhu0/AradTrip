using System;

namespace behaviac
{
	// Token: 0x02002E8D RID: 11917
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node5 : Action
	{
		// Token: 0x060145F5 RID: 83445 RVA: 0x006209DB File Offset: 0x0061EDDB
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "强化祭台已通关，卡德蒙已被加强！";
			this.method_p1 = 7f;
			this.method_p2 = 2;
		}

		// Token: 0x060145F6 RID: 83446 RVA: 0x00620A07 File Offset: 0x0061EE07
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF77 RID: 57207
		private string method_p0;

		// Token: 0x0400DF78 RID: 57208
		private float method_p1;

		// Token: 0x0400DF79 RID: 57209
		private int method_p2;
	}
}
