using System;

namespace behaviac
{
	// Token: 0x0200242F RID: 9263
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node65 : Condition
	{
		// Token: 0x060131B6 RID: 78262 RVA: 0x005AA627 File Offset: 0x005A8A27
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node65()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060131B7 RID: 78263 RVA: 0x005AA65C File Offset: 0x005A8A5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBDD RID: 52189
		private int opl_p0;

		// Token: 0x0400CBDE RID: 52190
		private int opl_p1;

		// Token: 0x0400CBDF RID: 52191
		private int opl_p2;

		// Token: 0x0400CBE0 RID: 52192
		private int opl_p3;
	}
}
