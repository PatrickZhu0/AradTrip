using System;

namespace behaviac
{
	// Token: 0x02002F4B RID: 12107
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node16 : Condition
	{
		// Token: 0x06014766 RID: 83814 RVA: 0x00628127 File Offset: 0x00626527
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node16()
		{
			this.opl_p0 = 5004;
		}

		// Token: 0x06014767 RID: 83815 RVA: 0x0062813C File Offset: 0x0062653C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0D6 RID: 57558
		private int opl_p0;
	}
}
