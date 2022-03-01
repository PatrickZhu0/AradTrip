using System;

namespace behaviac
{
	// Token: 0x02003DC6 RID: 15814
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node17 : Condition
	{
		// Token: 0x0601631B RID: 90907 RVA: 0x006B5963 File Offset: 0x006B3D63
		public Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node17()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x0601631C RID: 90908 RVA: 0x006B5984 File Offset: 0x006B3D84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB77 RID: 64375
		private HMType opl_p0;

		// Token: 0x0400FB78 RID: 64376
		private BE_Operation opl_p1;

		// Token: 0x0400FB79 RID: 64377
		private float opl_p2;
	}
}
