using System;

namespace behaviac
{
	// Token: 0x0200376F RID: 14191
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node84 : Condition
	{
		// Token: 0x060156E5 RID: 87781 RVA: 0x00676EB3 File Offset: 0x006752B3
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node84()
		{
			this.opl_p0 = 21197;
		}

		// Token: 0x060156E6 RID: 87782 RVA: 0x00676EC8 File Offset: 0x006752C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0AC RID: 61612
		private int opl_p0;
	}
}
