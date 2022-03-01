using System;

namespace behaviac
{
	// Token: 0x02002ADF RID: 10975
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node8 : Action
	{
		// Token: 0x06013ED6 RID: 81622 RVA: 0x005FB1F8 File Offset: 0x005F95F8
		public Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = -1;
		}

		// Token: 0x06013ED7 RID: 81623 RVA: 0x005FB215 File Offset: 0x005F9615
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D942 RID: 55618
		private LevelCounterType method_p0;

		// Token: 0x0400D943 RID: 55619
		private int method_p1;
	}
}
