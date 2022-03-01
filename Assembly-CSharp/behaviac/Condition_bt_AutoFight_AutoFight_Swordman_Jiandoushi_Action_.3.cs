using System;

namespace behaviac
{
	// Token: 0x020028E6 RID: 10470
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node63 : Condition
	{
		// Token: 0x06013B03 RID: 80643 RVA: 0x005E207D File Offset: 0x005E047D
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node63()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 230001;
		}

		// Token: 0x06013B04 RID: 80644 RVA: 0x005E20A0 File Offset: 0x005E04A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D565 RID: 54629
		private BE_Target opl_p0;

		// Token: 0x0400D566 RID: 54630
		private BE_Equal opl_p1;

		// Token: 0x0400D567 RID: 54631
		private int opl_p2;
	}
}
