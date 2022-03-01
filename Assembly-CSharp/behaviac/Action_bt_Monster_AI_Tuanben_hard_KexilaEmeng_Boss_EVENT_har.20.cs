using System;

namespace behaviac
{
	// Token: 0x02003BE7 RID: 15335
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node81 : Action
	{
		// Token: 0x06015F7B RID: 89979 RVA: 0x006A3025 File Offset: 0x006A1425
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node81()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06015F7C RID: 89980 RVA: 0x006A303B File Offset: 0x006A143B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F818 RID: 63512
		private int method_p0;
	}
}
