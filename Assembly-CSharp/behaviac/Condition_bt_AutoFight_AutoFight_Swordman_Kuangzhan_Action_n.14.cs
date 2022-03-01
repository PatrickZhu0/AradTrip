using System;

namespace behaviac
{
	// Token: 0x02002954 RID: 10580
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node44 : Condition
	{
		// Token: 0x06013BDD RID: 80861 RVA: 0x005E71D1 File Offset: 0x005E55D1
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node44()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013BDE RID: 80862 RVA: 0x005E71E4 File Offset: 0x005E55E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D644 RID: 54852
		private float opl_p0;
	}
}
