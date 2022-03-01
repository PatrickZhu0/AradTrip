using System;

namespace behaviac
{
	// Token: 0x02002D2C RID: 11564
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node0 : Action
	{
		// Token: 0x06014341 RID: 82753 RVA: 0x00611C26 File Offset: 0x00610026
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 96;
		}

		// Token: 0x06014342 RID: 82754 RVA: 0x00611C44 File Offset: 0x00610044
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD00 RID: 56576
		private BE_Target method_p0;

		// Token: 0x0400DD01 RID: 56577
		private int method_p1;
	}
}
