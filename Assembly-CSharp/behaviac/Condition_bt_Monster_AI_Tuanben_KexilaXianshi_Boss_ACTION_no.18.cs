using System;

namespace behaviac
{
	// Token: 0x02003A4B RID: 14923
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node57 : Condition
	{
		// Token: 0x06015C5F RID: 89183 RVA: 0x00693903 File Offset: 0x00691D03
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node57()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06015C60 RID: 89184 RVA: 0x00693918 File Offset: 0x00691D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F585 RID: 62853
		private float opl_p0;
	}
}
