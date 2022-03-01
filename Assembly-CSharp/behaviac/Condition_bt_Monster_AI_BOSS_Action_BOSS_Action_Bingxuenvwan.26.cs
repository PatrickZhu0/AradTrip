using System;

namespace behaviac
{
	// Token: 0x02002F8E RID: 12174
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node35 : Condition
	{
		// Token: 0x060147EA RID: 83946 RVA: 0x0062A9F1 File Offset: 0x00628DF1
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node35()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060147EB RID: 83947 RVA: 0x0062AA04 File Offset: 0x00628E04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E151 RID: 57681
		private float opl_p0;
	}
}
