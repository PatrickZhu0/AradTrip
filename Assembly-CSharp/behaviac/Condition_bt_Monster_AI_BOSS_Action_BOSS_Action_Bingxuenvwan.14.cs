using System;

namespace behaviac
{
	// Token: 0x02002F7F RID: 12159
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node20 : Condition
	{
		// Token: 0x060147CC RID: 83916 RVA: 0x0062A3FD File Offset: 0x006287FD
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node20()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060147CD RID: 83917 RVA: 0x0062A410 File Offset: 0x00628810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E136 RID: 57654
		private float opl_p0;
	}
}
