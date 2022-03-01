using System;

namespace behaviac
{
	// Token: 0x02003DAE RID: 15790
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5 : Action
	{
		// Token: 0x060162EC RID: 90860 RVA: 0x006B4D22 File Offset: 0x006B3122
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523802;
		}

		// Token: 0x060162ED RID: 90861 RVA: 0x006B4D43 File Offset: 0x006B3143
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB33 RID: 64307
		private BE_Target method_p0;

		// Token: 0x0400FB34 RID: 64308
		private int method_p1;
	}
}
