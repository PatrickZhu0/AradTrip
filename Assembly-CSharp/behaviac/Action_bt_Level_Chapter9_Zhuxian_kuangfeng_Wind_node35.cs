using System;

namespace behaviac
{
	// Token: 0x02002ADC RID: 10972
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node35 : Action
	{
		// Token: 0x06013ED0 RID: 81616 RVA: 0x005FB13F File Offset: 0x005F953F
		public Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06013ED1 RID: 81617 RVA: 0x005FB155 File Offset: 0x005F9555
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCountTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D93D RID: 55613
		private int method_p0;
	}
}
