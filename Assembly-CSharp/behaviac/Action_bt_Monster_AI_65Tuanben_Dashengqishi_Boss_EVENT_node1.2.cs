using System;

namespace behaviac
{
	// Token: 0x02002DC9 RID: 11721
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node17 : Action
	{
		// Token: 0x06014471 RID: 83057 RVA: 0x00617A67 File Offset: 0x00615E67
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570306;
		}

		// Token: 0x06014472 RID: 83058 RVA: 0x00617A88 File Offset: 0x00615E88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE34 RID: 56884
		private BE_Target method_p0;

		// Token: 0x0400DE35 RID: 56885
		private int method_p1;
	}
}
