using System;

namespace behaviac
{
	// Token: 0x02002F7B RID: 12155
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node64 : Condition
	{
		// Token: 0x060147C4 RID: 83908 RVA: 0x0062A247 File Offset: 0x00628647
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node64()
		{
			this.opl_p0 = 5544;
		}

		// Token: 0x060147C5 RID: 83909 RVA: 0x0062A25C File Offset: 0x0062865C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E12E RID: 57646
		private int opl_p0;
	}
}
