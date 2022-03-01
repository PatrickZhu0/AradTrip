using System;

namespace behaviac
{
	// Token: 0x02003788 RID: 14216
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node91 : Condition
	{
		// Token: 0x06015717 RID: 87831 RVA: 0x006778F3 File Offset: 0x00675CF3
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node91()
		{
			this.opl_p0 = 21188;
		}

		// Token: 0x06015718 RID: 87832 RVA: 0x00677908 File Offset: 0x00675D08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0CF RID: 61647
		private int opl_p0;
	}
}
