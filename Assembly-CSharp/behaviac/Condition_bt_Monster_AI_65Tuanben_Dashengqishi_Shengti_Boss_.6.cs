using System;

namespace behaviac
{
	// Token: 0x02002DD4 RID: 11732
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node74 : Condition
	{
		// Token: 0x06014485 RID: 83077 RVA: 0x006182E9 File Offset: 0x006166E9
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node74()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014486 RID: 83078 RVA: 0x0061830C File Offset: 0x0061670C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE3F RID: 56895
		private HMType opl_p0;

		// Token: 0x0400DE40 RID: 56896
		private BE_Operation opl_p1;

		// Token: 0x0400DE41 RID: 56897
		private float opl_p2;
	}
}
