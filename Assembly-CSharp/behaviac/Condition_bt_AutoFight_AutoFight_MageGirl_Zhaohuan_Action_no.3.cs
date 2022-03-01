using System;

namespace behaviac
{
	// Token: 0x0200274A RID: 10058
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node98 : Condition
	{
		// Token: 0x060137D5 RID: 79829 RVA: 0x005CF323 File Offset: 0x005CD723
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node98()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 211301;
		}

		// Token: 0x060137D6 RID: 79830 RVA: 0x005CF344 File Offset: 0x005CD744
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D22F RID: 53807
		private BE_Target opl_p0;

		// Token: 0x0400D230 RID: 53808
		private BE_Equal opl_p1;

		// Token: 0x0400D231 RID: 53809
		private int opl_p2;
	}
}
