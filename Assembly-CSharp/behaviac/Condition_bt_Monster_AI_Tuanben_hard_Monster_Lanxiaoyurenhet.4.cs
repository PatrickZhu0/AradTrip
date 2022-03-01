using System;

namespace behaviac
{
	// Token: 0x02003D2A RID: 15658
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node12 : Condition
	{
		// Token: 0x060161EE RID: 90606 RVA: 0x006AFE3F File Offset: 0x006AE23F
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node12()
		{
			this.opl_p0 = 21300;
		}

		// Token: 0x060161EF RID: 90607 RVA: 0x006AFE54 File Offset: 0x006AE254
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA66 RID: 64102
		private int opl_p0;
	}
}
