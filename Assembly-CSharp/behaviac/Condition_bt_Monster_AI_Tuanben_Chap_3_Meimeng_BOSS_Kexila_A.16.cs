using System;

namespace behaviac
{
	// Token: 0x020038E8 RID: 14568
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node4 : Condition
	{
		// Token: 0x060159AD RID: 88493 RVA: 0x0068593E File Offset: 0x00683D3E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060159AE RID: 88494 RVA: 0x00685960 File Offset: 0x00683D60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F358 RID: 62296
		private HMType opl_p0;

		// Token: 0x0400F359 RID: 62297
		private BE_Operation opl_p1;

		// Token: 0x0400F35A RID: 62298
		private float opl_p2;
	}
}
