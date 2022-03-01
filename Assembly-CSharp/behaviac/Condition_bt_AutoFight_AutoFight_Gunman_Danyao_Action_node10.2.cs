using System;

namespace behaviac
{
	// Token: 0x020025B4 RID: 9652
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node101 : Condition
	{
		// Token: 0x060134AF RID: 79023 RVA: 0x005BC93B File Offset: 0x005BAD3B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node101()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130204;
		}

		// Token: 0x060134B0 RID: 79024 RVA: 0x005BC95C File Offset: 0x005BAD5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEE6 RID: 52966
		private BE_Target opl_p0;

		// Token: 0x0400CEE7 RID: 52967
		private BE_Equal opl_p1;

		// Token: 0x0400CEE8 RID: 52968
		private int opl_p2;
	}
}
