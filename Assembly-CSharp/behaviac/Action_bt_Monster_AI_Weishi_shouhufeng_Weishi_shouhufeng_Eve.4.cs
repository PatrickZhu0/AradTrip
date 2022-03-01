using System;

namespace behaviac
{
	// Token: 0x02003DC1 RID: 15809
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node10 : Action
	{
		// Token: 0x06016311 RID: 90897 RVA: 0x006B579D File Offset: 0x006B3B9D
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52173;
		}

		// Token: 0x06016312 RID: 90898 RVA: 0x006B57BE File Offset: 0x006B3BBE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB67 RID: 64359
		private BE_Target method_p0;

		// Token: 0x0400FB68 RID: 64360
		private int method_p1;
	}
}
