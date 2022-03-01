using System;

namespace behaviac
{
	// Token: 0x02002F7A RID: 12154
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node15 : Condition
	{
		// Token: 0x060147C2 RID: 83906 RVA: 0x0062A1FF File Offset: 0x006285FF
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node15()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060147C3 RID: 83907 RVA: 0x0062A214 File Offset: 0x00628614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E12D RID: 57645
		private float opl_p0;
	}
}
