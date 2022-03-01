using System;

namespace behaviac
{
	// Token: 0x02003880 RID: 14464
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node4 : Condition
	{
		// Token: 0x060158E4 RID: 88292 RVA: 0x006816AA File Offset: 0x0067FAAA
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.55f;
		}

		// Token: 0x060158E5 RID: 88293 RVA: 0x006816CC File Offset: 0x0067FACC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F281 RID: 62081
		private HMType opl_p0;

		// Token: 0x0400F282 RID: 62082
		private BE_Operation opl_p1;

		// Token: 0x0400F283 RID: 62083
		private float opl_p2;
	}
}
