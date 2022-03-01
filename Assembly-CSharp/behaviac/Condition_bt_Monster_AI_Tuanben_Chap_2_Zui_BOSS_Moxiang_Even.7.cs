using System;

namespace behaviac
{
	// Token: 0x02003796 RID: 14230
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node14 : Condition
	{
		// Token: 0x06015731 RID: 87857 RVA: 0x006792C8 File Offset: 0x006776C8
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node14()
		{
			this.opl_p0 = 21189;
		}

		// Token: 0x06015732 RID: 87858 RVA: 0x006792DC File Offset: 0x006776DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0E4 RID: 61668
		private int opl_p0;
	}
}
