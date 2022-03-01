using System;

namespace behaviac
{
	// Token: 0x02002943 RID: 10563
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node6 : Condition
	{
		// Token: 0x06013BBB RID: 80827 RVA: 0x005E6A8C File Offset: 0x005E4E8C
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x06013BBC RID: 80828 RVA: 0x005E6AB0 File Offset: 0x005E4EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D61F RID: 54815
		private BE_Target opl_p0;

		// Token: 0x0400D620 RID: 54816
		private BE_Equal opl_p1;

		// Token: 0x0400D621 RID: 54817
		private int opl_p2;
	}
}
