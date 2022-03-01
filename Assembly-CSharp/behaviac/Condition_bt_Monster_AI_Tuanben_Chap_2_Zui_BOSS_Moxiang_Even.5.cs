using System;

namespace behaviac
{
	// Token: 0x02003793 RID: 14227
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node21 : Condition
	{
		// Token: 0x0601572B RID: 87851 RVA: 0x0067919A File Offset: 0x0067759A
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node21()
		{
			this.opl_p0 = 21189;
		}

		// Token: 0x0601572C RID: 87852 RVA: 0x006791B0 File Offset: 0x006775B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0E1 RID: 61665
		private int opl_p0;
	}
}
