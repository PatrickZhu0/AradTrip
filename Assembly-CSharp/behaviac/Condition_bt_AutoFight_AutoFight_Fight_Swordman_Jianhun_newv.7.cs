using System;

namespace behaviac
{
	// Token: 0x020022B7 RID: 8887
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node23 : Condition
	{
		// Token: 0x06012EE9 RID: 77545 RVA: 0x00596392 File Offset: 0x00594792
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node23()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012EEA RID: 77546 RVA: 0x005963A8 File Offset: 0x005947A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8FB RID: 51451
		private float opl_p0;
	}
}
