using System;

namespace behaviac
{
	// Token: 0x02003797 RID: 14231
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node19 : Condition
	{
		// Token: 0x06015733 RID: 87859 RVA: 0x0067930F File Offset: 0x0067770F
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node19()
		{
			this.opl_p0 = 21199;
		}

		// Token: 0x06015734 RID: 87860 RVA: 0x00679324 File Offset: 0x00677724
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0E5 RID: 61669
		private int opl_p0;
	}
}
