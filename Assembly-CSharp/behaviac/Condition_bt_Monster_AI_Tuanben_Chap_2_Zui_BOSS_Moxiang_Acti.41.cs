using System;

namespace behaviac
{
	// Token: 0x02003784 RID: 14212
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node71 : Condition
	{
		// Token: 0x0601570F RID: 87823 RVA: 0x0067776E File Offset: 0x00675B6E
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node71()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015710 RID: 87824 RVA: 0x00677784 File Offset: 0x00675B84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0CA RID: 61642
		private float opl_p0;
	}
}
