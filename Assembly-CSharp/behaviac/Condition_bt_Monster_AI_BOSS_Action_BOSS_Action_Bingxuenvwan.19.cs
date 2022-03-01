using System;

namespace behaviac
{
	// Token: 0x02002F85 RID: 12165
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node66 : Condition
	{
		// Token: 0x060147D8 RID: 83928 RVA: 0x0062A63F File Offset: 0x00628A3F
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node66()
		{
			this.opl_p0 = 5534;
		}

		// Token: 0x060147D9 RID: 83929 RVA: 0x0062A654 File Offset: 0x00628A54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E140 RID: 57664
		private int opl_p0;
	}
}
