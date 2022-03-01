using System;

namespace behaviac
{
	// Token: 0x02003DAF RID: 15791
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6 : Action
	{
		// Token: 0x060162EE RID: 90862 RVA: 0x006B4D5D File Offset: 0x006B315D
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523803;
		}

		// Token: 0x060162EF RID: 90863 RVA: 0x006B4D7E File Offset: 0x006B317E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB35 RID: 64309
		private BE_Target method_p0;

		// Token: 0x0400FB36 RID: 64310
		private int method_p1;
	}
}
