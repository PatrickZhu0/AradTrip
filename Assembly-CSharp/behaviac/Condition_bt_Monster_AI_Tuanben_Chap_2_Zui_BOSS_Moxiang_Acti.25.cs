using System;

namespace behaviac
{
	// Token: 0x0200376C RID: 14188
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node83 : Condition
	{
		// Token: 0x060156DF RID: 87775 RVA: 0x00676D77 File Offset: 0x00675177
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node83()
		{
			this.opl_p0 = 21198;
		}

		// Token: 0x060156E0 RID: 87776 RVA: 0x00676D8C File Offset: 0x0067518C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0A8 RID: 61608
		private int opl_p0;
	}
}
