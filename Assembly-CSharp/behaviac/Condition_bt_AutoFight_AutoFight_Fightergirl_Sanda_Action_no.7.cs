using System;

namespace behaviac
{
	// Token: 0x02001F2D RID: 7981
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node5 : Condition
	{
		// Token: 0x060127FD RID: 75773 RVA: 0x0056A35E File Offset: 0x0056875E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060127FE RID: 75774 RVA: 0x0056A374 File Offset: 0x00568774
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1F4 RID: 49652
		private float opl_p0;
	}
}
