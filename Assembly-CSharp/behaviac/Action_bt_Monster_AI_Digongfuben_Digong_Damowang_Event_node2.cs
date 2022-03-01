using System;

namespace behaviac
{
	// Token: 0x02003247 RID: 12871
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2 : Action
	{
		// Token: 0x06014D0F RID: 85263 RVA: 0x0064585F File Offset: 0x00643C5F
		public Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570219;
		}

		// Token: 0x06014D10 RID: 85264 RVA: 0x00645880 File Offset: 0x00643C80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E660 RID: 58976
		private BE_Target method_p0;

		// Token: 0x0400E661 RID: 58977
		private int method_p1;
	}
}
