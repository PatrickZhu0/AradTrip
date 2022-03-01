using System;

namespace behaviac
{
	// Token: 0x02002824 RID: 10276
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node52 : Condition
	{
		// Token: 0x06013986 RID: 80262 RVA: 0x005D8C2B File Offset: 0x005D702B
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node52()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013987 RID: 80263 RVA: 0x005D8C40 File Offset: 0x005D7040
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3E1 RID: 54241
		private float opl_p0;
	}
}
