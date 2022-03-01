using System;

namespace behaviac
{
	// Token: 0x020025B7 RID: 9655
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node104 : Condition
	{
		// Token: 0x060134B5 RID: 79029 RVA: 0x005BCA5B File Offset: 0x005BAE5B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node104()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130803;
		}

		// Token: 0x060134B6 RID: 79030 RVA: 0x005BCA7C File Offset: 0x005BAE7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEEF RID: 52975
		private BE_Target opl_p0;

		// Token: 0x0400CEF0 RID: 52976
		private BE_Equal opl_p1;

		// Token: 0x0400CEF1 RID: 52977
		private int opl_p2;
	}
}
