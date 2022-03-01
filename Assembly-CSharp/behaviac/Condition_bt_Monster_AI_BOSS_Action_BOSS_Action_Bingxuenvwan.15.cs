using System;

namespace behaviac
{
	// Token: 0x02002F80 RID: 12160
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node65 : Condition
	{
		// Token: 0x060147CE RID: 83918 RVA: 0x0062A443 File Offset: 0x00628843
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node65()
		{
			this.opl_p0 = 5533;
		}

		// Token: 0x060147CF RID: 83919 RVA: 0x0062A458 File Offset: 0x00628858
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E137 RID: 57655
		private int opl_p0;
	}
}
