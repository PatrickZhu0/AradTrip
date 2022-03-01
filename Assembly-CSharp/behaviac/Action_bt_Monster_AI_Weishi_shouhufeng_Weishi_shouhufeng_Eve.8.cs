using System;

namespace behaviac
{
	// Token: 0x02003DCA RID: 15818
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node23 : Action
	{
		// Token: 0x06016323 RID: 90915 RVA: 0x006B5AC7 File Offset: 0x006B3EC7
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52171;
		}

		// Token: 0x06016324 RID: 90916 RVA: 0x006B5AE8 File Offset: 0x006B3EE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB84 RID: 64388
		private BE_Target method_p0;

		// Token: 0x0400FB85 RID: 64389
		private int method_p1;
	}
}
