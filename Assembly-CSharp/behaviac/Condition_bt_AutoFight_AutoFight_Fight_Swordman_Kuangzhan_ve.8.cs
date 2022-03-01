using System;

namespace behaviac
{
	// Token: 0x02002417 RID: 9239
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node19 : Condition
	{
		// Token: 0x06013189 RID: 78217 RVA: 0x005A9C90 File Offset: 0x005A8090
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node19()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x0601318A RID: 78218 RVA: 0x005A9CA4 File Offset: 0x005A80A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBB5 RID: 52149
		private float opl_p0;
	}
}
