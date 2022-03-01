using System;

namespace behaviac
{
	// Token: 0x02002AF8 RID: 11000
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node8 : Action
	{
		// Token: 0x06013F04 RID: 81668 RVA: 0x005FC2BC File Offset: 0x005FA6BC
		public Action_bt_Level_Tuanben_TuanBen_Wind_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = LevelCounterType.WindDir;
			this.method_p1 = -1;
		}

		// Token: 0x06013F05 RID: 81669 RVA: 0x005FC2D9 File Offset: 0x005FA6D9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D956 RID: 55638
		private LevelCounterType method_p0;

		// Token: 0x0400D957 RID: 55639
		private int method_p1;
	}
}
