using System;

namespace behaviac
{
	// Token: 0x02002307 RID: 8967
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node5 : Condition
	{
		// Token: 0x06012F85 RID: 77701 RVA: 0x0059BD86 File Offset: 0x0059A186
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012F86 RID: 77702 RVA: 0x0059BDBC File Offset: 0x0059A1BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C99E RID: 51614
		private int opl_p0;

		// Token: 0x0400C99F RID: 51615
		private int opl_p1;

		// Token: 0x0400C9A0 RID: 51616
		private int opl_p2;

		// Token: 0x0400C9A1 RID: 51617
		private int opl_p3;
	}
}
