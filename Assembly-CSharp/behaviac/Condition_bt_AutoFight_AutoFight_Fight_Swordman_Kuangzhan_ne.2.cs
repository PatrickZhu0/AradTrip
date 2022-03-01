using System;

namespace behaviac
{
	// Token: 0x02002394 RID: 9108
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node5 : Condition
	{
		// Token: 0x0601308E RID: 77966 RVA: 0x005A24E7 File Offset: 0x005A08E7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601308F RID: 77967 RVA: 0x005A24FC File Offset: 0x005A08FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAA6 RID: 51878
		private float opl_p0;
	}
}
