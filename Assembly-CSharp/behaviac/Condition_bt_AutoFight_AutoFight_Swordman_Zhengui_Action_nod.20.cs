using System;

namespace behaviac
{
	// Token: 0x02002996 RID: 10646
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node26 : Condition
	{
		// Token: 0x06013C60 RID: 80992 RVA: 0x005EA299 File Offset: 0x005E8699
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node26()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013C61 RID: 80993 RVA: 0x005EA2AC File Offset: 0x005E86AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6CC RID: 54988
		private float opl_p0;
	}
}
