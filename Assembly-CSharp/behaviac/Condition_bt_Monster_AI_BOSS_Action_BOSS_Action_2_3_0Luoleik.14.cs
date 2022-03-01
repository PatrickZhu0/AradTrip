using System;

namespace behaviac
{
	// Token: 0x02002F63 RID: 12131
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node25 : Condition
	{
		// Token: 0x06014795 RID: 83861 RVA: 0x00629065 File Offset: 0x00627465
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node25()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014796 RID: 83862 RVA: 0x00629078 File Offset: 0x00627478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E105 RID: 57605
		private float opl_p0;
	}
}
