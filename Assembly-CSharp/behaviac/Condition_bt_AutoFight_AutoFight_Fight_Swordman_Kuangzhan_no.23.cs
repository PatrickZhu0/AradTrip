using System;

namespace behaviac
{
	// Token: 0x020023FD RID: 9213
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node48 : Condition
	{
		// Token: 0x06013159 RID: 78169 RVA: 0x005A8302 File Offset: 0x005A6702
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node48()
		{
			this.opl_p0 = 0.56f;
		}

		// Token: 0x0601315A RID: 78170 RVA: 0x005A8318 File Offset: 0x005A6718
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB83 RID: 52099
		private float opl_p0;
	}
}
