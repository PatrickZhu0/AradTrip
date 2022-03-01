using System;

namespace behaviac
{
	// Token: 0x020037AD RID: 14253
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node19 : Condition
	{
		// Token: 0x0601575D RID: 87901 RVA: 0x00679FF7 File Offset: 0x006783F7
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node19()
		{
			this.opl_p0 = 21199;
		}

		// Token: 0x0601575E RID: 87902 RVA: 0x0067A00C File Offset: 0x0067840C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F10A RID: 61706
		private int opl_p0;
	}
}
