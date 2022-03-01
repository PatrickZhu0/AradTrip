using System;

namespace behaviac
{
	// Token: 0x020031FC RID: 12796
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3 : Condition
	{
		// Token: 0x06014C82 RID: 85122 RVA: 0x00642C72 File Offset: 0x00641072
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014C83 RID: 85123 RVA: 0x00642C94 File Offset: 0x00641094
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5D6 RID: 58838
		private HMType opl_p0;

		// Token: 0x0400E5D7 RID: 58839
		private BE_Operation opl_p1;

		// Token: 0x0400E5D8 RID: 58840
		private float opl_p2;
	}
}
