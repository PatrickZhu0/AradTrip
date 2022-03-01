using System;

namespace behaviac
{
	// Token: 0x0200374E RID: 14158
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node10 : Condition
	{
		// Token: 0x060156A3 RID: 87715 RVA: 0x00676152 File Offset: 0x00674552
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node10()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060156A4 RID: 87716 RVA: 0x00676168 File Offset: 0x00674568
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F07D RID: 61565
		private float opl_p0;
	}
}
