using System;

namespace behaviac
{
	// Token: 0x02002285 RID: 8837
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node13 : Condition
	{
		// Token: 0x06012E8B RID: 77451 RVA: 0x00593E7C File Offset: 0x0059227C
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node13()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012E8C RID: 77452 RVA: 0x00593E90 File Offset: 0x00592290
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C898 RID: 51352
		private float opl_p0;
	}
}
