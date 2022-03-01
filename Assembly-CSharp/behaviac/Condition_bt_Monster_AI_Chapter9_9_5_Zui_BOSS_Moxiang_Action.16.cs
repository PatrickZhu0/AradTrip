using System;

namespace behaviac
{
	// Token: 0x020031AF RID: 12719
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node32 : Condition
	{
		// Token: 0x06014BF1 RID: 84977 RVA: 0x0063F5E3 File Offset: 0x0063D9E3
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node32()
		{
			this.opl_p0 = 21548;
		}

		// Token: 0x06014BF2 RID: 84978 RVA: 0x0063F5F8 File Offset: 0x0063D9F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E556 RID: 58710
		private int opl_p0;
	}
}
