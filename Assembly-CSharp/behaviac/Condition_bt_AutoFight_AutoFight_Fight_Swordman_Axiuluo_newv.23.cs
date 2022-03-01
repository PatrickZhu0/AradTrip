using System;

namespace behaviac
{
	// Token: 0x0200221F RID: 8735
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node55 : Condition
	{
		// Token: 0x06012DC8 RID: 77256 RVA: 0x0058E147 File Offset: 0x0058C547
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node55()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012DC9 RID: 77257 RVA: 0x0058E15C File Offset: 0x0058C55C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7C1 RID: 51137
		private float opl_p0;
	}
}
