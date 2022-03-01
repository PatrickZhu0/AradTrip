using System;

namespace behaviac
{
	// Token: 0x02003DB5 RID: 15797
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node15 : Action
	{
		// Token: 0x060162FA RID: 90874 RVA: 0x006B4F83 File Offset: 0x006B3383
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523801;
		}

		// Token: 0x060162FB RID: 90875 RVA: 0x006B4FA4 File Offset: 0x006B33A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB48 RID: 64328
		private BE_Target method_p0;

		// Token: 0x0400FB49 RID: 64329
		private int method_p1;
	}
}
