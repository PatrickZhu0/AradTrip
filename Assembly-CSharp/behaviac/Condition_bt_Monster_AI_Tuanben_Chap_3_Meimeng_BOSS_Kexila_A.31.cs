using System;

namespace behaviac
{
	// Token: 0x02003901 RID: 14593
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node65 : Condition
	{
		// Token: 0x060159DD RID: 88541 RVA: 0x0068717D File Offset: 0x0068557D
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node65()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.85f;
		}

		// Token: 0x060159DE RID: 88542 RVA: 0x006871A0 File Offset: 0x006855A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F37C RID: 62332
		private HMType opl_p0;

		// Token: 0x0400F37D RID: 62333
		private BE_Operation opl_p1;

		// Token: 0x0400F37E RID: 62334
		private float opl_p2;
	}
}
