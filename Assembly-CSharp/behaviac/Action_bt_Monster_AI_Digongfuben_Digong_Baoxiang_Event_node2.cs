using System;

namespace behaviac
{
	// Token: 0x0200323B RID: 12859
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2 : Action
	{
		// Token: 0x06014CF8 RID: 85240 RVA: 0x00645273 File Offset: 0x00643673
		public Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 29;
		}

		// Token: 0x06014CF9 RID: 85241 RVA: 0x00645291 File Offset: 0x00643691
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E651 RID: 58961
		private BE_Target method_p0;

		// Token: 0x0400E652 RID: 58962
		private int method_p1;
	}
}
