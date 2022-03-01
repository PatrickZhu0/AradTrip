using System;

namespace behaviac
{
	// Token: 0x0200259A RID: 9626
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node94 : Condition
	{
		// Token: 0x0601347B RID: 78971 RVA: 0x005BBE77 File Offset: 0x005BA277
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node94()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130302;
		}

		// Token: 0x0601347C RID: 78972 RVA: 0x005BBE98 File Offset: 0x005BA298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEAC RID: 52908
		private BE_Target opl_p0;

		// Token: 0x0400CEAD RID: 52909
		private BE_Equal opl_p1;

		// Token: 0x0400CEAE RID: 52910
		private int opl_p2;
	}
}
