using System;

namespace behaviac
{
	// Token: 0x02003778 RID: 14200
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node87 : Condition
	{
		// Token: 0x060156F7 RID: 87799 RVA: 0x00677267 File Offset: 0x00675667
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node87()
		{
			this.opl_p0 = 21188;
		}

		// Token: 0x060156F8 RID: 87800 RVA: 0x0067727C File Offset: 0x0067567C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0B8 RID: 61624
		private int opl_p0;
	}
}
