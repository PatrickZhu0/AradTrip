using System;

namespace behaviac
{
	// Token: 0x02002F4F RID: 12111
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node21 : Condition
	{
		// Token: 0x0601476E RID: 83822 RVA: 0x006282DB File Offset: 0x006266DB
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node21()
		{
			this.opl_p0 = 5451;
		}

		// Token: 0x0601476F RID: 83823 RVA: 0x006282F0 File Offset: 0x006266F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0DE RID: 57566
		private int opl_p0;
	}
}
