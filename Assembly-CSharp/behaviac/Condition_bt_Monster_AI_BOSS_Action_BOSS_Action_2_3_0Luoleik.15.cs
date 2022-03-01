using System;

namespace behaviac
{
	// Token: 0x02002F64 RID: 12132
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node26 : Condition
	{
		// Token: 0x06014797 RID: 83863 RVA: 0x006290AB File Offset: 0x006274AB
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node26()
		{
			this.opl_p0 = 5313;
		}

		// Token: 0x06014798 RID: 83864 RVA: 0x006290C0 File Offset: 0x006274C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E106 RID: 57606
		private int opl_p0;
	}
}
