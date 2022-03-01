using System;

namespace behaviac
{
	// Token: 0x020030C7 RID: 12487
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node5 : Condition
	{
		// Token: 0x06014A49 RID: 84553 RVA: 0x0063748B File Offset: 0x0063588B
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014A4A RID: 84554 RVA: 0x006374A0 File Offset: 0x006358A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3B3 RID: 58291
		private float opl_p0;
	}
}
