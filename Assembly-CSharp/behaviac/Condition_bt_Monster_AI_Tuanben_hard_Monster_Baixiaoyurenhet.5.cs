using System;

namespace behaviac
{
	// Token: 0x02003D08 RID: 15624
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node3 : Condition
	{
		// Token: 0x060161AE RID: 90542 RVA: 0x006AEB1A File Offset: 0x006ACF1A
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node3()
		{
			this.opl_p0 = 21021;
		}

		// Token: 0x060161AF RID: 90543 RVA: 0x006AEB30 File Offset: 0x006ACF30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA3F RID: 64063
		private int opl_p0;
	}
}
