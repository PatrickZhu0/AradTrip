using System;

namespace behaviac
{
	// Token: 0x02003685 RID: 13957
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node2 : Action
	{
		// Token: 0x06015529 RID: 87337 RVA: 0x0066E847 File Offset: 0x0066CC47
		public Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 34;
			this.method_p2 = 5000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601552A RID: 87338 RVA: 0x0066E87E File Offset: 0x0066CC7E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEE5 RID: 61157
		private BE_Target method_p0;

		// Token: 0x0400EEE6 RID: 61158
		private int method_p1;

		// Token: 0x0400EEE7 RID: 61159
		private int method_p2;

		// Token: 0x0400EEE8 RID: 61160
		private int method_p3;

		// Token: 0x0400EEE9 RID: 61161
		private int method_p4;
	}
}
