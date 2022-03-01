using System;

namespace behaviac
{
	// Token: 0x0200383D RID: 14397
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node50 : Condition
	{
		// Token: 0x06015860 RID: 88160 RVA: 0x0067EE73 File Offset: 0x0067D273
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node50()
		{
			this.opl_p0 = 21212;
		}

		// Token: 0x06015861 RID: 88161 RVA: 0x0067EE88 File Offset: 0x0067D288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F225 RID: 61989
		private int opl_p0;
	}
}
