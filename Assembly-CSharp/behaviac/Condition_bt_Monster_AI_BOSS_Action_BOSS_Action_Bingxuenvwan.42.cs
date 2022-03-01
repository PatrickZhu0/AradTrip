using System;

namespace behaviac
{
	// Token: 0x02002FA2 RID: 12194
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node55 : Condition
	{
		// Token: 0x06014812 RID: 83986 RVA: 0x0062B1E1 File Offset: 0x006295E1
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node55()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014813 RID: 83987 RVA: 0x0062B1F4 File Offset: 0x006295F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E175 RID: 57717
		private float opl_p0;
	}
}
