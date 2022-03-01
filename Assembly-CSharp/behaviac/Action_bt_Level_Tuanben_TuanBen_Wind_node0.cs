using System;

namespace behaviac
{
	// Token: 0x02002AFA RID: 11002
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node0 : Action
	{
		// Token: 0x06013F08 RID: 81672 RVA: 0x005FC33B File Offset: 0x005FA73B
		public Action_bt_Level_Tuanben_TuanBen_Wind_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = 0;
		}

		// Token: 0x06013F09 RID: 81673 RVA: 0x005FC358 File Offset: 0x005FA758
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D959 RID: 55641
		private LevelCounterType method_p0;

		// Token: 0x0400D95A RID: 55642
		private int method_p1;
	}
}
