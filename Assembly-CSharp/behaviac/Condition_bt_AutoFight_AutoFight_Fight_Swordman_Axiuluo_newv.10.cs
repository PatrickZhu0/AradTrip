using System;

namespace behaviac
{
	// Token: 0x0200220F RID: 8719
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node31 : Condition
	{
		// Token: 0x06012DA8 RID: 77224 RVA: 0x0058CFF9 File Offset: 0x0058B3F9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node31()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012DA9 RID: 77225 RVA: 0x0058D01C File Offset: 0x0058B41C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C79D RID: 51101
		private BE_Target opl_p0;

		// Token: 0x0400C79E RID: 51102
		private BE_Equal opl_p1;

		// Token: 0x0400C79F RID: 51103
		private int opl_p2;
	}
}
