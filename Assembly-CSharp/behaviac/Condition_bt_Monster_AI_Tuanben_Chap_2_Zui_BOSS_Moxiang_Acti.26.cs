using System;

namespace behaviac
{
	// Token: 0x0200376E RID: 14190
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node40 : Condition
	{
		// Token: 0x060156E3 RID: 87779 RVA: 0x00676E6A File Offset: 0x0067526A
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node40()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060156E4 RID: 87780 RVA: 0x00676E80 File Offset: 0x00675280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0AB RID: 61611
		private float opl_p0;
	}
}
