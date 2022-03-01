using System;

namespace behaviac
{
	// Token: 0x02002F57 RID: 12119
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node10 : Condition
	{
		// Token: 0x0601477D RID: 83837 RVA: 0x00628B49 File Offset: 0x00626F49
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node10()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601477E RID: 83838 RVA: 0x00628B5C File Offset: 0x00626F5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0ED RID: 57581
		private float opl_p0;
	}
}
