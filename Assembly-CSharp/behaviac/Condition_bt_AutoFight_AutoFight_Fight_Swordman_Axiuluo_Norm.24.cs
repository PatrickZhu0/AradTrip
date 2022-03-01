using System;

namespace behaviac
{
	// Token: 0x0200225F RID: 8799
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node1 : Condition
	{
		// Token: 0x06012E46 RID: 77382 RVA: 0x00591B41 File Offset: 0x0058FF41
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012E47 RID: 77383 RVA: 0x00591B64 File Offset: 0x0058FF64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C855 RID: 51285
		private BE_Target opl_p0;

		// Token: 0x0400C856 RID: 51286
		private BE_Equal opl_p1;

		// Token: 0x0400C857 RID: 51287
		private int opl_p2;
	}
}
