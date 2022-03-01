using System;

namespace behaviac
{
	// Token: 0x02002421 RID: 9249
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node33 : Condition
	{
		// Token: 0x0601319B RID: 78235 RVA: 0x005AA070 File Offset: 0x005A8470
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node33()
		{
			this.opl_p0 = 0.71f;
		}

		// Token: 0x0601319C RID: 78236 RVA: 0x005AA084 File Offset: 0x005A8484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBC5 RID: 52165
		private float opl_p0;
	}
}
