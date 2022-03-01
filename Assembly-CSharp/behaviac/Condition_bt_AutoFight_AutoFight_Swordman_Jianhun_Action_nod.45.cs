using System;

namespace behaviac
{
	// Token: 0x02002940 RID: 10560
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node40 : Condition
	{
		// Token: 0x06013BB6 RID: 80822 RVA: 0x005E57C7 File Offset: 0x005E3BC7
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node40()
		{
			this.opl_p0 = 1716;
		}

		// Token: 0x06013BB7 RID: 80823 RVA: 0x005E57DC File Offset: 0x005E3BDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D61C RID: 54812
		private int opl_p0;
	}
}
