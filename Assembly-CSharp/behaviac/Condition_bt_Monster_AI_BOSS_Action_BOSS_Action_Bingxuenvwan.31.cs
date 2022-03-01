using System;

namespace behaviac
{
	// Token: 0x02002F94 RID: 12180
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node70 : Condition
	{
		// Token: 0x060147F6 RID: 83958 RVA: 0x0062AC33 File Offset: 0x00629033
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node70()
		{
			this.opl_p0 = 5532;
		}

		// Token: 0x060147F7 RID: 83959 RVA: 0x0062AC48 File Offset: 0x00629048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E15B RID: 57691
		private int opl_p0;
	}
}
