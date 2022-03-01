using System;

namespace behaviac
{
	// Token: 0x02003C7D RID: 15485
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node57 : Condition
	{
		// Token: 0x060160A1 RID: 90273 RVA: 0x006A90EB File Offset: 0x006A74EB
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node57()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060160A2 RID: 90274 RVA: 0x006A9100 File Offset: 0x006A7500
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F933 RID: 63795
		private float opl_p0;
	}
}
