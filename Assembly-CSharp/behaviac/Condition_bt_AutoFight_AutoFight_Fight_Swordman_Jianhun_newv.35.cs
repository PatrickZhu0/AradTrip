using System;

namespace behaviac
{
	// Token: 0x020022DC RID: 8924
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node13 : Condition
	{
		// Token: 0x06012F33 RID: 77619 RVA: 0x005988C5 File Offset: 0x00596CC5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06012F34 RID: 77620 RVA: 0x005988D8 File Offset: 0x00596CD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C94B RID: 51531
		private float opl_p0;
	}
}
