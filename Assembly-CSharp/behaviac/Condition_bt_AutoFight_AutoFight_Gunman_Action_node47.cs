using System;

namespace behaviac
{
	// Token: 0x0200258F RID: 9615
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node47 : Condition
	{
		// Token: 0x06013466 RID: 78950 RVA: 0x005BAB99 File Offset: 0x005B8F99
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node47()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013467 RID: 78951 RVA: 0x005BABB8 File Offset: 0x005B8FB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE91 RID: 52881
		private BE_Target opl_p0;

		// Token: 0x0400CE92 RID: 52882
		private BE_Equal opl_p1;

		// Token: 0x0400CE93 RID: 52883
		private BE_State opl_p2;
	}
}
