using System;

namespace behaviac
{
	// Token: 0x0200383A RID: 14394
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node3 : Condition
	{
		// Token: 0x0601585A RID: 88154 RVA: 0x0067ED7E File Offset: 0x0067D17E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.55f;
		}

		// Token: 0x0601585B RID: 88155 RVA: 0x0067EDA0 File Offset: 0x0067D1A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F220 RID: 61984
		private HMType opl_p0;

		// Token: 0x0400F221 RID: 61985
		private BE_Operation opl_p1;

		// Token: 0x0400F222 RID: 61986
		private float opl_p2;
	}
}
