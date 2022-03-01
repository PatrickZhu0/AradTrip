using System;

namespace behaviac
{
	// Token: 0x020023D6 RID: 9174
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node1 : Condition
	{
		// Token: 0x06013111 RID: 78097 RVA: 0x005A6FC2 File Offset: 0x005A53C2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node1()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013112 RID: 78098 RVA: 0x005A6FD8 File Offset: 0x005A53D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB40 RID: 52032
		private float opl_p0;
	}
}
