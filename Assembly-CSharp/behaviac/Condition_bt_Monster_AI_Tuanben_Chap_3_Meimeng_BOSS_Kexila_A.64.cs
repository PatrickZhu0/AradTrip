using System;

namespace behaviac
{
	// Token: 0x02003930 RID: 14640
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node4 : Condition
	{
		// Token: 0x06015A3B RID: 88635 RVA: 0x0068857A File Offset: 0x0068697A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015A3C RID: 88636 RVA: 0x0068859C File Offset: 0x0068699C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3CD RID: 62413
		private HMType opl_p0;

		// Token: 0x0400F3CE RID: 62414
		private BE_Operation opl_p1;

		// Token: 0x0400F3CF RID: 62415
		private float opl_p2;
	}
}
