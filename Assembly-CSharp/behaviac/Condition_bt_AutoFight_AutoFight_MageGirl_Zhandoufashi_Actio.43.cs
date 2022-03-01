using System;

namespace behaviac
{
	// Token: 0x02002739 RID: 10041
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node18 : Condition
	{
		// Token: 0x060137B4 RID: 79796 RVA: 0x005CD7B9 File Offset: 0x005CBBB9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node18()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060137B5 RID: 79797 RVA: 0x005CD7CC File Offset: 0x005CBBCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D20F RID: 53775
		private float opl_p0;
	}
}
