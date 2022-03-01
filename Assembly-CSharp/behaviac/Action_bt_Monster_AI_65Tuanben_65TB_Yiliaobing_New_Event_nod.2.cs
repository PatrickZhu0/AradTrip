using System;

namespace behaviac
{
	// Token: 0x02002D2B RID: 11563
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node11 : Action
	{
		// Token: 0x0601433F RID: 82751 RVA: 0x00611BEB File Offset: 0x0060FFEB
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521983;
		}

		// Token: 0x06014340 RID: 82752 RVA: 0x00611C0C File Offset: 0x0061000C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCFE RID: 56574
		private BE_Target method_p0;

		// Token: 0x0400DCFF RID: 56575
		private int method_p1;
	}
}
