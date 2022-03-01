using System;

namespace behaviac
{
	// Token: 0x020026B2 RID: 9906
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node98 : Condition
	{
		// Token: 0x060136A7 RID: 79527 RVA: 0x005C8703 File Offset: 0x005C6B03
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node98()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 211301;
		}

		// Token: 0x060136A8 RID: 79528 RVA: 0x005C8724 File Offset: 0x005C6B24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0FB RID: 53499
		private BE_Target opl_p0;

		// Token: 0x0400D0FC RID: 53500
		private BE_Equal opl_p1;

		// Token: 0x0400D0FD RID: 53501
		private int opl_p2;
	}
}
