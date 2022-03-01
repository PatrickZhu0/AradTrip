using System;

namespace behaviac
{
	// Token: 0x02003F04 RID: 16132
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Moster_zhitianxinchang_Event_node2 : Condition
	{
		// Token: 0x0601657D RID: 91517 RVA: 0x006C27CD File Offset: 0x006C0BCD
		public Condition_bt_Monster_AI_Zhanguo_Moster_zhitianxinchang_Event_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.55f;
		}

		// Token: 0x0601657E RID: 91518 RVA: 0x006C27F0 File Offset: 0x006C0BF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD95 RID: 64917
		private HMType opl_p0;

		// Token: 0x0400FD96 RID: 64918
		private BE_Operation opl_p1;

		// Token: 0x0400FD97 RID: 64919
		private float opl_p2;
	}
}
