using System;

namespace behaviac
{
	// Token: 0x0200320E RID: 12814
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node42 : Condition
	{
		// Token: 0x06014CA6 RID: 85158 RVA: 0x006433A7 File Offset: 0x006417A7
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node42()
		{
			this.opl_p0 = 21561;
		}

		// Token: 0x06014CA7 RID: 85159 RVA: 0x006433BC File Offset: 0x006417BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5F1 RID: 58865
		private int opl_p0;
	}
}
