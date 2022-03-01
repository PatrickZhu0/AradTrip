using System;

namespace behaviac
{
	// Token: 0x02003752 RID: 14162
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node75 : Condition
	{
		// Token: 0x060156AB RID: 87723 RVA: 0x006762D7 File Offset: 0x006746D7
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node75()
		{
			this.opl_p0 = 21191;
		}

		// Token: 0x060156AC RID: 87724 RVA: 0x006762EC File Offset: 0x006746EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F082 RID: 61570
		private int opl_p0;
	}
}
