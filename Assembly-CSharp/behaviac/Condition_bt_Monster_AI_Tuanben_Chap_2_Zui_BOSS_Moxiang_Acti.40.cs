using System;

namespace behaviac
{
	// Token: 0x02003782 RID: 14210
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node68 : Condition
	{
		// Token: 0x0601570B RID: 87819 RVA: 0x0067767B File Offset: 0x00675A7B
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node68()
		{
			this.opl_p0 = 21195;
		}

		// Token: 0x0601570C RID: 87820 RVA: 0x00677690 File Offset: 0x00675A90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0C7 RID: 61639
		private int opl_p0;
	}
}
