using System;

namespace behaviac
{
	// Token: 0x02003DC7 RID: 15815
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node19 : Action
	{
		// Token: 0x0601631D RID: 90909 RVA: 0x006B59C3 File Offset: 0x006B3DC3
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52171;
		}

		// Token: 0x0601631E RID: 90910 RVA: 0x006B59E4 File Offset: 0x006B3DE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB7A RID: 64378
		private BE_Target method_p0;

		// Token: 0x0400FB7B RID: 64379
		private int method_p1;
	}
}
