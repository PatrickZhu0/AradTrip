using System;

namespace behaviac
{
	// Token: 0x02003599 RID: 13721
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node10 : Action
	{
		// Token: 0x06015362 RID: 86882 RVA: 0x006649FB File Offset: 0x00662DFB
		public Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x06015363 RID: 86883 RVA: 0x00664A1C File Offset: 0x00662E1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED2A RID: 60714
		private BE_Target method_p0;

		// Token: 0x0400ED2B RID: 60715
		private int method_p1;
	}
}
