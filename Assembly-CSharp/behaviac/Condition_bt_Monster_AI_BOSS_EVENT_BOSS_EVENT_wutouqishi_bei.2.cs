using System;

namespace behaviac
{
	// Token: 0x020030C6 RID: 12486
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node4 : Condition
	{
		// Token: 0x06014A47 RID: 84551 RVA: 0x00637443 File Offset: 0x00635843
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node4()
		{
			this.opl_p0 = 5636;
		}

		// Token: 0x06014A48 RID: 84552 RVA: 0x00637458 File Offset: 0x00635858
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3B2 RID: 58290
		private int opl_p0;
	}
}
