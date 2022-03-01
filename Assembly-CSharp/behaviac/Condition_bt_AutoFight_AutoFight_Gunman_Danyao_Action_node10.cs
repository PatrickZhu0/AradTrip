using System;

namespace behaviac
{
	// Token: 0x020025B3 RID: 9651
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node100 : Condition
	{
		// Token: 0x060134AD RID: 79021 RVA: 0x005BC8DB File Offset: 0x005BACDB
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node100()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130203;
		}

		// Token: 0x060134AE RID: 79022 RVA: 0x005BC8FC File Offset: 0x005BACFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEE3 RID: 52963
		private BE_Target opl_p0;

		// Token: 0x0400CEE4 RID: 52964
		private BE_Equal opl_p1;

		// Token: 0x0400CEE5 RID: 52965
		private int opl_p2;
	}
}
