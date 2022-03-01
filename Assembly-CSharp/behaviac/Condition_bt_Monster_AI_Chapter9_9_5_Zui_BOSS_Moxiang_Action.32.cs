using System;

namespace behaviac
{
	// Token: 0x020031C6 RID: 12742
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node59 : Condition
	{
		// Token: 0x06014C1F RID: 85023 RVA: 0x0063FF47 File Offset: 0x0063E347
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node59()
		{
			this.opl_p0 = 21571;
		}

		// Token: 0x06014C20 RID: 85024 RVA: 0x0063FF5C File Offset: 0x0063E35C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E578 RID: 58744
		private int opl_p0;
	}
}
