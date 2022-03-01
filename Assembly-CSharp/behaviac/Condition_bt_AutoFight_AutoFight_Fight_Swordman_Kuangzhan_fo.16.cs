using System;

namespace behaviac
{
	// Token: 0x0200234C RID: 9036
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node37 : Condition
	{
		// Token: 0x06013005 RID: 77829 RVA: 0x0059E922 File Offset: 0x0059CD22
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node37()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06013006 RID: 77830 RVA: 0x0059E938 File Offset: 0x0059CD38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA1A RID: 51738
		private float opl_p0;
	}
}
