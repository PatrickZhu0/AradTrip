using System;

namespace behaviac
{
	// Token: 0x02003727 RID: 14119
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5 : Action
	{
		// Token: 0x0601565A RID: 87642 RVA: 0x00674AC0 File Offset: 0x00672EC0
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538803;
		}

		// Token: 0x0601565B RID: 87643 RVA: 0x00674AE1 File Offset: 0x00672EE1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F02A RID: 61482
		private BE_Target method_p0;

		// Token: 0x0400F02B RID: 61483
		private int method_p1;
	}
}
