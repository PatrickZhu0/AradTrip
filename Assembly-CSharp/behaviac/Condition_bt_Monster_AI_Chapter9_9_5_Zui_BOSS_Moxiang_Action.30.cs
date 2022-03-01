using System;

namespace behaviac
{
	// Token: 0x020031C3 RID: 12739
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node53 : Condition
	{
		// Token: 0x06014C19 RID: 85017 RVA: 0x0063FE0B File Offset: 0x0063E20B
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node53()
		{
			this.opl_p0 = 21572;
		}

		// Token: 0x06014C1A RID: 85018 RVA: 0x0063FE20 File Offset: 0x0063E220
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E574 RID: 58740
		private int opl_p0;
	}
}
