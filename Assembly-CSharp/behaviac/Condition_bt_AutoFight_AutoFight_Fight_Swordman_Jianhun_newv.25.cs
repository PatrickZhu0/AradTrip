using System;

namespace behaviac
{
	// Token: 0x020022CF RID: 8911
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node44 : Condition
	{
		// Token: 0x06012F19 RID: 77593 RVA: 0x00598001 File Offset: 0x00596401
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node44()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06012F1A RID: 77594 RVA: 0x00598014 File Offset: 0x00596414
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C92B RID: 51499
		private float opl_p0;
	}
}
