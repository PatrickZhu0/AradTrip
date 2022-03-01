using System;

namespace behaviac
{
	// Token: 0x0200228D RID: 8845
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node24 : Condition
	{
		// Token: 0x06012E9A RID: 77466 RVA: 0x005941D6 File Offset: 0x005925D6
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node24()
		{
			this.opl_p0 = 0.28f;
		}

		// Token: 0x06012E9B RID: 77467 RVA: 0x005941EC File Offset: 0x005925EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8A4 RID: 51364
		private float opl_p0;
	}
}
