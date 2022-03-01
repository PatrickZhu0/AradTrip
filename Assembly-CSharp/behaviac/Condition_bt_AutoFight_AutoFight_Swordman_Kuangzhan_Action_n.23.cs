using System;

namespace behaviac
{
	// Token: 0x02002961 RID: 10593
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node104 : Condition
	{
		// Token: 0x06013BF7 RID: 80887 RVA: 0x005E77CF File Offset: 0x005E5BCF
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node104()
		{
			this.opl_p0 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p1 = 3;
		}

		// Token: 0x06013BF8 RID: 80888 RVA: 0x005E77E8 File Offset: 0x005E5BE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckLastResult(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D65D RID: 54877
		private BE_Operation opl_p0;

		// Token: 0x0400D65E RID: 54878
		private int opl_p1;
	}
}
