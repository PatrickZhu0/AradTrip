using System;

namespace behaviac
{
	// Token: 0x020022BC RID: 8892
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node4 : Condition
	{
		// Token: 0x06012EF3 RID: 77555 RVA: 0x005965C1 File Offset: 0x005949C1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node4()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012EF4 RID: 77556 RVA: 0x005965D4 File Offset: 0x005949D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C907 RID: 51463
		private float opl_p0;
	}
}
