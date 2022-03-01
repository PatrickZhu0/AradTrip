using System;

namespace behaviac
{
	// Token: 0x02002AE3 RID: 10979
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node13 : Action
	{
		// Token: 0x06013EDE RID: 81630 RVA: 0x005FB2F7 File Offset: 0x005F96F7
		public Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = 1;
		}

		// Token: 0x06013EDF RID: 81631 RVA: 0x005FB314 File Offset: 0x005F9714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D948 RID: 55624
		private LevelCounterType method_p0;

		// Token: 0x0400D949 RID: 55625
		private int method_p1;
	}
}
