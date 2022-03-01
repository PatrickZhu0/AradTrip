using System;

namespace behaviac
{
	// Token: 0x02002595 RID: 9621
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node89 : Condition
	{
		// Token: 0x06013471 RID: 78961 RVA: 0x005BBC95 File Offset: 0x005BA095
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node89()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130201;
		}

		// Token: 0x06013472 RID: 78962 RVA: 0x005BBCB8 File Offset: 0x005BA0B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE9D RID: 52893
		private BE_Target opl_p0;

		// Token: 0x0400CE9E RID: 52894
		private BE_Equal opl_p1;

		// Token: 0x0400CE9F RID: 52895
		private int opl_p2;
	}
}
