using System;

namespace behaviac
{
	// Token: 0x02003764 RID: 14180
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node50 : Condition
	{
		// Token: 0x060156CF RID: 87759 RVA: 0x00676A56 File Offset: 0x00674E56
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node50()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060156D0 RID: 87760 RVA: 0x00676A6C File Offset: 0x00674E6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F09C RID: 61596
		private float opl_p0;
	}
}
