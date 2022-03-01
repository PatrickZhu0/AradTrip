using System;

namespace behaviac
{
	// Token: 0x02002B9A RID: 11162
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node8 : Action
	{
		// Token: 0x0601403E RID: 81982 RVA: 0x00602D93 File Offset: 0x00601193
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 96;
		}

		// Token: 0x0601403F RID: 81983 RVA: 0x00602DB1 File Offset: 0x006011B1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA32 RID: 55858
		private BE_Target method_p0;

		// Token: 0x0400DA33 RID: 55859
		private int method_p1;
	}
}
