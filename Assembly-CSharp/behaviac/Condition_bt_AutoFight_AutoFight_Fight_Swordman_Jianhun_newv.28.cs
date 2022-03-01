using System;

namespace behaviac
{
	// Token: 0x020022D3 RID: 8915
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node48 : Condition
	{
		// Token: 0x06012F21 RID: 77601 RVA: 0x0059825E File Offset: 0x0059665E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node48()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06012F22 RID: 77602 RVA: 0x00598274 File Offset: 0x00596674
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C937 RID: 51511
		private float opl_p0;
	}
}
