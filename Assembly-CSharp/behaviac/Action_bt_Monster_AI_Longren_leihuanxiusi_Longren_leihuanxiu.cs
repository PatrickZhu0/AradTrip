using System;

namespace behaviac
{
	// Token: 0x02003592 RID: 13714
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node15 : Action
	{
		// Token: 0x06015354 RID: 86868 RVA: 0x00664764 File Offset: 0x00662B64
		public Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBackHit;
		}

		// Token: 0x06015355 RID: 86869 RVA: 0x0066477A File Offset: 0x00662B7A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED1B RID: 60699
		private EventType method_p0;
	}
}
