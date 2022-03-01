using System;

namespace behaviac
{
	// Token: 0x020037B3 RID: 14259
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node16 : Condition
	{
		// Token: 0x06015769 RID: 87913 RVA: 0x0067A1F7 File Offset: 0x006785F7
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node16()
		{
			this.opl_p0 = 21189;
		}

		// Token: 0x0601576A RID: 87914 RVA: 0x0067A20C File Offset: 0x0067860C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F114 RID: 61716
		private int opl_p0;
	}
}
