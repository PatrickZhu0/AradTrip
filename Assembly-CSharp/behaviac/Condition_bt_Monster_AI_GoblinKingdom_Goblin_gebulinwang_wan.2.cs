using System;

namespace behaviac
{
	// Token: 0x0200332D RID: 13101
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4 : Condition
	{
		// Token: 0x06014EBF RID: 85695 RVA: 0x0064DD1D File Offset: 0x0064C11D
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014EC0 RID: 85696 RVA: 0x0064DD30 File Offset: 0x0064C130
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7A6 RID: 59302
		private float opl_p0;
	}
}
