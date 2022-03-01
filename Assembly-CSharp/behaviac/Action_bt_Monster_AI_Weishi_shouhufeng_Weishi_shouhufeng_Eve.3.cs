using System;

namespace behaviac
{
	// Token: 0x02003DC0 RID: 15808
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node9 : Action
	{
		// Token: 0x0601630F RID: 90895 RVA: 0x006B5762 File Offset: 0x006B3B62
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52172;
		}

		// Token: 0x06016310 RID: 90896 RVA: 0x006B5783 File Offset: 0x006B3B83
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB65 RID: 64357
		private BE_Target method_p0;

		// Token: 0x0400FB66 RID: 64358
		private int method_p1;
	}
}
