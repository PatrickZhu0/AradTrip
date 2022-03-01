using System;

namespace behaviac
{
	// Token: 0x02002F81 RID: 12161
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node21 : Condition
	{
		// Token: 0x060147D0 RID: 83920 RVA: 0x0062A48B File Offset: 0x0062888B
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node21()
		{
			this.opl_p0 = 5533;
		}

		// Token: 0x060147D1 RID: 83921 RVA: 0x0062A4A0 File Offset: 0x006288A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E138 RID: 57656
		private int opl_p0;
	}
}
