using System;

namespace behaviac
{
	// Token: 0x02002F89 RID: 12169
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node30 : Condition
	{
		// Token: 0x060147E0 RID: 83936 RVA: 0x0062A7F5 File Offset: 0x00628BF5
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node30()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060147E1 RID: 83937 RVA: 0x0062A808 File Offset: 0x00628C08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E148 RID: 57672
		private float opl_p0;
	}
}
