using System;

namespace behaviac
{
	// Token: 0x02002FA4 RID: 12196
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node56 : Condition
	{
		// Token: 0x06014816 RID: 83990 RVA: 0x0062B26F File Offset: 0x0062966F
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node56()
		{
			this.opl_p0 = 5546;
		}

		// Token: 0x06014817 RID: 83991 RVA: 0x0062B284 File Offset: 0x00629684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E177 RID: 57719
		private int opl_p0;
	}
}
