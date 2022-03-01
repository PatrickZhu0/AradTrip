using System;

namespace behaviac
{
	// Token: 0x02002304 RID: 8964
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node6 : Condition
	{
		// Token: 0x06012F7F RID: 77695 RVA: 0x0059BC30 File Offset: 0x0059A030
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x06012F80 RID: 77696 RVA: 0x0059BC54 File Offset: 0x0059A054
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C998 RID: 51608
		private BE_Target opl_p0;

		// Token: 0x0400C999 RID: 51609
		private BE_Equal opl_p1;

		// Token: 0x0400C99A RID: 51610
		private int opl_p2;
	}
}
