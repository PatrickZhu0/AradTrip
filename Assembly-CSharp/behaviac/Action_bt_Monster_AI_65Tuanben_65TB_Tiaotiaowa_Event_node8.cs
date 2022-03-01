using System;

namespace behaviac
{
	// Token: 0x02002D0F RID: 11535
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node8 : Action
	{
		// Token: 0x0601430C RID: 82700 RVA: 0x00610AEB File Offset: 0x0060EEEB
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 96;
		}

		// Token: 0x0601430D RID: 82701 RVA: 0x00610B09 File Offset: 0x0060EF09
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCB8 RID: 56504
		private BE_Target method_p0;

		// Token: 0x0400DCB9 RID: 56505
		private int method_p1;
	}
}
