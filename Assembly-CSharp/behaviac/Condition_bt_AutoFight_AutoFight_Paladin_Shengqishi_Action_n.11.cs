using System;

namespace behaviac
{
	// Token: 0x02002820 RID: 10272
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node67 : Condition
	{
		// Token: 0x0601397E RID: 80254 RVA: 0x005D8A8F File Offset: 0x005D6E8F
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node67()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601397F RID: 80255 RVA: 0x005D8AA4 File Offset: 0x005D6EA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3DA RID: 54234
		private float opl_p0;
	}
}
