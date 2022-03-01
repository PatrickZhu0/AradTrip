using System;

namespace behaviac
{
	// Token: 0x02002F77 RID: 12151
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node9 : Condition
	{
		// Token: 0x060147BC RID: 83900 RVA: 0x0062A0AB File Offset: 0x006284AB
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node9()
		{
			this.opl_p0 = 5549;
		}

		// Token: 0x060147BD RID: 83901 RVA: 0x0062A0C0 File Offset: 0x006284C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E127 RID: 57639
		private int opl_p0;
	}
}
