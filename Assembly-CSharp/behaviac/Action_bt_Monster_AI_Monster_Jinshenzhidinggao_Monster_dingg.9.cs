using System;

namespace behaviac
{
	// Token: 0x020036A2 RID: 13986
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node18 : Action
	{
		// Token: 0x06015560 RID: 87392 RVA: 0x0066F8BA File Offset: 0x0066DCBA
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521233;
		}

		// Token: 0x06015561 RID: 87393 RVA: 0x0066F8DB File Offset: 0x0066DCDB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF30 RID: 61232
		private BE_Target method_p0;

		// Token: 0x0400EF31 RID: 61233
		private int method_p1;
	}
}
