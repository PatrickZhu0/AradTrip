using System;

namespace behaviac
{
	// Token: 0x02002975 RID: 10613
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node85 : Condition
	{
		// Token: 0x06013C1F RID: 80927 RVA: 0x005E8076 File Offset: 0x005E6476
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node85()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013C20 RID: 80928 RVA: 0x005E808C File Offset: 0x005E648C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D684 RID: 54916
		private float opl_p0;
	}
}
