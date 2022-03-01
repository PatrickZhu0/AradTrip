using System;

namespace behaviac
{
	// Token: 0x020023E7 RID: 9191
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node19 : Condition
	{
		// Token: 0x0601312F RID: 78127 RVA: 0x005A79C4 File Offset: 0x005A5DC4
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node19()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x06013130 RID: 78128 RVA: 0x005A79D8 File Offset: 0x005A5DD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB5C RID: 52060
		private float opl_p0;
	}
}
