using System;

namespace behaviac
{
	// Token: 0x0200375E RID: 14174
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node21 : Condition
	{
		// Token: 0x060156C3 RID: 87747 RVA: 0x006767DE File Offset: 0x00674BDE
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node21()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060156C4 RID: 87748 RVA: 0x006767F4 File Offset: 0x00674BF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F094 RID: 61588
		private float opl_p0;
	}
}
