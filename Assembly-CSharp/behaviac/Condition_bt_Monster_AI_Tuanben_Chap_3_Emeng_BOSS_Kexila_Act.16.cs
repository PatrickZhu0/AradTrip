using System;

namespace behaviac
{
	// Token: 0x02003850 RID: 14416
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node4 : Condition
	{
		// Token: 0x06015886 RID: 88198 RVA: 0x0067F622 File Offset: 0x0067DA22
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.55f;
		}

		// Token: 0x06015887 RID: 88199 RVA: 0x0067F644 File Offset: 0x0067DA44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F23F RID: 62015
		private HMType opl_p0;

		// Token: 0x0400F240 RID: 62016
		private BE_Operation opl_p1;

		// Token: 0x0400F241 RID: 62017
		private float opl_p2;
	}
}
