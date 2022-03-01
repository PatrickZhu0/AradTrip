using System;

namespace behaviac
{
	// Token: 0x0200379D RID: 14237
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node16 : Condition
	{
		// Token: 0x0601573F RID: 87871 RVA: 0x0067950F File Offset: 0x0067790F
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node16()
		{
			this.opl_p0 = 21189;
		}

		// Token: 0x06015740 RID: 87872 RVA: 0x00679524 File Offset: 0x00677924
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0EF RID: 61679
		private int opl_p0;
	}
}
