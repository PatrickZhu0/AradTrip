using System;

namespace behaviac
{
	// Token: 0x02002F70 RID: 12144
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node4 : Condition
	{
		// Token: 0x060147AE RID: 83886 RVA: 0x00629E1F File Offset: 0x0062821F
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node4()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060147AF RID: 83887 RVA: 0x00629E34 File Offset: 0x00628234
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E11C RID: 57628
		private float opl_p0;
	}
}
