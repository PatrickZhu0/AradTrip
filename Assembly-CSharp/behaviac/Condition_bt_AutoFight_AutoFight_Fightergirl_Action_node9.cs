using System;

namespace behaviac
{
	// Token: 0x02001EDE RID: 7902
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node9 : Condition
	{
		// Token: 0x06012761 RID: 75617 RVA: 0x00566705 File Offset: 0x00564B05
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node9()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06012762 RID: 75618 RVA: 0x00566718 File Offset: 0x00564B18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C156 RID: 49494
		private float opl_p0;
	}
}
