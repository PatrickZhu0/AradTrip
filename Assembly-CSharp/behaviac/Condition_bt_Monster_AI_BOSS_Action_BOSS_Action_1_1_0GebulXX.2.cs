using System;

namespace behaviac
{
	// Token: 0x02002F35 RID: 12085
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node6 : Condition
	{
		// Token: 0x0601473B RID: 83771 RVA: 0x0062743D File Offset: 0x0062583D
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node6()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601473C RID: 83772 RVA: 0x00627450 File Offset: 0x00625850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0AD RID: 57517
		private float opl_p0;
	}
}
