using System;

namespace behaviac
{
	// Token: 0x020022FE RID: 8958
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node12 : Condition
	{
		// Token: 0x06012F75 RID: 77685 RVA: 0x0059AF66 File Offset: 0x00599366
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node12()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012F76 RID: 77686 RVA: 0x0059AF9C File Offset: 0x0059939C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C990 RID: 51600
		private int opl_p0;

		// Token: 0x0400C991 RID: 51601
		private int opl_p1;

		// Token: 0x0400C992 RID: 51602
		private int opl_p2;

		// Token: 0x0400C993 RID: 51603
		private int opl_p3;
	}
}
