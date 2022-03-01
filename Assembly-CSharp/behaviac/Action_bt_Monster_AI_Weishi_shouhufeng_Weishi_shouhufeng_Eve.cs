using System;

namespace behaviac
{
	// Token: 0x02003DBD RID: 15805
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node5 : Action
	{
		// Token: 0x06016309 RID: 90889 RVA: 0x006B568F File Offset: 0x006B3A8F
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 16;
		}

		// Token: 0x0601630A RID: 90890 RVA: 0x006B56AD File Offset: 0x006B3AAD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB5E RID: 64350
		private BE_Target method_p0;

		// Token: 0x0400FB5F RID: 64351
		private int method_p1;
	}
}
