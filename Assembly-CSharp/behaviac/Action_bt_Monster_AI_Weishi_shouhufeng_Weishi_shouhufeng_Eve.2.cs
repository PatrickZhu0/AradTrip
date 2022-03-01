using System;

namespace behaviac
{
	// Token: 0x02003DBF RID: 15807
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node8 : Action
	{
		// Token: 0x0601630D RID: 90893 RVA: 0x006B5727 File Offset: 0x006B3B27
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52171;
		}

		// Token: 0x0601630E RID: 90894 RVA: 0x006B5748 File Offset: 0x006B3B48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB63 RID: 64355
		private BE_Target method_p0;

		// Token: 0x0400FB64 RID: 64356
		private int method_p1;
	}
}
