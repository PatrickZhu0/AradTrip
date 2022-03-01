using System;

namespace behaviac
{
	// Token: 0x020025B1 RID: 9649
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node98 : Condition
	{
		// Token: 0x060134A9 RID: 79017 RVA: 0x005BC81A File Offset: 0x005BAC1A
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node98()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130201;
		}

		// Token: 0x060134AA RID: 79018 RVA: 0x005BC83C File Offset: 0x005BAC3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEDD RID: 52957
		private BE_Target opl_p0;

		// Token: 0x0400CEDE RID: 52958
		private BE_Equal opl_p1;

		// Token: 0x0400CEDF RID: 52959
		private int opl_p2;
	}
}
