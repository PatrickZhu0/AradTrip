using System;

namespace behaviac
{
	// Token: 0x0200377B RID: 14203
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node59 : Condition
	{
		// Token: 0x060156FD RID: 87805 RVA: 0x006773BB File Offset: 0x006757BB
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node59()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060156FE RID: 87806 RVA: 0x006773D0 File Offset: 0x006757D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0BE RID: 61630
		private float opl_p0;
	}
}
