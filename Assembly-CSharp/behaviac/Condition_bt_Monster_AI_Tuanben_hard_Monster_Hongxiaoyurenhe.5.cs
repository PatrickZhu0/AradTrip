using System;

namespace behaviac
{
	// Token: 0x02003D1A RID: 15642
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node3 : Condition
	{
		// Token: 0x060161D0 RID: 90576 RVA: 0x006AF526 File Offset: 0x006AD926
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node3()
		{
			this.opl_p0 = 21021;
		}

		// Token: 0x060161D1 RID: 90577 RVA: 0x006AF53C File Offset: 0x006AD93C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA54 RID: 64084
		private int opl_p0;
	}
}
