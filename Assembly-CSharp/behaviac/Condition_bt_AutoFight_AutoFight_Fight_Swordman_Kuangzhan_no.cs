using System;

namespace behaviac
{
	// Token: 0x020023DC RID: 9180
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node6 : Condition
	{
		// Token: 0x0601311B RID: 78107 RVA: 0x005A74B8 File Offset: 0x005A58B8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x0601311C RID: 78108 RVA: 0x005A74DC File Offset: 0x005A58DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB47 RID: 52039
		private BE_Target opl_p0;

		// Token: 0x0400CB48 RID: 52040
		private BE_Equal opl_p1;

		// Token: 0x0400CB49 RID: 52041
		private int opl_p2;
	}
}
