using System;

namespace behaviac
{
	// Token: 0x0200377F RID: 14207
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node64 : Condition
	{
		// Token: 0x06015705 RID: 87813 RVA: 0x0067753F File Offset: 0x0067593F
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node64()
		{
			this.opl_p0 = 21197;
		}

		// Token: 0x06015706 RID: 87814 RVA: 0x00677554 File Offset: 0x00675954
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0C3 RID: 61635
		private int opl_p0;
	}
}
