using System;

namespace behaviac
{
	// Token: 0x02002818 RID: 10264
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node57 : Condition
	{
		// Token: 0x0601396E RID: 80238 RVA: 0x005D8757 File Offset: 0x005D6B57
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node57()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601396F RID: 80239 RVA: 0x005D876C File Offset: 0x005D6B6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3CC RID: 54220
		private float opl_p0;
	}
}
