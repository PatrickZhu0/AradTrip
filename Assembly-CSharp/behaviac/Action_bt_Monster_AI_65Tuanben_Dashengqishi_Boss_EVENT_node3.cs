using System;

namespace behaviac
{
	// Token: 0x02002DBB RID: 11707
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node30 : Action
	{
		// Token: 0x06014455 RID: 83029 RVA: 0x006176D6 File Offset: 0x00615AD6
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570300;
		}

		// Token: 0x06014456 RID: 83030 RVA: 0x006176F7 File Offset: 0x00615AF7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE1D RID: 56861
		private BE_Target method_p0;

		// Token: 0x0400DE1E RID: 56862
		private int method_p1;
	}
}
