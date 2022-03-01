using System;

namespace behaviac
{
	// Token: 0x020022E5 RID: 8933
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node1 : Condition
	{
		// Token: 0x06012F44 RID: 77636 RVA: 0x00599D86 File Offset: 0x00598186
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node1()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06012F45 RID: 77637 RVA: 0x00599D9C File Offset: 0x0059819C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C955 RID: 51541
		private float opl_p0;
	}
}
