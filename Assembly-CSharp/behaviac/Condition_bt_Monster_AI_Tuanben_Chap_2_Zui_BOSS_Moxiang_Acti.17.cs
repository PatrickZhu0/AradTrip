using System;

namespace behaviac
{
	// Token: 0x02003761 RID: 14177
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node34 : Condition
	{
		// Token: 0x060156C9 RID: 87753 RVA: 0x0067691A File Offset: 0x00674D1A
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node34()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x060156CA RID: 87754 RVA: 0x00676930 File Offset: 0x00674D30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F098 RID: 61592
		private float opl_p0;
	}
}
