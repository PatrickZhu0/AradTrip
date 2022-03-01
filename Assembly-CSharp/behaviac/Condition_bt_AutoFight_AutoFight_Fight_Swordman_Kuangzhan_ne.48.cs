using System;

namespace behaviac
{
	// Token: 0x020023D3 RID: 9171
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node10 : Condition
	{
		// Token: 0x0601310B RID: 78091 RVA: 0x005A6E87 File Offset: 0x005A5287
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node10()
		{
			this.opl_p0 = 0.02f;
		}

		// Token: 0x0601310C RID: 78092 RVA: 0x005A6E9C File Offset: 0x005A529C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB3C RID: 52028
		private float opl_p0;
	}
}
