using System;

namespace behaviac
{
	// Token: 0x02003DB8 RID: 15800
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node19 : Action
	{
		// Token: 0x06016300 RID: 90880 RVA: 0x006B5087 File Offset: 0x006B3487
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523801;
		}

		// Token: 0x06016301 RID: 90881 RVA: 0x006B50A8 File Offset: 0x006B34A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB52 RID: 64338
		private BE_Target method_p0;

		// Token: 0x0400FB53 RID: 64339
		private int method_p1;
	}
}
