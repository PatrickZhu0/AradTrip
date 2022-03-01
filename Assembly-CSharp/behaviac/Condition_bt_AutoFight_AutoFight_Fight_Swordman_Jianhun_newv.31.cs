using System;

namespace behaviac
{
	// Token: 0x020022D7 RID: 8919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node18 : Condition
	{
		// Token: 0x06012F29 RID: 77609 RVA: 0x00598526 File Offset: 0x00596926
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node18()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06012F2A RID: 77610 RVA: 0x0059853C File Offset: 0x0059693C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C93F RID: 51519
		private float opl_p0;
	}
}
