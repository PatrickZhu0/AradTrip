using System;

namespace behaviac
{
	// Token: 0x02002F3D RID: 12093
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node15 : Condition
	{
		// Token: 0x0601474B RID: 83787 RVA: 0x006277A5 File Offset: 0x00625BA5
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node15()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601474C RID: 83788 RVA: 0x006277B8 File Offset: 0x00625BB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0BD RID: 57533
		private float opl_p0;
	}
}
