using System;

namespace behaviac
{
	// Token: 0x0200319C RID: 12700
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node73 : Condition
	{
		// Token: 0x06014BCB RID: 84939 RVA: 0x0063EE1B File Offset: 0x0063D21B
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node73()
		{
			this.opl_p0 = 21547;
		}

		// Token: 0x06014BCC RID: 84940 RVA: 0x0063EE30 File Offset: 0x0063D230
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E53B RID: 58683
		private int opl_p0;
	}
}
