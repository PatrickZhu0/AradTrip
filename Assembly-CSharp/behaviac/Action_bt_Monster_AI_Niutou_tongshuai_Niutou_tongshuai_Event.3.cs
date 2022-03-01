using System;

namespace behaviac
{
	// Token: 0x02003726 RID: 14118
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4 : Action
	{
		// Token: 0x06015658 RID: 87640 RVA: 0x00674A85 File Offset: 0x00672E85
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538802;
		}

		// Token: 0x06015659 RID: 87641 RVA: 0x00674AA6 File Offset: 0x00672EA6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F028 RID: 61480
		private BE_Target method_p0;

		// Token: 0x0400F029 RID: 61481
		private int method_p1;
	}
}
