using System;

namespace behaviac
{
	// Token: 0x020031C9 RID: 12745
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node63 : Condition
	{
		// Token: 0x06014C25 RID: 85029 RVA: 0x00640083 File Offset: 0x0063E483
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node63()
		{
			this.opl_p0 = 21569;
		}

		// Token: 0x06014C26 RID: 85030 RVA: 0x00640098 File Offset: 0x0063E498
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E57C RID: 58748
		private int opl_p0;
	}
}
