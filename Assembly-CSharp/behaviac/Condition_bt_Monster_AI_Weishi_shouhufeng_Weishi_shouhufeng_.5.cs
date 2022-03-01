using System;

namespace behaviac
{
	// Token: 0x02003DC5 RID: 15813
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node16 : Condition
	{
		// Token: 0x06016319 RID: 90905 RVA: 0x006B5901 File Offset: 0x006B3D01
		public Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node16()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x0601631A RID: 90906 RVA: 0x006B5924 File Offset: 0x006B3D24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB74 RID: 64372
		private HMType opl_p0;

		// Token: 0x0400FB75 RID: 64373
		private BE_Operation opl_p1;

		// Token: 0x0400FB76 RID: 64374
		private float opl_p2;
	}
}
