using System;

namespace behaviac
{
	// Token: 0x0200377C RID: 14204
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node60 : Condition
	{
		// Token: 0x060156FF RID: 87807 RVA: 0x00677403 File Offset: 0x00675803
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node60()
		{
			this.opl_p0 = 21198;
		}

		// Token: 0x06015700 RID: 87808 RVA: 0x00677418 File Offset: 0x00675818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0BF RID: 61631
		private int opl_p0;
	}
}
