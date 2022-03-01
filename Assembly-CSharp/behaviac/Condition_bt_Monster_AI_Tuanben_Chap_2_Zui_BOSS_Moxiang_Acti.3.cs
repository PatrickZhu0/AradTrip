using System;

namespace behaviac
{
	// Token: 0x0200374C RID: 14156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node73 : Condition
	{
		// Token: 0x0601569F RID: 87711 RVA: 0x0067605F File Offset: 0x0067445F
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node73()
		{
			this.opl_p0 = 21188;
		}

		// Token: 0x060156A0 RID: 87712 RVA: 0x00676074 File Offset: 0x00674474
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F07A RID: 61562
		private int opl_p0;
	}
}
