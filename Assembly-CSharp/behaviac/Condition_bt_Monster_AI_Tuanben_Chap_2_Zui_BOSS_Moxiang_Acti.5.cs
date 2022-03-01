using System;

namespace behaviac
{
	// Token: 0x0200374F RID: 14159
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node74 : Condition
	{
		// Token: 0x060156A5 RID: 87717 RVA: 0x0067619B File Offset: 0x0067459B
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node74()
		{
			this.opl_p0 = 21192;
		}

		// Token: 0x060156A6 RID: 87718 RVA: 0x006761B0 File Offset: 0x006745B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F07E RID: 61566
		private int opl_p0;
	}
}
