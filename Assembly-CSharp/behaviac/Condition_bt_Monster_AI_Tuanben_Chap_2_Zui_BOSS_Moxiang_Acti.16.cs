using System;

namespace behaviac
{
	// Token: 0x0200375F RID: 14175
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node22 : Condition
	{
		// Token: 0x060156C5 RID: 87749 RVA: 0x00676827 File Offset: 0x00674C27
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node22()
		{
			this.opl_p0 = 21192;
		}

		// Token: 0x060156C6 RID: 87750 RVA: 0x0067683C File Offset: 0x00674C3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F095 RID: 61589
		private int opl_p0;
	}
}
