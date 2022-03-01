using System;

namespace behaviac
{
	// Token: 0x02002F7C RID: 12156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node16 : Condition
	{
		// Token: 0x060147C6 RID: 83910 RVA: 0x0062A28F File Offset: 0x0062868F
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node16()
		{
			this.opl_p0 = 5544;
		}

		// Token: 0x060147C7 RID: 83911 RVA: 0x0062A2A4 File Offset: 0x006286A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E12F RID: 57647
		private int opl_p0;
	}
}
