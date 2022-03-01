using System;

namespace behaviac
{
	// Token: 0x020031BF RID: 12735
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node86 : Condition
	{
		// Token: 0x06014C11 RID: 85009 RVA: 0x0063FC6F File Offset: 0x0063E06F
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node86()
		{
			this.opl_p0 = 21570;
		}

		// Token: 0x06014C12 RID: 85010 RVA: 0x0063FC84 File Offset: 0x0063E084
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E56D RID: 58733
		private int opl_p0;
	}
}
