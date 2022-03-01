using System;

namespace behaviac
{
	// Token: 0x0200246B RID: 9323
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node63 : Condition
	{
		// Token: 0x06013226 RID: 78374 RVA: 0x005AD692 File Offset: 0x005ABA92
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node63()
		{
			this.opl_p0 = 0.78f;
		}

		// Token: 0x06013227 RID: 78375 RVA: 0x005AD6A8 File Offset: 0x005ABAA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC4A RID: 52298
		private float opl_p0;
	}
}
