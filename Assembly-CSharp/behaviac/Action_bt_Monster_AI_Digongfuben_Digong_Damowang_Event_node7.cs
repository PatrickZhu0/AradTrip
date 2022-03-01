using System;

namespace behaviac
{
	// Token: 0x02003248 RID: 12872
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node7 : Action
	{
		// Token: 0x06014D11 RID: 85265 RVA: 0x0064589A File Offset: 0x00643C9A
		public Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570225;
		}

		// Token: 0x06014D12 RID: 85266 RVA: 0x006458BB File Offset: 0x00643CBB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E662 RID: 58978
		private BE_Target method_p0;

		// Token: 0x0400E663 RID: 58979
		private int method_p1;
	}
}
