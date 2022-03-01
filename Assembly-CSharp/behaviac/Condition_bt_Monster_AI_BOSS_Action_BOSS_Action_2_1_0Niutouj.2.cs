using System;

namespace behaviac
{
	// Token: 0x02002F42 RID: 12098
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node5 : Condition
	{
		// Token: 0x06014754 RID: 83796 RVA: 0x00627D79 File Offset: 0x00626179
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node5()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06014755 RID: 83797 RVA: 0x00627D8C File Offset: 0x0062618C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0C5 RID: 57541
		private float opl_p0;
	}
}
