using System;

namespace behaviac
{
	// Token: 0x020022BF RID: 8895
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node49 : Condition
	{
		// Token: 0x06012EF9 RID: 77561 RVA: 0x00596A35 File Offset: 0x00594E35
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node49()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012EFA RID: 77562 RVA: 0x00596A48 File Offset: 0x00594E48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C90B RID: 51467
		private float opl_p0;
	}
}
