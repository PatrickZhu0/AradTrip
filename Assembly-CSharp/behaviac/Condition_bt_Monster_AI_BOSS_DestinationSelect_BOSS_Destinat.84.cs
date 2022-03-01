using System;

namespace behaviac
{
	// Token: 0x02003030 RID: 12336
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node17 : Condition
	{
		// Token: 0x06014928 RID: 84264 RVA: 0x006316EB File Offset: 0x0062FAEB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014929 RID: 84265 RVA: 0x00631700 File Offset: 0x0062FB00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E286 RID: 57990
		private float opl_p0;
	}
}
