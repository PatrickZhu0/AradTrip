using System;

namespace behaviac
{
	// Token: 0x02002399 RID: 9113
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node97 : Condition
	{
		// Token: 0x06013098 RID: 77976 RVA: 0x005A27B5 File Offset: 0x005A0BB5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node97()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013099 RID: 77977 RVA: 0x005A27C8 File Offset: 0x005A0BC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CABA RID: 51898
		private float opl_p0;
	}
}
