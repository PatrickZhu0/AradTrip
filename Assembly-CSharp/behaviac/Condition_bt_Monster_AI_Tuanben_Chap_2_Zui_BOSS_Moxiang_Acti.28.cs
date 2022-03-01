using System;

namespace behaviac
{
	// Token: 0x02003771 RID: 14193
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node44 : Condition
	{
		// Token: 0x060156E9 RID: 87785 RVA: 0x00676FA6 File Offset: 0x006753A6
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node44()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x060156EA RID: 87786 RVA: 0x00676FBC File Offset: 0x006753BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0AF RID: 61615
		private float opl_p0;
	}
}
