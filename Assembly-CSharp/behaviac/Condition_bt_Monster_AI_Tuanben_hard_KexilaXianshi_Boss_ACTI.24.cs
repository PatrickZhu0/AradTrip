using System;

namespace behaviac
{
	// Token: 0x02003C86 RID: 15494
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node45 : Condition
	{
		// Token: 0x060160B3 RID: 90291 RVA: 0x006A945D File Offset: 0x006A785D
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node45()
		{
			this.opl_p0 = 21060;
		}

		// Token: 0x060160B4 RID: 90292 RVA: 0x006A9470 File Offset: 0x006A7870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F94A RID: 63818
		private int opl_p0;
	}
}
