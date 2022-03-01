using System;

namespace behaviac
{
	// Token: 0x02003219 RID: 12825
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node7 : Condition
	{
		// Token: 0x06014CBB RID: 85179 RVA: 0x006440CB File Offset: 0x006424CB
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node7()
		{
			this.opl_p0 = 21563;
		}

		// Token: 0x06014CBC RID: 85180 RVA: 0x006440E0 File Offset: 0x006424E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E602 RID: 58882
		private int opl_p0;
	}
}
