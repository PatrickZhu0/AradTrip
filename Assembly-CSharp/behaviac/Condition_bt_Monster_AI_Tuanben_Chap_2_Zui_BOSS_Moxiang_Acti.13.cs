using System;

namespace behaviac
{
	// Token: 0x0200375B RID: 14171
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node17 : Condition
	{
		// Token: 0x060156BD RID: 87741 RVA: 0x006766A3 File Offset: 0x00674AA3
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node17()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060156BE RID: 87742 RVA: 0x006766B8 File Offset: 0x00674AB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F090 RID: 61584
		private float opl_p0;
	}
}
