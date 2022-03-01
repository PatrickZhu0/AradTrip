using System;

namespace behaviac
{
	// Token: 0x020022AF RID: 8879
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node52 : Condition
	{
		// Token: 0x06012ED9 RID: 77529 RVA: 0x00595F8D File Offset: 0x0059438D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node52()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012EDA RID: 77530 RVA: 0x00595FA0 File Offset: 0x005943A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8E3 RID: 51427
		private float opl_p0;
	}
}
