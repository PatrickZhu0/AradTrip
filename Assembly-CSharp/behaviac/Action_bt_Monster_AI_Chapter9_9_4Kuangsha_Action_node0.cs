using System;

namespace behaviac
{
	// Token: 0x0200317A RID: 12666
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node0 : Action
	{
		// Token: 0x06014B8B RID: 84875 RVA: 0x0063D57D File Offset: 0x0063B97D
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06014B8C RID: 84876 RVA: 0x0063D593 File Offset: 0x0063B993
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4F8 RID: 58616
		private int method_p0;
	}
}
