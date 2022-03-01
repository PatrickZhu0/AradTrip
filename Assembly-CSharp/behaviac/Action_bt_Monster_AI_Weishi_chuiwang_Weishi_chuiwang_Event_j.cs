using System;

namespace behaviac
{
	// Token: 0x02003DAD RID: 15789
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4 : Action
	{
		// Token: 0x060162EA RID: 90858 RVA: 0x006B4CE7 File Offset: 0x006B30E7
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523801;
		}

		// Token: 0x060162EB RID: 90859 RVA: 0x006B4D08 File Offset: 0x006B3108
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB31 RID: 64305
		private BE_Target method_p0;

		// Token: 0x0400FB32 RID: 64306
		private int method_p1;
	}
}
