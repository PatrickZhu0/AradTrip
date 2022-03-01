using System;

namespace behaviac
{
	// Token: 0x02003222 RID: 12834
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node4 : Action
	{
		// Token: 0x06014CCD RID: 85197 RVA: 0x00644425 File Offset: 0x00642825
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570256;
		}

		// Token: 0x06014CCE RID: 85198 RVA: 0x00644446 File Offset: 0x00642846
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E61F RID: 58911
		private BE_Target method_p0;

		// Token: 0x0400E620 RID: 58912
		private int method_p1;
	}
}
