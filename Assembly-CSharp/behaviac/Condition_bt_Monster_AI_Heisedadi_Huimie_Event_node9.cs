using System;

namespace behaviac
{
	// Token: 0x0200341D RID: 13341
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node9 : Condition
	{
		// Token: 0x06015089 RID: 86153 RVA: 0x00656695 File Offset: 0x00654A95
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node9()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x0601508A RID: 86154 RVA: 0x006566B8 File Offset: 0x00654AB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E95A RID: 59738
		private HMType opl_p0;

		// Token: 0x0400E95B RID: 59739
		private BE_Operation opl_p1;

		// Token: 0x0400E95C RID: 59740
		private float opl_p2;
	}
}
