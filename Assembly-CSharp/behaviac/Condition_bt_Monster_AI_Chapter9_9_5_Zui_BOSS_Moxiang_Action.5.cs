using System;

namespace behaviac
{
	// Token: 0x0200319F RID: 12703
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node74 : Condition
	{
		// Token: 0x06014BD1 RID: 84945 RVA: 0x0063EF57 File Offset: 0x0063D357
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node74()
		{
			this.opl_p0 = 21549;
		}

		// Token: 0x06014BD2 RID: 84946 RVA: 0x0063EF6C File Offset: 0x0063D36C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E53F RID: 58687
		private int opl_p0;
	}
}
