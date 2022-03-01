using System;

namespace behaviac
{
	// Token: 0x02002AE1 RID: 10977
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node0 : Action
	{
		// Token: 0x06013EDA RID: 81626 RVA: 0x005FB277 File Offset: 0x005F9677
		public Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = 0;
		}

		// Token: 0x06013EDB RID: 81627 RVA: 0x005FB294 File Offset: 0x005F9694
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D945 RID: 55621
		private LevelCounterType method_p0;

		// Token: 0x0400D946 RID: 55622
		private int method_p1;
	}
}
