using System;

namespace behaviac
{
	// Token: 0x02002AF5 RID: 10997
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node35 : Action
	{
		// Token: 0x06013EFE RID: 81662 RVA: 0x005FC203 File Offset: 0x005FA603
		public Action_bt_Level_Tuanben_TuanBen_Wind_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06013EFF RID: 81663 RVA: 0x005FC219 File Offset: 0x005FA619
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SetCountTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D951 RID: 55633
		private int method_p0;
	}
}
