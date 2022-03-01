using System;

namespace behaviac
{
	// Token: 0x02002EC9 RID: 11977
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node50 : Action
	{
		// Token: 0x0601466C RID: 83564 RVA: 0x00622696 File Offset: 0x00620A96
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node50()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570297;
			this.method_p2 = 15300;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x0601466D RID: 83565 RVA: 0x006226D0 File Offset: 0x00620AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFD6 RID: 57302
		private BE_Target method_p0;

		// Token: 0x0400DFD7 RID: 57303
		private int method_p1;

		// Token: 0x0400DFD8 RID: 57304
		private int method_p2;

		// Token: 0x0400DFD9 RID: 57305
		private int method_p3;

		// Token: 0x0400DFDA RID: 57306
		private int method_p4;
	}
}
