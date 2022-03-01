using System;

namespace behaviac
{
	// Token: 0x0200376B RID: 14187
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node36 : Condition
	{
		// Token: 0x060156DD RID: 87773 RVA: 0x00676D2F File Offset: 0x0067512F
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node36()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060156DE RID: 87774 RVA: 0x00676D44 File Offset: 0x00675144
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0A7 RID: 61607
		private float opl_p0;
	}
}
