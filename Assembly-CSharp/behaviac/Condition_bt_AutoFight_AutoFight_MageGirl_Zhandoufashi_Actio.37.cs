using System;

namespace behaviac
{
	// Token: 0x02002731 RID: 10033
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node39 : Condition
	{
		// Token: 0x060137A4 RID: 79780 RVA: 0x005CD451 File Offset: 0x005CB851
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node39()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060137A5 RID: 79781 RVA: 0x005CD464 File Offset: 0x005CB864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1FF RID: 53759
		private float opl_p0;
	}
}
