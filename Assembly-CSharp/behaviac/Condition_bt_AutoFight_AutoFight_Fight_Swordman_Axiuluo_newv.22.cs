using System;

namespace behaviac
{
	// Token: 0x0200221E RID: 8734
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node54 : Condition
	{
		// Token: 0x06012DC6 RID: 77254 RVA: 0x0058E0E5 File Offset: 0x0058C4E5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node54()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012DC7 RID: 77255 RVA: 0x0058E108 File Offset: 0x0058C508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7BE RID: 51134
		private BE_Target opl_p0;

		// Token: 0x0400C7BF RID: 51135
		private BE_Equal opl_p1;

		// Token: 0x0400C7C0 RID: 51136
		private int opl_p2;
	}
}
