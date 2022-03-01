using System;

namespace behaviac
{
	// Token: 0x02003767 RID: 14183
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node80 : Condition
	{
		// Token: 0x060156D5 RID: 87765 RVA: 0x00676B92 File Offset: 0x00674F92
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node80()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060156D6 RID: 87766 RVA: 0x00676BA8 File Offset: 0x00674FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0A0 RID: 61600
		private float opl_p0;
	}
}
