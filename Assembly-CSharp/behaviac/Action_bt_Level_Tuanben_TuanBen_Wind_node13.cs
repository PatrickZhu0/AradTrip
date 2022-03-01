using System;

namespace behaviac
{
	// Token: 0x02002AFC RID: 11004
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node13 : Action
	{
		// Token: 0x06013F0C RID: 81676 RVA: 0x005FC3BB File Offset: 0x005FA7BB
		public Action_bt_Level_Tuanben_TuanBen_Wind_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = 1;
		}

		// Token: 0x06013F0D RID: 81677 RVA: 0x005FC3D8 File Offset: 0x005FA7D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D95C RID: 55644
		private LevelCounterType method_p0;

		// Token: 0x0400D95D RID: 55645
		private int method_p1;
	}
}
